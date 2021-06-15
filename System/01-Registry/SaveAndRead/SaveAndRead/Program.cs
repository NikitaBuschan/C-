using Microsoft.Win32;
using System;
using System.Collections.Generic;

namespace SaveAndRead
{
    class Program
    {
        static void Main(string[] args)
        {
            var students = new List<Student>()
            {
                new Student("Nikita", "Buschan", 24, "bpu-1721"),
                new Student("Fyodor", "Dostoevsky", Convert.ToUInt32(DateTime.Now.Year - 1821), "bpu-1721")
            };

            const string path = "Software";
            const string folder = "BPU-1721";

            try
            {
                using (var key = Registry.CurrentUser.OpenSubKey(path, true).CreateSubKey(folder, true))
                {
                    uint count = 1;
                    foreach (var student in students)
                    {
                        key.SetValue($"({count}){student.Name.Name}", student.Name.Data, student.Name.ValueKind);
                        key.SetValue($"({count}){student.Surname.Name}", student.Surname.Data, student.Surname.ValueKind);
                        key.SetValue($"({count}){student.Age.Name}", student.Age.Data, student.Age.ValueKind);
                        key.SetValue($"({count}){student.Group.Name}", student.Group.Data, student.Group.ValueKind);
                        count++;
                    }
                    key.SetValue("Count of students", $"{students.Count}", RegistryValueKind.DWord);
                }

                using (var key = Registry.CurrentUser.OpenSubKey($@"{path}\{folder}", false))
                {
                    var newStudents = new List<Student>();

                    for (uint i = 1; i <= Convert.ToInt32(key.GetValue("Count of students")); i++)
                    {
                        newStudents.Add(new Student(
                            key.GetValue($"({i})Name").ToString(),
                            key.GetValue($"({i})Surname").ToString(),
                            Convert.ToUInt32(key.GetValue($"({i})Age")),
                            key.GetValue($"({i})Group").ToString()));
                    }

                    foreach (var student in newStudents)
                    {
                        Console.WriteLine($"{student.ToString()}\n");
                    }
                }
            }
            catch (Exception)
            {
            }
        }
    }
}
