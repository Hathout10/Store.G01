using Store.G01.Core.Entites;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.G01.Core.RepostitoriesContract
{
	public interface IBasketRepository
	{

		Task<CustomerBasket?> GetBasketAsync (string basketId);
		Task<CustomerBasket?> UpdateBasketAsync (CustomerBasket basket);
		Task<bool> DeleteBasketAsync (string basketId);

	}
}
