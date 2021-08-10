using System;
using System.IO;
using System.Linq;
using Test.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Directory.GetCurrentDirectory());

            var configuration =
                new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json")
                    .Build();

            
            string connectionString = configuration.GetConnectionString("DefaultConnection");

            var options = new DbContextOptionsBuilder<StudentDbContext>()
                .UseSqlServer(connectionString)
                .Options;

            using (var context = new StudentDbContext(options))
            {
                var programmingDepartament = new Departament { Name = "Программирование" };
                var designDepartament = new Departament { Name = "Дизайн" };
                context.Departaments.Add(programmingDepartament);
                context.Departaments.Add(designDepartament);

                //var programmingDepartament = context.Departaments.FirstOrDefault(d => d.Name == "Программирование");
                context.Groups.Add(new Group { Name = "БПУ-1821", Departament = programmingDepartament });
                context.Groups.Add(new Group { Name = "БПУ-1911", Departament = programmingDepartament });
                context.Groups.Add(new Group { Name = "БПВ-1912", Departament = programmingDepartament });

                //var designDepartament = context.Departaments.FirstOrDefault(d => d.Name == "Дизайн");
                context.Groups.Add(new Group { Name = "БПУ-1821", Departament = designDepartament });
                context.Groups.Add(new Group { Name = "БПД-1911", Departament = designDepartament });
                context.Groups.Add(new Group { Name = "БПВ-1912", Departament = designDepartament });
                context.Groups.Add(new Group { Name = "БПВ-1921", Departament = designDepartament });

                context.SaveChanges();

                foreach (var department in context.Departaments)
                    Console.WriteLine($"{department.Id,-5}{department.Name}");
                Console.WriteLine();

                foreach (var group in context.Groups)
                    Console.WriteLine($"{group.Id,-5}{group.Name,-20}{group.Departament.Name}");
                Console.WriteLine();
                
                var programmingGroups = context.Groups
                    .Select(g => g)
                    .Where(g => g.Departament.Id == programmingDepartament.Id);
                foreach (var group in programmingGroups)
                    Console.WriteLine($"{group.Id,-5}{group.Name,-20}{group.Departament.Name}");
                Console.WriteLine();
            }
        }
    }
}
