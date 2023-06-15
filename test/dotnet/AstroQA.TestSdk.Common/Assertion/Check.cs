namespace AstroQA.TestSdk.Common.Assertion
{
	using CSharpFunctionalExtensions;
	using System;

	public static class Check
	{
		public static Result AreEqual(string expected, string actual, string entityName) =>
			expected == actual ? 
				Result.Success():
				Result.Failure(GetNotEqualError(entityName, expected, actual));

		public static Result AreEqual(long expected, long actual, string entityName) =>
			expected == actual ?
				Result.Success() :
				Result.Failure(GetNotEqualError(entityName, expected.ToString(), actual.ToString()));

		public static Result AreEqual(ulong expected, ulong actual, string entityName) =>
			expected == actual ?
				Result.Success() :
				Result.Failure(GetNotEqualError(entityName, expected.ToString(), actual.ToString()));

		public static Result AreEqual(Guid expected, Guid actual, string entityName) =>
			expected == actual ?
				Result.Success() :
				Result.Failure(GetNotEqualError(entityName, expected.ToString(), actual.ToString()));

		public static Result AreNotEqual(Guid expected, Guid actual, string entityName) =>
			expected != actual ?
				Result.Success() :
				Result.Failure(GetEqualError(entityName, expected.ToString(), actual.ToString()));

		public static Result NotNull<T>(T entity, string entityName) =>
			entity != null ?
				Result.Success() :
				Result.Failure(GetNullError(entityName));

		public static string GetNotEqualError(string entityName, string expectedValue, string actualValue) =>
			$"Error: {entityName} not equal; expected: '{expectedValue}', actual:'{actualValue}'.";

		public static string GetEqualError(string entityName, string expectedValue, string actualValue) =>
			$"Error: {entityName} equals; expected: '{expectedValue}', actual:'{actualValue}'.";

		public static string GetNullError(string entityName) =>
			$"Error: {entityName} is null.";
	}
}