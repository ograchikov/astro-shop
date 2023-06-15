namespace AstroQA.TestSdk.Common.Exceptions;

using System;

public class InvalidArgumentException : TestSdkException
{
	public InvalidArgumentException() { }

	public InvalidArgumentException(string argumentName) : 
		base($"argument:'{argumentName}'") { }

	public InvalidArgumentException(string argumentName, string message) :
		base($"argument:'{argumentName}' message:'{message}'")
	{ }

	public InvalidArgumentException(string argumentName, Exception innerException) :
		base($"argument:'{argumentName}'", innerException)
	{ }
}