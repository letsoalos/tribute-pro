using Core.BurialPlans.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Config.DatabaseConfig;

public class ExtendedMemberProductConfiguration : IEntityTypeConfiguration<ExtendedMemberProduct>
{
    public void Configure(EntityTypeBuilder<ExtendedMemberProduct> builder)
    {
        builder.Property(x => x.Name).HasMaxLength(100);
        builder.Property(x => x.Description).HasMaxLength(100);
        builder.Property(x => x.Name).HasMaxLength(100);
        builder.Property(x => x.EligibilityCriteria).HasMaxLength(255);
        builder.Property(x => x.Cost).HasColumnType("decimal(18,2)");

        builder.HasOne(x => x.BurialPlan)
               .WithMany()
               .HasForeignKey(x => x.BurialPlanId)
               .OnDelete(DeleteBehavior.NoAction);
    }
}
