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
            ArticleId = articleDetailModel.ArticleId,
            CurrencyId = articleDetailModel.CurrencyId,
            ContractId = articleDetailModel.ContractId,
            IsActive = articleDetailModel.IsActive
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

    public static ArticleDetailSummaryDTO ToSummaryDTO(this ArticleDetail articleDetailModel)
    {
        return new ArticleDetailSummaryDTO
        {
            Id = articleDetailModel.Id,
            Price = articleDetailModel.Price,
            ArticleSapNumber = articleDetailModel.Article.SapNumber,
            ArticleName = articleDetailModel.Article.Name,
            Contract = articleDetailModel.Contract.Name,
            Currency = articleDetailModel.Currency.Name,
            IsActive = articleDetailModel.IsActive
        };
    }
}