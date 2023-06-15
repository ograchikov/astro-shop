namespace AstroQA.TestSdk.Common.Parameters
{
	public static class ParameterHelper
	{
		public static TParam GetCustomIfNotNull<TParam>(TParam defaultParameter, TParam? customParameter) where TParam : struct
		{
			var parameter = defaultParameter;
			if (customParameter != null)
			{
				parameter = (TParam)customParameter;
			}
			return parameter;
		}

		public static TParam GetCustomIfNotNull<TParam>(TParam defaultParameter, TParam? customParameter) where TParam : class
		{
			var parameter = defaultParameter;
			if (customParameter != null)
			{
				parameter = customParameter;
			}
			return parameter;
		}
	}
}