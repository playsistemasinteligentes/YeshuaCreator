using Dominio.Migration;
using Dominio.Schemas.CQRS;
using Dominio.Schemas;
using DominioDeTestes.config;
using Shered.DB.Connection;
using System.Data;

namespace TestMigration
{
    [TestClass]
    public class MigrationTest
    {
        [TestMethod]
        public void TestMethod1()
        {
            bool resultado = true;
            string msgError = string.Empty;
            try
            {
                string conectionString = "Data Source=DESKTOP-JT9N4SD;Initial Catalog=YESHUA;User ID=sa;Password=sa;TrustServerCertificate=True;";


                var gbs = GlobalSettingsSingleton.Instance
                    .SetStringConetionWrite(conectionString)
                    .SetStringConetionRead(conectionString);

                using (IDbConnection connection = new SqlFactory(EnumSqlConections.SqlServer, gbs.GetConnectionStringWrite()).SqlConnection())
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

            }
            catch (Exception e)
            {
                msgError = e.Message;
                resultado = false;
            }



            Assert.AreEqual(true, resultado, "Erro ");
        }
    }
}