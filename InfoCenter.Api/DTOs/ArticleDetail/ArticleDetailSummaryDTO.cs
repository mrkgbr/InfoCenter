namespace InfoCenter.Api.DTOs.ArticleDetail;

public record ArticleDetailSummaryDTO
(
    int Id,
    decimal Price,
    string ArticleSapNumber,
    string ArticleName,
    string Currency,
    string Contract,
    bool IsActive
);