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
    public partial class FrmCreate : Form
    {
        Utils _objUtils = null;
        FrmMain frmMain = null;
        public static bool IsUpdate { get; set; }
        public static Shortcut Shortcut { get; set; }

        /// <summary>
        /// Constructors
        /// </summary>
        public FrmCreate()
        {
            Init();
        }

        public FrmCreate(FrmMain frmMain)
        {
            Init();
            this.frmMain = frmMain;
        }

        private void Init()
        {
            InitializeComponent();
            _objUtils = new Utils();
        }

        /// <summary>
        /// Create click
        /// </summary>
        private void btnCreate_Click(object sender, EventArgs e)
        {
            List<string> lstShortcutData = new List<string>();
            try
            {
                #region Validation

                bool blnIsValid = true;
                if (string.IsNullOrWhiteSpace(txtName.Text))
                {
                    _objUtils.ShowMsg(Strings.ErrEmptySnippetName);
                    blnIsValid = false;
                }
                else if (string.IsNullOrWhiteSpace(txtData.Text))
                {
                    _objUtils.ShowMsg(Strings.ErrEmptySnippetData);
                    blnIsValid = false;
                }
                if (!blnIsValid)
                {
                    return;
                }
                if(!IsUpdate)
                {
                    List<Shortcut> lstShortcuts = _objUtils.GetShortcuts();
                    if(lstShortcuts != null)
                    {
                        Shortcut objShortcutTemp = lstShortcuts.Where(s => s.Name == txtName.Text).FirstOrDefault();
                        if (objShortcutTemp != null)
                        {
                            _objUtils.ShowMsg("Another snippet exists with the name "+txtName.Text,MessageType.Error);
                            blnIsValid = false;
                        }
                    } 
                }
                if (!blnIsValid)
                {
                    return;
                }
                

                #endregion

                if (chkSplit.Checked)
                {
                    lstShortcutData = txtData.Text.Split('\n').ToList();
                    lstShortcutData.RemoveAll(s => string.IsNullOrWhiteSpace(s));
                }
                else
                {
                    lstShortcutData.Add(txtData.Text);
                }
                if(!IsUpdate)
                {
                    _objUtils.CreateShortcut(txtName.Text, lstShortcutData);
                    _objUtils.ShowMsg(Strings.SuccesCreateShortcut);
                    this.ActiveControl = txtName;
                }
                else
                {
                    _objUtils.UpdateShortcut(txtName.Text, lstShortcutData);
                    _objUtils.ShowMsg(Strings.SuccesUpdateShortcut);
                    this.Close();
                }
                txtName.Text = string.Empty;
                txtData.Text = string.Empty;
            }
            catch (Exception ex)
            {
                _objUtils.ShowMsg(ex.Message, MessageType.Error);
            }
        }

        /// <summary>
        /// Form load
        /// </summary>
        private void FrmCreate_Load(object sender, EventArgs e)
        {
            if(IsUpdate)
            {
                this.ActiveControl = txtData;
                btnCreate.Text = Strings.Update;
                this.Text = Strings.UpdateShortcut;
                txtName.ReadOnly = true;
                if(Shortcut != null)
                {
                    txtName.Text = Shortcut.Name;
                    StringBuilder sbData = new StringBuilder();
                    if (Shortcut.Data != null)
                    {
                        Shortcut.Data.ForEach(s => { sbData.Append(s); sbData.Append(Environment.NewLine); });
                    }
                    txtData.Text = sbData.ToString();
                }   
            }
            else
            {
                btnCreate.Text = Strings.Create;
                this.Text = Strings.CreateShortcut;
                txtName.ReadOnly = false;
            }
        }

        private void FrmCreate_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.frmMain.FetchData();
        }
    }
}
