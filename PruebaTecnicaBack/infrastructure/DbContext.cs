using Microsoft.EntityFrameworkCore;
using PruebaTecnicaBack.domain.entities;
using PruebaTecnicaBack.infrastructure.configuration;

namespace PruebaTecnicaBack.infrastructure
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Store> Stores { get; set; }

         protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.HasDefaultSchema("st");
            ModelConfig(modelBuilder);
        }

        private void ModelConfig(ModelBuilder modelBuilder)
        {
            new StoreConfiguration(modelBuilder.Entity<Store>());
        }
    }
}
