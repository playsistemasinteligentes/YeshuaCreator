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
| `MyConfig:ReadConectionString` | API, Worker, Studio appsettings | `GS.I.MYC.ReadConectionString` cria `SqlFactory` | Manter |
| `MyConfig:WriteConectionString` | API, Worker, Studio appsettings | Mantida pelo contrato de leitura/escrita; pode apontar para o mesmo banco da leitura | Manter |
| `MYCONFIG__READCONECTIONSTRING` | Docker compose, `GS` | Override real da conexao de leitura | Manter |
| `MYCONFIG__WRITECONECTIONSTRING` | Docker compose, `GS` | Override real da conexao de escrita | Manter por enquanto |
| `MyConfig:MaxConcurrentConnections` | appsettings da matriz antiga API/Front | Kestrel da API/Front globais antigos | Manter enquanto esses hosts existirem |
| `MyConfig:MaxConcurrentUpgradedConnections` | appsettings da matriz antiga API/Front | Kestrel da API/Front globais antigos | Manter enquanto esses hosts existirem |
| `MyConfig:MaxRequestBodySize` | appsettings da matriz antiga API/Front | Kestrel da API/Front globais antigos | Manter enquanto esses hosts existirem |
| `MyConfig:CorsOrigins` | appsettings da matriz antiga API | CORS da API global antiga | Manter enquanto esse host existir |
| `MyConfig:xReadConectionString` | appsettings antigos | Nao existe no modelo `MyConfig` e nao ha leitura encontrada | Removido dos artefatos ativos |
| `MyConfig:xWriteConectionString` | appsettings antigos | Nao existe no modelo `MyConfig` e nao ha leitura encontrada | Removido dos artefatos ativos |
| `MyConfig:HttpIPListen` | appsettings antigos | Nao foi encontrado uso no Kestrel atual | Removido dos artefatos ativos |
| `MyConfig:HttpPortListen` | appsettings antigos | Nao foi encontrado uso no Kestrel atual | Removido dos artefatos ativos |
| `MyConfig:HttpsIPListen` | appsettings antigos | Nao foi encontrado uso no Kestrel atual | Removido dos artefatos ativos |
| `MyConfig:HttpsPortListen` | appsettings antigos | Nao foi encontrado uso no Kestrel atual | Removido dos artefatos ativos |
| `MyConfig:HttpsPathCertificado` | appsettings antigos | Nao foi encontrado uso no Kestrel atual | Removido dos artefatos ativos |
| `MyConfig:HttpssenhaCertificado` | appsettings antigos | Nao foi encontrado uso no Kestrel atual | Removido dos artefatos ativos |
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
| `Storage:Providers:S3:*` | appsettings/Compose antigos | `S3StorageProvider` esta vazio e nao registrado | Removido dos artefatos ativos; roadmap futuro |

## RabbitMQ

| Chave | Onde aparece | Uso atual | Status |
| --- | --- | --- | --- |
| `RabbitMq:HostName` | Worker appsettings, Docker | `RabbitMqConnectionManager` e topology initializer | Manter |
| `RabbitMq:Port` | Worker appsettings, Docker | `RabbitMqConnectionManager` e topology initializer | Manter |
| `RabbitMq:Username` / `RabbitMq:UserName` | Worker appsettings, Docker | Binder alimenta `UserName` | Manter, padronizar para `UserName` depois |
| `RabbitMq:Password` | Worker appsettings, Docker | `RabbitMqConnectionManager` e topology initializer | Manter |
| `RabbitMq:VirtualHost` | Worker appsettings, Docker | `RabbitMqConnectionManager` e topology initializer | Manter |
| `RabbitMq:Exchange` | Compose antigo | Nao existe na classe de options usada; topology vem do codigo gerado | Removido dos artefatos ativos |
| `RabbitMq:Queue` | Compose antigo | Nao existe na classe de options usada; topology vem do codigo gerado | Removido dos artefatos ativos |
| `RabbitMq:RoutingKey` | Compose antigo | Nao existe na classe de options usada; topology vem do codigo gerado | Removido dos artefatos ativos |
| `MyConfig:RabbitMQ` | classe `MyConfig` antiga | Nao foi encontrado uso | Removido |

## Docker e infra

| Variavel | Servico | Uso atual | Status |
| --- | --- | --- | --- |
| `ASPNETCORE_URLS` | api, worker, front | Runtime ASP.NET | Manter |
| `ASPNETCORE_ENVIRONMENT` | api, worker, front | Runtime ASP.NET | Manter |
| `ConnectionStrings__Default` | Compose antigo de app | Nao ha `GetConnectionString("Default")` encontrado | Removido dos Compose ativos |
| `Redis__Host` | Compose antigo de app | Nao ha cliente Redis/configuracao encontrada | Removido dos Compose ativos |
| `SA__PASSWORD` | Compose antigo de app | Nao ha leitura C# encontrada | Removido dos Compose ativos |
| `MSSQL_SA_PASSWORD` | sql01 | Imagem SQL Server | Manter como referencia de segredo |
| `ACCEPT_EULA` | sqlserver | Imagem SQL Server | Manter |
| `MSSQL_PID` | sqlserver | Imagem SQL Server | Manter |
| `RABBITMQ_DEFAULT_USER` | rabbitmq | Imagem RabbitMQ | Manter |
| `RABBITMQ_DEFAULT_PASS` | rabbitmq | Imagem RabbitMQ | Manter |
| `CELERY_BROKER_URL` | ai-worker, ai-summarizer | Python Celery/messaging | Manter |
| `STORAGE_ROOT` | ai-worker | O worker baixa o audio pela URL e nao usa o volume diretamente | Removido do manifesto |
| `SUMMARIZER_MODEL` | ai-summarizer | Python summarizer | Manter |
| `SUMMARIZER_DEVICE` | ai-summarizer | Python summarizer | Manter |

O deploy publico atual usa `infra/Clinica/DockerCompose` e
`infra/Fiscal.MDFe/DockerCompose`, orquestrados por `infra/docker/deploy.sh`.
Clinica e MDF-e possuem connection strings distintas, enquanto `sqlserver` e a
persistencia fisica do SQL sao compartilhados pelo ambiente.

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
