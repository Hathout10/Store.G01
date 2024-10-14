using Store.G01.Core.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.G01.Core.Specifications.ProductS
{
	public class ProductSpecification : BaseSpecifications<Product, int>
	{
		public ProductSpecification(int id) : base(p => p.Id == id)
		{
			ApplyIncluds();

		}
		public ProductSpecification(string? sort, int? brandid, int? typeid) : base(
			p =>
			(!brandid.HasValue || brandid == p.BrandId)
			&&
			(!typeid.HasValue || typeid == p.TypeId)
			)
		{
			if (!string.IsNullOrEmpty(sort))
			{
				switch (sort.ToLower())
				{
					case "priceasc":
						AddOrderBy(p => p.Price);
						break;
					case "pricedesc":
						AddOrderByDescinding(p => p.Price);
						break;
					default:
						AddOrderBy(p => p.Name);
						break;
				}
			}
			else
			{
				AddOrderBy(p => p.Name);

			}
			ApplyIncluds();


		}

		private void ApplyIncluds()
		{
			Include.Add(p => p.Brand);
			Include.Add(p => p.Type);
		}


	}
}
