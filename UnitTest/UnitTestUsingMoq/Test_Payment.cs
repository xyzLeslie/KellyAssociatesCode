using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using ShoppingCart.Data.Entities;
using ShoppingCart.Data.Repository;
using ShoppingCart.Data.Repository.Interface;
using ShoppingCart.Service.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTest.UnitTestUsingMoq
{
    [TestClass]
    public class Test_Payment
    {
        [TestMethod]
        public void Charge_Payment()
        {
            PaymentService target = new PaymentService();
            bool result = target.ChargePayment("", 1000);
            Assert.IsFalse(result);
        }
    }
}
