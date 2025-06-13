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

namespace HelloWPFApp
{
    /// <summary>
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        public LoginWindow()
        {
            InitializeComponent();
        }

        private void btnThoat_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void btnDangNhap_Click(object sender, RoutedEventArgs e)
        {
            // Gia lap account la username: obama, password: 123
            if(txtUsername.Text=="obama" && txtPassword.Password == "123")
            {
                MainWindow mw = new MainWindow();
                mw.Show();
                Close();
                //hoac goi
                //btnDangNhap.RaiseEvent();
            }
            else
            {
                MessageBox.Show("Đăng nhập thất bại rồi bro!!!!");
            }
        }
    }
}
