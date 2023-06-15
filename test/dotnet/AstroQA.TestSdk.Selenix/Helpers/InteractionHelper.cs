namespace AstroQA.TestSdk.Selenix.Helpers;

using AstroQA.TestSdk.Common.Exceptions;
using AstroQA.TestSdk.Common.Logging;
using AstroQA.TestSdk.Selenix.Waiter;
using OpenQA.Selenium;

public class InteractionHelper : IInteractionHelper
{
	private readonly ISelenuimWaiter _waiter;
	private readonly IVisualizationHelper _visualization;
	private readonly ITestLogger _logger;

	public InteractionHelper(
		ISelenuimWaiter waiter,
		ITestLogger logger, 
		IVisualizationHelper visualization)
	{
		_waiter = waiter;
		_logger = logger;
		_visualization = visualization;
	}

	public IWebElement Click(By locator)
	{
		var element = _waiter.WaitClickable(locator);
		_visualization.HighLight(element);
		element.Click();
		_logger.Trace($"Click by '{locator}'.");
		return element;
	}

	public IWebElement Type(By locator, string text)
	{
		var element = CheckEnabled(_waiter.WaitClickable(locator), locator);
		element.SendKeys(text);
		_logger.Trace($"Type text '{text}' by '{locator}'.");
		return element;
	}

	public IWebElement ClearAndType(By locator, string text)
	{
		var element = CheckEnabled(_waiter.WaitClickable(locator), locator);
		element.Clear();
		element.SendKeys(text);
		_logger.Trace($"Type text '{text}' by '{locator}'.");
		return element;
	}

	public IWebElement CheckEnabled(IWebElement element, By locator)
	{
		if (!element.Enabled)
		{
			throw new TestSdkException(
				$"Exception in SendKeys(): element located by '{locator}' not enabled.");
		}
		return element;
	}
} 