namespace AstroQA.TestSdk.Common.Data;

public class LazyLoader<TData> : ILoader<TData>
{
	private readonly Lazy<Task<TData>> lazyLoader;

	public Task<TData> Load() => lazyLoader.Value;
		
	public LazyLoader(ILoader<TData> dataLoader)
	{
		lazyLoader = new Lazy<Task<TData>>(async () => await dataLoader.Load());
	}
}