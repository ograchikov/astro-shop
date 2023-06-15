namespace AstroShop.TestSdk.Web.Asserts;

using AstroShop.TestSdk.Domain.Model;
using System.Collections;

public class ProductInfoComparer : IComparer
{
	public int Compare(object? x, object? y)
	{
		if (x == null) throw new ArgumentNullException(nameof(x));
		if (y == null) throw new ArgumentNullException(nameof(y));
		var productX = (ProductInfo)x;
		var productY = (ProductInfo)y;

		// Compare Id
		var idComparison = productX.ProductId.CompareTo(productY.ProductId);
		if (idComparison != 0)
		{
			return idComparison;
		}

		switch (productX.Name)
		{
			// Compare Name (considering null values)
			case null:
				return -1;
			default:
			{
				{
					var nameComparison = string.Compare(
						productX.Name, 
						productY.Name, 
						StringComparison.Ordinal);
					if (nameComparison != 0)
					{
						return nameComparison;
					}
				}
				break;
			}
		}

		return productX.Price switch
		{
			// Compare Price (considering null values)
			null when productY.Price == null => 0,
			null => -1,
			_ => productY.Price switch
			{
				null => 1,
				_ => productX.Price.Value.CompareTo(productY.Price.Value)
			}
		};
	}
}
