using InfoCenter.Api.DTOs.Article;
using InfoCenter.Api.Helpers;
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
        private readonly IUnitRepository _unitRepository;

        public ArticleController(
            IArticleRepository articleRepository,
            IUnitRepository unitRepository
        )
        {
            _articleRepository = articleRepository;
            _unitRepository = unitRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] QueryObject query)
        {
            var articles = await _articleRepository.GetAllAsync(query);
            var articlesDTO = articles.Select(x => x.ToDTO());

            return Ok(articlesDTO);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var article = await _articleRepository.GetByIdAsync(id);

            if (article is null)
                return NotFound();

            return Ok(article.ToDTO());
        }

        [HttpPost("{unitId}")]
        public async Task<IActionResult> Create(
            [FromRoute] int unitId,
            [FromBody] CreateArticleDTO articleDTO
        )
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (!await _unitRepository.UnitExistsAsync(unitId))
                return BadRequest("Unit does not exist");

            var article = await _articleRepository.CreateAsync(
                articleDTO.ToModelFromCreateDTO(unitId)
            );

            return CreatedAtAction(nameof(GetById), new { id = article.Id }, article.ToDTO());
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(
            [FromRoute] int id,
            [FromBody] UpdateArticleDTO articleDTO
        )
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (!await _unitRepository.UnitExistsAsync(articleDTO.UnitId))
                return BadRequest("Unit does not exist");

            var article = await _articleRepository.UpdateAsync(id, articleDTO);
            if (article is null)
                return NotFound();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var existingArticle = await _articleRepository.DeleteAsync(id);
            if (existingArticle is null)
                return NotFound();

            return NoContent();
        }
    }
}
