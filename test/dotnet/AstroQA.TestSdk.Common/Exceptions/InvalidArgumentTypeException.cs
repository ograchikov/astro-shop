namespace AstroQA.TestSdk.Common.Exceptions;

using System;

public class InvalidArgumentTypeException : TestSdkException
{
	public InvalidArgumentTypeException() { }

	public InvalidArgumentTypeException(string? message) : base(message) { }

	public InvalidArgumentTypeException(string message, Exception inner) : 
		base(message, inner) { }
}