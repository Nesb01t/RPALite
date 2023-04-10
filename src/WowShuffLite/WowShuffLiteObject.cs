using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using RPALite.API;
using System.Data;

namespace RPALite.Src.WowShuffLite
{
    internal class WowShuffLiteObject
    {
        private Thread thread;
        private IntPtr wowHwnd;
        private IntPtr activatingHwnd;
        private DateTime startTime;
        private DateTime periodTime;
        private double produceCastTime;
        private double runTimeSeconds;
        private const double disenchantCastTime = 1.5;
        private const double intervalTime = 0.15;

        /// <summary>
        /// Shuffling 线程入口函数
        /// </summary>
        private void ThreadCall()
        {
            while (true)
            {
                CalcRunTime(); // 中断功能函数
                if (!isWowInBackground())
                {
                    runShuffling(); // 主操作函数
                }
            }
        }

        /// <summary>
        /// WOWShuffling 类
        /// </summary>
        public WowShuffLiteObject(IntPtr hwnd, double produceCastTime)
        {
            // 初始化成员
            startTime = DateTime.Now.ToLocalTime();
            periodTime = DateTime.MinValue;
            // wowHwnd = Hwnd.GetWindowHwnd("魔兽世界");
            wowHwnd = hwnd;
            this.produceCastTime = produceCastTime;

            // 初始化线程
            ThreadStart childref = new ThreadStart(ThreadCall);
            thread = new Thread(childref);
            thread.IsBackground = true;
            thread.Start();
        }

        // 执行操作函数
        private void runShuffling()
        {
            KeyboardUtils.PressKey(wowHwnd, '-');
            Thread.Sleep((int)(produceCastTime * 1000 + intervalTime * 1000));
        }

        // 计算过去时间
        private void CalcRunTime()
        {
            // 计算当前运行的时间 endTime - startTime
            TimeSpan elapsed = DateTime.Now.ToLocalTime() - startTime;
            runTimeSeconds = elapsed.TotalSeconds;

            // 记录上一次重启的周期时间
            TimeSpan periodElapsed = DateTime.Now.ToLocalTime() - periodTime;
            double seconds = periodElapsed.TotalSeconds;
            if (seconds > 1800)
            {
                periodTime = DateTime.Now.ToLocalTime();
                KeyboardUtils.PressKey(wowHwnd, ' ');
                Thread.Sleep((int)(100)); // 按下重启&喝药
                KeyboardUtils.PressKey(wowHwnd, '9');

                Thread.Sleep((int)(20000)); // 20秒后重新打开专业界面
                KeyboardUtils.PressKey(wowHwnd, '5');
                Thread.Sleep((int)(100));
                KeyboardUtils.PressKey(wowHwnd, '5');
                Thread.Sleep((int)(3000)); // 等待插件放置
            }
        }

        // 判断游戏是否在后台
        private bool isWowInBackground()
        {
            activatingHwnd = Hwnd.GetActivatingHwnd();
            return wowHwnd == activatingHwnd;
        }

        // 判断是否找到游戏
        public bool isWowRunning()
        {
            int hwndNum = (int)wowHwnd;
            return hwndNum != 0;
        }

        // 获取运行时间戳
        public string GetRunTime()
        {
            int hour = (int)(runTimeSeconds / 3600);
            int min = (int)((runTimeSeconds / 60) % 60);
            int second = (int)(runTimeSeconds % 60);
            string timeStamp = "";
            if (hour > 0)
            {
                timeStamp += hour.ToString() + "小时";
                timeStamp += min.ToString() + "分钟";
            }
            else if (min > 0)
            {
                timeStamp += min.ToString() + "分钟";
                timeStamp += second.ToString() + "秒";
            }
            else if (second > 0)
            {
                timeStamp += second.ToString() + "秒";
            }
            else
            {
                timeStamp = "无";
            }
            return timeStamp;
        }
    }
}
