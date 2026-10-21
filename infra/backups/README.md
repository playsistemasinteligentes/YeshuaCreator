# Backup E Recuperacao Yeshua

Ferramentas operacionais fora dos aplicativos e do deploy. O inventario segue
somente de leitura; o operador backup.py possui acoes explicitas para captura,
repositorio e recuperacao. O destino externo permanece pendente por decisao
do usuario; isso nao bloqueia a operacao local descrita abaixo.

Instrucao atual: continuar implementacao/testes locais. A limpeza/recriacao da
VPS foi adiada; os comandos deste documento nao foram executados nesta etapa.

## Rotina Online Local

Destino inicial aprovado: /root/YeshuaBackup/repository, privado e criptografado
pelo Restic. Shared.Backup.Repository vazio seleciona somente esse local;
Password continua no mesmo credentials.json protegido. configure-local gera
somente a senha de backup ausente, sem trocar qualquer chave existente.
Se um repositorio local ja existir sem a senha configurada, configure-local
recusa a operacao e exige a senha original; nao gera uma substituta inutilizavel.

| Rotina | Janela America/Sao_Paulo | Metodo |
| --- | --- | --- |
| SQL completo | Domingo 03:00 | Full nativo, base para os diferenciais |
| SQL diferencial | Segunda a sabado 03:00 | Alteracoes desde o full; novo full se a base foi trocada |
| SQL logs | Minutos 05/20/35/50 | Log nativo das bases FULL/BULK_LOGGED com full gerenciado |
| Arquivos | Diariamente 03:20 | Restic incremental/deduplicado |
| Integridade | Diariamente 05:30 | Metadados do repositorio |
| Leitura dos blocos | Domingo 06:00 | restic check --read-data |

### Selecao Por Raiz, Sem Excecoes

Decisao confirmada: somente PERSISTENTE e VOLATIL. O backup de arquivos seleciona
/root/YeshuaStorage/persistent inteiro e recursivamente. Nao seleciona a raiz
/root/YeshuaStorage nem sua pasta volatile. storage_excludes deve permanecer
vazio: nao e permitido esconder conteudo dentro de persistent por filtros.
O tar coordenado usa a mesma raiz integral, sem excecao para .render-*.
Novos aplicativos, tenants, arquivos e subpastas nessa raiz entram no proximo
ciclo, sem cadastro de jobs. SQL continua integral e nativo, sem MDF/LDF ativos.

Essa mudanca nao apaga a origem nem snapshots antigos e nao executa prune.
Os dados ja presentes em snapshots anteriores continuam ocupando espaco.
As demais classificacoes do mapa sao propostas em revisao, a discutir com o
usuario item por item; nao ampliar exclusoes sem essa revisao.

Nenhuma dessas rotinas para API/Worker, troca recovery model, executa SHRINK,
reinicia Docker ou altera Nginx. SQL usa um backup de cada vez e buffers de
4 MiB. O processo de backup tem prioridade de I/O baixa, quota de 25% de um
CPU e limite de 768 MiB. Essa quota nao limita o processo SQL, que fica no
container existente. A margem minima de disco e 8 GiB; falta de espaco gera
falha registrada, nunca prune ou remocao automatica de dados. Antes de gravar o
snapshot de arquivos, exigir espaco para uma copia nova inteira das origens
mais essa reserva, mesmo que a deduplicacao normalmente reduza o incremento.

O SQL nativo escreve somente no subdiretorio dedicado
/root/YeshuaDB/persistent/sql/backup/yeshua-scheduled; apenas esse subdiretorio,
e nao MDF/LDF, entra na copia Restic. No primeiro ciclo, o operador cria backup/
e yeshua-scheduled/ quando ausentes, com modo 0711 para permitir a travessia pelo
processo SQL. Diretorios existentes e a raiz SQL mantem dono/permissoes; cada
pasta nova de execucao continua 0700 e pertence ao UID do SQL no container.
Essa preparacao usa o mesmo fluxo do setup, sem comando manual adicional.
Records e intents em /root/YeshuaBackup
relacionam GUID, LSN, fork, tipo, checksum e arquivo. Um log concluido antes de
uma interrupcao deve ter seu recibo recuperado antes do proximo backup. Lacuna
de LSN ou troca de fork bloqueia afirmacao de cadeia recuperavel.

A rotina de arquivos cobre Storage/persistent, privado, cofre Memorias e HTTPS.
DECISAO POSTERIOR: HTTPS (/etc/letsencrypt) e VOLATIL, recriado pelo setup-cert.sh
no servidor novo. A rotina acima ainda o inclui; retirada das novas capturas e
ajuste da cobertura/restauracao estao pendentes no mapa, sem apagar snapshots
anteriores ou alterar certificados/Nginx agora.
Fontes, historico Git, copias do toolkit, builds, modelos baixaveis e imagens
Docker sao recriados, nao copiados. source.json registra somente revisao e
presenca de alteracoes locais; nao preserva essas alteracoes. Commit/push do
codigo e responsabilidade do fluxo de publicacao, nao da rotina de dados.
A captura e ONLINE, nao atomicamente consistente entre SQL e
arquivos. RabbitMQ/Redis/telemetria ativos, volumes do agente e uploads fora
de mounts nao sao copiados crus por ela: continuam exigindo a captura coordenada
separada. Essa pendencia nao fica escondida no recibo nem bloqueia proteger os
dados que ja podem ser copiados online. Imagens Docker continuam adiadas.

Instalacao e agendamento sao explicitos por install.py. O executavel fica em
/opt/yeshua-backup/current, separado do deploy e de git clean. Agendas somente
podem ser ativadas depois de full, diferencial, log, arquivos, leitura integral e verificacao
do plano da cadeia. Nao ha corrida de horarios perdidos (Persistent=false).

O setup do servidor chama install.py --initialize-online depois do primeiro
deploy. Essa opcao completa somente provas ausentes e habilita as agendas;
repetir o setup preserva senha/historico e nao repete baselines aprovados. O
setup pertence a infraestrutura, nao a Engine. Nao executar o setup geral no
meio de um restore: ele tambem executa deploy/migrations. Usar RECOVERY.md.
As unidades desta instalacao exigem os caminhos padrao do app e do JSON privado.
Recibos novos de arquivos usam persistent-roots-v3 com identidade da origem e cobertura
de recuperacao. O instalador refaz arquivos quando a selecao/metadata e antiga,
seguido da leitura integral; nunca reaproveita check-data anterior a uma nova
copia SQL/arquivos para habilitar as agendas. As baselines SQL validas continuam
reutilizadas. Isso nao altera a agenda nem adiciona limpeza ao deploy.

Novos bancos de usuario sao descobertos sem lista por app e recebem full na
proxima rodada SQL, inclusive quando ainda nao existe base para logs. Depois
seguem o recovery model existente, sem troca automatica. Containers Yeshua
sao reconhecidos pelo projeto playsis-* e arquivos Compose em infra do proprio
repositorio, nao por lista dos seis apps atuais. Subdiretorios sob Storage/persistent e
privado herdam a proxima copia. Montagens fora das areas conhecidas bloqueiam
a copia com erro de classificacao. Os volumes nativos do Shared de RabbitMQ,
Redis e agente sao VOLATEIS em ambas as capturas; outros volumes desconhecidos
bloqueiam a captura e devem usar uma raiz StorageLocation classificada. Nao sao
adotados implicitamente como persistentes. Nenhum diretorio aleatorio e assumido protegido.

Esta reforma foi testada localmente; nao confundir com a versao instalada na VPS.
Arquivos antigos em persistent continuam incluidos ate reclassificacao explicita:
nao ha exclusao retroativa nem mudanca automatica de caminhos SQL antigos.
O cofre YouTube nao foi movido. A classificacao foi ENCERRADA pelo usuario em
2026-10-21. Declaracoes DocsInput/DocsOutput/configuracoes Docs sem consumidores
foram retiradas sem apagar diretorios existentes. O Compose passa telemetria/Grafana
para /root/YeshuaStorage/volatile/infra/telemetry, sem alterar coleta/retencao.
Mount legado de telemetria bloqueia captura ate a virada intencional, sem filtro
dentro de persistente. Nada disso foi aplicado a VPS nesta continuacao.

Novas capturas online/coordenadas nao incluem /etc/letsencrypt. Recibos v2 nao
habilitam as agendas atuais: refazer arquivos e leitura integral, preservando
baselines SQL validas. Snapshots v2 continuam legiveis/restauraveis explicitamente,
inclusive HTTPS quando capturado; nao apagar origens ou backups anteriores.

### Guarda Da Senha De Recuperacao

O setup.sh resolve a guarda logo apos validar a configuracao privada, antes da
atualizacao geral, Docker ou builds. Usa as mesmas acoes configure-local e
recovery-key do operador; caso faltem, instala somente Restic/util-linux nessa
fase. O install.py final reutiliza a confirmacao, sem nova pergunta quando
senha/repositorio/maquina forem os mesmos. Nao ha segundo modo de instalacao.

Antes dessa guarda, o setup usa init --wait para aguardar o credentials.json
ausente/invalido: preparar ou repor em outra sessao no caminho do servidor e
confirmar PRONTO no terminal. Nao digitar segredos no prompt. Credenciais validas
ja restauradas sao reutilizadas sem essa pergunta. Sem terminal para concluir
o preparo, o setup para antes de instalar/subir servicos da aplicacao. A guarda
da senha segue estes passos:

1. Acompanhar em terminal privado interativo, sem gravacao/compartilhamento.
2. Digitar EXIBIR para autorizar a visualizacao da senha existente.
3. Guardar a senha e a identificacao do repositorio em local protegido fora da VPS
   e fora do proprio backup cifrado. Nao enviar ao chat, Git ou logs.
4. Digitar GUARDEI para confirmar a responsabilidade pela guarda.

EXIBIR e GUARDEI aceitam maiusculas/minusculas e espacos nas bordas. Respostas
incorretas ou vazias repetem somente a pergunta atual, sem encerrar o setup,
reexibir a senha ou registrar o texto digitado. Uma linha longa e descartada por
inteiro antes da nova pergunta. CANCELAR, Ctrl+C ou fim da entrada encerram sem
confirmar a guarda; nao ha aceite automatico nem geracao de outra senha.

A senha e escrita diretamente em /dev/tty, nunca no stdout/stderr capturado,
JSON de retorno ou recibos. Sem terminal privado ou confirmacao, o setup
interrompe antes das atualizacoes/deploy; servicos e agendas preexistentes nao
sao desligados. Sessoes de terminal podem ser gravadas externamente: o operador
deve escolher um terminal privado, pois o script nao consegue detectar essa gravacao.

state/recovery-key-custody.json guarda somente identificacao por hash, maquina,
data e declaracao de guarda. Nao comprova a existencia/leitura da copia externa
nem substitui o ensaio de recuperacao. Reinstalacao na mesma maquina com a mesma
senha/repositorio reutiliza a confirmacao; outra maquina ou senha exige nova
confirmacao. Nao ha rotacao automatica. Rotinas agendadas nao exibem segredos.

Para visualizar de novo, somente de forma explicita no terminal privado:

```bash
sudo env YESHUA_APP_DIR=/root/YeshuaCreator \
  python3 -B /opt/yeshua-backup/current/infra/backups/backup.py recovery-key --show-recovery-key
```

Esse comando nao gera senha nem exporta as demais credenciais. A copia dos dados
ainda e local: guardar a senha fora da VPS nao protege o repositorio contra perda
do disco. O destino externo continua como pendencia independente.

### Outras Chaves Conferidas No Setup

Nos caminhos de provisionamento revisados, a senha do backup e a unica chave
de recuperacao que o setup gera e precisa entregar para guarda independente.
Nao houve leitura de valores reais nem auditoria de chaves do sistema operacional.

| Material | Momento e tratamento |
| --- | --- |
| SQL, RabbitMQ, JWT, autenticacao entre modulos e assinatura de upload | Entradas do credentials.json, preenchidas/restauradas antes da validacao inicial; nao gerar ou mostrar novamente |
| Chaves dos provedores de IA | Integracoes opcionais no providers.json privado; nao geradas pelo setup, entram no backup privado |
| Chave do cofre YouTube | Pode ser criada ao salvar a configuracao no Memorias, nao pelo setup; permanece com o cofre persistente e nao e exposta nesta etapa. Discussao sobre armazenamento continua adiada |
| Certificados fiscais e senhas | Fornecidos ao aplicativo; persistentes na area privada, nao gerados no setup |
| HTTPS/Certbot | Reemitido pelo setup-cert.sh separado, classificado VOLATIL; nao exige entrega manual de chave para backup |

Quando o destino externo for escolhido, conferir tambem o acesso necessario a ele
no kit de recuperacao. Essa credencial ainda nao e criada por esta instalacao.

```bash
sudo python3 -B infra/backups/install.py
sudo YESHUA_APP_DIR=/root/YeshuaCreator python3 -B /opt/yeshua-backup/current/infra/backups/backup.py scheduled --kind full
sudo YESHUA_APP_DIR=/root/YeshuaCreator python3 -B /opt/yeshua-backup/current/infra/backups/backup.py scheduled --kind logs
sudo YESHUA_APP_DIR=/root/YeshuaCreator python3 -B /opt/yeshua-backup/current/infra/backups/backup.py scheduled --kind differential
sudo YESHUA_APP_DIR=/root/YeshuaCreator python3 -B /opt/yeshua-backup/current/infra/backups/backup.py scheduled --kind files
sudo YESHUA_APP_DIR=/root/YeshuaCreator python3 -B /opt/yeshua-backup/current/infra/backups/backup.py scheduled --kind check-data
sudo python3 -B /opt/yeshua-backup/current/infra/backups/install.py --enable-schedules
```

sql-restore-plan confere arquivos e monta full + ultimo diferencial compativel
+ logs posteriores. Nao restaura nem aprova teste funcional. status informa
recibos/falhas e espaco livre, sempre deixando offsite=false no destino local.
Perda da VPS/disco continua desprotegida ate existir copia externa.

Em 2026-10-20 foi concluido o inventario real da VPS. O ensaio escolhido pelo
usuario e recuperar o ambiente em um novo servidor, sem laboratorio SQL
preliminar. Testes de codigo e verificacoes de integridade continuam obrigatorios.

O procedimento completo esta em [RECOVERY.md](RECOVERY.md). Nao executar os
exemplos de captura fora de uma janela combinada: eles param os servicos.

## Uso No Servidor

```bash
sudo python3 -B infra/backups/sql.py inventory
```

Sem argumento, a acao tambem e inventory. A configuracao privada segue o
padrao existente: /root/YeshuaPrivate/production/credentials.json, ou
YESHUA_DEPLOY_SECRETS_FILE / --file para arquivo absoluto aprovado. O leitor
comum confere permissoes; nao ha arquivo de senhas proprio do backup.

O inventario le a senha administrativa SQL existente e consulta somente
metadados no container yeshua-sqlserver. Nao concede privilegios. A senha vai
no ambiente temporario do cliente, nunca nos argumentos, SQL ou relatorio.
SQLCMDPASSWORD e entregue ao processo docker exec sem valor no argumento.
O cliente usa localhost dentro do container SQL e o certificado interno e
aceito apenas nessa conexao, sem alterar configuracao TLS do servidor.

## O Que Confere

- Versao/edicao SQL, catalogos, estado, recovery model e criptografia declarada.
- Tamanho alocado de dados/log, nao estimativa garantida do tamanho do .bak.
- Ultimos registros de full, COPY_ONLY e log no historico msdb. Ausencia de
  registro nao comprova que nunca existiu backup ou agenda externa.
- Permissao administrativa atual e permissao BACKUP DATABASE por catalogo;
  a prova de backup e restore continua separada.
- Operacoes BACKUP/RESTORE em andamento e quantidade de jobs SQL habilitados.
- Ferramenta sqlcmd ja instalada no container, sem instalar uma substituta.
- Memoria, disco, carga e tamanhos de areas conhecidas, com du de baixa
  prioridade e tempo limitado. Falha/timeout de medicao fica explicito.
- Mounts, imagens e inicio/reinicios dos containers, sem mostrar ambiente.
- Indicios de agendas de backup em timers e cron de sistema/root. Nao e
  auditoria completa de todos os agendadores, scripts ou contas do provedor.

Os seis nomes publicos do deploy.env sao expectativa de inventario, nao
substituem o destino das conexoes privadas. Banco adicional vira pendencia
para classificar, nunca e apagado ou adotado silenciosamente.

O comando imprime JSON sem segredos. O inventario de topologia ainda e
administrativo: guardar eventual relatorio em area restrita fora do Git, nao
em /storage nem em pagina publica. Falhas nao mostram stdout/stderr bruto do
cliente; codigos numericos e categorias conhecidas podem aparecer.

## Limites De Aceite

Inventario nao e backup. Na resposta de inventory, backup_executed e
restore_proven permanecem false; os recibos de execucao ficam em status.
Uma observacao de saude, espaco ou permissao nao certifica a proxima execucao.
Rever recursos e concorrencia imediatamente antes do futuro piloto.

O cliente SQL usa -y 0 sem -h, combinacao compativel com sqlcmd ODBC. O resultado
tem marcador proprio e JSON validado, sem limite de coluna que possa aceitar
lista truncada como inventario completo. A consulta e estatica e nao inclui
credenciais nem dados de negocio.

O roteiro anterior de laboratorio SQL foi substituido pelo ensaio de recuperacao
completa em novo servidor. Nao usar SQL LocalDB 2019 para restaurar SQL 2022,
nem criar outro SQL automaticamente na VPS publicada. VERIFYONLY nao substitui
RESTORE DATABASE, CHECKDB e teste funcional.

## Operador

```bash
sudo python3 -B infra/backups/backup.py plan
```

Sem argumento, backup.py tambem executa apenas plan. Usa o mesmo credentials.json
privado. A configuracao publica de areas/limites fica em policy.json. Nao altera
Compose de producao, Nginx, migrations, DNS ou o procedimento normal de deploy.

| Acao | Efeito |
| --- | --- |
| configure-local | Prepara o repositorio local aprovado e somente a chave ausente |
| scheduled --kind TIPO | Executa a rotina online comum e registra resultado |
| status | Lista recibos/falhas e espaco, sem revelar segredos |
| sql-restore-plan | Confere hashes e dependencias full/diferencial/logs, sem restaurar |
| plan | Metadados, cobertura, espaco e memoria; nao cria arquivos |
| init-repository | Cria explicitamente repositorio Restic externo vazio |
| capture | Pausa coordenada, SQL nativo, arquivos e manifesto selado local |
| upload | Envia somente um conjunto selado; nunca para producao |
| check | Confere repositorio; --read-all-data le os blocos tambem |
| download | Recupera snapshot exato em diretorio novo e confere arquivos |
| prepare-server | Reconstroi arquivos/imagens em servidor novo confirmado |
| start-sql | Sobe somente SQL, porta vinculada a loopback |
| restore-sql | Restaura bancos de usuario vazios com MOVE e CHECKDB |
| restore-sql-chain | Aplica cadeia online verificada somente em SQL novo/vazio confirmado |
| restore-files | Planeja reposicao integral dos arquivos; --apply exige maquina nova e destinos vazios |
| create-services | Cria demais containers parados e recupera uploads internos |
| resume-source | Retoma IDs originais apos interrupcao abrupta da captura |
| retention | Simulacao por padrao; nunca executa prune |
| cleanup-staging | Simula descarte de um SetId local; aplicar exige este snapshot restaurado e aceito |

capture exige --allow-pause e --external-writers-isolated. O segundo e uma
afirmacao operacional, nao um firewall: o operador deve bloquear novas conexoes
de escrita externas, encerrar debug remoto e impedir tarefas externas durante
a janela. As sessoes SQL existentes tambem sao verificadas. Isso nao controla
efeitos ja enviados a provedores como SEFAZ/YouTube.

DECISAO APLICADA LOCALMENTE: master/model/msdb e tempdb ficam fora de novas
capturas online/coordenadas, inclusive na chamada direta das primitivas SQL.
Bancos de usuario sao selecionados automaticamente, sem lista fechada de Studios.
Midias/recibos antigos de sistema nao sao copiados nos novos snapshots SQL; ficam
intactos no disco/repositorio anterior. Nenhum
banco ou backup anterior sera apagado por mudar a selecao futura.

Estudo foi confirmado pelo usuario como PERSISTENTE: manter banco inteiro
no backup SQL nativo comum e na recuperacao, mesmo sem Studio identificado.
A selecao o inclui e tambem recebe novos bancos de usuario, sem limitar a
descoberta aos nomes publicados em deploy.env.

Instalacao/recriacao deve provisionar os acessos SQL necessarios pela
infraestrutura versionada, usando o arquivo privado e conferindo os usuarios
e permissoes dos bancos restaurados. Nao depender de restauracao de bancos de
sistema. O setup integra infra/private/sql_access.py, com contas adicionais
declaradas em Shared.SqlServer.Logins e sem rotacao automatica. Ver o roteiro
em infra/private/README.md; uso real e vinculos restaurados ainda precisam de prova.

Na captura coordenada, o padrao COPY_ONLY nao altera a base diferencial nem
implementa cadeia de logs. Esse conjunto recupera o ponto da captura, nao um
instante posterior. A rotina ONLINE usa outro caminho do mesmo operador: full
normal, diferencial e logs nativos. Nao misturar os dois fulls nem prometer
recuperacao por horario antes do ensaio. Os logs nativos ja sao capturados na
fase local aprovada, sem mudar recovery model nem executar SHRINK.

Storage/persistent e raizes privadas entram inteiros; SQL cru e volateis ficam
sempre fora. Exportacao de imagens Docker
esta desabilitada para novas capturas. Software deve ser reconstruido do Git.
O preparo automatico baseado em imagens exatas e fontes arquivados atende
somente conjuntos antigos; veja a atualizacao no inicio de RECOVERY.md.

Os Compose usados na recuperacao sao copias privadas resolvidas dos modelos
existentes, com imagens fixas, replicas registradas, volumes reais e hostname
do RabbitMQ preservados. Nao constituem outra fonte de desenvolvimento: nao
editar telas nem publicar por eles. O retorno ao deploy normal e um gate final.

## Credenciais Do Repositorio

Shared.Backup no mesmo JSON privado: Repository, Password e Environment.
Repository aceita S3 HTTPS ou SFTP, ou vazio para a fase LOCAL explicitamente
aprovada. Uma pasta na VPS nunca e descrita como copia externa. Password e independente das senhas SQL/SSH. Environment aceita
somente as variaveis do backend listadas no codigo. Valores nao vao em argumentos,
relatorios ou logs. SFTP exige chave e host previamente confiados pelo sistema;
o operador nao desabilita verificacao SSH nem administra chaves automaticamente.

Copiar o acesso ao armazenamento e a senha de recuperacao para um lugar seguro
fora da VPS e fora da unica copia criptografada. Nao guardar a unica chave
dentro do proprio backup. O kit inicial do novo servidor fica em outro
diretorio privado, nao no destino que sera restaurado.

Restic deve ser instalado pelo administrador a partir de distribuicao confiavel;
o operador nao baixa executaveis. A copia usa um processo, prioridade baixa e
nenhum paralelismo de backups SQL. Transferencias externas tem teto de 2 MiB/s
de envio e 4 MiB/s de leitura. Tar/Git/SQL/Restic com erro bloqueiam o selo.
Exit 3 do Restic e falha, mesmo que exista snapshot parcial.

As unidades systemd usam a rotina ONLINE, nao capture. A captura com parada
continua exigindo janela e isolamento real de escritores externos.
Retencao destrutiva exige recibo administrativo de aceite e recusa remover o
snapshot aceito. Descarte local e separado, restrito a um SetId selado,
com recibo de upload, manifest externo correspondente e aceite deste snapshot.
Limpeza de arquivos de negocio, SQL cru, volumes, imagens e
cache Docker nao faz parte da rotina. Retencao deve selecionar --kind sql,
--kind files ou --kind coordinated: nunca misturar perfis, nem agrupar pelo
RunId unico. Nao ha agenda de retencao destrutiva ou limpeza nesta fase.

## Testes Sem Producao

```bash
python3 -B -m unittest discover -s tests/Infrastructure/Backup -p 'test_*.py' -v
```

Os testes usam fixtures/mocks e nao abrem conexoes SQL reais.
