namespace AstroShop.UiTests.Tests;

using AstroShop.UiTests.Infra;
using AstroShop.UiTests.TestData;
using NUnit.Framework;

/// <summary>
/// Same browser for all tests in fixture.
/// </summary>
[Parallelizable(ParallelScope.None)]
public class StorefrontTests : TestBase
{
	[Test]
	public void StorefrontOpened_CorrectTitle()
	{
		AstroShop.Web.Storefront.Open();
		Asserts.WebPage.TitleEquals(
			WebpageTitles.StroefrontTitle,
			AstroShop.Web.Storefront.Title);
	}

	[Test]
	public void StorefrontOpened_CorrectHeader()
	{
		AstroShop.Web.Storefront.Open();
		Asserts.WebPage.TitleEquals(
			WebpageTitles.StroefrontWelcomeMessage,
			AstroShop.Web.Storefront.GetHeader());
	}
}