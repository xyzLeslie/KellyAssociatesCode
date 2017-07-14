using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCart.Data.Entities
{
    public class Cart
    {
        public class CartLine
        {
            public Product Product { get; set; }
            public int Quantity { get; set; }
        }
        public List<CartLine> lineCollection = new List<CartLine>();
    }
}
