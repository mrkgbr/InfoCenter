﻿namespace InfoCenter.Api.Models;

public class Unit
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string? Description { get; set; }
    public bool IsActive { get; set; } = true;

    public virtual IList<Article> Articles { get; set; } = [];
}
