using InfoCenter.Api.DTOs.ArticleDetail;
using InfoCenter.Api.Interfaces;
using InfoCenter.Api.Mappers;
using Microsoft.AspNetCore.Mvc;

namespace InfoCenter.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class ArticleDetailController : ControllerBase
{
    private readonly IArticleDetailRepository _articleDetailRepository;
    private readonly IArticleRepository _articleRepository;
    private readonly IContractRepository _contractRepository;
    private readonly ICurrencyRepository _currencyRepository;

    public ArticleDetailController(
        IArticleDetailRepository articleDetailRepository,
        IArticleRepository articleRepository,
        IContractRepository contractRepository,
        ICurrencyRepository currencyRepository
    )
    {
        _articleDetailRepository = articleDetailRepository;
        _articleRepository = articleRepository;
        _contractRepository = contractRepository;
        _currencyRepository = currencyRepository;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var articleDetails = await _articleDetailRepository.GetAllAsync();
        var articleDetailsDTO = articleDetails.Select(a => a.ToDTO());

        return Ok(articleDetailsDTO);
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetById([FromRoute] int id)
    {
        var articleDetail = await _articleDetailRepository.GetByIdAsync(id);
        if (articleDetail is null)
            return NotFound();

        return Ok(articleDetail.ToDTO());
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateArticleDetailDTO articleDetailDTO)
    {
        if (!await _articleRepository.ExistsAsync(articleDetailDTO.ArticleId))
            return BadRequest("Article does not exist");
        if (!await _contractRepository.ExistsAsync(articleDetailDTO.ContractId))
            return BadRequest("Contract does not exist");
        if (!await _currencyRepository.ExistsAsync(articleDetailDTO.CurrencyId))
            return BadRequest("Currency does not exist");

        var articleDetail = await _articleDetailRepository.CreateAsync(
            articleDetailDTO.ToModelFromCreateDTO()
        );

        return CreatedAtAction(
            nameof(GetById),
            new { id = articleDetail.Id },
            articleDetail.ToDTO()
        );
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> Update(
        [FromRoute] int id,
        [FromBody] UpdateArticleDetailDTO articleDetailDTO
    )
    {
        if (!await _articleRepository.ExistsAsync(articleDetailDTO.ArticleId))
            return BadRequest("Article does not exist");
        if (!await _contractRepository.ExistsAsync(articleDetailDTO.ContractId))
            return BadRequest("Contract does not exist");
        if (!await _currencyRepository.ExistsAsync(articleDetailDTO.CurrencyId))
            return BadRequest("Currency does not exist");

        var articleDetail = await _articleDetailRepository.UpdateAsync(articleDetailDTO);
        if (articleDetail is null)
            return NotFound();

        return NoContent();
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete([FromRoute] int id)
    {
        var articleDetail = await _articleDetailRepository.DeleteAsync(id);
        if (articleDetail is null)
            return NotFound();

        return NoContent();
    }
}
