using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCart.Data.Repository.Interface
{
    public interface IInventoryRepository
    {
        bool CheckInventory(int productId, int quantity);
        void MinusInventory(int productId, int quantity);
    }
}
