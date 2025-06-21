using BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
// thao tac voi csdl
namespace DataAccessLayer
{
    public class CustomerDAO
    {
        static List<Customer> customers = new List<Customer>();
        public void GenerateSampleDataset()
        {
            customers.Add(new Customer() { Id = 1, Name = "obama", Email = "obama@gmail.com", Phone = "012345786" });
            customers.Add(new Customer() { Id = 2, Name = "trump", Email = "trump@gmail.com", Phone = "012345786" });
            customers.Add(new Customer() { Id = 3, Name = "putin", Email = "putin@gmail.com", Phone = "012345786" });
            customers.Add(new Customer() { Id = 4, Name = "kim", Email = "kim@gmail.com", Phone = "012345786" });
            customers.Add(new Customer() { Id = 5, Name = "jong", Email = "jong@gmail.com", Phone = "012345786" });
        }
        public List<Customer> GetCustomers() // in memory data
        {
            return customers;
        }
    }
}
