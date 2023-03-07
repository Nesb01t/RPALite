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
using RPALite.Src;

namespace RPALite.gui
{
    public partial class WowShufflingGui : Window
    {
        private Timer timer;
        private TextBlock wowfindBlock;
        private TextBlock runtimeBlock;

        private WowShuffling wowshuffling;

        private const string notFindText = "❌ 未找到魔兽世界";
        private const string hasFindText = "✔ 正在执行程序中";
        private const string runtimeText = "⏺ 运行时间: ";

        public WowShufflingGui()
        {
            // 初始化窗口基础属性
            InitializeComponent();
            WindowStyleUtils.SetWindowRound(this);

            // 初始化加载成员
            wowshuffling = new WowShuffling(0.88);
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
                runTimeBlock.Text = runtimeText + wowshuffling.GetRunTime();

                if (wowshuffling.isWowRunning())
                {
                    wowfindBlock.Text = hasFindText;
                }
            }));
        }
    }
}
