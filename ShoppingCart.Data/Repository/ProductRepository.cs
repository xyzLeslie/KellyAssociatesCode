using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShoppingCart.Data.Repository.Interface;
using ShoppingCart.Data.Entities;

namespace ShoppingCart.Data.Repository
{
    public class ProductRepository:IProductRepository
    {
        List<Product> ProductList = new List<Product>();

        public IEnumerable<Product> GetAllProducts()
        {
            return ProductList;
        }
        public Product FindById(int Id)
        {
            return ProductList.FirstOrDefault(p => p.ProductID == Id);
        }

        public IEnumerable<Product> SearchByName(string productName)
        {
            return ProductList.Where(p => p.Name == productName).ToList();
        }
    }
}
