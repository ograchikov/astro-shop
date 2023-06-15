namespace AstroQA.TestSdk.Common.Exceptions
{
	using System;

	public class TestSdkException : Exception
	{
		public TestSdkException()
		{
		}

		public TestSdkException(string? message) : base(message)
		{
		}

		public TestSdkException(string message, Exception innerException) : 
			base(message, innerException)
		{
		}
	}
}