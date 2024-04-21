using InfoCenter.Api.DTOs.ArticleDetail;
using InfoCenter.Api.Models;

namespace InfoCenter.Api.Interfaces;

public interface IArticleDetailRepository
{
    Task<List<ArticleDetail>> GetAllAsync();
    Task<ArticleDetail?> GetByIdAsync(int id);
    Task<ArticleDetail> CreateAsync(ArticleDetail articleDetailModel);
    Task<ArticleDetail?> UpdateAsync(int id, UpdateArticleDetailDTO updateArticleDetailDTO);
    Task<ArticleDetail?> DeleteAsync(int id);
    Task<bool> HasArticleReference(int id);
    Task<bool> HasCurrencyReference(int id);
    Task<bool> HasContractReference(int id);
}
