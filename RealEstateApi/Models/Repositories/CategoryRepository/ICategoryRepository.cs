using RealEstateApi.Dtos.CategoryDtos;

namespace RealEstateApi.Models.Repositories.CategoryRepository;

public interface ICategoryRepository
{
    Task<List<ResultCategoryDto>> GetAllCategoryAsync();
    Task CreateCategoryAsync(CreateCategoryDto createCategoryDto);
    Task DeleteCategoryAsync(int id);
    Task UpdateCategoryAsync(UpdateCategoryDto updateCategoryDto);
    Task<GetByIdCategoryDto> GetCategoryAsync(int id);
}
