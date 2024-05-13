using InfoCenter.Api.DTOs.Unit;
using InfoCenter.Api.Models;

namespace InfoCenter.Api.Interfaces
{
    public interface IUnitRepository
    {
        Task<string?> CheckCreateUniquenessAsync(CreateUnitDTO unitDTO);
        Task<string?> CheckUpdateUniquenessAsync(UpdateUnitDTO unitModel);
        Task<Unit> CreateAsync(Unit unitModel);
        Task<Unit?> DeleteAsync(int id);
        Task<bool> ExistsAsync(int id);
        Task<List<Unit>> GetAllAsync();
        Task<Unit?> GetByIdAsync(int id);
        Task<Unit?> UpdateAsync(UpdateUnitDTO unitDTO);
    }
}
