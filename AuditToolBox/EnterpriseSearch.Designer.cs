namespace AuditToolBox
{
	// Token: 0x02000002 RID: 2
	public partial class EnterpriseSearch : global::System.Windows.Forms.Form
	{
		// Token: 0x06000009 RID: 9 RVA: 0x00002404 File Offset: 0x00000604
		protected override void Dispose(bool disposing)
		{
			bool flag = disposing && this.components != null;
			if (flag)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x0600000A RID: 10 RVA: 0x0000243C File Offset: 0x0000063C
		private void InitializeComponent()
		{
			global::System.ComponentModel.ComponentResourceManager resources = new global::System.ComponentModel.ComponentResourceManager(typeof(global::AuditToolBox.EnterpriseSearch));
			this.panel1 = new global::System.Windows.Forms.Panel();
			this.btnStop = new global::System.Windows.Forms.Button();
			this.btnStart = new global::System.Windows.Forms.Button();
			this.btnFilePath = new global::System.Windows.Forms.Button();
			this.tbFilePath = new global::System.Windows.Forms.TextBox();
			this.label2 = new global::System.Windows.Forms.Label();
			this.tbNames = new global::System.Windows.Forms.TextBox();
			this.label1 = new global::System.Windows.Forms.Label();
			this.panel2 = new global::System.Windows.Forms.Panel();
			this.panel1.SuspendLayout();
			base.SuspendLayout();
			this.panel1.Controls.Add(this.btnStop);
			this.panel1.Controls.Add(this.btnStart);
			this.panel1.Controls.Add(this.btnFilePath);
			this.panel1.Controls.Add(this.tbFilePath);
			this.panel1.Controls.Add(this.label2);
			this.panel1.Controls.Add(this.tbNames);
			this.panel1.Controls.Add(this.label1);
			this.panel1.Dock = global::System.Windows.Forms.DockStyle.Top;
			this.panel1.Location = new global::System.Drawing.Point(0, 0);
			this.panel1.Name = "panel1";
			this.panel1.Size = new global::System.Drawing.Size(1258, 132);
			this.panel1.TabIndex = 1;
			this.btnStop.BackColor = global::System.Drawing.Color.Red;
			this.btnStop.Location = new global::System.Drawing.Point(117, 102);
			this.btnStop.Name = "btnStop";
			this.btnStop.Size = new global::System.Drawing.Size(86, 23);
			this.btnStop.TabIndex = 5;
			this.btnStop.Text = "\ud83d\uded1停止";
			this.btnStop.UseVisualStyleBackColor = false;
			this.btnStop.Click += new global::System.EventHandler(this.btnStop_Click);
			this.btnStart.BackColor = global::System.Drawing.Color.Green;
			this.btnStart.Location = new global::System.Drawing.Point(14, 102);
			this.btnStart.Name = "btnStart";
			this.btnStart.Size = new global::System.Drawing.Size(97, 23);
			this.btnStart.TabIndex = 5;
			this.btnStart.Text = "▶开始截图";
			this.btnStart.UseVisualStyleBackColor = false;
			this.btnStart.Click += new global::System.EventHandler(this.btnStart_Click);
			this.btnFilePath.Location = new global::System.Drawing.Point(300, 74);
			this.btnFilePath.Name = "btnFilePath";
			this.btnFilePath.Size = new global::System.Drawing.Size(43, 23);
			this.btnFilePath.TabIndex = 4;
			this.btnFilePath.Text = "...";
			this.btnFilePath.UseVisualStyleBackColor = true;
			this.btnFilePath.Click += new global::System.EventHandler(this.btnFilePath_Click);
			this.tbFilePath.Location = new global::System.Drawing.Point(14, 75);
			this.tbFilePath.Name = "tbFilePath";
			this.tbFilePath.Size = new global::System.Drawing.Size(286, 21);
			this.tbFilePath.TabIndex = 3;
			this.label2.AutoSize = true;
			this.label2.Location = new global::System.Drawing.Point(12, 60);
			this.label2.Name = "label2";
			this.label2.Size = new global::System.Drawing.Size(113, 12);
			this.label2.TabIndex = 2;
			this.label2.Text = "请选择截图输出路径";
			this.tbNames.Location = new global::System.Drawing.Point(14, 24);
			this.tbNames.Multiline = true;
			this.tbNames.Name = "tbNames";
			this.tbNames.Size = new global::System.Drawing.Size(1215, 33);
			this.tbNames.TabIndex = 1;
			this.label1.AutoSize = true;
			this.label1.Location = new global::System.Drawing.Point(12, 9);
			this.label1.Name = "label1";
			this.label1.Size = new global::System.Drawing.Size(161, 12);
			this.label1.TabIndex = 0;
			this.label1.Text = "请输入企业名称，以逗号分隔";
			this.panel2.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.panel2.Location = new global::System.Drawing.Point(0, 132);
			this.panel2.Name = "panel2";
			this.panel2.Size = new global::System.Drawing.Size(1258, 461);
			this.panel2.TabIndex = 2;
			base.AutoScaleDimensions = new global::System.Drawing.SizeF(6f, 12f);
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
			base.ClientSize = new global::System.Drawing.Size(1258, 593);
			base.Controls.Add(this.panel2);
			base.Controls.Add(this.panel1);
			base.Name = "EnterpriseSearch";
			this.Text = "企业查询截图工具";
			base.WindowState = global::System.Windows.Forms.FormWindowState.Maximized;
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			base.ResumeLayout(false);
		}

		// Token: 0x04000005 RID: 5
		private global::System.ComponentModel.IContainer components = null;

		// Token: 0x04000006 RID: 6
		private global::System.Windows.Forms.Panel panel1;

		// Token: 0x04000007 RID: 7
		private global::System.Windows.Forms.Button btnStart;

		// Token: 0x04000008 RID: 8
		private global::System.Windows.Forms.Button btnFilePath;

		// Token: 0x04000009 RID: 9
		private global::System.Windows.Forms.TextBox tbFilePath;

		// Token: 0x0400000A RID: 10
		private global::System.Windows.Forms.Label label2;

		// Token: 0x0400000B RID: 11
		private global::System.Windows.Forms.TextBox tbNames;

		// Token: 0x0400000C RID: 12
		private global::System.Windows.Forms.Label label1;

		// Token: 0x0400000D RID: 13
		private global::System.Windows.Forms.Panel panel2;

		// Token: 0x0400000E RID: 14
		private global::System.Windows.Forms.Button btnStop;
	}
}
