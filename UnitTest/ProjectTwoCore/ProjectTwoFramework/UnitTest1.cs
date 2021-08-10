using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ProjectTwoFramework
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            Calc calc = new Calc();

            var expected = 20;
            var actual = calc.Sum(10, 10);

            Assert.Equal(expected, actual);
        }
    }
}
