using BusinessObjects;
using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        CustomerDAO cusDAO = new CustomerDAO();
        public void GenerateSampleDataset()
        {
            cusDAO.GenerateSampleDataset();
        }

        public List<Customer> GetCustomers()
        {
           return cusDAO.GetCustomers();
        }
    }
}
