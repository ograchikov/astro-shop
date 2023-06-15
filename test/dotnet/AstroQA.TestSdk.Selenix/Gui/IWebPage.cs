namespace AstroQA.TestSdk.Selenix.Gui;

public interface IWebPage
{
	public string Url { get; }
	public string Title { get; }
	public void Open();
	public void Close();
}