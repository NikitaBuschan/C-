using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MyCalcLib.Tests
{
    [TestClass]
    public class ExpectingExceptions
    {
        [ExpectedException(typeof(ArgumentNullException), "Excepton was not throw nullException")]
        [TestMethod]
        public void MyClass_SayHello_Exception()
        {
            MyClass instance = new MyClass();
            instance.SayHello(null);
        }

        [TestMethod]
        public void MyClass_SayHello_ReturnNikita()
        {
            // arrange
            MyClass instance = new MyClass();
            string expected = "Hello Nikita";

            // act
            string actual = instance.SayHello("Nikita");

            // assert
            Assert.AreEqual(expected, actual);
        }
    }
}
