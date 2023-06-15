namespace AstroQA.TestSdk.Selenix.Composition;

using Autofac;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;

public static class WebDriverComposition
{
	public static ContainerBuilder AddChromeDriver(
		this ContainerBuilder containerBuilder,
		string chromeDriverPath,
		ChromeOptions? chromeOptions = null)
	{
		containerBuilder.Register(_ =>
			{
				chromeOptions ??= new ChromeOptions();
				return new ChromeDriver(chromeDriverPath, chromeOptions);
			})
			.As<IWebDriver>()
			.InstancePerDependency();
		return containerBuilder;
	}

	public static ContainerBuilder AddFirefoxDriver(
		this ContainerBuilder containerBuilder,
		string firefoxDriverPath,
		FirefoxOptions? firefoxOptions = null)
	{
		containerBuilder.Register(_ =>
			{
				firefoxOptions ??= new FirefoxOptions();
				firefoxOptions.PageLoadStrategy = PageLoadStrategy.Default;
				return new FirefoxDriver(firefoxDriverPath, firefoxOptions);
			})
			.As<IWebDriver>()
			.InstancePerDependency();
		return containerBuilder;
	}
}