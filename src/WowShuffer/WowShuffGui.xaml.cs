using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Timers;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Runtime.InteropServices;
using System.Windows.Interop;
using RPALite.API;
using RPALite.Src.WowShuffer;

namespace RPALite.src.WowShuffer
{
    public partial class WowShuffGui : Window
    {
        private Timer timer;
        private TextBlock wowfindBlock;
        private TextBlock runtimeBlock;

        private WowShuffObject wowShuffObject;

        private const string notFindText = "❌ 未找到魔兽世界";
        private const string hasFindText = "✔ 正在执行程序中";
        private const string runtimeText = "⏺ 运行时间: ";

        private IntPtr capturedHwnd;
        private IntPtr capturingHwnd;

        private int clickedTime = 0;
        private bool isMouseDown = false;

        public WowShuffGui()
        {
            // 初始化窗口基础属性
            InitializeComponent();
            WindowStyleUtils.SetWindowRound(this);
        }

        public void InitializeShufflingObj()
        {
            hwndBlock.Text = "✅ 句柄:" + capturedHwnd.ToString();

            // 初始化加载成员
            wowShuffObject = new WowShuffObject(capturedHwnd, 0.88);
            wowfindBlock = FindName("wowFindBlock") as TextBlock;
            runtimeBlock = FindName("runTimeBlock") as TextBlock;

            // 初始化timer
            timer = new Timer();
            timer.Interval = 50;
            timer.Elapsed += OnTimedEvent;
            timer.Enabled = true;
        }

        /// <summary>
        /// 更新窗口数据
        /// </summary>
        /// <param name="source"></param>
        /// <param name="e"></param>
        private void OnTimedEvent(object source, ElapsedEventArgs e)
        {
            Dispatcher.Invoke(new Action(delegate
            {
                runTimeBlock.Text = runtimeText + wowShuffObject.GetRunTime();

                if (wowShuffObject.isWowRunning())
                {
                    wowfindBlock.Text = hasFindText;
                }
            }));
        }

        private void Hover_MouseDown(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Cross;
            if (this.isMouseDown)
            {
                return;
            }
            this.isMouseDown = true;
        }

        private void Hover_MouseUp(object sender, MouseEventArgs e)
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
            IntPtr hwnd = Hwnd.GetPointHwnd(point);
            capturedHwnd = hwnd;

            InitializeShufflingObj();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
