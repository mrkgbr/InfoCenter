namespace InfoCenter.Api.DTOs.Article
{
    public class CreateArticleDTO
    {
        public required string SapNumber { get; set; }
        public required string Name { get; set; }
        public string? Description { get; set; }
        public int UnitId { get; set; }
    }
}