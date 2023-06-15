namespace AstroQA.TestSdk.Common.Exceptions
{
	using System;

	public class TestSdkAssertionException : TestSdkException
	{
		public TestSdkAssertionException()
		{
		}

		public TestSdkAssertionException(string? message) : base(message)
		{
		}

		public TestSdkAssertionException(string message, Exception innerException) : 
			base(message, innerException)
		{
		}
	}
}