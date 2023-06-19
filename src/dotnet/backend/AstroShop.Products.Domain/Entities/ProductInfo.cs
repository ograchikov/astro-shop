namespace AstroShop.Products.Domain.Entities;

using AstroShop.Products.Domain.Catalogs;

public class ProductInfo
{
	public int ProductId { get; set; }
	public string ProductCode { get; set; } = string.Empty;
	public MarketType MarketType { get; set; }
	public string Name { get; set; } = string.Empty;
	public string? Description { get; set; }

	public virtual ICollection<ProductPrice>? ProductPrices { get; set; }
}