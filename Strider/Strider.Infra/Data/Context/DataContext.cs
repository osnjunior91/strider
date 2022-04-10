using Microsoft.EntityFrameworkCore;
using Strider.Infra.Data.Model;
using System.Linq;

namespace Strider.Infra.Data.Context
{
    public class DataContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Followers> Followers { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasData(
                    new User("User01"),
                    new User("User02"),
                    new User("User03")
                );
            foreach(var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.Restrict;
            }

            base.OnModelCreating(modelBuilder);
        }
    }
}
