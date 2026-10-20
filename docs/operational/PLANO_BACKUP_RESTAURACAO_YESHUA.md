# Plano De Backup, Checagem E Restauracao Do Ambiente Yeshua

Data: 2026-10-17.

Revisao 3, em 2026-10-19: diretorio privado com acesso restrito como padrao
para credenciais tecnicas, sem camada obrigatoria de criptografia local.

Status: proposta para revisao. Nenhum backup, agendamento, parada, restore ou
mudanca de infraestrutura foi executado por este planejamento.

O [mapa de dados, areas e politicas](MAPA_DADOS_AREAS_E_BACKUP_YESHUA.md)
complementa este procedimento com a classificacao por origem e a proposta de
heranca de protecao para novos recursos, incluindo lacunas ainda nao corrigidas.
Ele e o mapa de adesao; este documento define a sequencia e o procedimento
para implantar o modelo. Nao ha dois planos independentes por aplicativo.

A primeira entrega e a
[centralizacao de credenciais](PLANO_ETAPA_1_CENTRALIZACAO_CREDENCIAIS_YESHUA.md),
com restricao de acesso, deploy e redeploy comprovados. Somente apos esse
aceite retomar as rotinas deste plano. O
[piloto SQL local](PLANO_BACKUP_SQL_LOCAL_FUTURO_YESHUA.md) e planejamento
posterior, nao o primeiro passo nem backup ja implantado.

## 1. Objetivo E Limites

Proteger os dados do ambiente publicado e deixar um roteiro verificavel para
recuperar um arquivo, um aplicativo ou o servidor completo. A futura entrega de backup
prioriza bancos SQL, arquivos de negocio e configuracoes/chaves necessarias
para interpreta-los. Backup de imagens Docker e snapshot integral da VPS ficam
para depois da estabilizacao das versoes.

O ponto de partida deixa de ser criar uma rotina para cada pasta encontrada.
A ordem passa a ser definir politicas, preparar areas com essas politicas e
vincular recursos a elas. O inventario atual informa o que ja adere, o que
precisa de um bind e o que e uma excecao a corrigir. Para dados existentes,
admitir os caminhos atuais; nao mover toda a instalacao para iniciar a protecao.

```text
Politica definida uma vez
    -> area/banco preparado e vinculado no ambiente
    -> aplicativo escolhe a area
    -> dados novos herdam a estrategia
    -> ciclo de backup captura e demonstra recuperacao
```

O inventario abaixo foi obtido do repositorio. Nomes, tamanhos, mounts, versoes
e configuracoes efetivos precisam ser confirmados no servidor. Arquivo de
Compose descreve a intencao de implantacao; nao comprova o estado publicado.

Backup sera operacao da infraestrutura, fora da Engine e da DSL. Proposta de
ferramentas: backup nativo do SQL Server e restic no host Linux para enviar
copias seletivas a um repositorio externo criptografado. O fornecedor desse
repositorio permanece a definir. Nao e necessario criar outro servico Yeshua.

Este plano complementa o runbook da secao 9.9 de
`OPERATIONAL_SUPPORT_ADOPTION_STANDARD.md`: responsaveis e procedimento se
relacionam a G1, versao recuperavel a G2 e demonstracao de restore a G7. Esses
vinculos nao significam que os gates estejam aprovados nem criam nova familia
de classificacao do codigo.

## 2. Modelo De Protecao Por Areas

### 2.1 Niveis

Os niveis identificam camadas independentes; nao precisam esperar pelo backup
de Docker para serem implantados.

| Nivel | Conteudo | Prioridade | Situacao proposta |
| --- | --- | --- | --- |
| B0 | Inventario, versoes publicadas, mounts, dependencias e manifestos dos conjuntos | Imediata | Preparar antes da primeira copia |
| B1 | Bancos SQL de todos os aplicativos e da inteligencia operacional | Critica | Primeira implementacao |
| B2 | Arquivos de negocio selecionados e vinculados aos bancos | Critica | Implementar junto de B1 |
| B3 | Chaves, cofres, configuracoes privadas e certificados | Critica | Implementar junto de B1/B2 |
| B4 | Telemetria historica e outros dados operacionais reconstruiveis | Seletiva | Adiar, exceto evidencias de incidentes |
| B5 | Imagens Docker, caches de build e snapshot integral da VPS | Posterior | Nao implementar agora |

B1 sem B2/B3 nao representa recuperacao completa. Um banco pode voltar
corretamente e ainda apontar para fotos, XMLs ou credenciais que foram perdidos.

### 2.2 Politicas Reutilizaveis

O catalogo de perfis candidatos esta na secao 2 do mapa de dados:
`SQL_ESSENCIAL`, `ARQUIVOS_ESSENCIAIS`, `SEGREDOS_ESSENCIAIS`,
`CONFIGURACAO_ESSENCIAL`, `EVIDENCIA_SELETIVA`, `RECONSTRUIVEL`,
`TEMPORARIO` e `IMAGENS_ADIADAS`.

Cada politica define uma vez o metodo de captura aplicavel, frequencia,
retencao, destino, restricoes e prova de recuperacao exigida. As areas somente
referenciam essa politica. Nao repetir a agenda em appsettings de cada API,
Worker, Studio ou tarefa Python. A secao 4 define os parametros operacionais
iniciais propostos, que ainda precisam ser aprovados e medidos.

Politicas distintas podem participar da mesma janela coerente; isso nao cria
um backup separado por aplicativo. Uma captura pode proteger varias areas e
atender varios conjuntos de restauracao sem duplicar a copia dos mesmos dados.

### 2.3 Cadastro De Areas Do Ambiente

A implementacao futura tera configuracao versionada em `infra/backups`, nao
uma nova tabela de negocio nem um servico de cadastro. O registro de cada area
deve conter somente o necessario para resolver sua protecao:

| Dado | Responsabilidade |
| --- | --- |
| AreaId, aplicativo/dono e ambiente | Identificar sem depender do path fisico |
| Tipo e localizador efetivo | Catalogo SQL ou origem de arquivos, resolvidos a partir da configuracao real |
| PolicyId | Reutilizar uma definicao, sem copiar seus parametros |
| Dependencias de restore | Indicar bancos, arquivos, chaves e configuracoes que precisam voltar coerentes |
| Privacidade e escritores | Conferir mounts, acesso, parada/drenagem e ausencia de rota publica indevida |
| Presenca esperada | Diferenciar obrigatorio em uso, opcional justificado e legado sem uso comprovado |

As configuracoes de conexao e storage continuam sendo a fonte do destino
efetivamente usado pelo aplicativo. O cadastro de backup deve referenciar ou
conferir esse destino, nao criar uma segunda escolha independente. Divergencia
entre o bind do aplicativo, mount e area capturada e falha de cobertura.

Estado de captura, datas e provas de restore sao resultados privados da
operacao, nao flags editaveis no cadastro para simular cobertura. Registrar
versao da politica e do cadastro em cada SetId; restauracao usa esse registro
historico, nunca pressupoe que o path atual e o mesmo do backup antigo.

### 2.4 Vinculo Do Aplicativo

| Lugar | Conteudo permitido |
| --- | --- |
| DSL do aplicativo, quando a geracao precisar conhecer o recurso | Referencia logica de area; sem implementar agenda ou job |
| Configuracao de aplicativo/ambiente | Bind da referencia ao storage, cofre ou catalogo existente |
| Infraestrutura de backup | Definicoes das politicas, selecao das areas, captura, envio, retencao e restore |

Tabela nova entra no backup integral do banco sem configuracao por entidade.
Arquivo ou subpasta nova entra no proximo ciclo da area, sem cadastro por item.
Area ou banco fisico novo exige apenas adesao a uma politica ja suportada e
validacao de cobertura. Tecnologia nova de persistencia ainda exige comprovar
seu procedimento de captura uma vez; nao fingir que backup de mensagens e
igual a copia de arquivos.

Na futura entrega de backup, aproveitar `StorageLocation`, `Storage:Locations`, raizes
dos stores e os binds atuais. Nao introduzir uma DSL paralela nem configurar
backup por coluna, tenant ou status de saga. A referencia estatica na Engine
entra apenas na etapa P8, se houver geracao a padronizar, depois de demonstrar
o vinculo com as configuracoes existentes.

### 2.5 Regra Para Novos Dados

```text
Reutiliza banco/area existente -> herda politica, sem alterar a rotina
Nova area no ambiente -> escolhe politica, valida bind e comprova cobertura
Nova tecnologia -> aprova procedimento suportado antes de prometer protecao
```

Para preparar uma area vazia, testar captura/restore com dados sinteticos,
isolados e sem credenciais reais; depois acompanhar a primeira captura real.
Nao exigir um novo ensaio manual a cada foto, documento, tabela ou tenant.
Alteracao de path, chave, provider ou metodo exige nova verificacao direcionada.

Herdar a estrategia nao significa copia imediata: um arquivo criado depois da
ultima captura fica sujeito ao intervalo/RPO combinado ate o proximo ciclo.
Nao consultar o ultimo backup no caminho quente de uploads ou commands.

### 2.6 Persistente Privado: Padrao Simplificado Aprovado

Decisao confirmada em 2026-10-19; implantacao ainda pendente. O padrao e
armazenar credenciais tecnicas recuperaveis em arquivos privados fora do Git,
das imagens Docker e das rotas publicas. Nao criar uma camada generica de
criptografia/descriptografia para esses arquivos de configuracao.

Senha SQL, credenciais do broker e chaves de integracao podem permanecer em
texto no arquivo privado, com leitura restrita aos processos autorizados.
O Compose versionado guarda referencias, nunca os valores. Entrega por arquivo
ou ambiente continua respeitando o suporte atual do consumidor; variavel de
ambiente em execucao nao e criptografada e pode aparecer em inspecao/log indevido.

Na implementacao, conferir dono, UID/GID, permissoes de arquivos/diretorios e
mounts por servico; somente leitura quando o consumidor nao precisa escrever.
O gateway e outros aplicativos nao recebem acesso ao conjunto inteiro por
conveniencia. Nao aplicar chmod recursivo indiscriminado sobre SQL ou storage.
Essa restricao segue o principio de menor privilegio da
[OWASP](https://cheatsheetseries.owasp.org/cheatsheets/Secrets_Management_Cheat_Sheet.html#23-access-control).

A cifra ja existente do Memorias e preservada como formato interno do app,
nao um modelo adicional a impor aos outros hosts. Nao decifrar arquivos em
massa, remover AES, alterar key.bin ou gerar chave substituta para dados ja
gravados. Certificados/PFX e outros formatos protegidos existentes tambem
permanecem intactos. Essa decisao nao muda o armazenamento de autenticacao
das senhas dos usuarios nem dispensa TLS.

O deploy reutiliza a configuracao privada provisionada. Criacao inicial e
rotacao sao operacoes explicitas, nao recriacao de segredos a cada publicacao.
Externalizar valores ja versionados exige rotacao coordenada posteriormente;
apagar um valor do Compose nao revoga copias presentes no historico.

Backup da area privada continua cifrado, com acesso restrito e credencial de
recuperacao tambem fora da VPS. Permissoes nao cifram os arquivos nem protegem
contra administrador/invasor com controle total do host ou leitura direta do
disco. Esse limite e aceito para a primeira etapa; nao declarar um cofre externo
ou protecao contra comprometimento completo que nao foram implementados.

## 3. Inventario Inicial

O inventario e a lista inicial de adesao ao modelo, nao uma lista permanente
de tarefas individuais. Sua classificacao detalhada e os IDs das areas estao
no mapa de dados. Confirmar os destinos no servidor antes de ativar a captura.

### 3.1 Bancos Declarados

Os nomes atuais de `infra/docker/deploy.env` sao:

| Banco | Dados que precisam voltar |
| --- | --- |
| YESHUA_CENTRAL | Tenants, usuarios, concessoes, identidades globais, sequencias e autorizacao |
| YESHUA_CLINICA | Dados clinicos, financeiros e estado dos processos |
| YESHUA_APS_ADM | Cadastros, pedidos, cargas e estado dos processos |
| YESHUA_FISCAL | Documentos, protocolos, planos, referencias de arquivos e estado dos processos |
| YESHUA_MEMORIAS | Albuns, fotos, vinculos, publicacoes, canais e estado dos processos |
| YESHUA_OPERATIONAL_INTELLIGENCE | Indice de fontes, historico e demais dados operacionais persistidos |

Cobrir cada banco inteiro, incluindo tabelas Y, `MigrationVersion`, ledger de
autorizacao, identidades e sequencias. Nao selecionar apenas tabelas de negocio.

Confirmar tambem bancos antigos como `Context_CLINICA` e quaisquer bancos fora
dessa lista. Um banco descoberto nao e apagado, ignorado nem substituido
automaticamente: registrar se esta ativo, historico ou descartavel.

Proteger `master`, `msdb` e `model` em backups proprios, especialmente apos
alteracoes de instancia. Inventariar logins, SIDs, jobs, certificados e chaves
SQL quando existirem. A restauracao desses bancos de sistema exige roteiro
especifico e compatibilidade de versao; nao sera parte de um restore generico
de banco de aplicativo. `tempdb` e recriado e nao recebe backup.

### 3.2 SQL E Diretorios Do Host

| Origem declarada | Funcao | Tratamento |
| --- | --- | --- |
| /root/YeshuaDB/persistent/sql | Dados da instancia SQL; mount de /var/opt/mssql | Backup nativo .bak/.trn; nao copiar MDF/LDF ativos como backup |
| /root/YeshuaStorage/persistent/memorias/photos | Fotos originais | Obrigatorio |
| /root/YeshuaStorage/persistent/memorias/publicacoes | Manifestos e videos; arquivos de retomada referenciam esses bytes | Obrigatorio inicialmente |
| /root/YeshuaStorage/persistent/memorias/music | Musicas versionadas | Reconstituivel do Git somente se chaves e hashes coincidirem; preservar adicionais locais |
| /root/YeshuaStorage/persistent/docs e persistent/Docs | Configuracao usa docs; bootstrap cria Docs, caminhos diferentes no Linux | Inventariar e incluir os caminhos em uso, sem renomear automaticamente |
| /root/YeshuaStorage/volatile/ia/transcriptions e volatile/reports | Audios, entradas e resultados potencialmente unicos | Proteger inicialmente o conteudo essencial; volatile nao comprova descartabilidade |
| /root/YeshuaStorage/fiscal | Planos de emissao, certificados PFX e arquivos de senha | Obrigatorio e restrito; fica fora de persistent |
| /root/YeshuaStorage/sefaz | Artefatos XML de comunicacao fiscal | Obrigatorio; fica fora de persistent |
| /root/YeshuaMemoriasSecrets | Cofre OAuth, configuracao cifrada, chaves, sessoes de envio e recibos | Obrigatorio e restrito |
| /root/YeshuaDB/persistent/config | module-auth.env, memorias-youtube.env e configuracoes privadas | Obrigatorio e restrito |
| /etc/letsencrypt | Certificados HTTPS, chaves e configuracao de renovacao | Incluir preservando links e permissoes; alternativa de reemissao deve ser documentada |
| /root/YeshuaCreator/infra | Compose, scripts, rotas e arquivos locais de implantacao | Registrar commit e preservar diferencas locais necessarias, inclusive arquivos ignorados |
| /root/YeshuaDB/persistent/telemetry | Grafana, Loki, Tempo e Prometheus | B4; nao arquivar o diretorio ativo sem procedimento proprio |

Confirmar o destino de cada `StorageKey`, inclusive arquivos em localizacoes
antigas, provider diferente ou dentro da camada gravavel de containers.
Dados de negocio encontrados somente dentro de container sao uma lacuna
critica de persistencia, mesmo que ainda nao se faca backup de imagens.

Os endpoints customizados `/upload` de Clinica e APS gravam no diretorio
`uploads` relativo ao processo, sem mount especifico declarado. Confirmar uso
e conteudo no servidor; preservar originais existentes antes de recriar esses
containers e planejar seu bind para area protegida. A correcao nao foi feita.

Nao excluir todos os MP4: um video pode ter hash/tamanho vinculado a uma sessao
resumable. Regenerar um video visualmente parecido nao garante bytes iguais.
Backup de video no YouTube tambem nao substitui as fotos originais.

### 3.3 Exclusoes Propostas

Exclusoes sao especificas e aprovadas apos inventario, nunca deduzidas somente
pelo nome `volatile`, `temp` ou `output`.

| Item | Regra |
| --- | --- |
| Temporarios .render-* do FFmpeg | Excluir apenas os temporarios da tentativa; preservar manifest.json e video.mp4 final |
| Temporarios .tmp de escrita atomica | Excluir apos confirmar escritores parados e arquivo final existente |
| Locks de processo | Nao representam trabalho concluido nem credencial; nao restaurar lock ativo como estado de negocio |
| volatile/ia e volatile/reports | Excluir somente se todos os resultados forem reproduziveis e nao contiverem o unico audio/documento original |
| bin, obj, caches NuGet/pip/modelos e camadas de build | Reconstruir; modelos privados nao recuperaveis precisam de classificacao separada |
| Logs brutos Docker e telemetria rotativa | Fora da rotina essencial; preservar recorte de incidente antes de limpeza |
| Redis | Tratar como cache somente depois de confirmar o uso real; outro uso muda a decisao |
| Volumes operational-agent-* | Reconstruir ambiente e reautenticar ferramentas; preservar trabalho exclusivo nao enviado ao Git caso exista |

Diretorios desconhecidos ficam como pendencia visivel. Uma origem obrigatoria
ausente ou ilegivel impede classificar o conjunto como completo. Uma origem
opcional ausente deve aparecer no relatorio, sem ser silenciosamente ignorada.

### 3.4 Filas E Integracoes Externas

O Compose atual nao declara mounts de persistencia para Redis e RabbitMQ.
Confirmar os mounts reais: a imagem pode usar volume anonimo, que tambem nao
constitui politica de backup e restauracao controlada.

Exportar definicoes do RabbitMQ para registrar topologia, usuarios e politicas,
em arquivo restrito. Definicoes nao incluem mensagens. A documentacao do
[RabbitMQ distingue definicoes de mensagens e exige broker parado para copiar
o armazenamento de mensagens](https://www.rabbitmq.com/docs/backup).

Nesta primeira fase nao prometer recuperacao das mensagens pelo broker.
Inventariar filas, mensagens prontas, nao confirmadas e tarefas em execucao em
cada conjunto. Um backup consistente dos arquivos e SQL nao resolve sozinho
uma entrega que so existia na fila.

No Memorias, o renderer usa ACK antecipado. Uma tarefa aceita pode desaparecer
sem retorno se o processo cair. Inbox/Outbox/Saga e recibos ajudam a investigar,
mas nao autorizam republicar automaticamente mensagens ou marcar etapas como
concluidas. Essa lacuna permanece explicita ate um ensaio comprovar o caminho
de recuperacao.

## 4. Agenda Das Politicas E Retencao

RPO significa quanto trabalho pode ser perdido. RTO significa quanto tempo
podemos levar para recuperar. Ambos sao metas a validar com medicao, nao SLAs
ja entregues.

| Conjunto | Frequencia inicial proposta | RPO inicial pretendido |
| --- | --- | --- |
| B1+B2+B3 coerentes | Diario, em janela de manutencao combinada | Ate 24 horas, acrescidas de eventual atraso da copia externa |
| Extraordinario B1+B2+B3 | Antes de migration, upgrade relevante ou operacao destrutiva | Ponto validado anterior a mudanca |
| Configuracoes/chaves | Apos mudanca, vinculadas ao conjunto e a versao | Recuperar a configuracao correspondente aos dados |
| SQL logs, evolucao da recuperacao | A cada 15 minutos nos bancos elegiveis, apos ensaio | Meta SQL de 15 minutos; nao estende essa garantia aos arquivos/filas |
| B4 | Sob demanda por incidente | Aceitar perda do historico rotativo fora do recorte salvo |
| B5 | A definir apos estabilizacao | Nenhuma garantia de imagem/VPS nesta fase |

Esses parametros pertencem a definicao central das politicas, nao a cada area.
A agenda seleciona as areas aderentes a cada politica e agrupa a captura pelas
dependencias de consistencia. Uma area nova com a mesma politica nao recebe
outro script, outro cron ou outra regra de retencao.

A rotina diaria exige aceitar a perda potencial de ate um dia de dados. Se
isso nao for aceitavel, reduzir o intervalo antes de liberar a politica.
Medir espaco, duracao e transferencia antes de escolher o horario definitivo.

Retencao proposta: 7 conjuntos diarios, 4 semanais e 3 mensais. Manter o ultimo
conjunto comprovadamente restaurado, mesmo se houver falha na rotina seguinte.
Exclusao de snapshots respeita dependencias: manter cada full e todos os logs
necessarios a cada ponto preservado. Retencao fiscal/legal de documentos e uma
politica distinta; os prazos de backup nao autorizam apagar dados de negocio.

RTO inicial para exercicio: 4 horas para Central + um aplicativo e 8 horas para
o ambiente de negocio, contando obtencao dos arquivos e reconciliacao externa.
Esses numeros sao hipoteses de planejamento. Sem imagens preservadas, builds
e downloads tambem entram no tempo e podem impedir essas metas.

Guardar uma copia local recente e uma copia fora da VPS. Preferir que a copia
externa tenha protecao contra exclusao pela credencial usada no servidor;
escolher e testar a compatibilidade dessa protecao com a ferramenta de backup.
Snapshots ou outro disco da mesma VPS nao cobrem perda do servidor/provedor.

## 5. Organizacao E Ferramentas

Na futura implementacao, separar configuracao declarada de resultado executado:

```text
infra/backups/                         # proposta; ainda nao criado
  policies.json                       # perfis compartilhados, sem segredos
  areas.<ambiente>.json                # vinculos e selecao por ambiente
  README.md                           # operacao e uso das ferramentas existentes
```

Esses JSONs serao configuracao da rotina de infraestrutura, nao outra DSL de
dominio ou um registro consultado em runtime pelos aplicativos. Resolver binds
atuais sem copiar connection strings/segredos; inventario resolvido sensivel
e resultados ficam fora do Git. O formato exato sera validado na etapa P4.
Nao ha esses arquivos nem suporte de leitura implementado por este plano.

Usar uma area privada fora do Git e fora de qualquer caminho servido pelo
Nginx, por exemplo:

```text
/root/YeshuaBackups/
  staging/<SetId>/
    sql/
    files/
    private/
    metadata/
  reports/
  restore-tests/
```

`SetId` identifica um conjunto, por exemplo
`PRODUCTION_20261017T030000Z`. Os horarios do manifesto usam UTC; registrar
tambem o fuso da agenda operacional, `America/Sao_Paulo`.

No mount atual, SQL pode gravar inicialmente em `/var/opt/mssql/backup`, que
corresponde a `/root/YeshuaDB/persistent/sql/backup` no host. Esse e somente
staging e compartilha o disco do banco. A copia precisa sair dali e chegar ao
destino externo. Validar UID/GID, permissoes e espaco antes de usar essa pasta.

Restic e a proposta para armazenar snapshots seletivos e transferir os dados.
O mesmo programa permite listar e recuperar um snapshot identificado e
[verificar seu repositorio](https://restic.readthedocs.io/en/stable/010_introduction.html).
Precisamos escolher destino, credencial e senha de recuperacao na implantacao.
Guardar a senha/chave de recuperacao tambem fora da VPS e fora do proprio
repositorio cifrado; testar o acesso em outra maquina.

O manifesto de cada conjunto deve registrar:

- SetId, host, ambiente, autor/rotina e versao da politica de selecao.
- IDs das areas e politicas selecionadas, revisao de suas definicoes e binds
  efetivos capturados; guardar copia recuperavel dessas definicoes no conjunto.
- Areas esperadas versus capturadas e excecoes justificadas; nao transformar
  politica ausente em TEMPORARIO nem aceitar selecao vazia como sucesso.
- Tipo: SQL isolado, arquivos isolados ou conjunto coerente B1+B2+B3.
- Horario da pausa, inicio/fim das capturas e momento da liberacao.
- Bancos esperados, bancos encontrados, estado, recovery model e versao SQL.
- Arquivos .bak/.trn, tamanhos, hashes, tipo, checksum e LSNs quando aplicavel.
- Origens incluidas/excluidas, contagens, bytes e falhas de leitura.
- Commit e identidade da imagem realmente executada por aplicativo; nao apenas
  o HEAD do clone do servidor. Registrar versao SQL/FFmpeg e digests disponiveis.
- Referencias das configuracoes, chaves e cofres que pertencem ao conjunto.
- Snapshot externo exato, resultado da checagem e ultima prova de restauracao.
- Estado das filas e operacoes externas pendentes, sem payloads ou tokens.

Manifesto e inventario detalhado tambem sao privados. O relatorio de aviso
contem somente resultado, SetId, datas, volumes e referencias seguras.

## 6. Politica De Banco De Dados

1. Fazer backup SQL nativo completo, um banco por vez, com `CHECKSUM` e
   `STOP_ON_ERROR`. Usar `COMPRESSION` apos confirmar suporte e impacto na CPU.
2. Adotar nomes unicos por banco/conjunto. Nunca sobrescrever a unica copia boa.
3. Na rotina, usar full convencional. Para copia extraordinaria que nao deve
   interferir em uma rotina existente, avaliar full `COPY_ONLY`: ele nao altera
   a base diferencial nem serve como base para diferenciais, conforme a
   [documentacao da Microsoft](https://learn.microsoft.com/en-us/sql/relational-databases/backup-restore/copy-only-backups-sql-server).
4. Validar cada arquivo com `RESTORE VERIFYONLY ... WITH CHECKSUM,
   STOP_ON_ERROR`; falha de qualquer banco obrigatorio reprova o conjunto.
5. Provar a restauracao em instancia isolada, com `DBCC CHECKDB` e verificacoes
   funcionais. VERIFYONLY confirma leitura/completude, mas nao valida toda a
   estrutura dos dados, como esclarece a
   [Microsoft](https://learn.microsoft.com/en-us/sql/t-sql/statements/restore-statements-verifyonly-transact-sql).
6. Preservar o recovery model atual nesta primeira rodada. Banco em FULL
   precisa de rotina de backup de log e monitoramento; nao deixar o log crescer
   indefinidamente nem troca-lo para SIMPLE por conveniencia. Confirmar essa
   rotina no inventario P2 e na captura P3; sua ausencia impede agendar uma
   politica somente de fulls. P9 aperfeicoa a recuperacao por horario e comprova
   o RPO, mas nao adia a manutencao dos logs de bancos que ja estao em FULL.
7. Para recuperar horarios intermediarios, implantar e testar full + sequencia
   de logs sem lacunas. A restauracao utiliza `NORECOVERY` durante a sequencia
   e `RECOVERY` no fim; a
   [documentacao de restauracao completa](https://learn.microsoft.com/en-us/sql/relational-databases/backup-restore/complete-database-restores-full-recovery-model)
   descreve essa dependencia. Essa capacidade fica pendente ate o ensaio.
8. Se houver TDE ou backup SQL cifrado, incluir certificados e chaves privadas
   necessarios para abrir a copia em outra instancia. Banco .bak sozinho nao
   basta nesse caso.

Nao copiar `/var/opt/mssql` ativo como alternativa ao .bak. Nao usar script de
migration como recuperacao de dados. Migration cria/evolui estrutura; restore
devolve dados, sequencias e historico do ponto escolhido.

## 7. Roteiro De Backup Seguro

### 7.1 Preparar Uma Vez

1. Aprovar politicas reutilizaveis e escolher destino externo, acesso de
   recuperacao, janela, limites e responsaveis. Vincular areas antes de criar
   rotinas; nao criar politica por arquivo ou tabela.
2. Confirmar o inventario do servidor e reconciliar os seis bancos declarados
   com todos os bancos encontrados. Identificar leitores/escritores externos,
   inclusive testes locais Windows usando os mesmos bancos remotos.
3. Converter o inventario confirmado em areas aderentes e excecoes visiveis,
   com tamanho, mounts, politica e dependencias. Manter caminhos existentes
   quando seguros; nao assumir que somente persistent contem dados importantes.
4. Testar repositorio externo, credencial, criptografia, envio e
   recuperacao de um arquivo ficticio. Documentar quem recupera senha/chave.
5. Reservar disco para .bak, staging de arquivos e margem operacional. Simular
   selecao e estimar volume antes de qualquer copia de toda a midia.
6. Capturar versoes efetivas, configuracao de firewall/DNS e arquivos privados
   necessarios. Nao salvar saida integral de `docker inspect`, `env` ou Compose
   expandido em relatorio publico: essas saidas podem conter segredos.
7. Simular a selecao a partir das areas/politicas e conferir que nenhuma origem
   obrigatoria ficou fora. Definir avisos e criterio de abortar; a primeira
   captura e manual e acompanhada, e agendamento vem depois do restore.

### 7.2 Executar Um Conjunto Coerente

1. Selecionar as areas pela politica e pelo conjunto coerente. Fixar revisao
   de configuracao, resolver destinos e rejeitar divergencias/mounts ausentes.
   Criar SetId e manifesto em estado INICIADO. Obter lock para impedir backup
   concorrente e usar o mesmo lock global do deploy durante a captura; reconferir
   os binds sob o lock antes de pausar os servicos.
2. Conferir ultimo conjunto valido, disponibilidade do destino, espaco livre e
   estado SQL. Falha de pre-condicao encerra sem modificar o ambiente.
3. Para muita midia, fazer uma pre-copia local seletiva antes da janela. Ela
   ainda nao e um backup consistente nem deve receber estado de sucesso.
4. Fechar novas entradas e drenar tarefas em andamento com prazo definido.
   Pausar APIs, workers, renderer, importadores e demais escritores. Esta
   manutencao precisa considerar tambem acessos fora dos containers.
5. Registrar filas e tarefas pendentes. Se houver trabalho externo ambiguo,
   registrar a limitacao e nao declarar recuperacao automatica desse trabalho.
6. Confirmar que os escritores estao parados. Manter SQL ligado e executar os
   backups completos dos bancos selecionados, sequencialmente.
7. Capturar arquivos e cofres da mesma janela. Na pre-copia, sincronizar agora
   criacoes, alteracoes e exclusoes somente no staging do SetId. Qualquer
   remocao deve validar o destino absoluto e nunca atingir a origem publicada.
8. Preservar modos, proprietarios, links e datas. Validar arquivos apontados
   pelos bancos e conservar caminhos internos como `/storage` e
   `/memorias-secrets`; ha referencias absolutas em dados fiscais.
9. Selar a captura local: nenhuma alteracao posterior no staging desse SetId.
   Validar bancos e completude dos arquivos. Gravar capturas aprovadas como
   CAPTURADO_LOCAL, nao como backup externo concluido.
10. Liberar os servicos que estavam ativos antes da pausa, na ordem planejada,
    e confirmar saude. Nao iniciar por engano um servico que ja estava parado.
    A falha do backup tambem precisa deixar um estado operacional conhecido;
    falha de retomada exige alerta imediato, sem mascarar o erro original.
11. Enviar a captura selada ao repositorio externo, gravar snapshot exato e
    verificar o resultado. Somente entao marcar COPIADO_EXTERNO.
12. Emitir relatorio. Limpeza/retencao e uma etapa separada, somente depois de
    validar outra copia boa. Nunca executar prune junto de deploy ou render.

A pausa dura a captura local, nao necessariamente a transferencia externa.
Sem snapshot de filesystem, a primeira copia pode ser demorada e exigir disco
significativo. Se a medicao nao couber na janela, revisar a captura antes de
agendar; nao chamar uma copia de arquivos mudando de snapshot consistente.

Backups online por banco podem complementar a rotina sem parar a aplicacao,
mas sao rotulados SQL_ISOLADO. Fulls sequenciais com escritores ativos nao
oferecem, por si, um ponto global coerente entre Central, aplicativos e arquivos.

### 7.3 Adesao De Um Recurso Sem Nova Estrategia

1. Identificar se o recurso reutiliza um banco/area existentes. Se reutilizar,
   manter a politica da area e a proxima captura regular, sem cadastrar itens.
2. Se exige area nova, escolher perfil existente, bind, dono, privacidade e
   dependencias de restore. Nao abrir um cron ou script especifico do app.
3. Conferir mount, paths e todos os escritores, inclusive Python. Se a area
   esta vazia, provar com dados sinteticos antes de receber dados de negocio.
4. Incluir na selecao compartilhada, executar captura externa/restore inicial
   e registrar evidencia. Configurar monitoramento de idade e falhas dessa area.
5. Para legado em caminho incorreto, primeiro preservar o estado existente;
   depois alterar bind/migrar por aplicativo, com validacao e retorno possivel.
   Nenhum movimento de arquivos ou recriacao de container e implicito.

Se um recurso novo cabe em area existente, essa lista termina no passo 1;
apenas respeitar os limites/contratos ja definidos e o ciclo normal. Ela nao
introduz consulta ao backup em cada escrita nem confirma RPO zero.

## 8. Plano De Checagem

Separar validacao da adesao e prova da captura. Validacao estatica confere o
vinculo configurado; somente captura externa e restore demonstram recuperacao.

| Momento | Verificacao | Criterio |
| --- | --- | --- |
| Antes | Inventario, acessos, espaco e ausencia de concorrencia | Todas as origens obrigatorias identificadas e legiveis |
| Ao vincular area/banco | Politica conhecida, bind/mount, ambiente, privacidade e dependencias | Nenhum dado essencial so no container nem politica desconhecida aceita |
| Apos alterar configuracao de persistencia | Comparar destinos de todos os escritores com a selecao capturada | Nenhuma area silenciosamente deslocada ou omitida |
| Em cada captura | Resultado SQL, tamanhos, checksums, contagens e exclusoes | Nenhum erro ignorado nem banco silenciosamente ausente |
| Em cada envio | Snapshot externo e leitura de um item pequeno recuperado | Copia externa identificada e acessivel |
| Diario | Idade do ultimo conjunto completo externo e estado da agenda | Alertar se nao houver copia concluida dentro do RPO combinado |
| Semanal | Integridade do repositorio e leitura de uma parcela dos dados | Planejar cobertura integral ao longo do ciclo, nao somente a mesma amostra |
| Semanal | Restore real de um banco em rodizio e arquivos associados | CHECKDB aprovado e correspondencia banco/arquivo |
| Mensal | Restauracao integrada de Central e aplicativos | Todos os bancos cobertos e fluxos funcionais verificados |
| Apos mudanca que afete formato/chave ou procedimento de recuperacao | Novo ensaio direcionado | Abrir dados e cofres com a versao correta |
| Trimestral | Exercitar perda da VPS em destino separado | Medir recuperacao usando somente copias externas e kit de acesso |

O futuro validador de adesao comeca em modo relatorio para o legado, sem
reescrever o deploy. Apos aprovar as regras, recursos/areas novos e alterados
nao podem ser aceitos como protegidos com vinculos invalidos. Pendencia antiga
continua visivel; emitir aviso nao equivale a certificar o ambiente inteiro.
Esta validacao e evidencia de cobertura, nao nova classificacao de codigo.

Adicionar tabela ao banco coberto ou arquivo dentro de area existente nao
cria um restore manual por item. Manter os testes normais de schema/aplicativo,
a captura integral e os ensaios periodicos; repetir prova direcionada quando
a mudanca afetar o mecanismo, a chave ou a compatibilidade da recuperacao.

Para restic, `check` e a leitura dos dados sao verificacoes distintas; usar os
modos previstos na [documentacao do repositorio](https://restic.readthedocs.io/en/stable/045_working_with_repos.html).
Deduplicacao nao elimina a necessidade de provar a leitura e o restore.

Verificacoes de negocio do ensaio:

- Login na Central e abertura de um aplicativo, com tenant/usuario globais
  preservados. Confirmar sequencias acima dos IDs existentes; nunca reinicia-las.
- Consulta de cadastros e registros conhecidos, sem recalcular estados por migration.
- Foto original recuperada e hash conferido; album e vinculos correspondentes.
- Manifesto e video recuperados com tamanho/hash esperados pela publicacao.
- Leitura local do cofre com a chave e ProcessingScope corretos; comprovar
  sucesso sem exibir tokens, senhas ou chaves nem chamar o Google.
- Localizacao de XML/protocolo e certificado referenciados pelo Fiscal.
- Relacao entre sagas, steps, Inbox e Outbox sem liberacao automatica de efeitos.

O laboratorio usa instancia/rede/storage separados, sem escritores publicados,
sem saida para SEFAZ, YouTube, callbacks, email ou filas de producao. Trocar
ProcessingScope cegamente pode impedir abrir o cofre; preservar o valor
necessario dentro do laboratorio isolado, com rede e processos controlados.

Checagem de saude sozinha nao comprova restauracao. Guardar SetId, snapshot,
versao, checks executados, tempos e resultado do ensaio.

## 9. Roteiros De Restauracao

Entrada comum para os tres roteiros: identificar aplicativo/ambiente/AreaId e
SetId, consultar os binds e dependencias guardados naquele conjunto, recuperar
para destino alternativo e aplicar o procedimento da politica correspondente.
Nao escolher automaticamente o path da configuracao mais recente para um backup
antigo. Para segredo/cofre, recuperar tambem a chave/identidade compativel.

Politica RECONSTRUIVEL usa sua receita/versao comprovada; TEMPORARIO nao promete
conteudo recuperavel; IMAGENS_ADIADAS continua sem garantia de imagem. Esses
resultados devem ficar claros ao operador antes de qualquer substituicao.

### 9.1 Recuperar Arquivo Ou Registro Excluido

1. Identificar aplicativo, tenant, instante e conjunto anterior ao erro.
2. Recuperar o snapshot para diretorio alternativo. Nunca extrair inicialmente
   por cima de `/root/YeshuaStorage` ou do cofre ativo.
3. Conferir caminho, hash e registro que aponta para o arquivo. Guardar a
   versao atual antes de qualquer substituicao.
4. Para recuperar linhas SQL, restaurar o banco inteiro em instancia auxiliar
   e planejar a reintroducao pelos caminhos de negocio apropriados. Nao trocar
   um banco inteiro apenas para recuperar uma linha sem avaliar o trabalho novo.
5. Aplicar correcao em janela delimitada e verificar a leitura pelo aplicativo.
   Retencao do backup nao autoriza recuperar dados de outro tenant.

### 9.2 Recuperar Um Banco Ou Aplicativo

1. Pausar suas entradas e executores. Identificar dependencias com Central e
   outros aplicativos antes de escolher um ponto de retorno.
2. Preservar o estado atual e as evidencias. Se for viavel e houver cadeia de
   log, avaliar tail-log com responsavel SQL antes de substituir o banco.
3. Escolher SetId e versao de codigo compativeis. Restaurar primeiro em destino
   alternativo, validando .bak e nomes logicos com FILELISTONLY.
4. Restaurar arquivos/cofre correspondentes e conferir referencias. Segredos
   revogados depois do backup continuam revogados no provedor externo.
5. Executar CHECKDB e o ensaio funcional. So entao planejar a troca para o
   banco recuperado. Sobrescrita em producao e decisao explicita, nunca default.
6. Reconciliar fatos externos e integracoes. Restaurar somente APS ou Fiscal
   pode voltar o estado local para antes de um evento que o outro ja aplicou.
   Restaurar a Central isoladamente pode retroceder concessoes e sequencias:
   comparar IDs globais de todos os aplicativos antes de permitir novas contas.
7. Liberar execucao e escritas por etapas, acompanhando duplicacoes e falhas.

### 9.3 Recuperar O Servidor Completo

| Passo | Acao | Condicao para seguir |
| --- | --- | --- |
| 1 | Identificar o incidente e conter o servidor anterior | Impedir dois ambientes escrevendo/publicando em paralelo |
| 2 | Escolher o conjunto e obter acesso/chaves fora da VPS | Snapshot legivel e kit de recuperacao disponivel |
| 3 | Preparar Linux, disco, Docker e acesso restrito no novo destino | Capacidade, permissoes e versoes registradas |
| 4 | Obter o commit do conjunto e configuracoes privadas | Sem atualizar para main automaticamente |
| 5 | Restaurar staging em area alternativa e verificar | Origem intacta e dados legiveis |
| 6 | Preparar mounts e subir somente SQL e dependencias estritamente necessarias | APIs/workers/renderer ainda desligados |
| 7 | Restaurar bancos, arquivos e cofres | Mesmo conjunto logico, paths internos e identidades preservados |
| 8 | Restaurar logins/configuracoes SQL necessarios de forma controlada | Sem restore cego de master/msdb de outra versao |
| 9 | Recriar rede, cache e topologia do broker | Lacunas de mensagens registradas e reconciliadas |
| 10 | Preparar imagens do codigo compativel e validar banco/schema | Sem disparar migrations de atualizacao antes da verificacao |
| 11 | Subir API Central, APIs e Front sob acesso restrito | Conferir login, menus, leitura e referencias de arquivos |
| 12 | Reconciliar efeitos externos e liberar executores gradualmente | Nenhuma reemissao fiscal/upload/reenvio ambiguo automatico |
| 13 | Configurar HTTPS, Nginx e acesso publico | nginx -t, rotas e certificados aprovados |
| 14 | Conferir DNS e liberar trafego | Origem antiga contida e operador acompanhando |
| 15 | Fazer novo backup e registrar o incidente/tempos | Rotina protegendo o ambiente recuperado |

O `setup.sh` atual termina executando deploy de todos os aplicativos. O
`deploy.sh` pode atualizar o Git e executar migrations antes de iniciar os
servicos. Portanto eles nao sao o primeiro comando deste roteiro de restore.
Sera necessario um procedimento controlado de preparacao/subida dos servicos
existentes; ele nao foi implementado neste planejamento. Nao rodar o deploy
padrao ate comprovar o conjunto e aprovar eventual atualizacao de schema.

Restaurar SQL primeiro com a mesma versao/build compativel documentada. Evitar
usar a tag `latest` como identificacao do ambiente recuperado. Sem imagens
preservadas ou dependencias fixadas, registrar risco de rebuild diferente.

### 9.4 Revisao Antes De Religarmos Workers

Backup nao desfaz acontecimentos externos. A SEFAZ pode ter autorizado um
documento e o YouTube pode ter aceitado um video depois do ponto restaurado.

1. Separar concluidos confirmados, pendentes seguros e resultados ambiguos.
2. Conferir protocolos/XMLs, recibos de upload, IDs externos e dados de
   correlacao antes de emitir novo pedido.
3. Quando necessario, consultar o provedor por operacao controlada e autorizada.
   Nunca usar a simples falta de retorno local como prova de que nada aconteceu.
4. Retomar pelo fluxo de commands/receivers existente. Nao zerar Status,
   ProcessingScope, contadores, locks ou IDs em massa para fazer a fila andar.
5. No Memorias, preservar o mesmo arquivo, hash e destino da sessao resumable;
   sessao expirada ou resultado ambiguo exige revisao, sem upload cego.
6. No Fiscal, confirmar autorizacao/evento antes de qualquer reemissao. No
   APS/Fiscal, conferir tambem o retorno entre modulos.

## 10. Barreiras De Seguranca Do Roteiro

- Backup nao pode limpar bancos, arquivos de negocio, filas ou volumes.
- Nunca usar `docker compose down -v`, `docker system prune --volumes`,
  `git reset --hard`, `DROP DATABASE` ou restore com `REPLACE` como passo
  automatico de recuperacao. O deploy tem efeitos distintos do backup.
- Nunca guardar backups dentro do repositorio, de `/storage` servido pelo
  gateway ou somente no disco que contem o SQL.
- O conjunto nao e aprovado se faltar um banco esperado, um arquivo
  obrigatorio, sua chave ou a confirmacao da copia externa.
- Preservar chave e cofre correspondentes. No Memorias, key.bin da configuracao
  cifrada e o arquivo memorias-youtube.env precisam ser inventariados; o .env
  sozinho pode nao representar a configuracao efetiva salva pela interface.
- Arquivos fiscais PFX e senha.secret recebem o mesmo tratamento restrito do
  cofre. O log do backup nunca mostra seu conteudo.
- Recuperar primeiro para caminho/banco/instancia alternativa. Alterar somente
  o componente escolhido, com copia do estado anterior para eventual retorno.
- Exclusao por retencao exige destino confirmado e uma copia boa preservada;
  primeira implementacao roda retencao em simulacao.
- Remover/renomear uma area do cadastro nao autoriza apagar seus dados nem
  backups antigos. Preservar definicoes historicas e acesso aos conjuntos
  dentro da retencao; troca de chave/politica exige revisao das dependencias.

## 11. Sequencia Replanejada De Implementacao

Todas as etapas abaixo estao planejadas, nenhuma implantada. A nova ordem e
politica -> area -> adesao -> prova -> operacao continua, sem rotina por app.

As fases abaixo sao exclusivamente de backup, posteriores ao aceite da
centralizacao de credenciais. Nao substituem nem antecipam essa primeira entrega.

| Etapa | Entrega | Aceite |
| --- | --- | --- |
| P1 | Fechar catalogo de politicas e parametros compartilhados | Destino, retencao, janela, perda aceitavel, custodia de chaves e responsaveis definidos uma vez |
| P2 | Confirmar servidor e associar bancos/areas atuais a politicas | Binds reais, mounts, escritores, recovery models/logs, volumes e lacunas reconciliados, sem movimentacao em massa |
| P3 | Piloto manual com SQL, arquivos, cofre e configuracao dependentes | Copia externa e restore isolado aprovados; logs FULL tratados; procedimento medido |
| P4 | Configuracao versionada e rotina reutilizavel orientada a areas | Selecao em simulacao, perfis conhecidos, sem segredos no Git e sem scripts especificos por funcionalidade |
| P5 | Estender a todas as areas essenciais e ensaiar suas dependencias | Cada area obrigatoria com captura externa e evidencia de restore; lacunas sem cobertura declaradas |
| P6 | Agendamento por politica, alertas, retencao e exercicios | Idade/falhas por area visiveis, ausencia de sobreposicao e recuperacao a partir da copia externa |
| P7 | Adotar areas prontas em recursos novos e corrigir binds legados por app | Novo arquivo/tabela herda protecao sem novo job; dados antigos preservados antes de qualquer troca |
| P8 | Automatizar verificacao dos vinculos; DSL minima somente se necessaria | Relatorio do legado, validacao de recursos novos/alterados e referencias estaticas sem backup no caminho quente |
| P9 | Evoluir perda aceitavel SQL e comprovar recuperacao de mensagens | Cadeia de logs, efeitos externos e retomadas ensaiados; nao adia manutencao FULL nem preservacao de mensagens em risco |
| P10 | Backup de imagens Docker e eventual snapshot da VPS | Depois da estabilizacao, sem substituir as politicas de dados |

P1 define as politicas, nao significa aprovar todos os destinos do servidor.
P2 resolve esses destinos reais e as excecoes. Um risco imediato, como arquivo
unico no container ou log sem manutencao, deve ser contido antes de qualquer
deploy/recriacao; a ordem documental nao justifica perder dados aguardando P7/P9.

O piloto P3 comprova um caminho de ponta a ponta, nao o ambiente inteiro.
P5 demonstra a cobertura essencial; P6 completa a rotina operacional dessa
cobertura. Enquanto houver lacuna de mensagem ou origem nao protegida, manter
o escopo explicitamente limitado em vez de declarar backup de tudo entregue.

O novo fluxo de desenvolvimento passa a ser:

```text
Preciso persistir algo
  -> cabe em banco/area ja coberto? Reutilizar e herdar a politica
  -> precisa de area nova? Vincular perfil existente e comprovar adesao
  -> exige tecnologia nova? Validar procedimento uma vez e entao reutilizar
```

O operador continua usando uma rotina de infraestrutura compartilhada e
procedimentos nativos por tipo de dado. Nao criar API de backup, servico
central dependente dos aplicativos, nem jobs dentro de Commands/Receivers.

## 12. Bases Da Analise

Arquivos locais consultados:

- `infra/Shared/DockerCompose/docker-compose.yml`: SQL 2022 e mounts reais
  declarados para SQL, telemetria, storage, gateway e agente operacional.
- `infra/docker/deploy.env`: nomes atuais de bancos.
- `infra/docker/deploy.sh` e `infra/bootstraps/setup.sh`: efeitos do deploy e bootstrap.
- `infra/docker/load-deploy-env.sh`: configuracoes privadas fora do clone.
- `infra/Memorias/DockerCompose/docker-compose.yml` e `YOUTUBE.md`: mounts e
  dependencias de recuperacao da midia e credenciais.
- `EncryptedYouTubeAccountRepository.cs` e
  `EncryptedYouTubeApplicationConfigurationRepository.cs`: chaves, arquivos
  cifrados, recibos e vinculo ao ProcessingScope.
- `FiscalPayloadStore.cs` e `SefazFiscalDocumentStore.cs`: dados fiscais fora
  de persistent e referencias absolutas no storage.

Referencias tecnicas externas aparecem junto das decisoes que sustentam.
O inventario do servidor e a demonstracao de restore permanecem pendentes.
