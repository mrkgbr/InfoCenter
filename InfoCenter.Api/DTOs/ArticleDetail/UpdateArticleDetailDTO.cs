using System.ComponentModel.DataAnnotations;

namespace InfoCenter.Api.DTOs.ArticleDetail;

public record UpdateArticleDetailDTO
(
    [Required]
    int Id,

    [Required]
    decimal Price,

    [Required]
    int ArticleId,

    [Required]
    int ContractId,

    [Required]
    int CurrencyId,

    [Required]
    bool IsActive
);