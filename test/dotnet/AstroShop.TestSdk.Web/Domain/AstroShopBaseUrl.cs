namespace AstroShop.TestSdk.Web.Domain;

using AstroQA.TestSdk.Common.Domain;
using AstroQA.TestSdk.Common.Validation;

public class AstroShopBaseUrl : IValueObject<string>
{
	public AstroShopBaseUrl(string url)
	{
		Guard.NotNullOrWhitespace(url, nameof(AstroShopBaseUrl));
		Value = url;
	}

	public string Value { get; }
}