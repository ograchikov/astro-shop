namespace AstroQA.TestSdk.Common.Configuration;

using AstroQA.TestSdk.Common.Exceptions;

public class SettingsProvider : ISettingsProvider
{
	private readonly IReadOnlyDictionary<string, string> _settings;

	public SettingsProvider(IReadOnlyDictionary<string, string> settings)
	{
		_settings = settings;
	}

	public TSetting GetSetting<TSetting>(string settingName, Func<string, TSetting> castValueFunc)
	{
		var setting = GetString(settingName);
		return castValueFunc(setting);
	}

	public string GetString(string settingName)
	{

		if (!_settings.ContainsKey(settingName))
		{
			throw new SettingNotFoundException(settingName);
		}
		return _settings[settingName];
	}

	public int GetInt(string settingName)
	{
		var setting = GetString(settingName);
		TryParse(x => int.TryParse(x, out _), settingName, setting);
		return int.Parse(setting);
	}

	public double GetDouble(string settingName)
	{
		var setting = GetString(settingName);
		TryParse(x => double.TryParse(x, out _), settingName, setting);
		return double.Parse(setting);
	}

	public TimeSpan GetTimeSpanFromSeconds(string settingName)
	{
		var setting = GetInt(settingName);
		return TimeSpan.FromSeconds(setting);
	}

	private static void TryParse(
		Func<string, bool> tryParseFunc,
		string settingName,
		string setting)
	{
		if (!tryParseFunc(setting))
		{
			throw new CastSettingException(settingName, $"Value: '{setting}'.");
		};
	}
}