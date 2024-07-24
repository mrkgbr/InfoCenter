using InfoCenter.Api.DTOs.Article;
using InfoCenter.Api.Helpers;
using InfoCenter.Api.Interfaces;
using InfoCenter.Api.Mappers;

using Microsoft.AspNetCore.Mvc;

namespace InfoCenter.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class ArticleController : ControllerBase
{
    private readonly IArticleRepository _articleRepository;
    private readonly IUnitRepository _unitRepository;
    private readonly IArticleDetailRepository _articleDetailRepository;

    public ArticleController(
        IArticleRepository articleRepository,
        IUnitRepository unitRepository,
        IArticleDetailRepository articleDetailRepository
    )
    {
        _articleRepository = articleRepository;
        _unitRepository = unitRepository;
        _articleDetailRepository = articleDetailRepository;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll([FromQuery] QueryObject query)
    {
        var articles = await _articleRepository.GetAllAsync(query);
        var articlesDTO = articles.Select(x => x.ToDTO());

        return Ok(articlesDTO);
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetById([FromRoute] int id)
    {
        var article = await _articleRepository.GetByIdAsync(id);
        if (article is null)
            return NotFound("Article not found.");

        return Ok(article.ToDTO());
    }

    [HttpGet]
    [Route("Summary/{id:int}")]
    public async Task<IActionResult> GetByIdSummary([FromRoute] int id)
    {
        var article = await _articleRepository.GetByIdSummaryAsync(id);
        if (article is null)
            return NotFound("Article not found.");

        return Ok(article.ToSummaryDTO());
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateArticleDTO articleDTO)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        if (!await _unitRepository.ExistsAsync(articleDTO.UnitId))
            return BadRequest("Unit does not exist.");

        string? message = await _articleRepository.CheckCreateUniquenessAsync(articleDTO);
        if (!string.IsNullOrWhiteSpace(message))
            return BadRequest(message);

        var article = await _articleRepository.CreateAsync(articleDTO.ToModelFromCreateDTO());

        return CreatedAtAction(nameof(GetById), new { id = article.Id }, article.ToDTO());
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> Update(
        [FromRoute] int id,
        [FromBody] UpdateArticleDTO articleDTO
    )
    {
        if (id != articleDTO.Id)
            return BadRequest("The ID in the route does not match the ID in the request body.");

        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        if (!await _unitRepository.ExistsAsync(articleDTO.UnitId))
            return BadRequest("Unit does not exist");

        string? message = await _articleRepository.CheckUpdateUniquenessAsync(articleDTO);
        if (!string.IsNullOrWhiteSpace(message))
            return BadRequest(message);

        var article = await _articleRepository.UpdateAsync(articleDTO);
        if (article is null)
            return NotFound("Article not found.");

        return NoContent();
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete([FromRoute] int id)
    {
        if (await _articleDetailRepository.HasArticleReference(id))
            return BadRequest("One or more Article Detail has Article reference, cannot delete.");

        var existingArticle = await _articleRepository.DeleteAsync(id);
        if (existingArticle is null)
            return NotFound("Article not found.");

        return NoContent();
    }
}
