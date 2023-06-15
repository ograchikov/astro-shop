namespace AstroShop.TestSdk.Web.View;

using AstroQA.TestSdk.Selenix.Gui;
using AstroQA.TestSdk.Selenix.Waiter;
using OpenQA.Selenium;

public class OverlayPopupView : WebPageElement, IOverlayPopupView
{
	private readonly By _overlayLocator = By.ClassName("overlay");

	public OverlayPopupView(IWebDriver driver, ISelenuimWaiter waiter)
		: base(driver, waiter)
	{
	}

	public void CloseBySideClick()
	{
		var overlay = _waiter.WaitVisible(_overlayLocator);
		overlay.Click();
	}

	public void CloseByEscape()
	{
		var body = _waiter.WaitVisible(By.TagName("body"));
		body.SendKeys(Keys.Escape);
	}
}