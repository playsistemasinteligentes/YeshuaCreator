using Central.Repository.Commercial;
using Microsoft.Data.SqlClient;
using Shered.DB.Connection;

namespace Central.Tests.Wallet;

// Run explicitly with the supplied test connection; the customer databases are never used.
public sealed class WalletSqlTests
{
    [Fact]
    public async Task Wallet_additions_and_allocations_are_atomic_idempotent_and_have_a_service_statement()
    {
        var supplied = Environment.GetEnvironmentVariable("YESHUA_TEST_SQL");
        Assert.False(string.IsNullOrWhiteSpace(supplied), "Configure YESHUA_TEST_SQL to run this isolated SQL probe.");
        var settings = new SqlConnectionStringBuilder(supplied) { InitialCatalog = "master" };
        var password = Environment.GetEnvironmentVariable("YESHUA_TEST_SQL_PASSWORD");
        if (!string.IsNullOrEmpty(password)) settings.Password = password;
        var database = "YESHUA_WALLET_PROBE_" + Guid.NewGuid().ToString("N");
        await using var admin = new SqlConnection(settings.ConnectionString); await admin.OpenAsync();
        await new SqlCommand($"CREATE DATABASE [{database}];", admin).ExecuteNonQueryAsync();
        var connection = new SqlConnectionStringBuilder(settings.ConnectionString) { InitialCatalog = database }.ConnectionString;
        UnitOfWork Work() => new(new SqlFactory(EnumSqlConections.SqlServer, connection));
        try
        {
            using (var work = Work())
                work.Execute(@"CREATE TABLE CarteiraCredito(Id varchar(32) PRIMARY KEY,Saldo decimal(18,4),TenantID int,UserId int,Deleted bit,Changed datetime,OperationalEntityId varchar(32));
                    CREATE TABLE MovimentoCredito(Id varchar(64) PRIMARY KEY,Tipo varchar(30),Referencia varchar(100),Quantidade decimal(18,4),SaldoApos decimal(18,4),CriadoEmUtc datetime,TenantID int,UserId int,Deleted bit,Changed datetime,OperationalEntityId varchar(32));
                    CREATE TABLE ContratacaoUso(Id varchar(64) PRIMARY KEY,Oferta varchar(100),Quantidade int,Creditos decimal(18,4),CriadaEmUtc datetime,TenantID int,UserId int,Deleted bit,Changed datetime,OperationalEntityId varchar(32));
                    CREATE TABLE DireitoUsoContratado(Id varchar(64) PRIMARY KEY,ResourceKey varchar(100),PeriodUntilUtc datetime NULL,GrantedUnits decimal(18,4),TenantID int,UserId int,Deleted bit,Changed datetime,OperationalEntityId varchar(32));
                    CREATE TABLE CobrancaCredito(Id varchar(64) PRIMARY KEY,Creditos decimal(18,4),Valor decimal(18,2),Status int,CriadaEmUtc datetime,VenceEmUtc datetime,TenantID int,Deleted bit);
                    CREATE TABLE yTenantApplication(Id int IDENTITY PRIMARY KEY,ApplicationKey varchar(100),ValidUntil datetime,TenantID int,UserId int,Deleted bit,Changed datetime,OperationalEntityId varchar(32));
                    CREATE TABLE yAuthorizationDefinition(ApplicationKey varchar(100),DefinitionKey varchar(100),Description nvarchar(500),DefinitionType varchar(30),Active bit);
                    INSERT INTO yAuthorizationDefinition VALUES('Clinica','clinica.access','{""Models"":1}','UsageRight',1),('Clinica','clinica.transcription','{""Models"":3}','UsageRight',1);");
            var addition = Guid.NewGuid().ToString("D");
            await Task.WhenAll(Enumerable.Range(0, 12).Select(_ => Task.Run(() =>
            {
                using var work = Work(); new FinanceiroRepository(work).AddWalletCredits(7, 12, addition, 50m);
            })));
            using (var work = Work())
            {
                var repository = new FinanceiroRepository(work);
                Assert.Equal(50m, repository.Read(7).Balance);
                Assert.Single(repository.Read(7).Movements);
                Assert.Empty(repository.Read(7).Charges);
                Assert.Throws<InvalidOperationException>(() => repository.AddWalletCredits(7, 12, addition, 100m));
                repository.AddWalletCredits(7, 12, Guid.NewGuid().ToString("D"), 500m);
                Assert.Equal(550m, repository.Read(7).Balance);
                Assert.Throws<ArgumentException>(() => repository.AddWalletCredits(7, 12, Guid.NewGuid().ToString("D"), -50m));
            }
            var allocation = Guid.NewGuid().ToString("D");
            await Task.WhenAll(Enumerable.Range(0, 12).Select(_ => Task.Run(() =>
            {
                using var work = Work(); new FinanceiroRepository(work).AllocateWalletCredits(7, 12, allocation, "clinica-periodo", 1);
            })));
            using (var work = Work())
            {
                var repository = new FinanceiroRepository(work);
                var snapshot = repository.Read(7);
                Assert.Equal(450m, snapshot.Balance);
                Assert.Equal(3, snapshot.Movements.Count);
                var clinic = Assert.Single(snapshot.Movements.Where(item => item.Servico == "clinica.access"));
                Assert.Equal(-100m, clinic.Quantidade); Assert.Equal(450m, clinic.SaldoApos);
                Assert.Contains("Clínica", clinic.Descricao); Assert.Contains("1 mês", clinic.Descricao);
                Assert.Equal(1, work.ExecuteScalar<int>("SELECT COUNT(*) FROM yTenantApplication WHERE TenantID=7;"));
                repository.AllocateWalletCredits(7, 12, Guid.NewGuid().ToString("D"), "transcricao-creditos", 2);
                snapshot = repository.Read(7);
                Assert.Equal(410m, snapshot.Balance);
                Assert.Equal(20m, Assert.Single(snapshot.Rights.Where(right => right.Resource == "clinica.transcription")).GrantedUnits);
                Assert.Contains(snapshot.Movements, item => item.Servico == "clinica.transcription" && item.Descricao.Contains("20 transcrições"));
                Assert.Throws<InvalidOperationException>(() => repository.AllocateWalletCredits(7, 12, Guid.NewGuid().ToString("D"), "clinica-periodo", 36));
                Assert.Equal(410m, repository.Read(7).Balance);
                repository.AddWalletCredits(8, 13, addition, 100m);
                Assert.Equal(100m, repository.Read(8).Balance); Assert.Equal(410m, repository.Read(7).Balance);
                work.Execute(@"INSERT INTO ContratacaoUso VALUES('legacy','transcricao-periodo',1,50,SYSUTCDATETIME(),7,12,0,SYSUTCDATETIME(),'legacy');
                    INSERT INTO MovimentoCredito VALUES('legacy','Contratacao','legacy',-50,360,SYSUTCDATETIME(),7,12,0,SYSUTCDATETIME(),'legacy');
                    UPDATE CarteiraCredito SET Saldo=360 WHERE TenantID=7;");
                var historic = Assert.Single(repository.Read(7).Movements.Where(item => item.Referencia == "legacy"));
                Assert.Equal("clinica.transcription", historic.Servico); Assert.Contains("1 mês", historic.Descricao);
            }
        }
        finally
        {
            Assert.StartsWith("YESHUA_WALLET_PROBE_", database);
            SqlConnection.ClearAllPools();
            await new SqlCommand($"ALTER DATABASE [{database}] SET SINGLE_USER WITH ROLLBACK IMMEDIATE; DROP DATABASE [{database}];", admin).ExecuteNonQueryAsync();
        }
    }
}
