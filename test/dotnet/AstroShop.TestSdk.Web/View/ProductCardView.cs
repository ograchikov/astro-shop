namespace AstroShop.TestSdk.Web.View;

using AstroQA.TestSdk.Selenix.Gui;
using AstroQA.TestSdk.Selenix.Helpers;
using AstroQA.TestSdk.Selenix.Waiter;
using AstroShop.TestSdk.Domain.Model;
using OpenQA.Selenium;

public class ProductCardView : WebPage, IProductCardView
{
	private readonly By _productImageLocator = By.CssSelector("#product-list li.product-card img");
	private readonly By _productNameLocator = By.CssSelector("#product-list li.product-card p:first-child");
	private readonly By _productPriceLocator = By.CssSelector("#product-list li.product-card p:last-child");
	private readonly By _addToCartButtonLocator = By.CssSelector("#product-list li.product-card button");

	private readonly IPopupGalleryView _popupGalleryView;

	private readonly IInteractionHelper _interaction;

	public ProductCardView(
		IWebDriver driver, 
		ISelenuimWaiter waiter, 
		IInteractionHelper interaction,
		IPopupGalleryView popupGalleryView,
		string url = "")
		: base(driver, waiter, url)
	{
		_interaction = interaction;
		_popupGalleryView = popupGalleryView;
	}

	public ProductInfo GetProductInfo()
	{
		var productName = _driver.FindElement(_productNameLocator).Text;
		var productPrice = decimal.Parse(_driver.FindElement(_productPriceLocator).Text.TrimStart('$'));
		return new ProductInfo { Name = productName, Price = productPrice };
	}

	public IPopupGalleryView ViewProduct()
	{
		_interaction.Click(_productImageLocator);
		return _popupGalleryView;
	}

	public IProductCardView AddToCart()
	{
		_driver.FindElement(_addToCartButtonLocator).Click();
		return this;
	}
}