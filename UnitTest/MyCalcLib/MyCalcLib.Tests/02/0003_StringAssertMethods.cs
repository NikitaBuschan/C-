using System.Text.RegularExpressions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MyCalcLib.Tests
{
    [TestClass]
    public class StringAssertMethods
    {
        [TestMethod]
        public void StringContainsTest()
        {
            // Проверка на вхождение в строку подстроки
            StringAssert.Contains("Assert samples", "sam");
        }

        [TestMethod]
        public void StringMatchesTest()
        {
            // Проверка с использованием регулярного выражения
            StringAssert.Matches("123", new Regex(@"\d{3}"));
        }

        [TestMethod]
        public void StringStartWithTest()
        {
            // Проверка того, что строка начинается с определенныго слова
            StringAssert.StartsWith("Hello world", "Hello");
        }

        [TestMethod]
        public void StringEndWithTest()
        {
            // Проверка того, что строка заканчивается определенным словом
            StringAssert.EndsWith("Hello world", "o world");
        }
    }
}
