using InfoCenter.Api.Data;
using InfoCenter.Api.DTOs.Currency;
using InfoCenter.Api.Exceptions;
using InfoCenter.Api.Interfaces;
using InfoCenter.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace InfoCenter.Api.Repositories
{
    public class CurrencyRepository : ICurrencyRepository
    {
        private readonly InfoCenterContext _context;

        public CurrencyRepository(InfoCenterContext context)
        {
            _context = context;
        }

        private async Task<Currency> GetExistingCurrency(int id)
        {
            return await _context.Currencies.FindAsync(id)
                ?? throw new HttpResponseException(
                    404,
                    "Currency does not exists with the given ID."
                );
        }

        public async Task<Currency> CreateAsync(Currency currencyModel)
        {
            if (
                await _context.Currencies.AnyAsync(c =>
                    c.Name.ToLower() == currencyModel.Name.ToLower()
                )
            )
                throw new HttpResponseException(400, "Currency name must be unique");

            await _context.Currencies.AddAsync(currencyModel);
            await _context.SaveChangesAsync();

            return currencyModel;
        }

        public async Task<bool> CurrencyExistAsync(int id)
        {
            return await _context.Currencies.AnyAsync(c => c.Id == id);
        }

        public async Task<Currency> DeleteAsync(int id)
        {
            var existingCurrency = await GetExistingCurrency(id);

            _context.Currencies.Remove(existingCurrency);
            await _context.SaveChangesAsync();

            return existingCurrency;
        }

        public async Task<List<Currency>> GetAllAsync()
        {
            return await _context.Currencies.ToListAsync();
        }

        public async Task<Currency> GetByIdAsync(int id)
        {
            return await GetExistingCurrency(id);
        }

        public async Task<Currency> UpdateAsync(int id, UpdateCurrencyDTO currencyDTO)
        {
            var existingCurrency = await GetExistingCurrency(id);

            // checking name uniqueness
            if (
                await _context.Currencies.AnyAsync(c =>
                    c.Name.ToLower() == currencyDTO.Name.ToLower() && c.Id != id
                )
            )
                throw new HttpResponseException(400, "Currency name must be unique.");

            existingCurrency.Name = currencyDTO.Name;
            existingCurrency.Description = currencyDTO.Description;
            existingCurrency.IsActive = currencyDTO.IsActive;

            await _context.SaveChangesAsync();

            return existingCurrency;
        }
    }
}
