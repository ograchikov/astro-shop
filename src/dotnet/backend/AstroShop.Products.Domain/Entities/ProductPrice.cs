namespace AstroShop.Products.Domain.Entities;

public class ProductPrice
{
	public int ProductPriceId { get; set; }
	public string ProductCode { get; set; } = string.Empty;
	public string PriceListName { get; set; } = string.Empty;
	public decimal? Price { get; set; }

	public virtual PriceList? PriceList { get; set; }
	public virtual ProductInfo? ProductInfo { get; set; }
}