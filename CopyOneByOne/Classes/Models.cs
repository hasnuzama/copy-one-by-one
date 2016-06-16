using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CopyOneByOne
{
    /// <summary>
    /// Shortcuts data
    /// </summary>
    public class Shortcut
    {
        public string Name { get; set; }
        public List<string> Data { get; set; }
        public DateTime CreatedOn { get; set; }

        public Shortcut()
        {
        }
        public Shortcut(string strName, List<string> lstData)
        {
            this.Name = strName;
            this.Data = lstData;
            this.CreatedOn = DateTime.Now;
        }
    }

    /// <summary>
    /// User preferences
    /// </summary>
    public class Settings
    {
        public string Password { get; set; }
        public int? SortBy { get; set; }

        public bool RecentlyCopied { get; set; }
        public bool ViewShortcut { get; set; }
        public bool Repeat { get; set; }
        public bool? AutoMinimize { get; set; }
    }

    /// <summary>
    /// Data saved in file
    /// </summary>
    public class FileData
    {
        public Settings Settings { get; set; }
        public List<Shortcut> Shortcuts { get; set; }
    }

    /// <summary>
    /// Decrypt exception
    /// </summary>
    public class DecryptException : Exception
    {
        public string Message { get; set; }
        public DecryptException(string strMessage)
        {
            this.Message = strMessage;
        }
    }
}
