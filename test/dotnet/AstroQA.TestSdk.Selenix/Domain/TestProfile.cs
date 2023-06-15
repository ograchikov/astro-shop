namespace AstroQA.TestSdk.Selenix.Domain;

public class TestProfile
{
	public string Name { get; set; } = string.Empty;

	public List<BrowserInfo> Browsers { get; set; } = new();
}
