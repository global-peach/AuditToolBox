using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace AuditToolBox
{
	// Token: 0x02000004 RID: 4
	public partial class FunctionChoose : Form
	{
		// Token: 0x06000013 RID: 19 RVA: 0x0000315D File Offset: 0x0000135D
		public FunctionChoose()
		{
			this.InitializeComponent();
		}

		// Token: 0x06000014 RID: 20 RVA: 0x00003178 File Offset: 0x00001378
		private void button1_Click(object sender, EventArgs e)
		{
			EnterpriseSearch enterpriseSearch = new EnterpriseSearch();
			enterpriseSearch.Show(this);
		}

		// Token: 0x06000015 RID: 21 RVA: 0x00003194 File Offset: 0x00001394
		private void button2_Click(object sender, EventArgs e)
		{
			ExpressSearch expressSearch = new ExpressSearch();
			expressSearch.Show(this);
		}
	}
}
