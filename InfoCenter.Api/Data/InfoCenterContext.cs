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
    //         .Entity<Unit>()
    //         .HasIndex(u => u.Name)
    //         .IsUnique();

    //     modelBuilder
    //         .Entity<Article>()
    //         .HasOne(u => u.Unit)
    //         .WithMany(a => a.Articles)
    //         .HasForeignKey(u => u.UnitId)
    //         .IsRequired()
    //         .OnDelete(DeleteBehavior.Restrict); // Prevent cascade delete
    // }
}
