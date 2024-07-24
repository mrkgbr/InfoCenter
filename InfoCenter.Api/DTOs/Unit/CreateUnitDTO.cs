using System.ComponentModel.DataAnnotations;

namespace InfoCenter.Api.DTOs.Unit;

public class CreateUnitDTO
{
    [Required]
    [MaxLength(10, ErrorMessage = "Name cannot be longer thane 10 characters")]
    public required string Name { get; set; }

    [MaxLength(150, ErrorMessage = "Description cannot be longer than 150 characters")]
    public string? Description { get; set; }
}