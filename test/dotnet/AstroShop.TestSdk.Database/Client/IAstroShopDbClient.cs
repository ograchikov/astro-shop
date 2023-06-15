namespace AstroShop.TestSdk.Database.Client;

using AstroShop.TestSdk.Domain.Model;

public interface IAstroShopDbClient
{
	Task<ProductInfo?> GetProduct(int productId);
	Task<ProductInfo?> WaitAndGetProduct(int productId);
	Task<IReadOnlyCollection<ProductInfo>> GetProducts();
	Task<IReadOnlyCollection<ProductInfo>> GetProducts(List<int> productsId);
}