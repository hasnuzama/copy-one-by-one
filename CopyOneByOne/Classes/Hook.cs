using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.ComponentModel;

namespace CopyOneByOne
{
    /// <summary>
    /// A class that manages a global low level keyboard hook
    /// </summary>
    public class Hook
    {
        public event KeyEventHandler KeyDown;
        public event KeyEventHandler KeyUp;
        public List<Keys> HookedKeys = null;

        const int WH_KEYBOARD_LL = 13;
        const int WM_KEYDOWN = 0x100;
        const int WM_KEYUP = 0x101;
        const int WM_SYSKEYDOWN = 0x104;
        const int WM_SYSKEYUP = 0x105;

        private delegate IntPtr LowLevelKeyboardProc(int nCode, IntPtr wParam, IntPtr lParam);
        private IntPtr hhook = IntPtr.Zero;
        private static LowLevelKeyboardProc callBackProc;

        #region Constructor and destructor
        public Hook()
        {
            Init();
        }

        public Hook(bool blnSetHook)
        {
            if(blnSetHook)
                this.SetHook();
            Init();
        }

        private void Init()
        {
            HookedKeys = new List<Keys>();
        }

        ~Hook()
        {
            this.UnHook();
        }
        #endregion

        #region Importing dll's

        [DllImport("user32.dll")]
        static extern IntPtr SetWindowsHookEx(int idHook, LowLevelKeyboardProc callback, IntPtr hInstance, uint threadId);

        [DllImport("user32.dll")]
        static extern bool UnhookWindowsHookEx(IntPtr hInstance);

        [DllImport("user32.dll")]
        static extern IntPtr CallNextHookEx(IntPtr idHook, int nCode, int wParam, IntPtr lParam);

        [DllImport("kernel32.dll")]
        static extern IntPtr LoadLibrary(string lpFileName);

        #endregion

        #region All methods

        /// <summary>
        /// Sets Hook
        /// </summary>
        public void SetHook()
        {
            if(callBackProc != null)
                throw new InvalidOperationException(Strings.ErrMultipleHooks);

            IntPtr hInstance = LoadLibrary("User32");
            callBackProc = new LowLevelKeyboardProc(hookProc);
            hhook = SetWindowsHookEx(WH_KEYBOARD_LL, callBackProc, hInstance, 0);
            if (hhook == IntPtr.Zero) throw new Win32Exception();
        }

        /// <summary>
        /// Removes hook
        /// </summary>
        public void UnHook()
        {
            if (callBackProc == null) 
                return;
            bool blnStatus = UnhookWindowsHookEx(hhook);
            callBackProc = null;
        }

        /// <summary>
        /// Processing hook
        /// </summary>
        /// <param name="code"></param>
        /// <param name="wParam"></param>
        /// <param name="lParam"></param>
        /// <returns></returns>
        private IntPtr hookProc(int code, IntPtr wParam, IntPtr lParam)
        {
            if (code >= 0)
            {
                int vkCode = Marshal.ReadInt32(lParam);
                Keys key = (Keys)vkCode;
                if(this.HookedKeys.Contains(key))
                {
                    KeyEventArgs kea = new KeyEventArgs(key);
                    if (((int)wParam == WM_KEYDOWN || (int)wParam == WM_SYSKEYDOWN) && (KeyDown != null))
                    {
                        KeyDown(this, kea);
                    }
                    else if (((int)wParam == WM_KEYUP ||(int)wParam == WM_SYSKEYUP) && (KeyUp != null))
                    {
                        KeyUp(this, kea);
                    }
                }
            }
            return CallNextHookEx(hhook, code, (int)wParam, lParam);
        }

        #endregion
    }
}
