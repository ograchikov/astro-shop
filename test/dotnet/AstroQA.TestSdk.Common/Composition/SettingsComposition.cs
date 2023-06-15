namespace AstroQA.TestSdk.Common.Composition;

using AstroQA.TestSdk.Common.Configuration;
using Autofac;

public static class SettingsComposition
{
	public static ContainerBuilder AddSettingsProvider(
		this ContainerBuilder containerBuilder, 
		IReadOnlyDictionary<string, string> settings)
	{
		containerBuilder
			.Register(x => new SettingsProvider(settings))
			.As<ISettingsProvider>();
		return containerBuilder;
	}

	public static ContainerBuilder AddYamlSettingsAdapter(this ContainerBuilder containerBuilder)
	{
		containerBuilder.RegisterType<YamlSettingsAdapter>().As<ISettingsAdapter>();
		return containerBuilder;
	}
}