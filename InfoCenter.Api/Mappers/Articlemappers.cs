using InfoCenter.Api.DTOs.Article;
using InfoCenter.Api.Models;

namespace InfoCenter.Api.Mappers
{
    public static class ArticleMappers
    {
        public static ArticleDTO ToDTO(this Article articleModel)
        {
            return new ArticleDTO
            {
                Id = articleModel.Id,
                SapNumber = articleModel.SapNumber,
                Name = articleModel.Name,
                Description = articleModel.Description,
                IsActive = articleModel.IsActive,
                UnitId = articleModel.UnitId
            };
        }

        public static Article ToModelFromCreateDTO(this CreateArticleDTO articleDTO, int unitId)
        {
            return new Article
            {
                SapNumber = articleDTO.SapNumber,
                Name = articleDTO.Name,
                Description = articleDTO.Description,
                UnitId = unitId
            };
        }
    }
}