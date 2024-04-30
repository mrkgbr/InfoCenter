namespace InfoCenter.Api.DTOs.Unit;

public record UnitDTO
(
    int Id,
    string Name,
    string? Description,
    bool IsActive
);
