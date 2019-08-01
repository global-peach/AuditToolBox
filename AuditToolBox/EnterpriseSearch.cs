using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Awesomium.Core;
using Awesomium.Windows.Forms;

namespace AuditToolBox
{
	// Token: 0x02000002 RID: 2
	public partial class EnterpriseSearch : Form
	{
		// Token: 0x06000001 RID: 1 RVA: 0x00002050 File Offset: 0x00000250
		public EnterpriseSearch()
		{
			this.InitializeComponent();
            this.Icon = Properties.Resources.Icon;
			this.bro = new WebControl();
			this.bro.Dock = DockStyle.Fill;
			this.bro.Name = "webControl1";
			this.panel2.Controls.Add(this.bro);
			this.bro.Source = new Uri("https://www.qichacha.com");
		}

		// Token: 0x06000002 RID: 2 RVA: 0x000020E8 File Offset: 0x000002E8
		private void Bro_DocumentReady(object sender, DocumentReadyEventArgs e)
		{
			bool flag = e.ReadyState == DocumentReadyState.Loaded;
			if (flag)
			{
				bool flag2 = this.currentProcedu == 0;
				if (flag2)
				{
					this.currentProcedu = 1;
					string a = this.bro.ExecuteJavascriptWithResult("$('#searchlist tr:first a.ma_h1').attr('href')").ToString();
					this.bro.Source = new Uri("https://www.qichacha.com" + a);
				}
				else
				{
					this.PrintScreen();
					this.nameDict[this.currentName] = true;
					this.Start();
				}
			}
		}

		// Token: 0x06000003 RID: 3 RVA: 0x00002174 File Offset: 0x00000374
		private void btnFilePath_Click(object sender, EventArgs e)
		{
			FolderBrowserDialog dialog = new FolderBrowserDialog();
			dialog.Description = "请选择保存截图的文件夹";
			bool flag = dialog.ShowDialog() == DialogResult.OK;
			if (flag)
			{
				this.tbFilePath.Text = dialog.SelectedPath;
			}
		}

		// Token: 0x06000004 RID: 4 RVA: 0x000021B8 File Offset: 0x000003B8
		private void btnStart_Click(object sender, EventArgs e)
		{
			bool flag = string.IsNullOrEmpty(this.tbNames.Text) || string.IsNullOrEmpty(this.tbFilePath.Text);
			if (flag)
			{
				MessageBox.Show("请输入企业名称，并选择截图保存路径！");
			}
			else
			{
				this.nameDict.Clear();
				foreach (string name in this.tbNames.Text.Split(new char[]
				{
					',',
					'\r',
					'\n',
					'，'
				}))
				{
					StringBuilder rBuilder = new StringBuilder(name);
					foreach (char rInvalidChar in Path.GetInvalidFileNameChars())
					{
						rBuilder.Replace(rInvalidChar.ToString(), string.Empty);
					}
					bool flag2 = rBuilder.ToString().Trim().Length > 0;
					if (flag2)
					{
						this.nameDict.Add(rBuilder.ToString().Trim(), false);
					}
				}
				this.bro.DocumentReady += this.Bro_DocumentReady;
				this.Start();
			}
		}

		// Token: 0x06000005 RID: 5 RVA: 0x000022DC File Offset: 0x000004DC
		private void Start()
		{
			this.currentName = this.nameDict.FirstOrDefault(p => p.Value == false).Key;
			bool flag = this.currentName == null;
			if (flag)
			{
				this.bro.DocumentReady -= this.Bro_DocumentReady;
				MessageBox.Show("全部完成！");
			}
			else
			{
				this.currentProcedu = 0;
				this.bro.Source = new Uri("https://www.qichacha.com/search?key=" + this.currentName);
			}
		}

		// Token: 0x06000006 RID: 6 RVA: 0x00002380 File Offset: 0x00000580
		private void PrintScreen()
		{
			Image img = ScreenCapture.captureControl(this.panel2);
			img.Save(this.tbFilePath.Text + "\\" + this.currentName + ".png");
		}

		// Token: 0x06000007 RID: 7 RVA: 0x000023C1 File Offset: 0x000005C1
		private void Form1_FormClosing(object sender, FormClosingEventArgs e)
		{
			this.bro.Dispose();
		}

		// Token: 0x06000008 RID: 8 RVA: 0x000023D0 File Offset: 0x000005D0
		private void btnStop_Click(object sender, EventArgs e)
		{
			this.bro.DocumentReady -= this.Bro_DocumentReady;
			this.bro.Stop();
			MessageBox.Show("已停止！");
		}

		// Token: 0x04000001 RID: 1
		private WebControl bro;

		// Token: 0x04000002 RID: 2
		private Dictionary<string, bool> nameDict = new Dictionary<string, bool>();

		// Token: 0x04000003 RID: 3
		private string currentName = "";

		// Token: 0x04000004 RID: 4
		private int currentProcedu = 0;
	}
}
