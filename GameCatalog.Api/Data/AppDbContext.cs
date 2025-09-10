using GameCatalog.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace GameCatalog.Api.Data;
public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<Game> Games => Set<Game>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Game>(e =>
        {
            e.Property(g => g.Title).HasMaxLength(200).IsRequired();
            e.Property(g => g.Genre).HasMaxLength(100);
            e.Property(g => g.Price).HasColumnType("decimal(10,2)");
        });

        // Add few rows for demo
        modelBuilder.Entity<Game>().HasData(
            new Game { Id = 1, Title = "Stardew Valley", Platform = Platform.Switch, Genre = "Simulation", Price = 19.99m, ReleaseDate = new DateOnly(2017,10,5) },
            new Game { Id = 2, Title = "Elden Ring", Platform = Platform.PlayStation, Genre = "Action RPG", Price = 79.99m, ReleaseDate = new DateOnly(2022,2,25) }
        );
    }
}