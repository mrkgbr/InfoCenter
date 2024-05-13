using InfoCenter.Api.Data;
using InfoCenter.Api.DTOs.ArticleDetail;
using InfoCenter.Api.Interfaces;
using InfoCenter.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace InfoCenter.Api.Repositories;

public class ArticleDetailRepository : IArticleDetailRepository
{
    private readonly InfoCenterContext _context;

    public ArticleDetailRepository(InfoCenterContext context)
    {
        _context = context;
    }

    public async Task<ArticleDetail> CreateAsync(ArticleDetail articleDetailModel)
    {
        await _context.ArticleDetails.AddAsync(articleDetailModel);
        await _context.SaveChangesAsync();

        return articleDetailModel;
    }

    public async Task<ArticleDetail?> DeleteAsync(int id)
    {
        var existingArticleDetail = await _context.ArticleDetails.FindAsync(id);
        if (existingArticleDetail is null)
            return null;

        _context.ArticleDetails.Remove(existingArticleDetail);
        await _context.SaveChangesAsync();

        return existingArticleDetail;
    }

    public async Task<List<ArticleDetail>> GetAllAsync()
    {
        return await _context.ArticleDetails.ToListAsync();
    }

    public async Task<ArticleDetail?> GetByIdAsync(int id)
    {
        return await _context.ArticleDetails.FindAsync(id);
    }

    public async Task<bool> HasArticleReference(int id)
    {
        return await _context.ArticleDetails.AnyAsync(a => a.ArticleId == id);
    }

    public async Task<bool> HasContractReference(int id)
    {
        return await _context.ArticleDetails.AnyAsync(c => c.ContractId == id);
    }

    public async Task<bool> HasCurrencyReference(int id)
    {
        return await _context.ArticleDetails.AnyAsync(c => c.CurrencyId == id);
    }

    public async Task<ArticleDetail?> UpdateAsync(UpdateArticleDetailDTO updateArticleDetailDTO)
    {
        var existingArticleDetail = await _context.ArticleDetails.FindAsync(updateArticleDetailDTO.Id);
        if (existingArticleDetail is null)
            return null;

        existingArticleDetail.Price = updateArticleDetailDTO.Price;
        existingArticleDetail.IsActive = updateArticleDetailDTO.IsActive;
        existingArticleDetail.ArticleId = updateArticleDetailDTO.ArticleId;
        existingArticleDetail.ContractId = updateArticleDetailDTO.ContractId;
        existingArticleDetail.CurrencyId = updateArticleDetailDTO.CurrencyId;

        await _context.SaveChangesAsync();

        return existingArticleDetail;
    }
}
