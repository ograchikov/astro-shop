namespace AstroQA.TestSdk.Common.StringHelpers;

using AstroQA.TestSdk.Common.Exceptions;
using System.Globalization;

public class CurrencyParser
{
	public decimal ParseUsdString(string currencyString)
	{
		var usCulture = CultureInfo.CreateSpecificCulture("en-US");
		if (!decimal.TryParse(
			    currencyString,
			    NumberStyles.Currency,
			    usCulture,
			    out var currencyValue))
		{
			throw new InvalidArgumentException("Invalid currency string format.", nameof(currencyString));
		}

		return currencyValue;
	}
}