using Core.Policies.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Config.DatabaseConfig;

public class PolicyStatusHistoryConfiguration : IEntityTypeConfiguration<PolicyStatusHistory>
{
    public void Configure(EntityTypeBuilder<PolicyStatusHistory> builder)
    {
        builder.Property(x => x.Status).HasMaxLength(20);

        builder.HasOne(static x => x.Policy)
               .WithMany()
               .HasForeignKey(x => x.PolicyId)
               .OnDelete(DeleteBehavior.NoAction);
    }
}
