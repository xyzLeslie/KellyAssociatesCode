using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShoppingCart.Data.Repository.Interface;
using ShoppingCart.Data.Repository;
using ShoppingCart.Data.Entities;

namespace ShoppingCart.Service.Services
{
    public interface IProductService
    {
        IEnumerable<Product> GetAllProducts();
        Product FindById(int Id);
        IEnumerable<Product> SearchByName(string productName);
    }

    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public IEnumerable<Product> GetAllProducts()
        {
            return _productRepository.GetAllProducts();
        }
        public Product FindById(int Id)
        {
            return _productRepository.FindById(Id);
        }
        public IEnumerable<Product> SearchByName(string productName)
        {
            return _productRepository.SearchByName(productName);
        }

    }
}
