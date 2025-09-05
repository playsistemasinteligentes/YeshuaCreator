using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using Dapper;

namespace MyApp.QueryBuilder
{
    public static class DbExtensions
    {
        public static async Task<IEnumerable<dynamic>> QueryAsync(this IDbConnection cnn, QueryCommand cmd, IDbTransaction? tx = null, int? commandTimeout = null)
        {
            return await cnn.QueryAsync(cmd.Sql, cmd.Parameters, tx, commandTimeout);
        }

        public static async Task<int> ExecuteAsync(this IDbConnection cnn, QueryCommand cmd, IDbTransaction? tx = null, int? commandTimeout = null)
        {
            return await cnn.ExecuteAsync(cmd.Sql, cmd.Parameters, tx, commandTimeout);
        }
    }
}
