using InfoCenter.Api.DTOs.Unit;
using InfoCenter.Api.Models;

namespace InfoCenter.Api.Interfaces
{
    public interface IUnitRepository
    {
        Task<List<Unit>> GetAllAsync();
        Task<Unit?> GetByIdAsync(int id);
        Task<Unit> CreateAsync(Unit unitModel);
        Task<Unit?> UpdateAsync(int id, UpdateUnitDTO unitDTO);
        Task<Unit?> DeleteAsync(int id);
    }
}