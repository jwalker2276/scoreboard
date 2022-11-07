using Domain.Entities.Game.Entities;
using Domain.Entities.Player.Enitites;
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
