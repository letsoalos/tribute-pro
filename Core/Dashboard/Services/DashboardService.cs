using AutoMapper;
using Core.Clients.Entities;
using Core.Dtos;
using Core.Interfaces;
using Core.Policies.Entities;
using Core.Specifications;
using static Core.Specifications.DashboardSpecification;

namespace Core.Dashboard.Services;

public class DashboardService : IDashboardService
{
    private readonly IGenericRepository<Client> _clientRepo;
    private readonly IGenericRepository<Policy> _policyRepo;
    private readonly IMapper _mapper;

    public DashboardService(
        IGenericRepository<Client> clientRepo,
        IGenericRepository<Policy> policyRepo,
        IMapper mapper)
    {
        _clientRepo = clientRepo;
        _policyRepo = policyRepo;
        _mapper = mapper;
    }

    public async Task<DashboardSummaryDto> GetDashboardSummary()
    {
        var summary = new DashboardSummaryDto
        {
            TotalClients = await _clientRepo.CountAsync(),
            ActivePolicies = await _policyRepo.CountAsync(new PolicyStatusSpecification(true)),
            RecentRegistrations = await _clientRepo.CountAsync(new RecentClientSpecification())
        };

        // Branch distribution
        var clients = await _clientRepo.ListAsync(new DemographicSpecification());
        summary.BranchDistribution = clients
            .GroupBy(c => c.Branch.Name)
            .ToDictionary(g => g.Key, g => g.Count());

        return summary;
    }

    public async Task<ClientDemographicsDto> GetClientDemographics()
    {
        var clients = await _clientRepo.ListAsync(new DemographicSpecification());

        return new ClientDemographicsDto
        {
            GenderDistribution = clients
                .GroupBy(c => c.Gender.Name)
                .ToDictionary(g => g.Key, g => g.Count()),

            MaritalStatusDistribution = clients
                .GroupBy(c => c.MaritalStatus.Name)
                .ToDictionary(g => g.Key, g => g.Count()),

            AverageAge = clients.Average(c => DateTime.Today.Year - c.DateOfBirth.Year),

            BranchDistribution = clients
                .GroupBy(c => c.Branch.Name)
                .ToDictionary(g => g.Key, g => g.Count())
        };
    }

    public async Task<IEnumerable<DashboardRecentClientDto>> GetRecentClients()
    {
        var spec = new DashboardSpecification();
        var clients = await _clientRepo.ListAsync(spec);

        return clients.Select(c => new DashboardRecentClientDto
        {
            FullName = $"{c.FirstName} {c.LastName}",
            DateJoined = c.DateJoined,
            Branch = c.Branch.Name,
            BurialSociety = c.BurialSociety?.Name ?? "N/A"
        });
    }
}

// Supporting Specifications
public class PolicyStatusSpecification : BaseSpecification<Policy>
{
    public PolicyStatusSpecification(bool isActive)
        : base(p => p.IsActive == isActive) { }
}

public class RecentClientSpecification : BaseSpecification<Client>
{
    public RecentClientSpecification()
        : base(c => c.DateJoined >= DateTime.UtcNow.AddDays(-7))
    {
        AddOrderByDescending(c => c.DateJoined);
    }
}

