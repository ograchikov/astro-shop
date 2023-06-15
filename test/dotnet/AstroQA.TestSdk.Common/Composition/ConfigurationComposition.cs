namespace AstroQA.TestSdk.Common.Composition;

using Autofac;

public static class ConfigurationComposition
{
	public static ContainerBuilder AddConfiguration(
		this ContainerBuilder containerBuilder,
		IConfiguration configuration)
	{
		containerBuilder.RegisterInstance(configuration);
		return containerBuilder;
	}
}