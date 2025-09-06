using Dapper;
using Dominio.Migration;

public sealed class QueryCommand
{
    public string Sql { get; }
    public DynamicParameters Parameters { get; }
    private readonly List<QueryCondition> _conditions = new();
    public IReadOnlyList<QueryCondition> Conditions => _conditions;

    public QueryCommand(string sql, DynamicParameters parameters, IEnumerable<QueryCondition>? conditions = null)
    {
        Sql = sql;
        Parameters = parameters;
        if (conditions != null)
            _conditions.AddRange(conditions);
    }

    public override string ToString() => Sql;
}
