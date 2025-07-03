using MyStoreWpfApp_EntityFramework.Entities;
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

namespace MyStoreWpfApp_EntityFramework
{
    /// <summary>
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        MyStoreContext context = new MyStoreContext();
        public LoginWindow()
        {
            InitializeComponent();
            ChangeBackground();
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            string email = txtEmail.Text;
            string pass = txtPassword.Password;
            AccountMember am =  context.AccountMembers
                .FirstOrDefault(m => m.EmailAddress == email && m.MemberPassword == pass);
            if (am == null)
            {
                MessageBox.Show("Login Failed","Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            else
            {
                if (am.MemberRole == 1)
                {
                    MessageBox.Show("Login as ADMIN successfully", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
                    AdminWindow adminWindow = new AdminWindow();
                    adminWindow.Show();
                    Close();
                    return;
                }
                else if (am.MemberRole == 2)
                {
                    MessageBox.Show("Login as STAFF successfully", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
                    return;
                }
                else if (am.MemberRole == 3)
                {
                    MessageBox.Show("Login as MEMBER successfully", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
                    return ;
                }
            }
        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        private void ChangeBackground()
        {
            LinearGradientBrush brush = new LinearGradientBrush();
            brush.GradientStops.Add(new GradientStop(Colors.Magenta, 0.0));
            brush.GradientStops.Add(new GradientStop(Colors.Yellow, 0.5));
            brush.GradientStops.Add(new GradientStop(Colors.Cyan, 1.0));
            btnExit.Background = brush;
            //
            RadialGradientBrush brush2 = new RadialGradientBrush();
            brush2.GradientOrigin = new Point(0.5, 0.75);
            brush2.GradientStops.Add(new GradientStop(Colors.Red,0.0));
            brush2.GradientStops.Add(new GradientStop(Colors.White, 0.5));
            brush2.GradientStops.Add(new GradientStop(Colors.Blue, 1.0));
            btnLogin.Background = brush2;
        }
    }
}
