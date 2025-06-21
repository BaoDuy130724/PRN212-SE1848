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
        public ProductWindow()
        {
            InitializeComponent();
            productService.GenerateSampleDataset();
            lvProduct.ItemsSource = productService.GetProducts();
        }

        //private void btnAddProduct_Click(object sender, RoutedEventArgs e)
        //{
        //    MessageBox.Show("Add Product button clicked!");
        //}

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
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
        }
    }
}
