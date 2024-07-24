namespace InfoCenter.Api.DTOs.ArticleDetail;

public class ArticleDetailSummaryDTO
{
    public int Id { get; set; }
    public decimal Price { get; set; }
    public required string ArticleSapNumber { get; set; }
    public required string ArticleName { get; set; }
    public required string Currency { get; set; }
    public required string Contract { get; set; }
    public bool IsActive { get; set; }
}