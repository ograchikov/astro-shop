namespace AstroQA.TestSdk.Common.Configuration;

using AstroQA.TestSdk.Common.Data;
using System.Collections.ObjectModel;

public class YamlSettingsAdapter : ISettingsAdapter
{
	private readonly YamlDataAdapter<IDictionary<string, string>> _adapter;
	private readonly string _filePath;

	public async Task<IReadOnlyDictionary<string, string>> GetSettings()
	{
		var settings = await _adapter.LoadData(_filePath);
		return new ReadOnlyDictionary<string, string>(settings);
	}

	public YamlSettingsAdapter(
		YamlDataAdapter<IDictionary<string, string>> adapter, 
		SettingsFilePath filePath)
	{
		_adapter = adapter;
		_filePath = filePath.Value;
	}
}