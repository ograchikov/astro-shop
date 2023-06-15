namespace AstroShop.TestSdk.Web.View;

using AstroShop.TestSdk.Domain.Model;

public interface IProductCartView : IOverlayPopupView
{
	ProductInfo[] GetProducts();
	IProductCartView RemoveProduct(string productName);
	void Checkout();
}