using System.Text.Json;
using Dominio.Migration;
using Dominio.Schemas;
using Moq;
using Yeshua.Studio.Presenca;
using EngineUnitOfWork = Migration.Interfaces.IUnitOfWork;

namespace Presenca.Tests;

public sealed class CentralAuthorizationTests
{
    [Fact]
    public void Studio_definitions_are_projected_for_presenca_without_granting_access()
    {
        var central = new CentralFixture();
        new CentralAuthorizationSchema("Presenca", central.Work.Object).ApplyMigrations(Migrations());

        Assert.Contains(central.Definitions, d =>
            d.GetProperty("DefinitionType").GetString() == "Module" &&
            d.GetProperty("DefinitionKey").GetString() == "PRESENCA");
        Assert.Contains(central.Definitions, d =>
            d.GetProperty("DefinitionType").GetString() == "Grant" &&
            d.GetProperty("DefinitionKey").GetString() == "presenca.editorial");
        Assert.All(central.Definitions, d => Assert.Equal("Presenca", d.GetProperty("ApplicationKey").GetString()));
        Assert.Equal(new[] { 1, 2, 3 }, central.History.Keys.Order().ToArray());
        foreach (var table in new[] { "yTenantApplication", "yTenantModule", "yUserModule", "yUserGrant", "yPerfilGrant" })
            Assert.DoesNotContain(central.Writes, sql => sql.Contains(table, StringComparison.OrdinalIgnoreCase));
    }

    [Fact]
    public void Reapplying_studio_migrations_preserves_the_authorization_history()
    {
        var central = new CentralFixture();
        var schema = new CentralAuthorizationSchema("Presenca", central.Work.Object);
        schema.ApplyMigrations(Migrations());
        var count = central.Definitions.Count;
        var history = central.History.ToArray();

        schema.ApplyMigrations(Migrations());

        Assert.Equal(count, central.Definitions.Count);
        Assert.Equal(history, central.History.ToArray());
        central.Work.Verify(w => w.BeginTran(), Times.Exactly(3));
    }

    [Fact]
    public void Changing_an_applied_studio_definition_requires_a_new_migration()
    {
        var central = new CentralFixture();
        var schema = new CentralAuthorizationSchema("Presenca", central.Work.Object);
        schema.ApplyMigrations(Migrations());
        var count = central.Definitions.Count;
        var changed = Migrations();
        changed[0].AddModule("CHANGED", "Changed definition");

        Assert.Throws<InvalidOperationException>(() => schema.ApplyMigrations(changed));

        Assert.Equal(count, central.Definitions.Count);
        central.Work.Verify(w => w.BeginTran(), Times.Exactly(3));
    }

    private static MigrationBase[] Migrations()
    {
        MigrationBase[] migrations = [new M000001(), new M000002(), new M000003()];
        foreach (var migration in migrations)
        {
            migration.SetID(migration.GetType().Name);
            migration.Up();
        }
        return migrations;
    }

    // In-memory SQL boundary: exercises the real projection and real Studio DSL.
    private sealed class CentralFixture
    {
        public Mock<EngineUnitOfWork> Work { get; } = new(MockBehavior.Strict);
        public Dictionary<int, string> History { get; } = new();
        public List<JsonElement> Definitions { get; } = new();
        public List<string> Writes { get; } = new();

        public CentralFixture()
        {
            Work.Setup(w => w.BeginTran());
            Work.Setup(w => w.Commit());
            Work.Setup(w => w.Rollback());
            Work.Setup(w => w.QuerySingle<int>(It.IsAny<string>(), It.IsAny<object>()))
                .Returns((string _, object parameters) =>
                    History.ContainsKey(JsonSerializer.SerializeToElement(parameters).GetProperty("MigrationId").GetInt32()) ? 1 : 0);
            Work.Setup(w => w.QuerySingle<string>(It.IsAny<string>(), It.IsAny<object>()))
                .Returns((string _, object parameters) =>
                    History[JsonSerializer.SerializeToElement(parameters).GetProperty("MigrationId").GetInt32()]);
            Work.Setup(w => w.ExecuteCommand(It.IsAny<string>(), It.IsAny<object>()))
                .Callback((string sql, object? parameters) =>
                {
                    Writes.Add(sql);
                    if (sql.Contains("MERGE dbo.yAuthorizationDefinition", StringComparison.Ordinal))
                        Definitions.Add(JsonSerializer.SerializeToElement(parameters));
                    if (sql.Contains("INSERT INTO dbo.yAuthorizationMigrationVersion", StringComparison.Ordinal))
                    {
                        var row = JsonSerializer.SerializeToElement(parameters);
                        History.Add(row.GetProperty("MigrationId").GetInt32(), row.GetProperty("ContentHash").GetString()!);
                    }
                });
        }
    }
}
