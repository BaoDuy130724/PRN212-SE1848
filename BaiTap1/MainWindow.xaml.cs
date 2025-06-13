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

namespace BaiTap1
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

        private void sum_click(object sender, RoutedEventArgs e)
        {
            var numberA = txtNumbera.Text == "" ? 0 : int.Parse(txtNumbera.Text);
            var numberB = txtNumberb.Text == "" ? 0 : int.Parse(txtNumberb.Text);
            var sum = numberA + numberB;
            txtResult.Text = sum.ToString();
            
        }

        private void exit_click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}