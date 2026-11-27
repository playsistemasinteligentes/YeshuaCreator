using System.Data.Common;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace Yeshua.Central.BusinessMcp.Tests;

// Positive control: code exchange/refresh use this actual EF interceptor first.
// Locking the probe then makes ANY database authorization I/O fail the test.
internal sealed class AuthorizationIoProbe
{
    public bool Forbidden;
    public int DatabaseCommands, ConnectionOpens;
    public void Command()
    {
        Interlocked.Increment(ref DatabaseCommands);
        if (Forbidden) throw new InvalidOperationException("Database I/O is forbidden on business requests.");
    }
    public void Connection()
    {
        Interlocked.Increment(ref ConnectionOpens);
        if (Forbidden) throw new InvalidOperationException("Opening an authorization database connection is forbidden.");
    }
}
internal sealed class AuthorizationCommandProbe(AuthorizationIoProbe probe) : DbCommandInterceptor
{
    public override InterceptionResult<DbDataReader> ReaderExecuting(DbCommand c, CommandEventData e, InterceptionResult<DbDataReader> r)
    { probe.Command(); return r; }
    public override ValueTask<InterceptionResult<DbDataReader>> ReaderExecutingAsync(DbCommand c, CommandEventData e, InterceptionResult<DbDataReader> r, CancellationToken ct = default)
    { probe.Command(); return ValueTask.FromResult(r); }
    public override InterceptionResult<int> NonQueryExecuting(DbCommand c, CommandEventData e, InterceptionResult<int> r)
    { probe.Command(); return r; }
    public override ValueTask<InterceptionResult<int>> NonQueryExecutingAsync(DbCommand c, CommandEventData e, InterceptionResult<int> r, CancellationToken ct = default)
    { probe.Command(); return ValueTask.FromResult(r); }
    public override InterceptionResult<object> ScalarExecuting(DbCommand c, CommandEventData e, InterceptionResult<object> r)
    { probe.Command(); return r; }
    public override ValueTask<InterceptionResult<object>> ScalarExecutingAsync(DbCommand c, CommandEventData e, InterceptionResult<object> r, CancellationToken ct = default)
    { probe.Command(); return ValueTask.FromResult(r); }
}
internal sealed class AuthorizationConnectionProbe(AuthorizationIoProbe probe) : DbConnectionInterceptor
{
    public override InterceptionResult ConnectionOpening(DbConnection c, ConnectionEventData e, InterceptionResult r)
    { probe.Connection(); return r; }
    public override ValueTask<InterceptionResult> ConnectionOpeningAsync(DbConnection c, ConnectionEventData e, InterceptionResult r, CancellationToken ct = default)
    { probe.Connection(); return ValueTask.FromResult(r); }
}
