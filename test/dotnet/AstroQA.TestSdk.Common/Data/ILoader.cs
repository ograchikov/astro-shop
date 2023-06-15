namespace AstroQA.TestSdk.Common.Data;

public interface ILoader<TValue>
{
	Task<TValue> Load();
}