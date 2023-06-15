namespace AstroQA.TestSdk.Common.Waiter
{
	using AstroQA.TestSdk.Common.Logging;
	using AstroQA.TestSdk.Common.Parameters;
	using System;
	using System.Diagnostics;
	using System.Threading.Tasks;

	public class WaitHelper : IWaitHelper
	{
		private readonly TimeSpan _defaultTimeout;
		private readonly TimeSpan _defaultSpinTime;
		private readonly ITestLogger _logger;

		public WaitHelper(
			TimeSpan defaultTimeout,
			TimeSpan defaultSpinTime,
			ITestLogger logger)
		{
			_defaultTimeout = defaultTimeout;
			_defaultSpinTime = defaultSpinTime;
			_logger = logger;
		}

		public async Task<TResult> WaitForEntity<TResult>(
			Func<Task<TResult>> getDataFunc,
			string waitForMessage = "",
			TimeSpan? customTimeout = null,
			TimeSpan? customSpinTime = null)
		{
			var timeout = ParameterHelper.GetCustomIfNotNull(_defaultTimeout, customTimeout);
			var spinTime = ParameterHelper.GetCustomIfNotNull(_defaultSpinTime, customSpinTime);
			waitForMessage = string.IsNullOrWhiteSpace(waitForMessage) ? typeof(TResult).Name : waitForMessage;

			var stopwatch = Stopwatch.StartNew();
			while (stopwatch.Elapsed < timeout)
			{
				try
				{
					var result = await getDataFunc.Invoke();
					if (result != null)
					{
						_logger.Debug($"Wait for [{waitForMessage}] completed in {stopwatch.Elapsed}.");
						return result;
					}
				}
				catch (Exception e)
				{
					_logger.Error($"Wait for [{waitForMessage}] failed with error: [{e.Message}].", e);
					throw;
				}

				await Task.Delay(spinTime).ConfigureAwait(false);
			}

			throw new TimeoutException($"Wait for [{waitForMessage}] failed to get in {stopwatch.Elapsed}.");
		}

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
		public async Task<TResult> WaitForEntity<TDataProvider, TResult>(
			Func<TDataProvider, Task<TResult>> getDataFunc,
			TDataProvider dataProvider,
			string waitForMessage = "",
			TimeSpan? customTimeout = null,
			TimeSpan? customSpinTime = null)
		{
			var timeout = ParameterHelper.GetCustomIfNotNull(_defaultTimeout, customTimeout);
			var spinTime = ParameterHelper.GetCustomIfNotNull(_defaultSpinTime, customSpinTime);
			waitForMessage = string.IsNullOrWhiteSpace(waitForMessage) ? typeof(TResult).Name : waitForMessage;

			var stopwatch = Stopwatch.StartNew();
			while (stopwatch.Elapsed < timeout)
			{
				try
				{
					var result = await getDataFunc.Invoke(dataProvider);
					if (result != null)
					{
						_logger.Debug($"Wait for [{waitForMessage}] completed in {stopwatch.Elapsed}.");
						return result;
					}
				}
				catch (Exception e)
				{
					_logger.Error($"Wait for [{waitForMessage}] failed with error: [{e.Message}].", e);
					throw;
				}

				await Task.Delay(spinTime).ConfigureAwait(false);
			}

			throw new TimeoutException($"Wait for [{waitForMessage}] failed to get in {stopwatch.Elapsed}.");
		}

		public async Task<TResult?> WaitForEntityAndCheck<TResult>(
			Func<Task<TResult>> getDataFunc,
			Func<TResult?, bool> checkDataFunc,
			string waitForMessage = "",
			TimeSpan? customTimeout = null,
			TimeSpan? customSpinTime = null)
		{
			var timeout = ParameterHelper.GetCustomIfNotNull(_defaultTimeout, customTimeout);
			var spinTime = ParameterHelper.GetCustomIfNotNull(_defaultSpinTime, customSpinTime);
			waitForMessage = string.IsNullOrWhiteSpace(waitForMessage) ? typeof(TResult).Name : waitForMessage;

			TResult? result = default;
			var stopwatch = Stopwatch.StartNew();
			while (stopwatch.Elapsed < timeout)
			{
				try
				{
					result = await getDataFunc.Invoke();
					if (result != null)
					{
						var checkResult = checkDataFunc.Invoke(result);
						if (checkResult)
						{
							_logger.Debug($"Wait for [{waitForMessage}] completed in {stopwatch.Elapsed}.");
							return result;
						}
					}
				}
				catch (Exception e)
				{
					_logger.Error($"Wait for [{waitForMessage}] failed with error: [{e.Message}].", e);
					throw;
				}

				await Task.Delay(spinTime).ConfigureAwait(false);
			}

			var getDataResult = "";
			if (result != null)
			{
				getDataResult = "not ";
			}

			var getDataResultMessage = $"GetDataFunc output is {getDataResult}null";

			throw new TimeoutException(
				$"Wait for [{waitForMessage}] failed in {stopwatch.Elapsed}. " +
				getDataResultMessage);
		}

		public async Task<TResult?> WaitForEntityAndCheck<TDataProvider, TResult>(
			Func<TDataProvider, Task<TResult>> getDataFunc,
			TDataProvider dataProvider,
			Func<TResult?, bool> checkDataFunc,
			string waitForMessage = "",
			TimeSpan? customTimeout = null,
			TimeSpan? customSpinTime = null)
		{
			var timeout = ParameterHelper.GetCustomIfNotNull(_defaultTimeout, customTimeout);
			var spinTime = ParameterHelper.GetCustomIfNotNull(_defaultSpinTime, customSpinTime);
			waitForMessage = string.IsNullOrWhiteSpace(waitForMessage) ? typeof(TResult).Name : waitForMessage;

			TResult? result = default;
			var stopwatch = Stopwatch.StartNew();
			while (stopwatch.Elapsed < timeout)
			{
				try
				{
					result = await getDataFunc.Invoke(dataProvider);
					if (result != null)
					{
						var checkResult = checkDataFunc.Invoke(result);
						if (checkResult)
						{
							_logger.Debug($"Wait for [{waitForMessage}] completed in {stopwatch.Elapsed}.");
							return result;
						}
					}
				}
				catch (Exception e)
				{
					_logger.Error($"Wait for [{waitForMessage}] failed with error: [{e.Message}].", e);
					throw;
				}

				await Task.Delay(spinTime).ConfigureAwait(false);
			}

			var getDataResult = "";
			if (result != null)
			{
				getDataResult = "not ";
			}

			var getDataResultMessage = $"GetDataFunc output is {getDataResult}null";

			throw new TimeoutException($"Wait for [{waitForMessage}] failed in {stopwatch.Elapsed}. " +
			                           getDataResultMessage);
		}

		public async Task WaitForCondition(
			Func<Task<bool>> getAndCheckDataFunc,
			string waitForMessage,
			TimeSpan? customTimeout = null,
			TimeSpan? customSpinTime = null)
		{
			var timeout = _defaultTimeout;
			var spinTime = _defaultSpinTime;
			if (customTimeout != null)
			{
				timeout = (TimeSpan)customTimeout;
			}

			if (customSpinTime != null)
			{
				spinTime = (TimeSpan)customSpinTime;
			}

			var stopwatch = Stopwatch.StartNew();
			while (stopwatch.Elapsed < timeout)
			{
				try
				{
					var result = await getAndCheckDataFunc.Invoke();
					if (result)
					{
						_logger.Debug($"Wait for [{waitForMessage}] completed in {stopwatch.Elapsed}.");
						return;
					}
				}
				catch (Exception e)
				{
					_logger.Error($"Wait for [{waitForMessage}] failed with error: [{e.Message}].", e);
					throw;
				}

				await Task.Delay(spinTime);
			}

			throw new TimeoutException($"Wait for [{waitForMessage}] failed to get in {stopwatch.Elapsed}.");
		}
	}
}