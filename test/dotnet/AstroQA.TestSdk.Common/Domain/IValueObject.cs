namespace AstroQA.TestSdk.Common.Domain;

public interface IValueObject<out TValue>
{
	TValue Value { get; }
}