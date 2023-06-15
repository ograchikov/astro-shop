namespace AstroQA.TestSdk.Selenix.Helpers;

using AstroQA.TestSdk.Common.Logging;
using AstroQA.TestSdk.Selenix.Waiter;
using OpenQA.Selenium;

public class NavigationHelper : INavigationHelper
{
	private readonly IWebDriver _driver;
	private readonly ISelenuimWaiter _waiter;
	private readonly ITestLogger _logger;

	public NavigationHelper(
		IWebDriver driver, 
		ISelenuimWaiter waiter,
		ITestLogger logger)
	{
		_driver = driver;
		_waiter = waiter;
		_logger = logger;
	}

	public IAlert SwitchToAlert(TimeSpan? customTimeout = null)
	{
		_waiter.WaitForAlert(customTimeout);
		try
		{
			return _driver.SwitchTo().Alert();
		}
		catch (NoAlertPresentException e)
		{
			_logger.Error(e.Message);
			throw;
		}
	}
}