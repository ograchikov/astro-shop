namespace AstroQA.TestSdk.Common.Exceptions
{
	using System;

	public class UnexpectedParameterValueException : TestSdkException
	{
		public UnexpectedParameterValueException(string parameterName, string expectedValue, string actualValue) : 
			base($"Parameter Name:'{parameterName}', Expected Value:'{expectedValue}' Actual Value:'{actualValue}'.")
		{
		}

		public UnexpectedParameterValueException(string parameterName, string expectedValue, string actualValue, string comment) :
			base($"Parameter Name:'{parameterName}', Expected Value:'{expectedValue}' Actual Value:'{actualValue}' Comment: '{comment}'.")
		{
		}

		public UnexpectedParameterValueException(
			string parameterName, 
			string expectedValue, 
			string actualValue, 
			string comment,
			Exception innerException) :
			base($"Parameter Name:'{parameterName}', Expected Value:'{expectedValue}' Actual Value:'{actualValue}' Comment: '{comment}'.", innerException)
		{
		}
	}
}