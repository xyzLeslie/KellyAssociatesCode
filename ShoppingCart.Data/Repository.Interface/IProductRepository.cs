using ShoppingCart.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCart.Data.Repository.Interface
{
    public interface IProductRepository
    {
        IEnumerable<Product> GetAllProducts();
        Product FindById(int Id);
        IEnumerable<Product> SearchByName(string productName);
    }
}
