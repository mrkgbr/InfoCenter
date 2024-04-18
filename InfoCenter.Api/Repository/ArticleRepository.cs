using InfoCenter.Api.DTOs.Article;
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

        public async Task<List<Article>> GetAllAsync()
        {
            return await _context.Articles.ToListAsync();
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
    }
}