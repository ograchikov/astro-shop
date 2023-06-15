namespace AstroQA.TestSdk.Common.Retry;

using System;
using System.Threading.Tasks;

public interface IRetryHelper
{
	TResult ExecuteWithRetry<TResult>(Func<TResult> getDataFunc, TimeSpan? customSpinTime = null);

	Task<TResult> ExecuteWithRetryAsync<TResult>(Func<Task<TResult>> getDataFunc, TimeSpan? customSpinTime = null);
}