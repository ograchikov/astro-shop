namespace AstroQA.TestSdk.Selenix.Composition;

using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;
using WebDriverManager.Helpers;

public static class WebDriverManagerExtensions
{
	public const string LatestVersionKey = "Latest";

	public static DriverManager SetUpChromeDriver(
		this DriverManager manager,
		ChromeConfig chromeConfig,
		string version = LatestVersionKey,
		Architecture architecture = Architecture.Auto)
	{
		var binaryPath = manager.SetUpDriver(chromeConfig, version, architecture);
		return manager;
	}
}