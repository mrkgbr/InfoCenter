using InfoCenter.Api.DTOs.Unit;
using InfoCenter.Api.Interfaces;
using InfoCenter.Api.Mappers;
using Microsoft.AspNetCore.Mvc;

namespace InfoCenter.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UnitController : ControllerBase
    {
        private readonly IUnitRepository _unitRepository;

        public UnitController(IUnitRepository unitRepository)
        {
            _unitRepository = unitRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var units = await _unitRepository.GetAllAsync();
            var unitsDTO = units.Select(unit => unit.ToDTO());

            return Ok(unitsDTO);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var unit = await _unitRepository.GetByIdAsync(id);
            if (unit is null)
                return NotFound();

            return Ok(unit.ToDTO());
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateUnitDTO unitDTO)
        {
            var unit = await _unitRepository.CreateAsync(unitDTO.ToModelFromCreateDTO());

            return CreatedAtAction(nameof(GetById), new { id = unit.Id }, unit.ToDTO());
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateById(
            [FromRoute] int id,
            [FromBody] UpdateUnitDTO unitDTO
        )
        {
            var existingUnit = await _unitRepository.UpdateAsync(id, unitDTO);
            if (existingUnit is null)
                return NotFound();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteById([FromRoute] int id)
        {
            var existingUnit = await _unitRepository.DeleteAsync(id);
            if (existingUnit is null)
                return NotFound();

            return NoContent();
        }
    }
}
