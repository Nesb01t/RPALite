﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace RPALite.include
{
    internal class Window
    {
        [DllImport("user32.dll")]
        public extern static IntPtr FindWindow(string lpClassName, string lpWindowName);

        [DllImport("user32.dll")]
        public extern static IntPtr GetForegroundWindow();

        [DllImport("user32.dll")]
        public extern static IntPtr WindowFromPoint(int xPoint, int yPoint);

        [DllImport("user32.dll")]
        public extern static bool SetWindowText(IntPtr hwnd, string lpString);
    }
}