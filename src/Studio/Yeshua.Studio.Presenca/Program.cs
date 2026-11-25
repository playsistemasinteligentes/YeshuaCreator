using Dominio.Migration;
using Dominio.Schemas.CQRS;
using Dominio.Schemas;
using Infra;

if (args.Length == 2 && args[0] == "--codegen-only")
{
    new MigrationBuilder()
        .ADDSchema(new CSharpCQRS("Presenca", Path.GetFullPath(args[1]), "Yeshua.Studio.Presenca"))
        .Build().Run();
    return;
}

if (args.Length == 1 && args[0] == "--database-only")
{
    var connection = Environment.GetEnvironmentVariable("MYCONFIG__WRITECONECTIONSTRING");
    if (string.IsNullOrWhiteSpace(connection))
        throw new ArgumentException("Conexão explícita do Presenca obrigatória.");

    var centralConnection = Environment.GetEnvironmentVariable("MYCONFIG__CENTRALAUTHORIZATIONCONECTIONSTRING");
    if (string.IsNullOrWhiteSpace(centralConnection))
        throw new ArgumentException("Conexão de autorização da Central obrigatória para instalar o Presenca.");

    using var sql = new SqlFactory(EnumSqlConections.SqlServer, connection).SqlConnection();
    using var work = new UnitOfWork(sql, true);
    using var centralSql = new SqlFactory(EnumSqlConections.SqlServer, centralConnection).SqlConnection();
    using var centralWork = new UnitOfWork(centralSql, true);
    new MigrationBuilder()
        .ADDSchema(new SqlServerSchema(work, "Presenca"))
        .ADDSchema(new CentralAuthorizationSchema("Presenca", centralWork))
        .Build().Run();
    return;
}

throw new ArgumentException("Use --codegen-only <repository-root> ou --database-only (conexão explícita).");
