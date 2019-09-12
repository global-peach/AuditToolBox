using System;
using System.Windows.Forms;

namespace AuditToolBox
{
	internal static class Program
	{
		[STAThread]
		private static void Main()
		{
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
            if (new Login().ShowDialog() == DialogResult.OK)
            {
                Application.Run(new FunctionChoose());
            }
            Environment.Exit(0);
		}
	}
}
