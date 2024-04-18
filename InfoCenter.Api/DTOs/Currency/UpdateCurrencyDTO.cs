using System.ComponentModel.DataAnnotations;

namespace InfoCenter.Api.DTOs.Currency
{
    public class UpdateCurrencyDTO
    {
        [Required]
        [MaxLength(10, ErrorMessage = "Name cannot be longer than 10 characters")]
        public string Name { get; set; } = string.Empty;

        [MaxLength(150, ErrorMessage = "Description cannot be longer than 150 characters")]
        public string? Description { get; set; }

        [Required]
        public bool IsActive { get; set; }
    }
}
