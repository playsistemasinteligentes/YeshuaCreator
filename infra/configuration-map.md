# Yeshua configuration map

Este mapa registra como a configuracao esta sendo usada hoje e separa o que
parece ativo do que parece sobra historica.

## Regra adotada

- Desenvolvimento Windows: parametros publicos em appsettings e credenciais
  pelo JSON privado carregado por `tools/private/Use-YeshuaEnvironment.ps1`.
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

## Segredos De Implantacao

Padrao decidido em 2026-10-19, ainda pendente de implantacao geral: arquivos
privados fora do repositorio e das imagens, com permissoes/mounts somente para
os consumidores necessarios. Credenciais tecnicas podem ficar em texto nesses
arquivos; nao acrescentar cifra local generica nem uma chave de desbloqueio.
O Compose versionado guarda referencias, nao valores. Backup permanece cifrado.

O [primeiro passo](../docs/operational/PLANO_ETAPA_1_CENTRALIZACAO_CREDENCIAIS_YESHUA.md)
centraliza credenciais de implantacao em um unico arquivo por ambiente.
O caminho e formato hierarquico implementados no repositorio sao
`/root/YeshuaPrivate/production/credentials.json`, com secoes Shared e Apps.
O loader le esse arquivo no host e o Compose entrega somente as variaveis
necessarias a cada servico; nao montar o arquivo completo nos containers.
Subida, redeploy e restricao de acesso precisam passar antes da etapa de backup.

O loader comum le o JSON com validacao de campos/permissoes antes das operacoes
Docker, tanto no deploy geral quanto nos cinco deploys diretos e no Shared.
Nao gera chaves, nao grava o arquivo e nao usa module-auth.env ou
memorias-youtube.env como fallback. A captura inicial e explicita, separada do
deploy. O [roteiro operacional](private/README.md) descreve a transicao antes da
primeira publicacao desta versao. Aceite de producao ainda pendente.
O setup e unico para criar/reconstruir: reutiliza JSON valido, cria exemplo
restrito se ausente e bloqueia ate completar. So prepara diretorios ausentes,
sem alterar dono/modo dos dados existentes. Nao restaura SQL nem troca cofres.
A cifragem de dados/configuracao e as chaves persistentes existentes no Memorias
continuam intactas. Provisionamento/rotacao precisam de operacao explicita;
nao substituir automaticamente segredos de um ambiente ja existente.
Tokens/cofres por tenant nao sao configuracao estatica de implantacao; manter
seus formatos e a precedencia existente no Memorias.

Distincao esclarecida pelo usuario em 2026-10-19: configuracao do ambiente e
diferente de configuracao de integracao externa. Memorias/YouTube nao e excecao;
pertence a segunda categoria, sob responsabilidade do aplicativo.
Client ID, Client Secret, chave de protecao, configuracao OAuth e tokens
permanecem no aplicativo e em seus arquivos/cofres privados. Quando houver
bootstrap, ele fica em apps/Memorias/integracoes/youtube/bootstrap.json; preservar
cofre, precedencia e chaves existentes. SQL, RabbitMQ e JWT
compartilhados continuam no plano geral de infraestrutura. A mesma raiz privada
tera subareas por app e, quando aplicavel, tenant/titular/conexao, com IDs estaveis
e acesso por consumidor. Layouts atuais de cofre/arquivos ainda nao foram migrados.

A revisao do plano inclui SQL de cada app e da API operacional/MCP, RabbitMQ
.NET/Python, JWT, HMAC entre modulos e de upload Clinica, Grafana
e credenciais de testes. Credenciais de provedores externos de IA e OAuth/AES
YouTube sao integracoes/protecao dos dados do respectivo consumidor. Certificados,
tokens/cofres por tenant, SMTP de clientes e sessoes dos agentes permanecem
artefatos gerenciados restritos, nao variaveis globais de todos os containers.
Studios Central, APS.ADM e Fiscal agora aplicam os overrides SQL de leitura/escrita.
setup-cert.sh tambem carrega a configuracao para interpolar o Compose Shared,
mesmo ao subir somente nginx; suas rotas publicas nao foram alteradas.

## Storage

O inventario de areas e a proposta de vinculo com politicas de backup estao em
[MAPA_DADOS_AREAS_E_BACKUP_YESHUA.md](../docs/operational/MAPA_DADOS_AREAS_E_BACKUP_YESHUA.md).
As chaves abaixo resolvem storage; ainda nao ativam backup nem comprovam restore.
Nenhuma nova chave ou sintaxe de DSL de backup foi implementada.

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

O deploy publico atual e orquestrado por `infra/docker/deploy.sh` e usa:

- `infra/Central/DockerCompose` para Front compartilhado, API, Worker e Migration.
- `infra/Clinica/DockerCompose` para API, Worker e Migration.
- `infra/APS.ADM/DockerCompose` para API, Worker e Migration.
- `infra/Fiscal/DockerCompose` para API, Worker e Migration.

Os aplicativos compartilham `sqlserver`, `redis`, `rabbitmq`, `nginx` e a rede
`yeshua-net`, mas cada aplicativo possui banco proprio.

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
