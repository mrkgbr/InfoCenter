namespace InfoCenter.Api.DTOs.Currency
{
    public class UpdateCurrencyDTO
    {
        public required string Name { get; set; }
        public string? Description { get; set; }
        public bool IsActive { get; set; }
    }
}
