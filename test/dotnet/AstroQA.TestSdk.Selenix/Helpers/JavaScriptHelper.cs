namespace AstroQA.TestSdk.Selenix.Helpers
{
	using OpenQA.Selenium;

	public class JavaScriptHelper : IJavaScriptHelper
	{
	    private readonly WebDriver _driver;

        public JavaScriptHelper(WebDriver driver)
        {
	        _driver = driver;
        }

		public async Task<object> ExecuteScriptAsync(string script, params object[] args)
        {
            var jsExecutor = (IJavaScriptExecutor)_driver;
            var scriptResult = Task.Run(() => jsExecutor.ExecuteAsyncScript(script, args));
            return await scriptResult;
		}

        public object ExecuteScript(string script, params object[] args)
        {
            return _driver.ExecuteScript(script, args);
        }

        public object HighLight(IWebElement element)
        {
	        var js = (IJavaScriptExecutor)_driver;
	        var scriptResult =
		        js.ExecuteScript(
			        "arguments[0].setAttribute('style', 'background: yellow; border: 2px solid red;');", element);
	        return scriptResult;
        }
	}
}