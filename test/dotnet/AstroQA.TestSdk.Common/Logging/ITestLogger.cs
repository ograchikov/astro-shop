namespace AstroQA.TestSdk.Common.Logging;

using System;

public interface ITestLogger
{
	void Trace(string message, params object[] args);
	void Trace(Guid? executionId, string message, params object[] args);
	void Trace(string message);
	void Debug(Guid? executionId, string message, params object[] args);
	void Debug(string message);
	void Debug(string message, params object[] args);
	void Error(Guid? executionId, string message, params object[] args);
	void Error(string message, params object[] args);
	void Error(Exception exception, params object[] args);
	void Error(Exception exception, string message);
	void Error(string message);
	void Info(Guid? executionId, string message, params object[] args);
	void Info(string message, params object[] args);
	void Info(string message);
	void SetExecutionId();
	void SetExecutionId(Guid? executionId);
}