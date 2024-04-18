using System.ComponentModel.DataAnnotations;

namespace InfoCenter.Api.DTOs.Article
{
    public class UpdateArticleDTO
    {
        [Required]
        [MaxLength(10, ErrorMessage = "Sap Number cannot be longer than 10 characters")]
        public string SapNumber { get; set; } = string.Empty;

        [Required]
        [MaxLength(10, ErrorMessage = "Sap Number cannot be longer than 10 characters")]
        public string Name { get; set; } = string.Empty;

        [MaxLength(150, ErrorMessage = "Sap Number cannot be longer than 150 characters")]
        public string? Description { get; set; }

        [Required]
        public bool IsActive { get; set; }

        [Required]
        public int UnitId { get; set; }
    }
}