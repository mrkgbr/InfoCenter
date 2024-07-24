using InfoCenter.Api.Data;
using InfoCenter.Api.DTOs.Currency;
using InfoCenter.Api.Interfaces;
using InfoCenter.Api.Models;

using Microsoft.EntityFrameworkCore;

namespace InfoCenter.Api.Repositories;

public class CurrencyRepository : ICurrencyRepository
{
    private readonly InfoCenterContext _context;

    public CurrencyRepository(InfoCenterContext context)
    {
        _context = context;
    }

    public async Task<string?> CheckCreateUniquenessAsync(CreateCurrencyDTO currencyDTO)
    {
        if (
            await _context.Currencies.AnyAsync(c =>
                c.Name.ToLower() == currencyDTO.Name.ToLower()
            )
        )
            return "Name must be unique.";

        return null;
    }

    public async Task<string?> CheckUpdateUniquenessAsync(UpdateCurrencyDTO currencyModel)
    {
        if (
            await _context.Currencies.AnyAsync(c =>
                c.Name.ToLower() == currencyModel.Name.ToLower() && c.Id != currencyModel.Id
            )
        )
            return "Name must be unique.";

        return null;
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

    public async Task<bool> ExistsAsync(int id)
    {
        return await _context.Currencies.AnyAsync(c => c.Id == id);
    }

    public async Task<List<Currency>> GetAllAsync()
    {
        return await _context.Currencies.ToListAsync();
    }

    public async Task<Currency?> GetByIdAsync(int id)
    {
        return await _context.Currencies.FindAsync(id);
    }

    public async Task<Currency?> UpdateAsync(UpdateCurrencyDTO currencyDTO)
    {
        var existingCurrency = await _context.Currencies.FindAsync(currencyDTO.Id);
        if (existingCurrency is null)
            return null;

        existingCurrency.Name = currencyDTO.Name;
        existingCurrency.Description = currencyDTO.Description;
        existingCurrency.IsActive = currencyDTO.IsActive;

        await _context.SaveChangesAsync();

        return existingCurrency;
    }
}
