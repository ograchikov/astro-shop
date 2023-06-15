namespace AstroQA.TestSdk.Common.Exceptions;

using System;

public class CastSettingException : TestSdkException
{
	public CastSettingException(string settingName) : 
		base($"Setting:'{settingName}'") { }
	
	public CastSettingException(string settingName, string message) : 
		base($"Setting:'{settingName}' message:'{message}'") { }

	public CastSettingException(string settingName, Exception innerException) : 
		base($"Setting:'{settingName}'", innerException) { }
}