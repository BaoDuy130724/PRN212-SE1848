using BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public interface IProductRepository
    {
        public void GenerateSampleDataset();
        public List<Product> GetProducts();
        public bool SaveProduct(Product product);
        public Product GetProduct(int ID);
        public bool UpdateProduct(Product product);
        public bool DeleteProduct(Product p);
        public bool DeleteProduct(int ID);
    }
}
