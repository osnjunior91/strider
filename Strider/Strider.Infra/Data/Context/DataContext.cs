using Microsoft.EntityFrameworkCore;
using Strider.Infra.Data.Model;

namespace Strider.Infra.Data.Context
{
    public class DataContext : DbContext
    {
        public DbSet<User> Transactions { get; set; }
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasData(
                    new User("User01"),
                    new User("User02"),
                    new User("User03")
                );
            base.OnModelCreating(modelBuilder);
        }
    }
}
