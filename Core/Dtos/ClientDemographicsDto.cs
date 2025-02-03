namespace Core.Dtos;

public class ClientDemographicsDto
{
    public Dictionary<string, int> GenderDistribution { get; set; } = new();
    public Dictionary<string, int> MaritalStatusDistribution { get; set; } = new();
    public Dictionary<string, int> BranchDistribution { get; set; } = new();
    public double AverageAge { get; set; }
}
