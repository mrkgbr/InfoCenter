using InfoCenter.Api.DTOs.Article;
using InfoCenter.Api.Models;

namespace InfoCenter.Api.Mappers;

public static class ArticleMappers
{
    public static ArticleDTO ToDTO(this Article articleModel)
    {
        return new ArticleDTO
        (
            articleModel.Id,
            articleModel.SapNumber,
            articleModel.Name,
            articleModel.Description,
            articleModel.IsActive,
            articleModel.UnitId
        );
    }

    public static Article ToModelFromCreateDTO(this CreateArticleDTO articleDTO)
    {
        return new Article
        {
            SapNumber = articleDTO.SapNumber,
            Name = articleDTO.Name,
            Description = articleDTO.Description,
            UnitId = articleDTO.UnitId
        };
    }

    public static ArticleSummaryDTO ToSummaryDTO(this Article articleModel)
    {
        return new ArticleSummaryDTO
        (
            articleModel.Id,
            articleModel.SapNumber,
            articleModel.Name,
            articleModel.Description,
            articleModel.IsActive,
            articleModel.Unit.Name
        );
    }
}
