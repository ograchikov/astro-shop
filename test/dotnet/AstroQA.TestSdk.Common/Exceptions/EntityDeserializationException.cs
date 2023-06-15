namespace AstroQA.TestSdk.Common.Exceptions;

using System;

public class EntityDeserializationException : TestSdkException
{
	public EntityDeserializationException(string entityName) : 
		base($"Entity:'{entityName}'") { }
	
	public EntityDeserializationException(string entityName, string message) : 
		base($"Entity:'{entityName}' message:'{message}'") { }

	public EntityDeserializationException(string entityName, Exception innerException) : 
		base($"Entity:'{entityName}'", innerException) { }
}