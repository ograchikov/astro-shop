namespace AstroShop.Products.Database.Config;

using AstroShop.Products.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class ProductPriceConfig : IEntityTypeConfiguration<ProductPrice>
{
	public void Configure(EntityTypeBuilder<ProductPrice> builder)
	{
		builder.HasKey(p => p.ProductPriceId);

		builder.HasOne(pp => pp.PriceList)
			.WithMany(p => p.ProductPrices)
			.HasForeignKey(pp => pp.PriceListName);

		builder.HasOne(pp => pp.ProductInfo)
			.WithMany(p => p.ProductPrices)
			.HasForeignKey(pp => pp.ProductCode);
	}
}