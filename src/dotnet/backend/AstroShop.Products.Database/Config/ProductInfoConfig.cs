namespace AstroShop.Products.Database.Config;

using AstroShop.Products.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

public class ProductInfoConfig : IEntityTypeConfiguration<ProductInfo>
{
	public void Configure(EntityTypeBuilder<ProductInfo> builder)
	{
		builder.HasKey(p => p.ProductId);
		builder.Property(p => p.ProductCode).IsRequired();
		builder.Property(p => p.MarketType).IsRequired();
		builder.Property(p => p.Name).IsRequired();
		builder.Property(p => p.Description).HasMaxLength(500);
	}
}