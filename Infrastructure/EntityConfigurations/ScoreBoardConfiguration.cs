using Domain.ScoreBoardModels.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.EntityConfigurations;

internal class ScoreBoardConfiguration : IEntityTypeConfiguration<ScoreBoard>
{
    public void Configure(EntityTypeBuilder<ScoreBoard> builder)
    {
        builder.ToTable("ScoreBoards");

        builder.Property(x => x.Id)
            .IsRequired();

        builder.Property(x => x.GameId)
            .IsRequired();

        builder.Property(x => x.Name)
            .HasMaxLength(256)
            .IsRequired();

        builder.Property(x => x.MaxNumberOfScores)
            .IsRequired();

        builder.Property(x => x.SortBy)
            .HasColumnType("nvarchar(50)")
            .IsRequired();

        builder.Property(x => x.CreatedBy)
            .IsRequired()
            .HasMaxLength(256); ;
    }
}
