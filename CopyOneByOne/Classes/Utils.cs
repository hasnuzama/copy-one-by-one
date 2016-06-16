using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using System.Windows.Forms;

namespace CopyOneByOne
{
    public class Utils
    {
        #region Instance variables and properties

        JavaScriptSerializer _jss = null;
        public string DataFile
        {
            get
            {
                return string.Format(@"{0}\{1}", System.IO.Path.GetDirectoryName(Application.ExecutablePath), Strings.FileName);
            }
        }

        const string passPhrase = "Hasnu@81";        // can be any string
        const string saltValue = "ice#@91548";        // can be any string
        const string hashAlgorithm = "SHA1";             // can be "MD5"
        const int passwordIterations = 2;                // can be any number
        const string initVector = "@1B2c3D4e5F6g7H8"; // must be 16 bytes
        const int keySize = 256;                // can be 192 or 128

        #endregion

        #region Constructor and destructor

        public Utils()
        {
            _jss = new JavaScriptSerializer();
        }

        ~Utils()
        {
            _jss = null;
        }

        #endregion

        #region Private methods

        /// <summary>
        /// Reads all contents of file
        /// </summary>
        private string ReadFile(string strFileName)
        {
            string strData = string.Empty;
            try
            {
                strData = System.IO.File.ReadAllText(@DataFile);
                if(strData != string.Empty)
                    strData = Decrypt(strData);
            }
            catch(System.IO.FileNotFoundException ex)
            {
                // Neglect
            }
            catch (Exception ex)
            {
                throw;
            }
            return strData;
        }

        /// <summary>
        /// Writes data in given file
        /// </summary>
        private void WriteIntoFile(string strData, string strFileName = "")
        {
            try
            {
                if (strFileName == string.Empty)
                    strFileName = DataFile;

                strData = Encrypt(strData);

                System.IO.TextWriter tw = new System.IO.StreamWriter(strFileName);
                tw.Write(strData);
                tw.Close();
                tw.Dispose();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        /// <summary>
        /// Encrypts given message
        /// </summary>
        private string Encrypt(string strMessage)
        {
            return Security.Encrypt
            (
                strMessage,
                Strings.Security_PassPhrase,
                Strings.Security_SaltValue,
                Strings.Security_HashAlgorithm,
                Strings.Security_PasswordIterations,
                Strings.Security_InitVector,
                Strings.Security_KeySize
            );
        }

        /// <summary>
        /// Decrypts given message
        /// </summary>
        private string Decrypt(string strCipherText)
        {
            try
            {
                return Security.Decrypt
                (
                    strCipherText,
                    Strings.Security_PassPhrase,
                    Strings.Security_SaltValue,
                    Strings.Security_HashAlgorithm,
                    Strings.Security_PasswordIterations,
                    Strings.Security_InitVector,
                    Strings.Security_KeySize
                );
            }
            catch(Exception ex)
            {
                throw new DecryptException(ex.Message);
            }
        }

        /// <summary>
        /// Adds shortcut into the file
        /// </summary>
        private void AddShortcutToFile(Shortcut objShortcut)
        {
            try
            {
                #region Validation

                string strValidation = string.Empty;
                if (objShortcut == null || objShortcut.Name == null && objShortcut.Data == null)
                {
                    strValidation += "Null values";
                }
                if (objShortcut.Name == string.Empty)
                {
                    strValidation += ", Empty name";
                }
                if (objShortcut.Data.Count == 0)
                {
                    strValidation += ", No data";
                }
                if (strValidation != string.Empty)
                {
                    // Log this
                    return;
                }

                #endregion

                FileData objFileData = GetFileData();
                if (objFileData != null)
                {
                    if (objFileData.Shortcuts == null)
                        objFileData.Shortcuts = new List<Shortcut>();

                    objFileData.Shortcuts.Add(objShortcut);
                    string strNewData = _jss.Serialize(objFileData);
                    WriteIntoFile(strNewData);
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        #endregion

        #region Public methods

        /// <summary>
        /// Returns File data object
        /// </summary>
        public FileData GetFileData(string strFileName = "")
        {
            FileData objFileData = null;
            try
            {
                strFileName = (strFileName == string.Empty) ? Properties.Settings.Default.DataFile : strFileName;
                string strExistingData = ReadFile(@DataFile);
                objFileData = _jss.Deserialize<FileData>(strExistingData);
            }
            catch (Exception ex)
            {
                throw;
            }
            return objFileData;
        }

        /// <summary>
        /// Creates a shortcut
        /// </summary>
        public void CreateShortcut(string strShortcutName, List<string> lstData)
        {
            Shortcut objShortcut = null;
            try
            {
                #region Validation

                string strValidation = string.Empty;
                if (strShortcutName == null || lstData == null)
                {
                    strValidation += "Null values";
                }
                if (strShortcutName == string.Empty)
                {
                    strValidation += ", Empty name";
                }
                if (lstData.Count == 0)
                {
                    strValidation += "No data";
                }
                if (strValidation != string.Empty)
                {
                    // Log this
                    return;
                }

                #endregion

                objShortcut = new Shortcut(strShortcutName, lstData);
                CreateShortcut(objShortcut);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        /// <summary>
        /// Creates a shortcut
        /// </summary>
        public void CreateShortcut(Shortcut objShortcut)
        {
            try
            {
                #region Validation

                string strValidation = string.Empty;
                if (objShortcut == null || objShortcut.Name == null && objShortcut.Data == null)
                {
                    strValidation += "Null values";
                }
                if (objShortcut.Name == string.Empty)
                {
                    strValidation += ", Empty name";
                }
                if (objShortcut.Data.Count == 0)
                {
                    strValidation += "No data";
                }
                if (strValidation != string.Empty)
                {
                    // Log this
                    return;
                }

                #endregion

                AddShortcutToFile(objShortcut);

            }
            catch (Exception ex)
            {
                throw;
            }
        } 

        /// <summary>
        /// Returns all shortcuts
        /// </summary>
        /// <param name="strFileName"></param>
        /// <returns></returns>
        public List<Shortcut> GetShortcuts(string strFileName = "")
        {
            List<Shortcut> lstShortcuts = null;
            try
            {
                FileData objFileData = GetFileData(strFileName);
                if(objFileData != null)
                {
                    lstShortcuts = objFileData.Shortcuts;
                }  
            }
            catch (Exception ex)
            {
                throw;
            }
            return lstShortcuts;
        }

        /// <summary>
        /// Returns settings object
        /// </summary>
        public Settings GetSettings(string strFileName = "")
        {
            Settings objSettings = null;
            try
            {
                FileData objFileData = GetFileData(strFileName);
                if (objFileData != null)
                {
                    objSettings = objFileData.Settings;
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            return objSettings;
        }

        public Shortcut GetShortcut(string strShortcutName)
        {
            Shortcut objShortcut = null;
            try
            {
                List<Shortcut> lstShortcuts = GetShortcuts();
                if (lstShortcuts != null)
                    objShortcut = lstShortcuts.Where(s => s.Name == strShortcutName).FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw;
            }
            return objShortcut;
        }

        public void DeleteShortcut(string strShortcutName)
        {
            try
            {
                if (strShortcutName != string.Empty)
                {
                    FileData objFileData = GetFileData();
                    if (objFileData != null && objFileData.Shortcuts != null)
                    {
                        objFileData.Shortcuts.RemoveAll(s => s.Name == strShortcutName);
                        string strData = _jss.Serialize(objFileData);
                        WriteIntoFile(strData);
                    }
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public void UpdateShortcut(string strShortcutName, List<string> lstData)
        {
            try
            {
                Shortcut objShortcut = new Shortcut();
                objShortcut.Name = strShortcutName;
                objShortcut.Data = lstData;
                UpdateShortcut(objShortcut);
            }
            catch (Exception ex)
            {
            }
        }

        public void UpdateShortcut(Shortcut objShortcut)
        {
            try
            {
                #region Validation

                string strValidation = string.Empty;
                if (objShortcut == null || objShortcut.Name == null && objShortcut.Data == null)
                {
                    strValidation += "Null values";
                }
                if (objShortcut.Name == string.Empty)
                {
                    strValidation += ", Empty name";
                }
                if (objShortcut.Data.Count == 0)
                {
                    strValidation += ", No data";
                }
                if (strValidation != string.Empty)
                {
                    // Log this
                    return;
                }

                #endregion

                FileData objFileData = GetFileData();
                if (objFileData != null && objFileData.Shortcuts != null)
                {
                    int intIndex = objFileData.Shortcuts.FindIndex(s => s.Name == objShortcut.Name);
                    if (intIndex != -1)
                    {
                        objFileData.Shortcuts[intIndex].Data = objShortcut.Data;
                    }
                    string strData = _jss.Serialize(objFileData);
                    WriteIntoFile(strData);
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public void UpdateSettings(Settings objSettings,string strFileName = "")
        {
            try
            {
                if(objSettings != null)
                {
                    FileData objFileData = GetFileData(strFileName);
                    if (objFileData == null)
                        objFileData = new FileData();

                    objFileData.Settings = objSettings;
                    string strData = _jss.Serialize(objFileData);
                    WriteIntoFile(strData);
                }
            }
            catch(Exception ex)
            {
                throw;
            }
        }

        /// <summary>
        /// Displays message
        /// </summary>
        public void ShowMsg(string strMessage, MessageType msgType = MessageType.Info)
        {
            switch (msgType)
            {
                case MessageType.Info:
                    MessageBox.Show(strMessage, msgType.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                    break;
                case MessageType.Warning:
                    MessageBox.Show(strMessage, msgType.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    break;
                case MessageType.Error:
                    MessageBox.Show(strMessage, msgType.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
            }
        }

        #endregion
    }
}
