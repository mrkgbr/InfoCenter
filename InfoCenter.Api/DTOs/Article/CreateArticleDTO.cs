using System.ComponentModel.DataAnnotations;

namespace InfoCenter.Api.DTOs.Article;

public class CreateArticleDTO
{
    [Required]
    [MaxLength(10, ErrorMessage = "Sap Number cannot be longer than 10 characters")]
    public required string SapNumber { get; set; }

    [Required]
    [MaxLength(50, ErrorMessage = "Name cannot be longer than 50 characters")]
    public required string Name { get; set; }


    [MaxLength(150, ErrorMessage = "Description cannot be longer than 150 characters")]
    public string? Description { get; set; }

    [Required]
    public int UnitId { get; set; }
}
