namespace AstroShop.TestSdk.Database.Configs;

using AstroShop.TestSdk.Domain.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class ProductInfoConfig : IEntityTypeConfiguration<ProductInfo>
{
	public void Configure(EntityTypeBuilder<ProductInfo> builder)
	{
		builder.ToTable("ProductInfo");
		builder.HasKey(p => p.ProductId);
		builder.Property(p => p.Name).IsRequired().HasMaxLength(250);
		builder.Property(p => p.Price).HasColumnType("decimal(18,2)");
	}
}