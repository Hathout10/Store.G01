using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.G01.Core.ServicesContract
{
	public interface IcacheService
	{

		Task SetCasheKeyAsync(string Key, object response, TimeSpan expireTime);
		Task<string> GetCasheKeyAsync(string key);

	}
}
