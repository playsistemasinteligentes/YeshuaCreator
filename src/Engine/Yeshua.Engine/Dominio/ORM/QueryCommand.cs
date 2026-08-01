using Dapper;
using Dominio.Migration;
using MyApp.QueryBuilder;

public sealed class QueryCommand
{
    public string Sql { get; }
    public DynamicParameters Parameters { get; }
    public IReadOnlyList<QueryCondition> Conditions { get; }
    public IReadOnlyList<QueryField> SelectFields { get; }   // 👈 novo

    public QueryCommand(string sql, DynamicParameters parameters,
                        IReadOnlyList<QueryCondition>? conditions = null,
                        IReadOnlyList<QueryField>? selectFields = null)
    {
        Sql = sql;
        Parameters = parameters;
        Conditions = conditions ?? Array.Empty<QueryCondition>();
        SelectFields = selectFields ?? Array.Empty<QueryField>();
    }

    public override string ToString() => Sql;
}
