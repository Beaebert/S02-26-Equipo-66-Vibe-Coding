using JustinaSimulator.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;

namespace JustinaSimulator.Infrastructure.Persistence;

public class JustinaDbContext : DbContext
{
    public JustinaDbContext(DbContextOptions<JustinaDbContext> options) : base(options)
    {
    }

    public DbSet<Robot> Robots { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Robot>(entity =>
        {
            entity.HasKey(e => e.Id);

            // Map Value Object Coordinate using EF Core 8+ Complex Types or OwnsOne
            entity.OwnsOne(e => e.CurrentTarget, navigationBuilder =>
            {
                navigationBuilder.Property(c => c.X).HasColumnName("CurrentX");
                navigationBuilder.Property(c => c.Y).HasColumnName("CurrentY");
                navigationBuilder.Property(c => c.Z).HasColumnName("CurrentZ");
            });

            // Map the Trajectory list as a serialized JSON string for simplicity in the MVP
            entity.Property(e => e.Trajectory)
                .HasConversion(
                    v => JsonSerializer.Serialize(v, (JsonSerializerOptions)null),
                    v => JsonSerializer.Deserialize<List<Coordinate>>(v, (JsonSerializerOptions)null)
                );
        });
    }
}
