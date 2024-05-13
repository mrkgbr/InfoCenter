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
        private readonly IArticleDetailRepository _articleDetailRepository;

        public ContractController(
            IContractRepository contractRepo,
            IArticleDetailRepository articleDetailRepository
        )
        {
            _contractRepo = contractRepo;
            _articleDetailRepository = articleDetailRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var contracts = await _contractRepo.GetAllAsync();
            var contractsDTO = contracts.Select(c => c.ToDTO());

            return Ok(contractsDTO);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var contract = await _contractRepo.GetByIdAsync(id);
            if (contract is null)
                return NotFound();

            return Ok(contract.ToDTO());
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateContractDTO contractDTO)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            string? checkResponse = await _contractRepo.CheckCreateUniquenessAsync(contractDTO);
            if (!string.IsNullOrWhiteSpace(checkResponse))
                return BadRequest(checkResponse);

            var contract = await _contractRepo.CreateAsync(contractDTO.ToModelFromCreateDTO());

            return CreatedAtAction(nameof(GetById), new { id = contract.Id }, contract.ToDTO());
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update(
            [FromRoute] int id,
            [FromBody] UpdateContractDTO updateDTO
        )
        {
            if (id != updateDTO.Id)
                return BadRequest();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (!await _contractRepo.ExistsAsync(id))
                return NotFound();

            string? checkResponse = await _contractRepo.CheckUpdateUniquenessAsync(updateDTO);
            if (!string.IsNullOrWhiteSpace(checkResponse))
                return BadRequest(checkResponse);

            var contract = await _contractRepo.UpdateAsync(updateDTO);
            if (contract is null)
                return NotFound();

            return NoContent();
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            if (!await _contractRepo.ExistsAsync(id))
                return NotFound();

            if (await _articleDetailRepository.HasContractReference(id))
                return BadRequest("Some Article Detail has Contract reference, cannot delete");

            var contract = await _contractRepo.DeleteAsync(id);
            if (contract is null)
                return NotFound();

            return NoContent();
        }
    }
}
