using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace RPALite.API
{
    internal class KeyboardUtils
    {
        const uint WM_KEYDOWN = 0x0100;
        const uint WM_KEYUP = 0x0101;
        const uint WM_LBUTTONDOWN = 0x201;

        [DllImport("user32.dll", CharSet = CharSet.Unicode)]
        private static extern short VkKeyScan(char ch);

        [DllImport("user32.dll")]
        private static extern int PostMessage(IntPtr hwnd, uint msg, int wParam, int lParam);

        public static void PressKey(IntPtr hwnd, char key)
        {
            int keyCode = VkKeyScan(key);
            PostMessage(hwnd, WM_KEYDOWN, keyCode, 0);
            Thread.Sleep(3);
            PostMessage(hwnd, WM_KEYUP, keyCode, 0);
        }
    }
}
