namespace AstroQA.TestSdk.Common.Configuration;

using YamlDotNet.Serialization;

public class YamlConfigurationLoader : IConfigurationLoader
{
	public T LoadConfiguration<T>(string filePath)
	{
		var yaml = File.ReadAllText(filePath);
		var deserializer = new DeserializerBuilder().Build();
		var data = deserializer.Deserialize<T>(yaml);
		return data;
	}

	public T[] LoadConfigurations<T>(string filePath)
	{
		var yaml = File.ReadAllText(filePath);
		var deserializer = new DeserializerBuilder().Build();
		var data = deserializer.Deserialize<T[]>(yaml);
		return data;
	}
}