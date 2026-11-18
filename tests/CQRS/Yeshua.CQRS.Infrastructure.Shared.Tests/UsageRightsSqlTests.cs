using System.Security.Claims;
using Aplication.Interfaces.Services;
using Dominio.Commercial;
using Microsoft.Data.SqlClient;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shared.Repository.Commercial;
using Shered.DB.Connection;

namespace Shared.Tests;

[TestClass]
public sealed class UsageRightsSqlTests
{
    [TestMethod]
    public async Task Sql_reservations_are_concurrent_idempotent_persistent_and_tenant_scoped()
    {
        var supplied = Environment.GetEnvironmentVariable("YESHUA_TEST_SQL");
        if (string.IsNullOrWhiteSpace(supplied)) { Assert.Inconclusive("Defina YESHUA_TEST_SQL para o ensaio SQL isolado."); return; }
        var database = "YESHUA_BILLING_PROBE_" + Guid.NewGuid().ToString("N");
        var master = new SqlConnectionStringBuilder(supplied) { InitialCatalog = "master" };
        var password = Environment.GetEnvironmentVariable("YESHUA_TEST_SQL_PASSWORD");
        if (!string.IsNullOrEmpty(password)) master.Password = password;
        await using var admin = new SqlConnection(master.ConnectionString); await admin.OpenAsync();
        await new SqlCommand($"CREATE DATABASE [{database}];", admin).ExecuteNonQueryAsync();
        var connection = new SqlConnectionStringBuilder(master.ConnectionString) { InitialCatalog = database }.ConnectionString;
        UnitOfWork Work() => new(new SqlFactory(EnumSqlConections.SqlServer, connection));
        UsageRightsRepository Repository(UnitOfWork work, int tenant = 7) => new(work, new Context(tenant));
        try
        {
            using (var work = Work())
            {
                work.Execute(@"CREATE TABLE yUsageRight(Id varchar(64) PRIMARY KEY,ResourceKey varchar(100) NOT NULL,
                    PeriodUntilUtc datetime NULL,GrantedUnits decimal(18,4) NOT NULL,ReservedUnits decimal(18,4) NOT NULL,
                    ConsumedUnits decimal(18,4) NOT NULL,TenantID int NOT NULL,UserId int NOT NULL,
                    Deleted bit NOT NULL,Changed datetime NOT NULL,OperationalEntityId varchar(32) NOT NULL);
                    CREATE TABLE yUsageConsumption(Id varchar(64) PRIMARY KEY,ResourceKey varchar(100) NOT NULL,
                    OperationId varchar(100) NOT NULL,Units decimal(18,4) NOT NULL,UsesPeriod bit NOT NULL,Status int NOT NULL,
                    TenantID int NOT NULL,UserId int NOT NULL,Deleted bit NOT NULL,Changed datetime NOT NULL,OperationalEntityId varchar(32) NOT NULL);");
                Repository(work).Synchronize([new UsageRight("test.units", 0, 10)]);
            }
            var results = await Task.WhenAll(Enumerable.Range(0, 30).Select(index => Task.Run(() =>
            {
                using var work = Work();
                return (Operation: index.ToString(), Allowed: Repository(work).Reserve("test.units", index.ToString(), 1));
            })));
            Assert.AreEqual(10, results.Count(result => result.Allowed));
            using (var work = Work())
            {
                var repository = Repository(work);
                Assert.AreEqual(10m, work.ExecuteScalar<decimal>("SELECT ReservedUnits FROM yUsageRight WHERE TenantID=7 AND ResourceKey='test.units';"));
                foreach (var result in results.Where(result => result.Allowed))
                {
                    Assert.IsTrue(repository.Reserve("test.units", result.Operation, 1));
                    repository.Confirm("test.units", result.Operation); repository.Confirm("test.units", result.Operation);
                }
                repository.Synchronize([new UsageRight("test.units", 0, 5)]);
                Assert.AreEqual(10m, work.ExecuteScalar<decimal>("SELECT ConsumedUnits FROM yUsageRight WHERE TenantID=7 AND ResourceKey='test.units';"));
                Assert.AreEqual(0m, work.ExecuteScalar<decimal>("SELECT ReservedUnits FROM yUsageRight WHERE TenantID=7 AND ResourceKey='test.units';"));
                Assert.IsFalse(repository.Reserve("test.units", "exhausted", 1));
                Assert.IsFalse(Repository(work, 8).Reserve("test.units", "other-tenant", 1));
                repository.Synchronize([new UsageRight("test.release", 0, 1)]);
                Assert.IsTrue(repository.Reserve("test.release", "release", 1));
                repository.Release("test.release", "release"); repository.Release("test.release", "release");
                Assert.IsTrue(repository.Reserve("test.release", "release", 1));
                repository.Confirm("test.release", "release");
                Assert.AreEqual(1m, work.ExecuteScalar<decimal>("SELECT ConsumedUnits FROM yUsageRight WHERE TenantID=7 AND ResourceKey='test.release';"));
                repository.Synchronize([new UsageRight("test.period", DateTimeOffset.UtcNow.AddDays(1).ToUnixTimeSeconds(), 0)]);
                Assert.IsTrue(repository.Reserve("test.period", "period", 1)); repository.Confirm("test.period", "period");
                Assert.AreEqual(0m, work.ExecuteScalar<decimal>("SELECT ConsumedUnits FROM yUsageRight WHERE TenantID=7 AND ResourceKey='test.period';"));
                repository.Synchronize([new UsageRight("test.rollback", 0, 1)]);
                work.BeginTran(); Assert.IsTrue(repository.Reserve("test.rollback", "rollback", 1)); work.Rollback();
                Assert.AreEqual(0, work.ExecuteScalar<int>("SELECT COUNT(*) FROM yUsageConsumption WHERE TenantID=7 AND ResourceKey='test.rollback';"));
                Assert.IsTrue(repository.Reserve("test.rollback", "rollback", 1));
            }
            using (var reconnected = Work())
                Assert.IsFalse(Repository(reconnected).Reserve("test.units", "after-reconnect", 1));
        }
        finally
        {
            SqlConnection.ClearAllPools();
            if (!database.StartsWith("YESHUA_BILLING_PROBE_", StringComparison.Ordinal) || database.Length != 53)
                throw new InvalidOperationException("Nome de banco de ensaio invalido.");
            await new SqlCommand($"ALTER DATABASE [{database}] SET SINGLE_USER WITH ROLLBACK IMMEDIATE; DROP DATABASE [{database}];", admin).ExecuteNonQueryAsync();
        }
    }

    private sealed class Context(int tenant) : IExecutionContext
    {
        public int TenantID { get; private set; } = tenant;
        public int UserId { get; private set; } = 12;
        public IEnumerable<Claim> Claims => [];
        public string TraceId { get; private set; } = "billing-test";
        public ExecutionOrigin Origem { get; private set; } = ExecutionOrigin.Worker;
        public string ProcessingScope => "billing-test";
        public void SetTenantId(int id) => TenantID = id;
        public void SetUserId(int id) => UserId = id;
        public void SetTraceId(string value) => TraceId = value;
        public void SetOrigem(ExecutionOrigin value) => Origem = value;
    }
}
