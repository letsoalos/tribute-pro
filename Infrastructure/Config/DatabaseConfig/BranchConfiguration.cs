using Core.Shared.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Config.DatabaseConfig;

public class BranchConfiguration : IEntityTypeConfiguration<Branch>
{
    public void Configure(EntityTypeBuilder<Branch> builder)
    {
        builder.Property(x => x.Name).HasMaxLength(100);
        builder.Property(x => x.PhoneNumber).HasMaxLength(20);
        builder.Property(x => x.Email).HasMaxLength(100);

        builder.HasOne(x => x.Province)
               .WithMany()
               .HasForeignKey(x => x.ProvinceId)
               .OnDelete(DeleteBehavior.NoAction);
        builder.HasOne(x => x.Address)
               .WithMany()
               .HasForeignKey(x => x.AddressId)
               .OnDelete(DeleteBehavior.Cascade);
    }
}
