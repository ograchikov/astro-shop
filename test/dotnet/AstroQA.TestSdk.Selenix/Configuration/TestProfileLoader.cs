namespace AstroQA.TestSdk.Selenix.Configuration;

using AstroQA.TestSdk.Common.Configuration;
using AstroQA.TestSdk.Selenix.Domain;

public class TestProfileLoader
{
	private readonly IConfigurationLoader loader;

	public TestProfileLoader(IConfigurationLoader loader)
	{
		this.loader = loader;
	}

	public TestProfile[] LoadTestProfile(string filePath) =>
		loader.LoadConfigurations<TestProfile>(filePath);
}