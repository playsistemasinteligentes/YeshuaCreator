using Yeshua.Studio.Fiscal.CTe;
using Dominio.Migration;
using Dominio.Schemas;
using Dominio.Schemas.CQRS;
using Infra;
using Migration.Interfaces;
using System.Data;

Console.WriteLine("Begin CT-e");

bool databaseOnly = args.Contains("--database-only", StringComparer.OrdinalIgnoreCase);

if (args.Contains("--codegen-only", StringComparer.OrdinalIgnoreCase))
{
    Console.WriteLine("Running code generation only.");
    new MigrationBuilder()
        .ADDSchema(new CSharpCQRS(
            GS.I.MYC.Project,
            GS.I.MYC.Source,
            "Yeshua.Studio.Fiscal.CTe"))
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
        "Yeshua.Studio.Fiscal.CTe"));
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
