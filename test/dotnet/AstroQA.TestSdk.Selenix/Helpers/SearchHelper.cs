namespace AstroQA.TestSdk.Selenix.Helpers;

using AstroQA.TestSdk.Common.Logging;
using AstroQA.TestSdk.Selenix.Waiter;
using OpenQA.Selenium;

public class SearchHelper : ISearchHelper
{
	private readonly IWebDriver _driver;
	private readonly ISelenuimWaiter _waiter;
	private readonly ITestLogger _logger;

	public SearchHelper(
		IWebDriver driver, 
		ISelenuimWaiter waiter,
		ITestLogger logger)
	{
		_driver = driver;
		_waiter = waiter;
		_logger = logger;
	}

	public bool IsAllElementsVisible(By locator)
	{
		var elements = _driver.FindElements(locator);
		return elements.Count > 0 && elements.All(e => e.Displayed);
	}
}