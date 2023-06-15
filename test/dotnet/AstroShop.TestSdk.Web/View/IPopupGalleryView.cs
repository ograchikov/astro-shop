namespace AstroShop.TestSdk.Web.View;

using AstroShop.TestSdk.Domain.Model;

public interface IPopupGalleryView : IOverlayPopupView
{
	ProductInfo GetCurrentProductInfo();
	IPopupGalleryView NavigateLeft();
	IPopupGalleryView NavigateRight();
}