using System.ComponentModel.DataAnnotations;

namespace InfoCenter.Api.DTOs.ArticleDetail;

public record CreateArticleDetailDTO
(
    decimal Price,

    [Required]
    int ArticleId,

    [Required]
    int ContractId,

    [Required]
    int CurrencyId
);