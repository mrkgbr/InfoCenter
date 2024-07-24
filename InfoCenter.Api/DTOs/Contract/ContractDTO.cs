namespace InfoCenter.Api.DTOs.Contract;

public class ContractDTO
{
    public int Id { get; set; }
    public required string ContractNumber { get; set; }
    public required string Name { get; set; }
    public string? Description { get; set; }
    public DateOnly StartDate { get; set; }
    public DateOnly EndDate { get; set; }
    public bool IsActive { get; set; }
}