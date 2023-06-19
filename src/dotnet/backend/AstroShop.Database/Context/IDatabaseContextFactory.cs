namespace AstroShop.Database.Context;

public interface IDatabaseContextFactory<out TContext> where TContext : IDisposable
{
	TContext CreateContext();
}