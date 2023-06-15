namespace AstroQA.TestSdk.Common.Configuration;

using AstroQA.TestSdk.Common.Domain;

public class SettingsFilePath : NotNullOrWhitespaceStringValue
{
	public SettingsFilePath(string filePath) : base(filePath, nameof(SettingsFilePath))
	{
	}
}