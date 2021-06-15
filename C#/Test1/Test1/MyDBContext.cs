using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace Test1
{
    public class MyDBContext : DbContext
    {
        public MyDBContext() : base("DbConnectionString")
        {

        }

        public DbSet<Groupddd> Groupsddd { get; set; }
        public DbSet<Specialization> Specializations { get; set; }
    }
}
