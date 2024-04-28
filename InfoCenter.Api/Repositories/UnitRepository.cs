using InfoCenter.Api.Data;
using InfoCenter.Api.DTOs.Unit;
using InfoCenter.Api.Interfaces;
using InfoCenter.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace InfoCenter.Api.Repositories
{
    public class UnitRepository : IUnitRepository
    {
        private readonly InfoCenterContext _context;

        public UnitRepository(InfoCenterContext context)
        {
            _context = context;
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

        public async Task<List<Unit>> GetAllAsync()
        {
            return await _context.Units.ToListAsync();
        }

        public async Task<Unit?> GetByIdAsync(int id)
        {
            return await _context.Units.FindAsync(id);
        }

        public async Task<bool> IsUnitNameExistsAsync(string name)
        {
            return await _context.Units.AnyAsync(u => u.Name.ToLower() == name.ToLower());
        }

        public async Task<bool> IsUnitNameExistsAsync(string name, int id)
        {
            return await _context.Units.AnyAsync(u =>
                u.Name.ToLower() == name.ToLower() && u.Id != id
            );
        }

        public async Task<bool> UnitExistsAsync(int id)
        {
            return await _context.Units.AnyAsync(unit => unit.Id == id);
        }

        public async Task<Unit?> UpdateAsync(int id, UpdateUnitDTO unitDTO)
        {
            var existingUnit = await _context.Units.FindAsync(id);
            if (existingUnit is null)
                return null;

            existingUnit.Name = unitDTO.Name;
            existingUnit.Description = unitDTO.Description;
            existingUnit.IsActive = unitDTO.IsActive;

            await _context.SaveChangesAsync();

            return existingUnit;
        }
    }
}
