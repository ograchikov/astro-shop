namespace AstroShop.Products.Database.Context;

using AstroShop.Products.Domain.Entities;
using Microsoft.EntityFrameworkCore;

public interface IProductsDbContext
{
	DbSet<ProductInfo> ProductInfos { get; set; }
	DbSet<PriceList> PriceLists { get; set; }
	DbSet<ProductPrice> ProductPrices { get; set; }
}