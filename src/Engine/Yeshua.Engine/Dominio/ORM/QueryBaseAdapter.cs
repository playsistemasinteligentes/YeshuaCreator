using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace MyApp.QueryBuilder
{
    internal abstract class QueryBase
    {
        public abstract IEnumerable<LambdaExpression> Wheres { get; }
        public abstract Expression? SelectBody { get; }
        public abstract ISet<string> LeftJoinPaths { get; }
        public abstract int AliasSeed { get; set; }
    }

    internal static class QueryBaseAdapter
    {
        public static QueryBase Wrap<T>(this Query<T> q) => new Wrapped<T>(q);

        private sealed class Wrapped<T> : QueryBase
        {
            private readonly Query<T> _q;
            public Wrapped(Query<T> q) { _q = q; }
            public override IEnumerable<LambdaExpression> Wheres => _q.WhereExpressions;
            public override Expression? SelectBody => _q.SelectExpression;
            public override ISet<string> LeftJoinPaths => _q.LeftJoinPaths;
            public override int AliasSeed { get => _q.AliasSeed; set => _q.AliasSeed = value; }
        }
    }
}
