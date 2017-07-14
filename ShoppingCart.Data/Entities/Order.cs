using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCart.Data.Entities
{
    public class Order
    {
        public int Id { get; set; }
        public Customer Customer { get; set; }
        public Product Item { get; set; }
        public int Quantity { get; set; }
        public decimal TotalPrice { get; set; }
        public Card CardInfo { get; set; }
        public DateTime OrderTime { get; set; }
    }
}
