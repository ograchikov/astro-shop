namespace AstroShop.UiTests.Infra;

using AstroQA.TestSdk.Common.Configuration;

public class TestSettings
{
	public TimeSpan WebDriverTimeout { get; }

	public TimeSpan WebDriverSleepTime { get; }

	public string AstroShopBaseUrl { get; }

	public TestSettings(ISettingsProvider provider)
	{
		WebDriverTimeout = provider.GetTimeSpanFromSeconds("WebDriverTimeoutSeconds");
		WebDriverSleepTime = provider.GetTimeSpanFromSeconds("WebDriverSleepTimeMilliseconds");
		AstroShopBaseUrl = provider.GetString("AstroShopBaseUrl");
	}
}