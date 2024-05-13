using InfoCenter.Api.DTOs.Unit;
using InfoCenter.Api.Interfaces;
using InfoCenter.Api.Mappers;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace InfoCenter.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UnitController : ControllerBase
    {
        private readonly IUnitRepository _unitRepository;
        private readonly IArticleRepository _articleRepository;

        public UnitController(IUnitRepository unitRepository, IArticleRepository articleRepository)
        {
            _unitRepository = unitRepository;
            _articleRepository = articleRepository;
        }

        [HttpGet]
        [SwaggerOperation(Summary = "Returns all Units.")]
        public async Task<IActionResult> GetAll()
        {
            var units = await _unitRepository.GetAllAsync();
            var unitsDTO = units.Select(unit => unit.ToDTO());

            return Ok(unitsDTO);
        }

        [HttpGet("{id:int}")]
        [SwaggerOperation(Summary = "Returns a single Unit with the specified ID.")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var unit = await _unitRepository.GetByIdAsync(id);
            if (unit is null)
                return NotFound();

            return Ok(unit.ToDTO());
        }

        [HttpPost]
        [SwaggerOperation(Summary = "Creates a new Unit.")]
        public async Task<IActionResult> Create([FromBody] CreateUnitDTO unitDTO)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            string? checkResponse = await _unitRepository.CheckCreateUniquenessAsync(unitDTO);
            if (!string.IsNullOrWhiteSpace(checkResponse))
                return BadRequest(checkResponse);

            var unit = await _unitRepository.CreateAsync(unitDTO.ToModelFromCreateDTO());

            return CreatedAtAction(nameof(GetById), new { id = unit.Id }, unit.ToDTO());
        }

        [HttpPut("{id:int}")]
        [SwaggerOperation(Summary = "Updates an existing Unit with the specified ID.")]
        public async Task<IActionResult> UpdateById(
            [FromRoute] int id,
            [FromBody] UpdateUnitDTO unitDTO
        )
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (id != unitDTO.Id)
                return BadRequest();

            if (!await _unitRepository.ExistsAsync(id))
                return NotFound();

            string? checkResponse = await _unitRepository.CheckUpdateUniquenessAsync(unitDTO);
            if (!string.IsNullOrWhiteSpace(checkResponse))
                return BadRequest(checkResponse);

            var unit = await _unitRepository.UpdateAsync(unitDTO);
            if (unit is null)
                return NotFound();

            return NoContent();
        }

        [HttpDelete("{id:int}")]
        [SwaggerOperation(Summary = "Deletes a Unit with the specified ID.")]
        public async Task<IActionResult> DeleteById([FromRoute] int id)
        {
            if (!await _articleRepository.ExistsAsync(id))
                return NotFound();

            if (await _articleRepository.HasUnitReferenceAsync(id))
                return BadRequest("Some Article has Unit reference, cannot delete it.");

            var existingUnit = await _unitRepository.DeleteAsync(id);
            if (existingUnit is null)
                return NotFound();

            return NoContent();
        }
    }
}
