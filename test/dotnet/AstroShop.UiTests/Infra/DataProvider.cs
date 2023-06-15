namespace AstroShop.UiTests.Infra;

using Autofac;
using AstroQA.TestSdk.Common.Data;
using AstroShop.TestSdk.Domain.Model;
using AstroShop.TestSdk.Web.Domain;
using AstroShop.TestSdk.Web.TestDataHelpers;

/// <summary>
/// Demonstrates how any type of external data can be loaded once for all tests in assembly.
/// </summary>
public static class DataProvider
{
	static DataProvider()
	{
		var container = new ContainerBuilder();
		container
			.RegisterType<TestData>();
		container
			.RegisterType<ProductDataLoader>()
			.As<ILoader<ProductData>>();
		container
			.RegisterType<JsonDataAdapter<ProductInfo[]>>()
			.As<IDataAdapter<ProductInfo[]>>();
		container.RegisterInstance(new ProductDataFilePath("Resources/products.json"));
		TestData = container.Build().Resolve<TestData>();
	}

	public static TestData TestData { get; set; }
}