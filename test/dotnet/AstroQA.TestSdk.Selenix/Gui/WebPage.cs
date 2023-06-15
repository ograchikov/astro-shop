namespace AstroQA.TestSdk.Selenix.Gui;

using AstroQA.TestSdk.Selenix.Waiter;
using OpenQA.Selenium;

public abstract class WebPage : IWebPage
{
	protected readonly IWebDriver _driver;
	protected readonly ISelenuimWaiter _waiter;

	protected WebPage(IWebDriver driver, ISelenuimWaiter waiter, string url)
	{
		_driver = driver;
		_waiter = waiter;
		Url = url;
	}

	public string Url { get; }

	public string Title => _driver.Title;

	public void Open()
	{
		_driver.Navigate().GoToUrl(Url);
		_waiter.WaitDocumentReadyState();
	}

	public void Close() => _driver.Quit();
}