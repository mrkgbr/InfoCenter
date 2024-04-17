using InfoCenter.Api.DTOs.Unit;
using InfoCenter.Api.Interfaces;
using InfoCenter.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace InfoCenter.Api.Repository
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
            unitModel.IsActive = true; // default is true when created
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