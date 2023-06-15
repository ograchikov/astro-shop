namespace AstroShop.TestSdk.Web.View;

using AstroQA.TestSdk.Selenix.Gui;
using AstroQA.TestSdk.Selenix.Helpers;
using AstroQA.TestSdk.Selenix.Waiter;
using AstroShop.TestSdk.Domain.Model;
using OpenQA.Selenium;

public class PopupGalleryView : WebPage, IPopupGalleryView
{
	private readonly By _popupImageLocator = By.CssSelector(".product-popup-image");
	private readonly By _leftArrowLocator = By.CssSelector(".product-popup-arrow.left");
	private readonly By _rightArrowLocator = By.CssSelector(".product-popup-arrow.right");

	private readonly IOverlayPopupView _overlayPopupView;
	private readonly IInteractionHelper _interaction;

	public PopupGalleryView(
		IWebDriver driver, 
		ISelenuimWaiter waiter, 
		IInteractionHelper interaction, 
		IOverlayPopupView overlayPopupView, 
		string url = "")
		: base(driver, waiter, url)
	{
		_interaction = interaction;
		_overlayPopupView = overlayPopupView;
	}

	public ProductInfo GetCurrentProductInfo()
	{
		throw new NotImplementedException();
	}

	public IPopupGalleryView NavigateLeft()
	{
		_interaction.Click(_leftArrowLocator);
		return this;
	}

	public IPopupGalleryView NavigateRight()
	{
		_interaction.Click(_rightArrowLocator);
		return this;
	}

	public void CloseBySideClick() => _overlayPopupView.CloseBySideClick();

	public void CloseByEscape() => _overlayPopupView.CloseByEscape();
}