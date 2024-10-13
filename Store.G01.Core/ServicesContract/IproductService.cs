using Store.G01.Core.Dtos.Products;
using Store.G01.Core.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.G01.Core.ServicesContract
{
    public interface IproductService
    {



        Task<IEnumerable<ProductDto>> GetAllProductsAsync(string? sort);
        Task<IEnumerable<TypeBrandDto>> GetAllTypesAsync();
        Task<IEnumerable<TypeBrandDto>> GetAllBrandsAsync();
        Task<ProductDto> GetProductsByIdAsync(int id);

    }
}
