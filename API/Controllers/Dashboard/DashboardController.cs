using Core.Dtos;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers.Dashboard;

public class DashboardController : BaseApiController
{
    private readonly IDashboardService _dashboardService;

    public DashboardController(IDashboardService dashboardService)
    {
        _dashboardService = dashboardService;
    }

    [HttpGet("summary")]
    public async Task<ActionResult<DashboardSummaryDto>> GetSummary()
    {
        return Ok(await _dashboardService.GetDashboardSummary());
    }

    [HttpGet("demographics")]
    public async Task<ActionResult<ClientDemographicsDto>> GetDemographics()
    {
        return Ok(await _dashboardService.GetClientDemographics());
    }

    [HttpGet("recent-clients")]
    public async Task<ActionResult<IEnumerable<DashboardRecentClientDto>>> GetRecentClients()
    {
        return Ok(await _dashboardService.GetRecentClients());
    }
}
