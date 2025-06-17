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

namespace ListWpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<int> dsDulieu = new List<int>();
        public MainWindow()
        {
            InitializeComponent();
        }
        void HienThiDanhSach() 
        {
            lstDuLieu.Items.Clear();    
            foreach (var item in dsDulieu)
            {
                int x = item;
                lstDuLieu.Items.Add(x);
            }
        }
        private void btnThem_Click(object sender, RoutedEventArgs e)
        {
            int x = int.Parse(txtGiaTri.Text);
            dsDulieu.Add(x);
            HienThiDanhSach();
            txtGiaTri.Text = "";
        }

        private void txtChen_Click(object sender, RoutedEventArgs e)
        {
            int y = int.Parse(txtGiaTriChen.Text);
            int pos = int.Parse(txtViTri.Text);
            dsDulieu.Insert(pos, y);
            HienThiDanhSach();
            txtGiaTriChen.Text = "";
            txtViTri.Text = "";
        }

        private void btnSapXepTang_Click(object sender, RoutedEventArgs e)
        {
            dsDulieu.Sort();
            HienThiDanhSach();
        }

        private void btnSapXepGiam_Click(object sender, RoutedEventArgs e)
        {
            dsDulieu.Sort();
            dsDulieu.Reverse();
            HienThiDanhSach();
        }

        private void btnXoa1PhanTu_Click(object sender, RoutedEventArgs e)
        {
            if (lstDuLieu.SelectedIndex==-1)
            {
                MessageBox.Show("Vui lòng chọn phần tử cần xóa!","Thông báo lỗi", MessageBoxButton.OK);
                return;
            }
            dsDulieu.RemoveAt(lstDuLieu.SelectedIndex);
            HienThiDanhSach();
        }

        private void btnXoaNhPhanTu_Click(object sender, RoutedEventArgs e)
        {
            if (lstDuLieu.SelectedIndex == -1)
            {
                MessageBox.Show("Vui lòng chọn phần tử cần xóa!", "Thông báo lỗi", MessageBoxButton.OK);
                return;
            }
            while (lstDuLieu.SelectedItems.Count > 0)
            {
                int data = (int)lstDuLieu.SelectedItems[0];
                dsDulieu.Remove(data);
                lstDuLieu.Items.Remove(data);
            }
        }

        private void btnXoaHet_Click(object sender, RoutedEventArgs e)
        {
            dsDulieu.Clear();
            HienThiDanhSach();
        }
    }
}