using BusinessObjects;
using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class ProductRepository : IProductRepository
    {
        ProductDAO productDAO = new ProductDAO();

        public bool DeleteProduct(Product p)
        {
            return productDAO.DeleteProduct(p);
        }

        public bool DeleteProduct(int ID)
        {
            return productDAO.DeleteProduct(ID);
        }

        public void GenerateSampleDataset()
        {
            productDAO.GenerateSampleDataset();
        }

        public Product GetProduct(int ID)
        {
            return productDAO.GetProduct(ID);
        }

        public List<Product> GetProducts()
        {
            return productDAO.GetProducts();
        }

        public bool SaveProduct(Product product)
        {
            return productDAO.SaveProduct(product);
        }

        public bool UpdateProduct(Product product)
        {
            return productDAO.UpdateProduct(product);
        }
    }
}
