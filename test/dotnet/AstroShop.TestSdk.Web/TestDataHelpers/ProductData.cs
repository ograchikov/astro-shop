namespace AstroShop.TestSdk.Web.TestDataHelpers;

using AstroShop.TestSdk.Domain.Model;

public class ProductData
{
	public ProductData(ProductInfo[] products)
	{
		Products = products;
	}

	public ProductInfo[] Products { get; }
}