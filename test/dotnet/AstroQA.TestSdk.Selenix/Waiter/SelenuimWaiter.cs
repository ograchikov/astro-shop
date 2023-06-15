namespace AstroQA.TestSdk.Selenix.Waiter;

using AstroQA.TestSdk.Common.Logging;
using AstroQA.TestSdk.Common.Parameters;
using AstroQA.TestSdk.Selenix.Domain;
using AstroQA.TestSdk.Selenix.Helpers;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

public class SelenuimWaiter : ISelenuimWaiter
{
	private readonly IWebDriver _driver;
	private readonly ITestLogger _logger;
	private readonly TimeSpan _defaultTimeout;
	private readonly TimeSpan _defaultSleepTime;
	private readonly IWait<IWebDriver> _waiter;
	private readonly IClock _clock;
	private readonly IJavaScriptHelper _javaScript;

	public SelenuimWaiter(
		IWebDriver driver, 
		ITestLogger logger,
		IJavaScriptHelper javaScript,
		WebDriverSleepTime defaultSleepTime,
		WebDriverTimeout defaultTimeout,
		IWait<IWebDriver> waiter,
		IClock clock)
	{
		_driver = driver;
		_logger = logger;
		_defaultTimeout = defaultTimeout.Value;
		_javaScript = javaScript;
		_defaultSleepTime = defaultSleepTime.Value;
		_clock = clock;
		_waiter = waiter;
	}

	public TResult WaitUntil<TResult>(Func<IWebDriver, TResult> condition, TimeSpan? customTimeout = null) =>
		ExecuteWithTimeout(() => 
			GetCustomWaiterIfNotNull(customTimeout)
			.Until(condition));

	public void WaitDocumentReadyState(TimeSpan? customTimeout = null) =>
		ExecuteWithTimeout(() =>
			GetCustomWaiterIfNotNull(customTimeout)
				.Until(_ => _javaScript
					.ExecuteScript("return document.readyState")
					.Equals("complete")));

	public IAlert WaitForAlert(TimeSpan? customTimeout = null) =>
		ExecuteWithTimeout(() => 
			GetCustomWaiterIfNotNull(customTimeout)
				.Until(ExpectedConditions.AlertIsPresent()));

	public IWebElement WaitVisible(By locator, TimeSpan? customTimeout = null) =>
		ExecuteWithTimeout(() => 
			GetCustomWaiterIfNotNull(customTimeout)
				.Until(ExpectedConditions.ElementIsVisible(locator)));

	public IReadOnlyCollection<IWebElement> WaitAllVisible(By locator, TimeSpan? customTimeout = null) =>
		ExecuteWithTimeout(() =>
			GetCustomWaiterIfNotNull(customTimeout)
				.Until(ExpectedConditions.VisibilityOfAllElementsLocatedBy(locator)));

	public IWebElement WaitClickable(By locator, TimeSpan? customTimeout = null) =>
		ExecuteWithTimeout(() =>
			GetCustomWaiterIfNotNull(customTimeout)
				.Until(ExpectedConditions.ElementToBeClickable(locator)));

	private IWait<IWebDriver> GetCustomWaiterIfNotNull(TimeSpan? customTimeout = null) =>
		customTimeout == null ? 
			_waiter : 
			new WebDriverWait(
				_clock,
				_driver, 
				ParameterHelper.GetCustomIfNotNull(_defaultTimeout, customTimeout), 
				_defaultSleepTime);

	private T ExecuteWithTimeout<T>(Func<T> action)
	{
		try
		{
			return action();
		}
		catch (WebDriverTimeoutException e)
		{
			_logger.Error(e.Message);
			throw;
		}
	}
}