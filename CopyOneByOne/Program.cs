using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CopyOneByOne
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Utils objUtils = new Utils();
            try
            {             
                Settings objSettings = objUtils.GetSettings();
                if (objSettings != null)
                {
                    // Login
                    Application.EnableVisualStyles();
                    Application.SetCompatibleTextRenderingDefault(false);
                    Application.Run(new FrmLogin(objSettings.Password));
                }
                else
                {
                    // Register
                    Application.EnableVisualStyles();
                    Application.SetCompatibleTextRenderingDefault(false);
                    Application.Run(new FrmPassword(false));
                }
            }
            catch(DecryptException ex)
            {
                objUtils.ShowMsg(Strings.ErrFileCorrupted, MessageType.Error);
            }
            catch(Exception ex)
            {
                objUtils.ShowMsg(ex.Message, MessageType.Error);
            }    
        }
    }
}
