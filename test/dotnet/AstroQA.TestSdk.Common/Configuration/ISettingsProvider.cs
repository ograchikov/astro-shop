namespace AstroQA.TestSdk.Common.Configuration;

public interface ISettingsProvider
{
	TSetting GetSetting<TSetting>(string settingName, Func<string, TSetting> castValueFunc);
	string GetString(string settingName);
	int GetInt(string settingName);
	double GetDouble(string settingName);
	TimeSpan GetTimeSpanFromSeconds(string settingName);
}