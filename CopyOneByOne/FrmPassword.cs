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
    public partial class FrmPassword : Form
    {
        Utils _objUtils = null;
        public bool IsUpdate { get; set; }

        #region Constructors

        public FrmPassword()
        {
            InitializeComponent();
            this.IsUpdate = false;
            Init();
        }

        public FrmPassword(bool blnUpdate)
        {
            InitializeComponent();
            this.IsUpdate = blnUpdate;
            Init();
        }

        #endregion

        #region Private methods
        private void Init()
        {
            if(!IsUpdate)
            {
                txtCurrentPassword.ReadOnly = true;
                txtCurrentPassword.Hide();
                lblCurrentPassword.Hide();
                this.ActiveControl = txtNewPassword1;
            }
            _objUtils = new Utils();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Validate();
        }

        new private void Validate()
        {
            try
            {
                string strNewPassword1 = txtNewPassword1.Text;
                string strNewPassword2 = txtNewPassword2.Text;
                if (!IsUpdate)
                {
                    if (ValidateNewPassword())
                    {
                        Settings objSettings = new Settings();
                        objSettings.Password = strNewPassword1;
                        _objUtils.UpdateSettings(objSettings);
                        this.Hide();

                        FrmMain frmMain = new FrmMain();
                        frmMain.Show();
                    }
                }
                else
                {
                    if (ValidateCurrentPassword())
                    {
                        if (ValidateNewPassword())
                        {
                            Settings objSettings = _objUtils.GetSettings();
                            objSettings.Password = strNewPassword1;
                            _objUtils.UpdateSettings(objSettings);
                            _objUtils.ShowMsg(Strings.SuccesPasswordUpdate);
                            this.Close();
                        }
                    }
                }
            }
            catch(Exception ex)
            {
                _objUtils.ShowMsg(ex.Message, MessageType.Error);
            }
        }
        private bool ValidateCurrentPassword()
        {
            bool blnRetVal = false;
            string strCurrentPassword = txtCurrentPassword.Text;
            if(strCurrentPassword == string.Empty)
            {
                lblErr.Text = Strings.ErrEmptyDetails;
            }
            else
            {
                Settings objSettings = _objUtils.GetSettings();
                if (objSettings == null)
                {
                    lblErr.Text = Strings.ErrFileCorrupted;
                }
                else if( objSettings.Password != strCurrentPassword)
                {
                    lblErr.Text = Strings.ErrInvalidPassword;
                }
                else if(objSettings.Password == strCurrentPassword)
                {
                    blnRetVal = true;
                }
            }
            return blnRetVal;
        }
        private bool ValidateNewPassword()
        {
            bool blnRetVal = true;
            string strNewPassword1 = txtNewPassword1.Text;
            string strNewPassword2 = txtNewPassword2.Text;
            if (strNewPassword1 == string.Empty || strNewPassword2 == string.Empty)
            {
                lblErr.Text = Strings.ErrEmptyDetails;
                blnRetVal = false;
            }
            else if (strNewPassword1 != strNewPassword2)
            {
                lblErr.Text = Strings.ErrUnequalPasswords;
                blnRetVal = false;
            }
            return blnRetVal;
        }

        private void txtNewPassword2_KeyDown(object sender, KeyEventArgs e)
        {
            Keys key = e.KeyCode;
            if(key == Keys.Enter)
            {
                Validate();
            }
            e.Handled = true;
        }

        #endregion
    }
}
