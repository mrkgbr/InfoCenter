using InfoCenter.Api.DTOs.Currency;
using InfoCenter.Api.Models;

namespace InfoCenter.Api.Mappers
{
    public static class CurrencyMappers
    {
        public static CurrencyDTO ToDTO(this Currency currencyModel)
        {
            return new CurrencyDTO
            (
                currencyModel.Id,
                currencyModel.Name,
                currencyModel.Description,
                currencyModel.IsActive
            );
        }

        public static Currency ToModelFromCreateDTO(this CreateCurrencyDTO currencyDTO)
        {
            return new Currency
            {
                Name = currencyDTO.Name,
                Description = currencyDTO.Description
            };
        }
    }
}