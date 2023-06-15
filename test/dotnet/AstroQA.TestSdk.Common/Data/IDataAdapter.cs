namespace AstroQA.TestSdk.Common.Data;

public interface IDataAdapter<TData>
{
	Task<TData> LoadData(string filePath);
}
