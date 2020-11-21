using Microsoft.EntityFrameworkCore;

namespace ExampleApp.Data
{
    public class ExampleDbContext : DbContext
    {
        public ExampleDbContext(DbContextOptions options)
            : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<Example> Examples { get; set; }
    }
}
