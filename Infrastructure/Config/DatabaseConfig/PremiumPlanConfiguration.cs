using Core.Premiums.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Config.DatabaseConfig;

public class PremiumPlanConfiguration : IEntityTypeConfiguration<PremiumPlan>
{
    public void Configure(EntityTypeBuilder<PremiumPlan> builder)
    {
        builder.Property(x => x.Name).HasMaxLength(100);
        builder.Property(x => x.Description).HasMaxLength(100);
        builder.Property(x => x.PlanType).HasMaxLength(20);
        builder.Property(x => x.BasePremium).HasColumnType("decimal(18,2)");
    }
}
