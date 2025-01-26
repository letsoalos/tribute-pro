using Core.Shared.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Config.DatabaseConfig;

public class AddressConfiguration : IEntityTypeConfiguration<Address>
{
    public void Configure(EntityTypeBuilder<Address> builder)
    {
        builder.Property(x => x.StreetName).HasMaxLength(100);
        builder.Property(x => x.Suburb).HasMaxLength(50);
        builder.Property(x => x.City).HasMaxLength(50);
        builder.Property(x => x.Code).HasMaxLength(20);
    }
}
