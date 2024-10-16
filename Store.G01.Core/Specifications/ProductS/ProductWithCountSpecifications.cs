using Store.G01.Core.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.G01.Core.Specifications.ProductS
{
	public class ProductWithCountSpecifications : BaseSpecifications<Product, int>
	{
		public ProductWithCountSpecifications(ProductSpecParams productSpecParams) : base(
			p =>
			(string.IsNullOrEmpty(productSpecParams.Search) || p.Name.ToLower().Contains(productSpecParams.Search))
			&&
			(!productSpecParams.BrandId.HasValue || productSpecParams.BrandId == p.BrandId)
			&&
			(!productSpecParams.TypeId.HasValue || productSpecParams.TypeId == p.TypeId)
			)
		{

		}
	}
}
