using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MyCalcLib.Tests
{
    [TestClass]
    public class MyClassTests
    {
        [TestMethod]
        public void IsSqrtTest()
        {
            // arrange
            const double input = 4;
            const double expected = 2;

            // act
            double actual = MyClass.GetSqrt(input);

            // assert
            Assert.AreEqual(expected, actual, "Sqrt of {0} should have been {1}!", input, expected);
        }

        [TestMethod]
        public void DeltaTest()
        {
            const double expected = 3.1;
            const double delta = 0.07;

            double actual = MyClass.GetSqrt(10);

            Assert.AreEqual(expected, actual, delta, "fail message!");
        }

        [TestMethod]
        public void StringAreEqualTest()
        {
            // arrange
            const string input = "HELLO";
            const string expected = "hello";

            // act and assert
            // Третий параметр - игнорирование регистра
            Assert.AreEqual(expected, input, true);
        }

        [TestMethod]
        public void StringSameTest()
        {
            string a = "Hello";
            string b = "Hello";

            // Проверка равенства ссылок (только для ссылочных типов данных)
            Assert.AreSame(a, b);

            // Проверка не равенства ссылок
            // Assert.AreNotSame();
        }

        [TestMethod]
        public void IntegersSameTest()
        {
            //int i = 10;
            //int j = 10;

            //Assert.AreSame(i, j);

            // Ошибка - i & j значимые типы данных
        }
    }
}
