using Core.Dtos;

namespace Core.Interfaces;

public interface IDashboardService
{
    Task<DashboardSummaryDto> GetDashboardSummary();
    Task<ClientDemographicsDto> GetClientDemographics();
    Task<IEnumerable<DashboardRecentClientDto>> GetRecentClients();
}
