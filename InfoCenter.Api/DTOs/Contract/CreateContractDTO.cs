using System.ComponentModel.DataAnnotations;

namespace InfoCenter.Api.DTOs.Contract;

public class CreateContractDTO
{
    [Required]
    [MaxLength(10, ErrorMessage = "Contract Number cannot be longer than 10 characters")]
    public string ContractNumber { get; set; } = string.Empty;

    [Required]
    [MaxLength(50, ErrorMessage = "Name cannot be longer than 50 characters")]
    public string Name { get; set; } = string.Empty;

    [MaxLength(150, ErrorMessage = "Description cannot be longer than 150 characters")]
    public string? Description { get; set; }

    [Required]
    public DateOnly StartDate { get; set; }

    [Required]
    public DateOnly EndDate { get; set; }
}