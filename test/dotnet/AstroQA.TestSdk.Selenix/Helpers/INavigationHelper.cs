namespace AstroQA.TestSdk.Selenix.Helpers;

using OpenQA.Selenium;

public interface INavigationHelper
{
	IAlert SwitchToAlert(TimeSpan? customTimeout = null);
}