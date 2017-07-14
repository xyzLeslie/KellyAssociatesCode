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
    public class Test_Product
    {
        Mock<IProductRepository> mock = new Mock<IProductRepository>();
        [TestInitialize]
        public void Initialize()
        {
            var products = new List<Product>()
            {
            new Product() { ProductID = 1, Name = "P1", Description = "This is P1.", Price = 5, Category = "Office", Inventory = 10 },
            new Product() { ProductID = 2, Name = "P2", Description = "This is P2.", Price = 6, Category = "Office", Inventory = 20 }
            };
            mock.Setup(m => m.GetAllProducts()).Returns(products);
            mock.Setup(m => m.FindById(2)).Returns(products.FirstOrDefault(p => p.ProductID == 2));
            mock.Setup(m => m.SearchByName("P2")).Returns(products.Where(p => p.Name == "P2"));
        }

        [TestMethod]
        public void Get_All_Products()
        {
            ProductService target = new ProductService(mock.Object);
            IEnumerable<Product> results = target.GetAllProducts();
            Assert.IsNotNull(results);
        }

        [TestMethod]
        public void Find_By_Id()
        {
            ProductService target = new ProductService(mock.Object);
            Product result = target.FindById(2);
            Assert.AreEqual(result.Name, "P2");
        }

        [TestMethod]
        public void Search_By_Name()
        {
            ProductService target = new ProductService(mock.Object);
            IEnumerable<Product> results = target.SearchByName("P2");
            Assert.AreEqual(results.Count(), 1);
        }

    }
}
