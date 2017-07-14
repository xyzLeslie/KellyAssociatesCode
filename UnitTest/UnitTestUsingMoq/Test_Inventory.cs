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
using ShoppingCart.Data.Repository;
using ShoppingCart.Data.Repository.Interface;
using ShoppingCart.Service.Services;


namespace UnitTest.UnitTestUsingMoq
{
    [TestClass]
    public class Test_Inventory
    {
        Mock<IInventoryRepository> mock = new Mock<IInventoryRepository>();
        [TestInitialize]
        public void Initialize()
        {
            var products = new List<Product>()
            {
            new Product() { ProductID = 1, Name = "P1", Description = "This is P1.", Price = 5, Category = "Office", Inventory = 10 },
            new Product() { ProductID = 2, Name = "P2", Description = "This is P2.", Price = 6, Category = "Office", Inventory = 20 },
            };
            mock.Setup(m => m.CheckInventory(1, 5)).Returns(true);
            mock.Setup(m => m.CheckInventory(2, 30)).Returns(false);
        }

        [TestMethod]
        public void Check_Inventory()
        {
            InventoryService target = new InventoryService(mock.Object);
            bool result1 = target.CheckInventory(1, 5);
            bool result2 = target.CheckInventory(2, 30);
            Assert.IsTrue(result1);
            Assert.IsFalse(result2);
        }
    }
}
