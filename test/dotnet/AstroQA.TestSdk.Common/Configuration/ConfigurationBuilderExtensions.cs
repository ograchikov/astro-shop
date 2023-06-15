namespace AstroQA.TestSdk.Common.Configuration;

public static class ConfigurationBuilderExtensions
{
	public static IConfigurationBuilder InitializeYamlConfig(
		this IConfigurationBuilder builder,
		string environmentName,
		string configPath = "Configs",
		string settingsFileBaseName = "appsettings",
		bool isOptional = true,
		bool reloadOnChange = true) =>
		builder
			.SetBasePath(Directory.GetCurrentDirectory())
			.AddYamlFile(
				Path.Combine(configPath, $"{settingsFileBaseName}.yaml"),
				isOptional,
				reloadOnChange)
			.AddYamlFile(
				Path.Combine(configPath, $"{settingsFileBaseName}.{environmentName.ToLower()}.yaml"),
				isOptional,
				reloadOnChange)
			.AddEnvironmentVariables();
}