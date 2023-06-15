namespace AstroShop.TestSdk.Web.View;

using AstroShop.TestSdk.Domain.Model;

public interface IProductCardView
{
	ProductInfo GetProductInfo();
	IPopupGalleryView ViewProduct();
	IProductCardView AddToCart();
}