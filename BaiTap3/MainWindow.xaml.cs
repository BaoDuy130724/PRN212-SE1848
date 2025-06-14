using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace BaiTap3
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void BtnHuy_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void BtnGui_Click(object sender, RoutedEventArgs e)
        {
            string binhchon = "";
            if (radRatTot.IsChecked==true)
            {
                binhchon += radRatTot.Content.ToString();
            }
            else if (radTot.IsChecked == true)
            {
                binhchon += radTot.Content.ToString();
            }
            else if (radTamDuoc.IsChecked == true)
            {
                binhchon += radTamDuoc.Content.ToString();
            }
            else if (radKhongTot.IsChecked == true)
            {
                binhchon += radKhongTot.Content.ToString();
            }
            string gioitinh = "";
            if (radNam.IsChecked == true)
            {
                gioitinh += radNam.Content.ToString();
            }
            else if (radNu.IsChecked == true)
            {
                gioitinh += radNu.Content.ToString();
            }

            string info = "Bạn bình chọn Hệ thông: " + binhchon + Environment.NewLine; // Environment.NewLine adds a new line
            info += "Giới tính của bạn:" + gioitinh;

            MessageBoxResult ret = MessageBox.Show(info, "Mời bạn xác nhận", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if( ret == MessageBoxResult.Yes)
            {
                MessageBox.Show("Cảm ơn bạn đã bình chọn", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                MessageBox.Show("Bạn đã hủy bình chọn", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
    }
}