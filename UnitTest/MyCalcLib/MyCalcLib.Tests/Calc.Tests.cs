using MyCalcLib;
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MyCalcLib.Tests
{
    [TestClass]
    public class MyCalcTests
    {
        [TestMethod]
        public void Sum_10and20_30returned()
        {
            // arrange
            int x = 10;
            int y = 20;
            int expected = 30;

            // act
            MyСalc c = new MyСalc();
            int actual = c.Sum(x, y);

            // assert
            Assert.AreEqual(expected, actual);
        }
    }
}



// Получить окно для отображения тестов Ctrl + E, T  || Test -> Test Explorer