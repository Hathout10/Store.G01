using Store.G01.Core.Dtos.Products;
using Store.G01.Core.Entites;
using Store.G01.Core.Helper;
using Store.G01.Core.Specifications.ProductS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.G01.Core.ServicesContract
{
    public interface IproductService
	{



        Task<PaginationResponse<ProductDto>> GetAllProductsAsync(ProductSpecParams productSpecParams );
        Task<IEnumerable<TypeBrandDto>> GetAllTypesAsync();
        Task<IEnumerable<TypeBrandDto>> GetAllBrandsAsync();
        Task<ProductDto> GetProductsByIdAsync(int id);

    }
}
