using System.Text.Json;
using Core.BurialPlans.Entities;
using Core.Clients.Entities;
using Core.Members.Entities;
using Core.Policies.Entities;
using Core.Premiums.Entities;
using Core.Shared.Entities;

namespace Infrastructure.Data;

public class DataContextSeed
{
    public static async Task SeedAsync(DataContext context)
    {
        if (!context.Genders.Any())
        {
            var gendersData = await File.ReadAllTextAsync("../Infrastructure/Data/SeedData/genders.json");

            var genders = JsonSerializer.Deserialize<List<Gender>>(gendersData);

            if (genders == null) return;

            context.Genders.AddRange(genders);

            await context.SaveChangesAsync();
        }

        if (!context.Titles.Any())
        {
            var titlesData = await File.ReadAllTextAsync("../Infrastructure/Data/SeedData/titles.json");

            var titles = JsonSerializer.Deserialize<List<Title>>(titlesData);

            if (titles == null) return;

            context.Titles.AddRange(titles);

            await context.SaveChangesAsync();
        }

        if (!context.MaritalStatuses.Any())
        {
            var maritalStatusesData = await File.ReadAllTextAsync("../Infrastructure/Data/SeedData/maritalStatuses.json");

            var maritalStatuses = JsonSerializer.Deserialize<List<MaritalStatus>>(maritalStatusesData);

            if (maritalStatuses == null) return;

            context.MaritalStatuses.AddRange(maritalStatuses);

            await context.SaveChangesAsync();
        }

        if (!context.Relationships.Any())
        {
            var relationshipsData = await File.ReadAllTextAsync("../Infrastructure/Data/SeedData/relationship.json");

            var relationships = JsonSerializer.Deserialize<List<Relationship>>(relationshipsData);

            if (relationships == null) return;

            context.Relationships.AddRange(relationships);

            await context.SaveChangesAsync();
        }

        if (!context.Ethnicities.Any())
        {
            var ethnicitiesData = await File.ReadAllTextAsync("../Infrastructure/Data/SeedData/ethnicities.json");

            var ethnicities = JsonSerializer.Deserialize<List<Ethnicity>>(ethnicitiesData);

            if (ethnicities == null) return;

            context.Ethnicities.AddRange(ethnicities);

            await context.SaveChangesAsync();
        }

        if (!context.IdentityTypes.Any())
        {
            var identityTypesData = await File.ReadAllTextAsync("../Infrastructure/Data/SeedData/identityTypes.json");

            var identityTypes = JsonSerializer.Deserialize<List<IdentityType>>(identityTypesData);

            if (identityTypes == null) return;

            context.IdentityTypes.AddRange(identityTypes);

            await context.SaveChangesAsync();
        }

        if (!context.Provinces.Any())
        {
            var provincesData = await File.ReadAllTextAsync("../Infrastructure/Data/SeedData/pronvinces.json");

            var provinces = JsonSerializer.Deserialize<List<Province>>(provincesData);

            if (provinces == null) return;

            context.Provinces.AddRange(provinces);

            await context.SaveChangesAsync();
        }

        if (!context.Addresses.Any())
        {
            var addressesData = await File.ReadAllTextAsync("../Infrastructure/Data/SeedData/addresses.json");

            var addresses = JsonSerializer.Deserialize<List<Address>>(addressesData);

            if (addresses == null) return;

            context.Addresses.AddRange(addresses);

            await context.SaveChangesAsync();
        }

        if (!context.Branches.Any())
        {
            var branchesData = await File.ReadAllTextAsync("../Infrastructure/Data/SeedData/branches.json");

            var branches = JsonSerializer.Deserialize<List<Branch>>(branchesData);

            if (branches == null) return;

            context.Branches.AddRange(branches);

            await context.SaveChangesAsync();
        }

        if (!context.Addons.Any())
        {
            var addonsData = await File.ReadAllTextAsync("../Infrastructure/Data/SeedData/addons.json");

            var addons = JsonSerializer.Deserialize<List<Addon>>(addonsData);

            if (addons == null) return;

            context.Addons.AddRange(addons);

            await context.SaveChangesAsync();
        }

        if (!context.BenefitTypes.Any())
        {
            var benefitTypesData = await File.ReadAllTextAsync("../Infrastructure/Data/SeedData/benefittypes.json");

            var benefitTypes = JsonSerializer.Deserialize<List<BenefitType>>(benefitTypesData);

            if (benefitTypes == null) return;

            context.BenefitTypes.AddRange(benefitTypes);

            await context.SaveChangesAsync();
        }

        if (!context.BurialSchemes.Any())
        {
            var burialSchemesData = await File.ReadAllTextAsync("../Infrastructure/Data/SeedData/burialSchemes.json");

            var burialSchemes = JsonSerializer.Deserialize<List<BurialScheme>>(burialSchemesData);

            if (burialSchemes == null) return;

            context.BurialSchemes.AddRange(burialSchemes);

            await context.SaveChangesAsync();
        }

        if (!context.BurialPlans.Any())
        {
            var burialPlansData = await File.ReadAllTextAsync("../Infrastructure/Data/SeedData/burialplans.json");

            var burialPlans = JsonSerializer.Deserialize<List<BurialPlan>>(burialPlansData);

            if (burialPlans == null) return;

            context.BurialPlans.AddRange(burialPlans);

            await context.SaveChangesAsync();
        }

        if (!context.ExtendedMemberProducts.Any())
        {
            var extendedMemberProductsData = await File.ReadAllTextAsync("../Infrastructure/Data/SeedData/extendedmemberproducts.json");

            var extendedMemberProducts = JsonSerializer.Deserialize<List<ExtendedMemberProduct>>(extendedMemberProductsData);

            if (extendedMemberProducts == null) return;

            context.ExtendedMemberProducts.AddRange(extendedMemberProducts);

            await context.SaveChangesAsync();
        }

        if (!context.BurialPlanAddons.Any())
        {
            var burialPlanAddonsData = await File.ReadAllTextAsync("../Infrastructure/Data/SeedData/burialplanaddons.json");

            var burialPlanAddons = JsonSerializer.Deserialize<List<BurialPlanAddon>>(burialPlanAddonsData);

            if (burialPlanAddons == null) return;

            context.BurialPlanAddons.AddRange(burialPlanAddons);

            await context.SaveChangesAsync();
        }

        if (!context.Benefits.Any())
        {
            var benefitsData = await File.ReadAllTextAsync("../Infrastructure/Data/SeedData/benefits.json");

            var benefits = JsonSerializer.Deserialize<List<Benefit>>(benefitsData);

            if (benefits == null) return;

            context.Benefits.AddRange(benefits);

            await context.SaveChangesAsync();
        }

        if (!context.BurialSocieties.Any())
        {
            var burialSocietiesData = await File.ReadAllTextAsync("../Infrastructure/Data/SeedData/burialsocieties.json");

            var burialSocieties = JsonSerializer.Deserialize<List<BurialSociety>>(burialSocietiesData);

            if (burialSocieties == null) return;

            context.BurialSocieties.AddRange(burialSocieties);

            await context.SaveChangesAsync();
        }

        if (!context.PremiumPlans.Any())
        {
            var premiumPlansData = await File.ReadAllTextAsync("../Infrastructure/Data/SeedData/premiumplans.json");

            var premiumPlans = JsonSerializer.Deserialize<List<PremiumPlan>>(premiumPlansData);

            if (premiumPlans == null) return;

            context.PremiumPlans.AddRange(premiumPlans);

            await context.SaveChangesAsync();
        }

        if (!context.AgeRangePremia.Any())
        {
            var ageRangePremiaData = await File.ReadAllTextAsync("../Infrastructure/Data/SeedData/agerangepremiums.json");

            var ageRangePremia = JsonSerializer.Deserialize<List<AgeRangePremium>>(ageRangePremiaData);

            if (ageRangePremia == null) return;

            context.AgeRangePremia.AddRange(ageRangePremia);

            await context.SaveChangesAsync();
        }

        if (!context.PolicyTypes.Any())
        {
            var policyTypesData = await File.ReadAllTextAsync("../Infrastructure/Data/SeedData/policytypes.json");

            var policyTypes = JsonSerializer.Deserialize<List<PolicyType>>(policyTypesData);

            if (policyTypes == null) return;

            context.PolicyTypes.AddRange(policyTypes);

            await context.SaveChangesAsync();
        }

        if (!context.AppStatuses.Any())
        {
            var appStatusesData = await File.ReadAllTextAsync("../Infrastructure/Data/SeedData/appstatus.json");

            var appStatuses = JsonSerializer.Deserialize<List<AppStatus>>(appStatusesData);

            if (appStatuses == null) return;

            context.AppStatuses.AddRange(appStatuses);

            await context.SaveChangesAsync();
        }

        if (!context.Clients.Any())
        {
            var clientsData = await File.ReadAllTextAsync("../Infrastructure/Data/SeedData/clients.json");

            var clients = JsonSerializer.Deserialize<List<Client>>(clientsData);

            if (clients == null) return;

            context.Clients.AddRange(clients);

            await context.SaveChangesAsync();
        }

        if (!context.Policies.Any())
        {
            var policiesData = await File.ReadAllTextAsync("../Infrastructure/Data/SeedData/policies.json");

            var policies = JsonSerializer.Deserialize<List<Policy>>(policiesData);

            if (policies == null) return;

            context.Policies.AddRange(policies);

            await context.SaveChangesAsync();
        }

        if (!context.PolicyStatusHistories.Any())
        {
            var policyStatusHistoriesData = await File.ReadAllTextAsync("../Infrastructure/Data/SeedData/policystatushistory.json");

            var policyStatusHistories = JsonSerializer.Deserialize<List<PolicyStatusHistory>>(policyStatusHistoriesData);

            if (policyStatusHistories == null) return;

            context.PolicyStatusHistories.AddRange(policyStatusHistories);

            await context.SaveChangesAsync();
        }

        if (!context.Members.Any())
        {
            var membersData = await File.ReadAllTextAsync("../Infrastructure/Data/SeedData/members.json");

            var members = JsonSerializer.Deserialize<List<Member>>(membersData);

            if (members == null) return;

            context.Members.AddRange(members);

            await context.SaveChangesAsync();
        }

    }

}
