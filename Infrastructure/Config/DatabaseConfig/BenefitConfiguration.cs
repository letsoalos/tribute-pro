using Core.BurialPlans.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Config.DatabaseConfig;

public class BenefitConfiguration : IEntityTypeConfiguration<Benefit>
{
    public void Configure(EntityTypeBuilder<Benefit> builder)
    {
        builder.Property(x => x.Name).HasMaxLength(100);
        builder.Property(x => x.Description).HasMaxLength(100);
        builder.Property(x => x.Cost).HasColumnType("decimal(18,2)");

        builder.HasOne(x => x.BurialPlan)
                     .WithMany()
                     .HasForeignKey(x => x.BurialPlanId)
                     .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(x => x.BenefitType)
               .WithMany()
               .HasForeignKey(x => x.BenefitTypeId)
               .OnDelete(DeleteBehavior.Restrict);
    }
}
