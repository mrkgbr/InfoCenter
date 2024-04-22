using InfoCenter.Api.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InfoCenter.Api.Data.EfConfigs;

public class ArticleEntityTypeConfig : IEntityTypeConfiguration<Article>
{
    public void Configure(EntityTypeBuilder<Article> builder)
    {
        builder
            .HasOne(a => a.Unit)
            .WithMany(a => a.Articles)
            .HasForeignKey(a => a.UnitId)
            .IsRequired()
            .OnDelete(DeleteBehavior.Restrict);

        builder.Property(a => a.SapNumber).HasMaxLength(10).IsRequired();
        builder.HasIndex(a => a.SapNumber).IsUnique();

        builder.Property(a => a.Name).HasMaxLength(50).IsRequired();
        builder.HasIndex(a => a.Name).IsUnique();
    }
}
