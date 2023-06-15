namespace AstroQA.TestSdk.Selenix.Helpers;

public interface IJavaScriptHelper
{
	Task<object> ExecuteScriptAsync(string script, params object[] args);
	object ExecuteScript(string script, params object[] args);
}