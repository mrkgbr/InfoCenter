using System.ComponentModel.DataAnnotations;

namespace InfoCenter.Api.DTOs.Currency
{
    public record CreateCurrencyDTO
    (
        [Required]
        [MaxLength(10, ErrorMessage = "Name cannot be longer than 10 characters")]
        string Name,

        [MaxLength(150, ErrorMessage = "Description cannot be longer than 150 characters")]
        string? Description
    );
}