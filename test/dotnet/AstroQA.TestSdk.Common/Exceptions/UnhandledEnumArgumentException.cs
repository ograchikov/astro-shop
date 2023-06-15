namespace AstroQA.TestSdk.Common.Exceptions;

public class UnhandledEnumArgumentException : TestSdkException
{
	public UnhandledEnumArgumentException(string argumentName, string value) : 
		base($"name'{argumentName}', value'{value}'")
	{
	}
}