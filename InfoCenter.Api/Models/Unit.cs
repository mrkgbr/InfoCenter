using Microsoft.EntityFrameworkCore;

namespace InfoCenter.Api.Models;

[Index(nameof(Name), IsUnique = true)]
public class Unit
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string? Description { get; set; }
    public bool IsActive { get; set; } = true;

    public virtual ICollection<Article> Articles { get; set; } = new List<Article>();
}
