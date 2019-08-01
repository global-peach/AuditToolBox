using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using Awesomium.Core;
using Awesomium.Windows.Forms;

namespace AuditToolBox
{
	// Token: 0x02000003 RID: 3
	public partial class ExpressSearch : Form
	{
		// Token: 0x0600000B RID: 11 RVA: 0x000029E8 File Offset: 0x00000BE8
		public ExpressSearch()
		{
			this.InitializeComponent();
			this.bro = new WebControl();
			this.bro.Dock = DockStyle.Fill;
			this.bro.Name = "webControl1";
			this.panel2.Controls.Add(this.bro);
		}

		// Token: 0x0600000C RID: 12 RVA: 0x00002A4C File Offset: 0x00000C4C
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

		// Token: 0x0600000D RID: 13 RVA: 0x00002A90 File Offset: 0x00000C90
		private void btnExcelPath_Click(object sender, EventArgs e)
		{
			OpenFileDialog dialog = new OpenFileDialog();
			dialog.Title = "请选择快递单号Excel";
			bool flag = dialog.ShowDialog() == DialogResult.OK;
			if (flag)
			{
				this.tbExcelPath.Text = dialog.FileName;
			}
		}

		// Token: 0x0600000E RID: 14 RVA: 0x00002AD1 File Offset: 0x00000CD1
		private void btnStart_Click(object sender, EventArgs e)
		{
		}

		// Token: 0x0600000F RID: 15 RVA: 0x00002AD4 File Offset: 0x00000CD4
		private void btnStop_Click(object sender, EventArgs e)
		{
			this.bro.DocumentReady -= this.Bro_DocumentReady;
			this.bro.Stop();
			MessageBox.Show("已停止！");
		}

		// Token: 0x06000010 RID: 16 RVA: 0x00002B06 File Offset: 0x00000D06
		private void Bro_DocumentReady(object sender, DocumentReadyEventArgs e)
		{
			throw new NotImplementedException();
		}

		// Token: 0x0400000F RID: 15
		private WebControl bro;
	}
}
