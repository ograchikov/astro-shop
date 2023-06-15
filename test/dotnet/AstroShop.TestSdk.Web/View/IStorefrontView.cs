namespace AstroShop.TestSdk.Web.View;

using AstroQA.TestSdk.Selenix.Gui;
using AstroShop.TestSdk.Domain.Model;

public interface IStorefrontView : IWebPage
{
	string GetHeader();
	IStorefrontView ViewProduct(string productName);
	IStorefrontView AddProductToCart(string productName);
	IProductCartView OpenCart();
	ProductInfo[] GetProductsInfo();
}