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
            .HasColumnOrder(0)
            .IsRequired();

        builder.Property(x => x.Value)
            .HasColumnOrder(1)
            .IsRequired();

        builder.Property(x => x.GameId)
            .HasColumnOrder(2)
            .IsRequired();

        builder.Property(x => x.PlayerId)
            .HasColumnOrder(3)
            .IsRequired();

        builder.Property(x => x.CreationDate)
            .HasColumnOrder(4)
            .IsRequired();

        builder.Property(x => x.CreatedBy)
            .IsRequired()
            .HasColumnOrder(5)
            .HasMaxLength(256);
    }
}
