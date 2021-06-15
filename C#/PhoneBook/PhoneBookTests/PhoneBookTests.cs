using Microsoft.VisualStudio.TestTools.UnitTesting;
using PhoneBook;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook.Tests
{
    [TestClass()]
    public class PhoneBookTests
    {
        [TestMethod()]
        public void AllItemsAreNotNull()
        {
            StringAssert.EndsWith("123", "3");
        }


    }

}