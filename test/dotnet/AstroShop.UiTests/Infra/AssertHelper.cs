namespace AstroShop.UiTests.Infra;

using AstroQA.TestSdk.Selenix.Asserts;
using AstroShop.TestSdk.Web.Asserts;

public class AssertHelper
{
	public AssertHelper(
		IProductAsserts productAsserts, 
		IWebPageAsserts webPage)
	{
		Product = productAsserts;
		WebPage = webPage;
	}

	public IProductAsserts Product { get; }
	public IWebPageAsserts WebPage { get; }
}