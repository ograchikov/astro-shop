namespace AstroQA.TestSdk.Common.Domain;

using CSharpFunctionalExtensions;

public class ValueObjectType<TValue> : ValueObject, IValueObject<TValue> where TValue : IComparable
{
	public ValueObjectType(TValue value)
	{
		Value = value;
	}

	public TValue Value { get; }

	protected override IEnumerable<IComparable> GetEqualityComponents()
	{
		yield return Value;
	}
}