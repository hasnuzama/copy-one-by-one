using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CopyOneByOne
{
    public static class Strings
    {
        // Default
        public static string FileName = "Snippets.dat";
        public static string ErrDefault = "Something went wrong. Please write us an email.";

        // Tooltips
        public static string TltpCreate = "Create snippet";
        public static string TltpEdit = "Edit snippet";
        public static string TltpDel = "Delete snippet";
        public static string TltpChangePwd = "Change password";

        /// <summary>
        /// Main program
        /// </summary>
        public static string ErrFileCorrupted = "Backup file corrupted. Please restore/delete it.";

        /// <summary>
        /// Hook class
        /// </summary>
        public static string ErrMultipleHooks = "Can't hook more than once.";


        /// <summary>
        /// Used in utils
        /// </summary>
        public static string Security_PassPhrase = "Hasnu@81";        // can be any string
        public static string Security_SaltValue = "ice#@91548";        // can be any string
        public static string Security_HashAlgorithm = "SHA1";             // can be "MD5"
        public static int Security_PasswordIterations = 2;                // can be any number
        public static string Security_InitVector = "@1B2c3D4e5F6g7H8"; // must be 16 bytes
        public static int Security_KeySize = 256;                // can be 192 or 128

        /// <summary>
        /// Login form
        /// </summary>
        public static string ErrEmptyPassword = "Please enter password.";
        public static string ErrEmptyDetails = "Please enter details.";
        public static string ErrInvalidPassword = "Invalid password. Please try again.";
        public static string SuccesPasswordUpdate = "Password updated successfully.";
        public static string ErrUnequalPasswords = "Passwords are not matched.";

        /// <summary>
        /// Main form
        /// </summary>
        public static string ErrSelectShortcut = "Please select a snippet.";
        public static string SuccesDeleteShortcut = "Snippet deleted successfully.";
        public static string SuccesReload = "Refreshed successfully.";

        /// <summary>
        /// Create form
        /// </summary>
        public static string SuccesCreateShortcut = "Snippet created successfully.";
        public static string SuccesUpdateShortcut = "Snippet updated successfully.";
        public static string Create = "Create";
        public static string CreateShortcut = "Create Snippet";
        public static string Update = "Update";
        public static string UpdateShortcut = "Update Snippet";
        public static string ErrEmptySnippetName = "Please enter snippet name.";
        public static string ErrEmptySnippetData = "Please enter snippet data.";

    }
}
