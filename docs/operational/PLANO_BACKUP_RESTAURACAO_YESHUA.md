# Plano De Backup, Limpeza E Restauracao Do Ambiente Yeshua

Data: 2026-10-17.

INSTRUCAO ATUAL: limpeza/recriacao do servidor adiadas pelo usuario. Continuar
implementacao e testes locais, sem deploy ou alteracao operacional na VPS.

FECHAMENTO LOCAL DE 2026-10-21: concluir revisao/testes e enviar o codigo ao
remoto antes do servidor novo. Credenciais completas preservadas fora do Git;
copia separada para instalacao limpa remove somente o override do cofre antigo
Memorias, sem girar senhas. O ciclo aprovado e instalar vazio -> usar/criar dados
de teste -> gerar/validar backup -> copiar/verificar fora da VPS -> restaurar e
conferir uso. Nao fazer o segundo descarte com backup somente no mesmo disco.
O roteiro atual esta no inicio de infra/backups/RECOVERY.md e prevalece sobre
instrucoes historicas abaixo. Instalacao e restore reais ainda nao comprovados.

DECISAO POSTERIOR: esta virada pode descartar os dados atuais do Yeshua, inclusive
bancos e cofres/conexoes YouTube, e reinstalar os aplicativos do zero. Preservar
codigo/configuracao de instalacao e acesso administrativo; reemitir HTTPS; limitar a
operacao aos recursos inventariados do Yeshua. Nao apagar canais/videos do Google.
Nao migrar referencias antigas nem confundir reinstalacao limpa com prova de
restauracao. A politica futura de persistente/backup permanece integral.

ATUALIZACAO LOCAL DE 2026-10-20 (prevalece sobre o historico abaixo): nova
selecao recursiva de Storage/persistent, sem filtros de conteudo; volatile fora;
fontes/bundles Git, toolkit e imagens nao sao mais copiados. source.json identifica
a revisao para reconstrucao. Novos caminhos do Memorias/Fiscal e uploads legados
foram ajustados via StorageLocation. Setup prepara as raizes e revalida o recibo
de arquivos ao mudar a selecao. Nao houve nova publicacao desta reforma na VPS.

Os dados/caminhos antigos nao foram movidos nem apagados: enquanto estiverem em
persistent, continuam incluidos. Transicao e prova real no servidor novo seguem
pendentes. Nao usar prepare-server/imagens congeladas como promessa de restore
dos novos conjuntos data-only; reconstruir software pelo Git e restaurar os dados
conforme a atualizacao em infra/backups/RECOVERY.md. Classificacao ENCERRADA pelo
usuario em 2026-10-21; nao ha nova rodada item a item. Cobranca/limpeza continuam
pendentes no mapa.

APLICACAO LOCAL DE 2026-10-21: selecao SQL somente bancos de usuario (inclui
Estudo e novos bancos); capturas de arquivos v3 sem HTTPS ou volumes volateis.
Telemetria/Grafana no bind volatile/infra/telemetry; Docs sem uso retirados.
Snapshot SQL copia apenas midias/recibos de bancos de usuario, sem recapturar
backups antigos de sistema. Nenhuma origem ou snapshot antigo foi apagado.
Setup integra provisao explicita Shared.SqlServer.Logins pelo helper comum,
sem rotacao de senhas, roles inferidas ou novo servico. Deploy diario nao habilita
essa etapa. Provas reais de SQL/grants, terminal Linux e recuperacao integral
permanecem no ensaio do servidor novo; nao houve deploy desta implementacao.

Revisao 6, em 2026-10-20: inventario real concluido e implementacao operacional
em infra/backups. O ensaio final escolhido pelo usuario e restaurar o ambiente
em NOVO servidor, sem laboratorio SQL preliminar. Preserva credenciais privadas
existentes, sem criptografia local generica adicional.

Status: ferramentas instaladas na VPS, repositorio LOCAL cifrado inicializado,
primeiros backups SQL full/diferencial/logs e arquivos concluidos, leitura
integral aprovada e seis agendas systemd ativas.
Destino externo, captura coordenada e recuperacao no servidor novo permanecem
pendentes. Nenhum container de aplicativo, rota ou deploy foi alterado. O procedimento
executavel atual e [infra/backups/RECOVERY.md](../../infra/backups/RECOVERY.md).
As politicas/cadencias descritas abaixo permanecem propostas onde nao ativadas.

Decisoes posteriores do usuario, em 2026-10-20: somente persistente e volatil;
tudo em persistente entra no backup, sem excecao de conteudo, e volatil fica fora.
100% dos bancos dos aplicativos definidos nos Studios sao persistentes, inteiros.
Copias dos fontes, bundles Git, Docker/build/cache recriaveis nao sao persistentes;
restauracao rapida nao e objetivo desta fase. StorageLocation devera ser obrigatorio
para arquivos dos aplicativos. A lista de atividades e a separacao entre contrato
aprovado e implementacao atual estao na secao 0 do
[mapa de dados](MAPA_DADOS_AREAS_E_BACKUP_YESHUA.md#0-decisoes-confirmadas-e-lista-de-atividades).
Esta revisao registra decisoes, sem nova alteracao no servidor.

DECISAO POSTERIOR SOBRE SQL DE SISTEMA: master/model/msdb e tempdb ficam fora
do backup. O usuario nao mantem dados necessarios nesses bancos; acessos devem
ser criados pela infraestrutura na instalacao/recriacao, com segredos no arquivo
privado e conferencia dos usuarios/permissoes dos bancos restaurados. A selecao
SQL local ja os exclui; provisionamento integrado, com prova real pendente
no mapa. Registros de capturas anteriores abaixo sao historicos,
nao autorizacao para manter backup de sistema. Nao apagar copias antigas agora.

Banco adicional Estudo: usuario confirmou manter seu backup apos conferencia
dos metadados pela API operacional. Classificacao PERSISTENTE, banco inteiro,
pelo fluxo SQL nativo comum, sem agenda nova. A selecao atual ja o inclui;
preservar essa cobertura ao retirar os bancos de sistema, mesmo sem Studio
apontando para Estudo.

Cofre privado YouTube do Memorias: PERSISTENTE, confirmado pelo usuario;
copia integral da area privada e chaves correspondentes pelo fluxo comum de
arquivos, sem nova agenda. A raiz ja esta na selecao; restauracao funcional
ainda precisa de prova. Permanece no Memorias, com a cifra/identidade existentes,
sem migrar para Central ou SQL por causa da revisao de backup.

credentials.json administrativo: usuario confirmou PERSISTENTE e seguro.
Manter acesso restrito (pasta 0700/arquivo 0600 no Linux), fora do Git/imagens/logs,
backup no repositorio cifrado comum e conferencia das permissoes na restauracao.
Nao criar cofre/cifra local adicional ou regenerar credenciais por essa decisao.

providers.json opcional do agente: PERSISTENTE e restrito, confirmado pelo
usuario. Chaves de API configuradas entram na copia da raiz privada pelo fluxo
comum. Isso nao preserva sessoes/historicos/caches dos volumes do agente, que
continuam VOLATEIS; nao extrair logins das CLIs para criar outra persistencia.

HTTPS/Certbot em /etc/letsencrypt: VOLATIL por decisao posterior do usuario,
substituindo a aprovacao inicial como persistente. Reemitir no servidor novo
por infra/bootstraps/setup-cert.sh, com validacao do dominio e renovacao conferidas.
A rotina local atual exclui essa area; recibos antigos de arquivos nao habilitam
agendas atuais sem nova captura v3/leitura integral. Snapshots antigos sao preservados.
Nao apagar origem/snapshots nem emitir, revogar ou reiniciar servicos nesta etapa.

Senha de recuperacao do backup: usuario solicitou entrega ao operador durante
a instalacao. Implementado no INICIO do mesmo setup, apos validar o JSON e antes
de atualizacoes/Docker/builds: EXIBIR autoriza visualizacao em terminal privado
e GUARDEI confirma a guarda fora da VPS. Restic/util-linux sao preparados antes
se faltarem. O install.py final reutiliza a confirmacao, sem nova pergunta para
a mesma senha/repositorio/maquina, sem rotacao. Senha nunca sai no JSON/log/recibo.
Ausencia de terminal ou confirmacao interrompe o preparo antes das atualizacoes/
deploy, sem desligar apps/agendas existentes.
Recibo nao comprova guarda externa. Testes locais ficticios; entrega Linux real
e restauracao independente permanecem para o ensaio, sem publicacao na VPS.

Fotos originais do Memorias foram confirmadas como volateis por padrao.
O caminho atual em persistent precisa ser corrigido via StorageLocation na
reforma. Preservacao paga por tenant inteiro ou por usuario dentro do tenant,
incluindo o desejo de preservar o tenant do usuario, fica A PLANEJAR na secao
0.4 do mapa. Nenhuma cobranca, permissao ou transferencia de arquivos foi aplicada.

Videos MP4 locais do Memorias sao SEMPRE VOLATEIS, mesmo para pagantes.
A task futura de limpeza por tempo e/ou tamanho ocupado esta na secao 0.5
do mapa. Todo dado volatil exige ciclo de vida e tratamento de ausencia pela
aplicacao; nao ativar limpeza generica de arquivos em uso nem exclusao agora.
Manifestos manifest.json de renderizacao tambem foram confirmados como volateis;
o destino atual precisa ser corrigido via StorageLocation na reforma.

Trilhas padrao versionadas do Memorias tambem sao volateis, confirmadas pelo
usuario. Corrigir a localizacao e garantir reposicao do Git/deploy com hash;
isso nao classifica automaticamente eventuais arquivos adicionais desconhecidos.

DocsInput da Clinica (persistent/docs/input) ficou pendente de investigacao por
decisao do usuario, que nao recorda sua finalidade. Confirmar uso, conteudo e
referencias antes de classificar; nao mover, excluir ou mudar a selecao agora.
DocsOutput (persistent/docs/output) tambem ficou pendente de investigacao por
confirmacao posterior do usuario, sem classificacao ou alteracao agora.
A pasta legada persistent/Docs (D maiusculo) tambem foi incluida pelo usuario
nessa investigacao; nao classificar nem unificar os caminhos por suposicao.
As demais areas continuam com suas decisoes separadas em revisao.

Fiscal, por decisao posterior do usuario: certificado e senha sao persistentes;
planos, XMLs assinados, retornos SEFAZ e demais arquivos de processamento sao
volateis por padrao. O banco continua integralmente persistente. Consulta de XML
no banco quando houver conteudo completo, fallback SEFAZ e guarda persistente
paga ficam como atividades de planejamento/implementacao na secao 0.7 do mapa.
Nao afirmar recuperacao externa garantida nem implementada nesta revisao.
Manter a chave de acesso fiscal no banco, sem depender dos arquivos volateis.
O campo de 44 caracteres ja existe na DSL e a gravacao foi conferida nos fontes
da preparacao CT-e/MDF-e e DocumentoFiscal. Conferir os demais fluxos e prover
gravacao onde faltar; nao criar coluna duplicada. A consulta remota nao exige
comprovante local previamente guardado, mas continua sujeita as regras e
autenticacao do servico; chave/situacao nao comprovam recuperacao de XML completo.

Revisao de classificacao solicitada pelo usuario em 2026-10-20: os rotulos
essencial/nao volatil abaixo sao PROPOSTAS, salvo as decisoes confirmadas acima. Revisaremos
todos os grupos, um por um. A correcao imediata exclui somente volatile/** e
persistent/memorias/publicacoes/*/.render-*/** de /root/YeshuaStorage, nos dois
caminhos de captura. Os demais grupos permanecem como estao ate essa revisao.
Nao apagar arquivos de origem, snapshots anteriores nem executar prune; mudar
a selecao futura nao reduz imediatamente o espaco dos backups ja existentes.

O [mapa de dados, areas e politicas](MAPA_DADOS_AREAS_E_BACKUP_YESHUA.md)
complementa este procedimento com a classificacao por origem e a proposta de
heranca de protecao para novos recursos, incluindo lacunas ainda nao corrigidas.
Ele e o mapa de adesao; este documento define a sequencia e o procedimento
para implantar o modelo. Nao ha dois planos independentes por aplicativo.

A [centralizacao de credenciais](../../infra/private/README.md) passou pelo
aceite tecnico de producao e redeploy em 2026-10-20. O usuario confirmou o uso
real do Memorias; os demais testes funcionais seguem separados. Isso nao
certifica backup nem restore; os recibos de backup sao separados. O
[piloto SQL local](PLANO_BACKUP_SQL_LOCAL_FUTURO_YESHUA.md) fica como referencia
tecnica; sua exigencia de laboratorio previo foi substituida pelo ensaio no
servidor novo, por decisao do usuario.

## 0. Decisoes Consolidadas

Um modelo de operacao, sem um job por aplicativo:

```text
Banco -> backup nativo SQL -> arquivo concluido e verificado
Arquivos persistentes + privados + configuracao + copia SQL
    -> rotinas online com recibos; conjunto coerente exige janela separada
    -> Restic no host -> repositorio local criptografado aprovado
    -> copia externa pendente, sem bloquear a protecao local
    -> verificacao e restore isolado -> retencao controlada

Volatil comprovado -> limpeza separada, nunca pelo backup
```

| Classe pratica | Captura | Protecao |
| --- | --- | --- |
| Banco SQL | Backup nativo, nao copia de MDF/LDF ativos | Mesmo repositorio privado; externo pendente |
| Persistente nao privado | Copia dos arquivos necessarios ao negocio | Mesmo repositorio privado e criptografado |
| Persistente privado | Copia de chaves, cofres e configuracoes correspondentes | Mesmo backup; acesso e permissoes de origem mais restritos |
| Volatil comprovado | Fora do backup | Limpeza por regra propria, depois de simulacao |

"Nao privado" nao significa acesso publico a fotos, documentos ou dados de
clientes. Todo repositorio de backup e privado. Reconstruivel e uma exclusao
que exige prova de reconstrucao, nao outra rotina por aplicativo. B0-B5 e os
perfis do mapa servem para inventario e metodo de captura, nao multiplicam
agendas. Uma area nova herda a estrategia existente; dados desconhecidos
continuam como lacuna, nunca viram descartaveis automaticamente.

Restic instalado no host e systemd executam a operacao. Nao executar
backup dentro de APIs, Workers, SQL, telemetria ou agente de IA. A Inteligencia
Operacional pode consultar resultados sanitizados; uma falha dela nao bloqueia
backup nem substitui um alerta de backup atrasado fora da VPS.

A rotina online possui full semanal, diferencial diario, logs a cada 15 minutos
e arquivos diarios incrementais, em America/Sao_Paulo. Retencao de 7 diarias,
4 semanais e 3 mensais permanece apenas simulacao; nao apagar cadeia SQL antes
do aceite. O destino externo e uma pendencia, nao requisito para executar local.
Janela com parada e recuperacao de 100% ainda exigem ensaio assistido.
Backup extraordinario antes de mudanca destrutiva sera acao operacional
explicita; nao adicionar backup, prune ou limpeza a todo deploy agora.

O SetId relaciona as partes; nao torna bancos, arquivos, filas e provedores
externos atomicamente consistentes. Piloto SQL online sera SQL_ISOLADO. Um
conjunto coerente requer controlar todos os escritores durante a captura
local, inclusive debug remoto, e reconciliar os efeitos externos no restore.
Nao oferecer pausa automatica noturna antes de medir e aprovar sua janela.

Ordem vigente: inventario -> implementacao/testes -> repositorio LOCAL ->
full/diferencial/logs e arquivos online -> verificacao/agenda -> destino externo
e captura coordenada -> recuperacao completa em novo servidor -> aceite.
Nao subir outro SQL na VPS atual. Retencao destrutiva e limpeza continuam
desativadas ate o aceite. Backup local nao cobre perda da VPS/disco.

### 0.1 Estado Real E Implementacao

Inventario da VPS em 2026-10-20: SQL 2022 16.0.4265.3 Developer, seis bancos
Yeshua e Estudo ONLINE, todos FULL. No inventario inicial nao havia backups de
log registrados no msdb; a rotina agora gerou full e logs nativos gerenciados.
SQL Agent parado; cinco jobs habilitados sem agenda, nenhum marcado como
BACKUP direto. Nao executar ou excluir esses jobs automaticamente.

O plano de captura completo inclui os sete bancos de usuario, master/model/msdb,
arquivos e cofres, HTTPS, telemetria e cinco volumes Docker. tempdb e SQL cru
ficam fora. Storage respeita as duas exclusoes de volateis registradas acima;
as demais classificacoes aguardam revisao. COPY_ONLY pertence somente a captura coordenada extraordinaria; a
rotina SQL online tem full normal, diferencial e log, sem alterar recovery model.

A conferencia real validou seis modelos Compose resolvidos, 20 containers,
19 identidades de imagem e estimativa de 9.407.538.298 bytes de staging sem
imagens. Configuracao privada e IDs/inicios/reinicios dos containers ficaram
inalterados. As duas replicas do Front Central permanecem no modelo recuperavel.
Ordem de variaveis de ambiente nao representa divergencia entre replicas;
valores realmente diferentes bloqueiam a captura.

backup.py tem acoes explicitas de plan, capture, upload, check, download,
prepare-server, start-sql, restore-sql, create-services, resume-source,
retention e cleanup-staging. Cada acao tem seus gates; nenhum deploy as chama.
Captura interrompida tenta retomar os servicos originais; SIGKILL exige a acao
de retomada manual. A restauracao automatizada nao inicia workers nem aplica
migrations e recusa origem/destinos ocupados. Estado administrativo SQL e
reconciliacao com provedores continuam gates assistidos, nao falsos sucessos.

Imagens Docker permanecem opcionais no padrao de dados. --include-images foi
implementado para permitir o ensaio completo sem rebuild/pull latest, sujeito
a espaco e janela. Snapshot integral da VPS, caches e Docker prune continuam
fora da implementacao. A ferramenta foi instalada separadamente em
/opt/yeshua-backup/current e systemd usa a rotina ONLINE, nunca captura com
parada. /root/YeshuaBackup/repository e o destino local aprovado, 0700 e cifrado.
Somente Shared.Backup foi acrescentado ao JSON privado; segredos dos apps,
cofre YouTube, Git HEAD e identidade/inicio/reinicios dos containers preservados.
O kit de acesso ao backup tem copia restrita fora da VPS. O destino externo
ainda precisa ser informado. As lacunas de volumes quentes/sem bind e de
estado administrativo SQL impedem afirmar recuperacao integral antes do ensaio.

### 0.2 Evidencias Da Primeira Execucao

Concluidas em 2026-10-20, entre 15:00 e 15:26 America/Sao_Paulo:

| Verificacao | Resultado |
| --- | --- |
| Full SQL | 10 bancos, incluindo sete de usuario e master/model/msdb; cerca de 195 MB adicionados |
| Diferencial SQL | Sete diferenciais e tres fulls de sistema; cerca de 5 MB novos |
| Logs SQL | Sete bancos elegiveis; cerca de 250 KB novos em cada rodada inicial |
| Arquivos | 1.982.269.626 bytes processados; 1.902.216.942 bytes adicionados |
| Integridade | Leitura de todos os blocos concluida as 15:26:13, sem erro |
| Cadeia SQL | Hashes e dependencias full/diferencial/log conferidos; nao executou restore |
| Agendamento | Seis timers habilitados somente apos essas conclusoes |
| Testes locais | 102 de backup, 25 de configuracao privada e teste Bash do setup aprovados |
| Nao alteracao | Containers/IDs/inicio/reinicios, credenciais dos apps e Git HEAD preservados |

Recibos detalhados e IDs exatos ficam em /root/YeshuaBackup/status e records,
privados. O kit de acesso foi copiado com ACL restrita para
%USERPROFILE%/.yeshua/private/recovery no computador do usuario. Essa copia e
somente da chave/configuracao de acesso, NAO dos dados do repositorio.
restore_proven permanece false: nenhum desses testes equivale a restauracao
funcional ou a protecao contra perda da VPS.

Revisao operacional final a1f540881e5fee03fa43 instalada e conferida as 15:54.
A rodada de arquivos seguinte adicionou somente 185.239 bytes para um conjunto
de aproximadamente 1,98 GB; conferencias e seis timers continuaram aprovados.
O timer de logs executou automaticamente as 15:35 e 15:50. O instalador foi
reexecutado com --initialize-online sem refazer o full inicial. Repositorio:
1.953.722.368 bytes; midias SQL nativas: 201.187.328 bytes; livre: cerca de
33,76 GB. O arquivo temporario de entrega da chave foi removido da VPS.
Credenciais dos apps, containers e revisao Git permaneceram inalterados.

Correcao de volateis, ainda em 2026-10-20: release fdbee5d21ef05122857f instalada
sem deploy/restart de aplicativos. A copia seguinte processou 1.861.124.244 bytes,
contra 1.982.414.108 da copia auditada anterior. Os 39 arquivos/121.292.476 bytes
dos dois grupos excluidos nao aparecem no novo snapshot; os outros 502 arquivos
do Storage foram preservados. A pequena diferenca adicional corresponde a
metadata/ferramenta atualizadas. Snapshot verificado:
547215cccd347150563f8f329771b8489250d5e8b03acb861ff30f4125e1213f.
Restic check aprovado. O filtro tar foi provado com fixture na VPS, sem captura
com parada. Testes locais: 107 aprovados e um teste de tar Linux nao aplicavel
ao Windows; o fixture equivalente executou na VPS. Origem volatil, snapshots
anteriores, containers, credenciais e Git HEAD permaneceram inalterados.
Nao houve prune nem liberacao do espaco ocupado pelos snapshots antigos.
As demais classificacoes continuam pendentes de discussao individual.

### 0.3 Setup E Adesao De Novos Aplicativos

O setup pertence a infraestrutura, nao a Engine. A Engine pode fornecer o
template inicial, mas nao acessa VPS, instala pacotes, cria agendas nem executa
backup. setup.sh chama o instalador comum depois do deploy inicial. O modo
--initialize-online conclui somente provas ausentes/mais antigas que uma falha,
reutiliza chaves e historico e habilita as agendas sem refazer baselines validos.
Nao executar setup.sh para antecipar um restore: ele tambem publica/migra apps.

Bancos de usuario no SQL conhecido sao descobertos automaticamente. Um banco
novo recebe full no proximo ciclo SQL, sem esperar domingo; logs posteriores
seguem o recovery model existente. TDE, indisponibilidade, permissao e falta de
espaco continuam bloqueios explicitos, nao exclusoes silenciosas.

Novos apps publicados no padrao Compose playsis-* sob infra do repositorio sao
descobertos pelos labels existentes. Nao ha lista de seis apps no backup.
O onboarding normal do deploy/credenciais ainda pertence a infraestrutura.
Novas subpastas reais sob Storage e privado production herdam a politica da
area, incluindo as exclusoes de volateis; nao exigem novo script ou estrategia
por app/tenant. Links nao estendem a cobertura
ao destino externo. Bind fora das areas conhecidas reprova a copia de arquivos;
volumes quentes ficam relacionados como pendencia de captura coordenada.

Roteiro de instalacao e tabela de cobertura em
[infra/bootstraps/README.md](../../infra/bootstraps/README.md). Esta integracao
esta nos fontes; nao foi executado setup geral/upgrade/deploy sobre a VPS ativa.

### 0.4 Pendencias Que Nao Bloqueiam A Fase Local

- Destino externo: escolher provedor, custo, acesso independente e protecao
  contra exclusao. Levar tambem o historico local ja existente, nao apenas
  trocar Repository e deixar as copias antigas presas na VPS. Testar acesso
  em outra maquina antes de considerar a pendencia encerrada.
- Recuperacao integral: fornecer novo servidor, preservar DNS da origem,
  controlar egressos e executar RECOVERY.md com reconciliacao SEFAZ/YouTube.
- Captura coordenada: combinar isolamento de escritores e pausa curta para
  volumes quentes, uploads internos e estado que nao admite copia online.
  Essas origens constam como excluidas nos recibos de arquivos online.
- Imagens Docker: permanecem adiadas; quatro referencias nao estavam
  exportaveis no inventario. Nao reconstruir nem reiniciar aplicativos para
  esconder essa lacuna. O ensaio exige imagens exatas ou alternativa aprovada.
- Acessos SQL: provisionar logins/usuarios/permissoes na instalacao e restauracao,
  usando infraestrutura versionada e arquivo privado, sem restaurar bancos de
  sistema. Copias master/model/msdb anteriores nao compoem a estrategia futura.
- Retencao/limpeza: somente simulacao ate aceite funcional. A reserva de
  8 GiB interrompe novos backups se necessario, nunca dispara exclusao.
- Aviso independente da VPS: definir canal externo de alerta de atraso/falha.
  Status privado e falha de unidade existem, mas nao avisam se a VPS sumir.

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

O inventario abaixo nasceu do repositorio; a secao 0.1 registra a conferencia
real posterior na VPS. Reconfirmar recursos antes da captura. Arquivo de
Compose sozinho descreve intencao, nao comprova o estado publicado.

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
| B5 | Imagens Docker, caches de build e snapshot integral da VPS | Posterior | Imagens opcionais para ensaio; cache/snapshot adiados |

B1 sem B2/B3 nao representa recuperacao completa. Um banco pode voltar
corretamente e ainda apontar para fotos, XMLs ou credenciais que foram perdidos.

### 2.2 Politicas Reutilizaveis

O catalogo de perfis de captura esta na secao 2 do mapa de dados:
`SQL_ESSENCIAL`, `ARQUIVOS_ESSENCIAIS`, `SEGREDOS_ESSENCIAIS`,
`CONFIGURACAO_ESSENCIAL`, `EVIDENCIA_SELETIVA`, `RECONSTRUIVEL`,
`TEMPORARIO` e `IMAGENS_ADIADAS`.

Para a primeira entrega, SQL_ESSENCIAL, ARQUIVOS_ESSENCIAIS,
SEGREDOS_ESSENCIAIS e CONFIGURACAO_ESSENCIAL compartilham frequencia, retencao
e repositorio. Eles diferenciam a captura, as permissoes e a prova exigida,
nao criam quatro estrategias ou agendas. A politica essencial define seus
parametros uma unica vez; areas apenas aderem a ela. Nao repetir a agenda em
appsettings de cada API, Worker, Studio ou tarefa Python. A secao 4 define os
parametros iniciais propostos, que ainda precisam ser aprovados e medidos.

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

Decisao confirmada em 2026-10-19 e adotada no deploy de 2026-10-20. O padrao e
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

Nao incluir `master`, `msdb`, `model` ou `tempdb` no backup, por decisao do
usuario. Configuracao necessaria deve ser reproduzida pela infraestrutura, com
segredos no arquivo privado. Provisionar acessos e conferir o vinculo dos usuarios
e permissoes aos bancos restaurados; nao depender de bancos de sistema antigos.
O codigo atual ainda precisa refletir essa selecao e comprovar o provisionamento.

### 3.2 SQL E Diretorios Do Host

| Origem declarada | Funcao | Tratamento |
| --- | --- | --- |
| /root/YeshuaDB/persistent/sql | Dados da instancia SQL; mount de /var/opt/mssql | Backup nativo .bak/.trn; nao copiar MDF/LDF ativos como backup |
| /root/YeshuaStorage/persistent/memorias/photos | Fotos originais; destino atual a corrigir | VOLATIL por padrao, confirmado; preservacao paga tenant/usuario a planejar, sem filtro dentro de persistente |
| /root/YeshuaStorage/persistent/memorias/publicacoes | MP4 locais, manifestos e intermediarios; destinos atuais a corrigir | MP4 sempre VOLATIL, sem plano pago; manifest.json e .render-* tambem VOLATEIS, confirmados |
| /root/YeshuaStorage/persistent/memorias/music | Trilhas padrao versionadas; destino atual a corrigir | VOLATEIS, confirmado; repor do Git/deploy com hash; adicionais desconhecidos aguardam classificacao |
| /root/YeshuaStorage/persistent/docs e persistent/Docs | Configuracao usa docs; bootstrap cria Docs, caminhos diferentes no Linux | DocsInput pendente de investigacao; demais areas em revisao; confirmar uso/conteudo sem mover ou excluir |
| /root/YeshuaStorage/volatile/ia/transcriptions e volatile/reports | Area volatil | Fora das novas capturas por decisao do usuario; nao apagar origem ou snapshots antigos |
| /root/YeshuaStorage/fiscal | Planos de emissao e artefatos; destino atual a corrigir | VOLATEIS por padrao, confirmado; certificado/senha persistentes permanecem em local restrito |
| /root/YeshuaStorage/sefaz | XMLs assinados e retornos SEFAZ; destino atual a corrigir | VOLATEIS por padrao, confirmado; guarda persistente paga e fallback de consulta a planejar |
| Apps.Memorias.PrivateRoot, atualmente /root/YeshuaMemoriasSecrets | Cofre OAuth, configuracao cifrada, chaves, sessoes de envio e recibos | Obrigatorio e restrito; resolver o bind efetivo, sem trocar por pasta nova vazia |
| /root/YeshuaPrivate/production/credentials.json | Credenciais tecnicas do ambiente | Obrigatorio e restrito; dono root e modo 0600 |
| /root/YeshuaPrivate/production/apps e shared | Integracoes externas, certificados fiscais novos e configuracoes proprias | Incluir subareas efetivamente usadas, com permissoes dos consumidores |
| /root/YeshuaDB/persistent/config | Arquivos antigos de configuracao | Legado para inventario; nao e mais a fonte do loader atual nem exige migracao nesta etapa |
| /etc/letsencrypt | Certificados HTTPS, chaves e configuracao de renovacao | VOLATIL, confirmado; reemitir pelo setup-cert.sh na recriacao, nao copiar nas novas capturas. Adequacao pendente, sem exclusao da origem/snapshots |
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

Nao incluir cegamente toda a raiz privada administrativa: operations pode
conter logs e recibos antigos de implantacao. A selecao deve incluir todas as
configuracoes/chaves recuperaveis e suas dependencias, com exclusoes explicitas
para evidencias operacionais que nao integram o estado a restaurar. Nenhuma
exclusao de backup autoriza apagar a origem.

Os MP4 locais do Memorias foram classificados pelo usuario como sempre volateis.
Sessoes resumable podem referenciar seu hash/tamanho; a aplicacao devera tratar
arquivo ausente ou regenerado sem presumir continuidade da mesma sessao. Essa
dependencia nao autoriza transformar o MP4 em persistente nem copia paga.

### 3.3 Exclusoes Propostas

Exclusoes sao especificas e aprovadas apos inventario, nunca deduzidas somente
pelo nome `volatile`, `temp` ou `output`.

| Item | Regra |
| --- | --- |
| Temporarios .render-* do FFmpeg | Excluir apenas os temporarios da tentativa; preservar manifest.json e video.mp4 final |
| Temporarios .tmp de escrita atomica | Excluir apos confirmar escritores parados e arquivo final existente |
| Locks de processo | Nao representam trabalho concluido nem credencial; nao restaurar lock ativo como estado de negocio |
| volatile/ia e volatile/reports | Fora do backup por decisao do usuario em 2026-10-20; isso nao autoriza limpeza da origem |
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

| Conjunto | Cadencia atual ou pendencia | RPO pretendido, ainda sem aceite funcional |
| --- | --- | --- |
| B1 SQL completo | Domingo 03:00 | Base semanal da cadeia, sem pausa |
| B1 SQL diferencial | Segunda a sabado 03:00 | Alteracoes desde o full, sem pausa |
| B1 SQL logs | Minutos 05/20/35/50 | Meta SQL de 15 minutos; nao estende aos arquivos/filas |
| B2+B3 arquivos | Diario 03:20 | Meta local diaria, online e nao globalmente atomica |
| Integridade do repositorio | Diario 05:30; blocos completos domingo 06:00 | Detectar erros, nao substitui restauracao |
| B1+B2+B3 coerentes | Janela com parada ainda pendente | Sem garantia de conjunto global antes da captura/ensaio |
| Extraordinario B1+B2+B3 | Antes de migration, upgrade relevante ou operacao destrutiva | Ponto validado anterior a mudanca |
| Configuracoes/chaves | Apos mudanca, vinculadas ao conjunto e a versao | Recuperar a configuracao correspondente aos dados |
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

Definir agrupamento estavel de snapshots por ambiente/escopo. Nao agrupar
por SetId, tag exclusiva ou caminho staging/<SetId>: isso pode criar um grupo
por execucao e impedir que a retencao elimine conjuntos antigos. Snapshot de
SQL isolado ou configuracao nao substitui o ultimo conjunto completo. Conferir
a selecao em simulacao antes de ativar exclusoes. `forget` remove referencias
de snapshots; `prune` recupera o espaco dos dados nao referenciados e roda
separadamente, como descreve o [Restic](https://restic.readthedocs.io/en/stable/060_forget.html).

RTO inicial para exercicio: 4 horas para Central + um aplicativo e 8 horas para
o ambiente de negocio, contando obtencao dos arquivos e reconciliacao externa.
Esses numeros sao hipoteses de planejamento. Sem imagens preservadas, builds
e downloads tambem entram no tempo e podem impedir essas metas.

Guardar uma copia local recente e uma copia fora da VPS. Preferir que a copia
externa tenha protecao contra exclusao pela credencial usada no servidor;
escolher e testar a compatibilidade dessa protecao com a ferramenta de backup.
Snapshots ou outro disco da mesma VPS nao cobrem perda do servidor/provedor.

## 5. Organizacao E Ferramentas

Implementacao atual, separada dos aplicativos e do deploy:

```text
infra/backups/
  policy.json                         # areas e limites, sem segredos
  sql.py                              # SQL nativo e inventario
  backup.py                           # captura, repositorio e recuperacao
  routine.py                          # online, cadeias, recibos e verificacao
  install.py                          # ferramenta versionada fora do deploy
  yeshua-backup@.service               # executor comum com limites
  yeshua-backup-*.timer                # cadencias por metodo, nunca por app
  README.md
  RECOVERY.md
```

A politica pertence a infraestrutura, nao a DSL nem ao caminho dos aplicativos.
Configuracao resolvida sensivel, recibos e resultados ficam privados fora do Git.

Usar uma area privada fora do Git e fora de qualquer caminho servido pelo
Nginx, por exemplo:

```text
/root/YeshuaBackup/
  repository/                         # Restic cifrado; mesmo disco, nao offsite
  records/                            # dependencias e checksum SQL
  intents/                            # recuperar recibo de backup interrompido
  state/sql-catalog.json
  metadata/current/                   # fontes/Git/Compose/limites de cobertura
  status/                             # conclusoes e falhas por rotina
  <SetId>/                            # captura coordenada, quando autorizada
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

### 5.1 Execucao E Acesso

O executor fica no host Linux. A agenda online e ativada depois da primeira
execucao/verificacao de cada metodo; ela NAO representa aceite de recuperacao
integral. Captura com parada, retencao e limpeza continuam acoes distintas e
nao agendadas. Ha um executor comum, nao um por aplicativo. O teste de restore comeca acompanhado em outro
ambiente, nao com um segundo SQL automatico na VPS publicada.

Shared.Backup usa o mesmo credentials.json para localizador, senha e credencial
do destino, sem env paralelo permanente. A rotina recebe apenas os
segredos necessarios no processo filho, sem argumentos de senha, xtrace,
stdout, relatorios ou exportacao para APIs/Workers. O kit externo inclui acesso
ao destino e senha de recuperacao; guardar so a senha do Restic nao garante
acesso a uma conta de armazenamento perdida.

Restringir as origens a leitura quando o mecanismo permitir. Escrita local
somente em staging, cache, locks e relatorios aprovados. Um processo com root
ou acesso Docker continua administrativo; uma convencao de script nao elimina
esse poder. Nao prometer isolamento contra root nem destino indelevel sem
testar as permissoes do provedor. Separar permissoes de upload e manutencao
quando o backend suportar o fluxo, inclusive os locks necessarios ao Restic.

Limitar CPU, memoria, banda e concorrencia do cliente depois de medir o piloto;
executar somente uma operacao SQL por vez. Limites do servico no host nao
limitam automaticamente o trabalho executado dentro do container SQL. Medir
espaco para .bak e staging sem copiar toda a midia por antecipacao. Nao afirmar
que deduplicacao tornara os fulls SQL baratos: bytes alterados, compressao e
volume real determinam o custo.

### 5.2 Copia Externa E Criterio De Sucesso

Na rotina Restic, criar snapshot no destino remoto e enviar seus dados fazem
parte de `backup`; nao sao dois uploads independentes. Nossa captura local
selada e uma etapa anterior. Exigir codigo de saida de sucesso, ID do snapshot
e cobertura de todas as origens obrigatorias. A existencia de um snapshot nao
basta: Restic pode criar copia incompleta com codigo 3 quando nao consegue ler
alguns arquivos. Ver [codigos de saida do Restic](https://restic.readthedocs.io/en/stable/040_backup.html#exit-status-codes).

Versionamento ou protecao contra exclusao do destino precisa de ensaio de
upload, locks, retencao e restauracao. Nao habilitar Object Lock ou regra de
expiracao do bucket por suposicao de compatibilidade. A expiracao de objetos
isolados nao pode quebrar blocos ainda usados por snapshots preservados.
Recuperacao do repositorio e protecao contra comprometimento da VPS sao
verificacoes distintas da criptografia dos arquivos.

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
3. No piloto, usar full `COPY_ONLY`; na rotina, adotar full convencional
   somente apos reconciliar as rotinas existentes e sua base diferencial.
   Para copia extraordinaria que nao deve interferir na rotina, usar full
   `COPY_ONLY`: ele nao altera
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
   O mesmo cuidado vale para BULK_LOGGED, conforme as
   [orientacoes de backup de log da Microsoft](https://learn.microsoft.com/en-us/sql/relational-databases/backup-restore/transaction-log-backups-sql-server?view=sql-server-ver16).
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

1. Aprovar politicas reutilizaveis e escolher destino (local aprovado agora;
   externo pendente), acesso de
   recuperacao, janela, limites e responsaveis. Vincular areas antes de criar
   rotinas; nao criar politica por arquivo ou tabela.
2. Confirmar o inventario do servidor e reconciliar os seis bancos declarados
   com todos os bancos encontrados. Identificar leitores/escritores externos,
   inclusive testes locais Windows usando os mesmos bancos remotos.
3. Converter o inventario confirmado em areas aderentes e excecoes visiveis,
   com tamanho, mounts, politica e dependencias. Manter caminhos existentes
   quando seguros; nao assumir que somente persistent contem dados importantes.
4. Testar repositorio local agora; repetir no externo quando escolhido,
   conferindo credencial, criptografia, envio e
   recuperacao de um arquivo ficticio. Documentar quem recupera senha/chave.
5. Reservar disco para .bak, staging de arquivos e margem operacional. Simular
   selecao e estimar volume antes de qualquer copia de toda a midia.
6. Capturar versoes efetivas, configuracao de firewall/DNS e arquivos privados
   necessarios. Nao salvar saida integral de `docker inspect`, `env` ou Compose
   expandido em relatorio publico: essas saidas podem conter segredos.
7. Simular a selecao a partir das areas/politicas e conferir que nenhuma origem
   obrigatoria ficou fora. Definir avisos e criterio de abortar; a primeira
   captura coordenada e manual/acompanhada. A agenda ONLINE tem aceite tecnico
   separado e nao afirma que essa captura com pausa ja foi demonstrada.

### 7.2 Executar Um Conjunto Coerente

1. Selecionar as areas pela politica e pelo conjunto coerente. Fixar revisao
   de configuracao, resolver destinos e rejeitar divergencias/mounts ausentes.
   Criar SetId e manifesto em estado INICIADO. Obter lock para impedir backup
   concorrente e usar o mesmo lock global do deploy durante a captura; reconferir
   os binds sob o lock antes de pausar os servicos.
   O lock proprio impede outra execucao durante todo o ciclo. O lock do deploy
   protege somente a captura local e a retomada, com espera limitada; nao
   manter o deploy bloqueado durante uma transferencia externa longa.
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
O lock do deploy tambem nao interrompe gravacoes das APIs, Workers ou do debug
local. Se nao for possivel comprovar a parada dos escritores, registrar a
captura limitada e nao promover seu resultado a conjunto coerente.

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
| 8 | Provisionar acessos/configuracoes SQL necessarios pela infraestrutura e arquivo privado | Logins, usuarios e permissoes conferidos nos bancos restaurados, sem restore de bancos de sistema |
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
  cifrada, oauth.bin, accounts e o bootstrap.json opcional do aplicativo
  precisam ser inventariados; o bootstrap sozinho pode nao representar a
  configuracao efetiva salva pela interface. Preservar Apps.Memorias.PrivateRoot.
- Arquivos fiscais PFX e senha.secret recebem o mesmo tratamento restrito do
  cofre. O log do backup nunca mostra seu conteudo.
- Recuperar primeiro para caminho/banco/instancia alternativa. Alterar somente
  o componente escolhido, com copia do estado anterior para eventual retorno.
- Exclusao por retencao exige destino confirmado e uma copia boa preservada;
  primeira implementacao roda retencao em simulacao.
- Remover/renomear uma area do cadastro nao autoriza apagar seus dados nem
  backups antigos. Preservar definicoes historicas e acesso aos conjuntos
  dentro da retencao; troca de chave/politica exige revisao das dependencias.

### 10.1 Limpeza Independente Do Backup

Existem tres acoes diferentes: retencao de snapshots externos, descarte de
staging/.bak locais ja protegidos e limpeza de temporarios dos aplicativos.
Nenhuma delas remove registros SQL, arquivos de negocio, certificados, fotos,
videos finais, XMLs, volumes Docker ou a origem do backup.

A aplicacao pode continuar removendo temporarios proprios ao concluir uma
tentativa. A tarefa de infraestrutura trata somente abandonados comprovados,
sem substituir essa responsabilidade nem inferir sucesso de saga pela idade.

Cada area temporaria adere a uma regra reutilizavel com raiz permitida, idade,
limite de espaco, periodicidade e prova de ausencia de trabalho ativo. Caminho
desconhecido, lock ambiguo, manifesto incompleto ou falta de regra causam
preservacao e alerta, nao exclusao para liberar disco.

Antes de apagar, simular selecao e quantidade/bytes por varios ciclos. Exigir
execucao unica, destino absoluto validado, nenhum symlink escapando da raiz,
nenhum mount inesperado e nenhum cruzamento para persistente/privado. Extensao
.tmp, nome volatile, ausencia de lsof ou mtime antigo nao provam abandono.
Limite de disco nao autoriza apagar o mais antigo sem avaliar sua classe.

`systemd-tmpfiles` e candidato apenas para areas simples realmente
descartaveis. Seus locks de protecao precisam ser compativeis com os produtores;
arquivo aberto nao e sinonimo de lock reconhecido. Para FFmpeg, upload e saga,
usar a prova/lock existente, nao um novo motor de limpeza de negocio. Ver a
[documentacao de envelhecimento e locks do systemd](https://www.freedesktop.org/software/systemd/man/latest/tmpfiles.d.html).

Subpastas .render-* podem coexistir com manifesto/video final: nao aplicar
uma regra recursiva generica sobre publicacoes. Audios e relatorios em
volatile permanecem sem limpeza automatica ate comprovar que nao sao a unica
origem. Corrigir a classificacao/bind por etapa propria; nao mover dados para
fazer o inventario parecer correto.

Staging SQL so pode ser descartado quando estiver fechado, sem operacao SQL
ativa e coberto por copia externa validada, conforme a retencao aprovada.
Preservar o ultimo conjunto recuperavel, falhas em investigacao e dependencias
de logs. Nunca limpar arquivos de dados SQL nem chamar prune por falta de
espaco na producao. A limpeza comeca em simulacao, separada do aceite SQL.

## 11. Sequencia Replanejada De Implementacao

Todas as etapas abaixo estao planejadas, nenhuma implantada. A nova ordem e
politica -> area -> adesao -> prova -> operacao continua, sem rotina por app.

As fases abaixo sao exclusivamente de backup, posteriores ao aceite da
centralizacao de credenciais ja adotada. Nao exigem repetir o deploy para
inventariar bancos nem autorizam execucao de backup/restore por este documento.

| Etapa | Entrega | Aceite |
| --- | --- | --- |
| P1 | Fechar politica essencial compartilhada e inventario esperado | Classes, retencao candidata, captura, responsaveis e decisoes ainda abertas registradas uma vez |
| P2 | Confirmar servidor e associar bancos/areas atuais a politicas | Binds reais, mounts, escritores, recovery models/logs, volumes e lacunas reconciliados, sem movimentacao em massa |
| P3 | Piloto SQL local manual e ensaio Restic com arquivos ficticios | Um banco por vez, .bak validado, restore/CHECKDB isolados e selecao/cifra comprovadas; ainda sem protecao contra perda da VPS |
| P4 | Configuracao versionada e rotina reutilizavel orientada a areas | Selecao em simulacao, perfis conhecidos, sem segredos no Git e sem scripts especificos por funcionalidade |
| P5 | Aprovar destino externo e proteger SQL, arquivos, cofres e configuracao coerentes | Captura manual externa e restore aprovados para cada conjunto; lacunas sem cobertura declaradas |
| P6 | Agendamento unico, alertas externos, retencao e limpeza separadas | Restore externo comprovado; exclusoes primeiro simuladas, limites medidos e janela aprovada |
| P7 | Adotar areas prontas em recursos novos e corrigir binds legados por app | Novo arquivo/tabela herda protecao sem novo job; dados antigos preservados antes de qualquer troca |
| P8 | Automatizar verificacao dos vinculos; DSL minima somente se necessaria | Relatorio do legado, validacao de recursos novos/alterados e referencias estaticas sem backup no caminho quente |
| P9 | Evoluir perda aceitavel SQL e comprovar recuperacao de mensagens | Cadeia de logs, efeitos externos e retomadas ensaiados; nao adia manutencao FULL nem preservacao de mensagens em risco |
| P10 | Backup de imagens Docker e eventual snapshot da VPS | Depois da estabilizacao, sem substituir as politicas de dados |

P1 define a politica compartilhada, nao significa aprovar todos os destinos do servidor.
P2 resolve esses destinos reais e as excecoes. Um risco imediato, como arquivo
unico no container ou log sem manutencao, deve ser contido antes de qualquer
deploy/recriacao; a ordem documental nao justifica perder dados aguardando P7/P9.

O piloto P3 comprova a copia SQL local e a recuperacao, nao o ambiente inteiro
nem a protecao contra perda da VPS. O provedor externo pode ser escolhido apos
essa prova; nao impede inventario, piloto local e ensaio com arquivos ficticios.
P5 demonstra a cobertura essencial externa; P6 completa a rotina operacional dessa
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
