namespace AuditToolBox
{
	// Token: 0x02000003 RID: 3
	public partial class ExpressSearch : global::System.Windows.Forms.Form
	{
		// Token: 0x06000011 RID: 17 RVA: 0x00002B10 File Offset: 0x00000D10
		protected override void Dispose(bool disposing)
		{
			bool flag = disposing && this.components != null;
			if (flag)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x06000012 RID: 18 RVA: 0x00002B48 File Offset: 0x00000D48
		private void InitializeComponent()
		{
			this.panel1 = new global::System.Windows.Forms.Panel();
			this.label2 = new global::System.Windows.Forms.Label();
			this.btnExcelPath = new global::System.Windows.Forms.Button();
			this.tbExcelPath = new global::System.Windows.Forms.TextBox();
			this.btnFilePath = new global::System.Windows.Forms.Button();
			this.tbFilePath = new global::System.Windows.Forms.TextBox();
			this.label1 = new global::System.Windows.Forms.Label();
			this.btnStop = new global::System.Windows.Forms.Button();
			this.btnStart = new global::System.Windows.Forms.Button();
			this.panel2 = new global::System.Windows.Forms.Panel();
			this.panel1.SuspendLayout();
			base.SuspendLayout();
			this.panel1.Controls.Add(this.btnStop);
			this.panel1.Controls.Add(this.btnStart);
			this.panel1.Controls.Add(this.btnFilePath);
			this.panel1.Controls.Add(this.tbFilePath);
			this.panel1.Controls.Add(this.label1);
			this.panel1.Controls.Add(this.btnExcelPath);
			this.panel1.Controls.Add(this.tbExcelPath);
			this.panel1.Controls.Add(this.label2);
			this.panel1.Dock = global::System.Windows.Forms.DockStyle.Top;
			this.panel1.Location = new global::System.Drawing.Point(0, 0);
			this.panel1.Name = "panel1";
			this.panel1.Size = new global::System.Drawing.Size(800, 125);
			this.panel1.TabIndex = 0;
			this.label2.AutoSize = true;
			this.label2.Location = new global::System.Drawing.Point(12, 9);
			this.label2.Name = "label2";
			this.label2.Size = new global::System.Drawing.Size(119, 12);
			this.label2.TabIndex = 3;
			this.label2.Text = "请选择运单Excel文件";
			this.btnExcelPath.Location = new global::System.Drawing.Point(300, 23);
			this.btnExcelPath.Name = "btnExcelPath";
			this.btnExcelPath.Size = new global::System.Drawing.Size(43, 23);
			this.btnExcelPath.TabIndex = 6;
			this.btnExcelPath.Text = "...";
			this.btnExcelPath.UseVisualStyleBackColor = true;
			this.btnExcelPath.Click += new global::System.EventHandler(this.btnExcelPath_Click);
			this.tbExcelPath.Location = new global::System.Drawing.Point(14, 24);
			this.tbExcelPath.Name = "tbExcelPath";
			this.tbExcelPath.Size = new global::System.Drawing.Size(286, 21);
			this.tbExcelPath.TabIndex = 5;
			this.btnFilePath.Location = new global::System.Drawing.Point(300, 63);
			this.btnFilePath.Name = "btnFilePath";
			this.btnFilePath.Size = new global::System.Drawing.Size(43, 23);
			this.btnFilePath.TabIndex = 9;
			this.btnFilePath.Text = "...";
			this.btnFilePath.UseVisualStyleBackColor = true;
			this.btnFilePath.Click += new global::System.EventHandler(this.btnFilePath_Click);
			this.tbFilePath.Location = new global::System.Drawing.Point(14, 64);
			this.tbFilePath.Name = "tbFilePath";
			this.tbFilePath.Size = new global::System.Drawing.Size(286, 21);
			this.tbFilePath.TabIndex = 8;
			this.label1.AutoSize = true;
			this.label1.Location = new global::System.Drawing.Point(12, 49);
			this.label1.Name = "label1";
			this.label1.Size = new global::System.Drawing.Size(113, 12);
			this.label1.TabIndex = 7;
			this.label1.Text = "请选择截图输出路径";
			this.btnStop.BackColor = global::System.Drawing.Color.Red;
			this.btnStop.Location = new global::System.Drawing.Point(117, 91);
			this.btnStop.Name = "btnStop";
			this.btnStop.Size = new global::System.Drawing.Size(86, 23);
			this.btnStop.TabIndex = 10;
			this.btnStop.Text = "\ud83d\uded1停止";
			this.btnStop.UseVisualStyleBackColor = false;
			this.btnStop.Click += new global::System.EventHandler(this.btnStop_Click);
			this.btnStart.BackColor = global::System.Drawing.Color.Green;
			this.btnStart.Location = new global::System.Drawing.Point(14, 91);
			this.btnStart.Name = "btnStart";
			this.btnStart.Size = new global::System.Drawing.Size(97, 23);
			this.btnStart.TabIndex = 11;
			this.btnStart.Text = "▶开始截图";
			this.btnStart.UseVisualStyleBackColor = false;
			this.btnStart.Click += new global::System.EventHandler(this.btnStart_Click);
			this.panel2.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.panel2.Location = new global::System.Drawing.Point(0, 125);
			this.panel2.Name = "panel2";
			this.panel2.Size = new global::System.Drawing.Size(800, 325);
			this.panel2.TabIndex = 1;
			base.AutoScaleDimensions = new global::System.Drawing.SizeF(6f, 12f);
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
			base.ClientSize = new global::System.Drawing.Size(800, 450);
			base.Controls.Add(this.panel2);
			base.Controls.Add(this.panel1);
			base.Name = "ExpressSearch";
			this.Text = "快递单号查询截图工具";
			base.WindowState = global::System.Windows.Forms.FormWindowState.Maximized;
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			base.ResumeLayout(false);
		}

		// Token: 0x04000010 RID: 16
		private global::System.ComponentModel.IContainer components = null;

		// Token: 0x04000011 RID: 17
		private global::System.Windows.Forms.Panel panel1;

		// Token: 0x04000012 RID: 18
		private global::System.Windows.Forms.Label label2;

		// Token: 0x04000013 RID: 19
		private global::System.Windows.Forms.Button btnExcelPath;

		// Token: 0x04000014 RID: 20
		private global::System.Windows.Forms.TextBox tbExcelPath;

		// Token: 0x04000015 RID: 21
		private global::System.Windows.Forms.Button btnFilePath;

		// Token: 0x04000016 RID: 22
		private global::System.Windows.Forms.TextBox tbFilePath;

		// Token: 0x04000017 RID: 23
		private global::System.Windows.Forms.Label label1;

		// Token: 0x04000018 RID: 24
		private global::System.Windows.Forms.Button btnStop;

		// Token: 0x04000019 RID: 25
		private global::System.Windows.Forms.Button btnStart;

		// Token: 0x0400001A RID: 26
		private global::System.Windows.Forms.Panel panel2;
	}
}
