using Microsoft.EntityFrameworkCore;
using Test.Model;

namespace Test
{
    public class StudentDbContext : DbContext
    {
        public DbSet<Departament> Departaments { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<Student> Students { get; set; }

        public StudentDbContext(DbContextOptions<StudentDbContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
