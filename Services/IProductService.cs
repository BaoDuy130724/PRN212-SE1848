using BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public interface IProductService
    {
        public void GenerateSampleDataset();
        public List<Product> GetProducts();
        public bool SaveProduct(Product product);
        public Product GetProduct(int ID);
        public bool UpdateProduct(Product product);
        public bool DeleteProduct(int ID);
        public bool DeleteProduct(Product p);
    }
}
