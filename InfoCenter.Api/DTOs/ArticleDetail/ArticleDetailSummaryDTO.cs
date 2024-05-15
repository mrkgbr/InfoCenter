namespace InfoCenter.Api.DTOs.ArticleDetail;

public class ArticleDetailSummaryDTO
{
    public int Id { get; set; }
    public decimal Price { get; set; }
    public bool IsActive { get; set; }
    public string ArticleSapNumber { get; set; } = string.Empty;
    public string ArticleName { get; set; } = string.Empty;
    public string Contract { get; set; } = string.Empty;
    public string Currency { get; set; } = string.Empty;
}