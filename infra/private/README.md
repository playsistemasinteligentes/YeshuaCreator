# Configuracao Privada Yeshua

Implementada no repositorio em 2026-10-19. Preparacao privada conferida na VPS
em 2026-10-19: JSON criado a partir dos containers ativos, validacao de todos os
alvos aprovada, arquivo root:root 600 e pasta root:root 700. A chave de upload
Clinica ausente nas variaveis foi preservada do codigo da revisao instalada
`a4ccdbc3a`; nenhuma chave nova foi gerada. A referencia e os arquivos do cofre
YouTube permaneceram inalterados.

Nao foi executado deploy, pull, build, migration, parada ou reinicio de container
nessa preparacao. O repositorio remoto instalado continua em `a4ccdbc3a`, ainda
sem o leitor novo. A adocao pelos containers e o aceite funcional apos deploy
continuam pendentes. Deploy exige configuracao valida; setup pode criar o exemplo
privado vazio e parar para preenchimento, sem subir os servicos da aplicacao.

## Estrutura

```text
/root/YeshuaPrivate/production/
  credentials.json
  shared/OperationalAgent/integracoes/providers.json  # opcional
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

- JSON ausente: cria o exemplo vazio com permissoes restritas e interrompe antes
  de atualizar o sistema completo, instalar/iniciar Docker ou publicar apps.
  Completar os campos e repetir exatamente o mesmo setup. Nao gera chaves.
- JSON presente: valida e reutiliza sem reescrever, inclusive quando veio de uma
  copia restaurada. Diretorios ausentes de app sao criados; arquivos de cofre,
  chaves e dados presentes nao sao substituidos.
- Diretorios SQL/storage existentes mantem dono e permissoes. O setup nao aplica
  chown/chmod recursivo. Se as permissoes restauradas estiverem erradas, revisar
  explicitamente antes de subir; nao aplicar uma correcao em massa.
- JSON invalido, permissao indevida ou raiz YouTube explicitamente configurada
  que nao existe: interrompe antes de iniciar servicos da aplicacao.

`python3 infra/private/credentials.py init` segue a mesma regra: cria um exemplo
se ausente; se presente e valido para todos os apps, reutiliza e prepara somente
pastas ausentes. Importacoes explicitas continuam recusando um arquivo existente.
`YESHUA_DEPLOY_SECRETS_FILE` permite outro caminho absoluto fora do repositorio;
sua pasta e a raiz das subareas privadas. Deploy normal continua apenas leitor.

O setup nao restaura SQL automaticamente nem escolhe um backup. Isso fica para
a etapa posterior. Repor um cofre nao recria tenants/canais do banco: reutilizar
conexoes antigas depende dos mesmos IDs e ProcessingScope. Preservar somente a
configuracao Google do aplicativo nao equivale a restaurar todas as contas.

## Dados Existentes E Integracoes

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
  com `OpenAI.ApiKey` e `Anthropic.ApiKey`. Nao sao necessarios para validar as
  credenciais basicas da infraestrutura.
- Fiscal: novos certificados seguem tenant/titular/thumbprint na area privada,
  montada somente na API/Worker Fiscal. PFX e senha sao arquivos separados;
  o banco continua guardando referencias. Por decisao do usuario, nao faremos
  migracao do acervo antigo nesta entrega; isso nao bloqueia a implantacao.
  Nenhum arquivo antigo foi movido ou apagado. Backup nao foi implementado.
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
