using AngleSharp.Html.Dom;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Windows;

namespace One.Core.Habra
{

    class AutoProParser : IParser<string[]>
    {
        private string connectionString = @"Data Source=DESKTOP-FE00VPV\SQLEXPRESS;Initial Catalog=AutoPro;Integrated Security=True;";

        private readonly List<long> models = new List<long>();

        // Выбор модели
        public string[] ParseModels(IHtmlDocument document)
        {
            string name = string.Empty;
            string code = string.Empty;
            string dateRange = string.Empty;
            string complectations = string.Empty;

            var list = new List<string>();
            // Получение колонок (списка)
            var columns = document.QuerySelectorAll(".List.Multilist");

            try
            {
                // Создание подключения к базе данных
                using (var connection = new SqlConnection(connectionString))
                {
                    // Подключение к базе данных
                    connection.Open();

                    // Строка запроса на добавление модели в таблицу
                    string sqlString = "INSERT INTO Models (Name, Code, Date) VALUES (@name, @code, @date)";

                    foreach (var column in columns)
                    {
                        foreach (var columnItem in column.Children)
                        {
                            name = columnItem.QuerySelector(".name").TextContent;
                            list.Add(name);

                            foreach (var codeList in columnItem.QuerySelector(".List").Children)
                            {
                                code = codeList.QuerySelector("a").TextContent;
                                dateRange = codeList.QuerySelector(".dateRange").TextContent;
                                complectations = codeList.QuerySelector(".modelCode").TextContent;

                                using (SqlCommand command = new SqlCommand(sqlString, connection))
                                {
                                    command.Parameters.Add(new SqlParameter("@name", name));
                                    command.Parameters.Add(new SqlParameter("@code", code));
                                    command.Parameters.Add(new SqlParameter("@date", dateRange));
                                    command.ExecuteNonQuery();
                                }

                                string sqlGetIdString = "SELECT @@IDENTITY";
                                using (SqlCommand commandId = new SqlCommand(sqlGetIdString, connection))
                                    models.Add(Convert.ToInt64(commandId.ExecuteScalar()));

                                list.Add($"{code} {dateRange} {complectations}");
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            return list.ToArray();
        }

        // Выбор группы запчастей
        public string[] ParseComplectations(IHtmlDocument document)
        {
            var list = new List<string>();
            var items = document.QuerySelectorAll("table");

            try
            {
                // Создание подключения к базе данных
                using (var connection = new SqlConnection(connectionString))
                {
                    // Подключение к базе данных
                    connection.Open();

                    // Строка запроса на добавление группы запчастей в таблицу
                    string sqlString = "INSERT INTO Modifications (Engine1, Body, Grade, AtmMtm, GearShiftType, DriversPosition, NoOfDoors, Destination1, Dectination2, ModelFk) " +
                        "VALUES (@0, @1, @2, @3, @4, @5, @6, @7, @8, @ModelFk)";

                    foreach (var tbody in items[0].Children)
                    {

                        foreach (var tr in tbody.Children)
                        {
                            using (SqlCommand command = new SqlCommand(sqlString, connection))
                            {
                                var item = 0;
                                var i = 0;

                                foreach (var td in tr.Children)
                                {
                                    if (i > 1)
                                    {
                                        command.Parameters.Add(new SqlParameter($"@{item}", td.TextContent));
                                        list.Add(td.TextContent);
                                        item++;
                                    }
                                    i++;
                                }
                                // models[0]
                                command.Parameters.Add(new SqlParameter("@ModelFk", 1));
                                command.ExecuteNonQuery();
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            return list.ToArray();
        }

        // Выбор подгруппы запчастей первого уровня
        public string[] ParseSpares(IHtmlDocument document)
        {
            var list = new List<string>();
            var items = document.QuerySelectorAll(".name");
            try
            {
                // Создание подключения к базе данных
                using (var connection = new SqlConnection(connectionString))
                {
                    // Подключение к базе данных
                    connection.Open();

                    foreach (var item in items)
                    {

                        // Строка запроса на добавление группы запчастей в таблицу
                        string sqlString = "INSERT INTO Complectation (Name, ModificationsFk) " +
                        "VALUES (@name, @modificationsFk)";

                        using (SqlCommand command = new SqlCommand(sqlString, connection))
                        {

                            command.Parameters.Add(new SqlParameter("@name", item.Children[0].TextContent));
                            command.Parameters.Add(new SqlParameter("@modificationsFk", 1));
                            command.ExecuteNonQuery();
                        }
                        list.Add(item.Children[0].TextContent);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            return list.ToArray();
        }

        // Выбор подгруппы запчастей второго уровня
        public string[] ParseSparesGroup(IHtmlDocument document)
        {
            var list = new List<string>();
            var items = document.QuerySelectorAll(".name");
            try
            {
                // Создание подключения к базе данных
                using (var connection = new SqlConnection(connectionString))
                {
                    // Подключение к базе данных
                    connection.Open();

                    foreach (var item in items)
                    {

                        // Строка запроса на добавление запчастей второго уровня в таблицу
                        string sqlString = "INSERT INTO [Group] (Name, ComplectationFk) " +
                        "VALUES (@name, @complectationFk)";

                        using (SqlCommand command = new SqlCommand(sqlString, connection))
                        {

                            command.Parameters.Add(new SqlParameter("@name", item.Children[0].TextContent));
                            command.Parameters.Add(new SqlParameter("@complectationFk", 1));
                            command.ExecuteNonQuery();
                        }
                        list.Add(item.Children[0].TextContent);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            return list.ToArray();
        }

        // Парисим конкретные запчасти из таблицы
        public string[] ParseChoosePage(IHtmlDocument document)
        {
            var list = new List<string>();
            var tableRows = document.QuerySelectorAll("tbody")[0].Children;
            string treeCode = string.Empty;
            string tree = string.Empty;
            int i = 0;
            foreach (var row in tableRows)
            {
                if (i == 0)
                {
                    i++;
                    continue;
                }
                try
                {
                    // Создание подключения к базе данных
                    using (var connection = new SqlConnection(connectionString))
                    {
                        // Подключение к базе данных
                        connection.Open();

                        // Строка запроса на добавление запчастей второго уровня в таблицу
                        string sqlString = "INSERT INTO Spares (Code, Count, Info, TreeCode, Tree, Date, GroupFk) " +
                        "VALUES (@code, @count, @info, @treeCode, @tree, @date, @groupFk)";

                       
                        using (SqlCommand command = new SqlCommand(sqlString, connection))
                        {
                            // Получение tree эдемента
                            if (row.Children.Length == 1)
                            {
                                list.Add(row.Children[0].TextContent);
                                var treeCodeStrings = row.Children[0].TextContent.Split();
                                treeCode = treeCodeStrings[0];
                                var len = row.Children[0].TextContent.Length;
                                tree = row.Children[0].TextContent.Substring(treeCode.Length - 1, len - treeCode.Length);
                                continue;
                            }

                            // Если деталь была заменена (выставляем новый код детали)
                            if (row.Children[0].Children.Length == 2)
                            {
                                var codeStrings = row.Children[0].Children[1].TextContent.Split();
                                var code = codeStrings[2];

                                command.Parameters.Add(new SqlParameter("@code", code));
                            } else
                            {
                                command.Parameters.Add(new SqlParameter("@code", row.Children[0].TextContent));
                            }

                            
                            command.Parameters.Add(new SqlParameter("@count", row.Children[1].TextContent));
                            command.Parameters.Add(new SqlParameter("@date", row.Children[2].TextContent));
                            command.Parameters.Add(new SqlParameter("@info", row.Children[3].TextContent));
                            command.Parameters.Add(new SqlParameter("@tree", tree));
                            command.Parameters.Add(new SqlParameter("@groupFk", 1));
                            command.Parameters.Add(new SqlParameter("@treeCode", treeCode));

                            command.ExecuteNonQuery();
                        }

                        foreach (var columns in row.Children)
                        {
                            // Если нет вложенности (у th элементов)
                            if (columns.Children.Length == 0)
                            {
                                list.Add(columns.TextContent);
                            }
                            else   // Если есть вложенность: number, count, dateRange, info элементы
                            {
                                list.Add(columns.Children[0].TextContent);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

            }

            return list.ToArray();
        }
    }
}
