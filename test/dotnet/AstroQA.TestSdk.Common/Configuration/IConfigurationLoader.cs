namespace AstroQA.TestSdk.Common.Configuration;

public interface IConfigurationLoader
{
	T LoadConfiguration<T>(string filePath);
	T[] LoadConfigurations<T>(string filePath);
}