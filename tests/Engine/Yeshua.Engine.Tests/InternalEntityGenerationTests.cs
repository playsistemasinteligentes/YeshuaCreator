using Dominio;
using Dominio.Migration;
using Dominio.Schemas;
using Dominio.Schemas.CQRS;
using Migration.Dominio;

namespace TestMigration;

[TestClass]
public class InternalEntityGenerationTests
{
    [TestMethod]
    public void GlobalEntityOmitsTenantButKeepsOtherStandardFields()
    {
        var fixture = Create();
        var standard = new global::Migration.Dominio.Migration.S000001();
        standard.Up();
        MigrationBuilder.ValidateInternalEntities([fixture]);
        MigrationBuilder.ApplyStandardFields([standard, fixture]);
        var internalEntity = fixture.Entitys.Single(e => e.EntityName == "Channel");
        var normal = fixture.Entitys.Single(e => e.EntityName == "Album");
        Assert.IsFalse(internalEntity.AddColumns.Any(c => c.Name == "TenantID"));
        Assert.IsTrue(internalEntity.AddColumns.Any(c => c.Name == "OperationalEntityId"));
        Assert.IsTrue(normal.AddColumns.Any(c => c.Name == "TenantID" && c.WhereNeedBe));
        var sql = new SqlServerSchema(null!, "Memorias").CreateTable(internalEntity).Query;
        StringAssert.Contains(sql, "CREATE TABLE [Channel]");
        Assert.IsFalse(sql.Contains("TenantID", StringComparison.OrdinalIgnoreCase));
    }

    [TestMethod]
    public void OwnerReceivesEntityDependencyOnceWithoutRepeatingAddEntity()
    {
        var fixture = Create();
        MigrationBuilder.ValidateInternalEntities([fixture]);
        MigrationBuilder.ValidateInternalEntities([fixture]);
        Assert.AreSame(fixture.Entitys.Single(e => e.IsInternal), Owner(fixture).Entitys.Single());
        Assert.IsTrue(Owner(fixture).IsInternal);
        Assert.AreEqual(Migration.Dominio.Schemas.CQRS.Authorization.User, Owner(fixture).Authorization);
    }

    [DataTestMethod]
    [DataRow("missingOwner")]
    [DataRow("publicOwner")]
    [DataRow("duplicateOwner")]
    [DataRow("otherCommand")]
    [DataRow("menu")]
    [DataRow("foreignKey")]
    [DataRow("tenantColumn")]
    [DataRow("action")]
    [DataRow("customTab")]
    public void InvalidDeclarationsAreRejected(string scenario)
    {
        var fixture = Create();
        switch (scenario)
        {
            case "missingOwner": fixture.UseCaseGroup.Clear(); break;
            case "publicOwner":
                fixture.UseCaseGroup.Clear();
                fixture.AddUsecaseGroup("Memorias").AddUseCaseSubGrup("Canais")
                    .AddCommand("ReserveChannel", new Input(), new Output());
                break;
            case "duplicateOwner":
                fixture.AddUsecaseGroup("Memorias").AddUseCaseSubGrup("Canais")
                    .AddCommand("ReserveChannel", new Input(), new Output()).Internal();
                break;
            case "otherCommand":
                fixture.AddUsecaseGroup("Memorias").AddUseCaseSubGrup("Canais")
                    .AddCommand("Other", new Input(), new Output()).AddEntity("Channel");
                break;
            case "menu": fixture.AddMenuGroup("MEM", "Canais", "Channel"); break;
            case "foreignKey": fixture.AlterEntity("Album").AddColumn("ChannelId", "Canal").Int().FK("Channel", "Id"); break;
            case "tenantColumn": fixture.Entitys.Single(e => e.IsInternal).AddColumn("TenantID", "Tenant").Int(); break;
            case "action": fixture.AddUsecaseGroup("Memorias").ExposeAsEntityAction("Album", "Reservar"); break;
            case "customTab": fixture.Entitys.Single(e => e.EntityName == "Album").CustomTab("Canais").UseCase("ReserveChannel"); break;
        }
        Assert.ThrowsException<InvalidOperationException>(() => MigrationBuilder.ValidateInternalEntities([fixture]));
    }

    [TestMethod]
    public void GlobalWithoutInternalOwnerIsRejected()
    {
        var fixture = new Fixture();
        fixture.AddEntity("GlobalPublic").Global().AddColumn("Id", "ID").Int().Key();
        Assert.ThrowsException<InvalidOperationException>(() => MigrationBuilder.ValidateInternalEntities([fixture]));
    }

    [TestMethod]
    public void ConflictingOwnersAreRejected()
    {
        var entity = new Entity("Channel").InternalToUseCase("Memorias", "Canais", "Reserve");
        Assert.ThrowsException<InvalidOperationException>(() => entity.InternalToUseCase("Memorias", "Canais", "Other"));
    }

    [TestMethod]
    public void InternalEntityAndCommandHaveNoPublicEndpointsOrMenu()
    {
        var fixture = Create();
        MigrationBuilder.ValidateInternalEntities([fixture]);
        var endpoints = Generate(new SourceCodeInfraestructureAPIEndpointsMigration(fixture, "Memorias"));
        Assert.IsFalse(endpoints.Contains("Channel", StringComparison.Ordinal));
        Assert.IsFalse(endpoints.Contains("ReserveChannel", StringComparison.Ordinal));
        StringAssert.Contains(endpoints, "getMetaDataAlbum");
        StringAssert.Contains(endpoints, "PostAlbum");
        var menus = Generate(new SourceCodeInfraestructureModulesMigration(fixture));
        Assert.IsFalse(menus.Contains("getMetaDataChannel", StringComparison.Ordinal));
        StringAssert.Contains(menus, "getMetaDataAlbum");
        var dependencies = Generate(new SourceCodeInfraestructureDependencInjectionInjectionMigration(fixture));
        StringAssert.Contains(dependencies, "IChannelWriteRepository");
        StringAssert.Contains(dependencies, "ReserveChannelHandler");
        Assert.IsFalse(dependencies.Contains("InsertChannelReceiver", StringComparison.Ordinal));
        Assert.IsFalse(dependencies.Contains("IChannelQueryRead", StringComparison.Ordinal));
    }

    [TestMethod]
    public void InternalRepositoriesExposeOnlyCustomMethodsAndPreserveCustomFiles()
    {
        var entity = Create().Entitys.Single(e => e.IsInternal);
        foreach (var generator in new SourceCodeBase[] {
            new SourceCodeAplicationRepositoryInterfacesReadMigration(entity),
            new SourceCodeAplicationRepositoryInterfacesWriteMigration(entity, "Memorias"),
            new SourceCodeInfraestructureReadConcreteRepositoryMigration(entity, false),
            new SourceCodeInfraestructureWriteConcreteRepositoryMigration(entity, "Memorias") })
        {
            var code = Generate(generator);
            Assert.IsFalse(code.Contains("ICommandRead", StringComparison.Ordinal));
            Assert.IsFalse(code.Contains("QueryRead", StringComparison.Ordinal));
            Assert.IsFalse(code.Contains("void Insert(", StringComparison.Ordinal));
            StringAssert.Contains(code, "partial");
        }
    }

    [TestMethod]
    public void GeneratesOwnerButNoCrudCommandsReceiversOrQueriesForInternalEntity()
    {
        var directory = Path.Combine(Path.GetTempPath(), "Yeshua.Engine.Tests", Guid.NewGuid().ToString("N"));
        try
        {
            var fixture = Create();
            MigrationBuilder.ValidateInternalEntities([fixture]);
            var schema = new CSharpCQRS("Memorias", directory);
            schema.AppAplicationGenerateCommandCommands(fixture);
            schema.AppAplicationGenerateCommandReceivers(fixture);
            schema.AppInfraestructureGenerateReadConcreteQuerys(fixture);
            schema.AppInfraestructureGenerateWriteConcreteQuerys(fixture);
            var files = Directory.GetFiles(directory, "*.cs", SearchOption.AllDirectories);
            Assert.IsTrue(files.Any(p => p.EndsWith("ReserveChannelCommands.cs", StringComparison.Ordinal)));
            Assert.IsTrue(files.Any(p => p.EndsWith("ReserveChannelHandler.cs", StringComparison.Ordinal)));
            Assert.IsTrue(files.Any(p => p.EndsWith("AlbumCommands.cs", StringComparison.Ordinal)));
            Assert.IsFalse(files.Any(p => p.EndsWith("ChannelCommands.cs", StringComparison.Ordinal) && !p.EndsWith("ReserveChannelCommands.cs", StringComparison.Ordinal)));
            Assert.IsFalse(files.Any(p => p.Contains("\\Channel\\", StringComparison.Ordinal)));
        }
        finally
        {
            if (Directory.Exists(directory)) Directory.Delete(directory, true);
        }
    }

    private static Fixture Create()
    {
        var fixture = new Fixture();
        fixture.AddModule("MEM", "Memorias");
        fixture.AddEntity("Channel").AddModule("MEM").Global()
            .InternalToUseCase("Memorias", "Canais", "ReserveChannel")
            .AddColumn("Id", "ID").Int().Key();
        fixture.AddEntity("Album").AddModule("MEM").AddColumn("Id", "ID").Int().Key();
        fixture.AddUsecaseGroup("Memorias").AddUseCaseSubGrup("Canais")
            .AddCommand("ReserveChannel", new Input(), new Output()).Internal();
        return fixture;
    }

    private static UseCaseCommand Owner(Fixture fixture) => fixture.UseCaseGroup.Single().UseCaseSubGroup.Single().UseCaseCommand.Single();

    private static string Generate(SourceCodeBase generator)
    {
        var directory = Path.Combine(Path.GetTempPath(), "Yeshua.Engine.Tests", Guid.NewGuid().ToString("N"));
        try
        {
            Directory.CreateDirectory(directory);
            var path = Path.Combine(directory, "generated.cs");
            var custom = Path.Combine(directory, "custom.cs");
            File.WriteAllText(custom, "custom-owned");
            generator.WriteCode(null, path, custom);
            Assert.AreEqual("custom-owned", File.ReadAllText(custom));
            return File.ReadAllText(path);
        }
        finally
        {
            if (Directory.Exists(directory)) Directory.Delete(directory, true);
        }
    }

    private sealed class Fixture : MigrationBase { public override void Up() { } }
    public sealed record Input();
    public sealed record Output();
}
