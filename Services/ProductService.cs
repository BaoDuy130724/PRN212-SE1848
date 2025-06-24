using BusinessObjects;
using Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class ProductService : IProductService
    {
        IProductRepository iproductRepository;
        public ProductService()
        {
            iproductRepository = new ProductRepository();
        }

        public bool DeleteProduct(int ID)
        {
            return iproductRepository.DeleteProduct(ID);
        }

        public bool DeleteProduct(Product p)
        {
            return iproductRepository.DeleteProduct(p);
        }

        public void GenerateSampleDataset()
        {
            iproductRepository.GenerateSampleDataset();
        }

        public Product GetProduct(int ID)
        {
            return iproductRepository.GetProduct(ID);
        }

        public List<Product> GetProducts()
        {
            return iproductRepository.GetProducts();
        }

        public bool SaveProduct(Product product)
        {
            return iproductRepository.SaveProduct(product);
        }

        public bool UpdateProduct(Product product)
        {
            return iproductRepository.UpdateProduct(product);
        }
    }
}
