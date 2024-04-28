using InfoCenter.Api.Data;
using InfoCenter.Api.DTOs.Unit;
using InfoCenter.Api.Exceptions;
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

        private async Task<Unit> ExistingUnit(int id)
        {
            return await _context.Units.FindAsync(id)
                ?? throw new HttpResponseException(404, "Unit does not exists with the given ID.");
        }

        public async Task<bool> UnitExistsAsync(int id)
        {
            return await _context.Units.AnyAsync(unit => unit.Id == id);
        }

        public async Task<Unit> CreateAsync(Unit unitModel)
        {
            // checking name uniqueness
            if (await _context.Units.AnyAsync(u => u.Name.ToLower() == unitModel.Name.ToLower()))
                throw new HttpResponseException(400, "Unit name must be unique");

            await _context.Units.AddAsync(unitModel);
            await _context.SaveChangesAsync();

            return unitModel;
        }

        public async Task<Unit> DeleteAsync(int id)
        {
            Unit existingUnit = await ExistingUnit(id);

            _context.Units.Remove(existingUnit);
            await _context.SaveChangesAsync();

            return existingUnit;
        }

        public async Task<List<Unit>> GetAllAsync()
        {
            return await _context.Units.ToListAsync();
        }

        public async Task<Unit> GetByIdAsync(int id)
        {
            Unit existingUnit = await ExistingUnit(id);

            return existingUnit;
        }

        public async Task<Unit> UpdateAsync(int id, UpdateUnitDTO unitDTO)
        {
            Unit existingUnit = await ExistingUnit(id);

            // checking name uniqueness
            if (
                await _context.Units.AnyAsync(u =>
                    u.Name.ToLower() == unitDTO.Name.ToLower() && u.Id != id
                )
            )
                throw new HttpResponseException(400, "Name must be unique.");

            existingUnit.Name = unitDTO.Name;
            existingUnit.Description = unitDTO.Description;
            existingUnit.IsActive = unitDTO.IsActive;

            await _context.SaveChangesAsync();

            return existingUnit;
        }
    }
}
