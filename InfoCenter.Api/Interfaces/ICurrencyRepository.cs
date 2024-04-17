using InfoCenter.Api.DTOs.Currency;
using InfoCenter.Api.Models;

namespace InfoCenter.Api.Interfaces
{
    public interface ICurrencyRepository
    {
        Task<List<Currency>> GetAllAsync();
        Task<Currency?> GetByIdAsync(int id);
        Task<Currency> CreateAsync(Currency currencyModel);
        Task<Currency?> UpdateAsync(int id, UpdateCurrencyDTO currencyDTO);
        Task<Currency?> DeleteAsync(int id);
    }
}