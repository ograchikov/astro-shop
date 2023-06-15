namespace AstroShop.TestSdk.Web.TestDataHelpers;

using AstroQA.TestSdk.Common.Data;
using AstroShop.TestSdk.Domain.Model;
using AstroShop.TestSdk.Web.Domain;

public class ProductDataLoader : ILoader<ProductData>
{
	private readonly string _filePath;

	private readonly IDataAdapter<ProductInfo[]> _adapter;

	public ProductDataLoader(IDataAdapter<ProductInfo[]> adapter, ProductDataFilePath filePath)
	{
		_filePath = filePath.Value;
		_adapter = adapter;
	}

	public async Task<ProductData> Load()
	{
		var data = await _adapter.LoadData(_filePath);
		return new ProductData(data);
	} 
}