using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Store.G01.Apis.Error;
using Store.G01.Core.Dtos.Products;
using Store.G01.Core.Helper;
using Store.G01.Core.ServicesContract;
using Store.G01.Core.Specifications.ProductS;

namespace Store.G01.Apis.Controllers
{
	
	public class ProductController : BaseApiController
	{
		private readonly IproductService _productService;

		public ProductController(IproductService productService)
        {
			_productService = productService;
		}



		[ProducesResponseType(typeof(PaginationResponse<ProductDto>), StatusCodes.Status200OK )]
        [HttpGet] //Get BaseUrl/api/Products
		public async Task<ActionResult<PaginationResponse<ProductDto>>> GetAllProducts([FromQuery]ProductSpecParams productSpecParams) //endpoint
		{

			var result= await _productService.GetAllProductsAsync(productSpecParams);
			return Ok(result);
		}


		[ProducesResponseType(typeof(IEnumerable<TypeBrandDto>), StatusCodes.Status200OK)]
		[HttpGet("brands")]  // Get BaseUrl/api/Products/brands
		public async Task<ActionResult<IEnumerable<TypeBrandDto>>> GetAllBrand()
		{
			var result=await _productService.GetAllBrandsAsync();
			return Ok(result);
		}


		[ProducesResponseType(typeof(IEnumerable<TypeBrandDto>), StatusCodes.Status200OK)]
		[HttpGet("types")]  // Get BaseUrl/api/Products/types

		public async Task<ActionResult<IEnumerable<TypeBrandDto>>> GetAllTypes()
		{
			var result = await _productService.GetAllTypesAsync();
			return Ok(result);
		}


		[ProducesResponseType(typeof(ProductDto), StatusCodes.Status200OK)]
		[ProducesResponseType(typeof(ProductDto), StatusCodes.Status400BadRequest)]
		[ProducesResponseType(typeof(ProductDto), StatusCodes.Status404NotFound)]
		[HttpGet("{id}")] //BaseUrl/api/Products/id
		public async Task<ActionResult<ProductDto>> GetProductById(int? id)
		{
			if(id == null) return BadRequest(new ApiErrorResponce(400));
			var result=await _productService.GetProductsByIdAsync(id.Value);

			if (result == null) return NotFound(new ApiErrorResponce(404, $"the product with id :{id} not found at DB"));
			return Ok(result);
		}
	}
}
