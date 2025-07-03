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
using static Microsoft.EntityFrameworkCore.Query.Internal.ExpressionTreeFuncletizer;

namespace MyStoreWpfApp_EntityFramework
{
    /// <summary>
    /// Interaction logic for AdminWindow.xaml
    /// </summary>
    public partial class AdminWindow : Window
    {
        MyStoreContext _context = new MyStoreContext();
        public AdminWindow()
        {
            InitializeComponent();
            LoadCateogoriesIntoTreeView();
        }

        private void LoadCateogoriesIntoTreeView()
        {
            // tao root
            TreeViewItem root = new TreeViewItem();
            root.Header = "kho hang Cat Lai";
            tvCategory.Items.Add(root);
            // truy van toan bo danh muc
            var category = _context.Categories.ToList();
            foreach (var item in category)
            {
                TreeViewItem cate_node = new TreeViewItem();
                cate_node.Header = item.CategoryName;
                cate_node.Tag = item;
                root.Items.Add(cate_node);
                //Loc san pham theo category
                var products = _context.Products
                    .Where(x => x.CategoryId == item.CategoryId)
                    .ToList();
                //Nap product vao cate tuong ung
                foreach (var item1 in products)
                {
                    //Tao node
                    TreeViewItem pro_node = new TreeViewItem();
                    pro_node.Header = item1.ProductName;
                    pro_node.Tag = item1;
                    cate_node.Items.Add(pro_node);
                }
            }
            root.ExpandSubtree(); // Mo rong cac cay con
        }

        private void tvCategory_SelectedItemChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            if (e.NewValue == null)
            {
                return;
            }
            TreeViewItem item = e.NewValue as TreeViewItem;
            if (item == null)
            {
                return;
            }
            Category category = item.Tag as Category;
            if (category == null) return;
            LoadProductIntoListView(category);
        }

        private void LoadProductIntoListView(Category category)
        {
            var products = _context.Products
                    .Where(x => x.CategoryId == category.CategoryId)
                    .ToList();
            lvProduct.ItemsSource = null;
            lvProduct.ItemsSource = products;
        }

        private void lvProduct_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.AddedItems.Count == 0) return; // Kiem tra cac items duoc chon, neu = 0 tuc la khong co va se return
            Product product = e.AddedItems[0] as Product;
            DisplayProductDetail(product);
        }

        void DisplayProductDetail(Product product)
        {
            if (product == null)
            {
                txtId.Text = "";
                txtName.Text = "";
                txtQuantity.Text = "";
                txtPrice.Text = "";
            }
            else
            {
                txtId.Text = product.ProductId.ToString();
                txtName.Text = product.ProductName;
                txtQuantity.Text = product.UnitsInStock.ToString();
                txtPrice.Text = product.UnitPrice.ToString();
            }

        }

        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            DisplayProductDetail(null);
            txtId.Focus();
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                //b1: tim danh muc ma ta muon luu product vao
                TreeViewItem cate_node = tvCategory.SelectedItem as TreeViewItem;
                if (cate_node == null)
                {
                    MessageBox.Show("ban can chon danh muc truoc", "Loi luu san pham", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
                Category cateogory = cate_node.Tag as Category;
                if (cateogory == null)
                {
                    MessageBox.Show("ban can chon danh muc truoc", "Loi luu san pham", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
                //b2: tao product obj
                Product product = new Product();
                //b3: gan gia tri cho cac thuoc tinh cua product
                product.ProductName = txtName.Text;
                product.UnitsInStock = short.Parse(txtQuantity.Text);
                product.UnitPrice = decimal.Parse(txtPrice.Text);
                product.CategoryId = cateogory.CategoryId;
                _context.Products.Add(product);
                _context.SaveChanges();
                //b4: thuc hien luu product va cap nhat lai tv, lv
                //b4.1: Nap lai tv - tao product node cho cate node
                TreeViewItem product_node = new TreeViewItem();
                product_node.Header = product.ProductName;
                product_node.Tag = product;
                cate_node.Items.Add(product_node);
                //4.2 Nap lai lv
                LoadProductIntoListView(cateogory);
            }
            catch (Exception ex)
            {
                // Phai bat loi, khong duoc de system crash
                MessageBox.Show("Loi tum lum: " + ex.Message, "Loi", MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                
                //b1: tim san pham muon sua truoc
                int id = int.Parse(txtId.Text);
                Product product = _context.Products.FirstOrDefault(x => x.ProductId == id);
                if (product == null)
                {
                    MessageBox.Show("Khong tim thay san pham", "Loi sua", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
                //b2: tien hanh thay doi gia tri cac thuoc tinh
                product.ProductName = txtName.Text;
                product.UnitPrice = decimal.Parse(txtPrice.Text);
                product.UnitsInStock = short.Parse(txtQuantity.Text);
                //b3: thuc hien luu thay doi
                _context.SaveChanges();
                //b4: cap nhat lai giao dien TV va LV
                TreeViewItem cate_note = tvCategory.SelectedItem as TreeViewItem;
                if (cate_note != null)
                {
                    Category category = cate_note.Tag as Category;
                    if (category != null)
                    {
                        //xoá toàn bộ node con cũ của cate_note
                        cate_note.Items.Clear();
                        //nạp lại Product 
                        //Lọc sản phẩm theo danh mục
                        var products = _context.Products.Where(x => x.CategoryId == category.CategoryId).ToList();
                        //nạp product vào node danh mục tương ứng 
                        foreach (var product_update in products)
                        {
                            // tạo node cho product 
                            TreeViewItem product_node = new TreeViewItem();
                            product_node.Header = product_update.ProductName;
                            product_node.Tag = product_update;
                            cate_note.Items.Add(product_node);
                        }
                        //Bước 4.2 : Nạp lại listView
                        LoadProductIntoListView(category);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                //b1: tim san pham de xoa
                int id = int.Parse(txtId.Text);
                Product product = _context.Products.FirstOrDefault(x => x.ProductId == id);
                if (product == null)
                {
                    MessageBox.Show("khong tim thay san pham muon xoa", "loi xoa", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
                //b2: hoi xac thuc co muon hay khong
                var ret = MessageBox.Show("Ban co chac muon xoa san pham nay khong ?", "Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (ret == MessageBoxResult.No)
                {
                    return;
                }
                //b3: tien hanh xoa neu dong y
                _context.Products.Remove(product); // Xoa trong db
                _context.SaveChanges();
                //b4: cap nhat lai giao dien
                TreeViewItem cate_note = tvCategory.SelectedItem as TreeViewItem; //Lay ra cate_node dang chon
                if (cate_note != null)
                {
                    Category category = cate_note.Tag as Category; // lay ra tag cua cate_node
                    if (category != null)
                    {
                        //xoá toàn bộ node con cũ của cate_note
                        cate_note.Items.Clear();
                        //nạp lại Product 
                        //Lọc sản phẩm theo danh mục
                        var products = _context.Products.Where(x => x.CategoryId == category.CategoryId).ToList();
                        //nạp product vào node danh mục tương ứng 
                        foreach (var product_update in products)
                        {
                            // tạo node cho product 
                            TreeViewItem product_node = new TreeViewItem();
                            product_node.Header = product_update.ProductName;
                            product_node.Tag = product_update;
                            cate_note.Items.Add(product_node);
                        }
                        //Bước 4.2 : Nạp lại listView
                        LoadProductIntoListView(category);
                        //4.3 Cap nhat lai o TextBox chua thong tin product
                        DisplayProductDetail(null);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
