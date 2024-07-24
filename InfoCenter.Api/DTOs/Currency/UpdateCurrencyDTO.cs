using System.ComponentModel.DataAnnotations;

namespace InfoCenter.Api.DTOs.Currency;

public class UpdateCurrencyDTO
{
    [Required]
    public int Id { get; set; }

    [Required]
    [MaxLength(10, ErrorMessage = "Name cannot be longer than 10 characters")]
    public required string Name { get; set; }

    [MaxLength(150, ErrorMessage = "Description cannot be longer than 150 characters")]
    public string? Description { get; set; }

    [Required]
    public bool IsActive { get; set; }
}