using Dominio.Migration;
using Interfaces.Schemas;
using Migration.Interfaces;
using System.Security.Cryptography;
using System.Text;

namespace Dominio.Schemas
{
    public sealed class CentralAuthorizationSchema : IMigrationProjectionSchema
    {
        private const string ModuleDefinition = "Module";
        private const string GrantDefinition = "Grant";

        private readonly string _applicationKey;
        private readonly IUnitOfWork _unitOfWork;

        public CentralAuthorizationSchema(string applicationKey, IUnitOfWork unitOfWork)
        {
            if (string.IsNullOrWhiteSpace(applicationKey))
                throw new ArgumentException("O aplicativo da projecao de autorizacao deve ser informado.", nameof(applicationKey));

            _applicationKey = applicationKey.Trim();
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        }

        public void ApplyMigrations(IEnumerable<MigrationBase> migrations)
        {
            EnsureTables();

            foreach (var migration in migrations.Where(item => item.ID > 0).OrderBy(item => item.ID))
                ApplyMigration(migration);
        }

        private void ApplyMigration(MigrationBase migration)
        {
            var definitions = GetDefinitions(migration);
            var contentHash = CalculateContentHash(migration, definitions);
            var existingHash = GetExistingHash(migration.ID);

            if (existingHash is not null)
            {
                if (!string.Equals(existingHash, contentHash, StringComparison.OrdinalIgnoreCase))
                {
                    throw new InvalidOperationException(
                        $"A migration de autorizacao '{_applicationKey}:{migration.MigrationName}' ja foi aplicada na Central, " +
                        "mas seu conteudo foi alterado. Crie uma nova migration para modificar modulos ou permissoes.");
                }

                return;
            }

            try
            {
                _unitOfWork.BeginTran();

                foreach (var definition in definitions)
                    UpsertDefinition(migration.ID, definition);

                _unitOfWork.ExecuteCommand(
                    @"INSERT INTO dbo.yAuthorizationMigrationVersion
                        (ApplicationKey, MigrationId, MigrationName, ContentHash, AppliedAtUtc)
                      VALUES
                        (@ApplicationKey, @MigrationId, @MigrationName, @ContentHash, SYSUTCDATETIME());",
                    new
                    {
                        ApplicationKey = _applicationKey,
                        MigrationId = migration.ID,
                        MigrationName = migration.MigrationName,
                        ContentHash = contentHash
                    });

                _unitOfWork.Commit();
                Console.WriteLine($"Authorization migration applied: {_applicationKey}:{migration.MigrationName}");
            }
            catch
            {
                _unitOfWork.Rollback();
                throw;
            }
        }

        private string? GetExistingHash(int migrationId)
        {
            var count = _unitOfWork.QuerySingle<int>(
                @"SELECT COUNT(1)
                    FROM dbo.yAuthorizationMigrationVersion
                   WHERE ApplicationKey = @ApplicationKey
                     AND MigrationId = @MigrationId;",
                new { ApplicationKey = _applicationKey, MigrationId = migrationId });

            if (count == 0)
                return null;

            return _unitOfWork.QuerySingle<string>(
                @"SELECT ContentHash
                    FROM dbo.yAuthorizationMigrationVersion
                   WHERE ApplicationKey = @ApplicationKey
                     AND MigrationId = @MigrationId;",
                new { ApplicationKey = _applicationKey, MigrationId = migrationId });
        }

        private void UpsertDefinition(int migrationId, AuthorizationDefinition definition)
        {
            _unitOfWork.ExecuteCommand(
                @"MERGE dbo.yAuthorizationDefinition WITH (HOLDLOCK) AS target
                  USING (SELECT
                            @ApplicationKey AS ApplicationKey,
                            @DefinitionType AS DefinitionType,
                            @DefinitionKey AS DefinitionKey) AS source
                     ON target.ApplicationKey = source.ApplicationKey
                    AND target.DefinitionType = source.DefinitionType
                    AND target.DefinitionKey = source.DefinitionKey
                  WHEN MATCHED THEN
                    UPDATE SET
                        Description = @Description,
                        SourceMigrationId = @SourceMigrationId,
                        Active = 1,
                        ChangedAtUtc = SYSUTCDATETIME()
                  WHEN NOT MATCHED THEN
                    INSERT
                        (ApplicationKey, DefinitionType, DefinitionKey, Description, SourceMigrationId, Active, ChangedAtUtc)
                    VALUES
                        (@ApplicationKey, @DefinitionType, @DefinitionKey, @Description, @SourceMigrationId, 1, SYSUTCDATETIME());",
                new
                {
                    ApplicationKey = _applicationKey,
                    definition.DefinitionType,
                    definition.DefinitionKey,
                    definition.Description,
                    SourceMigrationId = migrationId
                });
        }

        private static IReadOnlyList<AuthorizationDefinition> GetDefinitions(MigrationBase migration)
        {
            var definitions = new Dictionary<string, AuthorizationDefinition>(StringComparer.OrdinalIgnoreCase);

            foreach (var module in migration.Modules.Where(item => item.Inserir && !string.IsNullOrWhiteSpace(item.Key)))
            {
                AddDefinition(
                    definitions,
                    new AuthorizationDefinition(
                        ModuleDefinition,
                        module.Key.Trim(),
                        module.Description._value ?? string.Empty));
            }

            foreach (var module in migration.Modules)
            {
                foreach (var page in module.CustomPages.Where(item => !string.IsNullOrWhiteSpace(item.Scope)))
                {
                    AddDefinition(
                        definitions,
                        new AuthorizationDefinition(
                            GrantDefinition,
                            page.Scope.Trim(),
                            page.Title ?? string.Empty));
                }
            }

            foreach (var group in migration.UseCaseGroup)
            {
                foreach (var subGroup in group.UseCaseSubGroup)
                {
                    foreach (var command in subGroup.UseCaseCommand)
                    {
                        var description = string.Join(
                            " / ",
                            new[] { group.Name._value, subGroup.Name._value, command.Name._value }
                                .Where(value => !string.IsNullOrWhiteSpace(value)));

                        foreach (var scope in command.Scopes.Where(item => !string.IsNullOrWhiteSpace(item)))
                        {
                            AddDefinition(
                                definitions,
                                new AuthorizationDefinition(GrantDefinition, scope.Trim(), description));
                        }
                    }
                }
            }

            return definitions.Values
                .OrderBy(item => item.DefinitionType, StringComparer.OrdinalIgnoreCase)
                .ThenBy(item => item.DefinitionKey, StringComparer.OrdinalIgnoreCase)
                .ToArray();
        }

        private static void AddDefinition(
            IDictionary<string, AuthorizationDefinition> definitions,
            AuthorizationDefinition definition)
        {
            var key = $"{definition.DefinitionType}:{definition.DefinitionKey}";
            definitions[key] = definition;
        }

        private static string CalculateContentHash(
            MigrationBase migration,
            IEnumerable<AuthorizationDefinition> definitions)
        {
            var content = new StringBuilder()
                .Append(migration.ID)
                .Append('|')
                .Append(migration.MigrationName)
                .AppendLine();

            foreach (var definition in definitions)
            {
                content
                    .Append(definition.DefinitionType)
                    .Append('|')
                    .Append(definition.DefinitionKey)
                    .Append('|')
                    .Append(definition.Description)
                    .AppendLine();
            }

            return Convert.ToHexString(SHA256.HashData(Encoding.UTF8.GetBytes(content.ToString())));
        }

        private void EnsureTables()
        {
            _unitOfWork.ExecuteCommand(
                @"IF OBJECT_ID(N'dbo.yAuthorizationMigrationVersion', N'U') IS NULL
                  BEGIN
                      CREATE TABLE dbo.yAuthorizationMigrationVersion
                      (
                          ApplicationKey NVARCHAR(100) NOT NULL,
                          MigrationId INT NOT NULL,
                          MigrationName NVARCHAR(128) NOT NULL,
                          ContentHash CHAR(64) NOT NULL,
                          AppliedAtUtc DATETIME2 NOT NULL,
                          CONSTRAINT PK_yAuthorizationMigrationVersion
                              PRIMARY KEY (ApplicationKey, MigrationId)
                      );
                  END;

                  IF OBJECT_ID(N'dbo.yAuthorizationDefinition', N'U') IS NULL
                  BEGIN
                      CREATE TABLE dbo.yAuthorizationDefinition
                      (
                          ApplicationKey NVARCHAR(100) NOT NULL,
                          DefinitionType NVARCHAR(20) NOT NULL,
                          DefinitionKey NVARCHAR(200) NOT NULL,
                          Description NVARCHAR(500) NOT NULL,
                          SourceMigrationId INT NOT NULL,
                          Active BIT NOT NULL,
                          ChangedAtUtc DATETIME2 NOT NULL,
                          CONSTRAINT PK_yAuthorizationDefinition
                              PRIMARY KEY (ApplicationKey, DefinitionType, DefinitionKey)
                      );
                  END;");
        }

        private sealed record AuthorizationDefinition(
            string DefinitionType,
            string DefinitionKey,
            string Description);
    }
}
