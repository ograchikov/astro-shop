namespace AstroShop.TestSdk.Web.Domain;

using AstroQA.TestSdk.Common.Domain;
using AstroQA.TestSdk.Common.Validation;

public class ProductDataFilePath : IValueObject<string>
{
	public ProductDataFilePath(string filePath)
	{
		Guard.NotNullOrWhitespace(filePath, nameof(ProductDataFilePath));
		Value = filePath;
	}

	public string Value { get; }
}