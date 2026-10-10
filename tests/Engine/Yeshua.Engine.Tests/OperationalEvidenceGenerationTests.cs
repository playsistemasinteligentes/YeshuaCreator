using Dominio;
using Dominio.Migration;
using Dominio.Schemas;
using Dominio.Schemas.CQRS;
using Migration.Dominio.Schemas.CQRS;

namespace TestMigration;

[TestClass]
public sealed class OperationalEvidenceGenerationTests
{
    [TestMethod]
    public void ClassificationConventionUsesMetadataNamesAndExplicitOverrides()
    {
        var entity = CreateEntity();

        Assert.AreEqual(
            OperationalDataClassification.Internal,
            OperationalDataClassificationConvention.Classify(Field(entity, "Status")));
        Assert.AreEqual(
            OperationalDataClassification.Confidential,
            OperationalDataClassificationConvention.Classify(Field(entity, "Cpf")));
        Assert.AreEqual(
            OperationalDataClassification.NeverCapture,
            OperationalDataClassificationConvention.Classify(Field(entity, "PasswordHash")));
        Assert.AreEqual(
            OperationalDataClassification.Public,
            OperationalDataClassificationConvention.Classify(Field(entity, "PublicCode")));
    }

    [TestMethod]
    public void EntityDecoratorGeneratesStaticClassificationsWithoutReflection()
    {
        var directory = CreateDirectory();

        try
        {
            var entity = CreateEntity();
            var migrationPath = Path.Combine(directory, "ClienteEntityDecorator.cs");
            var customPath = Path.Combine(directory, "ClienteEntityDecorator.Custon.cs");

            new SourceCodeEntityMigration(entity, CommandType.EntityDecorator)
                .WriteCode(entity, migrationPath, customPath);

            var content = File.ReadAllText(migrationPath);
            StringAssert.Contains(content, "public static class ClienteOperationalFields");
            StringAssert.Contains(
                content,
                "OperationalDataClassification Cpf = Dominio.Operational.OperationalDataClassification.Confidential");
            StringAssert.Contains(
                content,
                "OperationalDataClassification PasswordHash = Dominio.Operational.OperationalDataClassification.NeverCapture");
            StringAssert.Contains(content, "ClienteOperationalFields.Cpf");
            Assert.IsFalse(content.Contains("System.Reflection", StringComparison.Ordinal));
        }
        finally
        {
            Directory.Delete(directory, true);
        }
    }

    [TestMethod]
    public void OperationalPolicyGenerationPropagatesExecutionMode()
    {
        var directory = CreateDirectory();

        try
        {
            var migration = new OperationalMigration();
            migration.Up();
            var path = Path.Combine(directory, "OperationalLoggingPolicy.cs");

            new SourceCodeInfrastructureOperationalControlStateMigration(migration)
                .WriteGeneratedCode(path);

            var content = File.ReadAllText(path);
            StringAssert.Contains(content, "public string DefaultMode { get; init; } = \"Live\"");
            StringAssert.Contains(content, "public string? Mode { get; init; }");
            StringAssert.Contains(content, "DefaultMode = NormalizeMode(update.DefaultMode, current.DefaultMode)");
            StringAssert.Contains(content, "decision.Mode");
            StringAssert.Contains(content, "\"SIMULATION\" => \"Simulation\"");
        }
        finally
        {
            Directory.Delete(directory, true);
        }
    }

    [TestMethod]
    public void CrudReceiverGenerationPropagatesSynchronousExecutionIdentity()
    {
        var directory = CreateDirectory();

        try
        {
            var entity = CreateEntity();
            var migrationPath = Path.Combine(directory, "InsertClienteReceiver.cs");
            var customPath = Path.Combine(directory, "InsertClienteReceiver.Custon.cs");

            new SourceCodeAplicationCommandReceiversMigration(
                    entity,
                    CommandType.Insert,
                    "Command.Receivers.Write",
                    string.Empty)
                .WriteCode(entity, migrationPath, customPath);

            var content = File.ReadAllText(migrationPath);
            StringAssert.Contains(content, "var trackingMask = _domainTrackingPolicy.GetMask");
            StringAssert.Contains(content, "TryGetOperationalIdentity(out var executionIdentity)");
            StringAssert.Contains(content, "trackingMask != 0UL ? _executionContext.BeginOperationalExecution");
            StringAssert.Contains(content, "trackingMask: trackingMask");
            StringAssert.Contains(content, "rootOperationId: executionIdentity.RootOperationId");
            StringAssert.Contains(content, "operationId: executionIdentity.OperationId");
            StringAssert.Contains(content, "executionId: executionIdentity.ExecutionId");
            StringAssert.Contains(content, "causationId: executionIdentity.CausationId");
        }
        finally
        {
            Directory.Delete(directory, true);
        }
    }

    [TestMethod]
    public void AsyncOperationalIdentityIsStandardForSagaOutboxAndInbox()
    {
        var migration = new Migration.Dominio.Migration.S000009();
        migration.Up();

        foreach (var entityName in new[] { "ySaga", "ySagaStep", "yOutbox", "yInbox" })
        {
            var entity = migration.Entitys.Single(candidate => candidate.EntityName == entityName);
            CollectionAssert.AreEquivalent(
                new[] { "RootOperationId", "OperationId", "ExecutionId", "CausationId" },
                entity.AddColumns.Select(column => column.Name).ToArray());
        }
    }

    [TestMethod]
    public void SagaWorkerGenerationStartsOneCausalExecutionPerRecord()
    {
        var directory = CreateDirectory();

        try
        {
            var migrationPath = Path.Combine(directory, "SagaWorkerCommandHandler.cs");
            var customPath = Path.Combine(directory, "SagaWorkerCommandHandler.Custon.cs");

            new SourceCodeApplicationSagaWorker(false)
                .WriteCode(null, migrationPath, customPath);

            var content = File.ReadAllText(migrationPath);
            StringAssert.Contains(content, "new OperationalExecutionIdentity(");
            StringAssert.Contains(content, "sagaDto.rootoperationid");
            StringAssert.Contains(content, "BeginOperationalExecution(");
            StringAssert.Contains(content, "\"SagaWorker.Record\"");
            StringAssert.Contains(content, "saga.SetOperationalIdentity(");
            StringAssert.Contains(content, "saga.GetCurrent()?.SetOperationalIdentity(");
        }
        finally
        {
            Directory.Delete(directory, true);
        }
    }

    [TestMethod]
    public void OutboxGenerationCopiesTheCurrentOperationalIdentity()
    {
        var directory = CreateDirectory();

        try
        {
            var migrationPath = Path.Combine(directory, "OutboxService.cs");
            var customPath = Path.Combine(directory, "OutboxService.Custon.cs");

            new SourceCodeApplicationOutboxService()
                .WriteCode(null, migrationPath, customPath);

            var content = File.ReadAllText(migrationPath);
            StringAssert.Contains(content, "TryGetOperationalIdentity(out var identity)");
            StringAssert.Contains(content, "identity.RootOperationId");
            StringAssert.Contains(content, "identity.OperationId");
            StringAssert.Contains(content, "identity.ExecutionId");
            StringAssert.Contains(content, "identity.CausationId");
            StringAssert.Contains(content, "_logger.Evaluate(\"Outbox\"");
            StringAssert.Contains(content, "_logger.Evaluate(\"Inbox\"");
            StringAssert.Contains(content, "new Dominio.Operational.OperationalEvidenceTransition(");
            StringAssert.Contains(content, "\"Stored\"");
            StringAssert.Contains(content, "\"StoreFailed\"");
            Assert.IsFalse(content.Contains("payloadJson, telemetry", StringComparison.Ordinal));
        }
        finally
        {
            Directory.Delete(directory, true);
        }
    }

    [TestMethod]
    public void ModuleIngressEndpointIsGeneratedFromDeclaredContracts()
    {
        var directory = CreateDirectory();

        try
        {
            var migration = new ModuleIngressMigration();
            migration.Up();
            var migrationPath = Path.Combine(directory, "EndPoints.cs");
            var customPath = Path.Combine(directory, "EndPoints.Custon.cs");

            new SourceCodeInfraestructureAPIEndpointsMigration(migration, "Fiscal")
                .WriteCode(null, migrationPath, customPath);

            var content = File.ReadAllText(migrationPath);
            StringAssert.Contains(content, "CargaProntaParaEmissaoFiscal.v1");
            StringAssert.Contains(content, "/yapi/Fiscal/Inbox/YeshuaModuleEvent");
            StringAssert.Contains(content, "YeshuaModuleIngressTypes.Contains(envelope.Type)");
            StringAssert.Contains(content, "BeginOperationalExecution(parentIdentity, \"Inbox.YeshuaModuleEvent\")");
            StringAssert.Contains(content, "outboxService.AddInboxEvent(");
            StringAssert.Contains(content, "unitOfWork.Commit();");
            StringAssert.Contains(content, ").RequireAuthorization();");
            Assert.IsFalse(content.Contains("unitOfWork.Execute(", StringComparison.Ordinal));
        }
        finally
        {
            Directory.Delete(directory, true);
        }
    }

    [TestMethod]
    public void GlobalTenantIdentityGenerationUsesExplicitKeyAndCentralSequence()
    {
        var directory = CreateDirectory();

        try
        {
            var migration = new global::Migration.Dominio.Migration.S000001();
            migration.Up();
            var tenant = migration.Entitys.Single(entity => entity.EntityName == "yTenant");

            var factoryPath = Path.Combine(directory, "yTenantFactory.cs");
            new SourceCodeEntityMigration(tenant, CommandType.Factory)
                .WriteCode(tenant, factoryPath, Path.Combine(directory, "yTenantFactory.Custon.cs"));

            var queryPath = Path.Combine(directory, "yTenantWriteQuery.cs");
            new SourceCodeInfraestructureQueryWriteMigration(tenant, false, "Central")
                .WriteCode(tenant, queryPath, Path.Combine(directory, "yTenantWriteQuery.Custon.cs"));

            var repositoryPath = Path.Combine(directory, "yTenantWriteRepository.cs");
            new SourceCodeInfraestructureWriteConcreteRepositoryMigration(tenant, "Central")
                .WriteCode(tenant, repositoryPath, Path.Combine(directory, "yTenantWriteRepository.Custon.cs"));

            var fiscalQueryPath = Path.Combine(directory, "Fiscal.yTenantWriteQuery.cs");
            new SourceCodeInfraestructureQueryWriteMigration(tenant, false, "Fiscal")
                .WriteCode(tenant, fiscalQueryPath, Path.Combine(directory, "Fiscal.yTenantWriteQuery.Custon.cs"));

            var fiscalRepositoryPath = Path.Combine(directory, "Fiscal.yTenantWriteRepository.cs");
            new SourceCodeInfraestructureWriteConcreteRepositoryMigration(tenant, "Fiscal")
                .WriteCode(tenant, fiscalRepositoryPath, Path.Combine(directory, "Fiscal.yTenantWriteRepository.Custon.cs"));

            var factory = File.ReadAllText(factoryPath);
            var query = File.ReadAllText(queryPath);
            var repository = File.ReadAllText(repositoryPath);
            var fiscalQuery = File.ReadAllText(fiscalQueryPath);
            var fiscalRepository = File.ReadAllText(fiscalRepositoryPath);

            StringAssert.Contains(factory, "Create(int id, string cnpjcpf");
            StringAssert.Contains(query, "SELECT NEXT VALUE FOR [yTenantIdGlobalSequence]");
            StringAssert.Contains(repository, "public int NextGlobalId()");
            Assert.IsFalse(query.Contains("OUTPUT INSERTED.[Id]", StringComparison.Ordinal));
            Assert.IsFalse(fiscalQuery.Contains("NextGlobalId", StringComparison.Ordinal));
            Assert.IsFalse(fiscalRepository.Contains("NextGlobalId", StringComparison.Ordinal));

            var centralSchema = new SqlServerSchema(null!, "Central").ApplyMigration(migration);
            var fiscalSchema = new SqlServerSchema(null!, "Fiscal").ApplyMigration(migration);
            Assert.IsTrue(centralSchema.Any(x => x.Query.Contains("yTenantIdGlobalSequence", StringComparison.Ordinal)));
            Assert.IsFalse(fiscalSchema.Any(x => x.Query.Contains("yTenantIdGlobalSequence", StringComparison.Ordinal)));
        }
        finally
        {
            Directory.Delete(directory, true);
        }
    }

    [TestMethod]
    public void GlobalUserIdentityAllocatorIsGeneratedOnlyForCentral()
    {
        var directory = CreateDirectory();

        try
        {
            var migration = new global::Migration.Dominio.Migration.S000001();
            migration.Up();
            var user = migration.Entitys.Single(entity => entity.EntityName == "yUser");

            var centralQueryPath = Path.Combine(directory, "Central.yUserWriteQuery.cs");
            new SourceCodeInfraestructureQueryWriteMigration(user, false, "Central")
                .WriteCode(user, centralQueryPath, Path.Combine(directory, "Central.yUserWriteQuery.Custon.cs"));

            var applicationQueryPath = Path.Combine(directory, "Fiscal.yUserWriteQuery.cs");
            new SourceCodeInfraestructureQueryWriteMigration(user, false, "Fiscal")
                .WriteCode(user, applicationQueryPath, Path.Combine(directory, "Fiscal.yUserWriteQuery.Custon.cs"));

            var centralQuery = File.ReadAllText(centralQueryPath);
            var applicationQuery = File.ReadAllText(applicationQueryPath);

            StringAssert.Contains(centralQuery, "SELECT NEXT VALUE FOR [yUserIdGlobalSequence]");
            Assert.IsFalse(applicationQuery.Contains("NextGlobalId", StringComparison.Ordinal));
            Assert.IsFalse(centralQuery.Contains("OUTPUT INSERTED.[Id]", StringComparison.Ordinal));

            var centralSchema = new SqlServerSchema(null!, "Central").ApplyMigration(migration);
            var applicationSchema = new SqlServerSchema(null!, "Fiscal").ApplyMigration(migration);
            Assert.IsTrue(centralSchema.Any(x => x.Query.Contains("yUserIdGlobalSequence", StringComparison.Ordinal)));
            Assert.IsFalse(applicationSchema.Any(x => x.Query.Contains("yUserIdGlobalSequence", StringComparison.Ordinal)));
        }
        finally
        {
            Directory.Delete(directory, true);
        }
    }

    [TestMethod]
    public void OptionalOperationalIdentityIsCopiedByCrudAndPersistedByInsert()
    {
        var directory = CreateDirectory();

        try
        {
            var entity = new Entity("yInbox");
            entity
                .AddColumn("Id", "ID").Int().Incremento().Key()
                .AddColumn("RootOperationId", "Operacao raiz").Varchar(128).DefaultValue("#null")
                .AddColumn("OperationId", "Operacao logica").Varchar(128).DefaultValue("#null")
                .AddColumn("ExecutionId", "Tentativa").Varchar(128).DefaultValue("#null")
                .AddColumn("CausationId", "Causa").Varchar(128).DefaultValue("#null");

            var receiverPath = Path.Combine(directory, "InsertyInboxReceiver.cs");
            new SourceCodeAplicationCommandReceiversMigration(
                    entity,
                    CommandType.Insert,
                    "Command.Receivers.Write",
                    string.Empty)
                .WriteCode(entity, receiverPath, Path.Combine(directory, "Receiver.Custon.cs"));

            var receiver = File.ReadAllText(receiverPath);
            StringAssert.Contains(
                receiver,
                "yinbox.RootOperationId = hasExecutionIdentity ? executionIdentity.RootOperationId : c.RootOperationId");
            StringAssert.Contains(
                receiver,
                "yinbox.CausationId = hasExecutionIdentity ? executionIdentity.CausationId : c.CausationId");

            var queryPath = Path.Combine(directory, "yInboxWriteQuerys.cs");
            new SourceCodeInfraestructureQueryWriteMigration(entity, false, "Fiscal")
                .WriteCode(entity, queryPath, Path.Combine(directory, "Query.Custon.cs"));

            var query = File.ReadAllText(queryPath);
            StringAssert.Contains(query, "RootOperationId = yInbox.RootOperationId");
            Assert.IsFalse(query.Contains("RootOperationId = null", StringComparison.Ordinal));
        }
        finally
        {
            Directory.Delete(directory, true);
        }
    }

    private static Entity CreateEntity()
    {
        var entity = new Entity("Cliente");
        entity
            .AddColumn("Status", "Status").Int()
            .AddColumn("Cpf", "CPF").Varchar(20)
            .AddColumn("PasswordHash", "Senha").Varchar(200).Password()
            .AddColumn("PublicCode", "Codigo publico").Varchar(30)
            .ClassifyOperationalData(OperationalDataClassification.Public);
        return entity;
    }

    private static Column Field(Entity entity, string name) =>
        entity.AddColumns.Single(column => column.Name == name);

    private static string CreateDirectory()
    {
        var directory = Path.Combine(
            Path.GetTempPath(),
            "Yeshua.Engine.Tests",
            Guid.NewGuid().ToString("N"));
        Directory.CreateDirectory(directory);
        return directory;
    }

    private sealed class OperationalMigration : MigrationBase
    {
        public override void Up()
        {
            AddEntity("Cliente")
                .AddColumn("Id", "ID").Int().Key()
                .AddColumn("Cpf", "CPF").Varchar(20);
        }
    }

    private sealed class ModuleIngressMigration : MigrationBase
    {
        public override void Up()
        {
            AddUsecaseGroup("Fiscal")
                .AddUseCaseSubGrup("Emissao")
                .AddSaga("EmissaoFiscal")
                .StartsFromYeshuaModuleEvent(
                    "APSADM",
                    "CargaProntaParaEmissaoFiscal",
                    1,
                    "CargaStandard",
                    "PublicarCarga");
        }
    }
}
