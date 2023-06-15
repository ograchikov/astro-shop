using System.Diagnostics;

namespace AstroQA.TestSdk.Common.Validation;

using AstroQA.TestSdk.Common.Exceptions;

public class Guard
{
	[DebuggerStepThrough]
	public static TObject GetIfEqual<TObject>(
	TObject actualValue,
	TObject expectedValue,
	string argumentName,
	string message = "")
	{
		if (string.IsNullOrWhiteSpace(message))
		{
			message = $"Unexpected value:[{actualValue}], expected:[{expectedValue}].";
		}
		if (actualValue == null)
		{
			throw new InvalidArgumentException(argumentName, message);
		}
		return actualValue;
	}

	[DebuggerStepThrough]
	public static void NotNull(object parameter, string argumentName, string message = "")
	{
		if (parameter == null)
		{
			throw new NullArgumentException(argumentName, message);
		}
	}

	[DebuggerStepThrough]
	public static TType NotNull<TType>(TType parameter, string argumentName, string message = "")
	{
		if (parameter == null)
		{
			throw new NullArgumentException(argumentName, message);
		}

		return parameter;
	}

	[DebuggerStepThrough]
	public static void NotNullOrWhitespace(string parameter, string argumentName, string message = "")
	{
		if (string.IsNullOrWhiteSpace(parameter))
		{
			throw new NullOrEmptyArgumentException(argumentName, message);
		}
	}

	[DebuggerStepThrough]
	public static void Condition<TArgument>(
		TArgument argument,
		string argumentName,
		Func<TArgument, bool> verificationFunction,
		string message = "")
	{
		if (!verificationFunction.Invoke(argument))
		{
			throw new InvalidArgumentException(argumentName, message);
		}
	}

	[DebuggerStepThrough]
	public static void GuidNotEmpty(
		Guid guid,
		string argumentName,
		string message = "Guid is empty.")
	{
		if (guid == Guid.Empty)
		{
			throw new InvalidArgumentException(argumentName, message);
		}
	}

	[DebuggerStepThrough]
	public static void GuidNotNullOrEmpty(Guid? guid, string name, string message = "")
	{
		if (guid == null || guid == Guid.Empty)
		{
			throw new NullArgumentException(name, message);
		}
	}

	[DebuggerStepThrough]
	public static void IsType<TType>(object instance, out TType output, string? message = null)
	{
		if (!(instance is TType x))
		{
			if (message != null)
			{
				throw new InvalidArgumentTypeException(message);
			}

			throw new InvalidArgumentException($"Failed to cast [{instance.GetType()}] to [{typeof(TType).Name}].");
		}
		output = x;
	}

	[DebuggerStepThrough]
	public static TType IsType<TType>(object instance, string? message = null)
	{
		if (!(instance is TType x))
		{
			if (message != null)
			{
				throw new InvalidArgumentTypeException(message);
			}

			throw new InvalidArgumentException($"Failed to cast [{instance.GetType()}] to [{typeof(TType).Name}].");
		}
		return x;
	}
}