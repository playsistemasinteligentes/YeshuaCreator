using Dominio.Migration;
using Dominio.Schemas;
using Dominio.Schemas.CQRS;
using Infra;
using Migration.Interfaces;
using System.Data;

Console.WriteLine("Begin");

Console.WriteLine("Try Parameters");
string conectionString = GS.I.MYC.ReadConectionString;

using (IDbConnection connection = new SqlFactory(EnumSqlConections.SqlServer, conectionString).SqlConnection())
{
    Console.WriteLine("Try Conection");

    using (IUnitOfWork unitOfWork = new UnitOfWorkMok(connection, true))
    {
        Console.WriteLine("Try Migrations");

        MigrationBuilder migration = new MigrationBuilder();
        if (!string.IsNullOrEmpty(GS.I.MYC.Source))
            migration.ADDSchema(new CSharpCQRS(GS.I.MYC.Project, GS.I.MYC.Source));
        migration.ADDSchema(new SqlServerSchema(unitOfWork));
        migration.Build().Run();
    }
}
