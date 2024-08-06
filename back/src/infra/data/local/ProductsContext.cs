using Microsoft.EntityFrameworkCore;

namespace Tariff.Comparison.Data.Local;

public class ProductsContext(DbContextOptions options) : DbContext(options)
{
}
