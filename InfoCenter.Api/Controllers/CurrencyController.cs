using InfoCenter.Api.DTOs.Currency;
using InfoCenter.Api.Interfaces;
using InfoCenter.Api.Mappers;
using Microsoft.AspNetCore.Mvc;

namespace InfoCenter.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CurrencyController : ControllerBase
    {
        private readonly ICurrencyRepository _currencyRepository;

        public CurrencyController(ICurrencyRepository currencyRepository)
        {
            _currencyRepository = currencyRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var currencies = await _currencyRepository.GetAllAsync();
            var currenciesDTO = currencies.Select(c => c.ToDTO());

            return Ok(currenciesDTO);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var currency = await _currencyRepository.GetByIdAsync(id);
            if (currency is null)
                return NotFound();

            return Ok(currency.ToDTO());
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateCurrencyDTO currencyDTO)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var currency = await _currencyRepository.CreateAsync(
                currencyDTO.ToModelFromCreateDTO()
            );

            return CreatedAtAction(nameof(GetById), new { id = currency.Id }, currency.ToDTO());
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(
            [FromRoute] int id,
            [FromBody] UpdateCurrencyDTO currencyDTO
        )
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var currency = await _currencyRepository.UpdateAsync(id, currencyDTO);
            if (currency is null)
                return NotFound();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var currency = await _currencyRepository.DeleteAsync(id);
            if (currency is null)
                return NotFound();

            return NoContent();
        }
    }
}
