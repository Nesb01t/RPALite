using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using RPALite.api;

namespace RPALite.src.ApexFarmer
{
    public partial class ApexFarmGui : Window
    {

        private ApexFarmObject apexFarmObject;

        public ApexFarmGui()
        {
            // 初始化组件
            InitializeComponent();

            // 初始化ApexFarm对象
            apexFarmObject = new ApexFarmObject();
            Location location = apexFarmObject.LocateOnScreen("C:/Users/Administrator/Desktop/A.png", 0.1);

            Console.WriteLine(location.X + " : " + location.Y);
        }

    }
}
