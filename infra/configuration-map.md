# Yeshua configuration map

Este mapa registra como a configuracao esta sendo usada hoje e separa o que
parece ativo do que parece sobra historica.

## Regra adotada

- Desenvolvimento Windows: `appsettings.json` e arquivos locais de appsettings.
- Deploy Linux/Docker: variaveis de ambiente no formato `Section__Key`.
- Banco alvo: definido diretamente por `MyConfig:ReadConectionString` e
  `MyConfig:WriteConectionString`, sem condicional por ambiente.
- Testes integrados: secao geral `TestSettings` em appsettings, com override por
  `TESTSETTINGS__...` no deploy.

## API e Worker

| Chave | Onde aparece | Uso atual | Status |
| --- | --- | --- | --- |
| `MyConfig:ReadConectionString` | API, Worker, Front, Studio appsettings | `GS.I.MYC.ReadConectionString` cria `SqlFactory` | Manter |
| `MyConfig:WriteConectionString` | API, Worker, Front, Studio appsettings | Mantida pelo contrato de leitura/escrita; pode apontar para o mesmo banco da leitura | Manter |
| `MYCONFIG__READCONECTIONSTRING` | Docker compose, `GS` | Override real da conexao de leitura | Manter |
| `MYCONFIG__WRITECONECTIONSTRING` | Docker compose, `GS` | Override real da conexao de escrita | Manter por enquanto |
| `MyConfig:MaxConcurrentConnections` | appsettings API/Worker/Front | Kestrel da API/Front | Manter |
| `MyConfig:MaxConcurrentUpgradedConnections` | appsettings API/Worker/Front | Kestrel da API/Front | Manter |
| `MyConfig:MaxRequestBodySize` | appsettings API/Worker/Front | Kestrel da API/Front | Manter |
| `MyConfig:CorsOrigins` | appsettings API/Front | CORS da API | Manter |
| `MyConfig:xReadConectionString` | appsettings | Nao existe no modelo `MyConfig` e nao ha leitura encontrada | Candidato a remover |
| `MyConfig:xWriteConectionString` | appsettings | Nao existe no modelo `MyConfig` e nao ha leitura encontrada | Candidato a remover |
| `MyConfig:HttpIPListen` | appsettings | Nao foi encontrado uso no Kestrel atual | Candidato a remover ou implementar |
| `MyConfig:HttpPortListen` | appsettings | Nao foi encontrado uso no Kestrel atual | Candidato a remover ou implementar |
| `MyConfig:HttpsIPListen` | appsettings | Nao foi encontrado uso no Kestrel atual | Candidato a remover ou implementar |
| `MyConfig:HttpsPortListen` | appsettings | Nao foi encontrado uso no Kestrel atual | Candidato a remover ou implementar |
| `MyConfig:HttpsPathCertificado` | appsettings | Nao foi encontrado uso no Kestrel atual | Candidato a remover ou implementar |
| `MyConfig:HttpssenhaCertificado` | appsettings | Nao foi encontrado uso no Kestrel atual | Candidato a remover ou implementar |
| `JwtSettings:SecretKey` | `Program.cs`, default em `JwtSettings` | JWT da API | Manter, mas configurar explicitamente em deploy |
| `JwtSettings:ExpirationMinutes` | `Program.cs`, default em `JwtSettings` | JWT da API | Manter |

Observacao: `GS` hoje le apenas `appsettings.json` do diretorio de saida e aplica
override manual para duas variaveis `MYCONFIG__...`. Ele nao mescla
`appsettings.Development.json`. Ja `builder.Configuration` segue o pipeline
padrao do ASP.NET.

## Storage

| Chave | Onde aparece | Uso atual | Status |
| --- | --- | --- | --- |
| `Storage:Providers:Disk:Root` | API/Worker appsettings, Docker | `DiskStorageProvider` | Manter |
| `Storage:Providers:Disk:BaseUrl` | API/Worker appsettings, Docker | `DiskStorageProvider.GetBaseUrl` | Manter |
| `Storage:Locations:*` | API/Worker appsettings, Docker | `StorageResolver` escolhe provider por prefixo | Manter |
| `Storage:Providers:S3:*` | API/Worker appsettings, Docker | `S3StorageProvider` esta vazio e nao registrado | Candidato a remover ou deixar como roadmap |

## RabbitMQ

| Chave | Onde aparece | Uso atual | Status |
| --- | --- | --- | --- |
| `RabbitMq:HostName` | Worker appsettings, Docker | `RabbitMqConnectionManager` e topology initializer | Manter |
| `RabbitMq:Port` | Worker appsettings, Docker | `RabbitMqConnectionManager` e topology initializer | Manter |
| `RabbitMq:Username` / `RabbitMq:UserName` | Worker appsettings, Docker | Binder alimenta `UserName` | Manter, padronizar para `UserName` depois |
| `RabbitMq:Password` | Worker appsettings, Docker | `RabbitMqConnectionManager` e topology initializer | Manter |
| `RabbitMq:VirtualHost` | Worker appsettings, Docker | `RabbitMqConnectionManager` e topology initializer | Manter |
| `RabbitMq:Exchange` | Worker appsettings, Docker | Nao existe na classe de options usada | Candidato a remover ou implementar |
| `RabbitMq:Queue` | Worker appsettings, Docker | Nao existe na classe de options usada | Candidato a remover ou implementar |
| `RabbitMq:RoutingKey` | Worker appsettings, Docker | Nao existe na classe de options usada | Candidato a remover ou implementar |
| `MyConfig:RabbitMQ` | classe `MyConfig` | Nao foi encontrado uso | Candidato a remover |

## Docker e infra

| Variavel | Servico | Uso atual | Status |
| --- | --- | --- | --- |
| `ASPNETCORE_URLS` | api, worker, front | Runtime ASP.NET | Manter |
| `ASPNETCORE_ENVIRONMENT` | api, worker, front | Runtime ASP.NET | Manter |
| `ConnectionStrings__Default` | api, worker, migration | Nao ha `GetConnectionString("Default")` encontrado | Candidato a remover |
| `Redis__Host` | api, worker | Nao ha cliente Redis/configuracao encontrada | Candidato a remover |
| `SA__PASSWORD` | api, front, migration | Nao ha leitura C# encontrada | Candidato a remover |
| `SA_PASSWORD` | sqlserver | Imagem SQL Server | Manter |
| `ACCEPT_EULA` | sqlserver | Imagem SQL Server | Manter |
| `MSSQL_PID` | sqlserver | Imagem SQL Server | Manter |
| `RABBITMQ_DEFAULT_USER` | rabbitmq | Imagem RabbitMQ | Manter |
| `RABBITMQ_DEFAULT_PASS` | rabbitmq | Imagem RabbitMQ | Manter |
| `CELERY_BROKER_URL` | ai-worker, ai-summarizer | Python Celery/messaging | Manter |
| `STORAGE_ROOT` | ai-worker | Python worker | Manter |
| `SUMMARIZER_MODEL` | ai-summarizer | Python summarizer | Manter |
| `SUMMARIZER_DEVICE` | ai-summarizer | Python summarizer | Manter |

## Testes integrados

Os testes integrados de API executam sem paralelismo por `AssemblyInfo.cs` e
`xunit.runner.json`, porque batem em API e banco reais.

| Chave | Origem | Uso atual | Status |
| --- | --- | --- | --- |
| `TestSettings:BaseUrl` | `tests/CQRS/Yeshua.CQRS.Tests.Integration.Api/appsettings*.json` | URL alvo dos testes | Manter |
| `TestSettings:LoginPath` | appsettings/env | Endpoint de login, padrao `/yapi/login` | Manter |
| `TestSettings:Login` | appsettings/env | Login real para autenticar nos testes | Manter |
| `TestSettings:Password` | appsettings/env | Senha real para autenticar nos testes | Manter |
| `TestSettings:TimeoutSeconds` | appsettings/env | Timeout do `HttpClient` | Manter |
| `TESTSETTINGS__BASEURL` | deploy/test runner | Override de `TestSettings:BaseUrl` | Manter |
| `TESTSETTINGS__LOGIN` | deploy/test runner | Override de `TestSettings:Login` | Manter |
| `TESTSETTINGS__PASSWORD` | deploy/test runner | Override de `TestSettings:Password` | Manter |
| `TESTSETTINGS__LOGINPATH` | deploy/test runner | Override de `TestSettings:LoginPath` | Manter |
| `TESTSETTINGS__TIMEOUTSECONDS` | deploy/test runner | Override de `TestSettings:TimeoutSeconds` | Manter |
| `IntegrationApi:*` | legado do primeiro corte dos testes | Ainda aceito por compatibilidade temporaria | Remover depois da transicao |
| `INTEGRATIONAPI__*` | legado do primeiro corte dos testes | Ainda aceito por compatibilidade temporaria | Remover depois da transicao |
| `YESHUA_API_*` | legado do primeiro corte dos testes | Ainda aceito por compatibilidade | Remover depois da transicao |
