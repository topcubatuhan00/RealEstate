using RealEstateApi.Dtos.ProductDtos;

namespace RealEstateApi.Models.Repositories.ProductRepository;

public interface IProductRepository
{
    Task<List<ResultProductDto>> GetAllProductAsync();
    Task<List<ResultProductWithCategoryDto>> GetAllProductWithCategoryAsync();
}
