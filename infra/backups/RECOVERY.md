# Roteiro De Recuperacao Em Novo Servidor

Status: implementacao disponivel para ensaio. Recuperacao real ainda nao provada.
Nenhum comando deste roteiro foi executado para parar a VPS publicada.

INSTRUCAO ATUAL: limpeza e recriacao do servidor foram ADIADAS. Continuar apenas
a implementacao/testes locais; nao executar este roteiro na VPS nesta fase.

DECISAO POSTERIOR: o usuario autorizou descartar o estado atual do ambiente
Yeshua, inclusive bancos e conexoes YouTube, para uma instalacao limpa. Nao e
necessario migrar tokens/arquivos antigos nesta virada. A autorizacao e pontual:
nao torna o deploy normal destrutivo nem inclui sistema operacional, fontes,
acessos administrativos ou canais/videos publicados no Google. Reinstalar do
zero NAO comprova restore; gerar e validar uma nova base de backup depois da
reinstalacao, antes do futuro ensaio de recuperacao em outro servidor.

## Acesso Ao Storage SFTP

Atualizacao de 2026-10-23: a origem pode usar diretamente uma VPS separada de
storage, sem manter nova copia completa local. O JSON privado atualizado tem
Shared.Backup.Repository e Shared.Backup.Sftp com os caminhos de IdentityFile
e KnownHostsFile. Guardar esses dois arquivos junto com credentials.json em
local restrito FORA das VPSs, nunca somente dentro do repositorio cifrado.
Nao confundir a senha do Restic com senha SSH ou com a chave de transporte.

Antes de validar o backup no setup/restore, repor o JSON e os arquivos SSH nos
mesmos caminhos Linux, com dono root, diretorios 0700 e arquivos 0600.
Se o IP da nova origem mudou, um administrador precisa atualizar a restricao
from= da chave em /etc/ssh/authorized_keys/yeshua-backup no STORAGE.
Nao retirar a restricao nem desligar a verificacao de host para contornar erro.
Guardar tambem acesso administrativo independente ao storage, para autorizar
o IP novo ou emitir nova chave caso o acesso da origem tenha sido perdido.

O instalador valida o destino existente e nao cria repositorio local alternativo
em falha de rede/autenticacao. Nao reinicializar o destino que contem o historico.
A chave de recuperacao do Restic nao mudou durante a transicao. Recuperar
arquivos em pasta isolada e executar VERIFYONLY nao equivale a reconstruir
o ambiente inteiro: o ensaio funcional em servidor novo continua obrigatorio.

## Recuperar O Controlador

Na evolucao centralizada, guardar fora das duas VPSs tambem o credentials.json
DO STORAGE e as chaves/known_hosts do controlador. Esse JSON possui somente
senhas Restic por origem e configuracao operacional; nao precisa de senhas SQL.
O kit privado local 20261023-storage/controller contem essa copia. Chave SSH
de controle e chave de envio SFTP tem papeis opostos e nao sao intercambiaveis.

Reinstalar a Storage VPS com Linux/OpenSSH e Restic, recuperar o repositorio
sem reinicializa-lo e repor configuracoes/chaves privadas. Reconstituir as contas
SFTP/chroots pelo storage.py e o comando restrito da origem pelo source-access.
Conferir novos fingerprints e IPs por canal administrativo confiavel. Uma nova
instancia tem outro machine-id: revisar/revincular a identidade do controlador,
nao editar o JSON para fingir que a maquina antiga voltou. Transferencia para
outro controlador exige retirar a propriedade anterior na origem com operador,
apos parar suas agendas; nao ha transferencia automatica entre controladores.

Instalar com --role controller, testar probe e identidades e somente depois
habilitar agendas. Enquanto o controlador estiver ausente, a protecao SQL local
gera midias, mas arquivos novos nao tem entrega externa garantida. Acompanhar
espaco e idade do ultimo envio. Nunca apagar essas midias para liberar espaco
antes de conferir as cadeias e entregas. Restauracao de banco/arquivo continua
pelas acoes existentes, separada da instalacao limpa.

## Ciclo De Ensaio

Fechamento local de 2026-10-21. O proximo ciclo tem dois objetivos distintos;
nenhum deles autoriza apagar a VPS nesta etapa de preparacao.

### 1. Antes De Reinstalar

- Enviar ao Git as alteracoes verificadas e registrar a revisao. O setup obtem
  main; codigo apenas local nao chegara ao servidor. Nao publicar segredos.
- Conferir acesso administrativo/console do provedor e a copia privada local
  do credentials.json. O arquivo nao cria usuario SSH nem configura o provedor.
- Para descartar o cofre antigo do Memorias, retirar somente o override
  Apps.Memorias.PrivateRoot de uma COPIA do JSON. Manter o original intacto.
  O setup usa a raiz padrao apps/Memorias e o canal sera reconectado depois.
  Nunca retirar o override quando a intencao for recuperar aquele cofre.
- A copia original e a copia para servidor vazio estao fora do Git em
  %USERPROFILE%/.yeshua/private/production/<data-hora>/, com acesso restrito.
  credentials-new-server.json preserva senhas/chaves; nao e rotacao de segredos.
  Conferir host/nome dos bancos/conexoes caso o endereco do servidor mude.
- A copia de credenciais nao contem os dados SQL, o cofre YouTube ou o
  repositorio Restic. A primeira instalacao limpa descarta esses dados antigos,
  conforme a decisao do usuario; nao anunciar recuperacao deles.

### 2. Instalar E Usar

No servidor vazio, executar o setup documentado em ../README.md. Na espera
inicial, transferir a copia escolhida como
/root/YeshuaPrivate/production/credentials.json: pasta 0700, arquivo 0600,
proprietario root. Confirmar PRONTO; depois guardar a senha do backup quando
o terminal privado solicitar EXIBIR/GUARDEI. Nao colar segredos no chat/logs.
O setup segue o mesmo caminho, sem modo paralelo de instalacao/restauracao.

Conferir SQL/acessos, migrations, Central com duas replicas de front, APIs,
Workers, renderer e Nginx HTTP. Testar login/entrada nos aplicativos e criar
dados identificaveis de teste. O setup unico ja chama setup-cert.sh e confere
HTTP/status; quando o HTTPS configura, verifica tambem o certificado. Se falhar,
conclui em HTTP com HTTPS PENDENTE desde que HTTP/backup estejam validos: o DNS
pode ser ajustado depois, repetindo o MESMO comando publico do setup. Nao e
necessario alternar etapas/comandos HTTP e HTTPS. Acesso HTTP por IP nao protege
credenciais/dados em transito; usar acesso protegido para os testes. Conferir
firewall/DNS para emitir e renovacao antes de expor dados. Personalizacoes devem vir do Git.

O setup conclui full/diferencial/logs/arquivos/leitura integral iniciais e habilita
as seis agendas somente depois das provas exigidas. Conferir status,
sql-restore-plan e ausencia de falhas mais novas. O primeiro backup pode conter
apenas a base recem-criada: depois de usar, gerar novas capturas dos dados de
teste. Um resultado completed nao comprova restauracao funcional.

### 3. Provar Recuperacao Antes Do Segundo Descarte

Levar o repositorio cifrado para FORA do servidor de origem, juntamente com os
IDs completos dos snapshots escolhidos e a revisao do software. Guardar a senha
separadamente, em local restrito. O provedor externo definitivo segue pendente;
uma copia temporaria fora da VPS precisa ser completa, legivel e verificada.
Nao copiar um repositorio em alteracao sem coordenar os jobs de backup.

Antes de apagar a origem de um ensaio, comprovar dessa copia externa o acesso
ao repositorio, a leitura dos dados e o download --verify dos snapshots exatos
SQL e arquivos. Ter somente a senha, um recibo ou um caminho local NAO basta.
Sem essa prova, nao ha segundo descarte. Outra VPS permite manter a origem ate
o aceite; usar a mesma VPS exige assumir a perda da origem apos essa checagem.

No destino, seguir a recuperacao de dados abaixo: kit fora dos destinos,
download verificado, restore-files, SQL isolado na versao compativel e
restore-sql-chain. Software volta do Git; acessos SQL voltam da declaracao
privada. Nao executar o setup completo sobre o SQL restaurado sem revisar
migrations e bloquear integracoes externas. O ensaio so termina apos conferir
os dados identificaveis, login, uso dos aplicativos e uma nova rodada de backup.

## Atualizacao: Restaurar Dados E Reconstruir Software

Esta secao prevalece sobre o roteiro historico de recuperacao rapida abaixo.
DECISAO POSTERIOR: HTTPS/Certbot (/etc/letsencrypt) e VOLATIL; recriar pelo
setup-cert.sh no servidor novo, com dominio acessivel para validacao e renovacao
conferida. Novas capturas locais v3 ja excluem HTTPS; conjuntos anteriores podem
inclui-lo e continuam legiveis. Nao excluir origem
ou snapshots antigos, nem reemitir/parar Nginx nesta revisao de classificacao.
Novas copias NAO incluem fontes, bundle Git, toolkit nem imagens Docker.
source.json identifica a revisao; alteracoes locais nao commitadas nao sao
recuperaveis por esse backup. Cofres/chaves presentes nas raizes privadas entram
na copia; isso nao exige migrar o acervo de testes na futura reinstalacao limpa.

No servidor novo: obter o fonte no Git/revisao publicada; instalar dependencias;
baixar e verificar os snapshots exatos SQL e arquivos em uma area de recuperacao;
repor credentials.json/cofres com suas permissoes originais; reconstruir as imagens;
subir SOMENTE SQL, isolado, na versao compativel; executar restore-sql-chain
conforme as guardas abaixo; repor integralmente os diretorios persistentes em
destinos vazios com restore-files; depois publicar APIs/Workers/front a partir do
Git, verificando migrations e mantendo saidas externas bloqueadas ate aceite.
Repor trilhas e outros assets recriaveis pelo deploy, nao pelo backup de dados.

Fotos/videos/manifestos/XMLs classificados como volateis NAO voltam. Seus registros
SQL podem voltar; a aplicacao informa ausencia/reenvio/nova publicacao. Recuperar
XML completo da SEFAZ ainda exige investigacao por servico e nao e garantia atual.

NAO executar setup.sh sobre SQL restaurado sem revisar a etapa de deploy/migrations.
O preparo automatico de um restore integral a partir de copias somente de dados
depende do ensaio no servidor novo; a classificacao foi encerrada em 2026-10-21.
prepare-server (modelo congelado/imagens exatas) atende conjuntos antigos e recusa
novos conjuntos data-only ANTES de alterar destinos. --include-images esta
desabilitado para novas capturas. Nao misturar o procedimento antigo com este.
As ferramentas SQL online e download --verify continuam utilizaveis; recuperacao
100% do ambiente permanece nao comprovada. Nao apontar DNS antes do aceite.

### Arquivos Persistentes: Plano E Aplicacao Assistida

O proprio backup.py agora possui restore-files para snapshots online kind=files.
Nao e outro instalador, nao altera rotas, nao executa migrations, nao inicia
containers e nao restaura SQL. Sem --apply, valida e apresenta o plano sem
criar destinos. --apply e uma operacao explicita somente no novo servidor.

O kit do operador deve ficar FORA dos destinos a restaurar, por exemplo em
/root/YeshuaRecovery/operator/credentials.json, com diretorio 0700/arquivo 0600.
Ele usa SchemaVersion=1, Shared.Backup (senha/repositorio/acesso) e
Apps.Memorias.PrivateRoot quando o ambiente capturado usava uma raiz fora do
padrao privado. Sem override, vale a mesma raiz apps/Memorias do deploy. O segredo
SQL nao e necessario para baixar/repor arquivos. Nao colocar esse kit em Git
nem preencher /root/YeshuaPrivate/production antes da reposicao: um destino
nao vazio e recusado. O repositorio local tambem precisa ter sido transportado
ou o destino externo configurado; caminho nao equivale a transferencia.

```bash
# SOMENTE no futuro ensaio autorizado, em servidor NOVO.
sudo python3 -B infra/backups/backup.py download \
  --file /root/YeshuaRecovery/operator/credentials.json \
  --snapshot ID_COMPLETO_64_CARACTERES_DO_SNAPSHOT_FILES \
  --target /root/YeshuaRecovery/files-ensaio

# Simulacao: nao grava nenhum dos destinos.
sudo python3 -B infra/backups/backup.py restore-files \
  --file /root/YeshuaRecovery/operator/credentials.json \
  --download-root /root/YeshuaRecovery/files-ensaio \
  --new-server-machine-id ID_EXATO_DO_NOVO_SERVIDOR

# Aplicacao explicita, depois de conferir o plano.
sudo python3 -B infra/backups/backup.py restore-files \
  --file /root/YeshuaRecovery/operator/credentials.json \
  --download-root /root/YeshuaRecovery/files-ensaio \
  --new-server-machine-id ID_EXATO_DO_NOVO_SERVIDOR --apply
```

Guardas: download Restic --verify com ID exato; recibo ligado a esta maquina;
identidade da origem diferente do destino; manifestos da selecao
persistent-roots-v3; raizes esperadas e hashes do conteudo/permissoes conferidos
apos download e apos copia. Inclui Storage/persistent, privado, cofre Memorias
quando separado, sem HTTPS/telemetria/volumes volateis. Snapshots antigos v2
continuam aceitos com HTTPS quando capturado. Raizes aninhadas sao repostas uma
vez. Nunca selecionar volatile, fontes, imagens ou SQL cru por esse caminho.
O layout privado padrao e /root/YeshuaPrivate/production; a raiz legada
/root/YeshuaMemoriasSecrets tambem e reconhecida quando configurada. Layout
diferente exige revisao explicita, nao um destino inferido de manifesto externo.

Todas as pastas de destino devem estar ausentes/vazias antes da primeira copia;
a maquina deve estar sem containers ativos, exceto o SQL de recuperacao, se
necessario. Exigir reserva de disco em cada filesystem e lock do deploy durante
a aplicacao. A copia preserva proprietarios, modos, atributos e links relativos
internos (inclusive live/archive do HTTPS). Links absolutos/externos, dispositivos
e outros arquivos especiais bloqueiam a operacao, sem exclusao silenciosa.

O recibo de arquivos e emitido somente apos todas as copias verificadas. Uma
falha pode deixar destinos PARCIALMENTE preenchidos; nada e apagado/desfeito
automaticamente e uma repeticao nao sobrescreve esses dados. Revisar o destino
antes de tentar novamente. O recibo nao certifica consistencia global nem uso
real dos aplicativos: restore_proven permanece false ate o ensaio completo.

Copias anteriores sem a nova identidade/metadata nao recebem um aceite de
restore-files por suposicao. O conteudo baixado fica disponivel para procedimento
assistido; nao ha remocao/migracao retroativa de snapshots. O instalador deve
gerar nova captura de arquivos e depois nova leitura integral antes de habilitar
as agendas com esta versao. Ele nao repete baselines SQL ja validos por isso.

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
   O setup pede EXIBIR no terminal privado e GUARDEI apos a guarda logo depois
   da validacao privada inicial, antes de atualizar o sistema/publicar apps.
   O install.py final reutiliza a confirmacao da mesma senha/repositorio/maquina,
   sem nova pergunta. A senha nao sai nos logs ou recibos. Para nova consulta
   explicita, ver recovery-key --show-recovery-key
   no README. A declaracao do operador nao comprova uma copia externa legivel;
   conferir sua utilizacao no ensaio sem depender da VPS original.
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

DECISAO CONFIRMADA: master/model/msdb e tempdb nao fazem parte do backup.
O usuario nao guarda dados necessarios nesses bancos e determina que os acessos
sejam criados na recriacao do servidor. Capturas anteriores podem conter .bak
de sistema; nao restaura-los por cima da instancia nova nem apaga-los agora.
A selecao atual exclui os quatro em novas capturas; Estudo e novos bancos de
usuario permanecem incluidos automaticamente.

O caminho da instalacao/restauracao deve provisionar logins, usuarios e permissoes
necessarios pela infraestrutura versionada, lendo credenciais do arquivo privado.
Conferir o vinculo dos usuarios aos logins na nova instancia apos restaurar os
bancos de aplicativos e antes de liberar seus hosts. Nao regenerar credenciais
ou substituir usuarios existentes indiscriminadamente. O helper comum esta
integrado ao setup e aos pontos apos migration/antes dos hosts somente durante
setup. Contas adicionais exigem Shared.SqlServer.Logins explicito; somente sa
nao exige declaracao nova. Conferir conexoes/declaracoes no arquivo privado.

```bash
# No servidor novo, apos SQL/privado restaurados e ANTES de ligar hosts.
sudo python3 -B infra/private/sql_access.py
```

Conta existente com senha divergente/desabilitada ou principal nao SQL exige
reconciliacao explicita. O helper nao gira senhas, remove usuarios, restaura
master nem concede roles inferidas. A prova real ainda esta pendente; nao
declarar recuperacao completa sem testar os acessos dos aplicativos.

Nao reconstruir jobs administrativos por simples presenca no inventario antigo:
os cinco jobs observados nao tinham agenda e SQL Agent estava parado. Requisitos
novos de instancia devem ser declarados na infraestrutura, nao depender de
configuracao manual ou de backups dos bancos de sistema.

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
