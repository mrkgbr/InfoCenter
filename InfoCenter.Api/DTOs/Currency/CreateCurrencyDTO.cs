namespace InfoCenter.Api.DTOs.Currency
{
    public class CreateCurrencyDTO
    {
        public required string Name { get; set; }
        public string? Description { get; set; }
    }
}
