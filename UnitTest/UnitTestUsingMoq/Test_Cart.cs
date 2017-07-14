using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ShoppingCart;
using ShoppingCart.Data;
using ShoppingCart.Service;
using Moq;
using ShoppingCart.Data.Entities;
using ShoppingCart.Service.Services;
using static ShoppingCart.Data.Entities.Cart;

namespace UnitTest.UnitTestUsingMoq
{
    [TestClass]
    public class Test_Cart
    {
        Product P1 = new Product { ProductID = 1, Name = "P1", Description = "This is P1.", Price = 5, Category = "Office", Inventory = 10 };
        Product P2 = new Product { ProductID = 2, Name = "P2", Description = "This is P2.", Price = 6, Category = "Office", Inventory = 20 };

        [TestMethod]
        public void Add_Item()
        {
            CartService target = new CartService();

            target.AddItem(P1, 1);
            target.AddItem(P2, 1);
            CartLine[] results = target.ListItems().ToArray();

            Assert.AreEqual(results.Length, 2);
        }

        [TestMethod]
        public void Remove_Item()
        {

            CartService target = new CartService();

            target.AddItem(P1, 1);
            target.AddItem(P2, 1);

            target.RemoveLine(P2);

            CartLine[] results = target.ListItems().ToArray();

            Assert.AreEqual(results.Length, 1);
        }

        [TestMethod]
        public void Calculate_Value()
        {
            CartService target = new CartService();

            target.AddItem(P1, 2);
            target.AddItem(P2, 3);

            decimal result = target.ComputeTotalValue();

            Assert.AreEqual(result, 28);
        }
    }
}
