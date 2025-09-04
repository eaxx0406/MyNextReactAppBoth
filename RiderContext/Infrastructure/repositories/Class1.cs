using HorseRiderContext.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace HorseRiderContext.Infrastructure.repositories
{
    public class RiderDbContext : DbContext
    {
        public DbSet<Rider> Riders { get; set; } = null!;

        public RiderDbContext(DbContextOptions<RiderDbContext> options)
        : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Konfiguration af Horse-entiteten
            modelBuilder.Entity<Rider>(entity =>
            {
                entity.HasKey(r => r.Id); // Primærnøgle

                entity.Property(r => r.Id)
                    .IsRequired(); // Skal udfyldes

                entity.Property(r => r.RiderName)
                    .IsRequired()
                    .HasMaxLength(200); // Navn er påkrævet
 

                entity.Property(r => r.BirthYear)
                    .IsRequired(); // Skal udfyldes

                entity.Property(r => r.Email)
                    .IsRequired()
                    .HasMaxLength(200); // Email er påkrævet
            });
        }
    }
}