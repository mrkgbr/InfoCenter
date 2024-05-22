namespace InfoCenter.Api.DTOs.Contract;

public record ContractDTO
(
    int Id,
    string ContractNumber,
    string Name,
    string? Description,
    DateOnly StartDate,
    DateOnly EndDate,
    bool IsActive
);