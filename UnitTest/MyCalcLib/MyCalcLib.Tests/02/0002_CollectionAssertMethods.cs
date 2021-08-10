using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MyCalcLib.Tests
{
    [TestClass]
    public class CollectionAssertMethods
    {
        static List<string> employees;

        [ClassInitialize]
        public static void InitializeCurrentTest(TestContext testContext)
        {
            employees = new List<string>();

            employees.Add("Ivan");
            employees.Add("Ivan1");
            employees.Add("Ivan2");
            employees.Add("Ivan3");
        }

        [TestMethod]
        public void AllItemsAreNotNull()
        {
            // Проверка, что все элементы коллекции созданы
            CollectionAssert.AllItemsAreNotNull(employees, "Not null failed");
        }

        [TestMethod]
        public void AllItemsAreUnique()
        {
            // Проверка значений коллекции на уникальность
            CollectionAssert.AllItemsAreUnique(employees, "Uniqueness failed");
        }

        [TestMethod]
        public void AreEqual()
        {
            List<string> employeesTest = new List<string>();

            employeesTest.Add("Ivan");
            employeesTest.Add("Ivan1");
            employeesTest.Add("Ivan2");
            employeesTest.Add("Ivan3");

            // Последовательность и значения коллекций должны совпадать!
            CollectionAssert.AreEqual(employees, employeesTest);
        }

        [TestMethod]
        public void AreEquivalent()
        {
            List<string> employeesTest = new List<string>();

            employeesTest.Add("Ivan");
            employeesTest.Add("Ivan2");
            employeesTest.Add("Ivan1");
            employeesTest.Add("Ivan3");

            // Проверка по количеству и совпадению значений
            // на наличие одинаковых элементов, порядок которых не важен
            CollectionAssert.AreEquivalent(employees, employeesTest);
        }

        [TestMethod]
        public void employees_Subset()
        {
            List<string> employees_Subset = new List<string>();

            employees_Subset.Add(employees[2]);

            // Проверка того, что элементы employees_Subset входят в коллекцию employees
            CollectionAssert.IsSubsetOf(employees_Subset, employees, "failed!");

            // Проверка того, что элементы employees_Subset НЕ входят в коллекцию employees
            // CollectionAssert.IsNotSubsetOf(employees_Subset, employees, "failed!");
        }
    }
}
