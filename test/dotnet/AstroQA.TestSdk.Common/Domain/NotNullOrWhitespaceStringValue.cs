namespace AstroQA.TestSdk.Common.Domain;

using AstroQA.TestSdk.Common.Validation;

public class NotNullOrWhitespaceStringValue : IValueObject<string>
{
	public NotNullOrWhitespaceStringValue(string value, string valueName)
	{
		Guard.NotNullOrWhitespace(value, valueName);
		Value = value;
	}

	public string Value { get; private set; }
}