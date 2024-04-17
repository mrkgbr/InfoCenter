namespace InfoCenter.Api.DTOs.Unit;

public class UnitDTO
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public string? Description { get; set; }
    public bool IsActive { get; set; }
}