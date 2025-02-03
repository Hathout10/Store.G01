using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Store.G01.Core.ServicesContract;
using Store.G01.Service.Serveices.Caches;
using System.Text;

namespace Store.G01.Apis.Attributes
{
	public class CachedAttribute : Attribute, IAsyncActionFilter
	{
		private readonly int _expirTime;

		public CachedAttribute(int expirTime)
		{
			_expirTime = expirTime;
		}

		public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
		{
			var casheService = context.HttpContext.RequestServices.GetRequiredService<IcacheService>();

			var cacheKey = GenerateCacheKeyFromRequest(context.HttpContext.Request);

			var cacheResponse = await casheService.GetCasheKeyAsync(cacheKey);

			if (! string.IsNullOrEmpty(cacheResponse))
			{
				var contentResult = new ContentResult()
				{
					Content = cacheResponse,
					ContentType = "application/json",
					StatusCode = 200
				};

				context.Result = contentResult;
				return;
			}

			var executedContext= await next();

			if (executedContext.Result is OkObjectResult response)
			{
				await casheService.SetCasheKeyAsync(cacheKey, response.Value, TimeSpan.FromSeconds(_expirTime));
			}


		}

		private string GenerateCacheKeyFromRequest(HttpRequest request)
		{
			var cacheKey = new StringBuilder();
			cacheKey.Append($"{request.Path}");

			foreach (var (key, value) in request.Query.OrderBy(x => x.Key))
			{
				cacheKey.Append($"|{key}-{value}");
			}

			return cacheKey.ToString();
		}

	}
}
