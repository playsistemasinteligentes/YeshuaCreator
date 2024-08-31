using Dominio.Migration;
using Dominio.Schemas;
using Dominio.Schemas.CQRS;
using Shered.DB.Connection;
using System.Data;



using (IDbConnection connection = new SqlFactory(EnumSqlConections.SqlServer).SqlConnection())
{
    using (IUnitOfWork unitOfWork = new UnitOfWork(connection))
    {
        new MigrationBuilder()
            .ADDSchema(new CSharpCQRS("Clinica", "C:\\temp"))
            .ADDSchema(new SqlServerSchema(unitOfWork))
            .Build().Run();
        
        // pendecias 
        // kubernate
        // half checking 


    }
}



//ClinicaWriteRepository rep = new ClinicaWriteRepository(new SqlFactory());
//InsertClinicaReceiver receiver = new InsertClinicaReceiver(rep);
//ClinicaCommand comand = new ClinicaCommand { NomeFantasia = "angelo", RazaoSocial = "fontan" };
//receiver.Execute(comand);


