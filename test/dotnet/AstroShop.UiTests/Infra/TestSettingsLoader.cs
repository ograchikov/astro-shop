namespace AstroShop.UiTests.Infra;

using AstroQA.TestSdk.Common.Data;

public class TestSettingsLoader<TSettings>
{
	private readonly Lazy<Task<TSettings>> lazyLoader;

	public Task<TSettings> GetSettings() => lazyLoader.Value;
		
	public TestSettingsLoader(ILoader<TSettings> settingsLoader)
	{
		lazyLoader = new Lazy<Task<TSettings>>(async () => await settingsLoader.Load());
	}
}