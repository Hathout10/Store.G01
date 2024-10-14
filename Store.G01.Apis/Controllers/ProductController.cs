using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Store.G01.Core.ServicesContract;

namespace Store.G01.Apis.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ProductController : ControllerBase
	{
		private readonly IproductService _productService;

		public ProductController(IproductService productService)
        {
			_productService = productService;
		}

        [HttpGet] //Get BaseUrl/api/Products
		public async Task<IActionResult> GetAllProducts([FromQuery]string? sort,[FromQuery] int? brandid,[FromQuery]int? typeid) //endpoint
		{

			var result= await _productService.GetAllProductsAsync(sort, brandid, typeid);
			return Ok(result);
		}

		[HttpGet("brands")]  // Get BaseUrl/api/Products/brands
		public async Task<IActionResult> GetAllBrand()
		{
			var result=await _productService.GetAllBrandsAsync();
			return Ok(result);
		}

		[HttpGet("types")]  // Get BaseUrl/api/Products/types

		public async Task<IActionResult> GetAllTypes()
		{
			var result = await _productService.GetAllTypesAsync();
			return Ok(result);
		}

		[HttpGet("{id}")] //BaseUrl/api/Products/id
		public async Task<IActionResult> GetProductById(int? id)
		{
			if(id == null) return BadRequest("Invalid id !!");
			var result=await _productService.GetProductsByIdAsync(id.Value);

			if (result == null) return NotFound($"the product with id :{id} not found at DB");
			return Ok(result);
		}
	}
}
