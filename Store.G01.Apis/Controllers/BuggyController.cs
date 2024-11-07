using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Store.G01.Apis.Error;
using Store.G01.Repository.Data.Contexts;

namespace Store.G01.Apis.Controllers
{
	public class BuggyController : BaseApiController
	{
		private readonly StoreDbContext _context;

		public BuggyController(StoreDbContext context)
		{
			_context = context;
		}

		[HttpGet("notfound")] // Get : /api/Buggy/notfound
		public async Task<IActionResult> GetNotFoundRequestError()
		{
			var brand = await _context.Brands.FindAsync(100);

			if (brand == null) return NotFound(new ApiErrorResponce(404));

			return Ok(brand);

		}


		[HttpGet("servererror")] // Get : /api/Buggy/servererror
		public async Task<IActionResult> GetServerError()
		{
			var brand = await _context.Brands.FindAsync(100);

			var brandtostring = brand.ToString();  //will throw exception 

			return Ok(brand);

		}


		[HttpGet("badrequest")] // Get : /api/Buggy/badrequest
		public async Task<IActionResult> GetBadRequestError()
		{
			return BadRequest(new ApiErrorResponce(400));

		}

		[HttpGet("badrequest/{id}")] // Get : /api/Buggy/badrequest/ahmed
		public async Task<IActionResult> GetBadRequestError(int id) // validation error
		{
			return Ok();

		}

		[HttpGet("unauithorized")] // Get : /api/Buggy/unauithorized
		public async Task<IActionResult> GetUnauthorizedError(int id) // validation error
		{
			return Unauthorized(new ApiErrorResponce(401));

		}


	}
}