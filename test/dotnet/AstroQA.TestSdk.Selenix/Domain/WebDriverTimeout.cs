namespace AstroQA.TestSdk.Selenix.Domain;

using AstroQA.TestSdk.Common.Domain;

public sealed class WebDriverTimeout : ValueObjectType<TimeSpan> 
{
	public WebDriverTimeout(TimeSpan timeout) : base(timeout)
	{
	}
}