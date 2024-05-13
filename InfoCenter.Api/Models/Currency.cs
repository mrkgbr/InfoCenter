namespace InfoCenter.Api.Models;

public class Currency
{
    public int Id { get; set; }

    public string Name { get; set; } = string.Empty;
    public string? Description { get; set; }
    public bool IsActive { get; set; } = true;

    public ICollection<ArticleDetail> ArticleDetails { get; } = new List<ArticleDetail>();
}