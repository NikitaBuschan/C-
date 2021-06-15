using System.Data.Entity;

namespace Gems.Model
{
    public class GemContext : DbContext
    {
        public GemContext() : base("Gem") { }

        public DbSet<Gem> Gems { get; set; }
        public DbSet<Type> Types { get; set; }
    }
}
