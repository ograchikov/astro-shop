namespace AstroShop.Products.Domain.Entities;

public class PriceList
{
	public int PriceListId { get; set; }
	public string PriceListName { get; set; } = string.Empty;
	public string? Description { get; set; }
	public DateTime? EnableTime { get; set; }
	public DateTime? DisableTime { get; set; }

	public virtual ICollection<ProductPrice>? ProductPrices { get; set; }
}