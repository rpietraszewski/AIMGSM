using AIMGSM.Models;
using Microsoft.EntityFrameworkCore;

namespace AIMGSM.Contexts
{
    public class ServiceContext : DbContext
    {
        public ServiceContext(DbContextOptions<ServiceContext> options)
            : base(options)
        {
        }
        public DbSet<Service> Service { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Service>(ex =>
            {
                ex.HasKey(s => s.Id);
            });
        }
    }
}
