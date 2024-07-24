namespace InfoCenter.Api;

public class ArticleSummaryDTO
{
    public int Id { get; set; }
    public required string SapNumber { get; set; }
    public required string Name { get; set; }
    public string? Description { get; set; }
    public bool IsActive { get; set; }
    public required string Unit { get; set; }
}