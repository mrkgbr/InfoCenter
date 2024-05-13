namespace InfoCenter.Api.DTOs.Contract;

public class ContractDTO
{
    public int Id { get; set; }

    public string ContractNumber { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public string? Description { get; set; }
    public DateOnly StartDate { get; set; }
    public DateOnly EndDate { get; set; }
    public bool IsActive { get; set; }
}