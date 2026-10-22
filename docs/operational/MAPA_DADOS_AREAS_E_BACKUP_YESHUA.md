# Mapa De Dados, Areas E Politicas De Backup Yeshua

Data: 2026-10-17.

Revisao alinhada ao plano operacional v6, atualizada em 2026-10-20: uma
politica essencial, captura por tipo de dado e limpeza independente. Preserva
o padrao privado por diretorio/permissoes e os cofres existentes.

Status: mapa confrontado com inventario real da VPS; ferramentas instaladas e
backups SQL full/diferencial/logs reais gerados. Repositorio cifrado LOCAL em
/root/YeshuaBackup/repository; arquivos concluidos, leitura integral aprovada
e seis agendas online ativas. Volumes quentes e recuperacao integral pendentes.
Destino externo pendente, sem impedir a operacao local. A atualizacao ao final deste
documento registra os paths/volumes observados. O ensaio sera no servidor novo;
o [roteiro executavel](../../infra/backups/RECOVERY.md) prevalece sobre etapas
antigas de laboratorio preliminar. Nenhuma DSL de backup foi adicionada.

CLASSIFICACAO ENCERRADA pelo usuario em 2026-10-21. A secao 0 registra as decisoes
finais: somente PERSISTENTE e VOLATIL. Os perfis e perguntas das secoes historicas
nao reabrem a classificacao. A implementacao local aplica novas capturas a raiz
persistente inteira e areas privadas; nada de filtros por conteudo, imagens,
volumes volateis ou bancos de sistema. Nao apagar origens/snapshots/prune.
VPS atual intacta; implantacao e comprovacao em servidor novo ainda pendentes.

O procedimento de captura, checagem e restauracao esta no
[plano operacional](PLANO_BACKUP_RESTAURACAO_YESHUA.md). Este mapa concentra a
selecao dos dados e a associacao com politicas reutilizaveis. Ele e o mapa de
adesao ao plano: nao gera um job por item e nao substitui o roteiro operacional.

A [centralizacao de credenciais](../../infra/private/README.md) passou pelo
aceite tecnico de producao/redeploy em 2026-10-20; o usuario confirmou o uso
real do Memorias. Cobertura online nao inclui volumes quentes, uploads sem bind
nem prova de recuperacao integral; essas lacunas permanecem explicitas.

## 0. Decisoes Confirmadas E Lista De Atividades

Esta secao registra a revisao atual com o usuario e prevalece sobre os perfis
e sugestoes anteriores deste mapa. Nao representa nova implantacao na VPS.

### 0.1 Contrato Atual

- Existem somente PERSISTENTE e VOLATIL. Privacidade/permissoes nao criam
  outra categoria de backup.
- Tudo que estiver na area persistente entra integralmente no backup;
  a area volatil nao entra. Nao ha excecao de conteudo dentro de persistente.
- 100% dos bancos dos aplicativos definidos nos Studios sao PERSISTENTES,
  incluindo todas as tabelas e novos bancos desses aplicativos. O metodo
  continua sendo backup nativo SQL; nao copiar MDF/LDF ativos.
- Banco Estudo e PERSISTENTE, confirmado pelo usuario apos a conferencia dos
  metadados. Manter backup nativo integral no fluxo comum dos bancos de usuario,
  mesmo sem Studio identificado; a exclusao de bancos de sistema nao o alcanca.
- Cofre privado YouTube do Memorias e PERSISTENTE, confirmado pelo usuario:
  copia integral da area privada com configuracao, conexoes, estados e chaves
  correspondentes, pelo fluxo comum de arquivos. Permanece no Memorias e nao
  cobre fotos/videos. Nao migrar armazenamento por curiosidade sobre uso de SQL.
- credentials.json do ambiente e PERSISTENTE e restrito, confirmado pelo usuario.
  Manter fora do Git/imagens/logs, pasta 0700/arquivo 0600 no Linux, backup no
  repositorio cifrado existente e conferencia de permissoes na restauracao.
  Privacidade nao cria terceira categoria nem novo modelo de criptografia local.
- providers.json opcional do agente e PERSISTENTE e restrito, confirmado pelo
  usuario. Chaves de API configuradas entram no backup da raiz privada;
  sessoes/historicos/caches e volumes do agente continuam VOLATEIS.
- Identidade HTTPS e estado Certbot em /etc/letsencrypt sao VOLATEIS por decisao
  posterior do usuario: reemitir pelo setup-cert.sh no servidor novo, sem backup
  dessa area. Isso substitui a aprovacao inicial como persistente. Novas capturas
  v3 ja a excluem localmente; nao apagar origens/snapshots nem emitir certificados agora.
- Credencial de recuperacao do backup e PERSISTENTE/restrita, com guarda fora
  da VPS. Setup deve entrega-la ao operador por terminal privado e confirmar a
  guarda antes de novas provas/agendas. Nunca registrar a senha nos logs/recibos
  nem depender da unica copia dentro do backup cifrado que ela desbloqueia.
- Bancos de sistema SQL master/model/msdb e tempdb ficam fora do backup,
  confirmado pelo usuario. A instalacao/recriacao deve provisionar os acessos
  necessarios pela infraestrutura versionada, com credenciais do arquivo privado,
  sem restaurar bancos de sistema. A descoberta inclui os bancos de usuario,
  inclusive Estudo e bancos novos, sem depender de uma lista fechada de Studios.
- Tudo recriavel a partir de uma fonte disponivel fica fora de persistente
  e do backup: copias dos fontes, bundles Git, builds, imagens Docker e caches
  reconstruiveis. Nesta fase nao otimizar para restauracao rapida.
- Qualquer uso de storage da aplicacao deve passar por StorageLocation.
  A escolha de persistente/volatil e intencional na definicao/uso da localizacao;
  o backup herda essa escolha, sem flag de backup por arquivo ou por tenant.
- Planos por tenant, aplicativo, funcao e prazo ficam para outra fase.
- Fotos originais do Memorias sao VOLATEIS por padrao, confirmado pelo usuario.
  Os registros SQL de fotos/albuns continuam no banco persistente; esta decisao
  classifica os arquivos. O destino atual persistent/memorias/photos precisa
  ser corrigido na reforma, nao excluido por conteudo dentro de persistente.
- Videos MP4 locais gerados pelo Memorias sao SEMPRE VOLATEIS, inclusive
  para pagantes. Nao estender a futura preservacao paga de fotos aos videos.
- Manifestos de renderizacao manifest.json do Memorias sao VOLATEIS,
  confirmados pelo usuario; sao arquivos de instrucao para o renderer Python.
- Trilhas padrao versionadas do Memorias sao VOLATEIS, confirmadas pelo usuario;
  podem ser repostas do Git/deploy, sem copia no backup de dados.
- Audios originais da Clinica sao VOLATEIS, confirmados individualmente pelo
  usuario; ja usam StorageLocation.Volatile.TranscriptionsInput. A aplicacao
  deve tratar ausencia/reenvio e liberar para limpeza conforme o processamento.
- Arquivos auxiliares/de saida da transcricao da Clinica sao VOLATEIS,
  confirmados pelo usuario. O texto recebido e salvo no banco permanece
  persistente. O worker devolve o texto pela fila; audio baixado e WAV sao
  temporarios em TranscriptionsOutput, com criacao registrada e limpeza por tentativa.
- Relatorios da Clinica em volatile/reports/input permanecem VOLATEIS, por
  confirmacao do usuario. Aplicar a mesma regra a volatile/reports/output:
  o que ja esta classificado na area volatil continua volatil. A origem exata
  desses relatorios nao foi comprovada nesta conferencia; o usuario considera
  provavel que sejam gerados da base. Nao transformar essa suposicao em fato.
- Todo dado volatil exige tratamento especifico da aplicacao: definir seu
  ciclo de vida, quando pode ser limpo e o comportamento quando estiver ausente.
  Volatil nao significa autorizar exclusao de arquivo ainda em uso.
- Arquivos do Fiscal: certificado digital e senha sao PERSISTENTES; planos,
  XMLs assinados, retornos SEFAZ e demais artefatos de processamento sao VOLATEIS
  por padrao, por decisao do usuario. Guarda persistente de XML depende de futura
  contratacao paga. O banco Fiscal continua integralmente persistente.
- RabbitMQ e VOLATIL por decisao posterior do usuario: estado do broker e
  mensagens pendentes nao entram no backup. Credenciais no JSON privado e
  registros SQL de Inbox/Outbox/Saga continuam persistentes. Manter o protocolo
  e o comportamento atuais de ACK/retry, conforme a decisao final do usuario.
- Redis tambem e VOLATIL, confirmado pelo usuario: fora do backup, sem desligar
  o servico ou remover seu volume por essa classificacao. Nao alterar o cache
  em memoria dos aplicativos nem o funcionamento do RabbitMQ.
- Historico de telemetria (logs, metricas e rastros) e VOLATIL, confirmado pelo
  usuario. Nao alterar retencao/coleta por essa classificacao. O SQL operacional
  continua persistente, fora deste item.
- Estado interno do Grafana tambem e VOLATIL, confirmado pelo usuario. Paineis,
  alertas e demais personalizacoes devem nascer e ser mantidos na infraestrutura
  versionada/recuperavel, usando provisionamento nativo, nao apenas na interface.
  Segredos continuam no arquivo privado, fora do Git. Nao criar backup do banco
  interno para substituir esse contrato de recriacao.
- Volumes do agente operacional (workspace, Codex e Claude) sao VOLATEIS,
  confirmado pelo usuario. Estado funcional que precise sobreviver deve ser
  mantido no banco correspondente ja protegido por backup, nao somente nesses
  volumes. Credenciais tecnicas continuam seguindo o arquivo privado existente.

### 0.2 Atividades Da Reforma

DECISAO POSTERIOR DO USUARIO: recriar o ambiente Yeshua do zero, inclusive
bancos/dados e conexoes YouTube atuais, sem obrigacao de migrar/preservar o
acervo de testes. Essa autorizacao pontual substitui a exigencia de preservar
o cofre nesta transicao. Nao muda a politica futura: bancos/persistente continuam
protegidos e deploy normal nunca limpa dados. Nao inclui fontes, sistema
operacional, acesso administrativo, recursos de terceiros ou canais/videos
publicados no Google. A limpeza depende do inventario e do caminho de recriacao
conferidos, para nao remover um recurso fora do escopo.

PONTO DE RETOMADA ATUALIZADO: o usuario adiou a limpeza/recriacao do servidor.
Continuar a implementacao e os testes locais, sem deploy, parada, reinicio ou
exclusao de dados na VPS. A reinstalacao limpa fica como etapa futura separada.
A classificacao foi encerrada. Cobranca, limpeza generica e verificacoes de
recuperacao externa continuam trabalhos separados; nao agendar exclusoes agora.

APLICACAO LOCAL DE 2026-10-21: captura online e coordenada excluem bancos de
sistema, HTTPS e volumes Shared RabbitMQ/Redis/agente. Telemetria/Grafana usam
volatile/infra/telemetry no Compose, sem mudar coleta/retencao. Bind legado de
telemetria bloqueia captura ate a virada intencional. Volumes desconhecidos nao
viram persistentes por inferencia: exigem StorageLocation classificado.
DocsInput/DocsOutput/configs/criacao Docs sem uso foram retirados sem apagar dados.
Storage/persistent e privados entram inteiros; novas subpastas herdam a cobertura.
Memorias sem PrivateRoot explicito usa apps/Memorias sob a raiz privada, como o deploy.
Selecao v3 renova prova de arquivos/leitura integral; snapshots v2 continuam legiveis.
Midias antigas de sistema ficam no disco/historico, sem nova copia SQL delas.

PROVISIONAMENTO LOCAL: setup habilita o helper comum infra/private/sql_access.py,
antes dos hosts e apos migrations. sa vem do Compose/arquivo privado; contas
adicionais/roles devem ser declaradas em Shared.SqlServer.Logins. Nao inferir
permissoes das connection strings nem copiar master/msdb. Senhas existentes nao
giram; usuarios SQL orfaos de mesmo nome sao remapeados. Deploy cotidiano nao
habilita essa etapa. Correspondencia das conexoes, efetividade dos grants e
recuperacao real ainda precisam do ensaio isolado. Nenhuma operacao na VPS.

VERIFICACAO DESTA APLICACAO LOCAL (2026-10-21): backup com 166 testes, 164
aprovados e dois nao executados por ferramentas/permissoes do ambiente;
configuracao privada com 52 aprovados; Shared .NET com 28 aprovados. No fechamento,
o teste Compose validou os seis modelos com CLI oficial v2.25.0 e
fixtures, sem daemon; a suite .NET privada compilou com as dependencias reais de
StorageLocation e aprovou cinco testes (cofre fiscal e plano volatil incluidos).
Duas simulacoes Bash e sintaxe dos dez scripts aprovadas. JSON alterados validos.
Total: 249 testes aprovados, dois nao executados. Os 42 arquivos preparados para
commit foram comparados aos segredos da copia privada de producao, sem valores
encontrados. Segredos reais permanecem fora do Git; historico antigo nao e limpo
nem credenciais sao revogadas por essa verificacao.
SQL real, builds/containers Docker, Restic/GNU cp/ACLs Linux e recuperacao integral
nao foram executados nesta rodada. Modelo Compose valido nao comprova subida.
Esses resultados nao sao prova de restauracao 100% nem de copia externa.

IMPLEMENTACAO LOCAL: novas fotos, trilhas, manifestos/MP4 do Memorias e planos/XML
do Fiscal usam destinos volateis. Certificado/senha usam localizacao persistente
sob a raiz privada do Fiscal, nunca no storage publico. Uploads legados da Clinica
e APS usam IFileStorage/StorageLocation volatil com autenticacao e chave relativa;
uso/obsolescencia ainda sera investigado. Audios ausentes da Clinica e arquivos
ausentes do Memorias geram orientacao de reenvio/nova publicacao.

Backup seleciona Storage/persistent sem filtros; nao gera bundles/fontes/toolkit
ou imagens. Instalacao exige recibo da nova selecao antes de reaproveitar o aceite
de arquivos antigo. SQL continua nativo e automatico para novos bancos. O ensaio
de recuperacao integral e o destino externo permanecem pendentes. O modo antigo
prepare-server nao e um restore rapido para os novos conjuntos somente de dados;
reconstruir software pelo Git conforme RECOVERY.md. Nao houve deploy na VPS.

CONTINUACAO LOCAL: restore-files integra a recuperacao de arquivos ao mesmo
operador, com plano por padrao/--apply explicito, snapshot verificado, identidade
de maquina nova, destinos vazios e verificacao de conteudo/permissoes. Nao liga
servicos nem muda SQL/Nginx. Cobertura atual persistent-roots-v3 inclui identidade da
origem; o setup atualiza a prova de arquivos e refaz a leitura integral quando
necessario, sem repetir baselines SQL validas. A comprovacao Linux/Restic e o
ensaio funcional em servidor novo permanecem pendentes.

VERIFICACAO DA CONTINUACAO: suite de backup com 134 testes, 132 aprovados e
2 dependentes do ambiente/ferramentas Linux ou de permissao para criar symlinks;
suite de credenciais privadas com 25 aprovados. A copia dos testes e simulada:
GNU cp/Restic, ACLs/xattrs Linux e uso real dos aplicativos ainda precisam do
ensaio no novo servidor. Nenhuma operacao desta continuacao alterou a VPS.

TRANSICAO AINDA NAO EXECUTADA: autorizada a recriacao limpa, sem migrar caminhos antigos.
Conteudo que continuar fisicamente em persistent continua integralmente no backup,
mesmo sendo uma foto/video antigo hoje classificado como volatil. Registros SQL
com caminhos antigos nao sao reescritos automaticamente. A virada na VPS precisa
recriar dados/diretorios de forma controlada antes de medir a reducao real;
nao trocar isso por um filtro de exclusao no backup. O cofre YouTube tambem e
descartavel nesta reinstalacao; novos clientes/canais precisarao de nova conexao.

VERIFICACAO LOCAL: Shared 28 testes; Memorias 139 testes focados (upload, rotacao,
qualidade, apresentacao, transporte e publicacao YouTube); Fiscal 3 testes de
storage/certificado; backup 111 aprovados e 1 dependente das ferramentas Linux;
renderer 19 testes com FFmpeg real; transcricao 3 testes de temporarios com
dependencias externas simuladas. APIs Clinica e APS ADM compilaram em Release.
Teste simulado do setup aprovado; Docker nao esta disponivel nesta maquina para
ensaio de containers. YAML e novos mapeamentos dos tres Compose alterados foram
validados com parser. Nada disso equivale ao aceite de restauracao integral.

Atualizacao de 2026-10-22: os temporarios de transcricao usam
STORAGE_ROOT/volatile/ia/transcriptions/output (TranscriptionsOutput), sem backup,
com data de criacao registrada pelo aplicativo. A aplicacao limpa sua tentativa
no sucesso e em falhas de download, FFmpeg e transcricao; sobras de queda abrupta
ficam na raiz da rotina generica de 7 dias. O audio original nao e apagado pela
limpeza da tentativa. Servico de IA continua desativado no Compose.

- [x] Registrar a classificacao de todos os bancos dos aplicativos como persistente.
- [x] Registrar fotos originais do Memorias como volateis por padrao.
- [x] Registrar videos MP4 locais do Memorias como sempre volateis, sem plano pago.
- [x] Registrar manifestos de renderizacao do Memorias como volateis.
- [x] Registrar trilhas padrao versionadas do Memorias como volateis.
- [x] Registrar audios originais da Clinica como volateis.
- [x] Registrar uploads diretos de audio da API da Clinica como volateis.
- [x] Registrar uploads diretos de audio da API do APS como volateis.
- [x] Registrar arquivos auxiliares/de saida da transcricao da Clinica como volateis.
- [x] Registrar entrada de relatorios da Clinica como volatil e manter a saida
  volatil pela regra confirmada para as areas ja volateis.
- [x] Registrar certificado/senha do Fiscal como persistentes e os demais
  arquivos fiscais como volateis por padrao; guarda paga de XML a planejar.
- [x] Encerrar com o usuario a classificacao; seguir implementacao, sem nova rodada item a item.
- [x] Investigar DocsInput/DocsOutput e o nome legado Docs: nenhum consumidor
  de negocio identificado no codigo; resultado apresentado e retirada aprovada.
- [x] Aplicar localmente a retirada aprovada das declaracoes/configuracoes/criacao automatica
  de DocsInput/DocsOutput/Docs, sem apagar pastas existentes. Prontuario e
  RegistroDocumental continuam no SQL persistente. Conferencia da VPS nao foi repetida.
- [x] Investigar RabbitMQ e registrar decisao do usuario: VOLATIL, fora do backup.
- [x] Adequar localmente a captura coordenada para nao copiar o estado do
  RabbitMQ. Volumes desconhecidos bloqueiam, em vez de serem adotados. A copia online
  ja nao inclui o broker. Nao remover volumes, filas ou alterar a VPS agora.
- [x] Esclarecer o ACK do listener: usuario decidiu manter o conceito e o
  comportamento atuais. Nao alterar ACK, retry, confirmacoes ou tratamento de
  erros como parte desta tarefa; RabbitMQ permanece VOLATIL no plano de backup.
- [x] Investigar Redis e registrar a decisao do usuario: VOLATIL, fora do backup.
- [x] Adequar localmente a selecao coordenada para excluir o estado Redis,
  sem apagar volumes ou alterar o servico. A copia online ja nao o inclui.
- [x] Investigar historico de telemetria e registrar decisao do usuario: VOLATIL.
- [x] Investigar Grafana e registrar decisao do usuario: estado interno VOLATIL;
  personalizacoes obrigatoriamente versionadas na infraestrutura recuperavel.
- [x] Registrar decisao direta do usuario sobre os tres volumes do agente:
  VOLATEIS; qualquer estado funcional persistente devera ir ao banco ja protegido.
- [x] Adequar localmente a captura coordenada para nao copiar workspace/volumes Codex/Claude.
  Nao apagar volumes, copiar sessoes para SQL ou habilitar escrita do agente agora.
- [x] Adequar localmente as raizes/binds e a selecao coordenada para manter
  historico de telemetria e estado Grafana em volatil, sem filtros dentro de
  persistente. Nao apagar dados, mover diretorios ou mudar a VPS nesta fase.
- [x] Registrar decisao do usuario: master/model/msdb e tempdb fora do backup;
  acessos SQL necessarios devem ser criados na instalacao/recriacao do servidor.
- [x] Conferir metadados do Estudo via API operacional e registrar a decisao
  posterior do usuario: PERSISTENTE, manter backup nativo integral na rotina
  comum. Selecao atual ja o inclui; preservar cobertura na reforma da selecao SQL.
- [x] Conferir o cofre YouTube do Memorias e registrar decisao do usuario:
  PERSISTENTE, copia integral com suas chaves, sem migrar para Central ou SQL.
  A raiz privada ja integra a selecao comum de arquivos; restore ainda a provar.
- [x] Registrar credentials.json como PERSISTENTE e de acesso restrito por
  confirmacao do usuario. Manter protecoes existentes de origem/copia/restore,
  sem gerar chaves, expor valores ou criar outro cofre/cifra local.
- [x] Registrar providers.json como PERSISTENTE e restrito quando utilizado,
  confirmado pelo usuario, sem mudar a classificacao VOLATIL dos volumes do agente.
- [x] Registrar decisao posterior: /etc/letsencrypt VOLATIL e recriavel pelo
  setup-cert.sh, substituindo a aprovacao inicial como persistente.
- [x] Implementar entrega da senha existente do backup no INICIO do setup:
  apos validar o JSON, antes de atualizacoes/Docker/builds; EXIBIR -> terminal
  privado -> GUARDEI. Instalador final reutiliza recibo sem senha/sem nova pergunta.
  Ausencia de terminal/confirmacao impede atualizacoes/deploy; rotinas agendadas
  nao exibem a senha e credenciais existentes nao sao trocadas.
- [ ] Comprovar a entrega por terminal Linux real e a guarda independente no
  ensaio do servidor novo; declaracao do operador nao comprova copia externa.
- [x] Retirar localmente HTTPS das novas capturas online/coordenadas e adequar provas de
  cobertura/restauracao. Nao apagar a origem ou snapshots antigos por isso.
- [ ] Integrar/conferir recriacao HTTPS no roteiro de servidor novo pelo script
  existente, com validacao do dominio e agenda/renovacao comprovadas. Certbot
  standalone requer acesso para validacao; nao emitir/reiniciar Nginx nesta revisao.
- [x] Adequar localmente selecao SQL online/coordenada e provas de cobertura para excluir
  bancos de sistema. Nao apagar bancos ou snapshots anteriores; bancos de
  usuario continuam integralmente protegidos, inclusive Estudo e apps futuros.
- [x] Implementar provisionamento de logins, usuarios e permissoes SQL
  no caminho existente da infraestrutura, usando o arquivo privado. Reutilizar
  na instalacao e restauracao, conferir vinculos de usuarios em bancos restaurados
  antes de liberar apps. Nao depender de master/model/msdb antigos.
- [ ] Comprovar grants, vinculos e acesso real de cada aplicativo no servidor novo.
- [x] Direcionar novos uploads de fotos do Memorias a StorageLocation volatil.
- [ ] ETAPA FUTURA ADIADA: reinstalacao limpa dos recursos Yeshua da VPS, sem
  migrar dados/cofre antigos e sem atingir terceiros. Nao executar nesta fase.
- [ ] Inventariar caminhos de storage montados diretamente em codigo, configuracao,
  templates e integracoes; substituir pelo uso das localizacoes existentes.
- [x] Consolidar StorageLocation com as duas categorias, sem nova DSL de backup;
  Python/FFmpeg recebem destinos resolvidos pela aplicacao.
- [ ] Aplicar as classificacoes aprovadas aos destinos de escrita/leitura e
  configurar suas raizes/mounts na instalacao limpa, sem compatibilidade de
  caminhos antigos nem necessidade de preservar o cofre YouTube atual.
- [x] Alinhar no codigo as capturas online e coordenada: copiar persistente integralmente,
  nao copiar volatil e retirar copias de fontes/historico/artefatos recriaveis.
- [x] Novas publicacoes/intermediarios ficam em volatil e o novo backup nao usa
  excecao .render-*. Diretorios antigos continuam incluidos ate transicao explicita.
- [x] Testar heranca automatica para arquivo/subpasta/tenant novo em localizacao
  existente e para banco novo de aplicativo; testar recusa de destino fora das raizes.
- [x] Implementar reposicao assistida de arquivos pelo operador existente,
  com simulacao, destinos vazios, identificacao da origem e hashes/permissoes.
- [x] Recusar aceite de leitura integral anterior a uma nova copia SQL/arquivos
  no setup; testar renovacao da prova de arquivos sem refazer baselines SQL validas.
- [ ] Conferir a instalacao inicial e a rotina publicada depois das alteracoes;
  nao declarar estas atividades concluidas apenas pelo planejamento.
- [ ] Planejar preservacao paga de fotos por tenant inteiro ou por usuario
  dentro de um tenant, conforme a pendencia 0.4; nao implementar cobranca agora.
- [x] Direcionar novos videos MP4 locais do Memorias a StorageLocation volatil.
- [x] Direcionar novos manifestos de renderizacao do Memorias a StorageLocation volatil
  e tratar sua ausencia no fluxo da aplicacao.
- [x] Direcionar trilhas padrao do Memorias a StorageLocation volatil e garantir
  reposicao a partir dos arquivos versionados quando necessario, com verificacao de hash.
- [x] Implementar expiracao de arquivos volateis por 7 dias desde a criacao,
  com agenda diaria integrada ao setup e simulacao, conforme a secao 0.5.
- [ ] Comprovar simulacao/ativacao da limpeza no Linux da VPS e planejar o
  gatilho por espaco livre do servidor inteiro, sem quota por funcao.
- [ ] Conferir o tratamento de audio original ausente na Clinica e a liberacao
  para limpeza, protegendo uploads/transcricoes ainda em andamento.
- [x] Conferir no fonte atual as rotas /upload da Clinica e do APS ADM: ambas
  ja usam IFileStorage e StorageLocation volatil, com autenticacao. A pendencia
  anterior de migracao dessas rotas estava desatualizada; isto nao comprova deploy.
  A copia da API generica Yeshua.CQRS.Infrastructure.Api tambem foi alinhada ao
  mesmo storage autenticado/configuracao da Clinica; nao e publicada pelos
  Dockerfiles atuais desses apps. Seu build completo tem referencias antigas
  ausentes em Command.Commands/Receivers/Patterns.OutBox, fora desta alteracao.
- [x] Alinhar os temporarios do worker de transcricao e sua copia infra/docker
  a StorageLocation.Volatile.TranscriptionsOutput, sob STORAGE_ROOT. Audio
  baixado/WAV recebem o atributo de criacao no descritor ao nascer, sem fallback
  para /tmp; falhas de metadata removem a reserva. TranscriptionsOutput agora
  tem consumidor concreto. Limpeza imediata por tentativa preservada; sobras de
  queda abrupta ficam no escopo da limpeza de 7 dias. Servico continua desativado.
- [ ] Ao planejar externalizacao do renderer/servicos de midia, resolver o acesso
  aos arquivos sem presumir volume local compartilhado, conforme o ponto 0.6.
- [x] Direcionar novos planos, XMLs e artefatos de processamento do Fiscal via
  StorageLocation volatil e certificado/senha via persistente com acesso restrito.
- [ ] Planejar consulta de XML pelo banco e depois SEFAZ, tratamento de ausencia
  e guarda persistente paga, conforme a pendencia 0.7; nao prometer recuperacao
  externa sem validar o servico para cada tipo de documento.
- [ ] Conferir em todos os fluxos fiscais a gravacao da chave de acesso no
  banco antes de depender de arquivos volateis; prover a gravacao onde faltar.
  Campos e inserts de preparacao CT-e/MDF-e ja foram encontrados no codigo.

### 0.3 Entrada Automatica De Arquivos Novos

Ao desenvolver uma funcao, escolher uma StorageLocation persistente ou volatil.
Essa e a decisao intencional. Arquivos e subpastas novos escritos numa localizacao
persistente ja coberta entram no proximo ciclo de backup, sem cadastro individual,
novo job, chamada de backup no receiver ou configuracao por tenant. Em volatil,
ficam fora. Herdar a selecao nao significa copia sincrona no momento da gravacao.

Uma localizacao nova exige definir sua categoria e resolver o destino fisico
dentro da raiz correspondente. Um volume/diretorio arbitrario fora das raizes
nao ganha cobertura automaticamente; devera ser impedido/validado pela reforma.

Hoje arquivos novos nas areas persistentes ja selecionadas entram na copia
recursiva. Ainda faltam a obrigatoriedade de StorageLocation e a selecao estrita
de persistente: a rotina atual inclui outras raizes e metadata/source.bundle,
e ainda exclui .render-* dentro de persistent. Sao pendencias, nao o contrato final.

### 0.4 Pendencia: Preservacao Paga Das Fotos Do Memorias

Solicitacao do usuario: no comportamento futuro, sem contratacao as fotos sao
volateis; com contratacao valida, a localizacao passa a persistente e portanto
entra no backup comum. Nao criar filtro pago no backup nem terceira categoria.

Planejar os escopos tenant completo e usuario identificado dentro do tenant.
O usuario deseja preservar seu proprio tenant; identificacao e ativacao ficam
pendentes para a implementacao, sem inferir IDs ou liberar todos os tenants.

Ainda definir: como representar a contratacao e eventual integracao financeira;
como combinar cobertura do tenant e do usuario; quando a cobertura comeca;
tratamento de arquivos existentes; e comportamento ao cancelar/expirar, sem
exclusao imediata implicita. Contratar depois nao recupera arquivo ja perdido.
Essa elegibilidade nao deve ser confundida automaticamente com perfil/ACL.

Status: A PLANEJAR NA SEQUENCIA. Nenhum plano, tabela financeira, permissao,
cobranca ou mudanca de destino foi implementado por este registro.

### 0.5 Limpeza E Tratamento Dos Dados Volateis

Decisao aprovada em 2026-10-22: arquivos volateis dos aplicativos expiram
apos 7 dias da criacao real no filesystem, sem renovar prazo por atualizacao.
Implementacao local: infra/backups/volatile.py, somente raiz
/root/YeshuaStorage/volatile, com simulacao padrao e --apply explicito. O setup
usa o instalador existente para habilitar uma agenda diaria as 04:30 Sao Paulo;
nao limpa durante instalacao/deploy. O primeiro ciclo tambem considera os
arquivos antigos elegiveis. Nao executado nem ativado na VPS nesta entrega.

GNU stat %W consulta birth time no inode aberto. mtime e ctime nao substituem
criacao. Decisao FINAL: na falta da criacao nativa, usar a data registrada pelo
aplicativo no atributo Linux user.yeshua.created_at_unix (UTC/segundos Unix).
Sem as duas datas, preservar e emitir aviso/contador; nao excluir. Essa decisao
revoga a exclusao anterior por ausencia. A data registrada nao e renovada ao editar.
Erro ao consultar os metadados nao e atributo ausente: interrompe a rotina.
StorageFile concentra o registro generico no codigo compartilhado; DiskStorageProvider,
planos/XML Fiscal e renderer Memorias usam o mesmo contrato, sem sidecar/tabela.
Em desenvolvimento Windows, mantem criacao nativa. Uploads Clinica/APS ADM e da
API generica antiga usam o storage comum. Temporarios Python das duas copias do
transcritor tambem ficam na raiz volatil e registram criacao, sem reativar IA.
Testes locais da transcricao/cablagem de storage: 31, sendo 27 aprovados e 4
integracoes Linux omitidas no Windows. Isso nao comprova execucao de containers
nem validacao Linux da limpeza, ainda pendentes; nao afirmar cobertura universal.
Links, hardlinks, mounts internos e diretorios ficam preservados. Handles
abertos e flock protegem os arquivos identificados em uso; erro de inspecao
recusa limpeza. Revalidacao antes de unlink reduz concorrencia, mas nao equivale
a consultar estado de saga nem elimina a janela para uma abertura posterior.
Cada aplicacao continua responsavel por ausencia, reenvio/regeneracao e locks
quando precisar manter um arquivo em uso por periodos longos.

volatile/infra usa retencao nativa dos servicos, nao expiracao generica dos
arquivos internos. Prometheus/Loki/Tempo permanecem com os 5 dias existentes;
nao apagar bancos, indices, WAL ou estado Grafana por idade. Persistente,
privado, SQL, repositorio de backup, volumes Docker e certificados ficam fora
do escopo destrutivo deste script.

Pendencia: gatilho por espaco livre/ocupado no servidor inteiro, nao por funcao.
Nao ativar agora. Retencao do backup e descarte de midias SQL sao independentes
e mantem seus proprios gates de recuperacao.

Videos MP4 e manifestos do Memorias continuam volateis mesmo com contratacao
paga. O periodo nao e uma garantia de preservacao de dados volateis.

Status: IMPLEMENTADO E TESTADO LOCALMENTE; VALIDACAO LINUX/VPS PENDENTE.
Nenhum dado real foi apagado nesta entrega.

### 0.6 Ponto De Atencao: Externalizacao Dos Servicos De Midia

Hoje o .NET publica ManifestPath relativo ao storage pela Outbox/fila, e o
renderer Python resolve essa chave sob STORAGE_ROOT, normalmente /storage.
Manifesto, fotos, musicas e destino do video dependem de armazenamento acessivel
aos dois processos. A dependencia e do storage compartilhado, nao da proximidade
fisica dos servidores; levar a fila para outro host nao entrega os arquivos.

Antes de externalizar, planejar como o servico remoto resolvera essas referencias
e devolvera o resultado com acesso autenticado/restrito, isolamento de tenant
e validade compativel com o trabalho e a limpeza dos volateis. Avaliar o meio de
acesso/transferencia nesse momento, sem fixar HTTP, URL assinada ou storage remoto
agora. Nao resolver a separacao concedendo acesso direto do Python ao banco.

Status: PONTO DE ATENCAO FUTURO. Nenhum transporte ou servico novo implementado.

Observacao do usuario: verificar primeiro o suporte HTTP ja existente nas
abstracoes e providers de storage, incluindo IFileStorage e GetBaseUrl.
Se o caminho existente atender ao servico externo, reutiliza-lo, sem criar
endpoint/transporte paralelo. Confirmar acesso remoto efetivo e autorizacao;
gerar uma URL, sozinho, nao comprova esse suporte. Verificacao fica para depois.

### 0.7 Pendencia: XML Fiscal Volatil, Consulta E Guarda Paga

Decisao do usuario: XMLs fiscais, planos de emissao e demais arquivos de
processamento sao VOLATEIS por padrao, mesmo quando representam XML assinado
ou resposta de autorizacao. Certificado e senha sao PERSISTENTES, com acesso
restrito. O banco do aplicativo permanece integralmente persistente.

Fluxo desejado para consultar XML: procurar conteudo completo no banco quando
existir; caso nao exista, recorrer a SEFAZ. Conferir a disponibilidade real
da recuperacao para cada documento/servico e tratar ausencia, indisponibilidade
ou limites da integracao. O fluxo atual usa arquivos e guarda no banco caminhos,
hashes e metadados; isso nao comprova uma copia integral do XML no banco nem
recuperacao externa implementada. Consulta de status/protocolo nao equivale
automaticamente a obter o XML completo.

Requisito acrescentado pelo usuario: manter no minimo a chave de acesso no
banco para consultar novamente a SEFAZ, sem depender de XML/protocolo de
autorizacao previamente armazenado localmente. A chave de 44 caracteres ja
esta declarada na DSL em DocumentoFiscal, DocumentoFiscalOriginario,
NFeProdutoSnapshot e nas tentativas de emissao CT-e/MDF-e. Os handlers de
preparacao gravam prepared.Chave nas tentativas antes de enviar para autorizacao;
SefazFiscalDocumentStore tambem grava a chave em DocumentoFiscal.
Isso foi conferido nos fontes, nao como auditoria dos registros da VPS.

Nao criar coluna duplicada. Conferir cobertura dos demais fluxos e garantir
essa gravacao onde faltar, conservando tipo/ambiente e vinculo com tenant.
Nao exigir comprovante local de autorizacao para iniciar a consulta remota;
isso nao remove autenticacao/autorizacao da API nem as regras de acesso do
servico SEFAZ. A chave identifica o documento, mas nao garante por si so o
download do XML integral. Distribuicao pode exigir certificado, vinculo do ator,
NSU e outras condicoes, conforme o servico. Referencia a validar na implementacao:
[NT CT-e 2015.002 v1.04, distribuicao DF-e](https://www.cte.fazenda.gov.br/portal/exibirArquivo.aspx?conteudo=%2FVPENnM7j8s%3D).

Planejar a contratacao de guarda persistente dos XMLs: escopo, inicio da
cobertura, destino via StorageLocation e tratamento de transicao/cancelamento.
Quando contratado, o arquivo coberto vai para persistente e entra no backup
comum, sem filtro financeiro no backup e sem terceira categoria. Nao estender
essa regra aos MP4 do Memorias, que permanecem sempre volateis.

Status: CLASSIFICACAO CONFIRMADA; IMPLEMENTACAO PENDENTE. Nao mover/apagar arquivos,
ativar cobranca, criar novas rotas ou alterar a VPS nesta revisao.

### 0.8 Investigacoes Apresentadas Individualmente

Registro historico das conferencias. Classificacao encerrada em 2026-10-21;
implementacao local atual descrita em 0.2 prevalece sobre pendencias historicas.
Implantacao e prova real no servidor novo ainda nao foram feitas.

Instrucao do usuario: apresentar o resultado de cada investigacao, um por vez,
para decidir a classificacao/acao antes de aplicar. Nao tratar recomendacao como
aceite. Limpeza e recriacao da VPS continuam adiadas.

#### 1. Documentos Da Clinica: Entrada, Saida E Nome Legado

Conferencia local em 2026-10-20, sem nova consulta ou alteracao na VPS:

- DocsInput e DocsOutput existem como propriedades fixas em StorageLocation,
  apontando para persistent/docs/input e persistent/docs/output. Ja estavam
  assim no commit 7119f7e9c; nao nasceram na reforma de backup.
- A busca por essas propriedades/caminhos nos fontes identificou declaracoes e
  configuracoes, mas nenhum consumidor de negocio que grave ou leia essas areas.
  A DSL/migrations da Clinica nao declaram um fluxo de documentos em arquivo.
- Os consumidores de IFileStorage localizados na Clinica usam os destinos
  volateis de transcricao/upload, nao DocsInput/DocsOutput. O campo
  RegistroDocumental de Sesoes e Varchar(8000), assim como Prontuario: texto
  persistido em SQL, nao um arquivo nessas pastas.
- O Compose da Clinica configura docs minusculo. O setup.sh cria Docs com D
  maiusculo. Sao caminhos diferentes no Linux. O inventario anterior registrado
  na secao 10 encontrou apenas persistent/Docs vazio e nenhum persistent/docs;
  isso e evidencia anterior, nao uma verificacao atual de producao.

Conclusao limitada ao codigo consultado: aparente reserva antiga de storage,
sem funcionalidade ativa identificada. Nao confundir com prontuarios/registros
clinicos no banco, que continuam persistentes e protegidos integralmente.

DECISAO APROVADA pelo usuario em 2026-10-20: retirar declaracoes/configuracoes e criacao
automatica dessas pastas sem uso, em vez de manter uma classificacao presumida
para documentos futuros. Uma funcionalidade nova devera declarar sua propria
StorageLocation e escolher persistente ou volatil explicitamente. Nao apagar
pastas existentes nem filtrar seu conteudo no backup durante esta implementacao;
tudo que continuar fisicamente em persistent permanece incluido.

Status: RETIRADA IMPLEMENTADA LOCALMENTE em 2026-10-21. Nenhum destino foi movido
nem dado existente foi apagado. Declaracoes/configuracoes/criacao automatica removidas.

#### 2. RabbitMQ: Mensagens De Trabalho E De Retorno

Conferencia local em 2026-10-20, sem alterar filas/containers nem consultar
mensagens de producao. Decisao posterior do usuario: RabbitMQ VOLATIL, fora
do backup. Nenhuma fila/volume foi apagada e nenhuma configuracao mudou na VPS.

- A DSL da Clinica declara filas para transcricao/resumo de texto; a DSL do
  Memorias declara pedido/retorno de renderizacao. A topologia e recriada pelo
  inicializador a partir desses contratos. Credenciais tecnicas estao no JSON
  privado e nao precisam ser extraidas do volume do broker para essa finalidade.
- O publisher usa mensagens marcadas Persistent e o inicializador respeita
  Durable das filas. Esses nomes tecnicos nao decidem a categoria de backup.
- O transportador da Clinica marca yOutbox.Status=1 apos publicar. ClaimBatch
  seleciona Status=0 e locks Status=9 expirados, nao os enviados Status=1.
  O transportador de renderizacao do Memorias tambem marca a outbox como enviada.
  Portanto, restaurar o SQL nao demonstra reenvio automatico de tudo que estava
  no RabbitMQ. Nao redefinir mensagens enviadas por suposicao: pode duplicar efeitos.
- O worker Python da Clinica publica a transcricao em audio.transcribed.inbox;
  o texto chega ao SQL apenas depois da recepcao pelo aplicativo. Pode haver
  resultado pronto no broker e ainda nao persistido na Inbox/prontuario.
- O Compose Shared nao declara mount explicito para /var/lib/rabbitmq. O
  inventario anterior registrou um volume anonimo. A copia online atual nao
  cobre o estado vivo desse broker; a captura coordenada e uma etapa separada,
  ainda nao provada. Nenhuma protecao foi ativada por esta investigacao.
- Pendencia independente: RabbitMQQueueListener confirma a mensagem mesmo
  apos excecao do handler; tambem ha retorno Error convertido em State sem
  garantia, no listener, de recusa da confirmacao. O ConnectionManager registra
  confirmacao do publisher como pendencia. Backup nao corrige essas janelas
  de perda; revisar pelo mecanismo padrao de entrega, sem criar outro transporte.

Exemplo de perda: tarefa enviada consta no SQL como enviada, mas a solicitacao
ou o resultado aguardando consumo desaparece junto com o broker. Uma saga pode
continuar esperando; o processamento nao e necessariamente retomado sozinho.
Arquivos de audio/video volateis ausentes tambem podem impedir reprocessamento.

A recomendacao inicial de persistente NAO foi adotada. DECISAO DO USUARIO:
VOLATIL. Planejar o broker fora da selecao de backup, sem desativar por isso a
durabilidade de entrega em operacao normal. A possibilidade de perder pendencias
na recriacao foi explicitada; nao prometer retomada automatica pelo SQL enquanto
ela nao existir. Isso nao e aceite automatico para perder mensagens por erro de
recebimento com o ambiente funcionando. Credenciais de ambiente e tabelas SQL
mantem a classificacao persistente ja aprovada.

Status: CLASSIFICACAO CONFIRMADA, ADEQUACAO DA CAPTURA COORDENADA PENDENTE.
Nenhuma mensagem foi apagada, reenviada ou alterada; nenhuma configuracao mudou.

Esclarecimento sobre intencao do ACK, solicitado pelo usuario:

- Existe comentario explicito no listener: ACK SEMPRE (ou voce pode sofisticar
  depois). Isso demonstra comportamento deliberado no codigo, mas nao documenta
  uma decisao de negocio para cada categoria de falha. O motivo de evitar
  redelivery infinito e plausivel, nao comprovado por esse comentario.
- O retorno da IA pode representar falha do trabalho. Se o recebimento grava
  esse fato em yInbox com sucesso, confirmar a mensagem e coerente: o erro foi
  recebido e sua continuidade/retry pertence ao processamento SQL da Inbox/Saga.
  Nao exigir sucesso de toda a saga para retirar a mensagem de transporte.
- No caminho consultado da Clinica, InboxListenerHandler captura erro de
  AddInboxEvent e devolve State de erro; o QueueListenerWorker gerado ignora
  esse resultado. Em outro caminho, uma excecao propagada tambem e capturada
  pelo listener, que imprime no console e chama BasicAckAsync depois do catch.
  Nao foi identificado armazenamento alternativo da mensagem nesse tratamento.
- Assim, indisponibilidade SQL antes de inserir a Inbox pode resultar em ACK
  sem custodia duravel. Distinguir essa falha de recebimento da falha de negocio
  ja recebida/persistida. Registro em console nao comprova recuperacao do payload.
- Confirmacao AMQP permite ao broker descartar a entrega; nao e somente aviso
  de que o codigo foi chamado. Referencia: [RabbitMQ: Consumer Acknowledgements](https://www.rabbitmq.com/docs/confirms#consumer-acks).
- Qualquer alteracao deve ser decidida separadamente: sucesso/duplicidade
  reconhecida/falha de negocio assumida podem encerrar a entrega; falha de
  custodia ou mensagem invalida exigem politica explicita, evitando tanto perda
  silenciosa quanto reentrega infinita. Nao aplicar requeue=true indiscriminado.

Nenhuma regra de ACK, retry, confirmacao de publicacao ou listener foi alterada.

DECISAO FINAL DO USUARIO: deixar RabbitMQ VOLATIL e nao mudar o conceito atual.
Preservar integralmente o comportamento existente de recebimento, confirmacao,
retry e tratamento de erros. A analise acima fica como registro informativo,
nao como autorizacao ou atividade pendente de correcao nesta tarefa. Alterar o
escopo do backup nao deve modificar o protocolo de entrega. Nenhuma mudanca de
runtime ou operacao na VPS foi feita para aplicar esta decisao.

#### 3. Redis: Servico Presente, Consumidor Nao Identificado

Conferencia local em 2026-10-20, sem consultar chaves/valores, limpar dados,
parar containers ou mudar a VPS. Classificacao confirmada pelo usuario: VOLATIL.

- O Compose Shared declara redis:7-alpine, container yeshua-redis, sem mount
  explicito. O deploy Shared inclui o servico. O inventario anterior registrou
  um volume Docker anonimo; nao foi feita nova inspecao do conteudo desse volume.
- O Studio de ambiente Production tambem declara redis01. Isso confirma a
  previsao de infraestrutura, nao o uso dos dados por uma aplicacao.
- A busca nos fontes/configuracoes consultados nao encontrou cliente Redis,
  leitura/escrita de chaves, IDistributedCache ou result_backend Redis. O mapa
  de configuracoes ja registra Redis__Host removido dos Compose ativos por
  ausencia de consumidor. O template inicial antigo ainda contem essa chave;
  sua presenca nao demonstra que o host gerado a utiliza.
- O template de DI da Engine registra ICacheService<> como MemoryCacheService<>,
  cuja implementacao usa IMemoryCache dentro do proprio processo. Esse cache
  nao pertence ao container Redis e nao depende de seu volume para funcionar.
- Os Celery consultados da Clinica (transcricao/resumo) e do renderer Memorias
  configuram broker AMQP por CELERY_BROKER_URL, sem backend Redis de resultados.
  Os retornos usam as filas correspondentes; nao foi identificado polling de
  AsyncResult/result_backend para recuperar o resultado via Redis.

Conclusao limitada ao codigo consultado: o Redis esta previsto/subindo na
infraestrutura, mas nao foi identificada dependencia ativa das aplicacoes ou
dado exclusivo de negocio salvo nele. Isso nao prova que o Redis publicado
esteja vazio nem descarta um cliente externo nao representado neste repositorio.

DECISAO DO USUARIO: VOLATIL, fora do backup. Manter o servico como
esta nesta revisao; desligar/remover container ou volume e outra decisao, nao
uma consequencia automatica da classificacao. Nao alterar o cache em memoria,
o broker RabbitMQ, a DSL ou os workers Python por causa desta investigacao.

Status: CLASSIFICACAO CONFIRMADA, ADEQUACAO DA CAPTURA COORDENADA PENDENTE.
Nenhuma configuracao/dado mudou na VPS.

#### 4. Historico De Telemetria: Logs, Metricas E Rastros

Conferencia local em 2026-10-20, sem consultar conteudo de logs, alterar retencao,
parar servicos ou acessar a VPS. Classificacao confirmada pelo usuario: VOLATIL.

- O container yeshua-telemetry usa grafana/otel-lgtm e recebe a telemetria OTLP
  das aplicacoes. O Collector encaminha logs ao Loki, metricas ao Prometheus e
  rastros ao Tempo. Ha tambem pipeline de profiles configurado; isso nao comprova
  que exista produtor ativo desse sinal.
- A configuracao versionada do Loki aponta seus arquivos para /data/loki,
  incluindo chunks/indices/retencao. Define retention_period=120h e habilita
  retencao no compactor: previsao de historico rotativo de cinco dias.
- O Tempo aponta WAL/blocos para /data/tempo e configura block_retention=120h.
  O Prometheus recebe limites de retencao de cinco dias e tamanho padrao de 2GB
  via Compose (o tamanho e configuravel). O log Docker do container e rotativo,
  com tres arquivos de 10MB. Sao limites declarados, nao uma medicao atual da VPS
  nem garantia de limite rigido para o tamanho total do bind.
- Collector, Loki, Tempo e Prometheus tem configuracoes no Git. Essas definicoes
  podem ser repostas pelo deploy, mas nao recriam o historico observado.
- O consumo identificado do historico e diagnostico/observabilidade, inclusive
  consultas/coleta de evidencias pela API operacional. Perder esse historico
  reduz investigacao de execucoes anteriores; nao apaga cadastros, documentos ou
  Inbox/Outbox/Saga dos bancos SQL dos aplicativos. O banco da inteligencia
  operacional continua sendo banco de aplicativo persistente, fora deste item.
- O Compose atual monta /root/YeshuaDB/persistent/telemetry inteiro em /data.
  A copia online nao inclui esse estado vivo. A area ainda consta no modelo de
  captura coordenada; mudar a classificacao exige adequar o destino/raizes na
  implementacao, nao excluir subpastas por filtro dentro de persistente.

DECISAO DO USUARIO: historico de diagnostico VOLATIL, sem backup.
Na recriacao, os coletores passam a formar historico novo; o antigo nao volta.
Nao alterar a retencao ou desligar observabilidade por causa dessa classificacao.

ESCOPO: a investigacao do estado proprio do Grafana foi apresentada em separado
no item 5 e tambem resultou em VOLATIL. Historico e estado runtime do pacote
podem, portanto, usar raiz volatil na futura instalacao. Configuracoes versionadas
e credenciais privadas tem suas proprias origens de recuperacao; o SQL operacional
nao pertence a esse bind. Nao filtrar subpastas dentro da raiz persistente antiga
nem mover/excluir seu conteudo antes da transicao adiada.

Status: CLASSIFICACAO CONFIRMADA, ADEQUACAO DAS RAIZES PENDENTE.
Nenhuma configuracao/dado mudou na VPS.

#### 5. Estado Do Grafana: Paineis E Ajustes Pela Interface

Conferencia local e das fontes oficiais em 2026-10-20. Nao houve leitura de
banco/painel/usuario da VPS, mudanca de credenciais, export de dados ou reinicio.
Classificacao confirmada pelo usuario: VOLATIL. A conferencia nao comprovou
ausencia de personalizacoes publicadas; a decisao define como elas devem ser
mantidas daqui em diante, sem exigir uma copia do estado interno atual.

- O Compose define usuario/senha de provisionamento por variaveis vindas de
  Shared.Grafana no credentials.json privado. Esse arquivo continua persistente.
  Rotas /telemetry, ajustes de subpath e configuracoes de coleta estao no Git.
- A imagem oficial inclui definicoes padrao de datasources e dashboards. Na
  busca no repositorio Yeshua nao foram identificados paineis/provisionamentos
  Grafana customizados versionados. A imagem pode repor seu proprio padrao,
  mas isso nao significa repor edicoes feitas pela interface.
- Grafana usa um banco interno para usuarios/paineis e outras configuracoes;
  o padrao documentado e SQLite. Esse estado nao e um banco de aplicativo dos
  Studios nem esta coberto pela rotina SQL Server de full/diferencial/logs.
- A fonte upstream atual do otel-lgtm aponta os dados Grafana para
  /data/grafana/data e os plugins para /data/grafana/plugins. Nosso Compose
  monta /root/YeshuaDB/persistent/telemetry em /data. Como a tag padrao e latest,
  o caminho/versao efetivos devem ser confirmados antes de uma implementacao:
  fonte upstream atual nao e prova da imagem instalada na VPS.
- Paineis, contas/permissoes, fontes de dados e regras de alerta criados ou
  modificados pela interface podem representar configuracao unica. Sem
  preservacao/versionamento correspondente, esses ajustes precisarao ser
  refeitos apos recriar o Grafana. Nao afirmar que existem ou que sao dispensaveis
  sem inventario/autorizacao ou confirmacao do usuario.
- A senha administrativa de provisionamento e aplicada na criacao inicial.
  Uma senha alterada na interface nao e necessariamente a mesma guardada no
  JSON; preservar o bootstrap nao equivale a recuperar o cadastro de usuarios.

DECISAO DO USUARIO: estado Grafana VOLATIL, fora do backup. Personalizacoes
devem ser criadas e mantidas na infraestrutura recuperavel, nao depender de
edicoes feitas apenas na interface. Definicoes de paineis, alertas e fontes de
dados devem usar os arquivos/provisionamento nativos versionados em infra;
valores secretos continuam no JSON privado existente, nunca nesses arquivos Git.
Na recriacao, provisionar a partir dessas fontes. Nao criar outra DSL, camada
de configuracao ou copia do SQLite para substituir esse caminho.

A regra de autoria nao e uma autorizacao para bloquear a interface, mudar
permissoes/usuarios, apagar personalizacoes publicadas ou reiniciar o Grafana.
Nao foram criadas personalizacoes por esta decisao. Adequar apenas a infraestrutura
local/roteiro quando a implementacao das classificacoes for retomada; a transicao
de dados e a recriacao da VPS continuam adiadas.

Fontes oficiais consultadas: [configuracao e banco do Grafana](https://grafana.com/docs/grafana/latest/setup-grafana/configure-grafana/),
[backup do Grafana](https://grafana.com/docs/grafana/latest/administration/back-up-grafana/),
[imagem e provisionamento padrao](https://github.com/grafana/docker-otel-lgtm/blob/main/docker/Dockerfile),
[paths de inicializacao](https://github.com/grafana/docker-otel-lgtm/blob/main/docker/run-grafana.sh).

Status: CLASSIFICACAO CONFIRMADA, ADEQUACAO DAS RAIZES PENDENTE.
Nenhuma configuracao/dado mudou na VPS.

#### 6. Volumes Do Agente Operacional

DECISAO DIRETA DO USUARIO: VOLATEIS. A investigacao foi interrompida pelo usuario
apos identificar os tres mounts no Compose; nao afirmar que houve inventario do
conteudo, de alteracoes locais ou de autenticacoes existentes nesses volumes.

Escopo confirmado: operational-agent-workspace (/workspace),
operational-agent-codex (/home/agent/.codex) e
operational-agent-claude (/home/agent/.claude). Esses volumes nao entram no backup.
Sua recriacao nao promete recuperar sessoes ou trabalho local nao publicado.
Fontes/infra recuperaveis continuam tendo o Git como origem, nao uma copia do
workspace do agente no backup de dados.

Regra adicional do usuario: se algum estado funcional do agente precisar de
persistencia, coloca-lo no banco correspondente que ja tem backup, pelo caminho
normal de aplicacao/repositorio. Nao criar um cofre de estado paralelo em arquivo,
outro banco avulso ou um backup particular para esses volumes. Isso e uma regra
para funcionalidades que vierem a exigir persistencia, nao a alegacao de que
elas ja gravam no SQL.

Credenciais tecnicas de ambiente continuam no arquivo privado padrao; esta
decisao nao manda copiar tokens/sessoes das CLIs para o banco nem altera o modelo
de autenticacao dos agentes. A regra tambem nao habilita escrita no agente
observador/build-only, nao cria tabelas e nao executa migrations.

Status: CLASSIFICACAO CONFIRMADA, ADEQUACAO DA CAPTURA COORDENADA PENDENTE.
Nenhum volume, arquivo, banco ou container foi alterado ou apagado na VPS.

#### 7. Bancos De Sistema SQL: master, model, msdb E tempdb

Conferencia local e de documentacao oficial em 2026-10-20. Nao houve nova
consulta SQL, leitura de senhas/chaves, execucao de jobs ou operacao na VPS.
Esta investigacao nao decide a base legada Estudo, que sera um item separado.

- master guarda metadados/configuracoes da instancia, incluindo contas de
  acesso e referencias aos bancos. model serve de modelo para bancos novos.
  msdb guarda rotinas/agendas do SQL Agent e historicos administrativos.
  tempdb e uma area temporaria recriada na inicializacao e nao aceita backup.
- O codigo do operador atual seleciona todos os bancos, exceto tempdb. Portanto,
  ja inclui master/model/msdb via backup SQL nativo, sem copiar MDF/LDF ativos.
  No ciclo diferencial, os bancos de sistema recebem full; no ciclo de logs,
  sao ignorados. Nao ha nova agenda ou modelo de backup por banco nesta revisao.
- A recuperacao automatica dos bancos de usuario nao restaura esses tres bancos
  de sistema. O roteiro existente mantem seu uso/recuperacao como procedimento
  assistido, evitando sobrescrever a instancia nova com caminhos/estado antigos.
- O inventario anterior, registrado no plano/RECOVERY.md, encontrou cinco jobs
  habilitados, sem agenda, e SQL Agent parado. Isso nao prova que sejam uteis,
  descartaveis ou de backup. O conteudo/uso dessas rotinas nao foi investigado
  novamente nesta etapa, nem elas foram ativadas/excluidas.
- Na busca local dirigida nao foram identificados scripts de criacao desses
  jobs, provisionamento de logins SQL ou demais customizacoes da instancia em
  infra/Engine. Credenciais no JSON privado, sozinhas, nao comprovam recriacao
  de todos os logins/permissoes/configuracoes existentes.

Conclusao: o estado PADRAO e recriavel, mas a reconstituicao integral das
customizacoes ainda nao foi demonstrada. Nao aplicar a regra "recriavel a partir
do fonte" a esse estado sem identificar o que e necessario e onde foi declarado.
Tambem nao presumir dependencia de chaves de criptografia inexistentes: isso
exigiria conferencia especifica antes de qualquer recuperacao/descarte.

DECISAO POSTERIOR CONFIRMADA: o usuario informa que nao guarda dados necessarios
em master/model/msdb e determinou que os acessos sejam criados na recriacao do
servidor. Esses tres bancos, assim como tempdb, ficam fora do backup. A sugestao
anterior de manter copias de sistema foi rejeitada. Nao exportar logins/jobs para
contornar a decisao nem criar outro backup de estado administrativo.

O provisionamento pertence a infraestrutura versionada, com segredos no arquivo
privado. Deve criar os logins/usuarios/permissoes necessarios na instalacao e
conferir seu vinculo aos bancos de aplicativos restaurados antes de liberar os
hosts. Nao recriar indiscriminadamente os cinco jobs antigos nem ativar SQL Agent.
Essa exigencia esta na lista de atividades; a automacao ainda nao foi comprovada.

Fontes oficiais: [backup/restauracao de bancos de sistema](https://learn.microsoft.com/en-us/sql/relational-databases/backup-restore/back-up-and-restore-of-system-databases-sql-server?view=sql-server-ver16),
[metadados do master](https://learn.microsoft.com/en-us/sql/relational-databases/databases/master-database?view=sql-server-ver16).

Status: SELECAO SQL E PROVISIONAMENTO IMPLEMENTADOS LOCALMENTE em 2026-10-21.
Grants/vinculos reais ainda precisam do ensaio. Jobs, acessos e VPS nao foram
alterados operacionalmente; snapshots antigos nao foram apagados.

#### 8. Banco Adicional Estudo

Conferencia local em 2026-10-20, sem nova consulta SQL ou operacao na VPS.

- O inventario anterior encontrou Estudo ONLINE na mesma instancia, alem dos
  seis bancos Yeshua. Nao e banco de sistema; a decisao sobre master/model/msdb
  nao o exclui automaticamente.
- Na busca dirigida em src, infra, tests, tools e docs, nao foi identificada
  referencia de configuracao ou Studio usando o catalogo Estudo. As ocorrencias
  restantes sao registros do inventario ou uso comum da palavra "estudo".
  Ausencia de referencia local nao comprova ausencia de consumidores externos.
- Nao foram inspecionados tabelas, conteudo, sessoes atuais ou responsavel pela
  base nesta etapa. Nao inferir que seja vazio, descartavel ou recriavel pelo nome.
- A selecao atual descobre bancos de usuario e ainda inclui Estudo. Nenhum banco
  foi apagado ou excluido; snapshots anteriores permanecem intactos.

Resposta do usuario: nao recorda a finalidade da base. Isso nao e autorizacao
para descartar ou excluir do backup. Identificacao fica pendente, sem presumir
que seja uma base de testes e sem classificar os demais bancos por consequencia.

CONFERENCIA REAL SOLICITADA PELO USUARIO em 2026-10-20: API operacional publicada
respondeu healthy; chamadas MCP yeshua.database.select pela conexao configurada
Central consultaram somente metadados de Estudo e DMVs. Nao houve SSH, leitura
de registros de negocio/credenciais, alteracao SQL, deploy ou reinicio.

Resultados:

- Estudo ONLINE, FULL, sem criptografia declarada em sys.databases. Arquivos
  com 712 MiB de dados e 1.608 MiB de log ALOCADOS (2.320 MiB, cerca de 2,27 GiB).
  Nao confundir alocacao com dados uteis, log utilizado ou tamanho de backup.
- 198 tabelas de usuario em tres schemas: dbo tem 187 tabelas, aproximadamente
  1.212 linhas e 13,18 MiB reservados; importacao tem quatro tabelas, 383 linhas
  e 3,59 MiB; importacao_tipado tem sete tabelas, 1.546.376 linhas e 652,80 MiB.
  Contagens sao estimativas dos metadados, sem COUNT de registros de negocio.
- Em dbo aparecem Carga, CargaPrevista, Cliente, CorridasOnduladeiraEstudo,
  BoletimEstudo, ySagaStep e yInbox. BoletimEstudo e CorridasOnduladeiraEstudo
  tambem estao declaradas em src/Studio/Yeshua.Studio.APS.ADM/Migrations/M000002.cs,
  com LegacySource. Isso demonstra correspondencia de estrutura, nao prova que
  o APS atual use o catalogo Estudo.
- importacao_tipado.t006 concentra cerca de 1.437.576 linhas e 515,57 MiB
  reservados. Nomes de colunas indicam funcionarios/usuarios e rastreabilidade
  de importacao (__archive_row_id, __source_database_id, __archive_imported_at).
  t003 tem cerca de 78.148 linhas e 99,57 MiB, com colunas de empresas e emissores
  fiscais. Ha nomes de colunas referentes a dados pessoais e senhas; nenhum valor
  foi lido. A consulta de colunas inicial limitada a 100 retornou truncated=true;
  uma consulta separada conferiu os primeiros 15 nomes da t006. Nao e inventario
  completo de todas as colunas.
- Nenhuma sessao de usuario com Estudo como banco atual apareceu no instante
  consultado. Contadores de uso de indices para Estudo nao retornaram ultimas
  leituras/escritas; SQL informou inicio em 2026-10-19. Essa observacao nao
  comprova ausencia de uso historico, acessos por outro contexto ou uso futuro.

Inferencia: provavel base de estudo/importacao do legado relacionada ao APS,
com dados importados, nao uma base vazia. Origem exata, responsavel e necessidade
de preservacao continuam sem confirmacao. Nao atribuir descarte automatico pela
ausencia momentanea de sessoes. Apresentar esses achados antes da decisao.

DECISAO POSTERIOR CONFIRMADA: usuario determinou manter o backup do Estudo.
Classificacao PERSISTENTE, banco inteiro, pelo mesmo backup SQL nativo dos
demais bancos de usuario. Nao criar agenda exclusiva nem excluir por nao constar
dos Studios/deploy.env. A reforma que retira bancos de sistema deve preservar
Estudo tanto na captura online quanto na coordenada e na recuperacao.

Status: CLASSIFICACAO CONFIRMADA, PERSISTENTE. Selecao atual ja inclui Estudo
e permanece mantida; nenhuma alteracao na VPS, exclusao ou limpeza executada.

#### 9. Cofre Privado YouTube Do Memorias

Conferencia dos fontes customizados e Compose locais em 2026-10-20, sem abrir
arquivos privados, consultar valores secretos ou operar a VPS.

- EncryptedYouTubeApplicationConfigurationRepository guarda configuracao Google
  em accounts/configuration/<hash-do-escopo>/oauth.bin e sua chave em key.bin.
  A configuracao salva pelo aplicativo tem precedencia sobre o bootstrap.
- EncryptedYouTubeAccountRepository guarda conexoes/autorizacoes dos canais
  em accounts/<hash-do-escopo>/tenants/<TenantId>/connection-*.bin. A identidade
  criptografica atual e v2, vinculada a ProcessingScope, tenant e finalidade.
  Manter arquivo cifrado sem a chave correspondente nao comprova recuperacao.
- O mesmo cofre tambem guarda estados de upload/recibos upload-*.bin e estados
  temporarios authorization-*.bin. Restaurar um arquivo nao valida novamente
  autorizacao expirada nem comprova retomada/estado externo de uma publicacao.
- Esses arquivos nao sao fotos, MP4 ou manifestos de renderizacao e nao ficam
  no banco SQL. Backup do banco sozinho nao recupera configuracao/conexoes.
- API e Worker montam Apps.Memorias.PrivateRoot em /memorias-secrets e usam
  /memorias-secrets/accounts. O backup de arquivos atual inclui essa raiz
  privada; nao foi medido novamente seu tamanho/conteudo na VPS nesta etapa.
- Essa configuracao pertence ao Memorias, nao a Central. Nao transferir tokens
  ou configuracao da integracao para a Central, remover a cifra existente,
  mudar precedencia ou gerar outra chave por causa desta revisao de backup.

DECISAO CONFIRMADA: usuario aprovou o cofre como PERSISTENTE, com copia integral
da area privada pelo fluxo comum, incluindo chaves correspondentes e preservando
identidade de escopo/tenant. Nao criar filtros de conteudo dentro de persistente
nem outro job/cofre. Fotos/videos locais continuam VOLATEIS.

A permissao anterior para descartar o estado de testes na futura reinstalacao
nao define a politica futura do cofre. A reinstalacao continua adiada e esta
classificacao nao autoriza limpar arquivos, migrar tokens ou ativar backup novo.

Curiosidade do usuario sobre arquivo versus SQL: manter o cofre nesta reforma
preserva o mecanismo que a integracao ja usava, sem misturar migracao de dados
com organizacao/backup. Nao ha exigencia tecnica de manter tokens em arquivos;
armazenamento cifrado no banco seria outra implementacao, com gestao de chave
separada. A pergunta nao aprova migracao, mudanca de criptografia ou nova camada.

RETOMADA ADIADA pelo usuario: explicar o mecanismo do cofre e avaliar eventual
uso do banco em outra conversa/etapa. Usuario reafirmou que nao e volatil.
Nao prosseguir nesse redesenho durante a classificacao dos demais itens.

Status: CLASSIFICACAO CONFIRMADA, PERSISTENTE. Selecao atual mantida; nenhuma
mudanca no aplicativo, banco, arquivos privados ou VPS. Restore ainda a provar.

#### 10. Arquivo Central De Credenciais Do Ambiente

Conferencia da documentacao infra/private/README.md e selecao local de arquivos,
sem abrir o JSON real ou mostrar senhas/chaves. Nenhuma operacao na VPS.

- /root/YeshuaPrivate/production/credentials.json e configuracao administrativa
  do ambiente, com Shared e Apps.<Aplicativo>. "Centralizado" nao significa
  pertencente ao aplicativo Central nem novo servico em runtime.
- Contem conexoes SQL dos apps e operacionais, autenticacao RabbitMQ, chaves JWT,
  autenticacao entre modulos, Grafana e assinatura de upload. Deploy le o arquivo
  privado; Compose recebe somente variaveis declaradas para cada consumidor.
  O JSON inteiro nao e montado nos containers e o Front nao recebe segredos.
- Integracoes externas de tenants/canais e o cofre YouTube continuam no respectivo
  aplicativo, fora deste JSON. Esta revisao nao altera essa separacao.
- O arquivo e consumido antes da subida dos servicos. Guardar sua unica copia
  dentro do banco que ele permite acessar criaria dependencia de recuperacao;
  nao propor essa mudanca ao discutir o armazenamento do cofre Memorias.
- O backup atual de arquivos inclui a raiz privada. O arquivo deve manter
  permissoes restritas e permanecer fora do Git/imagens/logs. O JSON nao cria
  logins SQL por si so: provisionamento de acessos na recriacao continua sendo
  obrigacao da infraestrutura registrada no item 7.

DECISAO CONFIRMADA: usuario determinou manter PERSISTENTE e seguro, com copia
integral da raiz privada pelo fluxo de arquivos existente, sem outro job ou
modelo de segredo. Privacidade e controle de acesso, nao categoria de backup.

Manter os controles existentes: diretorio 0700 e arquivo 0600 no Linux, fora
do Git/imagens/logs, sem expor valores em relatorios ou montar o JSON inteiro
nos consumidores. Copias permanecem no repositorio cifrado comum. Restaurar
configuracao e conferir permissoes antes de provisionar/subir consumidores,
sem regenerar chaves automaticamente. Nao acrescentar criptografia local ou
outro cofre; a chave de recuperacao do backup exige custodia independente.

Status: CLASSIFICACAO CONFIRMADA, PERSISTENTE COM ACESSO RESTRITO. Selecao atual
mantida, sem mudanca de arquivo privado, deploy ou servidor. Esta confirmacao
nao equivale a nova auditoria de seguranca ou prova de restauracao funcional.

#### 11. Chaves Dos Provedores Do Agente Operacional

Conferencia local de infra/private/credentials.py, infra/private/README.md e
Compose Shared, sem ler providers.json real, consultar valores ou operar a VPS.

- O arquivo opcional fica em shared/OperationalAgent/integracoes/providers.json
  sob a raiz privada do ambiente. Campos OpenAI.ApiKey e Anthropic.ApiKey alimentam
  OPENAI_API_KEY e ANTHROPIC_API_KEY do agente pelo leitor comum do deploy.
- O arquivo e configuracao de integracao do consumidor, nao conteudo dos volumes
  operational-agent-workspace/codex/claude. Sua existencia nao e obrigatoria para
  validar a infraestrutura basica; nao foi conferida novamente na VPS nesta etapa.
- Sessoes de login das CLIs, historicos, caches e arquivos do workspace continuam
  VOLATEIS conforme decisao anterior. Nao exportar sessoes/tokens desses volumes
  para providers.json, SQL ou backup em decorrencia desta investigacao.
- O backup de arquivos ja seleciona a raiz privada integralmente. Um providers.json
  presente nessa raiz e incluido; nao criar arquivo vazio, novas chaves ou agenda
  particular para justificar a cobertura.

DECISAO CONFIRMADA: usuario aprovou providers.json PERSISTENTE quando utilizado,
com acesso restrito, fora do Git/imagens/logs e no backup cifrado comum, conforme
o padrao privado existente. Isso nao transforma os volumes do agente em persistentes
nem transfere a integracao ao aplicativo Central.

Status: CLASSIFICACAO CONFIRMADA, PERSISTENTE COM ACESSO RESTRITO. Selecao atual
mantida, sem alteracao de chaves, containers, volumes ou servidor.

#### 12. Identidade HTTPS E Configuracao Certbot

Conferencia local de infra/bootstraps/setup-cert.sh, Compose Shared, template
20-https.conf.disabled e selecao de arquivos em 2026-10-20. Documentacao oficial
Certbot conferida; nenhuma chave privada, conta ou arquivo real foi aberto.
Nao houve consulta/operacao na VPS, emissao, renovacao ou parada do Nginx.

- Nginx monta /etc/letsencrypt como somente leitura e aponta para
  live/playsis.com.br/fullchain.pem e privkey.pem. O conteudo e identidade HTTPS
  do dominio, distinto dos certificados fiscais dos tenants.
- Certbot mantem certificados/chaves e configuracao de renovacao sob essa raiz,
  com referencias entre live/archive. Capturar apenas um .pem isolado nao e o
  mesmo que preservar a area e suas dependencias. Chaves privadas exigem sigilo.
- O backup atual inclui /etc/letsencrypt quando presente. Preservacao de links,
  permissoes e teste de uso/renovacao na restauracao ainda dependem do ensaio.
- setup-cert.sh instala Certbot e emite por standalone, podendo parar o gateway
  durante a emissao. Nao executar esse script para classificar os dados nem
  reemitir automaticamente durante restore de certificados existentes.
- Scripts/templates do provisionamento continuam recriaveis pelo Git. O estado
  emitido nao e o proprio fonte. Renovacao automatica e sua agenda/hooks nao
  foram conferidos em runtime; nao declarar que estao corretos ou quebrados.

DECISAO POSTERIOR CONFIRMADA: usuario escolheu area HTTPS VOLATIL, apos esclarecer
que setup-cert.sh ja permite emitir certificados na recriacao do servidor. Essa
decisao substitui a aprovacao inicial como persistente e retira a excecao proposta.
Novas capturas nao devem incluir /etc/letsencrypt; scripts/templates continuam no
Git. A selecao atual e as provas de cobertura ainda precisam dessa adequacao.
Nao mudar rotas, renovar, revogar certificados ou reiniciar servicos nesta revisao.

Fonte: [Certbot, arquivos e renovacao](https://eff-certbot.readthedocs.io/en/stable/using.html#where-are-my-certificates).

Status: CLASSIFICACAO CONFIRMADA, VOLATIL. Novas capturas v3 excluem HTTPS;
prova de recriacao PENDENTE. Nao houve deploy ou alteracao de
arquivos/configuracao na VPS. Recriar nao equivale a certificado automaticamente
valido: provar emissao/renovacao no momento apropriado, com dominio validavel.

#### 13. Credencial De Recuperacao Do Proprio Backup

Conferencia local de restic_env em infra/backups/backup.py e do roteiro de
recuperacao, sem ler Shared.Backup.Password, kit real ou chaves de acesso.

- O operador usa Shared.Backup.Password do JSON privado para abrir o repositorio
  Restic. Endereco e credenciais do armazenamento sao configurados no mesmo bloco;
  destino externo continua pendente, com repositorio LOCAL nesta fase.
- A copia do JSON dentro de um backup cifrado nao basta para abrir esse proprio
  backup. E necessaria custodia independente da senha e do acesso ao repositorio,
  fora da VPS e fora da unica copia que esses valores permitem descriptografar.
- Ha registro anterior de kit restrito fora da VPS no plano operacional; ele
  nao foi aberto nem revalidado nesta etapa. Nao afirmar disponibilidade atual
  ou recuperacao funcional a partir desse registro historico.
- Regenerar outra senha/chave do zero nao recria o acesso ao conjunto anterior.
  Nao trocar credenciais, criar kit novo nem registrar seus valores no Git/chat/logs
  por causa da classificacao. Fontes das ferramentas continuam recriaveis.

DECISAO/IMPLEMENTACAO SOLICITADA: credencial PERSISTENTE/restrita, com guarda
independente. Ao preparar o servidor e os agentes de backup, expor a senha ao
operador para guarda protegida, sem depender de uma copia somente no servidor.
Nao criar nova categoria, cofre ou modelo de criptografia.

IMPLEMENTACAO LOCAL ATUALIZADA: o setup chama configure-local/recovery-key logo
apos validar o JSON privado, antes de atualizacao geral/Docker/builds. Instala
somente Restic/util-linux antes disso se faltarem. O instalador final reutiliza
a confirmacao da mesma senha/repositorio/maquina, sem pedir nova atencao; depois
completa initialize_online/habilitacao das agendas, como antes.
Antes da guarda, init --wait aguarda o arquivo privado no caminho do servidor,
preparado em outra sessao e confirmado com PRONTO por /dev/tty, sem ler senhas
do stdin. Erros podem ser corrigidos na mesma execucao; arquivo valido e
reutilizado sem pergunta. CANCELAR/EOF/Ctrl+C ou ausencia de terminal quando
precisa de preparo interrompem antes dos servicos. Validacao/testes locais;
nenhum deploy, limpeza ou alteracao na VPS nesta etapa.
Senha/repositorio sao verificados pelo acesso Restic; EXIBIR autoriza exibir a
senha existente somente em /dev/tty e GUARDEI confirma a guarda fora da VPS.
Nao usar stdout/stderr capturados. Sem terminal privado, recusa ou interrupcao,
nao confirmar custodia nem seguir para atualizacoes/deploy. Apps/agendas preexistentes
nao sao desligados. O operador deve evitar gravacao/compartilhamento do terminal;
o script nao consegue detectar uma gravacao externa da sessao.

state/recovery-key-custody.json guarda hash de identificacao, maquina, data e
declaracao de guarda, sem senha. Mesmo repositorio/senha/maquina reutiliza essa
confirmacao; outra maquina ou senha exige nova confirmacao. Consulta posterior
exige recovery-key --show-recovery-key, mantendo consentimento/terminal privado.
configure-local recusa gerar senha substituta se o repositorio ja existe e a
senha original esta ausente. Nenhuma credencial real foi lida, criada ou trocada.

Status: IMPLEMENTADO LOCALMENTE, SEM DEPLOY. Testes usam somente dados ficticios;
terminal Linux real, guarda externa e recuperacao continuam para o ensaio futuro.
A declaracao de guarda nao equivale a prova de copia externa nem resolve a
pendencia do destino externo dos dados, que continuam locais nesta fase.

REVISAO DE OUTRAS CHAVES: nos caminhos de setup auditados, somente a senha do
backup e gerada e precisa de entrega manual para guarda independente. Credenciais
SQL/broker/JWT/assinatura e chaves de provedores sao entradas privadas existentes,
validadas no inicio, sem nova exposicao. A chave do cofre YouTube pode nascer ao
salvar configuracao no aplicativo, nao no setup; manter backup do cofre sem expor
essa chave aqui. Certificados fiscais sao fornecidos ao app e HTTPS e reemitivel.
Nao houve leitura de valores nem auditoria de chaves do sistema operacional.
Credencial do destino externo dos dados sera conferida quando ele for escolhido.

Verificacao local desta entrega: 17 testes novos de entrega/recusa/repeticao e
nao exposicao, suite de backup com 151 testes (149 aprovados, dois dependentes
de ferramentas/permissoes Linux), 25 testes de configuracao privada aprovados
e teste Bash simulado do setup aprovado. Nenhuma credencial real utilizada.
O teste do setup tambem cobre guarda antes de apt upgrade/deploy, recusa no
inicio, servidor sem Restic e falha nos pre-requisitos, sem comandos reais de infra.

## 1. Decisao Principal

Definir a estrategia da area uma vez. Ao criar um recurso, escolher uma area
adequada; seus arquivos herdam a politica dessa area. Uma tabela nova herda a
politica do banco, sem configurar backup por entidade, coluna ou tenant.

```text
Recurso do aplicativo
        -> area logica ou banco conhecido
        -> configuracao do ambiente resolve o destino fisico
        -> politica da area define como proteger
        -> rotina de infraestrutura captura
        -> checagem e restore demonstram a protecao
```

Associar nao significa comprovar. Um caminho estar em uma lista ou conter a
palavra persistent nao demonstra que o backup funciona.

O vinculo e feito por aplicativo + ambiente + area. O backup da area inclui
todos os tenants e todos os descendentes admitidos; nao se cadastra uma regra
de backup por usuario, album, carga, arquivo ou nova subpasta.

Reutilizar area existente nao exige alterar o cadastro nem executar um novo
restore manual a cada item. O dado entra no proximo ciclo regular da politica,
sujeito ao RPO combinado; heranca nao significa copia imediata. Area vazia nova
pode ter bind/captura/restore demonstrados com dados sinteticos antes de uso.

## 2. Niveis E Politicas Reutilizaveis

Os niveis B0-B5 do plano continuam identificando camadas, nao uma escala de
sensibilidade. Os nomes abaixo sao perfis operacionais propostos, nao classes
C#, conceitos de dominio ou uma nova taxonomia de observabilidade.

Os quatro perfis essenciais abaixo usam a mesma politica, retencao e
repositorio. Cadencias SQL/arquivos/integridade pertencem aos metodos comuns,
nao a um script por aplicativo. Para o aplicativo, basta banco, persistente nao privado,
persistente privado ou volatil comprovado. Reconstruivel exige prova e nao
cria outra rotina. Os IDs existentes sao referencias de inventario, nao uma
nova sintaxe DSL ja implementada.

| Perfil de captura ou exclusao | Nivel | O que recebe | Protecao herdada |
| --- | --- | --- | --- |
| SQL_ESSENCIAL | B1 | Bancos de aplicativos e estado transacional | Backup SQL nativo integral; logs conforme recovery model; prova de restore |
| ARQUIVOS_ESSENCIAIS | B2 | Originais, documentos, manifestos e arquivos necessarios a retomada | Captura consistente, copia externa cifrada, integridade e vinculo com o banco |
| SEGREDOS_ESSENCIAIS | B3 | Cofres, chaves, certificados e credenciais persistentes | Diretorio privado e acesso restrito, sem cifra local obrigatoria; backup externo cifrado e recuperacao comprovada |
| CONFIGURACAO_ESSENCIAL | B0/B3 | Configuracao efetiva, versoes, topologia e acesso de recuperacao | Copia apos mudanca e no conjunto coerente; Git sozinho nao cobre configuracoes privadas |
| EVIDENCIA_SELETIVA | B4 | Recortes de incidente e evidencias operacionais | Captura explicita e restrita; nao promete preservar todo o historico rotativo |
| RECONSTRUIVEL | B0 | Arquivo cuja origem e receita de reconstrucao foram comprovadas | Preservar origem, versao, hash e receita; nao copiar o conteudo em cada ciclo |
| TEMPORARIO | Fora da copia periodica | Intermediarios descartaveis que nao sao a unica origem | Nao copiar; prazo de limpeza separado e nunca inferido apenas pelo nome |
| IMAGENS_ADIADAS | B5 | Imagens Docker e snapshot integral da VPS | Nao implantar agora; registrar versoes e risco de rebuild |

SQL_ESSENCIAL, ARQUIVOS_ESSENCIAIS e SEGREDOS_ESSENCIAIS participam do mesmo
conjunto coerente quando dependem uns dos outros. CONFIGURACAO_ESSENCIAL
acompanha esse conjunto. Frequencia, retencao e janela seguem o plano
operacional, sem repetir os valores em cada aplicativo.

O plano inicial propoe copia diaria e 7 diarias/4 semanais/3 mensais; nao e
garantia ja entregue. Perfis com menor perda aceitavel podem ser definidos
depois, uma vez para todos os recursos que os escolherem. Bancos ja em FULL
precisam de rotina de log desde a implantacao inicial, nao apenas nessa evolucao.

Privacidade e politica de backup sao escolhas distintas: um temporario pode
ser sensivel e exigir acesso restrito mesmo sem backup. Nao publicar uma area
so porque ela e protegida. Retencao de backup tambem nao define por quanto
tempo o aplicativo deve guardar ou apagar documentos de negocio.
Persistente nao privado nao significa acesso anonimo a documentos de clientes.

SEM_CLASSIFICACAO e uma pendencia, nunca um sinonimo de TEMPORARIO. Recurso
desconhecido nao deve ser apagado nem considerado protegido.

### 2.1 Padrao Unico Para Persistente Privado

Decisao confirmada em 2026-10-19: configuracoes com senha SQL, broker e chaves
de integracao ficam em arquivos privados, fora do Git/imagem/gateway e com
acesso apenas aos consumidores autorizados. Podem permanecer em texto nesses
arquivos; nao sera criado um formato cifrado generico nem uma nova chave para
abrir cada configuracao. Permissoes e mounts sao a protecao local inicial.

Memorias continua com seu formato cifrado e sua chave persistente existentes;
isso nao exige criar o mesmo formato em todos os outros aplicativos nem remover
sua protecao atual. Nenhuma chave, certificado ou arquivo foi alterado.

O backup dessa area continua criptografado. Os arquivos locais nao sao cifrados
pelas permissoes, e administrador/comprometimento completo do host continua
sendo um limite desse modelo. A referencia detalhada esta na secao 2.6 do plano.

## 3. Estado De Cobertura

Controlar separadamente a classificacao e sua evidencia:

| Estado | Significado |
| --- | --- |
| MAPEADO | Origem e politica propostas; estado inicial deste documento |
| CONFIRMADO_NO_SERVIDOR | Caminho, banco, dono, volume e mounts reais conferidos |
| CAPTURA_ATIVA | Rotina concluida e copia externa identificada para a area |
| RESTORE_COMPROVADO | Recuperacao dessa area e suas dependencias demonstrada |
| LACUNA | Origem desconhecida, fora do mount, sem adaptador ou sem politica aprovada |

Guardar data e SetId da ultima captura e do ultimo restore. Uma prova antiga
nao cobre automaticamente troca de chave, formato, tecnologia ou destino.

Nenhum recurso deste mapa e apresentado como CAPTURA_ATIVA ou
RESTORE_COMPROVADO. Essas evidencias dependem do inventario e dos ensaios reais.

## 4. Mapa Completo Do Escopo Identificado

Os IDs sao nomes estaveis propostos para discutir os vinculos. Os caminhos sao
os declarados hoje, nao destinos novos ja criados. Substituicoes por ambiente
e recursos existentes apenas no servidor permanecem para confirmacao.

```text
Ambiente publicado
  Bancos: Central, Clinica, APS.ADM, Fiscal, Memorias, Operational Intelligence
  Arquivos: originais, documentos, audios, fotos, videos, XMLs e planos
  Privados: cofres, certificados, tokens, recibos e chaves
  Configuracao: release, infra efetiva, acessos, agendas e topologia
  Operacao: evidencias selecionadas e configuracoes nao versionadas
  Lacunas: uploads no container, mensagens e destinos nao inventariados
  Reconstruiveis: somente o que tem origem/receita comprovadas
  Temporarios: somente copias/intermediarios sem valor exclusivo
  Adiados: imagens Docker e snapshot integral da VPS
```

### 4.1 Bancos E Estado Transacional

| ID | Origem declarada | Politica | Dependencias e observacoes |
| --- | --- | --- | --- |
| DB_CENTRAL | YESHUA_CENTRAL | PERSISTENTE, confirmado | Banco inteiro; tenants, usuarios, concessoes, sequencias globais, historico de autorizacao e migrations |
| DB_CLINICA | YESHUA_CLINICA | PERSISTENTE, confirmado | Banco inteiro; dados clinicos/financeiros, uploads e sagas; arquivos externos seguem revisao propria |
| DB_APS_ADM | YESHUA_APS_ADM | PERSISTENTE, confirmado | Banco inteiro; pedidos, cargas, snapshots, sagas e contratos com Fiscal |
| DB_FISCAL | YESHUA_FISCAL | PERSISTENTE, confirmado | Banco inteiro; documentos, protocolos, planos, referencias e estado das sagas |
| DB_MEMORIAS | YESHUA_MEMORIAS | PERSISTENTE, confirmado | Banco inteiro; albuns, fotos, publicacoes e canais; arquivos/cofre seguem revisao propria |
| DB_OPERATIONAL_INTELLIGENCE | YESHUA_OPERATIONAL_INTELLIGENCE | PERSISTENTE, confirmado | Banco inteiro por ser aplicativo definido em Studio; sem exclusao de tabelas reconstruiveis |
| DB_SQL_SYSTEM | master, msdb, model e tempdb | VOLATIL / recriavel, fora do backup, confirmado | Provisionar acessos necessarios pela infraestrutura e arquivo privado; selecao SQL e prova de recriacao pendentes. Nao recriar jobs antigos por suposicao |
| DB_ESTUDO | Estudo, metadados conferidos via API operacional | PERSISTENTE, confirmado | Banco inteiro, backup nativo na rotina comum, mesmo sem Studio identificado. Manter na captura/recuperacao ao excluir bancos de sistema; nao criar agenda particular |
| DB_LEGADOS | Context_CLINICA e outros bancos eventualmente encontrados | SEM_CLASSIFICACAO ate inventario | Nao excluir por nao aparecerem no deploy.env; identificar presenca, uso, dono e necessidade separadamente de Estudo |
| DB_LEITURA_FUTURO | Eventual banco separado de leitura de aplicativo | PERSISTENTE | A regra de todos os bancos dos aplicativos tambem cobre novas bases de leitura; nao presumir exclusao por replay |

Toda tabela do banco entra: tabelas Y, negocio, Saga/Step, Inbox/Outbox,
idempotencia, sequencias e ledgers. Nao excluir essas tabelas como se fossem
cache. Bancos de sistema ficam fora por decisao explicita, sem reduzir a cobertura
dos bancos de aplicativos; acesso e provisionado na recriacao do servidor.

Replicacao nao substitui backup. Dois bancos contendo a mesma exclusao
acidental nao oferecem um ponto anterior recuperavel.

### 4.2 Arquivos De Negocio

| ID | Origem ou localizador atual | Politica proposta | Decisao de recuperacao |
| --- | --- | --- | --- |
| MEMORIAS_FOTOS | /root/YeshuaStorage/persistent/memorias/photos (destino atual a corrigir) | VOLATIL por padrao, confirmado | Direcionar a StorageLocation volatil; preservacao paga por tenant/usuario fica na pendencia 0.4, nao implementada |
| MEMORIAS_VIDEOS_LOCAIS | /root/YeshuaStorage/persistent/memorias/publicacoes/{id}/video.mp4 (destino atual a corrigir) | SEMPRE VOLATIL, confirmado | Sem preservacao paga; direcionar via StorageLocation a volatil e tratar ausencia/limpeza na aplicacao |
| MEMORIAS_PUBLICACOES | /root/YeshuaStorage/persistent/memorias/publicacoes/{id}/manifest.json (destino atual a corrigir) | VOLATIL, confirmado | Instrucoes de renderizacao para o Python; direcionar via StorageLocation e tratar ausencia na aplicacao; .render-* tambem volatil |
| MEMORIAS_MUSICAS | /root/YeshuaStorage/persistent/memorias/music (destino atual a corrigir) | Trilhas padrao versionadas VOLATEIS, confirmado | Repor do Git/deploy com hash; eventuais arquivos nao versionados exigem identificacao/classificacao propria |
| CLINICA_DOCUMENTOS_ENTRADA | /root/YeshuaStorage/persistent/docs/input | RETIRADA APROVADA, implementacao pendente | Nenhum consumidor de negocio identificado; retirar declaracao/configuracao sem apagar pastas existentes |
| CLINICA_DOCUMENTOS_SAIDA | /root/YeshuaStorage/persistent/docs/output | RETIRADA APROVADA, implementacao pendente | Mesma investigacao; prontuario/RegistroDocumental continuam em SQL persistente |
| DOCUMENTOS_LEGADOS | /root/YeshuaStorage/persistent/Docs/input e output | RETIRADA APROVADA, implementacao pendente | Retirar criacao automatica com D maiusculo; nao apagar conteudo existente nem filtrar persistente |
| CLINICA_AUDIO_ORIGINAL | /root/YeshuaStorage/volatile/ia/transcriptions/input | VOLATIL, confirmado individualmente | Ja usa StorageLocation.Volatile.TranscriptionsInput; tratar ausencia/reenvio e limpeza na aplicacao; nenhuma exclusao da origem nesta revisao |
| CLINICA_TRANSCRICAO_ARQUIVOS | /root/YeshuaStorage/volatile/ia/transcriptions/output | VOLATIL, confirmado individualmente | Audio baixado/WAV dos dois workers Python usam esta area sob STORAGE_ROOT, com criacao registrada e limpeza por tentativa; sobras ficam na raiz da limpeza de 7 dias. Texto salvo no banco permanece persistente; IA segue desativada |
| CLINICA_RELATORIOS_ENTRADA | /root/YeshuaStorage/volatile/reports/input | VOLATIL, confirmado individualmente | Manter classificacao existente, por decisao do usuario; origem/uso nao comprovados no codigo conferido; nenhuma limpeza ativada |
| CLINICA_RELATORIOS_SAIDA | /root/YeshuaStorage/volatile/reports/output | VOLATIL pela regra confirmada | Area ja volatil permanece volatil; tratamento de ausencia/limpeza pertence a aplicacao; nenhuma limpeza ativada |
| FISCAL_PLANOS | /root/YeshuaStorage/fiscal/planos-emissao (destino atual a corrigir) | VOLATIL, confirmado | Direcionar via StorageLocation e tratar ausencia no processamento, sem backup por padrao |
| FISCAL_XML | /root/YeshuaStorage/sefaz (destino atual a corrigir) | VOLATIL por padrao, confirmado | XMLs assinados/retornos incluidos; consulta banco -> SEFAZ e guarda persistente paga a planejar na secao 0.7 |
| CLINICA_UPLOAD_LOCAL | /root/YeshuaStorage/volatile/clinica/uploads/{tenant}/{usuario}/{id} | Audios VOLATEIS, confirmado | /upload usa IFileStorage e StorageLocation, autenticacao e chave relativa; copia da API generica antiga alinhada ao mesmo contrato |
| APS_UPLOAD_LOCAL | /root/YeshuaStorage/volatile/aps-adm/uploads/{tenant}/{usuario}/{id} | Audios VOLATEIS, confirmado | /upload usa IFileStorage e StorageLocation, autenticacao e chave relativa; nao ha migracao de storage pendente nesta rota |
| ANEXOS_NAO_CATALOGADOS | Qualquer StorageKey, caminho local, bucket ou provider encontrado | SEM_CLASSIFICACAO | Relacionar referencias SQL com destinos efetivos; nao supor que a lista de pastas esgota os arquivos |

As duas rotas /upload existem no codigo customizado de API e recebem audio.
Esses uploads foram classificados pelo usuario como volateis e ja usam
StorageLocation. A copia antiga da API generica foi alinhada ao mesmo contrato.
Nao houve remocao de rotas nem exclusao de arquivos antigos; adequacao do fonte
nao comprova deploy nem funcionamento completo do host generico antigo.

Classificacao conservadora nao exige copiar uma pasta inexistente nem torna
um caminho obrigatorio em todo app. O inventario registra a area como presente,
ausente justificada ou lacuna. Ausencia inesperada de area em uso reprova o
conjunto; caminho legado comprovadamente sem uso nao e inventado no servidor.

### 4.3 Segredos, Chaves E Identidades De Recuperacao

| ID | Origem ou localizador | Politica | Dependencia critica |
| --- | --- | --- | --- |
| MEMORIAS_COFRE | Apps.Memorias.PrivateRoot/accounts, atualmente /root/YeshuaMemoriasSecrets/accounts | PERSISTENTE, confirmado | Cofre do Memorias, fora do SQL; conexoes/configuracao/chaves e estados de upload/autorizacao. Copia integral ja selecionada, sem prova de restore nesta revisao |
| MEMORIAS_CONFIG_CIFRADA | accounts/configuration/<hash-do-escopo>/oauth.bin e key.bin | PERSISTENTE, junto do cofre confirmado | Configuracao salva pela interface prevalece sobre bootstrap quando presente; preservar chave correspondente e identidade de escopo, sem transferir integracao para Central |
| MEMORIAS_UPLOAD_STATE | accounts/<escopo>/tenants/.../upload-*.bin | PERSISTENTE, parte da copia integral do cofre | Sessao/recibo vinculado ao mesmo video, destino, hash e publicacao; evitar upload duplicado |
| MEMORIAS_OAUTH_PENDING | authorization-*.bin no cofre | PERSISTENTE, parte da copia integral do cofre | Estado transitorio com validade; restore nao ressuscita autorizacao expirada; sem exclusao por conteudo dentro de persistente |
| FISCAL_CERTIFICADOS | /root/YeshuaPrivate/production/apps/Fiscal/tenants/<Id>/titulares/<Documento>/certificados/<Thumbprint> | PERSISTENTE, confirmado | Certificado PFX e senha.secret com acesso restrito; alinhar StorageLocation na reforma, sem exposicao publica |
| CONFIG_PRIVADA | /root/YeshuaPrivate/production/credentials.json | PERSISTENTE com acesso restrito, confirmado | Configuracao administrativa Shared/Apps; pasta 0700/arquivo 0600, fora do Git/imagens/logs; backup cifrado comum e permissoes conferidas no restore. Nao guardar unica copia no SQL que depende dela |
| INTEGRACOES_PRIVADAS | /root/YeshuaPrivate/production/apps/Memorias/integracoes/youtube/bootstrap.json | SEGREDOS_ESSENCIAIS quando usado | Bootstrap opcional do Memorias; nao substituir o cofre por bootstrap vazio. Discussao de armazenamento do cofre adiada; providers do agente tratados separadamente |
| AGENTE_PROVIDERS | shared/OperationalAgent/integracoes/providers.json sob a raiz privada | PERSISTENTE com acesso restrito, confirmado | Chaves de API opcionais lidas pelo deploy; nao sao sessoes/historicos das CLIs. Raiz privada ja selecionada; volumes do agente continuam VOLATEIS |
| CONFIG_PRIVADA_LEGADA | /root/YeshuaDB/persistent/config e /root/YeshuaStorage/fiscal/certificados | Inventariar legado sem adocao implicita | Nao sao o destino atual de novas credenciais; confirmar uso, sem migracao ou exclusao automatica |
| CHAVES_HOSTS | Origem efetiva de JWT, autenticacao entre modulos, credenciais SQL/broker e provedores | SEGREDOS_ESSENCIAIS | Pode vir de ambiente ou arquivo externo; preservar fonte recuperavel sem imprimir valores |
| SQL_CRIPTOGRAFIA | Certificados/chaves de TDE ou backup cifrado, se existirem | SEGREDOS_ESSENCIAIS | Exportacao suportada e acesso em outra instancia; .bak sozinho pode ser inutilizavel |
| HTTPS_IDENTIDADE | /etc/letsencrypt | VOLATIL, confirmado por decisao posterior | Reemitir pelo setup-cert.sh na recriacao, com validacao do dominio/renovacao. Retirada das novas capturas/cobertura pendente; nao apagar origem/snapshots agora |
| BACKUP_RECUPERACAO | Credencial do destino externo e senha/chave do repositorio | PERSISTENTE/restrito, com entrega ao operador solicitada | Setup entrega senha por terminal privado e confirma guarda independente; recibo sem senha nao e prova de copia externa. Implementado localmente, sem deploy/validacao de terminal Linux real |

Nao guardar valores secretos neste mapa nem em um manifesto versionado.
No Memorias, o ProcessingScope integra a identidade criptografica: preservar
seu valor e a correspondencia com o conjunto, sem troca automatica no restore.

Chave e cofre podem pertencer ao mesmo conjunto logico, mas acesso ao backup
nao deve ser publico. O segredo que abre o repositorio de backup precisa de
custodia independente; nao existe recuperacao se a unica chave estiver dentro
da copia cifrada ou no servidor perdido.

### 4.4 Configuracao, Fontes E Estado Operacional

| ID | Origem | Politica | Escopo |
| --- | --- | --- | --- |
| RELEASE_PUBLICADA | Commit e IDs/digests efetivos de cada container | CONFIGURACAO_ESSENCIAL | Front Central, APIs, workers, renderer e dependencias; HEAD do clone pode nao ser a release |
| FONTES_VERSIONADOS | Repositorio remoto com DSL, Custon, Front Central, scripts e migrations | RECONSTRUIVEL por Git verificado | Confirmar release alcancavel e acesso de recuperacao; preservar bundle/espelho se o remoto for o unico exemplar recuperavel |
| FONTES_LOCAIS_EXCLUSIVOS | Alteracoes/arquivos nao enviados ao remoto, inclusive workspace do agente | ARQUIVOS_ESSENCIAIS ate incorporar | Git nao guarda working tree nem arquivo ignorado; nunca descartar apenas por estar num clone |
| INFRA_EFETIVA | /root/YeshuaCreator/infra e overrides locais usados | CONFIGURACAO_ESSENCIAL | Compose, Dockerfiles, deploy.env, scripts, conf.d/routes HTTPS e diferencas nao versionadas |
| INFRA_HISTORICA | infra/Environments/Production/Migration e manifestos antigos | RECONSTRUIVEL se versionada | Artefato existente nao comprova que e usado pelo deploy publico atual |
| CONFIG_NAO_GIT | .env, appsettings ou override externo efetivamente consumido | CONFIGURACAO_ESSENCIAL; SEGREDOS_ESSENCIAIS se secreto | Registrar precedencia e origem real sem despejar ambiente/inspect em relatorio publico |
| ACESSO_SERVIDOR | Regras de firewall, DNS, portas, mounts, UID/GID, usuarios e acesso administrativo | CONFIGURACAO_ESSENCIAL | Registrar tambem configuracoes no provedor; chaves privadas em custodia restrita, nao copiar toda a home indiscriminadamente |
| AGENDAS_E_MONITORES | Timers/cron, rotinas de backup, checagens e destinatarios de alertas | CONFIGURACAO_ESSENCIAL | Incluir estado fora do Git e demonstrar deteccao de backup atrasado |
| BROKER_DEFINICOES | Estado/configuracao interna do RabbitMQ | VOLATIL, confirmado pelo usuario | Recriar topologia pelos contratos e credenciais pelo JSON privado; nao incluir export do broker no backup. Configuracao privada continua persistente |
| GRAFANA_CONFIG | Estado interno do Grafana | VOLATIL, confirmado pelo usuario | Personalizacoes devem ser versionadas/provisionadas pela infra, nao existir apenas na interface; segredos no JSON privado. Adequar raiz runtime sem apagar dados agora |
| TELEMETRIA_HISTORICO | Historico de logs/metricas/rastros hoje no bind /root/YeshuaDB/persistent/telemetry | VOLATIL, confirmado pelo usuario | Adequar raizes; nao mudar retencao/coleta. Grafana tambem classificado como volatil; nao filtrar conteudo da raiz persistente antiga |
| EVIDENCIAS_ENSAIOS | Manifestos de backup, resultados de checagem, hashes e provas de restore | CONFIGURACAO_ESSENCIAL | Guardar fora do servidor tambem; sem payloads/tokens; material sensivel com acesso restrito |
| CONJUNTOS_BACKUP | Staging local e snapshots externos a implantar | Preservar conforme politica de retencao do plano | .bak/.trn e arquivos selados alimentam a copia externa; nao incluir o repositorio/staging recursivamente no proprio backup |

### 4.5 Filas, Cache E Integracoes

| ID | Recurso | Tratamento proposto | Limite atual |
| --- | --- | --- | --- |
| BROKER_MENSAGENS | Mensagens prontas, nao confirmadas e em execucao | VOLATIL, confirmado pelo usuario | Fora do backup; adequar captura coordenada. Nao prometer retomada automatica via SQL e nao mudar ACK por causa dessa classificacao |
| REDIS_ESTADO | Conteudo Redis | VOLATIL, confirmado pelo usuario | Adequar captura coordenada; nao desligar/remover servico por essa decisao. Nenhum consumidor ativo identificado no codigo; cache gerado usa IMemoryCache |
| CELERY_TAREFAS | Tarefas Python/renderer e seus retornos | Reconciliacao com SQL, arquivos, fila e estado externo | Renderer Memorias usa ACK antecipado; backup SQL+arquivos nao garante recuperar tarefa aceita |
| ESTADO_EM_MEMORIA | Politica operacional temporaria e outros singletons | Sem backup da memoria | Preservar configuracao base; override que precise sobreviver deve ter persistencia deliberada |
| EFEITOS_SEFAZ | Autorizacoes, eventos e protocolos externos | Preservar evidencias locais e reconciliar | Restore nao desfaz emissao/evento externo; sem reemissao automatica baseada apenas em ausencia local |
| EFEITOS_YOUTUBE | Videos, IDs, canal/destino e recibos externos | Preservar vinculos locais e reconciliar | Conta externa nao e backup de fotos, nem backup da VPS; revogacao e expiracao continuam valendo |

Nova tecnologia sem adaptador/procedimento de recuperacao nao deve receber
uma etiqueta de protecao falsa. A politica pode ser reutilizada, mas SQL,
arquivos e mensagens nao sao capturados da mesma maneira. O primeiro uso de
um novo tipo de persistencia exige comprovar esse procedimento uma vez.

### 4.6 Temporarios, Reconstruiveis E Itens Adiados

| ID | Recurso | Politica sugerida | Condicao |
| --- | --- | --- | --- |
| MEMORIAS_RENDER_TEMP | .render-* junto das publicacoes | TEMPORARIO | Preservar video final e manifesto; nao excluir toda a pasta de publicacao |
| ESCRITA_ATOMICA_TEMP | .tmp e locks de arquivo | TEMPORARIO apos captura controlada | Confirmar escritor parado e arquivo final; nao tratar upload multipart como .tmp descartavel |
| IA_CONVERSAO_TEMP | Downloads/copias de trabalho e WAV de tempfile no Python | TEMPORARIO | Original precisa estar protegido; caches nao substituem a origem |
| IA_MODELOS_PUBLICOS | Cache de modelos, NuGet, pip e demais downloads | RECONSTRUIVEL | Registrar versao/fonte e disponibilidade; modelo privado ou ajustado exclusivamente e ARQUIVOS_ESSENCIAIS |
| RELATORIO_DERIVADO | Preview, miniatura, PDF nao assinado ou export reproduzivel | RECONSTRUIVEL apos prova | Fonte completa preservada e tempo aceitavel; documento entregue/alterado manualmente pode nao ser reproduzivel |
| BUILD_OUTPUT | bin, obj e caches de compilacao | RECONSTRUIVEL | Fonte e dependencias recuperaveis; nao implica build identico sem versoes fixadas |
| AGENTE_AMBIENTE | operational-agent-workspace/codex/claude | VOLATIL, confirmado pelo usuario | Fora do backup; estado funcional persistente deve ir ao banco ja protegido. Nao copiar sessoes para SQL nem apagar volumes por essa classificacao |
| LOGS_ROTATIVOS | Logs brutos Docker e sistema | EVIDENCIA_SELETIVA | Recorte de incidente pode ser essencial; nao prometer historico integral |
| DOCKER_IMAGENS | Imagens de Front Central, APIs, workers, SQL, Python/IA e demais servicos | IMAGENS_ADIADAS | Registrar identidade agora; criar estrategia de preservacao depois de estabilizar |
| VPS_SNAPSHOT | Snapshot integral, sistema operacional e camada Docker | IMAGENS_ADIADAS | Complemento futuro; nao substitui SQL nativo, arquivos e copia externa |

## 5. Areas Padrao Para Novos Recursos

Nao e necessario mover os dados atuais para uma unica pasta. A protecao deve
aceitar destinos existentes por vinculo explicito. Para novas areas, sugerir:

| Familia logica | Destino sugerido para novos recursos | Politica padrao |
| --- | --- | --- |
| Banco do aplicativo | Catalogo definido na conexao efetiva | SQL_ESSENCIAL |
| Originais/documentos | /root/YeshuaStorage/persistent/<app>/<area> | ARQUIVOS_ESSENCIAIS |
| Artefatos necessarios a retomada | /root/YeshuaStorage/persistent/<app>/<area> | ARQUIVOS_ESSENCIAIS |
| Configuracao tecnica | /root/YeshuaPrivate/<ambiente>/credentials.json com Shared/Apps | SEGREDOS_ESSENCIAIS |
| Integracao externa | /root/YeshuaPrivate/<ambiente>/apps/<App>/integracoes/<Integracao> ou shared/<Servico>/integracoes | SEGREDOS_ESSENCIAIS |
| Cofre/certificado novo | /root/YeshuaPrivate/<ambiente>/apps/<App>/tenants/<Id>/... | SEGREDOS_ESSENCIAIS |
| Trabalho descartavel | /root/YeshuaWork/<ambiente>/<app>/<area> | TEMPORARIO |
| Reconstruivel | Area separada da origem essencial | RECONSTRUIVEL |

YeshuaPrivate foi adotado para configuracao em 2026-10-20; YeshuaWork continua
proposta, nao e necessario mover temporarios agora. Memorias mantem o cofre
atual indicado no JSON. Certificados fiscais novos usam a raiz privada;
acervo antigo nao e migrado por este plano. Nenhum movimento ou descarte de
arquivos foi autorizado ou executado por este mapa.

Os exemplos fisicos usam a instalacao de producao atual. Homologacao e novos
ambientes exigem binds/catalogos distintos ou compartilhamento deliberado e
documentado; mudar apenas o nome do ambiente na metadata nao isola os dados.

Dentro de uma area, a politica e herdada recursivamente. Preferir separar areas
quando a politica mudar, em vez de crescer uma lista de exclusoes por arquivo.
Excecoes tecnicas existentes, como .render-* dentro da publicacao, permanecem
explicitamente delimitadas ate eventual reorganizacao.

Nao criar dados essenciais dentro de area TEMPORARIO. Nao declarar uma raiz
inteira de /root ou /storage como protegida para esconder recursos sem dono.
O grupo de persistencia nao concede permissao de acesso: monta-se somente o
necessario, e areas privadas nunca recebem rota publica.

No ambiente atual /volatile/ tem rota estatica publica no Nginx. Por isso,
novos temporarios sensiveis nao devem adotar essa rota como padrao. A avaliacao
dos audios existentes deve considerar privacidade separadamente do backup.

## 6. Como Novos Recursos Herdariam A Estrategia

### 6.1 Banco

```text
Novo app -> banco do app -> SQL_ESSENCIAL -> captura de todas as tabelas
Nova entidade no mesmo banco -> nada a cadastrar na rotina de backup
Novo banco fisico -> registrar o catalogo efetivo no inventario do ambiente
```

Validar que o banco existe na lista capturada, sem confiar somente no nome
pretendido pela DSL. Nao criar configuracao por tabela nem executar backup
durante uma migration. Ambiente de desenvolvimento nao herda automaticamente
a agenda de producao apenas por usar o mesmo nome de aplicativo.

### 6.2 Arquivos

```text
Novo documento APS -> area APS_DOCUMENTOS -> ARQUIVOS_ESSENCIAIS
Nova foto no Memorias -> area MEMORIAS_FOTOS -> VOLATIL por padrao (reforma pendente)
Novo MP4 local em publicacao -> MEMORIAS_VIDEOS_LOCAIS -> SEMPRE VOLATIL (reforma pendente)
Nova conversao WAV -> area de trabalho -> TEMPORARIO
Novo certificado -> area privada -> SEGREDOS_ESSENCIAIS
```

Criar arquivo ou subpasta dentro da area nao exige outra estrategia. Uma area
nova pode reutilizar politica pronta sem desenvolver outro job. Ainda precisa
ter mount correto e entrar numa captura externa demonstrada antes de receber
o estado RESTORE_COMPROVADO.

Se um arquivo e entrada original e depois serve de temporario de processamento,
sua origem continua essencial. Trabalhar sobre uma copia nao muda a politica
do original. Nenhuma transicao automatica de retencao por status da saga e
proposta nesta fase.

### 6.3 Conjunto De Restauracao

Nao basta escolher politica individual. Registrar tambem o que precisa voltar
junto, sem criar uma dependencia de runtime entre aplicativos:

| Conjunto | Recursos relacionados |
| --- | --- |
| AMBIENTE_PRODUCAO | Central, aplicativos, arquivos, cofres e configuracoes capturados na mesma janela |
| MEMORIAS | DB_MEMORIAS, fotos, publicacoes, musicas referenciadas, cofre e configuracao correspondente |
| FISCAL | DB_FISCAL, certificado/senha persistentes e configuracao correspondente; XMLs/planos volateis por padrao, guarda paga futura |
| CLINICA | DB_CLINICA, documentos e origens/artefatos de audio em uso |
| APS_FISCAL | Bancos APS/Fiscal, arquivos relacionados e revisao dos eventos entre modulos |

Esses nomes descrevem dependencias de restore, nao sao agendas duplicadas.
Uma captura pode atender varios conjuntos. Recuperar somente um componente
continua possivel, mas exige avaliar as dependencias antes da liberacao.

## 7. DSL E Configuracoes Sem Misturar Responsabilidades

### 7.1 O Que Ja Existe

- `StorageLocation` e `StoragePathBuilder` ja representam locais logicos no
  contrato compartilhado de arquivos.
- `Storage:Locations` seleciona provider por prefixo; `Storage:Providers:Disk`
  configura a raiz. Isso escolhe onde gravar, nao executa backup.
- Fiscal tambem usa variaveis de raiz proprias; Memorias possui configuracao
  especifica de cofre. Esses caminhos devem ser inventariados mesmo sem passar
  por IFileStorage.
- Existem `DeploymentSchema`, recursos, `.Persistent`, `.BindPersistence` e
  `DeploymentEnvironmentSchema`. Eles descrevem persistencia/implantacao,
  mas nao implementam politicas de backup.
- O deploy publico atual continua nos Compose de `infra/*/DockerCompose`.
  O Studio de ambiente Production e os artefatos em `Migration` nao representam
  automaticamente o conjunto ativo; seu exemplo inclui apenas Clinica/Fiscal.

### 7.2 Divisao Proposta

| Responsavel | O que declara | O que nao deve fazer |
| --- | --- | --- |
| DSL do aplicativo, se houver necessidade de geracao | Referencia logica de area/finalidade usada pelo recurso | Host, pasta da VPS, senha, agenda, retencao ou execucao de backup |
| Configuracao do aplicativo | Bind da area/raiz ja usada por API, Worker ou Python | Duplicar politica completa em cada host |
| Configuracao de infraestrutura/ambiente | Area -> mount/catalogo -> politica e dependencias de restore | Escrever regra de negocio ou alterar automaticamente o estado de saga |
| Rotina de infraestrutura | Capturar, enviar, verificar, reter e restaurar conforme politica | Rodar dentro do receiver ou no caminho quente de cada escrita |

Primeira etapa: aproveitar as configuracoes atuais e o mapa. Nao adicionar
metodo na DSL apenas para esconder um caminho. Se a geracao precisar conhecer
a area, evoluir o contrato existente com uma referencia pequena e validacao
estatica. Nao criar uma DSL paralela, um servico central de backup nem um
reposititorio runtime que toda escrita precise consultar.

Este registro ilustrativo representa o vinculo desejado. Nao e um arquivo de
configuracao consumido hoje nem uma API/DSL implementada:

```yaml
id: APS_DOCUMENTOS
application: APS.ADM
environment: Production
resourceType: Files
location: /root/YeshuaStorage/persistent/aps-adm/docs
policy: ARQUIVOS_ESSENCIAIS
restoreWith: [DB_APS_ADM, DB_CENTRAL]
visibility: Private
```

O path existe apenas na configuracao do ambiente. O recurso do aplicativo
referenciaria APS_DOCUMENTOS; a estrategia e resolvida na infraestrutura.
Nao duplicar a definicao da politica nesse registro. Visibility nao e uma
promessa de autorizacao ja aplicada ao filesystem ou ao HTTP.

Exemplo de bind que o mecanismo atual de storage ja entende:

```text
Storage__Providers__Disk__Root=/storage
Storage__Locations__persistent/aps-adm/docs=Disk
```

O exemplo nao basta para proteger APS: hoje faltam o mount correspondente no
seu Compose, a captura ativa e a prova. Tambem nao introduz isolamento entre
areas no provider atual. Um modelo futuro deve validar caminhos/mounts sem
alterar os StorageKeys existentes silenciosamente.

Segredos nunca devem ser encaminhados ao provider publico por conveniencia.
Usar os contratos/cofres existentes ou uma configuracao privada apropriada;
backup e uma responsabilidade adicional, nao um substituto do cofre.

## 8. Regras De Checagem Antes De Criar Ou Publicar

Checks propostos para implantacao posterior, ainda nao executaveis:

1. Todo banco e toda area gravavel possuem dono, ambiente, politica ou pendencia
   explicita. Campo ausente nunca vira TEMPORARIO por default.
2. Banco novo aparece na selecao real do SQL; banco de leitura so e dispensado
   de copia apos ensaio de reconstrucao, nao por se chamar leitura.
3. Caminho efetivo de API, Worker, Python e demais escritores corresponde ao
   mount e a origem capturada. Proibir dado essencial apenas na camada do container.
4. Validar destino resolvido, maiusculas/minusculas, limites de path e symlinks;
   prefixo textual sozinho nao prova que o arquivo pertence a area protegida.
5. Montar subpastas/volumes novos nao pode retirar silenciosamente parte de uma
   origem do backup. Registrar como tratar filesystems separados.
6. Area privada nao possui rota estatica publica nem mount desnecessario no
   gateway/renderer. Essa verificacao e independente de haver backup.
7. Registrar conjuntos de restore, chaves/cofres e versao necessarios; nunca
   concluir que cada snapshot isolado e consistente com os demais.
8. Dependencias externas e lacunas de mensagens permanecem visiveis. Restaurar
   e religar executores nao pode reenviar efeitos ambiguos automaticamente.
9. Mudanca de provider, path, policy ou chave exige revisar impacto, prova e
   copias antigas. Nao apagar a origem antiga na mesma operacao automaticamente.
10. A publicacao deve distinguir classificacao planejada de protecao demonstrada;
    futuro gate so pode aprovar com evidencia recente e dependencias cobertas.

Verificacoes de cobertura pertencem ao build/deploy, inventario ou tarefa
operacional. Nao consultar o ultimo backup nem gerar telemetria de backup a
cada upload, command, consulta SQL ou escrita de arquivo.

## 9. Pontos Para Ajustarmos Antes De Implementar

| Decisao | Sugestao inicial | Por que precisamos confirmar |
| --- | --- | --- |
| Audios originais da Clinica | Area volatile excluida do backup por decisao posterior do usuario | Exclusao da copia nao autoriza apagar arquivos de origem |
| Videos MP4 locais Memorias | SEMPRE VOLATIL, confirmado, inclusive para pagantes | Aplicacao deve tratar ausencia e limpeza; destino atual sera corrigido na reforma |
| Musicas padrao versionadas | VOLATEIS, confirmado pelo usuario | Repor do Git/deploy com hash; nao inferir a classificacao de arquivos adicionais desconhecidos |
| Relatorios e transcricoes | Area volatile excluida; outros locais aguardam revisao | Discutir classificacao de cada grupo sem limpeza automatica |
| Documentos Docs/docs | Inventariar ambos sem renomear agora | Diferenca concreta no Linux entre bootstrap e configuracao |
| Limpeza de volatile e .render-* | Task pendente por tempo e/ou tamanho, com contrato de cada aplicacao | Definir limites e proteger arquivos em uso; nenhum agendamento/exclusao ativado |
| Limpeza de staging SQL | Separar de limpeza de arquivos do aplicativo | Exigir backup externo validado, ausencia de SQL ativo e preservacao da cadeia/ultimo conjunto recuperavel |
| Upload local em containers | Preservar se existir e depois apontar para area adequada | Hoje nao ha persistencia declarada correspondente |
| Mensagens RabbitMQ | VOLATIL confirmado; adequar captura coordenada | Investigar intencao do ACK separadamente; perda de broker nao implica aceite de perda silenciosa no recebimento normal |
| Grafana/interface | Exportar configuracao propria antes de dispensar historico | Dashboard alterado manualmente pode existir somente em /data |
| Recursos novos | Escolher area existente primeiro; politica por area nova somente se necessario | Evita criar backup especifico por funcionalidade |
| Sintaxe DSL | Nao criar agora; fechar os vinculos e validar com poucos casos | Configuracao atual pode resolver a primeira entrega sem nova abstracao |

Sequencia replanejada: aprovar perfis -> confirmar servidor e vinculos -> piloto
de captura/restore -> rotina compartilhada por areas -> cobrir e provar areas
essenciais -> agendar/monitorar -> apontar novos recursos e corrigir legado ->
automatizar verificacoes e eventual referencia DSL minima. Imagens permanecem
adiadas; logs FULL e dados em risco nao aguardam essa fase.

As etapas P1-P10 e seus criterios de aceite pertencem exclusivamente a secao
11 do plano operacional. Este inventario indica a qual politica/area cada
recurso adere, sem outra sequencia de implantacao por aplicativo.

## 10. Bases E Limite Da Varredura

Foram conferidos os Compose ativos de Shared, Central, Clinica, APS.ADM,
Fiscal e Memorias; bootstrap, deploy.env, loader privado, rotas Nginx e os
contratos de storage compartilhados. A Engine foi consultada para localizar
os registros de storage e o modelo de recursos/implantacao ja existente.

Tambem foram conferidos os stores customizados do Fiscal, o cofre e arquivos
de publicacao do Memorias, o upload/audio da Clinica, os endpoints de upload
de Clinica/APS e os temporarios Python do renderer/transcricao. Nao foi feita
uma varredura de copias geradas para inferir arquitetura.

Fontes principais:

- `infra/docker/deploy.env` e `infra/docker/load-deploy-env.sh`.
- `infra/Shared/DockerCompose/docker-compose.yml`.
- `infra/Clinica/DockerCompose/docker-compose.yml` e `infra/bootstraps/setup.sh`.
- `infra/Memorias/DockerCompose/docker-compose.yml` e `YOUTUBE.md`.
- `infra/Shared/DockerCompose/nginx/routes/00-storage.conf`.
- `src/CQRS/Application/Yeshua.CQRS.Application.Command/Interfaces/Patterns/FileStore`.
- `src/CQRS/Infrastructure/Yeshua.CQRS.Infrastructure.Shared/Patterns/FileStore`.
- `src/Engine/Yeshua.Engine/Dominio/Deployment` e `Dominio/Schemas/DeploymentEnvironmentSchema.cs`.
- `src/CQRS/Infrastructure/Yeshua.Clinica.CQRS.Infrastructure.Api/Custon/EndPoints.cs`.
- `src/CQRS/Infrastructure/Yeshua.APS.ADM.CQRS.Infrastructure.Api/Custon/EndPoints.cs`.

O mapa complementa o runbook de recuperacao: G1 para responsabilidade e
procedimento, G2 para versao recuperavel e G7 para demonstracao, conforme o
padrao operacional do projeto. Nao declara esses gates aprovados.

Completo significa cobrir os tipos e origens identificados nesse escopo. Ainda
precisamos reconciliar os paths, bancos, volumes anonimos, configuracoes de
provedor e arquivos exclusivos do servidor. Nenhum ambiente foi alterado.
## Atualizacao Do Inventario Real Em 2026-10-20

O roteiro executavel consolidado esta em
[infra/backups/RECOVERY.md](../../infra/backups/RECOVERY.md). O ensaio final sera
em servidor novo; nao ha laboratorio SQL preliminar obrigatorio nem backup
ativo por estas edicoes. Este mapa continua classificando a adesao das areas.

Conferencia real: 20 containers em seis projetos; seis bancos Yeshua e Estudo,
alem dos bancos de sistema. A captura completa inclui todos, exceto tempdb;
nenhum banco adicional e removido. Todos os bancos de usuario estao FULL e nao
ha log backup registrado no msdb observado. COPY_ONLY inicial nao resolve a
politica de logs nem promete PITR.

Areas efetivas: /root/YeshuaStorage, telemetria em
/root/YeshuaDB/persistent/telemetry, /root/YeshuaPrivate/production,
/root/YeshuaMemoriasSecrets e /etc/letsencrypt. Cinco volumes Docker incluem
RabbitMQ, Redis e os tres volumes do agente operacional. SQL cru esta fora da
copia de arquivos. O plano confronta todos os mounts ativos e recusa bind
desconhecido, em vez de declarar cobertura automaticamente.

O diretorio existente e persistent/Docs (D maiusculo), vazio no inventario;
persistent/docs minusculo nao existe. A primeira captura incluiu Storage inteiro;
essa selecao foi substituida pelas duas exclusoes de volateis em 2026-10-20.
Isso nao autoriza limpeza por idade. /app/uploads dos containers e capturado
quando presente e recolocado antes de iniciar o servico recuperado.

Imagens fixas podem ser arquivadas opcionalmente para o ensaio integral.
Containers parados/volumes orfaos e arquivos fora das areas conhecidas exigem
revisao antes do aceite de 100%; nao sao deletados ou tratados como descartaveis.
