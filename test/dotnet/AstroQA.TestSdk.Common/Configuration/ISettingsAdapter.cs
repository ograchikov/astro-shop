namespace AstroQA.TestSdk.Common.Configuration;

public interface ISettingsAdapter
{
	Task<IReadOnlyDictionary<string, string>> GetSettings();
}