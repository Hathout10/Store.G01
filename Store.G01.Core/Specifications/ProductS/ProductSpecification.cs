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
		public ProductSpecification(ProductSpecParams productSpecParams) : base(
			p =>
			(string.IsNullOrEmpty(productSpecParams.Search) || p.Name.ToLower().Contains(productSpecParams.Search))
			&&
			(!productSpecParams.BrandId.HasValue || productSpecParams.BrandId == p.BrandId)
			&&
			(!productSpecParams.TypeId.HasValue || productSpecParams.TypeId == p.TypeId)
			)
		{
			if (!string.IsNullOrEmpty(productSpecParams.Sort))
			{
				switch (productSpecParams.Sort.ToLower())
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

			//900
			//page size :50
			//page index:3

			ApplyPagination(productSpecParams.PageSize * (productSpecParams.PageIndex - 1), productSpecParams.PageSize);

		}

		private void ApplyIncluds()
		{
			Include.Add(p => p.Brand);
			Include.Add(p => p.Type);
		}


	}
}
