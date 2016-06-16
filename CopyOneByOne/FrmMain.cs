using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Web.Script.Serialization;
using System.Diagnostics;

namespace CopyOneByOne
{
    public partial class FrmMain : Form
    {
        // Global variables
        List<string> _buffer = null;
        List<int> _lstDownKeys = null;
        JavaScriptSerializer _jss = null;
        Utils _objUtils = null;
        Shortcut _objShortcutSelected = null;
        Hook _objHook = null;
        int _intCurIndex = 0;
        bool _blnRepeat = false;
        List<Shortcut> _lstShortcuts = null;
        Settings _objSettings = null;
        List<string> _lstRecentlyAdded = null;
        String _strClipboardText = null;

        // Constructor
        public FrmMain()
        {
            try
            {
                InitializeComponent();
            }
            catch (Exception ex)
            {
                _objUtils.ShowMsg(ex.Message, MessageType.Error);
            }
        }

        // Form load
        private void FrmMain_Load(object sender, EventArgs e)
        {
            try
            {
                Init();
                RemoveBorders();
                LoadSettings();
            }
            catch (Exception ex)
            {
                _objUtils.ShowMsg(ex.Message);
            }
        }

        // All initializations
        private void Init()
        {
            try
            {
                if (_objHook == null)
                {
                    _objHook = new Hook(true);
                    _objHook.HookedKeys.Add(Keys.V);
                    _objHook.HookedKeys.Add(Keys.C);
                    _objHook.HookedKeys.Add(Keys.X);
                    _objHook.HookedKeys.Add(Keys.LControlKey);
                    _objHook.HookedKeys.Add(Keys.RControlKey);
                    _objHook.KeyUp += new KeyEventHandler(KeyUp);
                    _objHook.KeyDown += new KeyEventHandler(KeyDown);
                }

                _buffer = new List<string>();

                _lstDownKeys = new List<int>();

                _jss = new JavaScriptSerializer();

                _objUtils = new Utils();

                _lstRecentlyAdded = new List<string>();

                FetchData();

                this.Opacity = 0.95;

                tltpMsg.SetToolTip(btnCreate, Strings.TltpCreate);
                tltpMsg.SetToolTip(btnUpdate, Strings.TltpEdit);
                tltpMsg.SetToolTip(btnDelete, Strings.TltpDel);
                tltpMsg.SetToolTip(btnSettings, Strings.TltpChangePwd);
            }
            catch (Exception ex)
            {
                _objUtils.ShowMsg(ex.Message, MessageType.Error);
            }
        }

        private void ScrollBar_Displayed()
        {

        }

        /// <summary>
        /// Removes borders for all buttons
        /// </summary>
        private void RemoveBorders()
        {
            try
            {
                btnCreate.FlatAppearance.BorderSize = 0;
                btnUpdate.FlatAppearance.BorderSize = 0;
                btnDelete.FlatAppearance.BorderSize = 0;
                btnReload.FlatAppearance.BorderSize = 0;
                btnSettings.FlatAppearance.BorderSize = 0;
            }
            catch (Exception ex)
            {
                _objUtils.ShowMsg(ex.Message, MessageType.Error);
            }

        }

        /// <summary>
        /// Loads saved settings
        /// </summary>
        private void LoadSettings()
        {
            if (_objSettings != null)
            {
                chkRepeat.Checked = _objSettings.Repeat;
                cbxSortBy.SelectedIndex = _objSettings.SortBy ?? 0;
                chkAutoMinimize.Checked = _objSettings.AutoMinimize ?? false;
                ShowWidgets(_objSettings.RecentlyCopied, _objSettings.ViewShortcut);
            }
        }

        /// <summary>
        /// Shows widgets
        /// </summary>
        private void ShowWidgets(bool? blnRecentlyCopied = null, bool? blnViewShortcut = null)
        {
            if (blnRecentlyCopied == null && blnViewShortcut == null)
            {
                blnRecentlyCopied = lbWidgets.GetItemChecked(0);
                blnViewShortcut = lbWidgets.GetItemChecked(1);
            }
            else
            {
                lbWidgets.SetItemChecked(0, (bool)blnRecentlyCopied);
                lbWidgets.SetItemChecked(1, (bool)blnViewShortcut);
            }

            int intShortcutsWidth = Sizes.ShortcutsWidth - Sizes.RecentCopyWidth;
            int intWidgetHeight = (int)Sizes.ShortcutsHeight;
            if ((bool)blnRecentlyCopied && (bool)blnViewShortcut)
            {
                lvRecentlyCopied.Visible = true;
                lvViewShortcut.Visible = true;
                intWidgetHeight = (int)Sizes.RecentCopyHeight;
                lvViewShortcut.Location = new Point((int)Sizes.ViewShortcutLocationX, (int)Sizes.ViewShortcutLocationY);
            }
            else if ((bool)blnRecentlyCopied)
            {
                lvRecentlyCopied.Visible = true;
                lvViewShortcut.Visible = false;

            }
            else if ((bool)blnViewShortcut)
            {
                lvRecentlyCopied.Visible = false;
                lvViewShortcut.Visible = true;
                lvViewShortcut.Location = new Point((int)Sizes.RecentCopyLocationX, (int)Sizes.ReccentCopyLocationY);
            }
            else
            {
                lvRecentlyCopied.Visible = false;
                lvViewShortcut.Visible = false;
                intShortcutsWidth = (int)Sizes.ShortcutsWidth + 7;
            }
            lvShortcuts.Width = intShortcutsWidth;
            lvRecentlyCopied.Height = intWidgetHeight;
            lvViewShortcut.Height = intWidgetHeight;

            int intTiles = lvRecentlyCopied.Height / lvRecentlyCopied.TileSize.Height - 1;
            for (int i = _lstRecentlyAdded.Count; i > intTiles; i--)
                _lstRecentlyAdded.RemoveAt(i - 1);

            UpdateRecentlyCopied();
        }

        /// <summary>
        /// Updating list view
        /// </summary>
        private void UpdateListView()
        {
            try
            {
                if (_lstShortcuts == null)
                    return;

                int intSelectedIndex = cbxSortBy.SelectedIndex;

                if (intSelectedIndex == 0)
                    _lstShortcuts = _lstShortcuts.OrderBy(s => s.Name).ToList();
                else if (intSelectedIndex == 1)
                    _lstShortcuts = _lstShortcuts.OrderBy(s => s.CreatedOn).ToList();

                lvShortcuts.Clear();
                for (int i = 0; i < _lstShortcuts.Count; i++)
                {
                    lvShortcuts.Items.Add(new ListViewItem { Text = _lstShortcuts[i].Name });
                }
            }
            catch (Exception ex)
            {
                _objUtils.ShowMsg(ex.Message, MessageType.Error);
            }
        }

        private void FrmMain_Load(object sender, System.ComponentModel.CancelEventArgs e)
        {
        }


        /// <summary>
        /// Keyup event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        new void KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                _lstDownKeys.RemoveAll(k => k == e.KeyValue);
                if (_lstDownKeys.Exists(k => k == (int)KeyValue.LCtrl) || _lstDownKeys.Exists(k => k == (int)KeyValue.RCtrl))
                {
                    if (e.KeyValue == (int)KeyValue.C)
                    {
                        // We need to add item to the recently copied list
                        // ClearBuffer();
                        AddItemToRecentlyCopied(Clipboard.GetText());
                    }
                }
            }
            catch (Exception ex)
            {
                _objUtils.ShowMsg(ex.Message, MessageType.Error);
            }
            e.Handled = false;
        }

        /// <summary>
        /// Keydown event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        new void KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                _lstDownKeys.Add(e.KeyValue);
                if (_lstDownKeys.Exists(k => k == (int)KeyValue.LCtrl) || _lstDownKeys.Exists(k => k == (int)KeyValue.RCtrl))
                {
                    if (e.KeyValue == (int)KeyValue.V && _buffer.Count > 0)
                    {
                        _strClipboardText = Clipboard.GetText();
                        if(!string.IsNullOrWhiteSpace(_strClipboardText) && !_buffer.Exists( s=> s == _strClipboardText))
                        {
                            ClearBuffer();
                            _intCurIndex = 0;
                            _objShortcutSelected = null;
                        }
                        else if (_intCurIndex >= _buffer.Count)
                        {
                            if (!_blnRepeat)
                            {
                                Clipboard.Clear();
                                ClearBuffer();
                            }
                            else
                            {
                                _intCurIndex = 0;
                                Clipboard.SetText(_buffer[_intCurIndex++]);
                            }
                        }
                        else
                        {
                            if (!string.IsNullOrWhiteSpace(_buffer[_intCurIndex]))
                            {
                                Clipboard.SetText(_buffer[_intCurIndex]);
                            }
                            else
                            {
                                Clipboard.Clear();
                            }
                            ++_intCurIndex;
                        }
                    }
                    else if(e.KeyValue == (int)KeyValue.X || e.KeyValue == (int)KeyValue.C)
                    {
                        ClearBuffer();
                    }
                }
                e.Handled = false;
            }
            catch (Exception ex)
            {
                _objUtils.ShowMsg(ex.Message, MessageType.Error);
            }
        }

        /// <summary>
        /// On update click
        /// </summary>
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                UpdateSelectedShortcut();
                if (_objShortcutSelected != null)
                {
                    Form frmCreate = new FrmCreate(this);
                    FrmCreate.IsUpdate = true;
                    FrmCreate.Shortcut = _objShortcutSelected;
                    frmCreate.Show();
                }
                else
                {
                    _objUtils.ShowMsg(Strings.ErrSelectShortcut, MessageType.Warning);
                }
            }
            catch (Exception ex)
            {
                _objUtils.ShowMsg(ex.Message, MessageType.Error);
            }
        }

        /// <summary>
        /// On delete click
        /// </summary>
        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                UpdateSelectedShortcut();
                if (_objShortcutSelected != null)
                {
                    _objUtils.DeleteShortcut(_objShortcutSelected.Name);
                    _objUtils.ShowMsg(Strings.SuccesDeleteShortcut);
                    FetchData(); 
                }
                else
                {
                    _objUtils.ShowMsg(Strings.ErrSelectShortcut, MessageType.Warning);
                }
            }
            catch (Exception ex)
            {
                _objUtils.ShowMsg(ex.Message, MessageType.Error);
            }
        }

        /// <summary>
        /// On create click
        /// </summary>
        private void btnCreate_Click(object sender, EventArgs e)
        {
            try
            {
                Form frmCreate = new FrmCreate(this);
                FrmCreate.IsUpdate = false;
                frmCreate.Show();
            }
            catch (Exception ex)
            {
                _objUtils.ShowMsg(ex.Message, MessageType.Error);
            }
        }

        /// <summary>
        /// Updates currently selected shortcut in global object
        /// </summary>
        private void UpdateSelectedShortcut()
        {
            try
            {
                var lstSelectedItems = lvShortcuts.SelectedItems;
                if (lstSelectedItems != null && lstSelectedItems.Count > 0)
                {
                    string strShortcutName = lstSelectedItems[0].Text;
                    _objShortcutSelected = _lstShortcuts.Where(s => s.Name == strShortcutName).FirstOrDefault();
                }
                else
                {
                    _objShortcutSelected = null;
                }
            }
            catch (Exception ex)
            {
                _objUtils.ShowMsg(ex.Message, MessageType.Error);
            }
        }

        /// <summary>
        /// On reload click
        /// </summary>
        private void btnReload_Click(object sender, EventArgs e)
        {
            FetchData();
            _objUtils.ShowMsg(Strings.SuccesReload, MessageType.Info);
        }

        /// <summary>
        /// On Settings click
        /// </summary>
        private void btnSettings_Click(object sender, EventArgs e)
        {
            Form frmPassword = new FrmPassword(true);
            frmPassword.Show();
        }

        /// <summary>
        /// While closing form
        /// </summary>
        private void FrmMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            SaveSettings();
            Application.Exit();
        }

        /// <summary>
        /// Saving current settings
        /// </summary>
        private void SaveSettings()
        {
            try
            {
                _objSettings = _objUtils.GetSettings();

                if (_objSettings != null)
                {
                    _objSettings.Repeat = chkRepeat.Checked;
                    _objSettings.RecentlyCopied = lbWidgets.GetItemChecked(0);
                    _objSettings.ViewShortcut = lbWidgets.GetItemChecked(1);
                    _objSettings.SortBy = cbxSortBy.SelectedIndex;
                    _objSettings.AutoMinimize = chkAutoMinimize.Checked;
                    _objUtils.UpdateSettings(_objSettings);
                } 
            }
            catch (Exception ex)
            {
                _objUtils.ShowMsg(ex.Message, MessageType.Error);
            }
        }

        /// <summary>
        /// Sorting based on selected option
        /// </summary>
        private void cbxSortBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateListView();
        }

        /// <summary>
        /// Updating repeat variable
        /// </summary>
        private void chkRepeat_CheckedChanged(object sender, EventArgs e)
        {
            _blnRepeat = chkRepeat.Checked;
        }

        /// <summary>
        /// On click of shortcut
        /// </summary>
        private void lvShortcuts_ItemActivate(object sender, EventArgs e)
        {
            Minimize();
            ProcessItemSelection();
            Clipboard.Clear();
        }

        private void Minimize()
        {
            if (chkAutoMinimize.Checked)
            {
                this.WindowState = FormWindowState.Minimized;
            }
        }

        /// <summary>
        /// On selected index changed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lvShortcuts_SelectedIndexChanged(object sender, EventArgs e)
        {
        }


        /// <summary>
        /// Updates shortcut and copies the first value into the clipboard
        /// </summary>
        private void ProcessItemSelection()
        {
            try
            {
                UpdateSelectedShortcut();
                if (_objShortcutSelected != null)
                {
                    _buffer = _objShortcutSelected.Data;
                    if (lvViewShortcut.Visible)
                    {
                        lvViewShortcut.Clear();
                        _buffer.ForEach(s => { lvViewShortcut.Items.Add(s); });
                    }
                    //if (_buffer.Count > 0 && Clipboard.GetText() != _buffer.First())
                    //{
                        _intCurIndex = 0;
                    //}
                }
            }
            catch (Exception ex)
            {
                _objUtils.ShowMsg(ex.Message, MessageType.Error);
            }
        }

        /// <summary>
        /// Retriving all data and storing in global objects
        /// </summary>
        public void FetchData()
        {
            try
            {
                FileData objFileData = _objUtils.GetFileData();
                if (objFileData != null)
                {
                    _lstShortcuts = objFileData.Shortcuts;
                    _objSettings = objFileData.Settings;
                    UpdateListView();
                }

            }
            catch (Exception ex)
            {
                _objUtils.ShowMsg(ex.Message, MessageType.Error);
            }
        }

        /// <summary>
        /// On widgets change
        /// </summary>
        private void lbWidgets_SelectedIndexChanged(object sender, EventArgs e)
        {
            ShowWidgets();
        }

        /// <summary>
        /// On click of recently copied item
        /// </summary>
        private void lvRecentlyCopied_ItemActivate(object sender, EventArgs e)
        {
            Minimize();
            if (lvRecentlyCopied.SelectedItems.Count > 0 && !string.IsNullOrWhiteSpace(lvRecentlyCopied.SelectedItems[0].Text))
            {
                Clipboard.SetText(lvRecentlyCopied.SelectedItems[0].Text);
                ClearBuffer();
            }
        }

        /// <summary>
        /// Clearing global buffer
        /// </summary>
        private void ClearBuffer()
        {
            if (_buffer == null || _buffer.Count > 0)
                _buffer = new List<string>();
        }

        /// <summary>
        /// On click of view shortcut item
        /// </summary>
        private void lvViewShortcut_ItemActivate(object sender, EventArgs e)
        {
            Minimize();
            if (lvViewShortcut.SelectedItems.Count > 0 && !string.IsNullOrWhiteSpace(lvViewShortcut.SelectedItems[0].Text))
            {
                Clipboard.SetText(lvViewShortcut.SelectedItems[0].Text);
                _buffer = new List<string>();
            }
        }

        /// <summary>
        /// Adds given item to the global list
        /// </summary>
        private void AddItemToRecentlyCopied(string strItem)
        {
            if (lvRecentlyCopied.Visible && !string.IsNullOrWhiteSpace(strItem))
            {
                int intTiles = lvRecentlyCopied.Height / lvRecentlyCopied.TileSize.Height - 1;
                if (_lstRecentlyAdded.Count >= intTiles)
                {
                    _lstRecentlyAdded.RemoveAt(_lstRecentlyAdded.Count - 1);
                }
                _lstRecentlyAdded.Insert(0, strItem);
                UpdateRecentlyCopied();
            }
        }


        /// <summary>
        /// Updating recently added list view
        /// </summary>
        private void UpdateRecentlyCopied()
        {
            if (_lstRecentlyAdded == null)
                return;

            lvRecentlyCopied.Clear();
            for (int i = 0; i < _lstRecentlyAdded.Count; i++)
                lvRecentlyCopied.Items.Add(_lstRecentlyAdded[i]);
        }
    }
}
