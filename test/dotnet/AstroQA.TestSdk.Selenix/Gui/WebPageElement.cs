namespace AstroQA.TestSdk.Selenix.Gui;

using AstroQA.TestSdk.Selenix.Waiter;
using OpenQA.Selenium;

public abstract class WebPageElement
{
	protected readonly IWebDriver _driver;
	protected readonly ISelenuimWaiter _waiter;

	protected WebPageElement(
		IWebDriver driver,
		ISelenuimWaiter waiter)
	{
		_driver = driver;
		_waiter = waiter;
	}
}