namespace InfoCenter.Api.Models;

public class Article
{
    public int Id { get; set; }

    public string SapNumber { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public string? Description { get; set; }
    public bool IsActive { get; set; } = true;

    public int UnitId { get; set; }
    public Unit Unit { get; set; } = null!;

    public ICollection<ArticleDetail> ArticleDetails { get; } = new List<ArticleDetail>();
}