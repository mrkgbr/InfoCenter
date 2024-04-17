namespace InfoCenter.Api.Models;

public class Article
{
    public int Id { get; set; }
    public required string SapNumber { get; set; }
    public required string Name { get; set; }
    public string? Description { get; set; }
    public bool IsActive { get; set; }
    public int UnitId { get; set; }
    public Unit? Unit { get; set; }
}
