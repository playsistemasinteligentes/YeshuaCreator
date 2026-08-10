using Dominio.Migration;
using Dominio.Schemas;
using Dominio.Deployment;
using Dominio.Schemas.CQRS;
using Infra;
using Migration.Interfaces;
using System.Data;

Console.WriteLine("Begin");

var deployment = new DeploymentSchema(GS.I.MYC.Project, GS.I.MYC.Source)
    .AddResource("sqlserver", DeploymentResourceKind.DatabaseServer, resource => resource
        .IdentifiedBy("sql01")
        .Configure("Engine", "SqlServer")
        .Secret("MSSQL_SA_PASSWORD", "sql01-sa-password")
        .Persistent("sql-data", "/var/opt/mssql"))
    .AddResource("database", DeploymentResourceKind.DatabaseCatalog, resource => resource
        .HostedBy("sqlserver")
        .Configure("Catalog", "CLINICA"))
    .AddResource("redis", DeploymentResourceKind.Cache, resource => resource
        .IdentifiedBy("redis01"))
    .AddResource("rabbitmq", DeploymentResourceKind.MessageBroker, resource => resource
        .IdentifiedBy("rabbit01")
        .Secret("RABBITMQ_DEFAULT_USER", "rabbit01-username")
        .Secret("RABBITMQ_DEFAULT_PASS", "rabbit01-password"))
    .AddResource("storage", DeploymentResourceKind.Storage, resource => resource
        .IdentifiedBy("storage01")
        .Persistent("application-storage", "/storage"))
    .AddWorkload("api", workload => workload
        .FromProject("src/CQRS/Infrastructure/Yeshua.Clinica.CQRS.Infrastructure.Api/Yeshua.Clinica.CQRS.Infrastructure.Api.csproj")
        .Requires("database", "redis", "storage")
        .Configure("ASPNETCORE_ENVIRONMENT", "Production")
        .Configure("Redis__Host", "redis01")
        .Configure("Storage__Providers__Disk__Root", "/storage")
        .Configure("Storage__Providers__Disk__BaseUrl", "https://playsis.com.br")
        .Configure("Storage__Locations__volatile/ia/transcriptions/input", "Disk")
        .Configure("Storage__Locations__volatile/ia/transcriptions/output", "Disk")
        .Configure("Storage__Locations__volatile/reports/input", "Disk")
        .Configure("Storage__Locations__volatile/reports/output", "Disk")
        .Configure("Storage__Locations__persistent/docs/input", "Disk")
        .Configure("Storage__Locations__persistent/docs/output", "Disk")
        .Secret("MYCONFIG__READCONECTIONSTRING", "clinica-database-read-connection")
        .Secret("MYCONFIG__WRITECONECTIONSTRING", "clinica-database-write-connection")
        .Mount("storage", "/storage")
        .ExposeHttp("http", 7214, "/yapi")
        .TcpHealthCheck("http"))
    .AddWorkload("front", workload => workload
        .FromProject("src/CQRS/Infrastructure/Yeshua.Clinica.CQRS.Infrastructure.Front/Yeshua.Clinica.CQRS.Infrastructure.Front.csproj")
        .Requires("api")
        .Configure("ASPNETCORE_ENVIRONMENT", "Production")
        .ExposeHttp("http", 8080, "/")
        .TcpHealthCheck("http")
        .Scale(2))
    .AddWorkload("worker", workload => workload
        .FromProject("src/CQRS/Infrastructure/Yeshua.Clinica.CQRS.Infrastructure.Worker/Yeshua.Clinica.CQRS.Infrastructure.Worker.csproj")
        .Requires("database", "redis", "rabbitmq", "storage")
        .Configure("ASPNETCORE_ENVIRONMENT", "Production")
        .Configure("Redis__Host", "redis01")
        .Configure("Storage__Providers__Disk__Root", "/storage")
        .Configure("Storage__Providers__Disk__BaseUrl", "https://playsis.com.br")
        .Configure("Storage__Locations__volatile/ia/transcriptions/input", "Disk")
        .Configure("Storage__Locations__volatile/ia/transcriptions/output", "Disk")
        .Configure("Storage__Locations__volatile/reports/input", "Disk")
        .Configure("Storage__Locations__volatile/reports/output", "Disk")
        .Configure("Storage__Locations__persistent/docs/input", "Disk")
        .Configure("Storage__Locations__persistent/docs/output", "Disk")
        .Configure("RabbitMq__HostName", "rabbit01")
        .Configure("RabbitMq__Port", "5672")
        .Configure("RabbitMq__VirtualHost", "/")
        .Configure("RabbitMq__Exchange", "kiwi.exchange")
        .Configure("RabbitMq__Queue", "kiwi.queue")
        .Configure("RabbitMq__RoutingKey", "kiwi.routing")
        .Secret("MYCONFIG__READCONECTIONSTRING", "clinica-database-read-connection")
        .Secret("MYCONFIG__WRITECONECTIONSTRING", "clinica-database-write-connection")
        .Secret("RabbitMq__Username", "rabbit01-username")
        .Secret("RabbitMq__Password", "rabbit01-password")
        .Mount("storage", "/storage")
        .ExposeHttp("http", 7215, "/yworker")
        .TcpHealthCheck("http"))
    .AddWorkload("migration", workload => workload
        .FromProject(
            "src/Studio/Yeshua.Studio.AppClinicas/Yeshua.Studio.AppClinicas.csproj",
            DotNetRuntimeKind.Runtime)
        .Requires("database")
        .Secret("MYCONFIG__READCONECTIONSTRING", "clinica-database-read-connection")
        .Secret("MYCONFIG__WRITECONECTIONSTRING", "clinica-database-write-connection")
        .RunOnce())
    .AddWorkload("ai-worker", workload => workload
        .FromBuildContext("infra/docker/ai-worker")
        .ScaffoldDockerfile(DockerfileTemplate.PythonWorker(template => template
            .PythonVersion("3.11")
            .InstallSystemPackages("ffmpeg", "git", "build-essential")
            .InstallRequirements("requirements.txt")
            .CopyDirectory("app")
            .Command(
                "celery", "-A", "app.celery_app", "worker",
                "-Q", "audio.transcribe.outbox", "--concurrency=1", "--loglevel=info")))
        .Requires("rabbitmq")
        .Secret("CELERY_BROKER_URL", "rabbit01-celery-url")
        .Consumes("audio.transcribe.outbox")
        .Produces("audio.transcribed.inbox")
        .Resources(cpuRequest: "500m", memoryRequest: "2Gi", cpuLimit: "4", memoryLimit: "8Gi"))
    .AddWorkload("ai-summarizer", workload => workload
        .FromBuildContext("infra/docker/ai-summarizer")
        .ScaffoldDockerfile(DockerfileTemplate.PythonWorker(template => template
            .PythonVersion("3.11")
            .InstallSystemPackages("git", "build-essential")
            .InstallRequirements("requirements.txt")
            .CopyDirectory("app")
            .Command(
                "celery", "-A", "app.celery_app", "worker",
                "-Q", "text.summarize.outbox", "--concurrency=1", "--loglevel=info")))
        .Requires("rabbitmq")
        .Configure("SUMMARIZER_MODEL", "Qwen/Qwen2.5-0.5B-Instruct")
        .Configure("SUMMARIZER_DEVICE", "cpu")
        .Secret("CELERY_BROKER_URL", "rabbit01-celery-url")
        .Consumes("text.summarize.outbox")
        .Produces("text.summarized.inbox")
        .Resources(cpuRequest: "500m", memoryRequest: "2Gi", cpuLimit: "4", memoryLimit: "8Gi"));

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
            "Yeshua.Studio.AppClinicas"))
        .ADDSchema(deployment)
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
        migration.ADDSchema(deployment);
        migration.ADDSchema(new SqlServerSchema(unitOfWork));
        migration.Build().Run();
    }
}
