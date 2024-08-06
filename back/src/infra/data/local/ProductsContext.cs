using System.Text.Json;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Tariff.Comparison.Domain.Model;

namespace Tariff.Comparison.Data.Local;

public class ProductsContext(DbContextOptions options) : DbContext(options)
{
    public DbSet<Product> Products { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity( (EntityTypeBuilder<Product> builder) => {
            builder.HasKey(p => p.Name);
            builder.Property(p => p.Name);
            builder.Property(p => p.RawType);
            builder.ComplexProperty(p => p.TariffDetails);

            builder.Ignore(p => p.Type);
            builder.Ignore(p => p.TypeDescription);
        });
    }
}
