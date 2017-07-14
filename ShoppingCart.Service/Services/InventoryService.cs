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
    public interface IInventoryService
    {
        bool CheckInventory(int productId, int quantity);
    }

    public class InventoryService : IInventoryService
    {
        private readonly IInventoryRepository _inventoryRepository;

        public InventoryService(IInventoryRepository inventoryRepository)
        {
            _inventoryRepository = inventoryRepository;
        }
        
        public bool CheckInventory(int productId, int quantity)
        {
            return _inventoryRepository.CheckInventory(productId, quantity);
        }
        
    }
}
