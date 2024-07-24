using InfoCenter.Api.DTOs.Currency;
using InfoCenter.Api.Interfaces;
using InfoCenter.Api.Mappers;

using Microsoft.AspNetCore.Mvc;

using Swashbuckle.AspNetCore.Annotations;

namespace InfoCenter.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class CurrencyController : ControllerBase
{
    private readonly ICurrencyRepository _currencyRepository;
    private readonly IArticleDetailRepository _articleDetailRepository;

    public CurrencyController(
        ICurrencyRepository currencyRepository,
        IArticleDetailRepository articleDetailRepository
    )
    {
        _currencyRepository = currencyRepository;
        _articleDetailRepository = articleDetailRepository;
    }

    [HttpGet]
    [SwaggerOperation(Summary = "Returns all Currencies.")]
    public async Task<IActionResult> GetAll()
    {
        var currencies = await _currencyRepository.GetAllAsync();
        var currenciesDTO = currencies.Select(c => c.ToDTO());

        return Ok(currenciesDTO);
    }

    [HttpGet("{id:int}")]
    [SwaggerOperation(Summary = "Returns a Currency with the specified ID.")]
    public async Task<IActionResult> GetById([FromRoute] int id)
    {
        var currency = await _currencyRepository.GetByIdAsync(id);
        if (currency is null)
            return NotFound("Currency not found.");

        return Ok(currency.ToDTO());
    }

    [HttpPost]
    [SwaggerOperation(Summary = "Creates a new Currency.")]
    public async Task<IActionResult> Create([FromBody] CreateCurrencyDTO currencyDTO)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        string? checkResponse = await _currencyRepository.CheckCreateUniquenessAsync(currencyDTO);
        if (!string.IsNullOrWhiteSpace(checkResponse))
            return BadRequest(checkResponse);

        var currency = await _currencyRepository.CreateAsync(
            currencyDTO.ToModelFromCreateDTO()
        );

        return CreatedAtAction(nameof(GetById), new { id = currency.Id }, currency.ToDTO());
    }

    [HttpPut("{id:int}")]
    [SwaggerOperation(Summary = "Updates a Currency with the specified ID.")]
    public async Task<IActionResult> Update(
        [FromRoute] int id,
        [FromBody] UpdateCurrencyDTO currencyDTO
    )
    {
        if (id != currencyDTO.Id)
            return BadRequest("The ID in the route does not match the ID in the request body.");

        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        string? checkResponse = await _currencyRepository.CheckUpdateUniquenessAsync(currencyDTO);
        if (!string.IsNullOrWhiteSpace(checkResponse))
            return BadRequest(checkResponse);

        if (!await _currencyRepository.ExistsAsync(id))
            return NotFound("Currency not found.");

        var currency = await _currencyRepository.UpdateAsync(currencyDTO);
        if (currency is null)
            return NotFound("Currency not found.");

        return NoContent();
    }

    [HttpDelete("{id:int}")]
    [SwaggerOperation(Summary = "Deletes a Currency with the specified ID.")]
    public async Task<IActionResult> Delete([FromRoute] int id)
    {
        if (!await _currencyRepository.ExistsAsync(id))
            return NotFound("Currency not found.");

        if (await _articleDetailRepository.HasCurrencyReference(id))
            return BadRequest("One or more Article Detail has Currency reference, cannot delete.");

        var currency = await _currencyRepository.DeleteAsync(id);
        if (currency is null)
            return NotFound("Currency not found.");

        return NoContent();
    }
}
