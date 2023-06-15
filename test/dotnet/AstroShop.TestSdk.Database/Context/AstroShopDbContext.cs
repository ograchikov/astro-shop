namespace AstroShop.TestSdk.Database.Context;

using AstroShop.TestSdk.Domain.Model;
using Microsoft.EntityFrameworkCore;

public class AstroShopDbContext : DbContext
{
	public AstroShopDbContext()
	{
	}

	public AstroShopDbContext(DbContextOptions options) : base(options)
	{
	}

	public AstroShopDbContext(DbContextOptions<AstroShopDbContext> options) : base(options)
	{
	}

	public DbSet<ProductInfo> Products { get; set; } = null!;

	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		modelBuilder.ApplyConfigurationsFromAssembly(typeof(AstroShopDbContext).Assembly);
	}
}