namespace AstroQA.TestSdk.Selenix.Waiter;

using OpenQA.Selenium;

public interface ISelenuimWaiter
{
	TResult WaitUntil<TResult>(Func<IWebDriver, TResult> condition, TimeSpan? customTimeout = null);
	void WaitDocumentReadyState(TimeSpan? customTimeout = null);
	IAlert WaitForAlert(TimeSpan? customTimeout = null);
	IWebElement WaitVisible(By locator, TimeSpan? customTimeout = null);
	IReadOnlyCollection<IWebElement> WaitAllVisible(By locator, TimeSpan? customTimeout = null);
	IWebElement WaitClickable(By locator, TimeSpan? customTimeout = null);
}