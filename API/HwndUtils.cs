using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Runtime.InteropServices;

namespace RPALite.API
{
    internal class HwndUtils
    {
        [DllImport("user32.dll")]
        private extern static IntPtr FindWindow(string lpClassName, string lpWindowName);

        [DllImport("user32.dll")]
        private extern static IntPtr GetForegroundWindow();


        /// <summary>
        /// 获取窗口 Hwnd
        /// </summary>
        /// <param name="name">窗口标题</param>
        /// <returns>窗口句柄 Hwnd</returns>
        public static IntPtr GetWindowHwnd(string name)
        {
            IntPtr hwnd = FindWindow(null, name);
            return hwnd;
        }

        public static IntPtr GetActivatingHwnd()
        {
            IntPtr hwnd = GetForegroundWindow();
            return hwnd;
        }
    }
}
