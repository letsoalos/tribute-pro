using Core.BurialPlans.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Config.DatabaseConfig;

public class BurialPlanConfiguration : IEntityTypeConfiguration<BurialPlan>
{
    public void Configure(EntityTypeBuilder<BurialPlan> builder)
    {
        builder.Property(x => x.Name).HasMaxLength(100);
        builder.Property(x => x.Description).HasMaxLength(20);
        builder.Property(x => x.BasePremium).HasColumnType("decimal(18,2)");

        builder.HasOne(x => x.BurialScheme)
               .WithMany()
               .HasForeignKey(x => x.BurialSchemeId)
               .OnDelete(DeleteBehavior.NoAction);
    }
}
