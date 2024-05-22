namespace InfoCenter.Api;

public record ArticleSummaryDTO
(
    int Id,
    string SapNumber,
    string Name,
    string? Description,
    bool IsActive,
    string Unit
);