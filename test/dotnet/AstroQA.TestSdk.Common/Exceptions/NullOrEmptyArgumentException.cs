namespace AstroQA.TestSdk.Common.Exceptions;

using System;

public class NullOrEmptyArgumentException : TestSdkException
{
	public NullOrEmptyArgumentException(string nameOfArgument) : 
		base($"argument:'{nameOfArgument}'") { }
	
	public NullOrEmptyArgumentException(string nameOfArgument, string message) : 
		base($"argument:'{nameOfArgument}' message:'{message}'") { }

	public NullOrEmptyArgumentException(string nameOfArgument, Exception innerException) : 
		base($"argument:'{nameOfArgument}'", innerException) { }
}