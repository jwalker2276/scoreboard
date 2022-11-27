using Domain.GameModels.Entities;
using Domain.PlayerModels.Entities;
using Domain.ScoreBoardModels.Entities;
using Domain.ScoreModels.Entities;
using Infrastructure.CustomModels;
using Infrastructure.EntityConfigurations;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence;

public sealed class DatabaseContext : DbContext
{
    public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options) { }

    internal DbSet<Game>? Games { get; set; }

    internal DbSet<Player>? Players { get; set; }

    internal DbSet<Score>? Scores { get; set; }

    internal DbSet<ScoreBoard>? ScoreBoards { get; set; }

    internal DbSet<PlayerNameBlackList>? PlayerNameBlackLists { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        new GameConfiguration().Configure(modelBuilder.Entity<Game>());
        new PlayerConfiguration().Configure(modelBuilder.Entity<Player>());
        new ScoreConfiguration().Configure(modelBuilder.Entity<Score>());
        new ScoreBoardConfiguration().Configure(modelBuilder.Entity<ScoreBoard>());
        new PlayerNameBlackListConfiguration().Configure(modelBuilder.Entity<PlayerNameBlackList>());
    }
}
