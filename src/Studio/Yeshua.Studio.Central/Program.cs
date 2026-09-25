using Dominio.Migration;
using Dominio.Schemas;
using Dominio.Schemas.CQRS;
using Infra;
using Migration.Interfaces;
using System.Data;
using Yeshua.Studio.Central;

Console.WriteLine("Begin Central");

var mode = GetExecutionMode(args);
if (IsCleanupMode(mode))
{
    Console.WriteLine("Running cleanup mode.");
    var cleaner = CreateSchema();
    cleaner.CleanApplicationGeneratedMigration();
    cleaner.WriteApplicationCustonCleanupReport();
    return;
}

if (IsCustonReportMode(mode))
{
    Console.WriteLine("Running Custon report mode.");
    CreateSchema().WriteApplicationCustonCleanupReport();
    return;
}

if (!IsGenerateMode(mode))
    throw new InvalidOperationException($"Modo de execucao do Studio Central desconhecido: {mode}");

var databaseOnly = args.Contains("--database-only", StringComparer.OrdinalIgnoreCase);
var migration = new MigrationBuilder();
if (!databaseOnly && !string.IsNullOrWhiteSpace(GS.I.MYC.Source))
    migration.ADDSchema(CreateSchema());

if (!args.Contains("--codegen-only", StringComparer.OrdinalIgnoreCase))
{
    var connectionString = string.IsNullOrWhiteSpace(GS.I.MYC.ReadConectionString)
        ? GS.I.MYC.WriteConectionString
        : GS.I.MYC.ReadConectionString;

    if (!string.IsNullOrWhiteSpace(connectionString))
    {
        using IDbConnection connection = new SqlFactory(EnumSqlConections.SqlServer, connectionString).SqlConnection();
        using IUnitOfWork unitOfWork = new UnitOfWork(connection, true);
        migration.ADDSchema(new SqlServerSchema(unitOfWork));

        var centralConnectionString = GS.I.MYC.CentralAuthorizationConectionString;
        if (string.IsNullOrWhiteSpace(centralConnectionString)
            || string.Equals(centralConnectionString, connectionString, StringComparison.Ordinal))
        {
            migration.ADDSchema(new CentralAuthorizationSchema(GS.I.MYC.Project, unitOfWork));
            migration.Build().Run();
        }
        else
        {
            using IDbConnection centralConnection = new SqlFactory(
                EnumSqlConections.SqlServer,
                centralConnectionString).SqlConnection();
            using IUnitOfWork centralUnitOfWork = new UnitOfWork(centralConnection, true);
            migration.ADDSchema(new CentralAuthorizationSchema(GS.I.MYC.Project, centralUnitOfWork));
            migration.Build().Run();
        }
        return;
    }
}

migration.Build().Run();

static CSharpCQRS CreateSchema()
{
    return new CSharpCQRS(
            GS.I.MYC.Project,
            GS.I.MYC.Source,
            "Yeshua.Studio.Central")
        .AddSharedFrontHost("/apps/central/yapi");
}

static string GetExecutionMode(string[] args)
{
    var mode = args.FirstOrDefault(x => x.StartsWith("--mode=", StringComparison.OrdinalIgnoreCase));
    if (!string.IsNullOrWhiteSpace(mode))
        return mode["--mode=".Length..];

    var modeIndex = Array.FindIndex(args, x => x.Equals("--mode", StringComparison.OrdinalIgnoreCase));
    if (modeIndex >= 0 && modeIndex + 1 < args.Length)
        return args[modeIndex + 1];

    if (args.Contains("--cleanup", StringComparer.OrdinalIgnoreCase))
        return "cleanup";
    if (args.Contains("--custon-report", StringComparer.OrdinalIgnoreCase))
        return "custon-report";
    return "generate";
}

static bool IsGenerateMode(string mode) =>
    mode.Equals("generate", StringComparison.OrdinalIgnoreCase)
    || mode.Equals("gerar", StringComparison.OrdinalIgnoreCase);

static bool IsCleanupMode(string mode) =>
    mode.Equals("cleanup", StringComparison.OrdinalIgnoreCase)
    || mode.Equals("clean", StringComparison.OrdinalIgnoreCase)
    || mode.Equals("limpeza", StringComparison.OrdinalIgnoreCase)
    || mode.Equals("limpar", StringComparison.OrdinalIgnoreCase);

static bool IsCustonReportMode(string mode) =>
    mode.Equals("custon-report", StringComparison.OrdinalIgnoreCase)
    || mode.Equals("custom-report", StringComparison.OrdinalIgnoreCase)
    || mode.Equals("relatorio-custon", StringComparison.OrdinalIgnoreCase)
    || mode.Equals("relatorio-custom", StringComparison.OrdinalIgnoreCase);
