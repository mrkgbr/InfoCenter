using InfoCenter.Api.Data;
using InfoCenter.Api.DTOs.Unit;
using InfoCenter.Api.Interfaces;
using InfoCenter.Api.Models;

using Microsoft.EntityFrameworkCore;

namespace InfoCenter.Api.Repositories;

public class UnitRepository : IUnitRepository
{
    private readonly InfoCenterContext _context;

    public UnitRepository(InfoCenterContext context)
    {
        _context = context;
    }

    public async Task<string?> CheckCreateUniquenessAsync(CreateUnitDTO unitDTO)
    {
        if (await _context.Units.AnyAsync(u => u.Name.ToLower() == unitDTO.Name.ToLower()))
            return "Unit name must be unique";

        return null;
    }

    public async Task<string?> CheckUpdateUniquenessAsync(UpdateUnitDTO unitModel)
    {
        if (
            await _context.Units.AnyAsync(u =>
                u.Name.ToLower() == unitModel.Name.ToLower() && u.Id != unitModel.Id
            )
        )
            return "Unit name must be unique.";

        return null;
    }

    public async Task<Unit> CreateAsync(Unit unitModel)
    {
        await _context.Units.AddAsync(unitModel);
        await _context.SaveChangesAsync();

        return unitModel;
    }

    public async Task<Unit?> DeleteAsync(int id)
    {
        var existingUnit = await _context.Units.FindAsync(id);
        if (existingUnit is null)
            return null;

        _context.Units.Remove(existingUnit);
        await _context.SaveChangesAsync();

        return existingUnit;
    }

    public async Task<bool> ExistsAsync(int id)
    {
        return await _context.Units.AnyAsync(unit => unit.Id == id);
    }

    public async Task<List<Unit>> GetAllAsync()
    {
        return await _context.Units.ToListAsync();
    }

    public async Task<Unit?> GetByIdAsync(int id)
    {
        var existingUnit = await _context.Units.FindAsync(id);
        if (existingUnit is null)
            return null;

        return existingUnit;
    }

    public async Task<Unit?> UpdateAsync(UpdateUnitDTO unitDTO)
    {
        var existingUnit = await _context.Units.FindAsync(unitDTO.Id);
        if (existingUnit is null)
            return null;

        existingUnit.Name = unitDTO.Name;
        existingUnit.Description = unitDTO.Description;
        existingUnit.IsActive = unitDTO.IsActive;

        await _context.SaveChangesAsync();

        return existingUnit;
    }
}
