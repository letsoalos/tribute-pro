using Core.Clients.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Config.DatabaseConfig;

public class ClientConfiguration : IEntityTypeConfiguration<Client>
{
       public void Configure(EntityTypeBuilder<Client> builder)
       {
              // Property Configuration
              builder.Property(x => x.FirstName).HasMaxLength(100).IsRequired();
              builder.Property(x => x.LastName).HasMaxLength(100).IsRequired();
              builder.Property(x => x.IdentityNumber).HasMaxLength(20);
              builder.Property(x => x.OtherIdentity).HasMaxLength(20);
              builder.Property(x => x.CellPhone).HasMaxLength(20).IsRequired();
              builder.Property(x => x.Email).HasMaxLength(100);

              // Indexing Frequently Queried Properties
              builder.HasIndex(x => x.FirstName).HasDatabaseName("IX_Client_FirstName");
              builder.HasIndex(x => x.LastName).HasDatabaseName("IX_Client_LastName");
              builder.HasIndex(x => x.IdentityNumber).HasDatabaseName("IX_Client_IdentityNumber");
              builder.HasIndex(x => x.CellPhone).HasDatabaseName("IX_Client_CellPhone");
              builder.HasIndex(x => x.Email).HasDatabaseName("IX_Client_Email");
              builder.HasIndex(x => x.DateOfBirth).HasDatabaseName("IX_Client_DateOfBirth");

              // Relationships
              builder.HasOne(x => x.Title)
                     .WithMany()
                     .HasForeignKey(x => x.TitleId)
                     .OnDelete(DeleteBehavior.Restrict);

              builder.HasOne(x => x.Gender)
                     .WithMany()
                     .HasForeignKey(x => x.GenderId)
                     .OnDelete(DeleteBehavior.Restrict);

              builder.HasOne(x => x.MaritalStatus)
                     .WithMany()
                     .HasForeignKey(x => x.MaritalStatusId)
                     .OnDelete(DeleteBehavior.Restrict);

              builder.HasOne(x => x.Ethnicity)
                     .WithMany()
                     .HasForeignKey(x => x.EthnicityId)
                     .OnDelete(DeleteBehavior.Restrict);

              builder.HasOne(x => x.BurialPlan)
                     .WithMany()
                     .HasForeignKey(x => x.BurialPlanId)
                     .OnDelete(DeleteBehavior.Restrict);

              builder.HasOne(x => x.BurialSociety)
                     .WithMany()
                     .HasForeignKey(x => x.BurialSocietyId)
                     .OnDelete(DeleteBehavior.Restrict);

              builder.HasOne(x => x.IdentityType)
                     .WithMany()
                     .HasForeignKey(x => x.IdentityTypeId)
                     .OnDelete(DeleteBehavior.Restrict);

              builder.HasOne(x => x.Branch)
                     .WithMany()
                     .HasForeignKey(x => x.BranchId)
                     .OnDelete(DeleteBehavior.Restrict);
       }
}
