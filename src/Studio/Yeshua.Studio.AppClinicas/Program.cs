using Dominio.Migration;
using Dominio.Schemas;
using Dominio.Schemas.CQRS;
using Infra;
using Migration.Interfaces;
using System.Data;

Console.WriteLine("Begin");

if (args.Contains("--codegen-only", StringComparer.OrdinalIgnoreCase))
{
    Console.WriteLine("Running code generation only.");
    new MigrationBuilder()
        .ADDSchema(new CSharpCQRS(
            GS.I.MYC.Project,
            GS.I.MYC.Source,
            "Yeshua.Studio.AppClinicas"))
        .Build()
        .Run();
    return;
}
Console.WriteLine("Try Parameters");
string conectionString = GS.I.MYC.ReadConectionString;

using (IDbConnection connection = new SqlFactory(EnumSqlConections.SqlServer, conectionString).SqlConnection())
{
    Console.WriteLine("Try Conection");

    using (IUnitOfWork unitOfWork = new UnitOfWork(connection, true))
    {
        Console.WriteLine("Try Migrations");

        MigrationBuilder migration = new MigrationBuilder();
        if (!string.IsNullOrEmpty(GS.I.MYC.Source))
            migration.ADDSchema(new CSharpCQRS(
                GS.I.MYC.Project,
                GS.I.MYC.Source,
                "Yeshua.Studio.AppClinicas"));
        migration.ADDSchema(new SqlServerSchema(unitOfWork));
        migration.Build().Run();
    }
}
