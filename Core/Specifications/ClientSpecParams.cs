namespace Core.Specifications;

public class ClientSpecParams
{
    private const int MaxPageSize = 50;
    private int _pageSize = 50;
    private List<string> _statuses = new();
    private string? _search;
    private List<string> _burialSocieties = new();
    private List<string> _branches = new();

    public int PageIndex { get; set; } = 1;

    public int PageSize
    {
        get => _pageSize;
        set => _pageSize = Math.Min(value, MaxPageSize);
    }

    public List<string> Statuses
    {
        get => _statuses;
        set => _statuses = ProcessListInput(value);
    }

    public List<string> BurialSocieties
    {
        get => _burialSocieties;
        set => _burialSocieties = ProcessListInput(value);
    }

    public List<string> Branches
    {
        get => _branches;
        set => _branches = ProcessListInput(value);
    }

    public string? Sort { get; set; }

    public string Search
    {
        get => _search ?? string.Empty;
        set => _search = value?.Trim().ToLower();
    }


    private static List<string> ProcessListInput(IEnumerable<string> input)
    {
        return input
            .SelectMany(x => x.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            .Select(s => s.Trim().ToLower())
            .Where(s => !string.IsNullOrEmpty(s))
            .Distinct()
            .ToList();
    }
}
