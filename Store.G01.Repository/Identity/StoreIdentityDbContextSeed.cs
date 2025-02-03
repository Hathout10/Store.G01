using Microsoft.AspNetCore.Identity;
using Store.G01.Core.Entites.identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.G01.Repository.Identity
{
	public class StoreIdentityDbContextSeed
	{

		public async static Task SeedAppUserAsync(UserManager<AppUser> _usermanager)
		{
			if(_usermanager.Users.Count()==0)
			{
				var user = new AppUser()
				{
					Email = "mohamedhathout263@gmail.com",
					DisplayName = "Mohamed Hathout",
					UserName = "mohamed.hathout",
					PhoneNumber = "01096596731",
					Address = new Address()
					{
						FName = "mohamed",
						LName = "hathout",
						City = "menoufia",
						Country = "Egypt",
						Street = "Tareek barhim",

					}
				};
				await _usermanager.CreateAsync(user, "P@ssW0rd");
			}
		}

	}
}
