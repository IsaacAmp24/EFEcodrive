using EFEcodrive.loyalty.Domain.Models;
using Microsoft.EntityFrameworkCore;
using EFEcodrive.Shared.Extensions;

namespace EFEcodrive.Shared.Persistence.Contexts;

public class AppDbContext : DbContext
{
    public DbSet<Rewards> Rewards { get; set; }

    public AppDbContext(DbContextOptions options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        
        // Rewards
        
        builder.Entity<Rewards>().ToTable("Rewards");
        builder.Entity<Rewards>().HasKey(p => p.Id);
        builder.Entity<Rewards>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<Rewards>().Property(p => p.fleetId).IsRequired().HasMaxLength(200);
        builder.Entity<Rewards>().Property(p => p.RewardName).IsRequired().HasMaxLength(30);
        builder.Entity<Rewards>().Property(p => p.description).IsRequired().HasMaxLength(200);
        builder.Entity<Rewards>().Property(p => p.score).IsRequired();
        
        
        
        // Apply Snake Case Naming Convention
        builder.UseSnakeCaseNamingConvention();
    }
}