using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text.RegularExpressions;
using MyApp.QueryBuilder;

namespace Dominio.Migration
{
    public abstract partial class MigrationBase
    {
        private List<object> _queries = new();

        public MigrationQueryDefinition<T> AddQuery<T>(string queryName,
            Func<MigrationQueryDefinition<T>, MigrationQueryDefinition<T>> builder,
            bool forFront = false)
        {
            var queryDef = new MigrationQueryDefinition<T>(queryName) { IsForFront = forFront };
            queryDef = builder(queryDef);

            // Gera SQL base sem Where na hora do AddQuery
            queryDef.BuildSqlBase();

            _queries.Add(queryDef);
            _entity.Queries.Add(queryDef); // supondo que _entity tenha a lista Queries
            return queryDef;
        }

        public IEnumerable<MigrationQueryDefinition<T>> GetQueries<T>()
        {
            return _queries.OfType<MigrationQueryDefinition<T>>();
        }

    }

    public enum QueryType
    {
        Searchable, // para buscas
        ForReport,  // para relatórios
        ForBusiness // para lookup / regras de negócio
    }
    public class QueryCondition
    {
        public string Prefix { get; set; } = string.Empty;   // s, p, etc.
        public string Field { get; set; } = string.Empty;    // DataInicio
        public string Operator { get; set; } = string.Empty; // >=, =, !=
        public string RightExpression { get; set; } = string.Empty; // DateTime.Today, "Ativo"
        public object? RightExpressionValue { get; set; }  // Ex: DateTime.Today, "Ativo"
        public Type FieldType { get; set; } = typeof(object);
        public Column Column { get; set; }
        public string EntityName { get; internal set; }
    }
    public class MigrationQueryMeta
    {
        public string QueryName { get; set; } = string.Empty;
        public string SqlBase { get; set; } = string.Empty;
        //public List<QuerySelectField> SelectFields { get; set; } = new();
        public List<QueryField> SelectFields { get; set; } = new();
        // pendencia: este metadado de DSL ainda fica guardado no motor; a persistencia oficial precisa morar no Studio para cada aplicativo, e o motor deve reter apenas o necessario para suas migrations internas.
        public Dictionary<string, List<QueryCondition>> WhereContextParameters { get; set; } = new();
        public Dictionary<string, List<QueryCondition>> WhereParameters { get; set; } = new();

    }


    public class MigrationQueryDefinition<T> : IMigrationQueryDefinition, IQueryWithMeta
    {
        public MigrationQueryMeta Meta { get; private set; } = new();
        public string Name { get; private set; }
        public bool IsForFront { get; set; } = false;

        public List<(string ContextName, Expression<Func<T, bool>> Filter)> WhereContexts { get; } = new();
        public List<(string WhereName, Expression<Func<T, bool>> Filter)> Wheres { get; } = new();
        public List<LambdaExpression> Selects { get; } = new();

        private readonly Query<T> _queryBuilder;

        public MigrationQueryDefinition(string name)
        {
            Name = name;
            _queryBuilder = new Query<T>();
        }

        public MigrationQueryDefinition() => _queryBuilder = new Query<T>();

        public MigrationQueryDefinition<T> Where(string paramName, Expression<Func<T, bool>> filter)
        {
            Wheres.Add((paramName, filter));
            return this;
        }
        public MigrationQueryDefinition<T> WhereContext(string contextName, Expression<Func<T, bool>> filter)
        {
            WhereContexts.Add((contextName, filter));
            return this;
        }
        private string ExpressionToString(Expression expr)
        {
            switch (expr)
            {
                case ConstantExpression c:
                    // Literais
                    if (c.Value == null) return "null";
                    if (c.Type == typeof(string)) return $"\"{c.Value}\"";
                    if (c.Type == typeof(bool)) return (bool)c.Value ? "true" : "false";
                    return c.Value.ToString()!;

                case MemberExpression m:
                    // Se for uma variável de parâmetro (s.DataInicio), pega só o nome do membro
                    if (m.Expression is ParameterExpression)
                        return m.Member.Name;

                    // Se for membro de algo estático ou outro objeto
                    return m.ToString(); // ex: DateTime.Today

                case MethodCallExpression call:
                    return call.ToString(); // ex: SomeMethod(x)

                case UnaryExpression u:
                    return ExpressionToString(u.Operand); // ex: (object)x

                case BinaryExpression b:
                    // Exibe binário inteiro como string (fallback)
                    return $"{ExpressionToString(b.Left)} {GetSqlOperator(b.NodeType)} {ExpressionToString(b.Right)}";

                default:
                    return expr.ToString() ?? string.Empty;
            }
        }


        private string GetSqlOperator(ExpressionType nodeType) => nodeType switch
        {
            ExpressionType.Equal => "=",
            ExpressionType.NotEqual => "!=",
            ExpressionType.GreaterThan => ">",
            ExpressionType.GreaterThanOrEqual => ">=",
            ExpressionType.LessThan => "<",
            ExpressionType.LessThanOrEqual => "<=",
            _ => nodeType.ToString()
        };

        // --- Select ---
        public MigrationQueryDefinition<T> Select<TProp>(Expression<Func<T, TProp>> selector)
        {
            Selects.Add(selector);

            if (selector.Body is MemberExpression m)
            {
                AddSelectField(m);
            }
            else if (selector.Body is UnaryExpression u && u.Operand is MemberExpression um)
            {
                AddSelectField(um);
            }
            else if (selector.Body is NewExpression n)
            {
                for (int i = 0; i < n.Arguments.Count; i++)
                {
                    if (n.Arguments[i] is MemberExpression me)
                    {
                        AddSelectField(me);
                    }
                }
            }

            return this;
        }

        private void AddSelectField(MemberExpression member)
        {
            string path = GetFullPath(member);              // Paciente.Nome
            string name = member.Member.Name;               // Nome
            string entity = member.Member.DeclaringType?.Name ?? typeof(T).Name;
            Type type = member.Type;
        }

        private string GetFullPath(MemberExpression expr)
        {
            var stack = new Stack<string>();
            Expression? current = expr;

            while (current is MemberExpression me)
            {
                stack.Push(me.Member.Name);
                current = me.Expression;
            }

            return string.Join(".", stack);
        }

        // --- SQL Base ---
        public void BuildSqlBase()
        {
            Meta.QueryName = Name;
            Query<T> query;
            QueryCommand queryCommand;
            Meta.SqlBase = string.Empty;
            Meta.SelectFields.Clear();


            foreach (var ctx in Wheres)
            {
                query = new Query<T>();

                var tSelect = Selects.Last().ReturnType;
                var selectMethod = typeof(Query<T>)
                    .GetMethods()
                    .First(m => m.Name == "Select" && m.IsGenericMethodDefinition)
                    .MakeGenericMethod(tSelect);

                selectMethod.Invoke(query, new object[] { Selects.Last() });

                if (string.IsNullOrEmpty(Meta.SqlBase))
                {
                    queryCommand = query.ToCommand();
                    Meta.SqlBase = queryCommand.Sql;
                    if (Meta.SelectFields.Count == 0 && queryCommand.SelectFields.Any())
                        Meta.SelectFields.AddRange(queryCommand.SelectFields);
                }
                query.Where(ctx.Filter);
                queryCommand = query.ToCommand();

                if (!this.Meta.WhereParameters.ContainsKey(ctx.WhereName))
                    Meta.WhereParameters[ctx.WhereName] = new List<QueryCondition>();
                Meta.WhereParameters[ctx.WhereName].AddRange(queryCommand.Conditions);
            }
            foreach (var ctx in WhereContexts)
            {
                query = new Query<T>();
                var tSelect = Selects.Last().ReturnType;
                var selectMethod = typeof(Query<T>)
                    .GetMethods()
                    .First(m => m.Name == "Select" && m.IsGenericMethodDefinition)
                    .MakeGenericMethod(tSelect);

                selectMethod.Invoke(query, new object[] { Selects.Last() });
                if (string.IsNullOrEmpty(Meta.SqlBase))
                {
                    queryCommand = query.ToCommand();
                    Meta.SqlBase = queryCommand.Sql;
                    if (Meta.SelectFields.Count == 0 && queryCommand.SelectFields.Any())
                        Meta.SelectFields.AddRange(queryCommand.SelectFields);
                }
                query.Where(ctx.Filter);
                queryCommand = query.ToCommand();


                if (!this.Meta.WhereContextParameters.ContainsKey(ctx.ContextName))
                    Meta.WhereContextParameters[ctx.ContextName] = new List<QueryCondition>();
                Meta.WhereContextParameters[ctx.ContextName].AddRange(queryCommand.Conditions);

            }
        }

        // --- Interface ---
        IEnumerable<(string ContextName, LambdaExpression Filter)> IMigrationQueryDefinition.GetWhereContexts()
            => WhereContexts.Select(c => (c.ContextName, (LambdaExpression)c.Filter));

        IEnumerable<(string WhereName, LambdaExpression Filter)> IMigrationQueryDefinition.GetWheres()
            => Wheres.Select(c => (c.WhereName, (LambdaExpression)c.Filter));

        IEnumerable<LambdaExpression> IMigrationQueryDefinition.GetSelects()
            => Selects;
    }


    // marcador pra o motor pegar o Meta sem reflection/dynamic
    public interface IQueryWithMeta
    {
        MigrationQueryMeta Meta { get; }
    }

    public interface IMigrationQueryDefinition
    {
        string Name { get; }
        bool IsForFront { get; }
        IEnumerable<(string ContextName, LambdaExpression Filter)> GetWhereContexts();
        IEnumerable<(string WhereName, LambdaExpression Filter)> GetWheres();
        IEnumerable<LambdaExpression> GetSelects();
    }
    public class QuerySelectField
    {
        public string Entity { get; set; } = string.Empty; // Tipo de origem (ex.: Sessao, Paciente)
        public string Path { get; set; } = string.Empty;   // Caminho completo (ex.: Paciente.Nome)
        public string Name { get; set; } = string.Empty;   // Nome da propriedade final (ex.: Nome)
        public Type FieldType { get; set; } = typeof(object);

        public override string ToString() => $"{Path} ({FieldType.Name})";
    }


}
