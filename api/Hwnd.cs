using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using RPALite.include;
using System.Windows;
using Window = RPALite.include.Window;

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

        /// <summary>
        /// 设置窗口标题
        /// </summary>
        /// <param name="hwnd">窗口句柄</param>
        /// <param name="name">新的标题</param>
        /// <returns>是否设置成功</returns>
        public static bool SetWindowName(IntPtr hwnd, string name)
        {
            Window.SetWindowText(hwnd, name);
            return true;
        }

        /// <summary>
        /// 获取当前窗口句柄 Hwnd
        /// </summary>
        /// <returns></returns>
        public static IntPtr GetActivatingHwnd()
        {
            IntPtr hwnd = Window.GetForegroundWindow();
            return hwnd;
        }

        public static IntPtr GetPointHwnd(Point point)
        {
            IntPtr hwnd = Window.WindowFromPoint((int)point.X, (int)point.Y);
            return hwnd;
        }
    }
}
