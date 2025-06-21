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
        public bool SaveProduct (Product product)
        {
            Product old = products.FirstOrDefault(p => p.Id == product.Id);
            if (old != null)
            {
                return false;
            }
            products.Add(product);
            return true;
        }
    }
}
