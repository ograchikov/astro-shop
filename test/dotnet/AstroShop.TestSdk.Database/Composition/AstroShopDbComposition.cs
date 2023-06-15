namespace AstroShop.TestSdk.Database.Composition;

using AstroShop.TestSdk.Database.Client;
using Autofac;

public static class AstroShopDbComposition
{
	public static ContainerBuilder AddAstroShopDbTestSdk(
		this ContainerBuilder containerBuilder)
	{
		containerBuilder
			.RegisterType<AstroShopDbClient>()
			.As<IAstroShopDbClient>();
		return containerBuilder;
	}
}