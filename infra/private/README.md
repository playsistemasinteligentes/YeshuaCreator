# Configuracao Privada Yeshua

Implementada no repositorio em 2026-10-19. Preparacao privada conferida na VPS
em 2026-10-19: JSON criado a partir dos containers ativos, validacao de todos os
alvos aprovada, arquivo root:root 600 e pasta root:root 700. A chave de upload
Clinica ausente nas variaveis foi preservada do codigo da revisao instalada
`a4ccdbc3a`; nenhuma chave nova foi gerada. A referencia e os arquivos do cofre
YouTube permaneceram inalterados.

A preparacao de 2026-10-19 nao executou deploy nem reiniciou servicos. Em
2026-10-20 foi concluida a publicacao controlada da revisao `5a356472e`:
Central, Clinica, APS.ADM, Fiscal e Memorias, suas APIs/Workers, o renderer do
Memorias e a API de inteligencia operacional. As dez rotas publicas de saude
responderam com a revisao esperada; o Front manteve duas replicas iguais e o
`index.html` entregue correspondeu ao fonte. A inicializacao SQL da API operacional
e as migrations normais dos aplicativos terminaram sem erro.

O redeploy da Central com a mesma configuracao passou em cerca de 30 segundos,
reutilizando os quatro containers existentes. O JSON privado e o HTTPS ficaram
inalterados. Os dois arquivos de chave/configuracao YouTube comparados antes e
depois do deploy permaneceram identicos. SQL, Redis, RabbitMQ, telemetria,
agente e container Nginx nao foram reiniciados; Nginx recebeu somente validacao
e reload para atualizar os enderecos dos aplicativos.

As compilacoes dessa operacao foram limitadas a 1 CPU/1536 MiB por etapa antes
do deploy existente, reutilizando o cache do builder. Foi um procedimento
operacional pontual, nao uma alteracao dos limites padrao dos scripts de deploy.
Registros privados de aceite/retorno ficam em
`/root/YeshuaPrivate/production/operations/credentials-5a356472e/`; nao sao uma
segunda fonte de configuracao nem implementam uma rotina de backup.

Aceite tecnico de configuracao/permissoes/subida/redeploy concluido. Login com
conta real e fluxos de negocio, como emissao SEFAZ e upload YouTube, nao foram
executados nessa operacao e ainda exigem conferencia funcional. Deploy exige
configuracao valida; setup pode criar o exemplo privado vazio e parar para
preenchimento, sem subir os servicos da aplicacao.

### Testes Complementares Em 2026-10-20

- 39 verificacoes de producao passaram, incluindo revisao dos hosts, 52
  mapeamentos de credenciais entre Compose e containers, permissoes privadas,
  rejeicao de acesso ao getMenu sem token/com token invalido nos cinco apps,
  nove arquivos publicos iguais ao fonte, RabbitMQ autenticado e sem alarmes,
  Redis, ping do renderer Celery, Nginx e rota publica de saude do Grafana.
- Dez conexoes SQL locais, de leitura e de escrita dos cinco apps, abriram e
  executaram somente SELECT para conferir conectividade e existencia de yTenant.
  Isso nao testa permissoes de escrita nem altera registros. JSON local e da
  VPS permaneceram inalterados; as permissoes locais continuaram restritas.
- 25 testes Python, quatro testes .NET de configuracao privada, um teste de
  geracao da Engine e o teste Bash do leitor comum passaram. Usam dados ficticios.
- Navegacao publica entre login, cadastro e recuperacao conferida no navegador,
  incluindo larguras 375 e 320 sem rolagem horizontal. Entrada direta
  /memorias/login chegou a /spa/?app=Memorias#login. Cadastro e recuperacao nao
  foram enviados.
- Defeito reproduzido no front ja existente: login inexistente recebe HTTP 401
  sem corpo, mas router.js tenta res.json() antes de tratar o status e mostra
  "Erro de conexao". A API negou o acesso corretamente. Nao houve correcao nem
  redeploy do front nesta bateria; login positivo e fluxos autenticados seguem
  pendentes de teste com conta real. Nenhum documento fiscal ou video foi emitido.

## Estrutura

```text
/root/YeshuaPrivate/production/
  credentials.json
  shared/OperationalAgent/integracoes/providers.json  # opcional: agentes e tunel MCP
  apps/
    Central/
    Clinica/
    APS.ADM/
    Fiscal/tenants/<TenantId>/titulares/<Documento>/certificados/<Thumbprint>/
      certificado.pfx
      senha.secret
    Memorias/
      integracoes/youtube/bootstrap.json              # opcional
      accounts/                                      # cofre existente
```

`credentials.example.json` documenta o esquema vazio. O arquivo real possui
`SchemaVersion: 1`, `Shared` e `Apps.<Aplicativo>`. Contem conexoes SQL completas
de leitura/escrita por app, conexao de autorizacao Central, conexoes operacionais,
autenticacao RabbitMQ, JWT, chave entre modulos, Grafana e assinatura de upload
Clinica. Conexoes diferentes permanecem independentes; nenhuma e deduzida de
outra no deploy. Ao mudar um banco, alterar suas conexoes privadas explicitamente.

"Centralizado" nao significa gerenciado pelo aplicativo Central. O arquivo e
administrativo, lido no host, nunca montado inteiro nos containers. O Compose
entrega a cada servico somente as variaveis declaradas para ele. O Front nao
recebe senhas. Nao ha servico novo, consulta por requisicao ou cifra local nova.

OAuth/YouTube e provedores externos sao integracoes do consumidor, nao
credenciais do ambiente. Permanecem nos subdiretorios proprios. Tokens de
usuarios, SMTP de tenants e certificados nao sao incluidos no JSON geral.

## Transicao Da VPS Existente

1. Disponibilizar os novos arquivos do repositorio **sem executar deploy/setup**.
   Os containers atuais devem continuar rodando durante a captura. Nao remover
   containers, imagens, bancos, volumes nem os arquivos privados anteriores.
2. Como root, no repositorio, executar:

```bash
python3 infra/private/credentials.py init --from-running-containers
```

Esse comando somente le os containers dos seis projetos `playsis-*` conhecidos.
Cria o JSON privado com os valores encontrados, sem mostra-los, sem substituir
arquivo existente e sem gerar senhas/chaves. Replica divergente bloqueia a
importacao. Captura tambem o bind privado atual do Memorias e eventuais variaveis
de integracao nos arquivos proprios. Se o arquivo ja existir, revisar em vez de
apaga-lo para repetir a importacao.

3. Completar campos ausentes em um editor local no servidor, sem colar valores
   em chat, Git ou argumentos de comandos. Em especial, a chave HMAC de upload
   da Clinica anteriormente estava no codigo: o Docker antigo pode nao expor
   esse valor. Recuperar **a mesma chave**, nao inventar outra. Um servico parado
   tambem pode deixar campos ausentes. Preservar nomes de bancos, senhas, JWT,
   chave entre modulos e chave de protecao do YouTube. O importador nao recupera
   valores embutidos nos binarios nem segredos de um container que nao existe.
4. Verificar o arquivo sem exibir valores:

```bash
python3 infra/private/credentials.py validate --target all
stat -c '%U:%G %a %n' /root/YeshuaPrivate/production /root/YeshuaPrivate/production/credentials.json
```

Esperado: root:root, diretorio 700, arquivo 600. O leitor rejeita links,
permissoes de terceiros e ancestrais substituiveis por outros usuarios. Nao
usar chmod/chown recursivo sobre storage ou SQL. Acesso root/Docker continua
administrativo: variaveis dos containers nao sao um cofre contra o administrador.

5. Somente depois da validacao, usar as entradas de deploy existentes. Primeiro
   um alvo em janela controlada; confirmar migration, login e operacao antes do
   deploy geral. Nao rodar tudo apenas para conferir a configuracao.

```bash
bash infra/docker/deploy.sh central
```

O fluxo Git/build/migration/up/reconciliacao permanece o anterior. O leitor
comum valida o alvo e o Shared antes das operacoes Docker. `all` valida todos os
apps antes de iniciar o primeiro. Deploy normal nao grava no arquivo privado,
nao gera chave e nao le os antigos arquivos .env como fallback. Nginx usa o mesmo
leitor para interpolar o Shared; suas rotas, portas e replicas nao foram alteradas.

## Um Setup Para Criar Ou Reconstruir

Nao existe flag de instalacao nova/restauracao e nao ha segundo deploy. O
procedimento sempre e: fornecer configuracao/dados -> validar -> criar somente
diretorios ausentes -> executar o deploy existente.

Na reconstrucao, primeiro repor o JSON privado e o conjunto YouTube preservado,
nos caminhos configurados. Em um ambiente novo, completar o JSON com os valores
provisionados. Executar o mesmo setup como root:

```bash
bash /root/YeshuaCreator/infra/bootstraps/setup.sh
```

O comando publico de download em infra/README.md chama esse mesmo script quando
o repositorio ainda nao esta disponivel. O setup obtem o repositorio e, se
necessario, instala somente Git/Python/curl para ler a configuracao primeiro.

- JSON ausente: cria o exemplo vazio com permissoes restritas e aguarda seu
  preenchimento ou reposicao no inicio, antes da atualizacao geral/Docker/apps.
  Em outra sessao SSH/SFTP, preparar o arquivo no destino mostrado no servidor;
  nao e um caminho do computador local. Nao colar JSON, senhas ou chaves no prompt.
  Digitar PRONTO confere novamente e continua na mesma execucao quando valido.
  Nao gera chaves nem copia arquivos de outra maquina automaticamente.
- JSON presente: valida e reutiliza sem reescrever, inclusive quando veio de uma
  copia restaurada. Diretorios ausentes de app sao criados; arquivos de cofre,
  chaves e dados presentes nao sao substituidos.
- Diretorios SQL/storage existentes mantem dono e permissoes. O setup nao aplica
  chown/chmod recursivo. Se as permissoes restauradas estiverem erradas, revisar
  explicitamente antes de subir; nao aplicar uma correcao em massa.
- JSON invalido, permissao indevida ou raiz YouTube explicitamente configurada
  que nao existe: permite corrigir/repor em outra sessao e conferir com PRONTO,
  sem substituir valores nem corrigir permissoes automaticamente. CANCELAR,
  fim da entrada ou Ctrl+C interrompem antes dos servicos da aplicacao.

O setup usa `credentials.py init --wait`. Essa espera le somente confirmacoes
em /dev/tty, nunca stdin (que pode conter o script de download). Sem terminal
interativo, uma configuracao ja valida e reutilizada sem perguntas; se precisar
de preparo, o setup falha no inicio e preserva o exemplo para concluir depois.
O arquivo deve ter dono administrativo, pasta 0700 e arquivo 0600. O terminal
deve ser privado e nao gravado/compartilhado. A guarda da senha do backup vem
logo depois desta validacao, ainda antes das etapas demoradas; nao ha novas
perguntas previstas no final para a mesma senha/repositorio/maquina.

Sem --wait, `python3 infra/private/credentials.py init` continua nao interativo: cria um exemplo
se ausente; se presente e valido para todos os apps, reutiliza e prepara somente
pastas ausentes. Importacoes explicitas continuam recusando um arquivo existente.
`YESHUA_DEPLOY_SECRETS_FILE` permite outro caminho absoluto fora do repositorio;
sua pasta e a raiz das subareas privadas. Deploy normal continua apenas leitor.

O setup nao restaura SQL automaticamente nem escolhe um backup. Isso fica para
a etapa posterior. Repor um cofre nao recria tenants/canais do banco: reutilizar
conexoes antigas depende dos mesmos IDs e ProcessingScope. Preservar somente a
configuracao Google do aplicativo nao equivale a restaurar todas as contas.

## Dados Existentes E Integracoes

### Acessos SQL Na Instalacao Ou Reconstrucao

O SQL novo cria o administrador sa com Shared.SqlServer.AdminPassword pelo
Compose existente. Contas adicionais, quando utilizadas nas conexoes, devem
estar declaradas no mesmo arquivo privado; nao sao inferidas das connection
strings, nem extraidas de master/msdb. Exemplo somente estrutural:

```json
"SqlServer": {
  "AdminPassword": "<senha administrativa existente>",
  "Logins": {
    "usuario_aplicativo": {
      "Password": "<a mesma senha usada nas conexoes do aplicativo>",
      "CreateDatabase": false,
      "Databases": {
        "YESHUA_MEMORIAS": ["db_datareader", "db_datawriter"]
      }
    }
  }
}
```

Logins e opcional: {} preserva ambientes que usam somente sa. Essa secao e
administrativa; nao e enviada aos containers. Roles aceitas: db_owner,
db_datareader, db_datawriter, db_ddladmin e db_backupoperator. Declarar apenas
os acessos realmente necessarios. CreateDatabase=true concede explicitamente
CREATE ANY DATABASE para uma conta que precisa criar o catalogo pela migration;
nao concede sysadmin. A configuracao e validada antes das etapas demoradas.

O setup habilita internamente YESHUA_SETUP_SQL_ACCESS=1: prepara logins apos a
subida do SQL, reaplica os vinculos/roles apos cada migration e antes de iniciar
os consumidores, e exige todos os bancos declarados ao final. O helper e
infra/private/sql_access.py e reutiliza o leitor privado e cliente SQL existentes.
O deploy cotidiano nao habilita esse provisionamento nem muda permissoes.

Repetir nao troca senhas: conta existente deve estar habilitada e corresponder
a senha declarada; divergencia interrompe e exige reconciliacao explicita.
Usuarios SQL orfaos com o mesmo nome sao vinculados ao login recriado. Outros
tipos de principal bloqueiam a operacao. Nao ha remocao de acessos existentes,
nem criacao de um segundo usuario para um login que ja e dono do banco como dbo,
criacao de bancos por esse helper nem copia de jobs/logins do servidor antigo.
Connection strings devem corresponder as declaracoes; nao ha validacao automatica
dessa correspondencia nem descoberta de contas externas nao declaradas.

Depois de restaurar SQL e os arquivos privados, conferir os acessos ANTES dos hosts:

```bash
sudo python3 -B infra/private/sql_access.py
```

Senhas/SQL com senha seguem somente no ambiente/entrada do processo filho,
nunca em argumentos ou logs. Os testes locais simulam SQL; grants e remapeamento
reais ainda exigem o ensaio no novo servidor, com os aplicativos isolados.

- Memorias: `Apps.Memorias.PrivateRoot` preserva explicitamente o bind antigo,
  inclusive `/root/YeshuaMemoriasSecrets`. Nao mover `accounts`, `key.bin`,
  `oauth.bin`, tokens, scopes ou conexoes para adotar a nova nomenclatura. O
  padrao novo vale para instalacoes novas; um cofre antigo detectado sem
  referencia explicita bloqueia o deploy. Nao trocar chaves para fazer validar.
  Quando PrivateRoot e informado, a pasta precisa existir antes do deploy. API
  e Worker usam bind com create_host_path=false para nao criar uma raiz vazia
  por engano, conforme a [referencia Docker Compose](https://docs.docker.com/reference/compose-file/services/#volumes).
  O leitor nao valida criptograficamente o conteudo do cofre; o aplicativo
  continua responsavel por isso. Uma pasta vazia nao prova restauracao completa.
- O bootstrap YouTube opcional fica em
  `apps/Memorias/integracoes/youtube/bootstrap.json`, com `ClientId`,
  `ClientSecret`, `EncryptionKey` e metadados opcionais `RedirectUri`,
  `ConfigurationAdminTenantId`, `ConfigurationAdminUserId`. A precedencia do
  cofre/tela existentes nao muda. `configure-youtube.sh` administra somente esse
  arquivo, nao o JSON geral e nao gera chave. Pode-se continuar usando a tela.
- Providers opcionais do agente: `shared/OperationalAgent/integracoes/providers.json`,
  com `OpenAI.ApiKey`, `Anthropic.ApiKey` e o par opcional `McpTunnel.Id` /
  `McpTunnel.ApiKey`. O par do tunel deve ser preenchido junto e e entregue somente
  ao container operacional unificado. Consulte `providers.example.json`.
  Esses providers nao sao necessarios para validar as credenciais basicas da infraestrutura.
- Fiscal: novos certificados seguem tenant/titular/thumbprint na area privada,
  montada somente na API/Worker Fiscal. PFX e senha sao arquivos separados;
  o banco continua guardando referencias. Por decisao do usuario, nao faremos
  migracao do acervo antigo nesta entrega; isso nao bloqueia a implantacao.
  Nenhum arquivo antigo foi movido ou apagado. A area privada atual participa
  da rotina de arquivos em infra/backups; acervo legado fora dela continua
  dependendo do inventario/captura coordenada, nao de migracao silenciosa.
- Os paths internos do cofre Memorias e os formatos dos certificados nao foram
  redesenhados; hierarquia logica nao autoriza migracao silenciosa de dados.

## Desenvolvimento Local

Padrao Windows: `%USERPROFILE%/.yeshua/private/development/credentials.json`.
Foi preservada uma copia local dos valores existentes antes da limpeza dos
fontes. O arquivo real nao e versionado. Sua ACL permite somente usuario atual,
SYSTEM e Administradores. Campos nao encontrados continuam pendentes de
configuracao; isso nao representa credenciais de producao validadas.

Em 2026-10-20, com autorizacao explicita, foram completados somente quatro
campos vazios do arquivo local: chave entre modulos, URL do broker e conexoes
SQL leitura/escrita do Memorias. Valores locais ja preenchidos foram preservados.
Os cinco aplicativos passaram na validacao de configuracao e permissoes locais.
Isso nao comprova conectividade SQL, autorizacao no banco nem operacao do app.
Nao foram copiados SQL administrativo, credenciais operacionais ou cofre YouTube;
nenhum arquivo privado deve entrar no Git. A captura foi pontual, nao ha busca
automatica de segredos da VPS em cada inicializacao.

Com Python instalado (ou `-Python` apontando para o executavel), carregar na
sessao antes de iniciar API/Worker/Studio:

```powershell
./tools/private/Use-YeshuaEnvironment.ps1 -Application Central
dotnet run --project src/CQRS/Infrastructure/Yeshua.Central.CQRS.Infrastructure.Api
```

Para uma execucao com restauracao das variaveis anteriores ao terminar:

```powershell
./tools/private/Use-YeshuaEnvironment.ps1 -Application Fiscal -Command @('dotnet', 'run', '--project', 'src/Studio/Yeshua.Studio.Fiscal', '--', '--database-only')
```

Esse ultimo exemplo **executa migrations**: usar somente com conexoes privadas
locais previamente conferidas. O launcher nao inicia nada sem `-Command`.
Processos/Visual Studio ja abertos nao herdam variaveis de um terminal novo.

### Debug Local Com Banco No Servidor

Localizacao do codigo e localizacao do banco sao independentes. As conexoes do
JSON local podem apontar para o SQL da VPS; as senhas nao voltam para appsettings
ou launchSettings. Neste ambiente, as conexoes locais existentes de Central,
Clinica, APS.ADM e Fiscal ja apontavam para a VPS. Para novas conexoes, nomes
internos Docker como `sqlserver` nao sao enderecos validos no Windows; utilizar
o endereco autorizado do SQL, VPN ou tunel explicitamente configurado.

Iniciar apenas o aplicativo que sera depurado, com o mesmo escopo exclusivo na
API e no Worker locais que devam colaborar. Exemplo para a API Fiscal:

```powershell
./tools/private/Use-YeshuaEnvironment.ps1 -Application Fiscal -ProcessingScope debug-angelo -Command @('dotnet', 'run', '--project', 'src/CQRS/Infrastructure/Yeshua.Fiscal.CQRS.Infrastructure.Api')
```

No Visual Studio aberto, usar **Depurar > Anexar ao Processo** e selecionar
`Yeshua.Fiscal.CQRS.Infrastructure.Api.exe`; os breakpoints continuam nos fontes
locais. O iniciador nao depende de reiniciar o IDE e nao altera variaveis de
usuario/maquina. Com `-Command`, restaura as variaveis da sessao ao terminar,
inclusive quando o processo retorna erro. Sem `-Command`, carrega somente a
sessao atual; nao inicia aplicativo, nao faz login e nao consulta banco.

O leitor utiliza as [variaveis de ambiente do .NET](https://learn.microsoft.com/en-us/aspnet/core/fundamentals/configuration/?view=aspnetcore-8.0#environment-variables).
Nao carregar o perfil de um aplicativo no IDE e iniciar varios aplicativos com
ele: `MYCONFIG__...` identifica a conexao do aplicativo selecionado. Para debug
simultaneo, executar cada aplicativo em seu proprio iniciador/processo e anexar
aos processos correspondentes, sem compartilhar o ambiente generico entre apps.

`-ProcessingScope` apenas substitui `YeshuaProcessing:Scope` no processo iniciado.
Usar valor diferente da producao e o mesmo nos processos locais participantes.
Nao iniciar um Worker com o escopo publicado para fazer uma conferencia.
Escopo isola consumo de Saga/Inbox/Outbox, nao isola dados de negocio, filas de
outros tipos, canais YouTube ou chamadas externas. SQL com a mesma credencial
continua tendo as mesmas permissoes: CRUD e integracoes podem alterar dados reais.
Nao executar Studio `--database-only`, smoke/seed ou testes de escrita contra a
VPS como parte da validacao de credenciais. Preferir banco/usuario de testes
para trabalho cotidiano; sua criacao e uma operacao separada.

Opcionalmente `Apps.<App>.Tests.Smoke|Seed` guarda Login/Password e configuracao
publica de testes. `-TestProfile Smoke|Seed` carrega somente `TESTSETTINGS__...`;
nao executar testes integrados contra producao como verificacao de configuracao.

`init --from-development-source --file <caminho>` e um auxiliar **de transicao**:
le o HEAD anterior a limpeza, nao e fallback do runtime. Depois de comitar a
limpeza, recuperar valores do arquivo privado preservado ou do ref historico
correto, nunca recriar senhas automaticamente.

## Checagem E Retorno

Antes: validar arquivo/permissoes, registrar ref da versao e preservar cofres,
chaves e referencias existentes. Depois: conferir status/health sem despejar env,
migrations, login Central, entrada nos modulos, upload Clinica e uso de uma
conexao YouTube existente em teste controlado. Repetir redeploy sem mudar valores
e confirmar que o arquivo administrativo nao foi alterado.

Se falhar, interromper o alvo, diagnosticar e retornar ao ref conhecido pelo
procedimento de deploy anterior. Nao executar down -v, prune, excluir JSON/cofre
ou trocar chaves como recuperacao. Migration de negocio nao e desfeita por
rollback de codigo: sua compatibilidade precisa ser avaliada separadamente.

Testes locais cobrem leitor/ACL Windows, fixtures de importacao, rejeicao de
campos ausentes, sintaxe Bash, geracao sem senhas, assinatura de upload e destino
privado fiscal. Nao substituem o aceite de Docker/permissoes Linux na VPS.

Nao imprimir a acao `export`: sua saida base64 e transporte interno, **nao
criptografia**. Evitar `set -x`, env/inspect completos, dumps de configuracao e
`docker compose config` sem redacao. Segredos antigos continuam no historico
Git/imagens: retirar do fonte atual nao os revoga. Rotacao sera etapa separada.
## Acesso Ao Repositorio De Backup

O operador em infra/backups reutiliza o mesmo JSON privado, sem outro .env ou
servico de segredos. Shared.Backup contem Repository, Password e Environment;
o modelo publico tem apenas campos vazios. Leitura/validacao normal do deploy
nao exige esse bloco nem o exporta aos aplicativos. Memorias continua dono das
integracoes YouTube e de seu cofre; nada foi transferido para a Central.

A senha Restic e o acesso ao backend precisam de copia segura fora da VPS.
O bootstrap de restore exige somente SchemaVersion e Shared.Backup: a senha
SQL e as demais chaves vem do proprio arquivo privado restaurado. O bootstrap
fica em diretorio restrito diferente do destino de restauracao, evitando
sobrescrever a configuracao que esta sendo usada para baixar os dados.

Em 2026-10-20 foi inicializado o repositorio cifrado LOCAL em
/root/YeshuaBackup/repository. Somente Shared.Backup foi acrescentado; os
segredos existentes dos aplicativos nao foram trocados. O kit contendo APENAS
SchemaVersion/Shared.Backup tem copia com ACL restrita em
%USERPROFILE%/.yeshua/private/recovery, fora do Git. Nao inclui senha SSH,
SQL ou cofre YouTube. O destino externo continua pendente; a chave fora da VPS
nao substitui uma copia externa dos dados.

O [roteiro de recuperacao](../backups/RECOVERY.md) separa preparacao, SQL,
reconciliacao e liberacao dos servicos. Nenhuma credencial real foi colocada
no repositorio. Backup local executado nao e prova de restore integral.

### Copia Para A Instalacao Limpa

Em 2026-10-21, credentials.json completo de producao foi copiado via SSH com
conferencia SHA256 para %USERPROFILE%/.yeshua/private/production/<data-hora>/,
com ACL Windows restrita. Nao substitui a copia limitada de development nem
o kit de recovery e nao inclui o cofre YouTube ou dados SQL.

No mesmo diretorio, credentials-new-server.json e uma segunda copia validada
para a instalacao vazia aprovada: somente Apps.Memorias.PrivateRoot foi retirado,
para nao exigir o cofre antigo que sera descartado. Senhas/chaves preservadas;
o original nao foi alterado. Transferir o arquivo escolhido com o nome
credentials.json no destino padrao quando o setup aguardar. Nao e sincronizacao
automatica e nao cria outro modo de setup. Para recuperar o cofre antigo,
utilizar a configuracao original E os arquivos/chaves correspondentes, nao essa
copia limpa. Alterar credenciais de servicos existentes exige rotacao coordenada.

### Verificacao Local Repetivel

```bash
python3 -B -m unittest discover -s tests/Infrastructure/PrivateConfig -p 'test_*.py'
python3 -B -m unittest discover -s tests/Infrastructure/Backup -p 'test_*.py'
bash tests/Infrastructure/PrivateConfig/private-config-loader.test.sh
bash tests/Infrastructure/PrivateConfig/unified-setup.test.sh
dotnet test tests/Infrastructure/Yeshua.PrivateConfiguration.Tests/Yeshua.PrivateConfiguration.Tests.csproj
dotnet test tests/CQRS/Yeshua.CQRS.Infrastructure.Shared.Tests/Yeshua.CQRS.Infrastructure.Shared.Tests.csproj
```

O teste de modelos Compose usa somente fixtures, sem daemon/rede/VPS.
Usa docker-compose ou docker compose; YESHUA_TEST_COMPOSE pode apontar para
um executavel standalone oficial. Sem CLI, esse teste e explicitamente ignorado.
Nunca substituir a fixture pelas credenciais reais para imprimir config.

### Executor Codex Do Clinica

A configuracao Apps.Clinica no credentials.json geral usa o cofre privado
existente, junto das conexoes SQL e demais chaves. Ela e carregada para
Clinica/Shared/all pelo exportador,
com variaveis CLINICA_* limpas quando nao configuradas. Ver
docs/operational/clinica/CODEX_EXECUTOR.md. Nenhuma credencial e criada ou
migrada automaticamente, e o modo de tarefas depende de override explicito.

O Worker C# do Clinica usa `Apps.Clinica.Transcription` desse arquivo
para entrega direta da Outbox a OpenAI. `Transcription.Provider` aceita
`OpenAI` (padrao) ou `Queue`; `ApiKey`, `Model` e `BaseUrl` alimentam
`CLINICA_TRANSCRIPTION_*`. Nao duplicar a chave em outro arquivo. A opcao Queue
mantem o executor externo pela fila; resumo continua pela fila em ambos os modos.
O antigo apps/Clinica/integracoes/codex-executor.json nao e lido nem usado como fallback.
Configuracao e limites: [transcricao OpenAI](../../docs/operational/clinica/OPENAI_TRANSCRIPTION.md).
