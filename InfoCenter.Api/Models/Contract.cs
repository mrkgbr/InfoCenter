namespace InfoCenter.Api.Models;

public class Contract
{
    public int Id { get; set; }
    public required string ContractNumber { get; set; }
    public required string Name { get; set; }
    public string? Description { get; set; }
    public required DateOnly StartDate { get; set; }
    public required DateOnly EndDate { get; set; }
    public bool IsActive { get; set; }
}
