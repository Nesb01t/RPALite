using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace RPALite
{
    internal class WindowStyleUtils
    {
        /// <summary>
        /// 令窗口样式为圆角
        /// </summary>
        /// <param name="dependencyObject">窗口 Object</param>
        public static void SetWindowRound(DependencyObject dependencyObject)
        {
            IntPtr hwnd = new System.Windows.Interop.WindowInteropHelper(Window.GetWindow(dependencyObject)).EnsureHandle();
            var attribute = WindowStyleUtils.DWMWINDOWATTRIBUTE.DWMWA_WINDOW_CORNER_PREFERENCE;
            var preference = WindowStyleUtils.DWM_WINDOW_CORNER_PREFERENCE.DWMWCP_ROUND;
            WindowStyleUtils.DwmSetWindowAttribute(hwnd, attribute, ref preference, sizeof(uint));
        }

        private enum DWMWINDOWATTRIBUTE
        {
            DWMWA_WINDOW_CORNER_PREFERENCE = 33
        }

        private enum DWM_WINDOW_CORNER_PREFERENCE
        {
            DWMWCP_DEFAULT = 0,
            DWMWCP_DONOTROUND = 1,
            DWMWCP_ROUND = 2,
            DWMWCP_ROUNDSMALL = 3
        }

        [DllImport("dwmapi.dll", CharSet = CharSet.Unicode, PreserveSig = false)]
        private static extern void DwmSetWindowAttribute(IntPtr hwnd, DWMWINDOWATTRIBUTE attribute, ref DWM_WINDOW_CORNER_PREFERENCE pvAttribute, uint cbAttribute);
    }
}
