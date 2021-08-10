using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

// Написание Data Driven тестов в MSTest

namespace MyCalcLib.Tests._04
{
    [TestClass]
    public class UserManageTests
    {
        public TestContext TestContext { get; set; }
        private UserManage manager = new UserManage();

        // DataSource - определяем источник данных
        // 1 параметр - имя провайдера
        // 2 параметр - строка подключения или путь к файлу
        // 3 параметр - имя таблицы или элемента в XML
        // 4 параметр - как происходит доступ к записям из источника данных

        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.XML",
            @"04\TestData.xml",
            "User",
            DataAccessMethod.Sequential)]
        [TestMethod]
        public void UserManager_Add_FromXML()
        {
            string userId = Convert.ToString(TestContext.DataRow["userid"]);
            string phone = Convert.ToString(TestContext.DataRow["phone"]);
            string email = Convert.ToString(TestContext.DataRow["email"]);

            bool result = manager.Add(userId, phone, email);

            Assert.IsTrue(result, "Пользователь не может быть создан");
        }
    }
}
