namespace AstroShop.Products.Database.Context;

using AstroShop.Products.Domain.Entities;
using Microsoft.EntityFrameworkCore;

public class ProductsDbContext : DbContext, IProductsDbContext
{
	public DbSet<ProductInfo> ProductInfos { get; set; } = null!;
	public DbSet<PriceList> PriceLists { get; set; } = null!;
	public DbSet<ProductPrice> ProductPrices { get; set; } = null!;

	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		base.OnModelCreating(modelBuilder);

		modelBuilder.ApplyConfigurationsFromAssembly(typeof(ProductsDbContext).Assembly);

		modelBuilder.Entity<ProductInfo>()
			.Property(p => p.MarketType)
			.HasConversion<int>();
	}
}