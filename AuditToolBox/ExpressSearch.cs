using AuditToolBox.HTTPRequest.Express;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace AuditToolBox
{
    // Token: 0x02000003 RID: 3
    public partial class ExpressSearch : Form
    {
        private const string REQ_URL = "https://bsp-oisp.sf-express.com/bsp-oisp/sfexpressService";

        private const string CLIENT_CODE = "";//此处替换为您在丰桥平台获取的顾客编码

        private const string CHECKWORD = "";//此处替换为您在丰桥平台获取的校验码

        private List<Thread> threads = new List<Thread>();

        private CompanyEnum companyEnum;

        private ConcurrentQueue<string> numQueue = new ConcurrentQueue<string>();

        private Dictionary<string, Dictionary<DateTime, string>> expressContextDict = new Dictionary<string, Dictionary<DateTime, string>>();
        
        public ExpressSearch()
		{
			this.InitializeComponent();
            List<Tuple<string, CompanyEnum>> cpmpanyList = new List<Tuple<string, CompanyEnum>>();
            foreach (CompanyEnum item in Enum.GetValues(typeof(CompanyEnum)))
            {
                cpmpanyList.Add(new Tuple<string, CompanyEnum>(item.ToString(), item));
            }
            this.cmbCompany.DataSource = cpmpanyList;
            this.cmbCompany.DisplayMember = "Item1";
            this.cmbCompany.ValueMember = "Item2";
        }
        
		private void btnFilePath_Click(object sender, EventArgs e)
		{
			FolderBrowserDialog dialog = new FolderBrowserDialog();
			dialog.Description = "请选择保存Excel的文件夹";
			bool flag = dialog.ShowDialog() == DialogResult.OK;
			if (flag)
			{
				this.tbFilePath.Text = dialog.SelectedPath;
			}
		}
        
		private void btnStart_Click(object sender, EventArgs e)
		{
            bool flag = string.IsNullOrEmpty(this.cmbCompany.Text) || string.IsNullOrEmpty(this.tbNums.Text) || string.IsNullOrEmpty(this.tbFilePath.Text);
            if (flag)
            {
                MessageBox.Show("请输入快递单号，并选择输出文件保存路径！");
            }
            else
            {
                listBoxInfo.Items.Clear();
                companyEnum = (CompanyEnum)this.cmbCompany.SelectedValue;
                this.numQueue = new ConcurrentQueue<string>();
                foreach (string name in this.tbNums.Text.Split(new char[]
                {
                    ',',
                    '\r',
                    '\n',
                    '，'
                }))
                {
                    StringBuilder rBuilder = new StringBuilder(name);
                    foreach (char rInvalidChar in System.IO.Path.GetInvalidFileNameChars())
                    {
                        rBuilder.Replace(rInvalidChar.ToString(), string.Empty);
                    }
                    bool flag2 = rBuilder.ToString().Trim().Length > 0;
                    if (flag2)
                    {
                        this.numQueue.Enqueue(rBuilder.ToString().Trim());
                    }
                }
                this.Start();
            }
        }
        
		private void btnStop_Click(object sender, EventArgs e)
		{
            numQueue = new ConcurrentQueue<string>();
            foreach (var thread in threads)
            {
                thread.Abort();
            }
			MessageBox.Show("已停止！");
		}

        private void Start()
        {
            for (int i = 0; i < 8; i++)
            {
                Thread thread = new Thread(ThreadStart);
                thread.Start();
                threads.Add(thread);
            }
            //等待处理完成
            while (!numQueue.IsEmpty)
            {
                Thread.Sleep(100);
            }
            //生成excel
            ExportExcel();
            MessageBox.Show("已完成！");
        }

        private void ThreadStart()
        {
            while (!numQueue.IsEmpty)
            {
                string num = null;
                if (numQueue.TryDequeue(out num) && !string.IsNullOrEmpty(num))
                {
                    try
                    {
                        SearchExpress(companyEnum, num);
                    }
                    catch (Exception ex)
                    {
                        ShowInfo(string.Format("快递信息查询异常！单号：{0}，异常信息：{1}", num,ex.Message));
                    }
                }
            }
        }

        private void SearchExpress(CompanyEnum company, string num)
        {
            if (company == CompanyEnum.顺丰快递)
            {
                string respXml = callSfExpressServiceByCSIM(REQ_URL, num, CLIENT_CODE, CHECKWORD);
                if (!string.IsNullOrEmpty(respXml))
                {


                }
            }
            else
            {
                var data = KuaiDiRequest.GetOrderInfo(company, num);
                if (data.error_code != 0 || !string.IsNullOrEmpty(data.msg))
                {
                    ShowInfo(string.Format("单号：{0}，信息：{1}", num, data.msg));
                }
                else
                {
                    ShowInfo(string.Format("单号：{0}查询完成", num));
                    var context = new Dictionary<DateTime, string>();
                    foreach (var item in data.data.info.context)
                    {
                        context[new DateTime(1970, 1, 1).AddSeconds(item.time)] = item.desc;
                    }
                    expressContextDict[num] = context;
                }
            }
        }

        private void ShowInfo(string info)
        {
            if (InvokeRequired)
            {
                this.Invoke(new Action<string>(ShowInfo), info);
                return;
            }
            listBoxInfo.Items.Add(info);
        }

        private void ExportExcel()
        {
            if (expressContextDict == null || expressContextDict.Count == 0)
            {
                return;
            }
            try
            {
                XSSFWorkbook workbook = new XSSFWorkbook();
                ISheet sheet = workbook.CreateSheet(companyEnum.ToString());
                int rowNo = 0;
                foreach (var express in expressContextDict)
                {
                    IRow row = sheet.CreateRow(rowNo);
                    ICell cell = row.CreateCell(0);
                    cell.SetCellValue(express.Key);
                    int cellNo = 1;
                    foreach (var info in express.Value)
                    {
                        cell = row.CreateCell(cellNo);
                        cell.SetCellValue(string.Format("{0}:{1}", info.Key, info.Value));
                    }
                    rowNo++;
                }
                //转为字节数组  
                MemoryStream stream = new MemoryStream();
                workbook.Write(stream);
                var buf = stream.ToArray();
                if (!Directory.Exists(this.tbFilePath.Text))
                {
                    Directory.CreateDirectory(this.tbFilePath.Text);
                }
                string fileName = Path.Combine(this.tbFilePath.Text, "快递查询结果_" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".xlsx");
                using (FileStream fs = File.Create(fileName))
                {
                    fs.Write(buf, 0, buf.Length);
                    fs.Flush();
                }
                ShowInfo("导出完成");
            }
            catch (Exception ex)
            {
                ShowInfo("导出异常：" + ex.Message + ex.StackTrace);
            }
        }

        private string callSfExpressServiceByCSIM(string reqURL, string num, string clientCode, string checkword)
        {
            string result = "";

            string reqXml = "<Request service=\"RouteService\" lang=\"zh-CN\"><Head>{0}</Head><Body><RouteRequest tracking_type=\"1\" method_type=\"1\" tracking_number=\"{1}\"/></Body></Request>";
            string myReqXML = string.Format(reqXml, CLIENT_CODE, num);
            MD5 md5 = new MD5CryptoServiceProvider();
            string verifyCode = Convert.ToBase64String(md5.ComputeHash(Encoding.UTF8.GetBytes(myReqXML + checkword)));

            HttpWebRequest request = WebRequest.Create(reqURL) as HttpWebRequest;
            request.Method = "POST";
            request.ContentType = "application/x-www-form-urlencoded";
            StringBuilder val2 = new StringBuilder();
            val2.AppendFormat("{0}={1}", "xml", myReqXML);
            val2.Append("&");
            val2.AppendFormat("{0}={1}", "verifyCode", verifyCode);
            byte[] bytes = Encoding.UTF8.GetBytes(val2.ToString());
            request.ContentLength = bytes.Length;
            using (Stream reqStream = request.GetRequestStream())
            {
                reqStream.Write(bytes, 0, bytes.Length);
                WebResponse response = request.GetResponse();
                using (StreamReader reader = new StreamReader(response.GetResponseStream(), Encoding.UTF8))
                {
                    result = reader.ReadToEnd();
                }
            }

            return result;
        }
    }
}

