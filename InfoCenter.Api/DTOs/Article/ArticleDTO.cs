namespace InfoCenter.Api.DTOs.Article;

public record ArticleDTO
(
    int Id,
    string SapNumber,
    string Name,
    string? Description,
    bool IsActive,
    int UnitId
);
