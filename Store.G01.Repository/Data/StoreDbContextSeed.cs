using Store.G01.Core.Entites;
using Store.G01.Repository.Data.Contexts;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Store.G01.Repository.Data
{
	public static class StoreDbContextSeed
	{
		public async static Task SeedAsync(StoreDbContext _context)
		{
			if(_context.Brands.Count()==0)
			{
				//Brand
				//1.Read data from json file

				var brandsData = File.ReadAllText(@"..\Store.G01.Repository\Data\DataSeed\brands.json");

				//	F:\شيتات\Api\Store.G01\Store.G01.Repository\Data\DataSeed

				var brands = JsonSerializer.Deserialize<List<ProductBrand>>(brandsData);

				//seed data to Db
				if (brands is not null && brands.Count() > 0)
				{
					await _context.Brands.AddRangeAsync(brands);
					await _context.SaveChangesAsync();
				}
			}

			if (_context.Types.Count() == 0)
			{
				//Brand
				//1.Read data from json file

				var TypesData = File.ReadAllText(@"..\Store.G01.Repository\Data\DataSeed\types.json");

				//	F:\شيتات\Api\Store.G01\Store.G01.Repository\Data\DataSeed

				var Types = JsonSerializer.Deserialize<List<ProductType>>(TypesData);

				//seed data to Db
				if (Types is not null && Types.Count() > 0)
				{
					await _context.Types.AddRangeAsync(Types);
					await _context.SaveChangesAsync();
				}
			}

			if (_context.Products.Count() == 0)
			{
				//Brand
				//1.Read data from json file

				var productsData = File.ReadAllText(@"..\Store.G01.Repository\Data\DataSeed\products.json");

				//	F:\شيتات\Api\Store.G01\Store.G01.Repository\Data\DataSeed

				var products = JsonSerializer.Deserialize<List<Product>>(productsData);

				//seed data to Db
				if (products is not null && products.Count() > 0)
				{
					await _context.Products.AddRangeAsync(products);
					await _context.SaveChangesAsync();
				}
			}



		}
	}
}
