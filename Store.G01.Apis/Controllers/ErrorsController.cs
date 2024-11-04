using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Store.G01.Apis.Error;

namespace Store.G01.Apis.Controllers
{
	[Route("error/{code}")]
	[ApiController]
	[ApiExplorerSettings(IgnoreApi =true)]
	public class ErrorsController : ControllerBase
	{

		public IActionResult Error(int code)
		{
			return NotFound(new ApiErrorResponce(404,"Not Found End Point! "));
		}

	}
}
