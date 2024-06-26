using System.ComponentModel.DataAnnotations;

namespace InfoCenter.Api.DTOs.Unit;

public record CreateUnitDTO
(
    [Required]
    [MaxLength(10, ErrorMessage = "Name cannot be longer thane 10 characters")]
    string Name,

    [MaxLength(150, ErrorMessage = "Description cannot be longer than 150 characters")]
    string? Description
);