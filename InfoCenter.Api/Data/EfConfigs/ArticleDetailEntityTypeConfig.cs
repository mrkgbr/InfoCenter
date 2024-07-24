using InfoCenter.Api.Models;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InfoCenter.Api.Data.EfConfigs;

public class ArticleDetailEntityTypeConfig : IEntityTypeConfiguration<ArticleDetail>
{
    public void Configure(EntityTypeBuilder<ArticleDetail> builder)
    {
        builder
            .HasOne(a => a.Article)
            .WithMany(a => a.ArticleDetails)
            .HasForeignKey(a => a.ArticleId)
            .IsRequired()
            .OnDelete(DeleteBehavior.Restrict);

        builder
            .HasOne(a => a.Contract)
            .WithMany(a => a.ArticleDetails)
            .HasForeignKey(a => a.ContractId)
            .IsRequired()
            .OnDelete(DeleteBehavior.Restrict);

        builder
            .HasOne(a => a.Currency)
            .WithMany(a => a.ArticleDetails)
            .HasForeignKey(a => a.CurrencyId)
            .IsRequired()
            .OnDelete(DeleteBehavior.Restrict);

        builder.Property(a => a.Price).IsRequired();
    }
}