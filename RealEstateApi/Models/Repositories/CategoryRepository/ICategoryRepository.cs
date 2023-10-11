using RealEstateApi.Dtos.CategoryDtos;

namespace RealEstateApi.Models.Repositories.CategoryRepository;

public interface ICategoryRepository
{
    Task<List<ResultCategoryDto>> GetAllCategoryAsync();
}
