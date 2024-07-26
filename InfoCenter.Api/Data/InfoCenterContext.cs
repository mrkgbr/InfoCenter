using InfoCenter.Api.Data.EfConfigs;
using InfoCenter.Api.Models;

using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace InfoCenter.Api.Data;

public class InfoCenterContext : IdentityDbContext
{
    public InfoCenterContext(DbContextOptions<InfoCenterContext> options) : base(options) {}
    public DbSet<Contract> Contracts { get; set; }
    public DbSet<Currency> Currencies { get; set; }
    public DbSet<Unit> Units { get; set; }
    public DbSet<Article> Articles { get; set; }
    public DbSet<ArticleDetail> ArticleDetails { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        new UnitEntityTypeConfig().Configure(modelBuilder.Entity<Unit>());
        new ArticleEntityTypeConfig().Configure(modelBuilder.Entity<Article>());
        new CurrencyEntityTypeConfig().Configure(modelBuilder.Entity<Currency>());
        new ContractEntityTypeConfig().Configure(modelBuilder.Entity<Contract>());
        new ArticleDetailEntityTypeConfig().Configure(modelBuilder.Entity<ArticleDetail>());
    }
}