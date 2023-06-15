namespace AstroQA.TestSdk.Common.Exceptions;

using System;

public class NullArgumentException : TestSdkException
{
	public NullArgumentException(string nameOfArgument) : 
		base($"argument:'{nameOfArgument}'") { }
	
	public NullArgumentException(string nameOfArgument, string message) : 
		base($"argument:'{nameOfArgument}' message:'{message}'") { }

	public NullArgumentException(string nameOfArgument, Exception innerException) : 
		base($"argument:'{nameOfArgument}'", innerException) { }
}