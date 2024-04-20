using InfoCenter.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace InfoCenter.Api;

public class InfoCenterContext(DbContextOptions<InfoCenterContext> options) : DbContext(options)
{
    public DbSet<Contract> Contracts { get; set; }
    public DbSet<Currency> Currencies { get; set; }
    public DbSet<Unit> Units { get; set; }
    public DbSet<Article> Articles { get; set; }

    // Prevent delete using fluent API
    // protected override void OnModelCreating(ModelBuilder modelBuilder)
    // {
    //     modelBuilder
    //         .Entity<Article>()
    //         .HasOne(u => u.Unit)
    //         .WithMany(a => a.Articles)
    //         .HasForeignKey(a => a.UnitId)
    //         .OnDelete(DeleteBehavior.Restrict); // Prevent cascade delete
    // }
}
