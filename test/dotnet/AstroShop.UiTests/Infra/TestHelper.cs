namespace AstroShop.UiTests.Infra;

using AstroShop.TestSdk.Web.TestContracts;
using OpenQA.Selenium;

public class TestHelper : IDisposable, IAsyncDisposable
{
	private readonly IWebDriver _driver;

	public TestHelper(IAstroShopWebHelper astroShop, IWebDriver driver)
	{
		Web = astroShop;
		_driver = driver;
	}

	public IAstroShopWebHelper Web { get; }

	public void Dispose()
	{
		_driver.Quit();
		_driver.Dispose();
	}

	public ValueTask DisposeAsync()
	{
		Dispose();
		return default;
	}
}