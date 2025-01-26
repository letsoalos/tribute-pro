using Core.Premiums.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Config.DatabaseConfig;

public class AgeRangePremiumConfiguration : IEntityTypeConfiguration<AgeRangePremium>
{
    public void Configure(EntityTypeBuilder<AgeRangePremium> builder)
    {
        builder.Property(x => x.MonthlyPremium).HasColumnType("decimal(18,2)");

        builder.HasOne(x => x.PremiumPlan)
               .WithMany()
               .HasForeignKey(x => x.PremiumPlanId)
               .OnDelete(DeleteBehavior.NoAction);
    }
}
