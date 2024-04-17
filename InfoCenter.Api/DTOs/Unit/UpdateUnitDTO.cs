namespace InfoCenter.Api.DTOs.Unit;

public class UpdateUnitDTO
{
    public required string Name { get; set; }
    public string? Description { get; set; }
    public bool IsActive { get; set; }
}