using Core.BurialPlans.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Config.DatabaseConfig;

public class BurialPlanAddonConfiguration : IEntityTypeConfiguration<BurialPlanAddon>
{
    public void Configure(EntityTypeBuilder<BurialPlanAddon> builder)
    {
        builder.HasOne(x => x.BurialPlan)
               .WithMany()
               .HasForeignKey(x => x.BurialPlanId)
               .OnDelete(DeleteBehavior.NoAction);
        builder.HasOne(x => x.Addon)
               .WithMany()
               .HasForeignKey(x => x.AddonId)
               .OnDelete(DeleteBehavior.NoAction);
    }
}
