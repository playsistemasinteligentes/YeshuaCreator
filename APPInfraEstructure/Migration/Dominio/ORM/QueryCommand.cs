using Dapper;

namespace MyApp.QueryBuilder
{
    public sealed class QueryCommand
    {
        public string Sql { get; }
        public DynamicParameters Parameters { get; }

        public QueryCommand(string sql, DynamicParameters parameters)
        {
            Sql = sql;
            Parameters = parameters;
        }

        public override string ToString() => Sql;
    }
}
