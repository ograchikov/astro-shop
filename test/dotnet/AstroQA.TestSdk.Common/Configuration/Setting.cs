namespace AstroQA.TestSdk.Common.Configuration;

using AstroQA.TestSdk.Common.Validation;

public class Setting
{
	public Setting(string key, string value)
	{
		Guard.NotNullOrWhitespace(key, nameof(key));
		Guard.NotNull(value, nameof(value));
		Key = key;
		Value = value;
	}

	public string Key { get; }

	public string Value { get; }
}