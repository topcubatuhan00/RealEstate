using Microsoft.Data.SqlClient;
using System.Data;

namespace RealEstateApi.Models.DapperContext;

public class Context
{
    #region Fields
    private readonly IConfiguration _configuration;
    private readonly string _connectionString;
    #endregion

    #region Ctor
    public Context
    (
        IConfiguration configuration
    )
    {
        _configuration = configuration;
        _connectionString = _configuration.GetConnectionString("connection");
    }
    #endregion

    #region Methods
    public IDbConnection CreateConnection() => new SqlConnection(_connectionString);
    #endregion
}
