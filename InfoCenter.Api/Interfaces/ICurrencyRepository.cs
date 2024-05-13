using InfoCenter.Api.DTOs.Currency;
using InfoCenter.Api.Models;

namespace InfoCenter.Api.Interfaces
{
    public interface ICurrencyRepository
    {
        Task<string?> CheckCreateUniqueness(CreateCurrencyDTO currencyDTO);
        Task<string?> CheckUpdateUniqueness(UpdateCurrencyDTO currencyModel);
        Task<Currency> CreateAsync(Currency currencyModel);
        Task<Currency?> DeleteAsync(int id);
        Task<bool> ExistsAsync(int id);
        Task<List<Currency>> GetAllAsync();
        Task<Currency?> GetByIdAsync(int id);
        Task<Currency?> UpdateAsync(UpdateCurrencyDTO currencyDTO);
    }
}