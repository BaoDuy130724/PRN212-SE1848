using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP6_Dictionary
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Dictionary<int, Product> Products { get; set; } // Dictionary to hold products by their Id

        public Category() {
            Products = new Dictionary<int, Product>(); // Initialize the dictionary
        }
        public override string ToString()
        {
            return $"{Id} \t {Name}";
        }
        /*
         * khi quản lý mọi đối tượng ta đều phải đáp ứng đầy đủ tính năng của CRUD 
         */
        public void AddProduct(Product p)
        {
            //kiểm tra ID nếu chưa tồn tại thì thêm mới
            if (p == null)
            {
                return; // dữ liệu đầu vào null
            }
            if (Products.ContainsKey(p.Id))
            {
                return; // sản phẩm đã tồn tại
            }
            Products.Add(p.Id, p);
        }
        // Xuất toàn bộ sản phẩm 
        public void PrintAllProducts()
        {
            foreach (KeyValuePair<int, Product> kvp in Products)
            {
                Product p = kvp.Value;
                Console.WriteLine(p);
            }
        }
        // Lọc sản phẩm có giá từ MIN - MAX
        public Dictionary<int, Product> FilterProductsByPrice (double min, double max)
        {
            return Products
                .Where(item => item.Value.Price >= min && item.Value.Price <=max)
                .ToDictionary<int, Product>();
        }
        // Sắp xếp sản phầm theo giá tăng dần
        public Dictionary<int, Product> SortProductsByPrice()
        {
            return Products
                .OrderBy(item => item.Value.Price)
                .ToDictionary<int, Product>();
        }
        // Sắp xếp theo giá tăng dần, nếu giá trùng thì xếp theo số lượng giảm dần 
        public Dictionary<int, Product> SortComplex()
        {
            return Products
                .OrderByDescending(item => item.Value.Quantity)
                .OrderBy(item => item.Value.Price) // chạy cái ngoài cùng trước (không tính toDictionary)
                .ToDictionary<int, Product>();
            //return Products
            //    .OrderBy(item => item.Value.Price)
            //    .ThenByDescending(item => item.Value.Quantity)
            //    .ToDictionary<int, Product>();
        }
        // cập nhật sản phẩm
        public bool UpdateProduct(Product p)
        {
            if (p == null || !Products.ContainsKey(p.Id))
            {
                return false; // dữ liệu đầu vào null hoặc sản phẩm không tồn tại
            }
            Products[p.Id] = p; // cập nhật sản phẩm tại ô nhớ chứa p.Id    
            return true;
        }
        // xóa
        public bool RemoveProduct(int id)
        {
            if(Products.ContainsKey(id))
            {
                Products.Remove(id);
                return true; // xóa thành công
            }
            return false; // không tìm thấy sản phẩm để xóa
        }
        // Viết hàm cho phép xóa nhiều sản phẩm có đơn giá từ A tới B
        //public Dictionary<int, Product> RemoveProductsByPrice(double A, double B)
        //{
        //    foreach (KeyValuePair<int, Product> kvp in Products)
        //    {
        //        if(kvp.Value.Price >= A && kvp.Value.Price <= B)
        //        {
        //            Products.Remove(kvp.Key);
        //        }
        //    }
        //    return Products;
        //}
        //c2
        public bool RemoveProductsByPrice2(double a, double b)
        {
            List<Product> filtered_products = Products
                .Where(item => item.Value.Price >= a && item.Value.Price <= b)
                .Select(item => item.Value)
                .ToList();
            foreach(KeyValuePair<int, Product> kvp in Products)
            {
                if(filtered_products.Contains(kvp.Value))
                {
                    Products.Remove(kvp.Key);
                }
            }
            return true; // trả về true nếu xóa thành công
        }
    }
}
