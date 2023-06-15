namespace AstroQA.TestSdk.Selenix.Asserts;

using AstroQA.TestSdk.Common.Exceptions;

public class WebPageAsserts : IWebPageAsserts
{
	public void TitleEquals(string expectedTitle, string actualTitle)
	{
		if (expectedTitle != actualTitle)
		{
			throw new TestSdkAssertionException(
				$"Web page title '{actualTitle}' not equal to expected '{expectedTitle}'.");
		}
	}
}