namespace AstroShop.UiTests.Infra;

using AstroQA.TestSdk.Common.Composition;
using AstroQA.TestSdk.Common.Configuration;
using Autofac;

/// <summary>
/// Demonstrates how any type of external data can be loaded once for all tests in assembly.
/// </summary>
public static class TestSettingsProvider
{
	static TestSettingsProvider()
	{
		var settingsBuilder = new ContainerBuilder()
			.AddYamlSettingsAdapter()
			.AddYamlDataAdapter<IDictionary<string, string>>();
		settingsBuilder.RegisterInstance(new SettingsFilePath("Configs/appsettings.yaml"));
		var settingsProvider = settingsBuilder.Build().Resolve<ISettingsAdapter>();
		Settings = new Lazy<Task<IReadOnlyDictionary<string, string>>>(
			async () => await settingsProvider.GetSettings());
	}

	public static Lazy<Task<IReadOnlyDictionary<string, string>>> Settings { get; }
}