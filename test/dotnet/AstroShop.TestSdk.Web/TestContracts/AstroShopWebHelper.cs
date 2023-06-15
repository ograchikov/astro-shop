namespace AstroShop.TestSdk.Web.TestContracts;

using AstroQA.TestSdk.Selenix.View;
using AstroShop.TestSdk.Web.View;

public class AstroShopWebHelper : IAstroShopWebHelper
{
	public IStorefrontView Storefront { get; }
	public IPopupGalleryView PopupGallery { get; }
	public IProductCartView ProductCart { get; }
	public IAlertView Alert { get; }

	public AstroShopWebHelper(
		IStorefrontView storefront, 
		IPopupGalleryView popupGallery, 
		IProductCartView productCart, 
		IAlertView alert)
	{
		Storefront = storefront;
		PopupGallery = popupGallery;
		ProductCart = productCart;
		Alert = alert;
	}
}