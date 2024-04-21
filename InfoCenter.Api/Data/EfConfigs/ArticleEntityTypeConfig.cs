using InfoCenter.Api.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InfoCenter.Api.Data.EfConfigs;

public class ArticleEntityTypeConfig : IEntityTypeConfiguration<Article>
{
    public void Configure(EntityTypeBuilder<Article> builder)
    {
        builder
            .HasOne(u => u.Unit)
            .WithMany(a => a.Articles)
            .HasForeignKey(u => u.UnitId)
            .IsRequired()
            .OnDelete(DeleteBehavior.Restrict);

        builder.Property(u => u.SapNumber).HasMaxLength(10).IsRequired();
        builder.HasIndex(u => u.SapNumber).IsUnique();

        builder.Property(u => u.Name).HasMaxLength(50).IsRequired();
        builder.HasIndex(u => u.Name).IsUnique();
    }
}
