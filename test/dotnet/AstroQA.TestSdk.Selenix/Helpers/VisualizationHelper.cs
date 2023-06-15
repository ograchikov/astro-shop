namespace AstroQA.TestSdk.Selenix.Helpers
{
	using OpenQA.Selenium;

	public class VisualizationHelper : IVisualizationHelper
	{
		private readonly IJavaScriptHelper _javaScript;

		public VisualizationHelper(IJavaScriptHelper javaScript)
		{
			_javaScript = javaScript;
		}

		public void HighLight(IWebElement element) =>
			_javaScript.ExecuteScript(
				"arguments[0].setAttribute('style', 'background: yellow; border: 2px solid red;');",
				element);
	}
}