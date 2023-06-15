namespace AstroQA.TestSdk.Selenix.Composition;

using AstroQA.TestSdk.Selenix.Domain;
using AstroQA.TestSdk.Selenix.Helpers;
using AstroQA.TestSdk.Selenix.View;
using AstroQA.TestSdk.Selenix.Waiter;
using Autofac;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

public static class SeleniumComposition
{
	public static ContainerBuilder AddSeleniumWebDriver(
		this ContainerBuilder containerBuilder,
		WebDriverType driverType) =>
		driverType switch
		{
			WebDriverType.Chrome => AddChromeDriverPeLifetimeScope(containerBuilder),
			WebDriverType.Firefox => AddFirefoxDriverPeLifetimeScope(containerBuilder),
			_ => throw new ArgumentOutOfRangeException(nameof(driverType), driverType, null)
		};

	public static ContainerBuilder AddChromeDriverPeLifetimeScope(
		this ContainerBuilder containerBuilder)
	{
		containerBuilder
			.RegisterType<ChromeDriver>()
			.As<WebDriver>()
			.As<IWebDriver>()
			.InstancePerLifetimeScope();
		return containerBuilder;
	}

	public static ContainerBuilder AddFirefoxDriverPeLifetimeScope(
		this ContainerBuilder containerBuilder)
	{
		containerBuilder
			.RegisterType<FirefoxDriver>()
			.As<WebDriver>()
			.As<IWebDriver>()
			.InstancePerLifetimeScope();
		return containerBuilder;
	}

	public static ContainerBuilder AddSeleniumHelpers(this ContainerBuilder containerBuilder)
	{
		containerBuilder.RegisterType<InteractionHelper>()
			.As<IInteractionHelper>()
			.InstancePerLifetimeScope();
		containerBuilder.RegisterType<JavaScriptHelper>()
			.As<IJavaScriptHelper>()
			.InstancePerLifetimeScope();
		containerBuilder.RegisterType<NavigationHelper>()
			.As<INavigationHelper>()
			.InstancePerLifetimeScope();
		containerBuilder.RegisterType<SearchHelper>()
			.As<ISearchHelper>()
			.InstancePerLifetimeScope();
		containerBuilder.RegisterType<VisualizationHelper>()
			.As<IVisualizationHelper>()
			.InstancePerLifetimeScope();
		return containerBuilder;
	}

	public static ContainerBuilder AddWebViews(this ContainerBuilder containerBuilder)
	{
		containerBuilder
			.RegisterType<AlertView>()
			.As<IAlertView>()
			.InstancePerLifetimeScope();
		return containerBuilder;
	}

	public static ContainerBuilder AddSeleniumWaiter(
		this ContainerBuilder containerBuilder,
		TimeSpan defaultSleepTime,
		TimeSpan defaultTimeout,
		IClock? customClock = null)
	{
		containerBuilder
			.RegisterInstance(customClock ?? new SystemClock())
			.As<IClock>();
		containerBuilder
			.RegisterInstance(new WebDriverTimeout(defaultTimeout));
		containerBuilder
			.RegisterInstance(new WebDriverSleepTime(defaultSleepTime));
		containerBuilder
			.RegisterType<SelenuimWaiter>()
			.As<ISelenuimWaiter>()
			.InstancePerLifetimeScope();

		containerBuilder
			.Register(c => new WebDriverWait(
				c.Resolve<IClock>(),
				c.Resolve<IWebDriver>(),
				c.Resolve<WebDriverTimeout>().Value,
				c.Resolve<WebDriverSleepTime>().Value))
			.As<IWait<IWebDriver>>()
			.InstancePerLifetimeScope();

		return containerBuilder;
	}
}