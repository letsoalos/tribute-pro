namespace Core.Dtos;

public class DashboardSummaryDto
{
    public int TotalClients { get; set; }
    public int ActivePolicies { get; set; }
    public int TotalBurialPlans { get; set; }
    public int RecentRegistrations { get; set; }
    public Dictionary<string, int> BranchDistribution { get; set; } = new();
    public Dictionary<string, int> PolicyStatusDistribution { get; set; } = new();
}
