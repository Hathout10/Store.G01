using Microsoft.AspNetCore.Builder;
using Store.G01.Apis.Middlewares;
using Store.G01.Repository.Data.Contexts;
using Store.G01.Repository.Data;
using Microsoft.EntityFrameworkCore;

namespace Store.G01.Apis.Helper
{
	public static class ConfigureMiddleWare
	{

      public static async Task<IApplicationBuilder> ConfigureMiddleWares(this WebApplication app)
		{
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



			app.UseMiddleware<ExceptionMiddleware>();  // configure usrer-Defiend MiddleWare

			// Configure the HTTP request pipeline.
			if (app.Environment.IsDevelopment())
			{
				app.UseSwagger();
				app.UseSwaggerUI();
			}

			app.UseStatusCodePagesWithReExecute("/error/{0}");

			app.UseHttpsRedirection();

			app.UseAuthorization();


			app.MapControllers();

			app.Run();

			return app;
		}

	}
}
