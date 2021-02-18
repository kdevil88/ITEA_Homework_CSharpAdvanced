using System;
using GraduationWork;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GraduationWorkTest
{
    [TestClass]
    public class GraduationWorkTests
    {
        [TestMethod]
        public void User_CheckCredentials_Valid()
        {
            User user = new User();
            user.Name = "Login";
            user.Password = "Valid";
            bool actual = Common.checkCredentials(user, "Valid");
            Assert.IsTrue(actual);
        }
        [TestMethod]
        public void User_CheckCredentials_InValid()
        {
            User user = new User();
            user.Name = "Login";
            user.Password = "Valid";
            bool actual = Common.checkCredentials(user, "InValid");
            Assert.IsFalse(actual);
        }
        [TestMethod]
        public void Manager_IsAdmin_True()
        {
            Manager manager = new Manager();
            bool actual = Common.isAdmin(manager);
            Assert.IsTrue(actual);
        }
        [TestMethod]
        public void Customer_IsAdmin_False()
        {
            Customer customer = new Customer();
            bool actual = Common.isAdmin(customer);
            Assert.IsFalse(actual);
        }
        [TestMethod]
        public void NewOrderProductTotalPrice_quantity3price15_45returned()
        {
            int q = 3;
            int p = 15;
            decimal expected = 45;
            NewOrder newOrder = new NewOrder();
            newOrder.Quantity = q;
            newOrder.Product = new Product { Price = p };
            decimal actual = newOrder.ProductTotalPrice;
            Assert.AreEqual(expected, actual);
        }
    }
}
