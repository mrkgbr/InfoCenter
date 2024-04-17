using System.ComponentModel.DataAnnotations;

namespace InfoCenter.Api.DTOs.Unit;

public class CreateUnitDTO
{
    [Required]
    [MaxLength(10, ErrorMessage = "Name cannot be over 10 characters")]
    public required string Name { get; set; }

    [Required]
    [MaxLength(150, ErrorMessage = "Name cannot be over 150 characters")]
    public string? Description { get; set; }
}