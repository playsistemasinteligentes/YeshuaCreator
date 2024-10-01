using Dominio.Migration;
using Dominio.Schemas;
using Dominio.Schemas.CQRS;
using DominioDeTestes.config;
using Shered.DB.Connection;
using System.Data;
using System.IO;
using System.IO.Compression;
using System.Text;

string conectionString = "Data Source=DESKTOP-2P3VSJ8;Initial Catalog=CLINICA;User ID=sa;Password=henrique662003;TrustServerCertificate=True;";
var gbs = GlobalSettingsSingleton.Instance
    .SetStringConetionWrite(conectionString)
    .SetStringConetionRead(conectionString);

using (IDbConnection connection = new SqlFactory(EnumSqlConections.SqlServer, gbs.GetConnectionStringWrite()).SqlConnection())
{
    using (IUnitOfWork unitOfWork = new UnitOfWork(connection))
    {
        new MigrationBuilder()
            .ADDSchema(new CSharpCQRS("Clinica", "C:\\Users\\henri\\OneDrive\\Área de Trabalho\\ProjetoEstagio\\ApiWhatsApp\\YeshuaCreator"))
            .ADDSchema(new SqlServerSchema(unitOfWork))
            .Build().Run();
    }
}
