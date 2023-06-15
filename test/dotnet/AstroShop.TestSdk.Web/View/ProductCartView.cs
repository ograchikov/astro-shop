namespace AstroShop.TestSdk.Web.View;

using AstroQA.TestSdk.Common.StringHelpers;
using AstroQA.TestSdk.Selenix.Gui;
using AstroQA.TestSdk.Selenix.Helpers;
using AstroQA.TestSdk.Selenix.Waiter;
using AstroShop.TestSdk.Domain.Model;
using OpenQA.Selenium;

public class ProductCartView : WebPageElement, IProductCartView
{
	private readonly By _checkoutButtonLocator = By.Id("checkout-button");
	private readonly By _cartListLocator = By.Id("cart-list");

	private readonly By _productsLocator = By.ClassName("product-card");
	private readonly By _productNameLocator = By.CssSelector("p[name='product-name']");
	private readonly By _productPriceLocator = By.CssSelector("p[name='product-price']");
	private readonly By _removeButtonLocator = By.CssSelector("[name='remove-from-cart']");
	private readonly string _productIdName = "product-id";

	private readonly IOverlayPopupView _overlayPopupView;
	private readonly IInteractionHelper _interaction;

	private readonly CurrencyParser _currencyParser;

	public ProductCartView(
		IWebDriver driver, 
		ISelenuimWaiter waiter,
		IOverlayPopupView overlayPopupView, 
		IInteractionHelper interaction,
		CurrencyParser currencyParser)
		: base(driver, waiter)
	{
		_overlayPopupView = overlayPopupView;
		_interaction = interaction;
		_currencyParser = currencyParser;
	}

	public ProductInfo[] GetProducts()
	{
		var productList = _driver.FindElements(_productsLocator);
		var productsInfo = new List<ProductInfo>();

		foreach (var productElement in productList)
		{
			var idText = productElement.GetAttribute(_productIdName);
			var nameElement = productElement.FindElement(_productNameLocator);
			var priceElement = productElement.FindElement(_productPriceLocator);

			var id = int.Parse(idText);
			var name = nameElement.Text;
			var currencyString = priceElement.Text;
			var price = _currencyParser.ParseUsdString(currencyString);

			var productInfo = new ProductInfo
			{
				ProductId = id,
				Name = name,
				Price = price
			};

			productsInfo.Add(productInfo);
		}

		return productsInfo.ToArray();
	}

	public IProductCartView RemoveProduct(string productName)
	{
		var cartList = _waiter.WaitVisible(_cartListLocator);
		var productCards = cartList.FindElements(By.CssSelector("li.productInfo-card"));

		foreach (var productCard in productCards)
		{
			var name = productCard.Text.Split('-')[0].Trim();
			if (name != productName) continue;
			var removeButton = productCard.FindElement(_removeButtonLocator);
			removeButton.Click();
			break;
		}
		return this;
	}

	public void Checkout() => _interaction.Click(_checkoutButtonLocator);

	public void CloseBySideClick() => _overlayPopupView.CloseBySideClick();

	public void CloseByEscape() => _overlayPopupView.CloseByEscape();
}