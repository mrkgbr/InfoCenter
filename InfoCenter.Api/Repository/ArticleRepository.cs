using InfoCenter.Api.Data;
using InfoCenter.Api.DTOs.Article;
using InfoCenter.Api.Helpers;
using InfoCenter.Api.Interfaces;
using InfoCenter.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace InfoCenter.Api.Repository
{
    public class ArticleRepository : IArticleRepository
    {
        private readonly InfoCenterContext _context;

        public ArticleRepository(InfoCenterContext context)
        {
            _context = context;
        }

        public async Task<bool> ArticleExistAsync(int id)
        {
            return await _context.Articles.AnyAsync(a => a.Id == id);
        }

        public async Task<bool> HasUnitReferenceAsync(int id)
        {
            return await _context.Articles.AnyAsync(article => article.UnitId == id);
        }

        public async Task<Article> CreateAsync(Article articleModel)
        {
            await _context.Articles.AddAsync(articleModel);
            await _context.SaveChangesAsync();

            return articleModel;
        }

        public async Task<Article?> DeleteAsync(int id)
        {
            var existingArticle = await _context.Articles.FindAsync(id);
            if (existingArticle is null)
                return null;

            _context.Remove(existingArticle);
            await _context.SaveChangesAsync();

            return existingArticle;
        }

        public async Task<List<Article>> GetAllAsync(QueryObject query)
        {
            var articles = _context.Articles.AsQueryable();

            if (!string.IsNullOrWhiteSpace(query.SapNumber))
            {
                articles = articles.Where(a => a.SapNumber.Contains(query.SapNumber));
            }

            if (!string.IsNullOrWhiteSpace(query.Name))
            {
                articles = articles.Where(a => a.Name.Contains(query.Name));
            }

            if (!string.IsNullOrWhiteSpace(query.SortBy))
            {
                if (query.SortBy.Equals("SapNumber", StringComparison.OrdinalIgnoreCase))
                {
                    articles = query.IsDescending
                        ? articles.OrderByDescending(a => a.SapNumber)
                        : articles.OrderBy(a => a.SapNumber);
                }
            }

            var skipNumber = (query.PageNumber - 1) * query.PageSize;

            return await articles.Skip(skipNumber).Take(query.PageSize).ToListAsync();
        }

        public async Task<Article?> GetByIdAsync(int id)
        {
            return await _context.Articles.FindAsync(id);
        }

        public async Task<Article?> UpdateAsync(int id, UpdateArticleDTO articleDTO)
        {
            var existingArticle = await _context.Articles.FindAsync(id);
            if (existingArticle is null)
                return null;

            existingArticle.SapNumber = articleDTO.SapNumber;
            existingArticle.Name = articleDTO.Name;
            existingArticle.Description = articleDTO.Description;
            existingArticle.IsActive = articleDTO.IsActive;
            existingArticle.UnitId = articleDTO.UnitId;

            await _context.SaveChangesAsync();

            return existingArticle;
        }

        public async Task<Article?> GetByIdSummaryAsync(int id)
        {
            return await _context
                .Articles.Include(a => a.Unit)
                .FirstOrDefaultAsync(a => a.Id == id);
        }
    }
}
