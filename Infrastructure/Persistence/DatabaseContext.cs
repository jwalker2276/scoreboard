using Domain.GameModels.Entities;
using Domain.PlayerModels.Enitites;
using Infrastructure.EntityConfigurations;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence;

public sealed class DatabaseContext : DbContext
{
    public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options) { }

    public DbSet<Game>? Games { get; set; }

    public DbSet<Player>? Players { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        new GameConfiguration().Configure(modelBuilder.Entity<Game>());
        new PlayerConfiguration().Configure(modelBuilder.Entity<Player>());
    }
}
