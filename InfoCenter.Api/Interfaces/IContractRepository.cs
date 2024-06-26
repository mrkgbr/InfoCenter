﻿using InfoCenter.Api.DTOs.Contract;
using InfoCenter.Api.Models;

namespace InfoCenter.Api.Interfaces;

public interface IContractRepository
{
    Task<string?> CheckCreateUniquenessAsync(CreateContractDTO contractDTO);
    Task<string?> CheckUpdateUniquenessAsync(UpdateContractDTO contractModel);
    Task<Contract> CreateAsync(Contract contractModel);
    Task<Contract?> DeleteAsync(int id);
    Task<bool> ExistsAsync(int id);
    Task<List<Contract>> GetAllAsync();
    Task<Contract?> GetByIdAsync(int id);
    Task<Contract?> UpdateAsync(UpdateContractDTO contractDTO);
}