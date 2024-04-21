using InfoCenter.Api.Data;
using InfoCenter.Api.DTOs.Currency;
using InfoCenter.Api.Interfaces;
using InfoCenter.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace InfoCenter.Api.Repository
{
    public class CurrencyRepository : ICurrencyRepository
    {
        private readonly InfoCenterContext _context;

        public CurrencyRepository(InfoCenterContext context)
        {
            _context = context;
        }

        public async Task<Currency> CreateAsync(Currency currencyModel)
        {
            await _context.Currencies.AddAsync(currencyModel);
            await _context.SaveChangesAsync();

            return currencyModel;
        }

        public async Task<Currency?> DeleteAsync(int id)
        {
            var existingCurrency = await _context.Currencies.FindAsync(id);
            if (existingCurrency is null)
                return null;

            _context.Currencies.Remove(existingCurrency);
            await _context.SaveChangesAsync();

            return existingCurrency;
        }

        public async Task<List<Currency>> GetAllAsync()
        {
            return await _context.Currencies.ToListAsync();
        }

        public async Task<Currency?> GetByIdAsync(int id)
        {
            var existingCurrency = await _context.Currencies.FindAsync(id);
            if (existingCurrency is null)
                return null;

            return existingCurrency;
        }

        public async Task<Currency?> UpdateAsync(int id, UpdateCurrencyDTO currencyDTO)
        {
            var existingCurrency = await _context.Currencies.FindAsync(id);
            if (existingCurrency is null)
                return null;

            existingCurrency.Name = currencyDTO.Name;
            existingCurrency.Description = currencyDTO.Description;
            existingCurrency.IsActive = currencyDTO.IsActive;

            await _context.SaveChangesAsync();

            return existingCurrency;
        }
    }
}
