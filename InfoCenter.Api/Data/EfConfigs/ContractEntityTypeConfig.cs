using InfoCenter.Api.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InfoCenter.Api;

public class ContractEntityTypeConfig : IEntityTypeConfiguration<Contract>
{
    public void Configure(EntityTypeBuilder<Contract> builder)
    {
        builder.HasIndex(c => c.ContractNumber).IsUnique();
        builder.Property(c => c.ContractNumber).HasMaxLength(10).IsRequired();

        builder.Property(n => n.Name).IsRequired();

        builder.Property(s => s.StartDate).IsRequired();

        builder.Property(e => e.EndDate).IsRequired();
    }
}
