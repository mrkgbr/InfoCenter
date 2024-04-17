namespace InfoCenter.Api.DTOs.Article
{
    public class UpdateArticleDTO
    {
        public required string SapNumber { get; set; }
        public required string Name { get; set; }
        public string? Description { get; set; }
        public bool IsActive { get; set; }
        public int UnitId { get; set; }
    }
}