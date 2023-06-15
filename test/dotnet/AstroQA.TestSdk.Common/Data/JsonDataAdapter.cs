namespace AstroQA.TestSdk.Common.Data;

using AstroQA.TestSdk.Common.Exceptions;
using AstroQA.TestSdk.Common.Validation;
using Newtonsoft.Json;

public class JsonDataAdapter<TData> : IDataAdapter<TData>
{
	public async Task<TData> LoadData(string filePath)
	{
		Guard.NotNullOrWhitespace(filePath, nameof(filePath));
		var json = await File.ReadAllTextAsync(filePath);

		Guard.NotNullOrWhitespace(json, nameof(json));
		return JsonConvert.DeserializeObject<TData>(json) ??
		       throw new EntityDeserializationException(
			       typeof(TData).Name,
			       $"File path: '{filePath}'.");
	}
}