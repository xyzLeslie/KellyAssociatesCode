using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShoppingCart.Data.Repository.Interface;
using ShoppingCart.Data.Entities;

namespace ShoppingCart.Data.Repository
{
    public class OrderRepository:IOrderRepository
    {
        List<Order> OrderList = new List<Order>();

        public IEnumerable<Order> GetAllOrders()
        {
            return OrderList;
        }

        public void AddOrder(Order order)
        {
            OrderList.Add(order);
        }
        public void DeleteOrder(Order order)
        {
            OrderList.Remove(order);
        }
    }
}
