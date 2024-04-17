using InfoCenter.Api.DTOs.Article;
using InfoCenter.Api.Models;

namespace InfoCenter.Api.Interfaces
{
    public interface IArticleRepository
    {
        Task<List<Article>> GetAllAsync();
        Task<Article?> GetByIdAsync(int id);
        Task<Article> CreateAsync(Article articleModel);
        Task<Article?> UpdateAsync(int id, UpdateArticleDTO articleModel);
        Task<Article?> DeleteAsync(int id);
    }
}