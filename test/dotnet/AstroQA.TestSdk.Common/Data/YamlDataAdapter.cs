namespace AstroQA.TestSdk.Common.Data;

using AstroQA.TestSdk.Common.Exceptions;
using AstroQA.TestSdk.Common.Validation;
using YamlDotNet.Serialization;

public class YamlDataAdapter<TData> : IDataAdapter<TData>
{
	public async Task<TData> LoadData(string filePath)
	{
		Guard.NotNullOrWhitespace(filePath, nameof(filePath));
		var yaml = await File.ReadAllTextAsync(filePath);

		Guard.NotNullOrWhitespace(yaml, nameof(yaml));
		var deserializer = new DeserializerBuilder().Build();
		return deserializer.Deserialize<TData>(yaml) ?? 
		       throw new EntityDeserializationException(
			       typeof(TData).Name,
			       $"File path: '{filePath}'.");
	}
}