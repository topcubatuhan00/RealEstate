using Dapper;
using RealEstateApi.Dtos.ProductDtos;
using RealEstateApi.Models.DapperContext;

namespace RealEstateApi.Models.Repositories.ProductRepository;

public class ProductRepository : IProductRepository
{
    #region Fields
    private readonly Context _context;
    #endregion

    #region Ctor
    public ProductRepository
    (
        Context context
    )
    {
        _context = context;
    }
    #endregion

    #region Methods
    public async Task<List<ResultProductDto>> GetAllProductAsync()
    {
        string query = "select * from product";
        using (var connection = _context.CreateConnection())
        {
            var values = await connection.QueryAsync<ResultProductDto>(query);
            return values.ToList();
        }
    }

    public async Task<List<ResultProductWithCategoryDto>> GetAllProductWithCategoryAsync()
    {
        string query = "select ProductId, Title, Price, City, District,ProductCategory, CategoryName  from product inner join Category on Product.ProductCategory = Category.CategoryId";
        using (var connection = _context.CreateConnection())
        {
            var values = await connection.QueryAsync<ResultProductWithCategoryDto>(query);
            return values.ToList();
        }
    }
    #endregion
}
