# Etapa 1: Centralizacao Das Credenciais De Implantacao

Data: 2026-10-19.

Revisao 4: separar configuracao do ambiente de configuracao de integracao
externa. Memorias nao e excecao: YouTube pertence a segunda categoria.
Estrutura hierarquica do arquivo e da raiz privada proposta antes da implementacao.

Status: implementacao no repositorio e testes locais adicionados. O
[roteiro operacional](../../infra/private/README.md) registra o comportamento
efetivo e a transicao. Valores locais existentes foram preservados em arquivo
restrito fora do repositorio. Nenhum arquivo privado foi criado na VPS, deploy
executado ou permissao de producao testada. A implantacao depende da captura
explicita dos valores atuais antes de publicar a versao nova.

O inventario abaixo descreve a situacao levantada antes da implementacao.
Permanece pendente o aceite Linux/Docker. O usuario retirou a migracao de
certificados fiscais antigos do escopo; a preservacao exigida nesta transicao
e a configuracao/cofre YouTube. Backup e rotacao nao foram implementados.
Setup unico para criar/reconstruir foi implementado sem modo de restauracao;
o roteiro operacional prevalece sobre a sequencia proposta no inventario inicial.

## 1. Entrega E Limites

Primeiro centralizar as credenciais de implantacao, retirar seus valores dos
fontes/configuracoes versionados e comprovar acesso restrito e funcionamento
dos deploys. Somente depois do aceite retomar o planejamento de backup.

Reutilizar o loader e as variaveis de ambiente existentes. Sem novo servico,
cofre remoto, biblioteca de secrets, DSL ou consulta adicional no aplicativo.
Sem nova criptografia local obrigatoria: a protecao inicial e de acesso.

Fora desta etapa: rotinas/destino de backup, Restic, agendamento, reestruturacao
ou troca de bancos, migrations de negocio, limpeza de containers/volumes e rotacao de
credenciais. A criptografia/cofre existentes do Memorias permanecem intactos.

## 2. Arquivo Central E Quem Le

Local proposto para o ambiente publicado:

```text
/root/YeshuaPrivate/production/credentials.json
```

Um arquivo por ambiente, fora do repositorio, do contexto de build, das imagens,
do storage publico e da arvore de dados SQL. A separacao da arvore SQL evita
que o chown/chmod recursivo do bootstrap atual altere sua protecao.

- Diretorios privados: root:root, modo 0700.
- Arquivo: root:root, modo 0600, criado desde o inicio com umask 077.
- Conferir tambem ancestrais, ACLs, links e quem pode substituir arquivo/pasta.
- Rejeitar links simbolicos e permissoes/proprietario inesperados antes da leitura.
- Nao aplicar chmod/chown recursivo em SQL, storage ou outros dados existentes.

Esse dono/modo vale para o arquivo de ambiente e seus diretorios administrativos.
Subdiretorios de dados privados escritos por aplicativos devem ter dono/UID e
modos compativeis com os respectivos processos, sem dar a eles acesso ao JSON
geral. O Docker monta somente o subdiretorio autorizado de cada consumidor.

### 2.1 Duas Categorias, Uma Raiz Privada

Configuracao do ambiente: conexoes SQL, autenticacao da infraestrutura e
chaves tecnicas do ecossistema. Um arquivo por ambiente, com secoes Shared e
Apps/<Aplicativo>. Central significa centralizado, nao o aplicativo Central.

Configuracao de integracao/cliente: OAuth YouTube, conexoes de canais, SMTP
de tenant e certificados fiscais. Pertence ao aplicativo e, quando aplicavel,
ao tenant/titular/conexao. Vive na mesma raiz privada, em subdiretorios proprios,
nao misturada ao arquivo de ambiente nem versionada junto aos fontes.

Estrutura alvo proposta, ainda sem migracao dos arquivos atuais:

```text
/root/YeshuaPrivate/production/
  credentials.json
  shared/
    OperationalAgent/integracoes/
  apps/
    Central/
    Clinica/
    APS.ADM/
    Memorias/
      integracoes/youtube/configuracao/
      tenants/<tenantId>/integracoes/youtube/conexoes/<conexaoId>/
    Fiscal/
      tenants/<tenantId>/titulares/<documento>/certificados/<thumbprint>/
        certificado.pfx
        senha.secret
```

Essa e organizacao por proprietario/finalidade, nao uma nova camada de runtime.
Subpastas aparecem somente quando houver dados; nao criar esqueletos vazios
por tenant. Usar identidade estavel do aplicativo e IDs de tenant/conexao.
Para titular fiscal, reutilizar o documento normalizado ja registrado, sem
inventar novo cadastro. Nomes de pessoas/empresas nao definem caminhos.

Espelhar o nome logico usado por Studio e infra, nao toda a arvore src/CQRS ou
o namespace dos projetos: uma refatoracao de fonte nao deve deslocar dados
persistentes. A ligacao de Clinica com Yeshua.Studio.AppClinicas e dos demais
apps com seus Studios deve ser explicita na configuracao versionada do deploy,
sem descobrir diretorios dinamicamente nem deduzir nomes por reflection.

### 2.2 Estrutura Proposta Do Arquivo Unico

JSON e uma proposta de formato para suportar hierarquia real e parsers normais,
em lugar das atribuicoes Bash planas do desenho anterior. Exemplo somente de
estrutura, sem credenciais reais:

```json
{
  "Shared": {
    "SqlServer": { "AdminPassword": "<segredo>" },
    "RabbitMq": { "UserName": "<usuario>", "Password": "<segredo>" },
    "Jwt": { "SecretKey": "<segredo>" }
  },
  "Apps": {
    "Memorias": {
      "MyConfig": {
        "ReadConectionString": "<conexao>",
        "WriteConectionString": "<conexao>"
      }
    },
    "Fiscal": {
      "MyConfig": {
        "ReadConectionString": "<conexao>",
        "WriteConectionString": "<conexao>"
      }
    }
  }
}
```

Expandir a mesma estrutura aos demais consumidores inventariados; nao criar
um formato diferente por app. Campos compartilhados ficam em Shared, campos
de uso exclusivo em Apps/<Aplicativo>. O nome de uma secao organiza propriedade,
nao cria usuario/permissao SQL novo. Publicacao continua resolvendo conexoes e
fornecendo os contratos MYCONFIG__..., JwtSettings__... e RabbitMq__... atuais.

O loader existente tera que usar um parser JSON padrao, sem source/eval do
conteudo nem montagem de comandos com os valores. Confirmar a dependencia no
host Linux e o importador PowerShell antes de executar a troca de formato.
As variaveis da secao 8.1.1 passam a ser o contrato intermediario de saida do
loader para Compose, nao o formato nem uma segunda copia de arquivo de senhas.

### 2.3 Dados Existentes E Isolamento

A arvore acima nao descreve os caminhos atuais dos cofres Memorias. Eles usam
scope codificado e arquivos com contratos criptograficos existentes. Planejar
o mapeamento antes de alterar paths; preservar ProcessingScope, chaves, formatos
e identidades de tenant/conexao. Reorganizar raiz nao autoriza recriar o cofre.

Banco e payloads de certificado Fiscal possuem referencias aos paths atuais.
Qualquer mudanca deve mover somente os arquivos identificados, validar pares
PFX/senha e atualizar referencias pelo caminho do aplicativo, com retorno previsto.
Sem rename/move recursivo geral, perda de arquivos ou geracao de chaves.

O tenant deve vir do contexto autenticado, nao de um path enviado pelo cliente.
Validar os segmentos e confirmar que o caminho resolvido fica na raiz permitida.
Ter uma pasta chamada privado ou tenant nao concede isolamento: exigir permissoes,
binds por consumidor e testes de acesso negado entre aplicativos/tenants.

O padrao inicial corresponde ao deploy Linux atual, executado por root. Se
futuramente houver usuario de deploy dedicado, ajustar propriedade e testes
explicitamente; nao ampliar leitura para todos apenas para fazer funcionar.

```text
Arquivo privado no host
    -> loader comum do deploy le e valida
    -> Compose recebe variaveis para interpolacao
    -> cada servico recebe somente suas configuracoes necessarias
    -> aplicativo usa os contratos de configuracao atuais
```

O container nao precisa montar nem ler o arquivo central inteiro. Nao usar
esse arquivo como env_file de todos os servicos: isso distribuiria todos os
segredos para todos. Usar referencias explicitas em environment, por servico.

Root e administradores do Docker continuam podendo acessar variaveis dos
containers. A restricao protege contra usuarios/processos sem esse privilegio;
nao e uma promessa de segredo contra o administrador do proprio servidor.

## 3. O Que Vai Para O Arquivo

| Familia | Consumidores a conferir |
| --- | --- |
| Usuario/senha SQL | SQL Shared, migrations/Studios, APIs, Workers e servicos operacionais que usam SQL |
| Usuario/senha RabbitMQ | Broker, Workers e processadores que realmente usam a fila |
| Chave JWT | APIs que emitem/validam tokens, preservando a compatibilidade atual |
| Chave HMAC de upload da Clinica | Geracao e validacao de tokens de upload na API Clinica |
| YESHUA_MODULE_SHARED_KEY | Comunicacao autenticada entre modulos |
| Senha administrativa Grafana | Servico Grafana |

Os nomes existentes de variaveis devem ser reaproveitados. Completar o esquema
apenas onde os valores ainda sao literais. Nomes de banco, hosts, portas,
paths, URLs e opcoes nao secretas continuam em deploy.env/configuracao normal.
Nao criar senha por app ou mudar a topologia de autenticacao nesta entrega.

O arquivo centraliza credenciais estaticas de implantacao, nao dados de negocio
nem tokens OAuth atualizados por tenant. Cofres, key.bin, certificados e seus
formatos existentes nao sao convertidos nem apagados para caber no JSON geral.

Classificacao esclarecida pelo usuario em 2026-10-19: Memorias nao e excecao.
Configuracao YouTube e integracao externa do aplicativo, nao configuracao do
ambiente. Inclui Client ID/Secret, chave associada ao cofre, OAuth, tokens,
states e sessoes de upload. Preservar tela, cofre e precedencia atuais; nao
transportar para a Central nem para o arquivo de ambiente por conveniencia.

Se o ambiente usa memorias-youtube.env como bootstrap, ele permanece arquivo
privado especifico do app e deve ser lido pelo deploy Memorias. O loader geral
deixa de carregar essa configuracao para os outros destinos somente depois de
essa leitura especifica estar comprovada. SQL, RabbitMQ e JWT usados pelo
Memorias continuam no plano de infraestrutura compartilhada, como nos demais apps.

O inventario detalhado esta na secao 8; a matriz por servico, na secao 9.
Centralizacao de implantacao nao significa converter todos os segredos de
clientes em variaveis globais do servidor.

## 4. Verificacao Do Estado Atual

| Item | Achado no repositorio | Consequencia para a implementacao |
| --- | --- | --- |
| Deploy geral | Usa infra/docker/load-deploy-env.sh | Reaproveitar o ponto existente |
| Deploys diretos APS.ADM e Fiscal | Usam o mesmo loader | Adequar ao arquivo unico |
| Deploys diretos Central, Clinica, Memorias e Shared | Leem deploy.env sem o loader comum | Corrigir tambem essas entradas; nao depender do ambiente herdado do deploy geral |
| Loader atual | Le module-auth.env e memorias-youtube.env; pode gerar chave de modulo | Centralizar apenas credenciais gerais; leitura YouTube fica no deploy Memorias. Deploy normal apenas le/valida, nunca cria chave ausente |
| Compose ativos | Ha referencias de credenciais e valores/defaults ainda embutidos | Externalizar por consumidor, sem fallback secreto versionado |
| Bootstrap atual | Altera dono/modo da arvore YeshuaDB/persistent | Manter o arquivo privado fora dessa arvore |
| Engine | EnsureApplicationHostMyConfig copia conexoes do Studio para os hosts | Nao deixar a geracao reintroduzir senhas apos a limpeza |
| Runtime SQL compartilhado | GS aceita os overrides MYCONFIG__READCONECTIONSTRING e MYCONFIG__WRITECONECTIONSTRING | Preservar o caminho existente; nao presumir que user-secrets ja atende GS |
| Studios de migration | Clinica e Memorias aplicam os tres overrides SQL; Central, APS.ADM e Fiscal aplicam o de autorizacao, mas nao os de leitura/escrita | Corrigir a leitura antes de esvaziar appsettings e provar que --database-only realmente acessou o banco esperado |
| Configurador YouTube | Escreve arquivo privado separado | Conservar a configuracao especifica no Memorias; nao escrever no arquivo geral nem gerar nova chave de um cofre existente |
| Upload Clinica | UploadTokenHelper assina e valida com constante no fonte | Fornecer uma chave configurada, separada de JWT, sem fallback literal |
| Python | Renderer Memorias e workers de IA da Clinica possuem fallback com credenciais na URL do broker | Remover valores secretos do codigo, nao somente dos Compose |
| Certificado fiscal | FiscalPayloadStore grava PFX e senha.secret na raiz de storage; API/Worker/Nginx e agente podem montar a mesma arvore no host | Separar o destino privado por consumidor; nao afirmar que a permissao do arquivo central protege esses arquivos |
| Configuracao de testes | Foram encontrados campos TestSettings:Password nao vazios em alguns appsettings | Classificar fixtures e retirar credenciais reais sem executar testes de negocio em producao |

Essa conferencia nao comprova permissoes, valores efetivos, mounts ou saude da
VPS. Os testes abaixo ainda precisam ser implementados/executados.

## 5. Sequencia De Implementacao

1. Inventariar chaves e consumidores ativos, sem imprimir valores. Separar
   valores reais de placeholders e registrar o estado atual para retorno.
2. Preparar o diretorio/arquivo privado com permissao restrita e importar os
   valores que o ambiente realmente usa. Nao escolher senhas novas nem supor
   que as do Git correspondem as do SQL/broker em volumes ja existentes.
3. Adequar load-deploy-env.sh ao caminho central, reutilizando o seletor
   YESHUA_DEPLOY_SECRETS_ENV. Carregar configuracao publica e depois os segredos
   centrais, validar o conjunto dos Compose que serao usados e falhar sem alterar
   servicos quando faltar algo. Em all, validar o conjunto inteiro antes do Shared.
4. Fazer todas as entradas de deploy usarem esse loader. Preservar lock,
   atualizacao do repositorio, build, migration, subida e reconciliacao Nginx
   existentes; nao incluir limpeza extraordinaria nem mudar a estrategia de deploy.
5. Substituir literais/defaults secretos dos Compose por referencias explicitas.
   Corrigir primeiro a leitura SQL dos Studios Central/APS/Fiscal e a chave de
   upload Clinica. Remover valores reais dos appsettings ativos/Studios, defaults
   Python/JWT e ajustar a origem de geracao quando necessario. Templates podem
   conter campos vazios ou referencias, nao valores secretos. Nunca copiar a
   configuracao privada efetiva para um arquivo gerado ou para a imagem.
6. Cobrir desenvolvimento local com arquivo externo equivalente e ACL do Windows,
   separado de producao; scripts locais fornecem os overrides atuais. Nao deixar
   um novo clone sem caminho documentado para configurar e iniciar a aplicacao.
7. Preservar configurador, tela e cofres YouTube no Memorias. Seu deploy le o
   bootstrap privado especifico quando usado; nao inclui esses valores no arquivo
   geral nem os distribui a outros apps. Provar isso antes de retirar a leitura
   YouTube do loader geral atual, sem apagar arquivos ou mudar a precedencia.
8. Testar com credenciais ficticias e ambiente isolado; depois aplicar a mudanca
   acompanhada por destino e comprovar conexoes/login. Nao iniciar pelo deploy all.
9. Apos o aceite, desativar as leituras dos arquivos de configuracao antigos.
   Nao apagar cofres/dados nem fazer exclusao automatica de arquivos privados.

Antes de declarar o persistente privado implantado, separar tambem os arquivos
de certificado/senha fiscal do storage comum. Fazer isso como mudanca controlada
de destino e referencias, nao como movimentacao recursiva ou alteracao da saga.
Preservar o acesso aos certificados existentes ate a prova de leitura pelo app.

O formato hierarquico proposto usa JSON e parser padrao; nao executar o conteudo
como shell nem interpretar JSON como --env-file. O source atual de deploy.env
nao secreto e um mecanismo separado, preservado ate sua propria necessidade de
mudanca. Testar caracteres especiais e chaves/tipos invalidos antes da importacao.

Credenciais centrais prevalecem para as chaves selecionadas. Variavel herdada,
.env antigo ou default nao pode esconder ausencia no arquivo. Validar chaves
efetivamente declaradas, nao apenas variaveis ja presentes no processo.
Exigir somente o conjunto necessario ao destino/integracao habilitada.

Para evitar montagem incorreta de senhas com ponto-e-virgula, aspas, arroba ou
barra, a primeira entrega pode guardar conexoes SQL e URL AMQP finais ja validas
no arquivo privado, com nomes explicitos por finalidade/banco. Nao adicionar
concatenacao Bash de connection strings nem um formatador caseiro de URL.
Se houver representacoes diferentes da mesma identidade, conferir sua coerencia
sem exibir valores. Separar usuarios/permissoes de banco e uma evolucao posterior,
nao um efeito implicito da centralizacao.

O Compose suporta referencias obrigatorias com ${VAR:?mensagem}; a
[documentacao oficial](https://docs.docker.com/compose/how-tos/environment-variables/variable-interpolation/)
explica interpolacao e precedencia. Nao registrar docker compose config ou
--environment: a saida resolvida pode conter segredos.

Mudar variavel nao atualiza automaticamente senha de login SQL ou usuario de
broker persistido. A importacao precisa preservar os valores atuais. Rotacao
coordenada de valores ja expostos no Git e uma tarefa separada: mover o arquivo
nao remove segredos do historico nem torna credenciais antigas seguras.

## 6. Plano De Checagem

| Teste | Resultado exigido |
| --- | --- |
| Sintaxe/contrato do loader | Leitura sem escrita; valores ficticios chegam intactos, inclusive caracteres especiais |
| Arquivo ausente/ilegivel ou chave obrigatoria ausente | Falha antes de build, migration ou subida; sem gerar substituto |
| Modo 0644, dono inesperado, ACL indevida, link ou ancestral alteravel | Recusa de leitura sem exibir conteudo |
| Usuario comum no host | Nao consegue listar/ler/substituir arquivo ou pasta privada |
| Todas as entradas gerais/diretas | Mesma origem; segredo ausente nao e suprido silenciosamente pelo shell ou .env |
| Preflight all | Falta de uma credencial obrigatoria de um modulo interrompe antes de atualizar o Shared ou qualquer app |
| Migration sem conexao | --database-only falha explicitamente; nao retorna sucesso sem verificar/aplicar o banco correto |
| SQL de leitura/escrita/autorizacao | Valores ficticios distintos provam cada override, sem escrita acidental em producao |
| Integracao opcional desativada | Nao exige chave de provedor que nao sera utilizado |
| Limite entre servicos | Cada container recebe somente o necessario; Front, Nginx e renderer nao recebem senhas SQL/OAuth sem necessidade |
| Fonte/imagem/log | Sem valores reais em arquivos ativos versionados, assets, build args, imagens ou saida de diagnostico |
| Ambiente isolado | SQL, broker e apps conectam; migrations e login funcionam; sem efeitos externos fiscais/YouTube |
| Memorias existente | Client ID/secret, chaves e cofres permanecem no app; nada de YouTube no arquivo geral. Deploy proprio e precedencia continuam validos |
| Upload Clinica | Geracao/validacao usam a chave configurada; token adulterado e recusado; replicas concordam |
| HTTPS | setup-cert consegue usar o Compose sem expor segredo ou parar Nginx por falta de configuracao |
| Arquivos privados por app | Fiscal acessa PFX/senha e Memorias acessa o cofre; Front, Nginx, agente e Python nao acessam essas areas |
| Segundo deploy | Mesmo arquivo/chaves, sem prompts de senha ou regeneracao; aplicacoes continuam funcionando |

Conferir hashes/igualdade de forma restrita quando necessario, sem registrar
valores. Nao usar xtrace, dump de environment ou inspect completo em relatorios.
Rever tambem endpoints publicos/diagnosticos para nao exporem configuracao.

Retorno: guardar de forma restrita a configuracao efetiva anterior e a revisao
de codigo; se o piloto falhar, interromper a expansao e restaurar o mapeamento
anterior sem trocar senhas ou apagar volumes. Nao e a rotina futura de backup.

## 7. Aceite Antes De Falar Em Backup

- Arquivo unico de implantacao real, fora do repositorio e com restricao comprovada.
- Deploy geral e cada deploy direto testados usando essa origem.
- Servicos iniciam e usam suas credenciais sem valores reais nos fontes ativos.
- Redeploy preserva acesso, tokens/chaves esperados e dados ja cifrados.
- Evidencias sanitizadas registram o que passou e o que nao foi executado.

Hoje apenas o mapeamento estatico e o plano estao feitos. Centralizacao,
ensaios e aceite de producao continuam pendentes. O
[plano de backup](PLANO_BACKUP_RESTAURACAO_YESHUA.md) permanece posterior.

## 8. Inventario De Credenciais E Destinos

IDs abaixo sao apenas referencias deste documento, nao novos conceitos de DSL.
Nomes novos de variaveis sao propostas de mapeamento, nao chaves implementadas.
Um valor nao vazio no fonte nao comprova que seja o valor real usado na VPS.

### 8.1 Credenciais Estaticas Da Instalacao

| ID | Credencial | Origem/consumidor atual | Destino e regra planejados |
| --- | --- | --- | --- |
| C01 | Senha administrativa SQL | Shared: SA_PASSWORD literal; usuarios usados nas conexoes dos apps | Arquivo central; referencia explicita na propriedade ja consumida pela imagem. Preservar senha real do SQL existente |
| C02 | Conexoes SQL de cada app | MYCONFIG__READCONECTIONSTRING/WRITECONECTIONSTRING, appsettings API/Worker/Studio | Arquivo central, conexoes por catalogo/finalidade; manter os dois contratos mesmo quando os valores coincidirem |
| C03 | Conexao SQL para projetar autorizacao na Central | MYCONFIG__CENTRALAUTHORIZATIONCONECTIONSTRING dos cinco containers de migration | Arquivo central; fornecida aos Studios, nao a todos os containers por conveniencia |
| C04 | Conexoes SQL operacionais | ConnectionStrings__OperationalIntelligence e seis Mcp__DatabaseQuery__Connections__* no Shared | Arquivo central; API operacional recebe somente as conexoes nomeadas que usa. Nao ampliar privilegios nesta mudanca |
| C05 | Usuario/senha e URI do RabbitMQ | RABBITMQ_DEFAULT_USER/PASS, RabbitMq__UserName/Username e Password, CELERY_BROKER_URL | Arquivo central; manter identidade/vhost atuais, mapear .NET e Python e eliminar defaults secretos |
| C06 | Assinatura JWT | YESHUA_JWT_SECRET nas cinco APIs; defaults em Compose, appsettings e JwtSettings | Arquivo central; mesma chave efetiva no ecossistema atual, sem trocar fluxo de login/token nem criar chave por modulo |
| C07 | Assinatura entre modulos | YESHUA_MODULE_SHARED_KEY em APIs/Workers APS e Fiscal; module-auth.env | Arquivo central; importar a chave efetiva. Deploy nao gera substituta |
| C08 | Assinatura de token de upload Clinica | UploadTokenHelper.Generate e ValidateAndExtract usam constante | Proposta YESHUA_CLINICA_UPLOAD_SIGNING_KEY -> configuracao propria da API. Resolver na inicializacao, nao ler arquivo a cada chunk |
| C09 | Login administrativo Grafana | YESHUA_TELEMETRY_GRAFANA_USER/PASSWORD -> GF_SECURITY_ADMIN_USER/PASSWORD | Arquivo central; fornecer ao pacote de telemetria. Alterar env nao garante trocar login ja persistido no Grafana |
| C10 | Chave API OpenAI | OPENAI_API_KEY do operational-intelligence-agent | Integracao externa da ferramenta; area privada do servico proprietario, somente quando utilizada |
| C11 | Chave API Anthropic | ANTHROPIC_API_KEY do operational-intelligence-agent | Integracao externa da ferramenta; mesma classificacao de YouTube, nao excecao nem senha global de ambiente |
| C12 | Bootstrap OAuth Google/YouTube | YESHUA_MEMORIAS_YOUTUBE_CLIENT_ID/CLIENT_SECRET em API e Worker Memorias; memorias-youtube.env | Integracao externa Memorias: configuracao/cofre do aplicativo, nao arquivo de ambiente |
| C13 | Chave de bootstrap AES YouTube | YESHUA_MEMORIAS_YOUTUBE_ENCRYPTION_KEY; pode inicializar key.bin | Protecao associada ao cofre da integracao Memorias. Preservar key.bin e demais chaves, sem importar ao arquivo de ambiente |
| C14 | Conta de teste/integracao | TestSettings:Login/Password, overrides TESTSETTINGS__LOGIN/PASSWORD e scripts de teste | Arquivo privado do ambiente de teste, nao distribuido aos apps. Contas distintas por alvo, sem incluir senhas de usuarios reais no Git |

Nao impor uma unica identidade SQL a todas as conexoes: se o ambiente efetivo
ja tiver usuarios diferentes, preserva-los. Nao criar todos esses valores em
um servidor que nao usa os respectivos consumidores. O arquivo JSON usa
secoes nomeadas; o esquema e de chaves conhecidas, sem credenciais vazias
aceitas como configuradas nem exigencias de integracoes desabilitadas.

C10-C13 continuam no inventario para rastreabilidade, classificados como
integracoes/protecao de seus dados, nao excecoes a configuracao do ambiente.
C14 pertence ao ambiente de teste, nao ao arquivo de producao. A mesma regra
vale para qualquer integracao futura: resolver aplicativo/servico proprietario
e, se houver, tenant/conexao; nao criar uma terceira origem no arquivo geral
nem fazer o deploy geral ler/regravar cofres para preencher configuracao.

### 8.1.1 Contrato De Saida Do Loader Para Compose

Tabela de nomes intermediarios, sem valores; o arquivo de origem e o JSON
hierarquico da secao 2.2, nao um arquivo plano adicional. READ/WRITE sao dois
campos para cada catalogo listado, nao uma decisao de separar fisicamente os bancos agora.
O loader resolve as secoes e entrega os contratos existentes dos consumidores.

| Variaveis resolvidas pelo loader | Mapeamento |
| --- | --- |
| YESHUA_SQL_SA_PASSWORD | SA_PASSWORD do SQL Shared, mantendo o contrato atual da imagem |
| YESHUA_SQL_CENTRAL_READ / YESHUA_SQL_CENTRAL_WRITE | MYCONFIG__READCONECTIONSTRING / WRITECONECTIONSTRING da Central |
| YESHUA_SQL_CLINICA_READ / YESHUA_SQL_CLINICA_WRITE | Mesmos dois destinos da Clinica |
| YESHUA_SQL_APS_ADM_READ / YESHUA_SQL_APS_ADM_WRITE | Mesmos dois destinos do APS.ADM |
| YESHUA_SQL_FISCAL_READ / YESHUA_SQL_FISCAL_WRITE | Mesmos dois destinos do Fiscal |
| YESHUA_SQL_MEMORIAS_READ / YESHUA_SQL_MEMORIAS_WRITE | Mesmos dois destinos do Memorias |
| YESHUA_SQL_CENTRAL_AUTHORIZATION | MYCONFIG__CENTRALAUTHORIZATIONCONECTIONSTRING dos Studios |
| YESHUA_SQL_OPERATIONAL_INTELLIGENCE | ConnectionStrings__OperationalIntelligence |
| YESHUA_SQL_MCP_OPERATIONAL_INTELLIGENCE / CENTRAL / CLINICA / APS_ADM / FISCAL / MEMORIAS | Seis chaves completas com prefixo YESHUA_SQL_MCP_, destinadas as conexoes nomeadas MCP |
| YESHUA_RABBITMQ_USERNAME / YESHUA_RABBITMQ_PASSWORD | Broker e propriedades RabbitMq__UserName/Password dos consumidores .NET |
| YESHUA_CELERY_BROKER_URL | URI final para CELERY_BROKER_URL de cada consumidor Python |
| YESHUA_JWT_SECRET / YESHUA_MODULE_SHARED_KEY | Mantem os dois nomes de origem existentes |
| YESHUA_CLINICA_UPLOAD_SIGNING_KEY | Nova origem configurada do HMAC de upload, sem reutilizar JWT |
| YESHUA_TELEMETRY_GRAFANA_USER / YESHUA_TELEMETRY_GRAFANA_PASSWORD | Mantem os nomes existentes |

Cada campo SQL do JSON contem a connection string final, inclusive host/catalogo e
escapes, e nao somente uma senha. Conferir contra os nomes publicos de banco;
se forem divergentes, interromper a mudanca em vez de migrar outro catalogo.
Na primeira entrega, mudar nome de banco exige ajustar intencionalmente suas
conexoes; nao esconder isso em concatenacao de texto nem trocar banco durante
um deploy de credenciais. Valores repetidos no mesmo arquivo podem representar
a mesma identidade em contratos diferentes; a validacao deve comparar destinos
e finalidade, sem exibir segredos e sem conceder privilegios automaticamente.

As chaves YESHUA_MEMORIAS_YOUTUBE_* nao pertencem a este contrato geral.
Permanecem exclusivamente na configuracao privada especifica do Memorias,
quando o modo de bootstrap desse aplicativo as utilizar.

### 8.2 Segredos Que Nao Viram Variaveis Globais De Deploy

Todos seguem o principio de acesso restrito. A forma de armazenamento continua
a adequada ao consumidor existente; nao nasce uma infraestrutura nova por linha.

| ID | Credencial/artefato | Consumidores | Tratamento no plano |
| --- | --- | --- | --- |
| P01 | oauth.bin e key.bin da configuracao YouTube | API/Worker Memorias via repositorio criptografado | Permanecem na area privada Memorias; preservar chave, scope e precedencia sobre bootstrap |
| P02 | Access/refresh tokens OAuth, states e sessoes de upload | API/Worker Memorias, por tenant/conexao | Cofre existente, nao env nem payload para renderer; operacoes normais continuam atualizando-o |
| P03 | PFX fiscal e senha.secret por titular/tenant | API/Worker Fiscal, registrados por fluxo normal | Arquivos privados especificos do app; SQL guarda referencias. Nunca colocar todos os certificados/senhas no arquivo central |
| P04 | Chave TLS do site e conta ACME | Certbot no host; Nginx le certificados | Preservar /etc/letsencrypt e seu formato, leitura somente dos consumidores necessarios. CAs ICP-Brasil publicas nao sao segredos |
| P05 | Login/senha SMTP por tenant | EmailNotification da Clinica consulta yConfigNotification | Permanece dado gerenciado do aplicativo no banco; nao transportar para um login global. Hardening dessa coluna e tarefa propria |
| P06 | Senhas de usuarios e tokens tecnicos yToken | Login Central e conectores autenticados | Dados/identidades de clientes; nao sao credenciais de deploy. yToken declara TokenHash; nao presumir que isso tambem proteja yUser.Senha |
| P07 | Sessoes autenticadas das ferramentas de agente | Volumes operational-agent-codex e operational-agent-claude | Manter no formato nativo e acesso do usuario agent; nao extrair tokens para env nem conceder acesso ao arquivo central |
| P08 | SSH/Git/registro Docker/CI, caso utilizados | Operador/runner, nao aplicativos | Nao foi encontrada configuracao ativa dessas credenciais neste fluxo. Conferir no host/runner; manter chave/sessao nativa restrita, nao embutir em URL, argumento ou imagem |

Hoje a rota de arquivos encontrada no gateway publica /volatile/, nao toda a
arvore /storage. Isso nao prova isolamento dos certificados: o Nginx e o agente
declaram mounts da arvore geral, e os aplicativos tambem a compartilham.
Separar a area privada remove esse acesso desnecessario sem mudar rotas publicas.

A revisao tambem encontrou comparacao direta de user.senha no login Central
e senha de PFX passada em argumento do fallback OpenSSL. Registrar essas
lacunas sem afirmar que mover credenciais de deploy as resolveu. Qualquer
correcao desses comportamentos exige seu proprio plano/teste de compatibilidade;
nao alterar silenciosamente cadastro, hash de senha ou emissao fiscal nesta etapa.

### 8.3 Servicos Sem Credencial Propria Encontrada

- Front Central: nao recebe senha SQL, chave de assinatura JWT ou chave OAuth.
  O navegador usa o token do usuario; isso nao autoriza publicar secrets em JS.
- Nginx: usa chave/certificado TLS por arquivo, nao senhas dos apps.
- Redis: nao foi localizada autenticacao configurada no Compose ativo.
- Loki/Tempo/Prometheus/Collector: nao foi localizada credencial de autenticacao
  dos apps nas configuracoes atuais. A senha Grafana nao autentica todos eles.
- FFmpeg/modelos locais de transcricao/resumo: nao exigem chave de nuvem nas
  implementacoes revisadas; quem exige autenticacao e o broker consumido por Python.

Ausencia de credencial nao significa ausencia de risco nem servico seguro.
Nao abrir portas ou atribuir senhas imaginarias a esses servicos neste trabalho.
A API operacional/MCP e as rotas de observabilidade possuem pendencias de
autorizacao; centralizar conexoes SQL nao entrega esse controle de acesso.

## 9. Matriz De Entrega Por Servico

Esta matriz registra o que esta declarado hoje ou precisa ser externalizado.
Nao adiciona acesso SQL/Broker a um processo que nao o utiliza.

| Servico | Credenciais de instalacao | Arquivos/dados privados adicionais |
| --- | --- | --- |
| Shared sqlserver | C01 | Dados SQL atuais, sem mudar volume |
| Shared rabbitmq | C05, usuario/senha | Estado atual do broker, sem redefinir usuario por recriacao |
| Shared operational-intelligence-api | C04 | Nenhum acesso ao arquivo central |
| Shared operational-intelligence-agent | Sem credencial global de app no desenho atual | C10/C11 de suas integracoes quando usados, P07; nao P01/P02/P03 |
| Shared yeshua-telemetry | C09 | Persistencia Grafana existente |
| Shared nginx | Nenhuma variavel secreta dos apps | P04, leitura de TLS |
| central-front, duas replicas | Nenhuma | Nenhum cofre ou chave de servidor |
| central-api | C02 Central, C06 | P06 pelo banco Central |
| central-worker | C02 Central, C05 conforme configuracao atual | Nenhum arquivo de credenciais central |
| central-migration | C02 Central, C03 | Nenhum cofre |
| clinica-api | C02 Clinica, C06, C08 | P05 quando notificacao usada |
| clinica-worker | C02 Clinica, C05 | Storage operacional, nao certificados de outros apps |
| clinica-migration | C02 Clinica, C03 | Nenhum cofre |
| clinica-ai-worker/ai-summarizer, hoje comentados | C05, URI para Python se reativados | Sem chaves OpenAI/Anthropic no processamento local atual |
| aps-adm-api | C02 APS.ADM, C05, C06, C07 | Tokens de conector pelo caminho yToken |
| aps-adm-worker | C02 APS.ADM, C05, C07 | Nenhum cofre de outro app |
| aps-adm-migration | C02 APS.ADM, C03 | Nenhum cofre |
| fiscal-api | C02 Fiscal, C05, C06, C07 | P03 |
| fiscal-worker | C02 Fiscal, C05, C07 | P03 |
| fiscal-migration | C02 Fiscal, C03 | Nao recebe certificados de clientes |
| memorias-api | Do arquivo geral: C02 Memorias, C05, C06 | C12/C13 locais do Memorias conforme modo, P01/P02 |
| memorias-worker | Do arquivo geral: C02 Memorias, C05 | C12/C13 locais do Memorias conforme modo, P01/P02 |
| memorias-migration | C02 Memorias, C03 | Nao recebe OAuth nem tokens de canais |
| memorias-media-renderer | C05, URI para Python | Storage de midia, nunca P01/P02/P03 |
| Runner de testes | C14 e, somente se necessario ao teste, conexao de laboratorio | Nunca arquivo privado de producao inteiro |

O arquivo do host nunca e env_file universal de todos os servicos. A escolha
por environment explicito reutiliza os contratos existentes; Docker Compose
tambem oferece arquivos secrets por servico, mas esses contratos nao sao
adotados em paralelo nesta entrega. A
[documentacao Docker](https://docs.docker.com/compose/how-tos/use-secrets/)
esclarece essa alternativa e o risco de exposicao por variaveis de ambiente.

## 10. Todas As Entradas De Publicacao

| Entrada | Situacao atual | Alteracao planejada |
| --- | --- | --- |
| infra/docker/deploy.sh all | Atualiza Git, usa loader, depois Shared e cinco apps | Validar configuracao de todos antes de construir/migrar/subir o primeiro |
| Mesmo script central/clinica/aps-adm/fiscal/memorias | Executa Shared, app selecionado e gateway | Validar uniao Shared + app + gateway, nao exigir segredos de app nao envolvido |
| Mesmo script shared | Sobe servicos Shared e tenta gateway | Validar configuracao do Compose Shared; chaves opcionais de IA continuam opcionais |
| Cinco deploy.sh dos apps | Somente APS/Fiscal usam loader; podem chamar Shared | Todos usam o mesmo leitor, inclusive execucao direta; validar Shared quando for chamado |
| Shared/DockerCompose/deploy.sh direto | Le somente deploy.env | Passa pelo leitor comum, sem depender de shell previamente preparado |
| bootstraps/setup.sh | Instala/prepara host e dispara deploy all | Instruir provisionamento do arquivo privado antes do primeiro deploy; nao criar senhas automaticamente para contornar ausencia |
| bootstraps/setup-cert.sh | Certbot e depois docker compose up -d nginx | Carregar/validar antes de parar Nginx; mesmas rotas e certificados, sem novo proxy ou porta |
| configure-youtube.sh | Escreve memorias-youtube.env separado | Continua especifico do Memorias, sem escrita no arquivo geral; preservar chaves/cofres e formato privado |
| Wrappers ai-worker/ai-summarizer | Encaminham para deploy.sh clinica | Continuam encaminhando, sem leitor de segredo proprio |
| infra/docker/docker-compose.yml | Inclui Compose Clinica por compatibilidade | Usa referencias do manifesto incluido; operacao manual exige ambiente carregado, nao cria outra copia de credenciais |
| infra/Environments/Production/Migration | Fluxo alternativo com .env, sem chamada no orquestrador publico atual | Classificar como alternativo, nao migrar para ele. Sanear exemplos e documentar que nao e a entrada deste servidor |
| Template DockerCompose da Engine | Ponto inicial de uma infra nova, nao sobrescreve a atual | Gerar referencias sem valor e instrucoes de provisionamento; nao copiar o arquivo privado |
| Desenvolvimento/Studio/testes Windows | Fontes e contratos de leitura diferentes | Configuracao privada de desenvolvimento fora do checkout, ACL e overrides atuais; provar o launcher antes de retirar fallback real |

Compose pode interpolar o modelo inteiro mesmo quando o comando pede somente
nginx. Portanto, adicionar ${VAR:?erro} em outros servicos do Shared exige que
setup-cert e reconciliacao do gateway tenham o contexto correto tambem. Nao
tratar ausencia de senha SQL durante esse parsing como defeito da rota Nginx.

Leitura normal nao cria pasta, arquivo, usuario ou chave. Provisionamento e
alteracao administrativa sao operacoes explicitas. Atualizacoes atomicas do
arquivo devem respeitar o lock de deploy existente para nao trocar o conjunto
de credenciais no meio de um all; nao criar outro agendador ou servico para isso.

Atualizacao do arquivo nao modifica variaveis de containers ja em execucao.
O deploy do consumidor aplica as variaveis ao recriar seu processo quando
necessario, pelo fluxo existente; nao derrubar todos os apps por qualquer edicao.
Alteracao de senha SQL/Rabbit/Grafana persistida continua exigindo rotacao
coordenada, nao apenas editar env e esperar sincronizacao automatica.

## 11. Ordem De Entrega E Provas

1. Validar raiz privada e estrutura JSON Shared/Apps antes de implementar.
   Separar ambiente de integracao externa e dados de clientes, sem excecao por app.
   Guardar conexoes finais preserva o contrato atual; nao confundir nomes de
   bancos em deploy.env com senha ou origem de conexao de cada ambiente.
2. Implementar e testar o leitor comum com arquivo ficticio, restricoes de
   acesso, precedencia e validacao por conjunto de Compose. No Windows, testar
   o importador/launcher com a configuracao privada de desenvolvimento antes
   da limpeza dos appsettings; nao presumir suporte a user-secrets pelo GS.
3. Corrigir os tres Studios que nao aplicam leitura/escrita por ambiente.
   --database-only precisa falhar sem conexao e demonstrar catalogo/versao
   esperados sem imprimir a connection string. Nenhuma mudanca em DDL/migration.
4. Externalizar Compose, defaults Python/JWT, HMAC upload e appsettings.
   Conferir a geracao de um app representativo: nenhum segredo da execucao
   deve reaparecer no JSON gerado nem no resultado do publish.
5. Adequar entradas diretas, bootstrap e certificado; preservar o configurador
   YouTube do Memorias e comprovar a leitura especifica do seu bootstrap privado.
   Testar all com uma chave obrigatoria propositalmente ausente: nenhum servico
   pode ser atualizado antes dessa rejeicao. Nao executar esse ensaio na VPS.
6. Preparar o arquivo real fora do Git e preservar valores efetivos. Ensaiar
   primeiro num ambiente isolado com SQL/broker ja inicializados para mostrar
   que o deploy nao redefine usuarios/senhas nem perde acesso aos cofres.
7. Publicar acompanhado, Shared e apps de forma sequencial e com provas por
   consumidor. Confirmar login Central -> acesso aos modulos, transporte
   APS/Fiscal sem chamada fiscal real, upload Clinica e acesso ao cofre Memorias.
   Nao usar health/live sozinho como prova de conexao, permissao ou migration.
8. Separar os arquivos privados fiscais com binds e caminhos especificos.
   Manter certificado/senha sempre pareados, dono/UID correto e referencias
   antigas legiveis ate a confirmacao. Sem varrer/mover todo o storage.
   Depois de confirmar a nova leitura e atualizar as referencias pelo caminho
   do app, retirar somente os originais identificados da arvore compartilhada
   para quarentena privada. Nao deixar uma copia publica/compartilhada e declarar
   o segredo protegido apenas porque existe outra copia na pasta restrita.
9. Repetir deploy geral e direto; comprovar duas replicas Front intactas,
   ausencia de segredo no Front, nenhum valor novo e continuidade dos dados.
10. Registrar aceite e desativar somente as origens estaticas substituidas.
    Backup e uma etapa seguinte; nao adicionar rotina de backup ao deploy.

Um sucesso de centralizacao demonstra origem e acesso de configuracao, nao
rotacao dos segredos ja expostos. Preservar valores permite uma transicao sem
quebrar tokens/dados; a remediacao de valores publicos/conhecidos deve ser
planejada separadamente e nao pode ser anunciada como concluida.

## 12. Base Da Revisao E Limites

Revisados os seis Compose do caminho publico, scripts chamados por eles,
bootstrap/certificado/configurador, consumidores customizados identificados,
loader SQL/JWT compartilhado, fonte de geracao e configuracao dos Studios.
A conferencia estruturada leu 34 appsettings JSON em src/Studio,
src/CQRS/Infrastructure, src/OperationalIntelligence e tests. Valores foram
classificados sem serem reproduzidos neste documento.

Foram examinadas tambem as referencias de testes, ferramentas, frontend,
templates e caminhos alternativos de infra para nao tratar restos historicos
como componentes ativos. Buscas por nome sao inventario, nao prova de que
cada valor encontrado seja real, seguro ou consumido em producao.

Fontes-chave para localizar os achados:

- infra/docker/load-deploy-env.sh e deploy.sh.
- infra/Shared/DockerCompose/docker-compose.yml e nginx/routes.
- infra/{Central,Clinica,APS.ADM,Fiscal,Memorias}/DockerCompose.
- src/Engine/Yeshua.Engine/Dominio/Schemas/CQRS/CSharpCQRS.cs,
  EnsureApplicationHostMyConfig/TryReadStudioHostMyConfig.
- src/Engine/Yeshua.Engine/Dominio/Migration/MigrationStandard.cs e
  MigrationStanard/S000004.cs para credenciais de clientes e tokens.
- src/Studio/Yeshua.Studio.{Central,APS.ADM,Fiscal}/GlobalSettingsSingleton.cs.
- src/CQRS/Infrastructure/Yeshua.CQRS.Infrastructure.Shared/Configuration e Patterns/JWT.
- src/CQRS/Application/Yeshua.Clinica.CQRS.Application.Command/Receivers/Custon/UseCases/FileUpload/Infra/UploadTokenHelper.cs.
- src/CQRS/Infrastructure/Yeshua.Clinica.CQRS.Infrastructure.Shared/Patterns/Strategy/Custon/INotification/EmailNotification.cs.
- src/CQRS/Application/Yeshua.Fiscal.CQRS.Application.Command/Receivers/Custon/Saga/FiscalPayloadStore.cs e FiscalCertificateResolver.cs.
- src/CQRS/Infrastructure/Yeshua.Memorias.CQRS.Infrastructure.Shared/YouTube/Custon.
- tests/CQRS/Yeshua.CQRS.Tests.Integration.Api.TestKit/ApiIntegrationSettings.cs.

Nao foram lidos arquivos privados da VPS, autenticacoes reais de ferramentas,
segredos do provedor Git/CI, conteudo de backups ou dados dos clientes.
Nao foi executado scanner que garanta ausencia de segredo em todo o historico,
imagens antigas, camadas/cache Docker ou snapshots de fontes indexados.
Mover valores atuais nao higieniza esses artefatos; registrar para remediacao,
sem apagar historico, imagens ou dados automaticamente.

Referencias tecnicas complementares:

- [RabbitMQ URI](https://www.rabbitmq.com/docs/uri-spec): usuario/senha em URI
  exigem escaping proprio; copiar uma senha crua para uma URL nao e equivalente
  a fornece-la na propriedade Password do cliente .NET.
- [OWASP Secrets Management](https://cheatsheetseries.owasp.org/cheatsheets/Secrets_Management_Cheat_Sheet.html):
  limitar consumidores, evitar vazamento em logs e distinguir externalizacao
  de rotacao e recuperacao. Nenhum produto adicional foi adotado por esta revisao.
