using InfoCenter.Api.Data;
using InfoCenter.Api.DTOs.Contract;
using InfoCenter.Api.Interfaces;
using InfoCenter.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace InfoCenter.Api.Repository;

public class ContractRepository : IContractRepository
{
    private readonly InfoCenterContext _context;

    public ContractRepository(InfoCenterContext context)
    {
        _context = context;
    }

    public async Task<bool> ContractExistAsync(int id)
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

    public async Task<Contract?> GetByIdAsnyc(int id)
    {
        return await _context.Contracts.FindAsync(id);
    }

    public async Task<Contract?> UpdateAsync(int id, UpdateContractDTO contractDTO)
    {
        var existingContract = await _context.Contracts.FindAsync(id);
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
