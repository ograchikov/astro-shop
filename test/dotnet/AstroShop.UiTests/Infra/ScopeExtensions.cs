namespace AstroShop.UiTests.Infra;

using Autofac;

public static class ScopeExtensions
{
	public static TestHelper GetAstroShop(this ILifetimeScope scope) =>
		scope.Resolve<TestHelper>();
}