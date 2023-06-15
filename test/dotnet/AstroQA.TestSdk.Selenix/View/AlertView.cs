namespace AstroQA.TestSdk.Selenix.View;

using AstroQA.TestSdk.Common.Validation;
using AstroQA.TestSdk.Selenix.Gui;
using AstroQA.TestSdk.Selenix.Helpers;
using AstroQA.TestSdk.Selenix.Waiter;
using OpenQA.Selenium;

public class AlertView : WebPageElement, IAlertView
{
	private readonly INavigationHelper _navigation;
	private IAlert? _alert;

	public AlertView(
		IWebDriver driver, 
		ISelenuimWaiter waiter,
		INavigationHelper navigation)
		: base(driver, waiter)
	{
		_navigation = navigation;
	}

	public void Open()
	{
		_alert = _navigation.SwitchToAlert();
	}

	public string GeText()
	{
		Guard.NotNull(_alert, "Alert");
		return _alert?.Text ?? string.Empty;
	}
}