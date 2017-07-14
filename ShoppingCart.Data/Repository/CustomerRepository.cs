using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShoppingCart.Data.Repository.Interface;
using ShoppingCart.Data.Entities;


namespace ShoppingCart.Data.Repository
{
    public class CustomerRepository : ICustomerRepository
    {
        List<Customer> CustomerList = new List<Customer>();

        public IEnumerable<Customer> GetAllCustomers()
        {
            return CustomerList;
        }
        public Customer FindById(int Id)
        {
            return CustomerList.FirstOrDefault(c => c.Id == Id);
        }

        public IEnumerable<Customer> SearchByName(string customerName)
        {
            return CustomerList.Where(c => c.Name == customerName).ToList();
        }
    }
}
