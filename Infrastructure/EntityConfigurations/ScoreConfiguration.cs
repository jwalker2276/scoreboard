using Domain.ScoreModels.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.EntityConfigurations;

internal class ScoreConfiguration : IEntityTypeConfiguration<Score>
{
    public void Configure(EntityTypeBuilder<Score> builder)
    {
        builder.ToTable("Scores");

        builder.Property(x => x.Id)
            .IsRequired();

        builder.Property(x => x.Value)
            .IsRequired();

        builder.Property(x => x.GameId)
            .IsRequired();

        builder.Property(x => x.PlayerId)
            .IsRequired();

        builder.Property(x => x.CreationDate)
            .IsRequired();

        builder.Property(x => x.CreatedBy)
            .IsRequired()
            .HasMaxLength(256);
    }
}
