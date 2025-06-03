using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoLINQ2ObjectModelClass
{
    public class ListProduct
    {
        List<Product> products;
        public ListProduct()
        {
            products = new List<Product>();
        }
        public void gen_Product()
        {
            products.Add(new Product() { ID = 1, Name = "p1", Quantity = 10, Price = 100 });
            products.Add(new Product() { ID = 2, Name = "p2", Quantity = 15, Price = 150 });
            products.Add(new Product() { ID = 3, Name = "p3", Quantity = 20, Price = 200 });
            products.Add(new Product() { ID = 4, Name = "p4", Quantity = 8, Price = 120 });
            products.Add(new Product() { ID = 5, Name = "p5", Quantity = 12, Price = 180 });
            products.Add(new Product() { ID = 6, Name = "p6", Quantity = 5, Price = 90 });
            products.Add(new Product() { ID = 7, Name = "p7", Quantity = 18, Price = 250 });
            products.Add(new Product() { ID = 8, Name = "p8", Quantity = 22, Price = 300 });
            products.Add(new Product() { ID = 9, Name = "p9", Quantity = 9, Price = 110 });
            products.Add(new Product() { ID = 10, Name = "p10", Quantity = 14, Price = 160 });

        }
        public List<Product> FilterProductByPrice(double a, double b)
        {
            var result = from p in products
                         where p.Price >= a && p.Price <= b
                         select p;
            return result.ToList();
        }
        public List<Product> FilterProductByPrice2(double a, double b)
        {
             return products.Where(product => product.Price>=a && product.Price<=b).ToList();
        }
        public List<Product> SortProductByPriceAsc()
        {
            return products.OrderBy(product => product.Price).ToList();
        }
        public List<Product> SortProductByPriceAsc2()
        {
            var rs = from p in products
                     orderby p.Price ascending
                     select p;
            return rs.ToList();
        }
        public List<Product> SortProductByPriceDesc()
        {
            return products.OrderByDescending(product => product.Price).ToList();
        }
        public List<Product> SortProductByPriceDesc2()
        {
            var rs = from p in products
                     orderby p.Price descending
                     select p;
            return rs.ToList();
        }
        public double SumOfValues()
        {
            return products.Sum(p=>p.Quantity * p.Price);
        }
        public Product FindProductByID(int id)
        {
            return products.FirstOrDefault(p => p.ID == id);
        }
        public List<Product> TopNProducts(int n)
        {
            var rs = products.OrderByDescending(p=>p.Price * p.Quantity).Take(n).ToList();
            return rs;
        }
    }
}
