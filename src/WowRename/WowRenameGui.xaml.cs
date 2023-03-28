using System;
using System.Collections.Generic;
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

namespace RPALite.src.WowRename
{
    /// <summary>
    /// Window1.xaml 的交互逻辑
    /// </summary>
    public partial class WowRenameGui : Window
    {
        public WowRenameGui()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            IntPtr hwnd = API.Hwnd.GetWindowHwnd("魔兽世界");
            API.Hwnd.SetWindowName(hwnd, "World of Warcraft");
        }
    }
}
