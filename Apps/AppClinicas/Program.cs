using Dominio.Migration;
using Dominio.Schemas;
using Dominio.Schemas.CQRS;
using DominioDeTestes.config;
using Shered.DB.Connection;
using System.Data;
using System.IO;
using System.IO.Compression;
using System.Text;

Console.WriteLine("Begin");

Console.WriteLine("Try Parameters");
string conectionString = GS.I.MYC.ReadConectionString;

using (IDbConnection connection = new SqlFactory(EnumSqlConections.SqlServer, conectionString).SqlConnection())
{
    Console.WriteLine("Try Conection");

    using (IUnitOfWork unitOfWork = new UnitOfWork(connection, true))
    {
        Console.WriteLine("Try Migrations");
        new MigrationBuilder()
            .ADDSchema(new CSharpCQRS("Clinica", "C:\\Users\\angel\\source\\repos\\playsistemasinteligentes\\YeshuaCreator"))
            .ADDSchema(new SqlServerSchema(unitOfWork))
            .Build().Run();
    }
}
