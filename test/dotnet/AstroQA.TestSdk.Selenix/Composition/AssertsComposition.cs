namespace AstroQA.TestSdk.Selenix.Composition;

using AstroQA.TestSdk.Selenix.Asserts;
using Autofac;

public static class AssertsComposition
{
	public static ContainerBuilder AddWebPageAsserts(
		this ContainerBuilder containerBuilder)
	{
		containerBuilder
			.RegisterType<WebPageAsserts>()
			.As<IWebPageAsserts>()
			.InstancePerLifetimeScope();
		return containerBuilder;
	}
}