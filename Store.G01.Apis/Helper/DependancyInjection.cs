using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Store.G01.Apis.Error;
using Store.G01.Core.Mapping.Products;
using Store.G01.Core.RepostitoriesContract;
using Store.G01.Core.ServicesContract;
using Store.G01.Repository;
using Store.G01.Repository.Data.Contexts;
using Store.G01.Service.Serveices.Products;

namespace Store.G01.Apis.Helper
{
	public static class DependancyInjection
	{
		public static IServiceCollection AddDependency(this IServiceCollection services, IConfiguration configuration)
		{

			services.AddBuiltInServece();
			services.AddSwaggerServece();
			services.AddDbContextServece(configuration);
			services.AddUserDefinedServece();
			services.AddAutoMapperServece(configuration);
			services.ConfigureInvalidModelStateResponseServece();

			return services;
		}

		public static IServiceCollection AddBuiltInServece(this IServiceCollection services)
		{

			services.AddControllers();

			return services;
		}

		public static IServiceCollection AddSwaggerServece(this IServiceCollection services)
		{

			// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
			services.AddEndpointsApiExplorer();
			services.AddSwaggerGen();


			return services;
		}


		public static IServiceCollection AddDbContextServece(this IServiceCollection services, IConfiguration configuration)
		{

			services.AddDbContext<StoreDbContext>(options =>
			{
				options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
			});


			return services;
		}

		public static IServiceCollection AddUserDefinedServece(this IServiceCollection services)
		{

			services.AddScoped<IproductService, ProductService>();
			services.AddScoped<IUnitOfWork, UniteOfWork>();


			return services;
		}
		public static IServiceCollection AddAutoMapperServece(this IServiceCollection services, IConfiguration configuration)
		{

			services.AddAutoMapper(m => m.AddProfile(new ProductProfile(configuration)));


			return services;
		}

		public static IServiceCollection ConfigureInvalidModelStateResponseServece(this IServiceCollection services)
		{

			services.Configure<ApiBehaviorOptions>(options =>
			{

				options.InvalidModelStateResponseFactory = (actionContext) =>
				{
					var errors = actionContext.ModelState.Where(p => p.Value.Errors.Count() > 0)
											.SelectMany(p => p.Value.Errors)
											.Select(e => e.ErrorMessage)
											.ToArray();



					var response = new ApiValidationError()
					{
						Errors = errors
					};
					return new BadRequestObjectResult(response);
				};

			});

			return services;
		}
	}
}