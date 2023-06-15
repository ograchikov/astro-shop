namespace AstroShop.TestSdk.Web.Asserts
{
	using AstroShop.TestSdk.Domain.Model;

	public interface IProductAsserts
	{
		void ProductsAreEqual(
			IList<ProductInfo> expectedProducts,
			IList<ProductInfo> actualProducts);
	}
}
