namespace AuditToolBox
{
	// Token: 0x02000004 RID: 4
	public partial class FunctionChoose : global::System.Windows.Forms.Form
	{
		// Token: 0x06000016 RID: 22 RVA: 0x000031B0 File Offset: 0x000013B0
		protected override void Dispose(bool disposing)
		{
			bool flag = disposing && this.components != null;
			if (flag)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x06000017 RID: 23 RVA: 0x000031E8 File Offset: 0x000013E8
		private void InitializeComponent()
		{
			this.button1 = new global::System.Windows.Forms.Button();
			this.button2 = new global::System.Windows.Forms.Button();
			base.SuspendLayout();
			this.button1.Location = new global::System.Drawing.Point(12, 12);
			this.button1.Name = "button1";
			this.button1.Size = new global::System.Drawing.Size(300, 70);
			this.button1.TabIndex = 0;
			this.button1.Text = "企查查";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new global::System.EventHandler(this.button1_Click);
			this.button2.Location = new global::System.Drawing.Point(12, 110);
			this.button2.Name = "button2";
			this.button2.Size = new global::System.Drawing.Size(300, 70);
			this.button2.TabIndex = 0;
			this.button2.Text = "快递单号";
			this.button2.UseVisualStyleBackColor = true;
			this.button2.Click += new global::System.EventHandler(this.button2_Click);
			base.AutoScaleDimensions = new global::System.Drawing.SizeF(6f, 12f);
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
			base.ClientSize = new global::System.Drawing.Size(332, 201);
			base.Controls.Add(this.button2);
			base.Controls.Add(this.button1);
			base.Name = "FunctionChoose";
			base.StartPosition = global::System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "功能列表";
			base.ResumeLayout(false);
		}

		// Token: 0x0400001B RID: 27
		private global::System.ComponentModel.IContainer components = null;

		// Token: 0x0400001C RID: 28
		private global::System.Windows.Forms.Button button1;

		// Token: 0x0400001D RID: 29
		private global::System.Windows.Forms.Button button2;
	}
}
