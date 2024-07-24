using InfoCenter.Api.Models;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InfoCenter.Api.Data.EfConfigs;

public class ContractEntityTypeConfig : IEntityTypeConfiguration<Contract>
{
    public void Configure(EntityTypeBuilder<Contract> builder)
    {
        builder.HasIndex(c => c.ContractNumber).IsUnique();
        builder.Property(c => c.ContractNumber).HasMaxLength(10).IsRequired();

        builder.Property(c => c.Name).IsRequired();

        builder.Property(c => c.StartDate).IsRequired();

        builder.Property(c => c.EndDate).IsRequired();

        builder.Property(c => c.IsActive).IsRequired();
    }
}