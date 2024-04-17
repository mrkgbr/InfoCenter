using InfoCenter.Api.DTOs.Article;
using InfoCenter.Api.Interfaces;
using InfoCenter.Api.Mappers;
using Microsoft.AspNetCore.Mvc;

namespace InfoCenter.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ArticleController : ControllerBase
    {
        private readonly IArticleRepository _articleRepository;

        public ArticleController(IArticleRepository articleRepository)
        {
            _articleRepository = articleRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var articles = await _articleRepository.GetAllAsync();

            return Ok(articles);
        }

        [HttpGet("{id}", Name = "ArticleGetById")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var article = await _articleRepository.GetByIdAsync(id);

            if (article is null)
                return NotFound();

            return Ok(article.ToDTO());
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateArticleDTO articleDTO)
        {
            var article = await _articleRepository.CreateAsync(articleDTO.ToModelFromCreateDTO());

            return CreatedAtAction("ArticleGetById", new { id = article.Id }, article.ToDTO());
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateArticleDTO articleDTO)
        {
            var article = await _articleRepository.UpdateAsync(id, articleDTO);
            if (article is null)
                return NotFound();

            return Ok(article.ToDTO());
        }

        [HttpDelete]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var existingArticle = await _articleRepository.DeleteAsync(id);
            if (existingArticle is null)
                return NotFound();

            return NoContent();
        }
    }
}
