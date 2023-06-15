namespace AstroShop.UiTests.Infra;

using AstroQA.TestSdk.Common.Composition;
using AstroQA.TestSdk.Common.Configuration;
using AstroQA.TestSdk.Common.StringHelpers;
using AstroQA.TestSdk.Selenix.Composition;
using AstroQA.TestSdk.Selenix.Domain;
using AstroShop.TestSdk.Web.Composition;
using AstroShop.TestSdk.Web.Domain;
using Autofac;
using NUnit.Framework;

public class TestBase
{
	private IContainer _container = null!;

	/// <summary>Test fixture lifetime scope AstroShopTestHelper.</summary>
	protected TestHelper AstroShop { get; private set; } = null!;

	protected TestSettings Settings { get; private set; } = null!;

	protected AssertHelper Asserts { get; private set; } = null!;

	/// <summary>Begins new test lifetime scope.</summary>
	/// <returns>Test lifetime scope container.</returns>
	public ILifetimeScope NewScope() => _container.BeginLifetimeScope();

	[OneTimeSetUp]
	public async Task Setup()
	{
		// Test Settings
		var settings = await TestSettingsProvider.Settings.Value;
		Settings = new TestSettings(new SettingsProvider(settings));
		
		// Test SDK
		var services = new ContainerBuilder()
			.AddAstroShopTestSdk()
			.AddWebDriverManager()
			.AddSeleniumWebDriver(WebDriverType.Chrome)
			.AddSeleniumHelpers()
			.AddWebViews()
			.AddSeleniumWaiter(
				Settings.WebDriverSleepTime,
				Settings.WebDriverTimeout)
			.AddTestLogger();

		services.RegisterType<CurrencyParser>().SingleInstance();
		services.RegisterInstance(new AstroShopBaseUrl(Settings.AstroShopBaseUrl));
		services.RegisterType<TestHelper>().InstancePerLifetimeScope();

		// Asserts
		services.AddWebPageAsserts();
		services.AddAstroShopAsserts();
		services.RegisterType<AssertHelper>().SingleInstance();

		var provider = services.Build();
		
		_container = provider;

		AstroShop = _container.Resolve<TestHelper>();
		Asserts = _container.Resolve<AssertHelper>();
	}

	[OneTimeTearDown]
	public void CartTestsTeardown()
	{
		AstroShop.Dispose();
	}
}