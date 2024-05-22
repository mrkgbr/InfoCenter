using System.ComponentModel.DataAnnotations;

namespace InfoCenter.Api.DTOs.Contract;

public record UpdateContractDTO
(
    [Required]
    int Id,

    [Required]
    [MaxLength(10, ErrorMessage = "Contract Number cannot be longer than 10 characters")]
    string ContractNumber,

    [Required]
    [MaxLength(50, ErrorMessage = "Name cannot be longer than 50 characters")]
    string Name,

    [MaxLength(150, ErrorMessage = "Description cannot be longer than 150 characters")]
    string? Description,

    [Required]
    DateOnly StartDate,

    [Required]
    DateOnly EndDate,

    [Required]
    bool IsActive
);