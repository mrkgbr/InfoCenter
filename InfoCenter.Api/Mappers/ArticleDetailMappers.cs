using InfoCenter.Api.DTOs.ArticleDetail;
using InfoCenter.Api.Models;

namespace InfoCenter.Api.Mappers;

public static class ArticleDetailMappers
{
    public static ArticleDetailDTO ToDTO(this ArticleDetail articleDetailModel)
    {
        return new ArticleDetailDTO
        (
            articleDetailModel.Id,
            articleDetailModel.Price,
            articleDetailModel.ArticleId,
            articleDetailModel.CurrencyId,
            articleDetailModel.ContractId,
            articleDetailModel.IsActive
        );
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
        (
            articleDetailModel.Id,
            articleDetailModel.Price,
            articleDetailModel.Article.SapNumber,
            articleDetailModel.Article.Name,
            articleDetailModel.Contract.Name,
            articleDetailModel.Currency.Name,
            articleDetailModel.IsActive
        );
    }
}