using InfoCenter.Api.DTOs.Article;
using InfoCenter.Api.Helpers;
using InfoCenter.Api.Models;

namespace InfoCenter.Api.Interfaces;

public interface IArticleRepository
{
    Task<string?> CheckCreateUniquenessAsync(CreateArticleDTO articleDTO);
    Task<string?> CheckUpdateUniquenessAsync(UpdateArticleDTO articleModel);
    Task<Article> CreateAsync(Article articleModel);
    Task<Article?> DeleteAsync(int id);
    Task<bool> ExistsAsync(int id);
    Task<List<Article>> GetAllAsync(QueryObject query);
    Task<Article?> GetByIdAsync(int id);
    Task<Article?> GetByIdSummaryAsync(int id);
    Task<bool> HasUnitReferenceAsync(int id);
    Task<Article?> UpdateAsync(UpdateArticleDTO articleModel);
}
