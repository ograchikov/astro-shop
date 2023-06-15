namespace AstroShop.TestSdk.Database.Client;

using AstroShop.TestSdk.Domain.Model;

public interface IAstroShopDbClient
{
	Task<IReadOnlyCollection<ProductInfo>> GetProducts();
	Task<IReadOnlyCollection<ProductInfo>> GetProducts(List<int> productsId);
	Task<ProductInfo?> GetProduct(int productId);
}