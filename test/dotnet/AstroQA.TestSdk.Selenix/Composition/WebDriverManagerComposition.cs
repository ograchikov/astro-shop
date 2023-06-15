namespace AstroQA.TestSdk.Selenix.Composition;

using Autofac;
using WebDriverManager;

public static class WebDriverManagerComposition
{
	public static ContainerBuilder AddWebDriverManager(this ContainerBuilder containerBuilder)
	{
		containerBuilder.RegisterType<DriverManager>().SingleInstance();
		return containerBuilder;
	}
}