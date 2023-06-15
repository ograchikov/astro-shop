namespace AstroQA.TestSdk.Common.Composition;

using AstroQA.TestSdk.Common.Data;
using Autofac;

public static class DataAdapterComposition
{
	public static ContainerBuilder AddYamlDataAdapter<TData>(this ContainerBuilder containerBuilder)
	{
		containerBuilder
			.RegisterType<YamlDataAdapter<TData>>()
			.As<YamlDataAdapter<TData>>()
			.As<IDataAdapter<TData>>();
		return containerBuilder;
	}
}