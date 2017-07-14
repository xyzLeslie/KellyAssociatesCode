using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShoppingCart.Data.Repository.Interface;
using ShoppingCart.Data.Entities;
using ShoppingCart.Data.Repository;


namespace ShoppingCart.Service.Services
{
    public interface ICustomerService
    {
        IEnumerable<Customer> GetAllCustomers();
        Customer FindById(int Id);
        IEnumerable<Customer> SearchByName(string Name);
    }

    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;

        public CustomerService(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public IEnumerable<Customer> GetAllCustomers()
        {
            return _customerRepository.GetAllCustomers();
        }
        public Customer FindById(int Id)
        {
            return _customerRepository.FindById(Id);
        }
        public IEnumerable<Customer> SearchByName(string Name)
        {
            return _customerRepository.SearchByName(Name);
        }

    }
}
