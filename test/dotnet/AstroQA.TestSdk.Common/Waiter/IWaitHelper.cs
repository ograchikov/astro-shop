namespace AstroQA.TestSdk.Common.Waiter;

public interface IWaitHelper
{
	Task<TResult> WaitForEntity<TResult>(
		Func<Task<TResult>> getDataFunc,
		string waitForMessage = "",
		TimeSpan? customTimeout = null,
		TimeSpan? customSpinTime = null);

	/// <summary>
	/// Waits for entity obtained using provided function an data provider.
	/// </summary>
	/// <typeparam name="TDataProvider">Data provider type.</typeparam>
	/// <typeparam name="TResult">Result type.</typeparam>
	/// <param name="getDataFunc">Get data function.</param>
	/// <param name="dataProvider">Data Provider.</param>
	/// <param name="waitForMessage">Wait for [{waitForMessage}] completed in {stopwatch.Elapsed}.</param>
	/// <param name="customTimeout">Timeout.</param>
	/// <param name="customSpinTime">Time between attempts to get data.</param>
	/// <returns></returns>
	Task<TResult> WaitForEntity<TDataProvider, TResult>(
		Func<TDataProvider, Task<TResult>> getDataFunc,
		TDataProvider dataProvider,
		string waitForMessage = "",
		TimeSpan? customTimeout = null,
		TimeSpan? customSpinTime = null);

	Task<TResult?> WaitForEntityAndCheck<TResult>(
		Func<Task<TResult>> getDataFunc,
		Func<TResult?, bool> checkDataFunc,
		string waitForMessage = "",
		TimeSpan? customTimeout = null,
		TimeSpan? customSpinTime = null);

	Task<TResult?> WaitForEntityAndCheck<TDataProvider, TResult>(
		Func<TDataProvider, Task<TResult>> getDataFunc,
		TDataProvider dataProvider,
		Func<TResult?, bool> checkDataFunc,
		string waitForMessage = "",
		TimeSpan? customTimeout = null,
		TimeSpan? customSpinTime = null);

	Task WaitForCondition(
		Func<Task<bool>> getAndCheckDataFunc,
		string waitForMessage,
		TimeSpan? customTimeout = null,
		TimeSpan? customSpinTime = null);
}