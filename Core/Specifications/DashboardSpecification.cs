using Core.Clients.Entities;

namespace Core.Specifications;

public class DashboardSpecification : BaseSpecification<Client>
{
    public DashboardSpecification() : base()
    {
        AddOrderByDescending(c => c.DateJoined);
        AddDashboardIncludes();
        ApplyPaging(0, 10); // Get top 10 recent
    }

    private void AddDashboardIncludes()
    {
        AddInclude(c => c.Branch);
        AddInclude(c => c.BurialSociety!);
        AddInclude(c => c.Gender);
        AddInclude(c => c.MaritalStatus);
    }

    public class DemographicSpecification : BaseSpecification<Client>
    {
        public DemographicSpecification() : base()
        {
            AddInclude(c => c.Gender);
            AddInclude(c => c.MaritalStatus);
            AddInclude(c => c.Branch);
        }
    }
}
