using InfoCenter.Api.DTOs.Article;
using InfoCenter.Api.Helpers;
using InfoCenter.Api.Models;

namespace InfoCenter.Api.Interfaces
{
    public interface IArticleRepository
    {
        Task<List<Article>> GetAllAsync(QueryObject query);
        Task<Article?> GetByIdAsync(int id);
        Task<Article?> GetByIdSummaryAsync(int id);
        Task<Article> CreateAsync(Article articleModel);
        Task<Article?> UpdateAsync(int id, UpdateArticleDTO articleModel);
        Task<Article?> DeleteAsync(int id);
        Task<bool> HasUnitReferenceAsync(int id);
        Task<bool> ArticleExistAsync(int id);
    }
}