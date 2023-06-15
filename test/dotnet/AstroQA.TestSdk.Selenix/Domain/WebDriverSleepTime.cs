namespace AstroQA.TestSdk.Selenix.Domain;

using AstroQA.TestSdk.Common.Domain;

public sealed class WebDriverSleepTime : ValueObjectType<TimeSpan> 
{
	public WebDriverSleepTime(TimeSpan spinTime) : base(spinTime)
	{
	}
}