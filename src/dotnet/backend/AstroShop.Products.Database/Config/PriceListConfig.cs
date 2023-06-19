namespace AstroShop.Products.Database.Config;

using AstroShop.Products.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class PriceListConfig : IEntityTypeConfiguration<PriceList>
{
	public void Configure(EntityTypeBuilder<PriceList> builder)
	{
		builder.HasKey(p => p.PriceListId);
		builder.Property(p => p.PriceListName).IsRequired();
		builder.Property(p => p.Description).HasMaxLength(500);
	}
}