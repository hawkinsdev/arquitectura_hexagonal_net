using Microsoft.EntityFrameworkCore;
using MyApp.Domain.Entities;

namespace MyApp.Infrastructure.Data {

    public class MyAppDbContext : DbContext {
        public MyAppDbContext(DbContextOptions<MyAppDbContext> options) : base(options) { }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            modelBuilder.Entity<User>().HasKey( o => o.Id);
        }
    }
}