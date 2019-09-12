using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AuditToolBox
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.No;
            Close();
            Dispose();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (txtPassword.Text.Trim() == "940126")
            {
                DialogResult = DialogResult.OK;
                Close();
                Dispose();
            }
            else
            {
                MessageBox.Show("密码错误！");
            }
        }

        private void txtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnOK_Click(null, null);
            }
        }
    }
}
