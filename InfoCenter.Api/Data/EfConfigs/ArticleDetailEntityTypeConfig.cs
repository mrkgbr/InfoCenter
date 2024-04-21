using InfoCenter.Api.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InfoCenter.Api;

public class ArticleDetailEntityTypeConfig : IEntityTypeConfiguration<ArticleDetail>
{
    public void Configure(EntityTypeBuilder<ArticleDetail> builder)
    {
        builder
            .HasOne(a => a.Article)
            .WithMany(ad => ad.ArticleDetails)
            .HasForeignKey(a => a.ArticleId)
            .IsRequired()
            .OnDelete(DeleteBehavior.Restrict);

        builder
            .HasOne(c => c.Contract)
            .WithMany(ad => ad.ArticleDetails)
            .HasForeignKey(c => c.ContractId)
            .IsRequired()
            .OnDelete(DeleteBehavior.Restrict);

        builder
            .HasOne(c => c.Currency)
            .WithMany(ad => ad.ArticleDetails)
            .HasForeignKey(c => c.CurrencyId)
            .IsRequired()
            .OnDelete(DeleteBehavior.Restrict);

        builder.Property(ad => ad.Price).IsRequired();

        builder.Property(ad => ad.StartDate).IsRequired();

        builder.Property(ad => ad.EndDate).IsRequired();
    }
}
