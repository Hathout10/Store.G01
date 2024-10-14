using AutoMapper;
using AutoMapper.Execution;
using Microsoft.Extensions.Configuration;
using Store.G01.Core.Dtos.Products;
using Store.G01.Core.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.G01.Core.Mapping.Products
{
	public class PictureUrlResolver : IValueResolver<Product,ProductDto,string>
	{
		private readonly IConfiguration configuration;

		public PictureUrlResolver(IConfiguration configuration) 
		{
			this.configuration = configuration;
		}

		public string Resolve(Product source, ProductDto destination, string destMember, ResolutionContext context)
		{
			return $"{configuration["BaseUrl"]}{source.PictureUrl}";
		}
	}
}
