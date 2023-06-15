namespace AstroQA.TestSdk.Selenix.Helpers;

using OpenQA.Selenium;

public interface IInteractionHelper
{
	IWebElement Click(By locator);
	IWebElement Type(By locator, string text);
}