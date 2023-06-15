namespace AstroQA.TestSdk.Selenix.Domain;

public class BrowserInfo
{
	public string BrowserName { get; set; } = string.Empty;

	public List<string> Versions { get; set; } = new();
}