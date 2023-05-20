using AIMGSM.Models;
using Microsoft.EntityFrameworkCore;

namespace AIMGSM.Contexts
{
    public class GlobalContext : DbContext
    {
        public GlobalContext(DbContextOptions<GlobalContext> options)
            : base(options)
        {
        }
        public DbSet<Service> Service { get; set; }
        public DbSet<Device> Device { get; set; }
        public DbSet<Price> Price { get; set; }
        public DbSet<Form> Form { get; set; }
        public DbSet<Blog> Blog { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Service>()
                .HasKey(s => s.Id);
            modelBuilder.Entity<Device>()
                .HasKey(d => d.Id);
            modelBuilder.Entity<Price>()
                .HasKey(p => p.Id);
            modelBuilder.Entity<Form>()
                .HasKey(p => p.Id);
            modelBuilder.Entity<Blog>()
                .HasKey(p => p.Id);
        }
    }
}
