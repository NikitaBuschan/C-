using System;
using System.Diagnostics;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MyCalcLib.Tests
{
    [TestClass]
    public class ClassInitAndCleanUp
    {
        private static ShoppingCart cart;

        [ClassInitialize]
        public static void ClassInitialize(TestContext context)
        {
            Debug.WriteLine("Class Initialize");
            Item item = new Item();
            item.Name = "Unit Test";
            item.Quantity = 10;

            cart = new ShoppingCart();
            cart.Add(item);
        }

        [ClassCleanup]
        public static void TestCleanUp()
        {
            Debug.WriteLine("Test CleanUp");
            cart.Dispose();
        }

        [TestMethod]
        public void ShopingCart_AddToCart()
        {
            int expected = cart.Items.Count + 1;

            cart.Add(new Item() { Name = "Test", Quantity = 1 });

            Assert.AreEqual(expected, cart.Count);
        }
    }
}
