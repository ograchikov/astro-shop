namespace AstroQA.TestSdk.Common.Exceptions;

using System;

public class SettingNotFoundException : TestSdkException
{
	public SettingNotFoundException(string settingName) : 
		base($"Setting:'{settingName}'") { }
	
	public SettingNotFoundException(string settingName, string message) : 
		base($"Setting:'{settingName}' message:'{message}'") { }

	public SettingNotFoundException(string settingName, Exception innerException) : 
		base($"Setting:'{settingName}'", innerException) { }
}