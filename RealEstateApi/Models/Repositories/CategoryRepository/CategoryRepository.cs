using Dapper;
using RealEstateApi.Dtos.CategoryDtos;
using RealEstateApi.Models.DapperContext;

namespace RealEstateApi.Models.Repositories.CategoryRepository;

public class CategoryRepository : ICategoryRepository
{
    #region Fields
    private readonly Context _context;
    #endregion


    #region Ctor
    public CategoryRepository
    (
        Context context
    )
    {
        _context = context;
    }
    #endregion


    #region Methods
    public async Task<List<ResultCategoryDto>> GetAllCategoryAsync()
    {
        string query = "select * from category";
        using (var connection = _context.CreateConnection())
        {
            var values = await connection.QueryAsync<ResultCategoryDto>(query);
            return values.ToList();
        }
    }
    #endregion

}
