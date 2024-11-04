using AutoMapper;
using Store.G01.Core.Dtos.Products;
using Store.G01.Core.Entites;
using Store.G01.Core.RepostitoriesContract;
using Store.G01.Core.ServicesContract;
using Store.G01.Core.Specifications;
using Store.G01.Core.Specifications.ProductS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.G01.Service.Serveices.Products
{
	public class ProductService : IproductService
	{
		private readonly IUnitOfWork _unitOfWork;
		private readonly IMapper _mapper;

		public ProductService(IUnitOfWork unitOfWork,IMapper mapper)
        {
			_unitOfWork = unitOfWork;
			_mapper = mapper;
		}
		public async Task<IEnumerable<ProductDto>> GetAllProductsAsync(string? sort, int? brandid, int? typeid)
		{


			var spec = new ProductSpecification(sort, brandid, typeid);
			var products= await _unitOfWork.Repository<Product, int>().GetAllWithSpecAsync(spec);
			return _mapper.Map<IEnumerable<ProductDto>>(products);

		}
		public async Task<ProductDto> GetProductsByIdAsync(int id)
		{
			var spec = new ProductSpecification(id);

			return _mapper.Map<ProductDto>(await _unitOfWork.Repository<Product, int>().GetWithSpecAsync(spec));

		}

		public async Task<IEnumerable<TypeBrandDto>> GetAllTypesAsync()
		{
			return _mapper.Map<IEnumerable<TypeBrandDto>>(await _unitOfWork.Repository<ProductType, int>().GetAllAsync());
		}

		public async Task<IEnumerable<TypeBrandDto>> GetAllBrandsAsync()
		{
			return _mapper.Map<IEnumerable<TypeBrandDto>>(await _unitOfWork.Repository<ProductBrand, int>().GetAllAsync());

		}



		
	}
}
