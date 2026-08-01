using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using Dapper;
using Dominio.Migration;

namespace MyApp.QueryBuilder
{
    internal class SqlResult
    {
        public string Sql { get; set; } = string.Empty;
        public string Alias { get; set; } = string.Empty;
    }


    internal sealed class SqlVisitor
    {
        private readonly QueryBase _query;
        private readonly Type _rootType;
        private readonly Dictionary<string, string> _aliasByPath = new(StringComparer.OrdinalIgnoreCase);
        private readonly List<string> _joins = new();
        private readonly List<string> _selects = new();
        private readonly List<string> _wheres = new();
        private readonly DynamicParameters _parameters = new();
        private readonly List<QueryField> _selectFields = new();
        private string _lastAlias = RootAlias;

        private int _paramIndex = 0;
        private const string RootAlias = "t0";

        public SqlVisitor(QueryBase query, Type rootType)
        {
            _query = query ?? throw new ArgumentNullException(nameof(query));
            _rootType = rootType ?? throw new ArgumentNullException(nameof(rootType));
            _aliasByPath[string.Empty] = RootAlias;
        }

        public QueryCommand BuildCommand()
        {
            // Lista temporária para armazenar condições
            var conditions = new List<QueryCondition>();

            // SELECT
            if (_query.SelectBody == null)
            {
                _selects.Add($"{RootAlias}.*");
            }
            else
            {
                AddSelect(_query.SelectBody, RootAlias);
            }

            // WHERE
            foreach (var where in _query.Wheres)
            {
                var cond = VisitPredicate(where, conditions);
                if (!string.IsNullOrWhiteSpace(cond))
                    _wheres.Add(cond);
            }

            var sql = ComposeSql();
            return new QueryCommand(sql, _parameters, conditions, _selectFields);

        }

        private string ComposeSql()
        {
            var sb = new StringBuilder();
            sb.Append("SELECT ").Append(string.Join(", ", _selects)).Append(' ');
            sb.Append("FROM ").Append(_rootType.Name).Append(' ').Append(RootAlias).Append(' ');
            if (_joins.Count > 0)
                sb.Append(string.Join(" ", _joins)).Append(' ');
            if (_wheres.Count > 0)
                sb.Append("WHERE ").Append(string.Join(" AND ", _wheres));
            return sb.ToString().Trim();
        }

        #region SELECT
        private void AddSelect(Expression body, string currentAlias)
        {
            if (body is NewExpression newExpr)
            {
                foreach (var arg in newExpr.Arguments)
                {
                    var sel = VisitValueExpression(arg, currentAlias, forSelect: true);
                    _selects.Add(sel);

                    var member = GetMemberExpression(arg);
                    if (member != null)
                    {
                        var declaringType = (member.Expression as ParameterExpression)?.Type
                                    ?? member.Member.DeclaringType;

                        _selectFields.Add(new QueryField
                        {
                            Prefix = sel.Split(".")[0],
                            Field = member.Member.Name,
                            Expression = sel,
                            FieldType = ((PropertyInfo)member.Member).PropertyType,
                            EntityName = declaringType.Name
                        });
                    }
                }
                return;
            }

            var single = VisitValueExpression(body, currentAlias, forSelect: true);
            _selects.Add(single);

            var singleMember = GetMemberExpression(body);
            if (singleMember != null)
            {
                var declaringType = (singleMember.Expression as ParameterExpression)?.Type ?? singleMember.Member.DeclaringType;

                _selectFields.Add(new QueryField
                {
                    Prefix = single.Split(".")[0],
                    Field = singleMember.Member.Name,
                    EntityName = declaringType.Name,
                    Expression = single,
                    FieldType = ((PropertyInfo)singleMember.Member).PropertyType
                });
            }
        }
        #endregion

        #region WHERE
        private string VisitPredicate(LambdaExpression lambda, List<QueryCondition> conditions)
        {
            return VisitBoolean(lambda.Body, RootAlias, conditions);
        }

        private static MemberExpression? GetMemberExpression(Expression expr)
        {
            return expr switch
            {
                MemberExpression me => me,
                UnaryExpression ue when ue.Operand is MemberExpression inner => inner,
                _ => null
            };
        }

        private string VisitBoolean(Expression expr, string currentAlias, List<QueryCondition> conditions)
        {
            switch (expr)
            {
                case BinaryExpression be:
                    if (be.NodeType == ExpressionType.AndAlso || be.NodeType == ExpressionType.And)
                        return $"({VisitBoolean(be.Left, currentAlias, conditions)} AND {VisitBoolean(be.Right, currentAlias, conditions)})";
                    if (be.NodeType == ExpressionType.OrElse || be.NodeType == ExpressionType.Or)
                        return $"({VisitBoolean(be.Left, currentAlias, conditions)} OR {VisitBoolean(be.Right, currentAlias, conditions)})";

                    // comparação
                    var leftMember = GetMemberExpression(be.Left);
                    var leftSqlResult = leftMember != null ? ResolveMemberChain(leftMember, false) : null;
                    var leftSql = leftSqlResult?.Sql ?? VisitValueExpression(be.Left, currentAlias, false);

                    string op;
                    string rightExpr;

                    if (IsNullConstant(be.Right))
                    {
                        op = be.NodeType == ExpressionType.Equal ? "IS NULL" : "IS NOT NULL";
                        rightExpr = "NULL";
                    }
                    else
                    {
                        var val = Eval(be.Right);
                        rightExpr = val?.ToString() ?? "NULL";
                        op = OpSql(be.NodeType);
                    }
                    var declaringType = (leftMember.Expression as ParameterExpression)?.Type ?? leftMember.Member.DeclaringType;

                    if (leftMember != null && leftSqlResult != null)
                    {
                        var printer = new ExpressionPrinter();

                        conditions.Add(new QueryCondition
                        {
                            Prefix = leftSqlResult.Alias, // 👈 sempre o alias correto
                            Field = leftMember.Member.Name,
                            Operator = op,
                            RightExpression = printer.Print(be.Right),
                            RightExpressionValue = rightExpr,
                            FieldType = ((PropertyInfo)leftMember.Member).PropertyType,
                            EntityName = declaringType.Name
                        });
                    }

                    return $"{leftSql} {op} {(IsNullConstant(be.Right) ? "" : AddParameter(Eval(be.Right)))}";

                case UnaryExpression ue when ue.NodeType == ExpressionType.Not:
                    return $"(NOT {VisitBoolean(ue.Operand, currentAlias, conditions)})";

                case MethodCallExpression m:
                    return VisitBooleanMethod(m, currentAlias, conditions);

                default:
                    throw new NotSupportedException($"Boolean expression not supported: {expr.NodeType}");
            }
        }

        private string VisitBooleanMethod(MethodCallExpression m, string currentAlias, List<QueryCondition> conditions)
        {
            // string methods
            if (m.Method.DeclaringType == typeof(string))
            {
                var memberSql = VisitValueExpression(m.Object!, currentAlias, forSelect: false);
                var value = (string?)Eval(m.Arguments[0]) ?? string.Empty;
                return m.Method.Name switch
                {
                    nameof(string.Contains) => $"{memberSql} LIKE {AddParameter($"%{value}%")}",
                    nameof(string.StartsWith) => $"{memberSql} LIKE {AddParameter($"{value}%")}",
                    nameof(string.EndsWith) => $"{memberSql} LIKE {AddParameter($"%{value}")}",
                    _ => throw new NotSupportedException($"String method not supported: {m.Method.Name}")
                };
            }

            // Enumerable.Contains(collection, item)
            if (m.Method.Name == nameof(Enumerable.Contains))
            {
                IEnumerable<object>? values = null;
                Expression? itemExpr = null;

                if (m.Arguments.Count == 2)
                {
                    values = Eval(m.Arguments[0]) as IEnumerable<object>;
                    itemExpr = m.Arguments[1];
                }
                else if (m.Object != null && m.Arguments.Count == 1)
                {
                    values = Eval(m.Object) as IEnumerable<object>;
                    itemExpr = m.Arguments[0];
                }

                if (values == null || itemExpr == null)
                    throw new NotSupportedException("Enumerable.Contains usage not supported in this form.");

                var memberSql = VisitValueExpression(itemExpr, currentAlias, forSelect: false);
                var paramNames = new List<string>();
                foreach (var v in values)
                    paramNames.Add(AddParameter(v));
                return $"{memberSql} IN ({string.Join(", ", paramNames)})";
            }

            throw new NotSupportedException($"Method in boolean expression not supported: {m.Method.Name}");
        }
        #endregion

        #region VALUE
        private string VisitValueExpression(Expression expr, string currentAlias, bool forSelect)
        {
            switch (expr)
            {
                case MemberExpression me:
                    return ResolveMemberChain(me, forSelect).Sql;

                case UnaryExpression ue when ue.NodeType == ExpressionType.Convert:
                    return VisitValueExpression(ue.Operand, currentAlias, forSelect);

                case ConstantExpression c:
                    return AddParameter(c.Value);

                case MethodCallExpression m when m.Method.DeclaringType == typeof(string):
                    var val = (string?)Eval(m) ?? string.Empty;
                    return AddParameter(val);

                default:
                    var ev = Eval(expr);
                    return AddParameter(ev);
            }
        }

        private SqlResult ResolveMemberChain(MemberExpression me, bool forSelect)
        {
            var chain = GetChain(me);
            string currentPath = string.Empty;
            string parentAlias = RootAlias;

            for (int i = 0; i < chain.Length; i++)
            {
                var prop = chain[i];
                var propType = prop.PropertyType;
                bool isNavigation = IsNavigation(propType);
                bool isLast = (i == chain.Length - 1);

                if (isNavigation && !isLast)
                {
                    currentPath = AppendPath(currentPath, prop.Name);
                    parentAlias = EnsureJoin(parentAlias, currentPath, prop);
                    continue;
                }

                if (isNavigation && isLast)
                {
                    currentPath = AppendPath(currentPath, prop.Name);
                    var alias = EnsureJoin(parentAlias, currentPath, prop);
                    return new SqlResult { Sql = $"{alias}.Id", Alias = alias };
                }

                return new SqlResult { Sql = $"{parentAlias}.{prop.Name}", Alias = parentAlias };
            }

            throw new NotSupportedException("Cannot resolve member chain for SQL.");
        }
        #endregion

        #region JOINS
        private string EnsureJoin(string parentAlias, string path, PropertyInfo navProp)
        {
            if (_aliasByPath.TryGetValue(path, out var existing)) return existing;

            var alias = NextAlias();
            _aliasByPath[path] = alias;

            var navType = navProp.PropertyType;
            var fkName = navProp.Name + "Id"; // convenção
            var joinType = _query.LeftJoinPaths.Contains(path) ? "LEFT JOIN" : "INNER JOIN";
            var sql = $"{joinType} {navType.Name} {alias} ON {alias}.Id = {parentAlias}.{fkName}";
            _joins.Add(sql);
            return alias;
        }
        #endregion

        #region HELPERS
        private static bool IsNullConstant(Expression e) =>
            e is ConstantExpression c && c.Value is null;

        private static string OpSql(ExpressionType t) => t switch
        {
            ExpressionType.Equal => "=",
            ExpressionType.NotEqual => "<>",
            ExpressionType.GreaterThan => ">",
            ExpressionType.GreaterThanOrEqual => ">=",
            ExpressionType.LessThan => "<",
            ExpressionType.LessThanOrEqual => "<=",
            _ => throw new NotSupportedException($"Operator not supported: {t}")
        };

        private string AddParameter(object? value)
        {
            var name = $"@p{_paramIndex++}";
            _parameters.Add(name, value);
            return name;
        }

        private static bool IsNavigation(Type t) => !(t.IsValueType || t == typeof(string));

        private static PropertyInfo[] GetChain(MemberExpression me)
        {
            var stack = new Stack<PropertyInfo>();
            Expression? cur = me;
            while (cur is MemberExpression m)
            {
                if (m.Member is PropertyInfo pi)
                    stack.Push(pi);
                else
                    throw new NotSupportedException("Only property members are supported.");
                cur = m.Expression;
            }
            return stack.ToArray();
        }

        internal static string GetMemberPath(Expression expr)
        {
            var list = new List<string>();
            Expression? cur = expr;
            while (cur is MemberExpression m)
            {
                list.Insert(0, m.Member.Name);
                cur = m.Expression;
            }
            if (list.Count > 0) list.RemoveAt(0);
            return string.Join('.', list);
        }

        private object? Eval(Expression expr)
        {
            if (expr is ConstantExpression c) return c.Value;
            try
            {
                var lambda = Expression.Lambda(expr);
                var compiled = lambda.Compile();
                return compiled.DynamicInvoke();
            }
            catch
            {
                throw new InvalidOperationException($"Cannot evaluate expression: {expr}");
            }
        }

        private string NextAlias()
        {
            _query.AliasSeed += 1;
            return $"t{_query.AliasSeed}";
        }

        private static string AppendPath(string basePath, string seg) =>
            string.IsNullOrEmpty(basePath) ? seg : $"{basePath}.{seg}";
        #endregion
    }
}
