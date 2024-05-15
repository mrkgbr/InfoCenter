using InfoCenter.Api.DTOs.ArticleDetail;
using InfoCenter.Api.Models;

namespace InfoCenter.Api.Interfaces;

public interface IArticleDetailRepository
{
    Task<ArticleDetail> CreateAsync(ArticleDetail articleDetailModel);
    Task<ArticleDetail?> DeleteAsync(int id);
    Task<List<ArticleDetail>> GetAllAsync();
    Task<ArticleDetail?> GetByIdAsync(int id);
    Task<ArticleDetail?> GetByIdSummary(int id);
    Task<bool> HasArticleReference(int id);
    Task<bool> HasCurrencyReference(int id);
    Task<bool> HasContractReference(int id);
    Task<ArticleDetail?> UpdateAsync(UpdateArticleDetailDTO updateArticleDetailDTO);
}