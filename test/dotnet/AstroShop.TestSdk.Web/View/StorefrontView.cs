namespace AstroShop.TestSdk.Web.View;

using AstroQA.TestSdk.Common.StringHelpers;
using AstroQA.TestSdk.Selenix.Gui;
using AstroQA.TestSdk.Selenix.Helpers;
using AstroQA.TestSdk.Selenix.Waiter;
using AstroShop.TestSdk.Domain.Model;
using AstroShop.TestSdk.Web.Domain;
using OpenQA.Selenium;

public class StorefrontView : WebPage, IStorefrontView
{
	private readonly By _headerLocator = By.CssSelector("h1");
	private readonly By _cartButtonLocator = By.Id("cart-button");
	private readonly By _productsLocator = By.ClassName("product-card");
	private readonly By _productNameLocator = By.CssSelector("p[name='product-name']");
	private readonly By _productPriceLocator = By.CssSelector("p[name='product-price']");
	private readonly By _addButtonLocator = By.CssSelector("[name='add-to-cart']");
	private readonly string _productIdName = "product-id";
	private readonly CurrencyParser _currencyParser;

	private readonly IProductCartView _cartView;

	private readonly IInteractionHelper _interaction;

	public StorefrontView(
		IWebDriver driver,
		ISelenuimWaiter waiter,
		IProductCartView cartView,
		IInteractionHelper interaction,
		CurrencyParser currencyParser,
		AstroShopBaseUrl url)
		: base(driver, waiter, url.Value)
	{
		_cartView = cartView;
		_interaction = interaction;
		_currencyParser = currencyParser;
	}

	public string GetHeader()
	{
		return _driver.FindElement(_headerLocator).Text;
	}

	public IStorefrontView ViewProduct(string productName)
	{
		return this;
	}

	public IStorefrontView AddProductToCart(string productName)
	{
		var productCard = _driver.FindElement(
			By.XPath($"//li[@class='product-card']//p[@name='product-name' and text()='{productName}']//ancestor::li[@class='product-card']"));
		var n = productCard.Text;
		var addToCartButton = productCard.FindElement(_addButtonLocator);
		addToCartButton.Click();
		return this;
	}

	public IProductCartView OpenCart()
	{
		_interaction.Click(_cartButtonLocator);
		return _cartView;
	}

	public ProductInfo[] GetProductsInfo()
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
}