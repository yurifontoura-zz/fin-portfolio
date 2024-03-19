using JobSchedule.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace JobSchedule.Repository.Context
{
    public class EFContext : DbContext
    {
        public EFContext() : base() { }
        public EFContext(DbContextOptions options) : base(options) { }

        public DbSet<Shop> Shops { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            Mappings.Shop(modelBuilder.Entity<Shop>());

            base.OnModelCreating(modelBuilder);
        }
    }
}
