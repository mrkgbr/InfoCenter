using InfoCenter.Api.DTOs.ArticleDetail;
using InfoCenter.Api.Models;

namespace InfoCenter.Api.Mappers;

public static class ArticleDetailMappers
{
    public static ArticleDetailDTO ToDTO(this ArticleDetail articleDetailModel)
    {
        return new ArticleDetailDTO
        {
            Id = articleDetailModel.Id,
            Price = articleDetailModel.Price,
            IsActive = articleDetailModel.IsActive,
            ArticleId = articleDetailModel.ArticleId,
            CurrencyId = articleDetailModel.CurrencyId,
            ContractId = articleDetailModel.ContractId
        };
    }

    public static ArticleDetail ToModelFromCreateDTO(this CreateArticleDetailDTO articleDetailDTO)
    {
        return new ArticleDetail
        {
            Price = articleDetailDTO.Price,
            ArticleId = articleDetailDTO.ArticleId,
            CurrencyId = articleDetailDTO.CurrencyId,
            ContractId = articleDetailDTO.ContractId
        };
    }
}