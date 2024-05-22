namespace InfoCenter.Api.DTOs.ArticleDetail;

public record ArticleDetailDTO
(
    int Id,
    decimal Price,
    int ArticleId,
    int CurrencyId,
    int ContractId,
    bool IsActive
);