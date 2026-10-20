# Roteiro De Recuperacao Em Novo Servidor

Status: implementacao disponivel para ensaio. Recuperacao real ainda nao provada.
Nenhum comando deste roteiro foi executado para parar a VPS publicada.

DECISAO POSTERIOR: o usuario autorizou descartar o estado atual do ambiente
Yeshua, inclusive bancos e conexoes YouTube, para uma instalacao limpa. Nao e
necessario migrar tokens/arquivos antigos nesta virada. A autorizacao e pontual:
nao torna o deploy normal destrutivo nem inclui sistema operacional, fontes,
acessos administrativos ou canais/videos publicados no Google. Reinstalar do
zero NAO comprova restore; gerar e validar uma nova base de backup depois da
reinstalacao, antes do futuro ensaio de recuperacao em outro servidor.

## Atualizacao: Restaurar Dados E Reconstruir Software

Esta secao prevalece sobre o roteiro historico de recuperacao rapida abaixo.
Novas copias NAO incluem fontes, bundle Git, toolkit nem imagens Docker.
source.json identifica a revisao; alteracoes locais nao commitadas nao sao
recuperaveis por esse backup. O cofre YouTube/chaves existentes sao preservados.

No servidor novo: obter o fonte no Git/revisao publicada; instalar dependencias;
baixar e verificar os snapshots exatos SQL e arquivos em uma area de recuperacao;
repor credentials.json/cofres com suas permissoes originais; reconstruir as imagens;
subir SOMENTE SQL, isolado, na versao compativel; executar sql-restore-plan e
restore-sql-chain conforme as guardas abaixo; repor integralmente os diretorios
persistentes em destinos vazios; depois publicar APIs/Workers/front a partir do
Git, verificando migrations e mantendo saidas externas bloqueadas ate aceite.
Repor trilhas e outros assets recriaveis pelo deploy, nao pelo backup de dados.

Fotos/videos/manifestos/XMLs classificados como volateis NAO voltam. Seus registros
SQL podem voltar; a aplicacao informa ausencia/reenvio/nova publicacao. Recuperar
XML completo da SEFAZ ainda exige investigacao por servico e nao e garantia atual.

NAO executar setup.sh sobre SQL restaurado sem revisar a etapa de deploy/migrations.
O preparo automatico de um restore integral a partir de copias somente de dados
ainda depende de terminar a classificacao dos volumes e do ensaio no servidor novo.
prepare-server (modelo congelado/imagens exatas) atende conjuntos antigos e recusa
novos conjuntos data-only ANTES de alterar destinos. --include-images esta
desabilitado para novas capturas. Nao misturar o procedimento antigo com este.
As ferramentas SQL online e download --verify continuam utilizaveis; recuperacao
100% do ambiente permanece nao comprovada. Nao apontar DNS antes do aceite.

## Procedimento Historico: Conjuntos Com Fontes E Imagens

As secoes seguintes documentam conjuntos antigos. Nao sao instrucao para gerar
novos bundles/imagens nem prometem backup de fotos/volateis na politica atual.

## Fase Local Aprovada Em 2026-10-20

Nao esperar o provedor externo para proteger os dados online. O usuario aprovou
repositorio local em /root/YeshuaBackup/repository e deixou o destino externo
pendente. A rotina full/diferencial/logs/arquivos esta detalhada em README.md.
Um repositorio no mesmo disco nao protege perda da VPS, mesmo criptografado.

O bootstrap gera somente Shared.Backup.Password quando ausente. Guardar tambem
um kit restrito fora da VPS contendo essa senha; nao incluir senha SSH no kit.
No novo servidor o repositorio precisara ser transportado/copiado de forma
controlada; o caminho local vazio, sozinho, nao torna a copia acessivel la.

Recuperacao SQL incremental exige full normal compativel + ultimo diferencial
da mesma base, se houver, + logs em ordem sem lacuna. Nao aplicar esses
diferenciais por cima do COPY_ONLY de uma captura coordenada diferente. O
catalogo guarda as dependencias e sql-restore-plan confere a cadeia e hashes.
download aceita snapshot exato kind=sql ou kind=files, recupera em diretorio
novo e emite recibo somente depois de restore --verify. restore-sql-chain
exige esse recibo SQL, --download-root e --new-server-machine-id. O destino
deve ter SOMENTE o SQL de recuperacao ligado, mesma versao capturada, nenhum
banco de usuario e nenhuma sessao externa. Aplica full com NORECOVERY, depois
diferencial/logs e termina com RECOVERY/CHECKDB. Recusa a maquina original.
Nao restaura bancos de sistema nem afirma consistencia global com arquivos.
O ensaio assistido no servidor novo ainda e obrigatorio antes de afirmar
recuperacao. Nao executar restore-sql e restore-sql-chain sobre o mesmo destino:
o primeiro usa a captura coordenada; o segundo e alternativa para SQL online.

As snapshots de arquivos online nao incluem volumes quentes de RabbitMQ/Redis,
telemetria ou uploads internos sem bind. Para recuperar 100% do ambiente e
necessario complementar com o conjunto coordenado abaixo e reconciliar os
efeitos externos. Nao confundir agendas online ativas com esse aceite global.

## 1. Antes Da Primeira Copia

1. Para a fase local, usar o repositorio aprovado; o externo NAO e requisito.
   Quando escolhido, preparar S3 HTTPS ou SFTP restrito e testar transferencia.
2. Preencher Shared.Backup no credentials.json existente, fora do Git. Na fase
   local, configure-local prepara esse bloco sem trocar segredos existentes.
3. Guardar senha do repositorio e acesso ao armazenamento fora da VPS tambem.
4. Instalar Restic no host por fonte confiavel; conferir versao e executar plan.
5. Inicializar explicitamente o repositorio vazio. Nao inicializar sobre um
   endereco que deveria conter backup anterior; investigar em caso de erro.
6. Combinar janela e isolar TODOS os escritores, inclusive debug local contra
   SQL remoto, cron, integradores e outros hosts. Bloquear novas conexoes SQL
   externas no firewall do provedor durante a captura, preservando SSH e a
   rede interna Docker. Conferir a regra antes de iniciar; o script nao a cria.
7. Nao iniciar deploy, migrations nem operacoes fiscais manuais nessa janela.

```bash
sudo python3 -B infra/backups/backup.py plan
sudo python3 -B infra/backups/backup.py init-repository
```

O primeiro inventario real confirmou SQL 2022 16.0.4265.3, seis bancos Yeshua,
o banco adicional Estudo, master/model/msdb e tempdb. A captura cobre todos,
exceto tempdb. COPY_ONLY e checksum nao alteram recovery model nem corrigem
por si so a ausencia de rotina de log em bancos FULL.

## 2. Captura Coerente

Na janela aprovada, no servidor de origem, depois do isolamento externo:

```bash
sudo python3 -B infra/backups/backup.py capture \
  --allow-pause --external-writers-isolated --include-images
```

--include-images e indicado para o ensaio de recuperacao integral, mas continua
opcional no padrao de backup de dados. O arquivo e preparado antes da pausa;
nao ha compilacao. Se faltar espaco, a operacao recusa; nao apagar volumes,
dados, imagens ou backups para forcar passagem sem um plano de capacidade.

A captura fecha o Nginx primeiro, para os escritores, depois os servicos com
estado. SQL continua ligado apenas para backup nativo. Faz backups sequenciais,
VERIFYONLY/CHECKSUM, captura arquivos, cofres e volumes parados e retoma somente
os containers que estavam ligados. O Nginx volta por ultimo. A pausa cobre a
copia LOCAL; nunca fica esperando upload externo.

O resultado informa SetId. Os arquivos ficam em /root/YeshuaBackup/SET_ID,
0700, fora de /storage e do Git. manifest.json descreve o conjunto; seal.json
tem SHA256 das partes. compose.json contem segredos e e estritamente privado.
source.tar preserva o conteudo versionado atual, inclusive alteracoes locais;
source.bundle preserva historico Git. A configuracao HTTPS efetivamente ativada
tambem e incluida, sem alterar as rotas publicadas.

Um erro nao produz conjunto aceito. SIGINT/SIGTERM tentam retomar disponibilidade;
SIGKILL, falha do host ou perda de energia podem exigir retomada manual:

```bash
sudo python3 -B infra/backups/backup.py resume-source --set /root/YeshuaBackup/SET_ID
```

Essa acao confere a identidade da maquina e os IDs originais, sem recriar nem
atualizar containers. Se a retomada falhar, recuperar disponibilidade antes de
qualquer novo ensaio. Nao usar docker compose down, rm -f ou prune como reparo.

## 3. Copia Externa

Depois que os servicos originais voltarem:

```bash
sudo python3 -B infra/backups/backup.py upload --set /root/YeshuaBackup/SET_ID
sudo python3 -B infra/backups/backup.py check --read-all-data
```

Guardar o snapshot_id completo do recibo em local externo. Nao usar latest no
restore. Falha de rede preserva o conjunto selado para repetir upload, sem outra
pausa e sem afirmar que a copia externa foi concluida.

Nenhum arquivo local e removido automaticamente, mesmo apos upload. Nao usar
retencao destrutiva antes do primeiro aceite de restauracao. O recibo nao e
prova de funcionamento do aplicativo restaurado.

## 4. Preparar O Servidor Novo

1. Criar VPS Linux nova, mesma arquitetura, com disco para copia baixada,
   volumes restaurados, imagens e margem operacional. Nao usar a VPS original.
2. Manter DNS apontando para a origem. No novo firewall liberar somente SSH
   administrativo; bloquear entrada publica e saida para SEFAZ/YouTube/SMTP e
   outros provedores ate a reconciliacao. Proteger tambem redes Docker/IPv6,
   nao confiar somente em UFW para portas publicadas pelo Docker.
3. Instalar Docker/Compose, Python 3.11+, Git, tar com ACL/xattrs e Restic por
   fontes confiaveis. Nao rodar setup.sh/deploy.sh: eles publicam e migrariam a base.
4. Colocar o kit desta implementacao em /opt/yeshua-recovery, com os caminhos
   infra/backups e infra/private/credentials.py preservados. Nao colocar o kit
   dentro de /root/YeshuaCreator, que precisa estar vazio para receber a copia.
5. Criar /root/YeshuaRecoveryAccess (0700) com credentials.json (0600) contendo
   SchemaVersion e Shared.Backup. Nao e preciso saber novamente a senha SQL:
   ela vira no arquivo privado recuperado. Este arquivo e de bootstrap; nao
   ocupa a pasta privada original que sera restaurada.
6. Conferir /etc/machine-id e anotar esse valor como NOVO_MACHINE_ID. Nao
   copiar o machine-id da origem. O operador compara ambos antes de escrever.

```bash
cd /opt/yeshua-recovery
sudo python3 -B infra/backups/backup.py download \
  --file /root/YeshuaRecoveryAccess/credentials.json \
  --snapshot SNAPSHOT_ID_COMPLETO \
  --target /root/YeshuaRecovery/ENSAIO_001
```

O resultado informa o diretorio exato do conjunto recuperado. Chamaremos esse
caminho de DIRETORIO_DO_CONJUNTO nos comandos abaixo. O download nunca restaura
direto em /, nao apaga arquivos existentes e verifica os dados baixados.

## 5. Repor Arquivos E SQL

```bash
sudo python3 -B infra/backups/backup.py prepare-server \
  --file /root/YeshuaRecoveryAccess/credentials.json \
  --set DIRETORIO_DO_CONJUNTO --new-server-machine-id NOVO_MACHINE_ID

sudo python3 -B infra/backups/backup.py start-sql \
  --file /root/YeshuaRecoveryAccess/credentials.json \
  --set DIRETORIO_DO_CONJUNTO --new-server-machine-id NOVO_MACHINE_ID
```

prepare-server recusa pastas de destino nao vazias, containers existentes e
volumes de mesmo nome. Reconstroi arquivos, permissoes, volumes, fontes Git e
imagens exatas. As fotos e chaves YouTube retornam juntas; nenhuma chave e
gerada. Nao substitui cofre existente. O SQL cru original nunca e copiado.

start-sql liga somente o SQL, com porta de host 127.0.0.1:1433. Aguardar ele
ficar pronto e conferir sua versao. Os proximos comandos usam o arquivo privado
RESTAURADO, com a senha original correspondente ao SQL e aos aplicativos.

```bash
sudo python3 -B infra/backups/backup.py restore-sql \
  --set DIRETORIO_DO_CONJUNTO --new-server-machine-id NOVO_MACHINE_ID

sudo python3 -B infra/backups/backup.py create-services \
  --set DIRETORIO_DO_CONJUNTO --new-server-machine-id NOVO_MACHINE_ID
```

restore-sql recusa qualquer banco de usuario preexistente, verifica imagem e
versao SQL, usa MOVE para os arquivos novos e executa CHECKDB. Nao usa REPLACE,
SHRINK, SINGLE_USER nem encerra sessoes de terceiros. Falha no meio deixa o
ensaio pendente: nao tentar rerodar por cima nem adicionar REPLACE. Investigar
e repetir em destino vazio controlado.

create-services cria os demais containers PARADOS, sem build/pull/migration,
preserva duas replicas do Front Central e recupera /app/uploads quando existia
no container de origem. RabbitMQ recebe seu volume, cookie e hostname antigo.
Nenhum worker, renderer, automacao ou endpoint publico e ligado nessa etapa.

## 6. Estado De Servidor SQL E Reconciliacao

Os arquivos master/model/msdb.bak sao capturados, mas NAO sao restaurados por
restore-sql: master exige inicializacao single-user e para o processo ao ser
restaurado; msdb pode reintroduzir jobs. Isso deve ser uma etapa DBA assistida
na maquina nova, com imagem/build identicos e apps parados. Nao usar o
procedimento de banco comum para substituir bancos de sistema.

O caminho padrao deste ensaio e restaurar os bancos de usuario e repor o
estado administrativo necessario de maneira assistida. NAO restaurar master
por cima depois disso: ele traria registros e caminhos fisicos antigos, que
podem divergir dos arquivos MOVE ja recuperados. Se a recuperacao integral dos
bancos de sistema for realmente necessaria, planejar a sequencia DBA antes de
restore-sql, com outro destino vazio e verificacao dos caminhos de cada banco.

Conferir e repor somente o estado administrativo necessario: logins/SIDs e
permissoes, jobs, agendas, configuracao e dependencias de criptografia. Os cinco
jobs encontrados na origem estavam sem agenda e o SQL Agent estava parado;
nao liga-los automaticamente nem presumir que eram rotinas de backup.
Manter backups de sistema para recuperacao assistida/comparacao. Se houver
estado necessario nao recuperado, o aceite de 100% permanece bloqueado.

Antes de ligar processadores:

- Conferir conexoes internas; nenhum app de teste pode escrever no SQL antigo.
- Conferir ProcessingScope e contratos; impedir clientes/debug antigos de
  consumir registros do ambiente novo sem intencao.
- Reconciliar publicacoes YouTube com IDs/sessoes capturadas; nao iniciar upload
  duplicado para provar que o canal foi recuperado.
- Reconciliar documentos/eventos SEFAZ emitidos depois do ponto do backup.
  Recuperacao de banco nao desfaz autorizacao/cancelamento externo.
- Conferir Inbox/Outbox, mensagens RabbitMQ, reservas e locks; manter Workers e
  renderer parados ate decidir o que pode retomar. Nunca purgar fila por padrao.
- Conferir certificados, fotos, XMLs, musicas, publicacoes e documentos vinculados.
- Conferir Nginx com nginx -t antes de expo-lo. Usar acesso de ensaio por hosts
  local/tunel, com o dominio correto, mantendo DNS publico original.

Os modelos privados playsis-*.json estao no conjunto. Depois da revisao,
o operador usa docker compose --project-name PROJETO -f CAMINHO_DO_MODELO start
com a lista EXPLICITA de servicos liberados. Nao usar start geral antes da
reconciliacao. Todos os restart policies estao em no durante o ensaio.

## 7. Aceite, Retencao E Retorno Ao Deploy

O aceite deve comprovar login da Central, entrada nos cinco aplicativos,
consultas e edicao controlada, fotos/cofre Memorias, XML/certificado Fiscal,
uploads Clinica/APS, saga/filas, Front Central nas duas replicas e telemetria.
CHECKDB e health HTTP sozinhos nao aprovam esses fluxos.

Registrar SetId, snapshot completo, maquina nova, tempos de copia/restore,
checksums, resultados e excecoes. Nenhuma flag de sucesso e inferida por
healthcheck. Antes de afirmar recuperacao total, fechar tambem a revisao de
estado SQL, volumes de apps inativos e arquivos fora das areas conhecidas.

So depois do aceite copiar o recibo administrativo accepted-recovery.json
para /root/YeshuaBackup na origem, privado, contendo snapshot_id e
functional_recovery_accepted: true. A retencao continua simulacao por padrao:

```bash
sudo python3 -B infra/backups/backup.py retention
```

Aplicacao da retencao exige --kind sql|files|coordinated, --apply --snapshot
ID_ACEITO e recibo correspondente. Cada perfil e selecionado separadamente.
O operador recusa remover o snapshot aceito, aplica somente os IDs simulados e
nao faz prune. cleanup-staging --set CAMINHO simula descarte da preparacao local;
--apply exige que ESSE snapshot tenha sido restaurado e aceito, alem do recibo
de upload e manifest externo correspondente. Nao remove dados de negocio,
cofres, SQL cru, volumes nem imagens. Limpeza de arquivos volateis nao e
automatizada; nao apagar a unica copia local antes de provar a externa.
Nao aplicar lifecycle de objetos
que apague blocos vivos do Restic.

Antes do deploy comum no recuperado, revisar a branch/revisao recuperada, o
origin Git (inicialmente aponta para o bundle local), o arquivo de credenciais,
IPs, dominio, firewall e politica de restart. Somente entao voltar aos Compose
normais e ao deploy existente, preservando os binds/dados restaurados. Essa
publicacao e deliberada; nao faz parte do restore. DNS e desligamento da VPS
antiga so entram depois de aceite e plano de corte, nunca automaticamente.

## Referencias Tecnicas

- [BACKUP DATABASE e checksum](https://learn.microsoft.com/en-us/sql/t-sql/statements/backup-transact-sql?view=sql-server-ver16).
- [Limites de RESTORE VERIFYONLY](https://learn.microsoft.com/en-us/sql/t-sql/statements/restore-statements-verifyonly-transact-sql?view=sql-server-ver16).
- [Restaurar bancos de sistema](https://learn.microsoft.com/en-us/sql/relational-databases/backup-restore/restore-system-databases-sql-server?view=sql-server-ver16).
- [Backup e recuperacao RabbitMQ](https://www.rabbitmq.com/docs/backup).
- [Recuperacao Restic](https://restic.readthedocs.io/en/stable/050_restore.html).
- [Retencao e agrupamento Restic](https://restic.readthedocs.io/en/stable/060_forget.html).
