using InfoCenter.Api.DTOs.Contract;
using InfoCenter.Api.Interfaces;
using InfoCenter.Api.Mappers;
using Microsoft.AspNetCore.Mvc;

namespace InfoCenter.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ContractController : ControllerBase
    {
        private readonly IContractRepository _contractRepo;

        public ContractController(IContractRepository contractRepo)
        {
            _contractRepo = contractRepo;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var contracts = await _contractRepo.GetAllAsync();
            var contractsDTO = contracts.Select(c => c.ToDTO());

            return Ok(contractsDTO);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var contract = await _contractRepo.GetByIdAsnyc(id);
            if (contract is null)
                return NotFound();

            return Ok(contract.ToDTO());
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateContractDTO contractDTO)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var contract = await _contractRepo.CreateAsync(contractDTO.ToModelFromCreateDTO());

            return CreatedAtAction(nameof(GetById), new { id = contract.Id }, contract.ToDTO());
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromRoute] int id, UpdateContractDTO updateDTO)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var contract = await _contractRepo.UpdateAsync(id, updateDTO);
            if (contract is null)
                return NotFound();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var contract = await _contractRepo.DeleteAsync(id);
            if (contract is null)
                return NotFound();

            return NoContent();
        }
    }
}
