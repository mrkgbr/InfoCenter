namespace InfoCenter.Api.DTOs.Currency
{
    public record CurrencyDTO
    (
        int Id,
        string Name,
        string? Description,
        bool IsActive
    );
}