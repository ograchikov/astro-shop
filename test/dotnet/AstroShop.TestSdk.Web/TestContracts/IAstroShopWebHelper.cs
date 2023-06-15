namespace AstroShop.TestSdk.Web.TestContracts;

using AstroQA.TestSdk.Selenix.View;
using AstroShop.TestSdk.Web.View;

public interface IAstroShopWebHelper
{
	IStorefrontView Storefront { get; }
	IPopupGalleryView PopupGallery { get; }
	IProductCartView ProductCart { get; }
	IAlertView Alert { get; }
}