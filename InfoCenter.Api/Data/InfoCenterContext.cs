using InfoCenter.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace InfoCenter.Api;

public class InfoCenterContext(DbContextOptions<InfoCenterContext> options) : DbContext(options)
{
    public DbSet<Contract> Contracts { get; set; }
    public DbSet<Currency> Currencies { get; set; }
    public DbSet<Unit> Units { get; set; }
    public DbSet<Article> Articles { get; set; }
}
