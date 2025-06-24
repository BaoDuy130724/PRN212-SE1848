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
using BusinessObjects;
using Services;

namespace WpfApp
{
    /// <summary>
    /// Interaction logic for ProductWindow.xaml
    /// </summary>
    public partial class ProductWindow : Window
    {
        ProductService productService = new ProductService();
        bool isCompleted = false;
        public ProductWindow()
        {
            InitializeComponent();
            isCompleted = false;
            productService.GenerateSampleDataset();
            lvProduct.ItemsSource = productService.GetProducts();
            isCompleted = true;
        }

        //private void btnAddProduct_Click(object sender, RoutedEventArgs e)
        //{
        //    MessageBox.Show("Add Product button clicked!");
        //}

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                isCompleted = false;
                Product p = new Product()
                {
                    Id = int.Parse(txtid.Text),
                    Name = txtname.Text,
                    Quantity = int.Parse(txtquantity.Text),
                    Price = double.Parse(txtprice.Text)
                };
                bool kq = productService.SaveProduct(p);
                if (kq)
                {
                    lvProduct.ItemsSource = null;
                    lvProduct.ItemsSource = productService.GetProducts();
                }
                isCompleted = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: "+ex.Message);
            }
        }

        private void btnSua_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                isCompleted = false;
                int id = int.Parse(txtid.Text);
                Product p = productService.GetProduct(id);
                if (p == null) return; //khong tim thay de sua
                                       // neu tim thay thi thay doi du lieu
                p.Name = txtname.Text;
                p.Quantity = int.Parse(txtquantity.Text);
                p.Price = double.Parse(txtprice.Text);
                bool kq = productService.UpdateProduct(p);
                if (kq)
                {
                    lvProduct.ItemsSource = null; //reset lvProduct
                    lvProduct.ItemsSource = productService.GetProducts();
                }
                isCompleted = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: "+ex.Message);
            }
        }

        private void lvProduct_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (isCompleted == false)
                return;//vi thuc hien thao tac du lieu chua xong
            if (e.AddedItems.Count < 0)
                return;//nguoi dung chua chon dong nao
            //lay product dang chon
            Product p = e.AddedItems[0] as Product; //doi tuong lay ra duoc xem la Product object
            if(p == null) return;
            //lay ra duoc product xong gan vao cac textbox
            txtid.Text = p.Id.ToString();
            txtname.Text = p.Name.ToString();
            txtquantity.Text = p.Quantity.ToString();
            txtprice.Text = p.Price.ToString();
        }

        private void btnXoa_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // phai xac thuc co muon xoa khong ?
                MessageBoxResult ret = MessageBox.Show(
                    "Bạn muốn xóa sản phẩm này hả?",//Nội dung hỏi của cửa sổ
                    "Xác nhận xóa", //Tiêu đề cửa sổ
                    MessageBoxButton.YesNo, //Hiển thị lựa chọn YES/NO
                    MessageBoxImage.Question); // Hiển thị biểu tượng câu hỏi
                if (ret == MessageBoxResult.No)
                {
                    return; //Xác nhận không xóa 
                }
                isCompleted = false; //đánh dấu là chưa làm xong thao tác
                int id = int.Parse(txtid.Text);
                bool kq = productService.DeleteProduct(id);
                if (kq == false) return;
                lvProduct.ItemsSource = null;
                lvProduct.ItemsSource = productService.GetProducts();
                txtid.Text = "";
                txtname.Text = "";
                txtquantity.Text = "";
                txtprice.Text = "";
                isCompleted = true; //đánh dấu là làm xong thao tác
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }
    }
}
