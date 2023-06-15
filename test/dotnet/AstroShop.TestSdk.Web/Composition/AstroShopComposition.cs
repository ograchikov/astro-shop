namespace AstroShop.TestSdk.Web.Composition;

using AstroShop.TestSdk.Web.TestContracts;
using AstroShop.TestSdk.Web.View;
using Autofac;

public static class AstroShopComposition
{
	public static ContainerBuilder AddAstroShopTestSdk(
		this ContainerBuilder containerBuilder)
	{
		containerBuilder
			.RegisterType<AstroShopWebHelper>()
			.As<IAstroShopWebHelper>()
			.InstancePerLifetimeScope();
		containerBuilder
			.RegisterType<OverlayPopupView>()
			.As<IOverlayPopupView>()
			.InstancePerLifetimeScope();
		containerBuilder
			.RegisterType<PopupGalleryView>()
			.As<IPopupGalleryView>()
			.InstancePerLifetimeScope();
		containerBuilder
			.RegisterType<ProductCardView>()
			.As<IProductCardView>()
			.InstancePerLifetimeScope();
		containerBuilder
			.RegisterType<ProductCartView>()
			.As<IProductCartView>()
			.InstancePerLifetimeScope();
		containerBuilder
			.RegisterType<StorefrontView>()
			.As<IStorefrontView>()
			.InstancePerLifetimeScope();
		return containerBuilder;
	}
}