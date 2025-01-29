using System.Linq.Expressions;
using System.Reflection;
using Core.BurialPlans.Entities;
using Core.Clients.Entities;
using Core.Interfaces;
using Core.Members.Entities;
using Core.Policies.Entities;
using Core.Premiums.Entities;
using Core.Shared.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data;

public class DataContext(DbContextOptions<DataContext> options) : DbContext(options)
{
    public DbSet<Addon> Addons { get; set; }
    public DbSet<AppStatus> AppStatuses { get; set; }
    public DbSet<Benefit> Benefits { get; set; }
    public DbSet<BenefitType> BenefitTypes { get; set; }
    public DbSet<BurialPlanAddon> BurialPlanAddons { get; set; }
    public DbSet<Ethnicity> Ethnicities { get; set; }
    public DbSet<ExtendedMemberProduct> ExtendedMemberProducts { get; set; }
    public DbSet<Gender> Genders { get; set; }
    public DbSet<IdentityType> IdentityTypes { get; set; }
    public DbSet<MaritalStatus> MaritalStatuses { get; set; }
    public DbSet<PolicyType> PolicyTypes { get; set; }
    public DbSet<Province> Provinces { get; set; }
    public DbSet<Relationship> Relationships { get; set; }
    public DbSet<Title> Titles { get; set; }
    public DbSet<Address> Addresses { get; set; }
    public DbSet<AgeRangePremium> AgeRangePremia { get; set; }
    public DbSet<Branch> Branches { get; set; }
    public DbSet<BurialPlan> BurialPlans { get; set; }
    public DbSet<BurialScheme> BurialSchemes { get; set; }
    public DbSet<BurialSociety> BurialSocieties { get; set; }
    public DbSet<Client> Clients { get; set; }
    public DbSet<Member> Members { get; set; }
    public DbSet<Policy> Policies { get; set; }
    public DbSet<PolicyStatusHistory> PolicyStatusHistories { get; set; }
    public DbSet<PremiumPlan> PremiumPlans { get; set; }



    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        foreach (var entityType in modelBuilder.Model.GetEntityTypes())
        {
            if (typeof(ISoftDelete).IsAssignableFrom(entityType.ClrType))
            {
                var parameter = Expression.Parameter(entityType.ClrType, "e");
                var property = Expression.Property(parameter, "IsDeleted");
                var negation = Expression.Not(property);
                var lambda = Expression.Lambda(negation, parameter);

                modelBuilder.Entity(entityType.ClrType).HasQueryFilter(lambda);
            }
        }

        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}
