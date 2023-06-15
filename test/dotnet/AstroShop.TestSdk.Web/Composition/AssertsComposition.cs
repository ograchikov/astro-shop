namespace AstroShop.TestSdk.Web.Composition;

using AstroShop.TestSdk.Web.Asserts;
using Autofac;

public static class AssertsComposition
{
	public static ContainerBuilder AddAstroShopAsserts(
		this ContainerBuilder containerBuilder)
	{
		containerBuilder
			.RegisterType<ProductInfoComparer>()
			.InstancePerLifetimeScope();
		containerBuilder
			.RegisterType<ProductAsserts>()
			.As<IProductAsserts>();
		return containerBuilder;
	}
}