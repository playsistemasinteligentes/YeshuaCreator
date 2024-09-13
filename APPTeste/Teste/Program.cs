using Dominio.Migration;
using Dominio.Schemas;
using Dominio.Schemas.CQRS;
using DominioDeTestes.config;
using Shered.DB.Connection;
using System.Data;
using System.IO;
using System.IO.Compression;
using System.Text;

string conectionString = "Data Source=DESKTOP-JT9N4SD;Initial Catalog=YESHUA;User ID=sa;Password=sa;TrustServerCertificate=True;";
var gbs = GlobalSettingsSingleton.Instance
    .SetStringConetionWrite(conectionString)
    .SetStringConetionRead(conectionString);

using (IDbConnection connection = new SqlFactory(EnumSqlConections.SqlServer, gbs.GetConnectionStringWrite()).SqlConnection())
{
    using (IUnitOfWork unitOfWork = new UnitOfWork(connection))
    {
        new MigrationBuilder()
            .ADDSchema(new CSharpCQRS("Clinica", "C:\\Users\\angel\\source\\repos\\playsistemasinteligentes\\YeshuaCreator"))
            .ADDSchema(new SqlServerSchema(unitOfWork))
            .Build().Run();
    }
}


// pendecias 
// kubernate
// half checking 
//PacienteSpecification
//PacienteValidation
// azure infra 
// amazon infra 

//ClinicaWriteRepository rep = new ClinicaWriteRepository(new SqlFactory());
//InsertClinicaReceiver receiver = new InsertClinicaReceiver(rep);
//ClinicaCommand comand = new ClinicaCommand { NomeFantasia = "angelo", RazaoSocial = "fontan" };
//receiver.Execute(comand);


