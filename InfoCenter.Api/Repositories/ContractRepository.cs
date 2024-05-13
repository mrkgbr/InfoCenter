using InfoCenter.Api.Data;
using InfoCenter.Api.DTOs.Contract;
using InfoCenter.Api.Interfaces;
using InfoCenter.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace InfoCenter.Api.Repositories;

public class ContractRepository : IContractRepository
{
    private readonly InfoCenterContext _context;

    public ContractRepository(InfoCenterContext context)
    {
        _context = context;
    }

    public async Task<string?> CheckCreateUniquenessAsync(CreateContractDTO contractDTO)
    {
        if (
            await _context.Contracts.AnyAsync(c =>
                c.ContractNumber.ToLower() == contractDTO.ContractNumber.ToLower()
            )
        )
            return "ContractNumber must be unique.";

        return null;
    }

    public async Task<string?> CheckUpdateUniquenessAsync(UpdateContractDTO contractModel)
    {
        if (
            await _context.Contracts.AnyAsync(c =>
                c.ContractNumber.ToLower() == contractModel.ContractNumber.ToLower()
                && c.Id != contractModel.Id
            )
        )
            return "ContractNumber must be unique.";

        return null;
    }

    public async Task<bool> ExistsAsync(int id)
    {
        return await _context.Contracts.AnyAsync(c => c.Id == id);
    }

    public async Task<Contract> CreateAsync(Contract contractModel)
    {
        await _context.Contracts.AddAsync(contractModel);
        await _context.SaveChangesAsync();

        return contractModel;
    }

    public async Task<Contract?> DeleteAsync(int id)
    {
        var existingContract = await _context.Contracts.FindAsync(id);
        if (existingContract is null)
            return null;

        _context.Contracts.Remove(existingContract);
        await _context.SaveChangesAsync();

        return existingContract;
    }

    public async Task<List<Contract>> GetAllAsync()
    {
        return await _context.Contracts.ToListAsync();
    }

    public async Task<Contract?> GetByIdAsync(int id)
    {
        return await _context.Contracts.FindAsync(id);
    }

    public async Task<Contract?> UpdateAsync(UpdateContractDTO contractDTO)
    {
        var existingContract = await _context.Contracts.FindAsync(contractDTO.Id);
        if (existingContract is null)
            return null;

        existingContract.ContractNumber = contractDTO.ContractNumber;
        existingContract.Name = contractDTO.Name;
        existingContract.Description = contractDTO.Description;
        existingContract.StartDate = contractDTO.StartDate;
        existingContract.EndDate = contractDTO.EndDate;
        existingContract.IsActive = contractDTO.IsActive;

        await _context.SaveChangesAsync();

        return existingContract;
    }
}
