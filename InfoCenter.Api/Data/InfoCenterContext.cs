using InfoCenter.Api.Data.EfConfigs;
using InfoCenter.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace InfoCenter.Api.Data;

public class InfoCenterContext(DbContextOptions<InfoCenterContext> options) : DbContext(options)
{
    public DbSet<Contract> Contracts { get; set; }
    public DbSet<Currency> Currencies { get; set; }
    public DbSet<Unit> Units { get; set; }
    public DbSet<Article> Articles { get; set; }
    public DbSet<ArticleDetail> ArticleDetails { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        new UnitEntityTypeConfig().Configure(modelBuilder.Entity<Unit>());
        new ArticleEntityTypeConfig().Configure(modelBuilder.Entity<Article>());
        new CurrencyEntityTypeConfig().Configure(modelBuilder.Entity<Currency>());
        new ArticleDetailEntityTypeConfig().Configure(modelBuilder.Entity<ArticleDetail>());
    }
}
