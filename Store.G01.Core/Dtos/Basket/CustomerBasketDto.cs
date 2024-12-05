using Store.G01.Core.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.G01.Core.Dtos.Basket
{
	public class CustomerBasketDto
	{
		public string Id { get; set; }

		public List<BasketItem> Items { get; set; }

	}
}
