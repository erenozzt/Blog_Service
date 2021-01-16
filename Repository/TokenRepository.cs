using Dapper;
using BlogService.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace BlogService.Repository
{
    public class TokenRepository : ITokenRepository
    {
        IDbConnection connection = new SqlConnection("Server=erenozzt\\SQLEXPRESS;Database=BlogDb;Integrated Security=True");
 
        public async Task<UserInfo> GetUser(string email, string password)
        {
            DynamicParameters paramsValue = new DynamicParameters();

            paramsValue.Add("@email", email);
            paramsValue.Add("@password", password);
            return (UserInfo)await connection.QueryAsync<UserInfo>("sp_getUser", new { paramsValue }, commandType: CommandType.StoredProcedure);
        }
    }
}
