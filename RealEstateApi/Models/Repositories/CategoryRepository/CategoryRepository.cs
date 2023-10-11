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

    public async Task CreateCategoryAsync(CreateCategoryDto createCategoryDto)
    {
        string query = "insert into category (CategoryName, CategoryStatus) values (@name, @status)";

        var parameters = new DynamicParameters();
        parameters.Add("@name", createCategoryDto.CategoryName);
        parameters.Add("@status", true);

        using (var connection = _context.CreateConnection())
        {
            await connection.ExecuteAsync(query, parameters);
            await Task.CompletedTask;
        }
    }

    public async Task DeleteCategoryAsync(int id)
    {
        string query = "delete from category where CategoryId=@id";

        var parameters = new DynamicParameters();
        parameters.Add("@id", id);

        using (var connection = _context.CreateConnection())
        {
            await connection.ExecuteAsync(query, parameters);
            await Task.CompletedTask;
        }
    }

    public async Task UpdateCategoryAsync(UpdateCategoryDto updateCategoryDto)
    {
        string query = "update category set CategoryName=@name, CategoryStatus=@status where CategoryId=@id";

        var parameters = new DynamicParameters();
        parameters.Add("@name", updateCategoryDto.CategoryName);
        parameters.Add("@status", updateCategoryDto.CategoryStatus);
        parameters.Add("@id", updateCategoryDto.CategoryId);

        using (var connection = _context.CreateConnection())
        {
            await connection.ExecuteAsync(query, parameters);
            await Task.CompletedTask;
        }
    }

    public async Task<GetByIdCategoryDto> GetCategoryAsync(int id)
    {
        string query = "select * from category where CategoryId=@id";
        var parameters = new DynamicParameters();
        parameters.Add("@id", id);

        using (var connection = _context.CreateConnection())
        {
            var value = await connection.QueryFirstOrDefaultAsync<GetByIdCategoryDto>(query, parameters);
            return value;
        }
    }
    #endregion

}
