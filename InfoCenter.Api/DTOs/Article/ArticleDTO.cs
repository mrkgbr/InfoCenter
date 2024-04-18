namespace InfoCenter.Api.DTOs.Article
{
    public class ArticleDTO
    {
        public int Id { get; set; }
        public string SapNumber { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
        public bool IsActive { get; set; }
        public int UnitId { get; set; }
    }
}
