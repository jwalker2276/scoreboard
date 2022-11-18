using Domain.GameModels.Entities;
using Domain.PlayerModels.Entities;
using Domain.ScoreBoardModels.Entities;
using Domain.ScoreModels.Entities;
using Infrastructure.EntityConfigurations;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence;

public sealed class DatabaseContext : DbContext
{
    public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options) { }

    public DbSet<Game>? Games { get; set; }

    public DbSet<Player>? Players { get; set; }

    public DbSet<Score>? Scores { get; set; }

    public DbSet<ScoreBoard>? ScoreBoards { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        new GameConfiguration().Configure(modelBuilder.Entity<Game>());
        new PlayerConfiguration().Configure(modelBuilder.Entity<Player>());
        new ScoreConfiguration().Configure(modelBuilder.Entity<Score>());
        new ScoreBoardConfiguration().Configure(modelBuilder.Entity<ScoreBoard>());
    }
}
