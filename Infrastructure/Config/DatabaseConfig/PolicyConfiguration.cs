using Core.Policies.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Config.DatabaseConfig;

public class PolicyConfiguration : IEntityTypeConfiguration<Policy>
{
       public void Configure(EntityTypeBuilder<Policy> builder)
       {
              builder.Property(x => x.PolicyNumber).HasMaxLength(100);

              builder.HasOne(x => x.Client)
                     .WithMany()
                     .HasForeignKey(x => x.ClientId)
                     .OnDelete(DeleteBehavior.NoAction);
              builder.HasOne(x => x.PremiumPlan)
                     .WithMany()
                     .HasForeignKey(x => x.PremiumPlanId)
                     .OnDelete(DeleteBehavior.NoAction);
              builder.HasOne(x => x.CurrentStatus)
                     .WithMany()
                     .HasForeignKey(x => x.CurrentStatusId)
                     .OnDelete(DeleteBehavior.NoAction);
              builder.HasOne(x => x.PolicyType)
                     .WithMany()
                     .HasForeignKey(x => x.PolicyTypeCode)
                     .HasPrincipalKey(pt => pt.PolicyTypeCode)
                     .OnDelete(DeleteBehavior.NoAction);
       }
}
