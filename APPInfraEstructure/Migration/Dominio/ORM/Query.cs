using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace MyApp.QueryBuilder
{
    public class Query<T>
    {
        internal List<Expression<Func<T, bool>>> WhereExpressions { get; } = new();
        internal Expression SelectExpression { get; private set; } = null!;
        internal ISet<string> LeftJoinPaths { get; } = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
        internal int AliasSeed { get; set; } = 0;

        public Query<T> Where(Expression<Func<T, bool>> predicate)
        {
            if (predicate is null) throw new ArgumentNullException(nameof(predicate));
            WhereExpressions.Add(predicate);
            return this;
        }

        /// <summary>Selecione múltiplas colunas via expressão anônima: s => new { s.Id, s.Paciente.Nome }.</summary>
        public Query<T> Select<TResult>(Expression<Func<T, TResult>> selector)
        {
            if (selector is null) throw new ArgumentNullException(nameof(selector));
            SelectExpression = selector.Body;
            return this;
        }

        /// <summary>Força LEFT JOIN no caminho informado, ex.: .LeftJoin(s => s.Paciente)</summary>
        public Query<T> LeftJoin<TNav>(Expression<Func<T, TNav>> navigation)
        {
            if (navigation is null) throw new ArgumentNullException(nameof(navigation));
            var path = SqlVisitor.GetMemberPath(navigation.Body);
            if (!string.IsNullOrEmpty(path))
                LeftJoinPaths.Add(path);
            return this;
        }

        public QueryCommand ToCommand()
        {
            var wrapper = QueryBaseAdapter.Wrap(this);
            var visitor = new SqlVisitor(wrapper, typeof(T));
            return visitor.BuildCommand();
        }
    }

    /// <summary>Helper para facilitar uso estático</summary>
    public static class Query
    {
        public static MyApp.QueryBuilder.Query<T> For<T>() => new MyApp.QueryBuilder.Query<T>();
    }
}
