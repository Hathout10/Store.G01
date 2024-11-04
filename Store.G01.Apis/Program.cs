
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Store.G01.Apis.Error;
using Store.G01.Apis.Helper;
using Store.G01.Apis.Middlewares;
using Store.G01.Core.Mapping.Products;
using Store.G01.Core.RepostitoriesContract;
using Store.G01.Core.ServicesContract;
using Store.G01.Repository;
using Store.G01.Repository.Data;
using Store.G01.Repository.Data.Contexts;
using Store.G01.Service.Serveices.Products;

namespace Store.G01.Apis
{
	public class Program
	{
		public static async Task Main(string[] args)
		{
			var builder = WebApplication.CreateBuilder(args);

			// Add services to the container.

			builder.Services.AddDependency(builder.Configuration);


			

		

			var app = builder.Build();

		 await	app.ConfigureMiddleWares();


		}
	}
}
