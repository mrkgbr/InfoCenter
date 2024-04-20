using Microsoft.EntityFrameworkCore;

namespace InfoCenter.Api.Models;

public class Article
{
    public int Id { get; set; }

    public string SapNumber { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public string? Description { get; set; }
    public bool IsActive { get; set; } = true;

    public int UnitId { get; set; }
    [DeleteBehavior(DeleteBehavior.Restrict)]
    public virtual Unit Unit { get; set; } = null!;
}
