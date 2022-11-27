using Infrastructure.CustomModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.EntityConfigurations;

internal class PlayerNameBlackListConfiguration : IEntityTypeConfiguration<PlayerNameBlackList>
{
    public void Configure(EntityTypeBuilder<PlayerNameBlackList> builder)
    {
        builder.ToTable("PlayerNameBlackList");

        builder.Property(n => n.NotAllowedWordOrCharacters)
            .IsRequired()
            .HasMaxLength(256);
    }
}
