using System;
using System.Configuration;
using System.Data.Common;
using System.Data.SqlClient;

namespace Test1
{
    class Test1
    {
        static void Main(string[] args)
        {
            ConnectionStringSettings settings = ConfigurationManager.ConnectionStrings["MyLibrary"];

            try
            {
                using (var connection = new SqlConnection(settings.ConnectionString))
                {
                    // Открываем соединение
                    connection.Open();

                    // Запрос
                    string queryAllBooks = "SELECT A.Name AS AuthorName, B.Name AS BookName, P.Name AS PressName " +
                        "FROM Authors A, Books B, Presses P " +
                        "WHERE A.Id = B.AuthorFk AND B.PressFk = P.Id";

                    // Отправляем запрос и пробегаемся по полученной выборке
                    using (var command = new SqlCommand(queryAllBooks, connection))
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                            Console.WriteLine($"{reader["AuthorName"]}\t{reader["BookName"]}\t{reader["PressName"]}");
                    }

                    Console.WriteLine();

                    // Запрос
                    string queryCountOfBooks = "SELECT COUNT(*) FROM Books";

                    // Отправляем запрос
                    using (var command = new SqlCommand(queryCountOfBooks, connection))
                    {
                        int count = (int)command.ExecuteScalar();
                        Console.WriteLine($"Количество книг: {count}");
                    }
                } // Закрываем соединение
            }
            catch (DbException ex)
            {
                Console.WriteLine($"Ошибка при работе с БД: {ex.Message}");
            }
        }
    }
}