using Core.Shared.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Config.DatabaseConfig;

public class BurialSocietyConfiguration : IEntityTypeConfiguration<BurialSociety>
{
    public void Configure(EntityTypeBuilder<BurialSociety> builder)
    {
        builder.Property(x => x.Name).HasMaxLength(100);
        builder.Property(x => x.ContactPerson).HasMaxLength(100);
        builder.Property(x => x.PhoneNumber).HasMaxLength(20);
        builder.Property(x => x.Email).HasMaxLength(100);
    }
}
