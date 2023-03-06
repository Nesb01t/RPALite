using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using RPALite.include;

namespace RPALite.API
{
    internal class Hwnd
    {
        /// <summary>
        /// 获取窗口 Hwnd
        /// </summary>
        /// <param name="name">窗口标题</param>
        /// <returns>窗口句柄 Hwnd</returns>
        public static IntPtr GetWindowHwnd(string name)
        {
            IntPtr hwnd = Window.FindWindow(null, name);
            return hwnd;
        }

        public static IntPtr GetActivatingHwnd()
        {
            IntPtr hwnd = Window.GetForegroundWindow();
            return hwnd;
        }
    }
}
