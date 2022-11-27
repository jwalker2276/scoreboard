using Infrastructure.CustomModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.EntityConfigurations;

internal class BlackListWordsConfiguration : IEntityTypeConfiguration<BlackListWord>
{
    public void Configure(EntityTypeBuilder<BlackListWord> builder)
    {
        builder.ToTable("BlackListWords");

        builder.Property(n => n.NotAllowedWordOrCharacters)
            .IsRequired()
            .HasMaxLength(256);
    }
}
