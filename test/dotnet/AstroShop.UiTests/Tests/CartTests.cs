namespace AstroShop.UiTests.Tests;

using AstroShop.UiTests.Infra;
using AstroShop.UiTests.TestData;
using NUnit.Framework;

/// <summary>
/// New browser and test scope for each test run in parallel.
/// </summary>
public class CartTests : TestBase
{
	[Test]
	public async Task CheckoutSingleProduct_CorrectTotal()
	{
		await using var scope = NewScope();
		var astroShop = scope.GetAstroShop();

		astroShop.Web.Storefront.Open();
		astroShop.Web.Storefront.AddProductToCart(ProductNames.AiArt1);
		var cart = astroShop.Web.Storefront.OpenCart();
		cart.Checkout();

		astroShop.Web.Alert.Open();
		var totalPriceMessage = astroShop.Web.Alert.GeText();
		Assert.AreEqual(totalPriceMessage, "Total: 10");
	}

	[Test]
	public async Task CheckoutSameProductTwice_CorrectTotal()
	{
		await using var scope = NewScope();
		var astroShop = scope.GetAstroShop();

		astroShop.Web.Storefront.Open();
		astroShop.Web.Storefront.AddProductToCart(ProductNames.AiArt1);
		astroShop.Web.Storefront.AddProductToCart(ProductNames.AiArt1);
		var cart = astroShop.Web.Storefront.OpenCart();
		cart.Checkout();

		astroShop.Web.Alert.Open();
		var totalPriceMessage = astroShop.Web.Alert.GeText();
		Assert.AreEqual(totalPriceMessage, "Total: 20");
	}

	[Test]
	public async Task CheckoutVariousProducts_CorrectTotal()
	{
		await using var scope = NewScope();
		var astroShop = scope.GetAstroShop();

		astroShop.Web.Storefront.Open();
		astroShop.Web.Storefront.AddProductToCart(ProductNames.AiArt1);
		astroShop.Web.Storefront.AddProductToCart(ProductNames.AiArt2);
		var cart = astroShop.Web.Storefront.OpenCart();
		cart.Checkout();

		astroShop.Web.Alert.Open();
		var totalPriceMessage = astroShop.Web.Alert.GeText();
		Assert.AreEqual(totalPriceMessage, "Total: 40");
	}
}