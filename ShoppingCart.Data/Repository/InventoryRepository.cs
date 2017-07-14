using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShoppingCart.Data.Repository.Interface;
using ShoppingCart.Data.Entities;

namespace ShoppingCart.Data.Repository
{
    public class InventoryRepository : IInventoryRepository
    {
        List<Product> products = new List<Product>();
        public bool CheckInventory(int productId, int inventory)
        {
            
            var product = products.FirstOrDefault(p => p.ProductID == productId);
            if (product.Inventory >= inventory)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public void MinusInventory(int productId, int quantity)
        {
            var product = products.FirstOrDefault(p => p.ProductID == productId);
            product.Inventory -= quantity;
        }
    }
}
