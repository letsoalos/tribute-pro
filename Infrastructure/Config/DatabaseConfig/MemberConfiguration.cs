using Core.Members.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Config.DatabaseConfig;

public class MemberConfiguration : IEntityTypeConfiguration<Member>
{
       public void Configure(EntityTypeBuilder<Member> builder)
       {
              builder.Property(x => x.FirstName).HasMaxLength(100);
              builder.Property(x => x.LastName).HasMaxLength(100);

              builder.Property(x => x.IsBeneficiary)
               .IsRequired(false)
               .HasComment("Applicable only for funeral plans with payout benefits");

              builder.HasOne(x => x.Title)
                     .WithMany()
                     .HasForeignKey(x => x.TitleId)
                     .OnDelete(DeleteBehavior.NoAction);
              builder.HasOne(x => x.Relationship)
                     .WithMany()
                     .HasForeignKey(x => x.RelationshipId)
                     .OnDelete(DeleteBehavior.NoAction);
              builder.HasOne(x => x.Gender)
                     .WithMany()
                     .HasForeignKey(x => x.GenderId)
                     .OnDelete(DeleteBehavior.NoAction);
              builder.HasOne(x => x.Client)
                     .WithMany()
                     .HasForeignKey(x => x.ClientId)
                     .OnDelete(DeleteBehavior.NoAction);
       }
}
