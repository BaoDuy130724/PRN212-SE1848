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
                cate_node.Header =item.CategoryName;
                cate_node.Tag =item;
                root.Items.Add(cate_node);
                //Loc san pham theo category
                var products = _context.Products
                    .Where(x => x.CategoryId==item.CategoryId)
                    .ToList();
                //Nap product vao cate tuong ung
                foreach (var item1 in products)
                {
                    //Tao node
                    TreeViewItem pro_node = new TreeViewItem();
                    pro_node.Header = item1.ProductName;
                    pro_node.Tag =item1;
                    cate_node .Items.Add(pro_node);
                }
            }
            root.ExpandSubtree(); // Mo rong cac cay con
        }

        private void tvCategory_SelectedItemChanged_1(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            if(e.NewValue == null) 
            {
                return;
            }
            TreeViewItem item = e.NewValue as TreeViewItem; 
            if (item == null)
            {
                return;
            }
            Category category = item.Tag as Category;
            if (category == null)  return;
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
    }
}
