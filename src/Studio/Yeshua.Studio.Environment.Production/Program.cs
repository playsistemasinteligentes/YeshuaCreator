using Dominio.Schemas;

var solutionDirectory = FindSolutionDirectory();

// pendencia: definir a provisao e a rotacao dos valores referenciados em .env.example.
// observacao: nenhum valor de senha ou connection string deve entrar nesta declaracao.
// pendencia: criar os catalogos CLINICA e MDFE de forma idempotente antes da primeira migration.
// observacao: servidores que ja possuem os catalogos continuam usando os dados persistidos atuais.
new DeploymentEnvironmentSchema("Production", solutionDirectory)
    .Domain("playsis.com.br")
    .IncludeApplication("Clinica", "Fiscal.MDFe")
    .ProvideResource("sql01", provider => provider
        .FromImage("mcr.microsoft.com/mssql/server:2022-latest")
        .Configure("ACCEPT_EULA", "Y")
        .Configure("MSSQL_PID", "Express")
        .BindPersistence("sql-data", "/root/YeshuaDB/persistent/sql")
        .Publish(1433, 1433))
    .ProvideResource("redis01", provider => provider
        .FromImage("redis:7-alpine")
        .Publish(6379, 6379))
    .ProvideResource("rabbit01", provider => provider
        .FromImage("rabbitmq:3-management-alpine")
        .Publish(5672, 5672)
        .Publish(15672, 15672))
    .ProvideResource("storage01", provider => provider
        .BindPersistence("application-storage", "/root/YeshuaStorage"))
    .MapStorage("storage01", "/volatile/", "/storage/volatile/")
    .Generate();

Console.WriteLine("Manifestos do ambiente Production gerados.");

static string FindSolutionDirectory()
{
    var directory = new DirectoryInfo(AppContext.BaseDirectory);
    while (directory is not null)
    {
        if (File.Exists(Path.Combine(directory.FullName, "YeshuaCreator.sln")))
            return directory.FullName;
        directory = directory.Parent;
    }

    throw new DirectoryNotFoundException("Nao foi possivel localizar YeshuaCreator.sln.");
}
