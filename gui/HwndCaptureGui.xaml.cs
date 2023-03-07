using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Forms;
using MouseEventArgs = System.Windows.Input.MouseEventArgs;
using Cursors = System.Windows.Input.Cursors;
using RPALite.API;

namespace RPALite.gui
{
    /// <summary>
    /// HwndCaptureGui.xaml 的交互逻辑
    /// </summary>
    public partial class HwndCaptureGui : Window
    {     
        private IntPtr capturedHwnd;
        private IntPtr capturingHwnd;

        private int clickedTime = 0;
        private bool isMouseDown = false;

        public HwndCaptureGui()
        {
            // 初始化组件渲染
            InitializeComponent();

            // 初始化加载成员
            hwndBlock = FindName("hwndBlock") as TextBlock;
        }

        private void Button_MouseDown(object sender, MouseEventArgs e) 
        {
            this.Cursor = Cursors.Cross;
            if (this.isMouseDown)
            {
                return;
            }
            this.isMouseDown = true;
        }

        private void Button_MouseMove(object sender, MouseEventArgs e)
        {
            // TODO: 如果过程中需要标红，可以在这里写入
        }

        private void Button_MouseUp(object sender, MouseEventArgs e)
        {
            hwndBlock.Text = "Up" + clickedTime++;
            this.Cursor = Cursors.Arrow;
            if (!this.isMouseDown)
            {
                return;
            }
            // 获取鼠标绝对位置
            Point point = e.GetPosition(null);
            point = this.PointToScreen(point);

            // 获取指针位置 Hwnd
            IntPtr hwnd = Hwnd.GetPointHwnd(point);
            hwndBlock.Text = point.ToString() + ": " + hwnd;
        }
    }
}
