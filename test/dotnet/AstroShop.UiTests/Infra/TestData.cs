namespace AstroShop.UiTests.Infra;

using AstroQA.TestSdk.Common.Data;
using AstroShop.TestSdk.Web.TestDataHelpers;

public class TestData
{
	private readonly Lazy<Task<ProductData>> lazyProductDataLoader;

	public Task<ProductData> GetProductData() => lazyProductDataLoader.Value;

	public TestData(ILoader<ProductData> productDataLoader)
	{
		lazyProductDataLoader = new Lazy<Task<ProductData>>(async () => await productDataLoader.Load());
	}
}