using AutoMapper;
using Store.G01.Core.Dtos.Products;
using Store.G01.Core.Entites;
using Store.G01.Core.Helper;
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
		public async Task<PaginationResponse<ProductDto>> GetAllProductsAsync(ProductSpecParams productSpecParams)
		{


			var spec = new ProductSpecification(productSpecParams);
			var products= await _unitOfWork.Repository<Product, int>().GetAllWithSpecAsync(spec);
			var mappedproduct= _mapper.Map<IEnumerable<ProductDto>>(products);

			var countspec = new ProductWithCountSpecifications(productSpecParams);

			var count = await _unitOfWork.Repository<Product, int>().GetCountAsync(countspec);

			return new PaginationResponse<ProductDto>(productSpecParams.PageSize, productSpecParams.PageIndex, count, mappedproduct);

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
