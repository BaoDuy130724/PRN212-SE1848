using BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class ProductDAO
    {
        static List<Product> products = new List<Product>();
        public void GenerateSampleDataset()
        {
            products.Add(new Product { Id = 1, Name = "Laptop", Quantity = 10, Price = 999.99 });
            products.Add(new Product { Id = 2, Name = "Sting", Quantity = 10, Price = 999.99 });
            products.Add(new Product { Id = 3, Name = "RedBull", Quantity = 10, Price = 999.99 });
            products.Add(new Product { Id = 4, Name = "Coca", Quantity = 10, Price = 999.99 });
            products.Add(new Product { Id = 5, Name = "Lavie", Quantity = 10, Price = 999.99 });
        }
        public List<Product> GetProducts()
        {
            return products;
        }
        public bool SaveProduct(Product product)
        {
            Product old = products.FirstOrDefault(p => p.Id == product.Id);
            if (old != null)
            {
                return false;
            }
            products.Add(product);
            return true;
        }
        public bool UpdateProduct(Product product)
        {
            //B1: tim xem product muon sua nay co ton tai khong
            Product old = products.FirstOrDefault(p => p.Id == product.Id);
            if (old == null)
            {
                return false;
            }
            old.Name = product.Name;
            old.Quantity = product.Quantity;
            old.Price = product.Price;
            return true;
        }
        public Product GetProduct(int ID)
        {
            return products.FirstOrDefault(p => p.Id == ID);
        }
        public bool DeleteProduct(int ID)
        {
            Product p = GetProduct(ID);
            if (p != null)
            {
                products.Remove(p);
                return true;

            }
            return false;
        }
        public bool DeleteProduct(Product p)
        {
            if (p == null)
            {
                return false;
            }
            return DeleteProduct(p.Id);
        }
    }
}
