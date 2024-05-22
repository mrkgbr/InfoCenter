using System.ComponentModel.DataAnnotations;

namespace InfoCenter.Api.DTOs.Article;

    public record CreateArticleDTO
    (
        [Required]
        [MaxLength(10, ErrorMessage = "Sap Number cannot be longer than 10 characters")]
        string SapNumber,

        [Required]
        [MaxLength(50, ErrorMessage = "Name cannot be longer than 50 characters")]
        string Name,

        [MaxLength(150, ErrorMessage = "Description cannot be longer than 150 characters")]
        string? Description,

        [Required]
        int UnitId
    );
