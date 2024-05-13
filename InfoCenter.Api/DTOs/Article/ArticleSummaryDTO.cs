namespace InfoCenter.Api;

public class ArticleSummaryDTO
{
    public int Id { get; set; }
    public string SapNumber { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public string? Description { get; set; }
    public bool IsActive { get; set; }
    public string Unit { get; set; } = string.Empty;
}
