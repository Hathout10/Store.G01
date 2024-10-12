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
        public ProductSpecification()
        {
			ApplyIncluds();

		}

        private void ApplyIncluds()
		{
			Include.Add(p => p.Brand);
			Include.Add(p => p.Type);
		}


	}
}
