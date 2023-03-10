using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenCvSharp;
using OpenCvSharp.Extensions;
using System.Drawing;
using System.Runtime.InteropServices;
using Window = System.Windows.Window;
using RPALite.api;
using System.Windows.Forms;

namespace RPALite.src.ApexFarmer
{
    internal class ApexFarmObject
    {
        /// <summary>
        /// 传入截图，获得图片在屏幕中的位置信息
        /// </summary>
        /// <param name="imgPath">截图的地址</param>
        /// <param name="threshold">相似度，默认为1，建议为0.9</param>
        /// <returns>坐标信息的结构体</returns>
        public Location LocateOnScreen(string imgPath, double threshold = 1)
        {
            // 创建图象，保存将来截取的图象
            Bitmap imgSrc = new Bitmap(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height);
            Graphics imgGraphics = Graphics.FromImage(imgSrc);

            // 设置截屏区域
            imgGraphics.CopyFromScreen(0, 0, 0, 0, new System.Drawing.Size((int)ConvertToNomalCooridate(Screen.PrimaryScreen.Bounds.Width), (int)ConvertToNomalCooridate(Screen.PrimaryScreen.Bounds.Height)));
            
            // 寻找位置的图片
            Bitmap imgSub = new Bitmap(imgPath);
            OpenCvSharp.Mat srcMat = null;
            OpenCvSharp.Mat dstMat = null;
            OpenCvSharp.OutputArray outArray = null;
            try
            {
                srcMat = imgSrc.ToMat();
                dstMat = imgSub.ToMat();
                outArray = OpenCvSharp.OutputArray.Create(srcMat);
                // CV 开始匹配
                OpenCvSharp.Cv2.MatchTemplate(srcMat, dstMat, outArray, TemplateMatchModes.CCoeffNormed);

                double minValue, maxValue;
                OpenCvSharp.Point location, point;
                OpenCvSharp.Cv2.MinMaxLoc(OpenCvSharp.InputArray.Create(outArray.GetMat()), out minValue, out maxValue, out location, out point);
                if (maxValue >= threshold)
                {
                    return new Location(point.X, point.Y);
                }
                return new Location();
            }
            catch
            {
                return new Location();
            }
            finally
            {
                if (imgSrc != null)
                    imgSrc.Dispose();
                if (imgGraphics != null)
                    imgGraphics.Dispose();
                if (imgSub != null)
                    imgSub.Dispose();
                if (srcMat != null)
                    srcMat.Dispose();
                if (dstMat != null)
                    dstMat.Dispose();
                if (outArray != null)
                    outArray.Dispose();
            }
        }

        /// <summary>
        /// 由于win10有缩放功能，所以要转为正常的坐标
        /// </summary>
        /// <param name="pixel">需要转换的值</param>
        /// <returns>转换之后的值</returns>
        private double ConvertToNomalCooridate(double pixel)
        {
            Graphics g = Graphics.FromHwnd(IntPtr.Zero);
            float result = g.DpiX;
            if (result == 0)
            {
                return pixel;
            }
            return pixel * result / 96;
        }

    }
}
