using Yeshua.Studio.Fiscal;
using Dominio.Migration;
using Dominio.Schemas;
using Dominio.Schemas.CQRS;
using Infra;
using Migration.Interfaces;
using System.Data;

Console.WriteLine("Begin Fiscal");

var mode = GetExecutionMode(args);
if (IsCleanupMode(mode))
{
    Console.WriteLine("Running cleanup mode.");
    var cleaner = new CSharpCQRS(
        GS.I.MYC.Project,
        GS.I.MYC.Source,
        "Yeshua.Studio.Fiscal");
    cleaner.CleanApplicationGeneratedMigration();
    cleaner.WriteApplicationCustonCleanupReport();
    return;
}

if (IsCustonReportMode(mode))
{
    Console.WriteLine("Running Custon report mode.");
    var reporter = new CSharpCQRS(
        GS.I.MYC.Project,
        GS.I.MYC.Source,
        "Yeshua.Studio.Fiscal");
    reporter.WriteApplicationCustonCleanupReport();
    return;
}

if (!IsGenerateMode(mode))
    throw new InvalidOperationException($"Modo de execucao do Studio Fiscal desconhecido: {mode}");

bool databaseOnly = args.Contains("--database-only", StringComparer.OrdinalIgnoreCase);

if (args.Contains("--codegen-only", StringComparer.OrdinalIgnoreCase))
{
    Console.WriteLine("Running code generation only.");
    new MigrationBuilder()
        .ADDSchema(new CSharpCQRS(
            GS.I.MYC.Project,
            GS.I.MYC.Source,
            "Yeshua.Studio.Fiscal"))
        .Build()
        .Run();
    return;
}
MigrationBuilder migration = new MigrationBuilder();

if (!databaseOnly && !string.IsNullOrWhiteSpace(GS.I.MYC.Source))
{
    migration.ADDSchema(new CSharpCQRS(
        GS.I.MYC.Project,
        GS.I.MYC.Source,
        "Yeshua.Studio.Fiscal"));
}

var connectionString = GS.I.MYC.ReadConectionString;
if (string.IsNullOrWhiteSpace(connectionString))
    connectionString = GS.I.MYC.WriteConectionString;

if (!string.IsNullOrWhiteSpace(connectionString))
{
    Console.WriteLine("Try Connection");

    using (IDbConnection connection = new SqlFactory(EnumSqlConections.SqlServer, connectionString).SqlConnection())
    using (IUnitOfWork unitOfWork = new UnitOfWork(connection, true))
    {
        Console.WriteLine("Try Migrations");
        migration.ADDSchema(new SqlServerSchema(unitOfWork));
        migration.Build().Run();
    }
}
else
{
    Console.WriteLine("No database connection configured. Running code generation only.");
    migration.Build().Run();
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

static bool IsGenerateMode(string mode)
{
    return mode.Equals("generate", StringComparison.OrdinalIgnoreCase)
        || mode.Equals("gerar", StringComparison.OrdinalIgnoreCase);
}

static bool IsCleanupMode(string mode)
{
    return mode.Equals("cleanup", StringComparison.OrdinalIgnoreCase)
        || mode.Equals("clean", StringComparison.OrdinalIgnoreCase)
        || mode.Equals("limpeza", StringComparison.OrdinalIgnoreCase)
        || mode.Equals("limpar", StringComparison.OrdinalIgnoreCase);
}

static bool IsCustonReportMode(string mode)
{
    return mode.Equals("custon-report", StringComparison.OrdinalIgnoreCase)
        || mode.Equals("custom-report", StringComparison.OrdinalIgnoreCase)
        || mode.Equals("relatorio-custon", StringComparison.OrdinalIgnoreCase)
        || mode.Equals("relatorio-custom", StringComparison.OrdinalIgnoreCase);
}
