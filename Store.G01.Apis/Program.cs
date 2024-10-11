
using Microsoft.EntityFrameworkCore;
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

			builder.Services.AddControllers();
			// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
			builder.Services.AddEndpointsApiExplorer();
			builder.Services.AddSwaggerGen();

			builder.Services.AddDbContext<StoreDbContext>(options =>
			{
				options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
			});

			builder.Services.AddScoped<IproductService, ProductService>();
			builder.Services.AddScoped<IUnitOfWork, UniteOfWork>();
			builder.Services.AddAutoMapper(m => m.AddProfile(new ProductProfile()));

			var app = builder.Build();

			#region Update Database

			using var scope = app.Services.CreateScope();
			var services = scope.ServiceProvider;

			var context = services.GetRequiredService<StoreDbContext>();
			var loggerFactory = services.GetRequiredService<ILoggerFactory>();
			try
			{
				await context.Database.MigrateAsync();
				await StoreDbContextSeed.SeedAsync(context);
			}
			catch (Exception ex)
			{
				var logger = loggerFactory.CreateLogger<Program>();
				logger.LogError(ex, ex.Message);
			}

			//StoreDbContext context = new StoreDbContext();
			//context.Database.MigrateAsync();  //update Database


			#endregion


			// Configure the HTTP request pipeline.
			if (app.Environment.IsDevelopment())
			{
				app.UseSwagger();
				app.UseSwaggerUI();
			}
			app.UseHttpsRedirection();

			app.UseAuthorization();


			app.MapControllers();

			app.Run();
		}
	}
}
