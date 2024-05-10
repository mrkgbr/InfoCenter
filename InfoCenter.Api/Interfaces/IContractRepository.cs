
using InfoCenter.Api.DTOs.Contract;
using InfoCenter.Api.Models;

namespace InfoCenter.Api.Interfaces;

public interface IContractRepository
{
    Task<List<Contract>> GetAllAsync();
    Task<Contract?> GetByIdAsync(int id);
    Task<Contract> CreateAsync(Contract contractModel);
    Task<Contract?> UpdateAsync(int id, UpdateContractDTO contractDTO);
    Task<Contract?> DeleteAsync(int id);
    Task<bool> ExistsAsync(int id);
    Task<string?> CheckUpdateUniqueness(int id, UpdateContractDTO contractModel);
    Task<string?> CheckCreateUniqueness(CreateContractDTO contractDTO);
}
