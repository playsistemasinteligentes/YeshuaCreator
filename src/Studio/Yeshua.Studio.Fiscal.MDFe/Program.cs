using Yeshua.Studio.Fiscal.MDFe;
using Dominio.Migration;
using Dominio.Schemas;
using Dominio.Deployment;
using Dominio.Schemas.CQRS;
using Infra;
using Migration.Interfaces;
using System.Data;

Console.WriteLine("Begin MDF-e");

var deployment = new DeploymentSchema(GS.I.MYC.Project, GS.I.MYC.Source)
    .AddResource("sqlserver", DeploymentResourceKind.DatabaseServer, resource => resource
        .IdentifiedBy("sql01")
        .Configure("Engine", "SqlServer")
        .Secret("MSSQL_SA_PASSWORD", "sql01-sa-password")
        .Persistent("sql-data", "/var/opt/mssql"))
    .AddResource("database", DeploymentResourceKind.DatabaseCatalog, resource => resource
        .HostedBy("sqlserver")
        .Configure("Catalog", "MDFE"))
    .AddWorkload("api", workload => workload
        .FromProject("src/CQRS/Infrastructure/Yeshua.Fiscal.MDFe.CQRS.Infrastructure.Api/Yeshua.Fiscal.MDFe.CQRS.Infrastructure.Api.csproj")
        .Requires("database")
        .Configure("ASPNETCORE_ENVIRONMENT", "Production")
        .Secret("MYCONFIG__READCONECTIONSTRING", "mdfe-database-read-connection")
        .Secret("MYCONFIG__WRITECONECTIONSTRING", "mdfe-database-write-connection")
        .ExposeHttp("http", 7214, "/mdfe/yapi", "/yapi")
        .TcpHealthCheck("http"))
    .AddWorkload("front", workload => workload
        .FromProject("src/CQRS/Infrastructure/Yeshua.Fiscal.MDFe.CQRS.Infrastructure.Front/Yeshua.Fiscal.MDFe.CQRS.Infrastructure.Front.csproj")
        .Requires("api")
        .Configure("ASPNETCORE_ENVIRONMENT", "Production")
        .ExposeHttp("http", 8080, "/mdfe", "/")
        .TcpHealthCheck("http"))
    .AddWorkload("migration", workload => workload
        .FromProject(
            "src/Studio/Yeshua.Studio.Fiscal.MDFe/Yeshua.Studio.Fiscal.MDFe.csproj",
            DotNetRuntimeKind.Runtime)
        .Requires("database")
        .Secret("MYCONFIG__READCONECTIONSTRING", "mdfe-database-read-connection")
        .Secret("MYCONFIG__WRITECONECTIONSTRING", "mdfe-database-write-connection")
        .RunOnce());

if (args.Contains("--deployment-only", StringComparer.OrdinalIgnoreCase))
{
    Console.WriteLine("Running deployment generation only.");
    new MigrationBuilder()
        .ADDSchema(deployment)
        .Build()
        .Run();
    return;
}

if (args.Contains("--codegen-only", StringComparer.OrdinalIgnoreCase))
{
    Console.WriteLine("Running code generation only.");
    new MigrationBuilder()
        .ADDSchema(new CSharpCQRS(
            GS.I.MYC.Project,
            GS.I.MYC.Source,
            "Yeshua.Studio.Fiscal.MDFe"))
        .ADDSchema(deployment)
        .Build()
        .Run();
    return;
}

MigrationBuilder migration = new MigrationBuilder();

if (!string.IsNullOrWhiteSpace(GS.I.MYC.Source))
    migration.ADDSchema(new CSharpCQRS(
        GS.I.MYC.Project,
        GS.I.MYC.Source,
        "Yeshua.Studio.Fiscal.MDFe"));
    migration.ADDSchema(deployment);

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
