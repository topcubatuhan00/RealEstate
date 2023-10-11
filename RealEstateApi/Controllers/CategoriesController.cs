using Microsoft.AspNetCore.Mvc;
using RealEstateApi.Dtos.CategoryDtos;
using RealEstateApi.Models.Repositories.CategoryRepository;

namespace RealEstateApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CategoriesController : ControllerBase
{
    #region Fields
    private readonly ICategoryRepository _categoryRepository;
    #endregion

    #region Ctor
    public CategoriesController(ICategoryRepository categoryRepository)
    {
        _categoryRepository = categoryRepository;
    }
    #endregion

    #region Methods
    [HttpGet]
    public async Task<IActionResult> CategoryList()
    {
        var values = await _categoryRepository.GetAllCategoryAsync();
        return Ok(values);
    }

    [HttpPost]
    public async Task<IActionResult> CreateCategory(CreateCategoryDto createCategoryDto)
    {
        await _categoryRepository.CreateCategoryAsync(createCategoryDto);
        return Ok("Success Added");
    }

    [HttpDelete]
    public async Task<IActionResult> DeleteCategory(int id)
    {
        await _categoryRepository.DeleteCategoryAsync(id);
        return Ok("Success Delete");
    }

    [HttpPut]
    public async Task<IActionResult> UpdateCategory(UpdateCategoryDto updateCategoryDto)
    {
        await _categoryRepository.UpdateCategoryAsync(updateCategoryDto);
        return Ok("Success Update");
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetCategory(int id)
    {
        var value = await _categoryRepository.GetCategoryAsync(id);
        return Ok(value);
    }
    #endregion
}
