namespace AstroQA.TestSdk.Common.Composition;

using AstroQA.TestSdk.Common.Logging;
using Autofac;

public static class LoggerComposition
{
	public static ContainerBuilder AddTestLogger(this ContainerBuilder containerBuilder)
	{
		containerBuilder.RegisterType<TestLogger>().As<ITestLogger>().InstancePerDependency();
		return containerBuilder;
	}
}