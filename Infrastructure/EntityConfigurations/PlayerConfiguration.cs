using Domain.PlayerModels.Enitites;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.EntityConfigurations;

internal class PlayerConfiguration : IEntityTypeConfiguration<Player>
{
    public void Configure(EntityTypeBuilder<Player> builder)
    {
        builder.ToTable("Players");

        builder.Property(x => x.Id)
            .IsRequired();

        builder.Property(x => x.DefaultPlayerName)
            .IsRequired()
            .HasMaxLength(256);

        builder.Property(x => x.PreferredPlayerName)
            .HasMaxLength(256);

        builder.Property(x => x.IsPlayerNameApproved)
            .IsRequired()
            .HasDefaultValue(false);

        builder.Property(x => x.CreationDate)
            .IsRequired();

        builder.Property(x => x.CreatedBy)
            .IsRequired()
            .HasMaxLength(256);
    }
}
