namespace InfoCenter.Api.DTOs.ArticleDetail;

public class ArticleDetailSummaryDTO
{
    public int Id { get; set; }
    public decimal Price { get; set; }
    public bool IsActive { get; set; }
    public string Article { get; set; } = string.Empty;
    public string Contract { get; set; } = string.Empty;
    public string Currency { get; set; } = string.Empty;
}
