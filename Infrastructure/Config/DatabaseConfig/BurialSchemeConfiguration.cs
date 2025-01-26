using Core.BurialPlans.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Config.DatabaseConfig;

public class BurialSchemeConfiguration : IEntityTypeConfiguration<BurialScheme>
{
    public void Configure(EntityTypeBuilder<BurialScheme> builder)
    {
        builder.Property(x => x.Name).HasMaxLength(100);
        builder.Property(x => x.Description).HasMaxLength(20);
    }
}
