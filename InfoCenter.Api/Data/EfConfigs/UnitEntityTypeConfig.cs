using InfoCenter.Api.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InfoCenter.Api.Data.EfConfigs;

public class UnitEntityTypeConfig : IEntityTypeConfiguration<Unit>
{
    public void Configure(EntityTypeBuilder<Unit> builder)
    {
        builder.Property(u => u.Name).IsRequired();
        builder.HasIndex(u => u.Name).IsUnique();

        builder.Property(u => u.IsActive).IsRequired();
    }
}
