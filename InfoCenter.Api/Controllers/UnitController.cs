using InfoCenter.Api.DTOs.Unit;
using InfoCenter.Api.Interfaces;
using InfoCenter.Api.Mappers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
        [SwaggerOperation(Summary = "Returns all the units in the system")]
        public async Task<IActionResult> GetAll()
        {
            var units = await _unitRepository.GetAllAsync();
            var unitsDTO = units.Select(unit => unit.ToDTO());

            return Ok(unitsDTO);
        }

        [HttpGet("{id}")]
        [SwaggerOperation(Summary = "Returns a single unit by id")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var unit = await _unitRepository.GetByIdAsync(id);
            if (unit is null)
                return NotFound();

            return Ok(unit.ToDTO());
        }

        [HttpPost]
        [SwaggerOperation(Summary = "Creates a new unit in the system")]
        public async Task<IActionResult> Create([FromBody] CreateUnitDTO unitDTO)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var unit = await _unitRepository.CreateAsync(unitDTO.ToModelFromCreateDTO());

                return CreatedAtAction(nameof(GetById), new { id = unit.Id }, unit.ToDTO());
            }
            catch (DbUpdateException ex)
            {
                return BadRequest(ex.InnerException?.Message);
            }
        }

        [HttpPut("{id}")]
        [SwaggerOperation(Summary = "Updates an existing customer in the system")]
        public async Task<IActionResult> UpdateById(
            [FromRoute] int id,
            [FromBody] UpdateUnitDTO unitDTO
        )
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var existingUnit = await _unitRepository.UpdateAsync(id, unitDTO);
            if (existingUnit is null)
                return NotFound();

            return NoContent();
        }

        [HttpDelete("{id}")]
        [SwaggerOperation(Summary = "Deletes a unit in the system")]
        public async Task<IActionResult> DeleteById([FromRoute] int id)
        {
            try
            {
                if (await _articleRepository.ArticleHasUnitReferenceAsync(id))
                    return BadRequest("Some Article has Unit reference, cannot delete");

                var existingUnit = await _unitRepository.DeleteAsync(id);
                if (existingUnit is null)
                    return NotFound();

                return NoContent();
            }
            catch (DbUpdateException ex)
            {
                return BadRequest(ex.InnerException?.Message ?? "Something went wrong");
            }
        }
    }
}
