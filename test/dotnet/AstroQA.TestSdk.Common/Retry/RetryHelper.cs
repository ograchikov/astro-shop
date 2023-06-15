namespace AstroQA.TestSdk.Common.Retry
{
	using System;
	using System.Threading;
	using System.Threading.Tasks;
	using AstroQA.TestSdk.Common.Parameters;

	public class RetryHelper : IRetryHelper
	{
		private readonly int _maxRetryAttempts;
		private readonly TimeSpan _defaultSpinTime;

		public RetryHelper(int maxRetryAttempts, TimeSpan defaultSpinTime)
		{
			_maxRetryAttempts = maxRetryAttempts;
			_defaultSpinTime = defaultSpinTime;
		}

		public TResult ExecuteWithRetry<TResult>(Func<TResult> getDataFunc, TimeSpan? customSpinTime = null)
		{
			var spinTime = ParameterHelper.GetCustomIfNotNull(_defaultSpinTime, customSpinTime);
			var attempt = _maxRetryAttempts;
			Exception lastEx;
			do
			{
				try
				{
					return getDataFunc();
				}
				catch (Exception ex)
				{
					lastEx = ex;
					Console.WriteLine(ex.GetBaseException().Message);
					Thread.Sleep(spinTime);
				}
			} while (--attempt > 0);

			throw lastEx;
		}

		public async Task<TResult> ExecuteWithRetryAsync<TResult>(Func<Task<TResult>> getDataFunc,
			TimeSpan? customSpinTime = null)
		{
			var spinTime = ParameterHelper.GetCustomIfNotNull(_defaultSpinTime, customSpinTime);
			var attempt = _maxRetryAttempts;
			Exception lastEx;
			do
			{
				try
				{
					return await getDataFunc();
				}
				catch (Exception ex)
				{
					lastEx = ex;
					Console.WriteLine(ex.GetBaseException().Message);
					await Task.Delay(spinTime);
				}
			} while (--attempt > 0);

			throw lastEx;
		}
	}
}