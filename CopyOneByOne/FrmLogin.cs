using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CopyOneByOne
{
    public partial class FrmLogin : Form
    {
        private string Password { set;get;}
        public FrmLogin()
        {
            InitializeComponent();
        }

        public FrmLogin(string strPassword)
        {
            this.Password = strPassword;
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            Validate();
        }

        /// <summary>
        /// Validats the entered password
        /// </summary>
        new private void Validate()
        {
            if (txtPassword.Text == string.Empty)
            {
                lblErr.Text = Strings.ErrEmptyPassword;
            }
            else if (txtPassword.Text != this.Password)
            {
                lblErr.Text = Strings.ErrInvalidPassword;
            }
            else if (txtPassword.Text == this.Password)
            {
                this.Hide();
                FrmMain frmMain = new FrmMain();
                frmMain.Show();
            }
        }

        /// <summary>
        /// Validating password on pressing enter
        /// </summary>
        private void txtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            Keys key = e.KeyCode;
            if(key == Keys.Enter)
            {
                Validate(); 
            }
            e.Handled = true;
        }
    }
}
