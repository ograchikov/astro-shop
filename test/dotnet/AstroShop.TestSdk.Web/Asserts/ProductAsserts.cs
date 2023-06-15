namespace AstroShop.TestSdk.Web.Asserts;

using AstroShop.TestSdk.Domain.Model;
using NUnit.Framework;

public class ProductAsserts : IProductAsserts
{
	private readonly ProductInfoComparer _productInfoComparer;

	public ProductAsserts(ProductInfoComparer productInfoComparer)
	{
		_productInfoComparer = productInfoComparer;
	}

	public void ProductsAreEqual(
		IList<ProductInfo> expectedProducts, 
		IList<ProductInfo> actualProducts) =>
		CollectionAssert.AreEqual(
			expectedProducts, 
			actualProducts,
			_productInfoComparer,
			"Products are not equal.");
}