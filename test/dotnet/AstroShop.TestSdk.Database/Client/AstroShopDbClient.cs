﻿namespace AstroShop.TestSdk.Database.Client;

using AstroQA.TestSdk.Database.Context;
using AstroShop.TestSdk.Database.Context;
using AstroShop.TestSdk.Domain.Model;
using Microsoft.EntityFrameworkCore;

public class AstroShopDbClient : IAstroShopDbClient
{
	private readonly IDatabaseContextFactory<AstroShopDbContext> _factory;

	public AstroShopDbClient(IDatabaseContextFactory<AstroShopDbContext> factory)
	{
		_factory = factory;
	}

	public async Task<IReadOnlyCollection<ProductInfo>> GetProducts()
	{
		await using var context = _factory.CreateContext();
		return await context.Products
			.AsNoTracking()
			.ToListAsync()
			.ConfigureAwait(false);
	}

	public async Task<ProductInfo?> GetProduct(int productId)
	{
		await using var context = _factory.CreateContext();
		return await context.Products
			.AsNoTracking()
			.FirstOrDefaultAsync(x => x.ProductId == productId)
			.ConfigureAwait(false);
	}

	public async Task<IReadOnlyCollection<ProductInfo>> GetProducts(List<int> productsId)
	{
		await using var context = _factory.CreateContext();
		return await context.Products
			.AsNoTracking()
			.Where(x => productsId.Contains(x.ProductId))
			.ToListAsync()
			.ConfigureAwait(false);
	}
}