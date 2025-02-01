using System.Linq.Expressions;
using Core.Clients.Entities;

namespace Core.Specifications;

public class ClientSpecification : BaseSpecification<Client>
{
    public ClientSpecification(int id) : base(x => x.Id == id)
    {
        AddAllIncludes();
    }

    public ClientSpecification(ClientSpecParams specParams)
        : base(BuildFilterCriteria(specParams))
    {
        AddAllIncludes();
        ApplyPaging(specParams.PageSize * (specParams.PageIndex - 1), specParams.PageSize);
        ApplySorting(specParams.Sort!);
    }

    private static Expression<Func<Client, bool>> BuildFilterCriteria(ClientSpecParams specParams)
    {
        var searchTerm = specParams.Search;
        var burialSocieties = specParams.BurialSocieties;
        var branches = specParams.Branches;
        var statuses = specParams.Statuses;

        return x =>
            (string.IsNullOrEmpty(searchTerm) ||
             x.IdentityNumber!.Contains(searchTerm) ||
             x.OtherIdentity!.Contains(searchTerm) ||
             x.FirstName.Contains(searchTerm) ||
             x.LastName.Contains(searchTerm) ||
             x.CellPhone.Contains(searchTerm) ||
             x.DateOfBirth.ToString("yyyy-MM-dd").Contains(searchTerm)) &&
            (burialSocieties.Count == 0 ||
             (x.BurialSociety != null && burialSocieties.Contains(x.BurialSociety.Name))) &&
            (branches.Count == 0 ||
             (x.Branch != null && branches.Contains(x.Branch.Name)));
    }


    private void AddAllIncludes()
    {
        AddInclude(x => x.IdentityType);
        AddInclude(x => x.Title);
        AddInclude(x => x.Ethnicity);
        AddInclude(x => x.BurialPlan!);
        AddInclude(x => x.Gender);
        AddInclude(x => x.MaritalStatus);
        AddInclude(x => x.BurialSociety!);
        AddInclude(x => x.Branch);
    }

    private void ApplySorting(string sort)
    {
        if (!string.IsNullOrEmpty(sort))
        {
            switch (sort.ToLower())
            {
                case "datecreatedasc":
                    AddOrderBy(x => x.DateJoined);
                    break;
                case "datecreateddesc":
                    AddOrderByDescending(x => x.DateJoined);
                    break;
                case "lastname":
                    AddOrderBy(x => x.LastName);
                    break;
                case "lastname_desc":
                    AddOrderByDescending(x => x.LastName);
                    break;
                default:
                    AddOrderBy(x => x.FirstName);
                    break;
            }
        }
        else
        {
            AddOrderBy(x => x.FirstName);
        }
    }
}