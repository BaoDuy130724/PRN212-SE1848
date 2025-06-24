using System.ComponentModel.DataAnnotations;
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
using TreeViewWpfApp.models;
namespace TreeViewWpfApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Dictionary<int, Category> categories = SampleDataset.GenerateDataset();
        public MainWindow()
        {
            InitializeComponent();
            DisplayDataIntoTreeView();
        }

        private void DisplayDataIntoTreeView()
        {
            //xoa du lieu cu di
            tvCategory.Items.Clear();
            //tao nut goc
            TreeViewItem root = new TreeViewItem();
            root.Header = "kho hàng ĐỘC LẠ BÌNH DƯƠNG";
            //Loop1 : nạp toàn bộ danh mục lên cây
            foreach (KeyValuePair<int,Category> item  in categories)
            {
                Category cate = item.Value;
                //Tạo category node
                TreeViewItem cate_node = new TreeViewItem();
                cate_node.Header = cate;
                root.Items.Add(cate_node);
                //Loop2: Nạp sản phẩm của các danh mục lên cây
                foreach (KeyValuePair<int, Product> subitem in cate.Products)
                {
                    Product p = subitem.Value;
                    TreeViewItem p_node = new TreeViewItem();
                    p_node.Header = p;
                    cate_node.Items.Add(p_node);
                }
                
            }
            tvCategory.Items.Add(root);
        }
    }
}