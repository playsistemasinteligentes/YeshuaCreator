# Plano Futuro: Backup SQL Local E Prova De Recuperacao

Data: 2026-10-19.

Status: planejamento posterior, adiado ate o aceite da
[centralizacao de credenciais](PLANO_ETAPA_1_CENTRALIZACAO_CREDENCIAIS_YESHUA.md).
Este documento nao e o primeiro passo. Verificacao estatica do repositorio;
nenhuma conexao com o SQL publicado, backup real, restore, instalacao, alteracao de credencial,
parada ou agendamento foi executado. Scripts desta etapa ainda nao existem.

## 1. Entrega Delimitada

Depois da centralizacao validada, o piloto podera gerar backups nativos e
comprovar que podem ser restaurados, antes de escolher onde guardar a copia externa. O SQL produz o
arquivo; nossa futura rotina somente coordena selecao, execucao e verificacao.

Um ensaio separado do Restic pode demonstrar criptografia e recuperacao local
com arquivos ficticios. Ele nao exige escolher provedor, conta de nuvem ou
destino definitivo, nem autoriza copiar todos os diretorios reais agora.

```text
Conferencia sem alterar servicos
    -> piloto SQL de um banco
    -> validacao do arquivo
    -> restore isolado e conferencia
    -> repetir sequencialmente nos demais bancos
    -> relatorio local, ainda sem protecao contra perda da VPS
```

Ficam fora desta entrega: envio externo, contratacao de storage, retencao com
exclusao automatica, cron/timer, mudancas no deploy, Nginx, DSL, migrations,
rotacao de senhas, recriacao de containers e backup de imagens Docker.

O [plano geral](PLANO_BACKUP_RESTAURACAO_YESHUA.md) continua definindo a protecao
completa. Esta etapa detalha o piloto P3 e os pre-requisitos correspondentes,
sem dispensar inventario e controle de acesso. O
[mapa de dados](MAPA_DADOS_AREAS_E_BACKUP_YESHUA.md) informa as outras origens.

## 2. Verificacao Ja Feita

| Item conferido | Resultado factual | O que ainda nao foi comprovado |
| --- | --- | --- |
| SQL no Compose Shared | Imagem declarada SQL Server 2022; container yeshua-sqlserver | Instancia efetiva, build, edicao e saude do servidor publicado |
| Persistencia SQL | /root/YeshuaDB/persistent/sql montado em /var/opt/mssql | Permissao de escrita e espaco disponivel na VPS |
| Bancos do deploy.env | Seis nomes definidos, relacionados abaixo | Existencia, estado, tamanho e recovery model dos bancos reais |
| Rotina de backup na infra atual | Nao localizada rotina SQL/Restic em infra pelos comandos de backup/restore pesquisados | Pode haver rotina fora do repositorio no servidor; inventariar antes de criar outra |
| Lock do deploy | /var/lock/yeshua-deploy.lock com flock | Ausencia de outros escritores/mantenedores que ignorem esse lock |
| Loader do deploy | Pode gerar chave de modulos se ela estiver ausente | Nao pode ser reutilizado como mero leitor pela rotina de backup |
| Bootstrap | Atualiza pacotes e termina disparando deploy | Nao e comando de preparacao do backup ou laboratorio de restore |
| Credenciais | Ainda ha valores fixos nos Compose e arquivos privados usados para outros segredos | Credencial apropriada para backup/validacao ainda precisa ser provisionada |
| Ferramentas nesta sessao Windows | sqlcmd localizado; docker e restic nao encontrados no PATH | Disponibilidade das ferramentas Linux na VPS e no laboratorio |

Essa verificacao e de fonte/configuracao, nao de producao. Nao foram lidos
valores de arquivos privados do servidor nem testadas credenciais contra ele.
Ausencia de uma ferramenta no PATH local nao comprova sua ausencia na VPS.

Catalogos esperados, usando os valores atuais de `infra/docker/deploy.env`:

- YESHUA_CENTRAL.
- YESHUA_CLINICA.
- YESHUA_APS_ADM.
- YESHUA_FISCAL.
- YESHUA_MEMORIAS.
- YESHUA_OPERATIONAL_INTELLIGENCE.

O futuro script le a configuracao efetiva, em vez de manter outra lista fixa.
Bancos adicionais/legados sao inventariados, nao apagados nem incluidos por
adivinhacao. master/msdb/model tambem entram no inventario, mas seu backup e
restore seguem procedimento proprio, fora do piloto de banco de aplicativo.

## 3. Preparacao Antes Do Piloto

1. Ler o estado real de SQL/container/mounts, sem reiniciar nada. Identificar
   versao/build, catalogos, tamanho, recovery model, backups e rotinas existentes.
   Conferir criptografia SQL/TDE e a disponibilidade dos certificados/chaves
   necessarios ao restore, se usados; nao alterar essa protecao para o piloto.
2. Conferir espaco para a copia completa e margem operacional, inclusive dados
   e logs em crescimento. Nao encher o disco real para testar essa verificacao.
3. Confirmar como executar sqlcmd: cliente Linux disponivel ou ferramenta de
   administracao aprovada. Nao pressupor path dentro da imagem nem instalar
   pacotes ou recriar SQL automaticamente para obter o cliente.
4. Provisionar acesso SQL por arquivo privado, sem nova camada de cifra local,
   conforme o padrao aprovado. Validar permissoes de backup e verificacao;
   nao presumir que permissao para gerar backup tambem autoriza VERIFYONLY.
   Nao conceder sysadmin automaticamente nem usar senha fixa no script.
5. Conferir UID/GID do SQL e permissoes somente no destino de backup. Nao usar
   chmod/chown recursivo sobre toda a arvore SQL/persistent.
6. Reservar periodo acompanhado para o piloto, com uma operacao SQL por vez.
   Medir duracao, CPU, memoria e I/O, sem prometer impacto zero nos aplicativos.
7. Separar o ambiente de restore. Preferir outra maquina/ambiente isolado;
   nao subir outro SQL na VPS publicada sem avaliar memoria e disco antes.

Nao carregar `load-deploy-env.sh` para descobrir configuracao: ele tem efeitos
de escrita. Ler somente as configuracoes necessarias ao backup, sem executar
bootstrap/deploy e sem criar chaves ou arquivos de aplicativos implicitamente.

Se houver banco em FULL sem manutencao de log, registrar e tratar essa lacuna
antes do agendamento. Full/COPY_ONLY nao substitui backup de log nem autoriza
trocar o recovery model, fazer shrink ou quebrar uma cadeia existente.

## 4. Onde Gerar A Copia Local

Para o piloto, usar uma subpasta do mount SQL ja existente, se as conferencias
de espaco/permissao aprovarem:

```text
SQL enxerga: /var/opt/mssql/backup/<SetId>/
Host enxerga: /root/YeshuaDB/persistent/sql/backup/<SetId>/
```

Os caminhos sao uma proposta, nao pastas criadas nesta tarefa. Isso permite
testar sem adicionar mount ou recriar container. SetId e nomes dos arquivos
sao unicos; nunca anexar a arquivo antigo nem sobrescrever a unica copia boa.

Essa pasta e restrita: .bak pode conter todos os dados do aplicativo. Ela nao
deve ser servida pelo Nginx, publicada no Git ou liberada a qualquer container.

A futura copia de arquivos seleciona explicitamente os backups SQL concluidos
e as outras areas persistentes. Nao copia a raiz SQL crua: MDF/LDF e outros
arquivos ativos nao se tornam backup por estarem dentro de persistent.
Nao aplicar uma exclusao que omita tambem os .bak sem perceber.

O backup continua no mesmo disco/servidor dos dados. Sua geracao e validacao
local nao protegem contra perda da VPS. Nao usar o estado COPIADO_EXTERNO nesta
etapa, nem anunciar que todo o ambiente ja esta protegido.

## 5. Execucao Planejada

### 5.1 Primeiro Banco

1. Escolher um banco piloto a partir do tamanho e capacidade reais; nao iniciar
   seis backups em paralelo. Registrar expressamente qual banco sera capturado.
2. Obter lock proprio de backup e impedir concorrencia com deploy durante a
   captura usando o lock existente. Espera deve ser limitada e falha visivel,
   sem matar deploy ou manter uma janela de manutencao bloqueada indefinidamente.
3. Gerar full nativo com COPY_ONLY, CHECKSUM e STOP_ON_ERROR em arquivo novo.
   COPY_ONLY e a escolha do piloto para nao alterar a base diferencial de uma
   rotina existente, conforme a
   [Microsoft](https://learn.microsoft.com/en-us/sql/relational-databases/backup-restore/copy-only-backups-sql-server?view=sql-server-ver16).
4. Medir o primeiro ciclo. Nao habilitar compressao nem paralelismo como
   suposta otimizacao automatica; compressao sera avaliada pelo impacto medido.
5. Executar RESTORE VERIFYONLY com CHECKSUM e STOP_ON_ERROR e conferir metadata
   do backup: banco esperado, tipo full, copia concluida e checksum presente.
6. Registrar nome, tamanho, horario, versao SQL, resultado e hash do arquivo
   fechado. Nao selecionar arquivo ainda sendo produzido para copia posterior.
7. Liberar locks e registrar resultado mesmo em falha. Arquivo incompleto nao
   recebe estado de copia valida nem e apagado por uma limpeza generica.

A autenticacao do cliente nao vai em argumento de senha, log ou relatorio.
Erros SQL devem virar falha da rotina, usando o tratamento apropriado do
cliente; nao considerar a mera existencia de um .bak como sucesso.
Validar nomes/localizadores antes de montar identificadores SQL e caminhos.

Se um limite de tempo for atingido, confirmar se a operacao SQL ainda esta
executando antes de repetir. Nao disparar outro backup automaticamente nem
reiniciar o SQL para encerrar o anterior.

SQL permite backup nativo online; isso nao exige parar todos os aplicativos
para um backup SQL isolado. Porem, fulls sequenciais com escritores ativos nao
representam um ponto coerente entre todos os bancos e arquivos. Esta etapa
registra expressamente SQL_ISOLADO, sem prometer recuperacao completa de sagas.

### 5.2 Prova De Restore

1. Usar instancia isolada com versao compativel, disco e volume distintos.
   Nunca montar /root/YeshuaDB/persistent/sql como dados do laboratorio.
2. Recuperar uma copia do .bak e conferir seu hash. Identificar arquivos
   logicos com FILELISTONLY e mapear os destinos exclusivos do laboratorio.
3. Restaurar com outro nome e paths, sem REPLACE, sem conexoes de aplicativos
   publicados, sem jobs e sem acesso a filas/SEFAZ/YouTube/callbacks de producao.
4. Executar DBCC CHECKDB no banco restaurado e conferir schema e registros
   conhecidos de forma restrita. Nao exportar payloads ou dados pessoais no
   relatorio de teste.
5. Registrar duracao, resultado e versao usados. VERIFYONLY verifica leitura
   do backup, mas nao substitui essa prova, como esclarece a
   [Microsoft](https://learn.microsoft.com/en-us/sql/t-sql/statements/restore-statements-verifyonly-transact-sql?view=sql-server-ver16).

A documentacao oficial descreve o
[restore em container separado](https://learn.microsoft.com/en-us/sql/linux/migrate/tutorial-restore-backup-sql-server-container?view=sql-server-ver16).
Nao executar seus exemplos contra os volumes/caminhos da producao.

### 5.3 Demais Bancos

Repetir a mesma rotina, sequencialmente, para os demais catalogos aprovados,
apos o piloto passar e sua carga ser aceitavel. Se faltar um banco esperado,
nao criar o banco nem rodar migration: reprovar a captura e explicar a ausencia.
Relatorio deve listar esperados, encontrados, capturados, verificados e
restaurados. Um banco aprovado nao certifica automaticamente os outros cinco.

## 6. Ensaio Local Do Restic, Sem Destino Externo

Esse ensaio pode ocorrer em uma maquina de teste, sem dados privados reais:

1. Criar arquivos ficticios representando persistente, privado e volatil,
   alem de uma pasta simulando dados SQL crus e outra contendo backup SQL.
2. Usar repositorio local cifrado separado das origens. Credencial de teste
   fora do Git; nao colocar o repositorio dentro da arvore que ele copia.
3. Demonstrar que persistente/privado e o backup SQL sao selecionados, e que
   volatil/SQL cru nao entram. Se usar um .bak real no ensaio, somente apos
   aprovar acesso, espaco e tratamento de dados desse laboratorio.
4. Alterar arquivos ficticios, criar novo snapshot e recuperar as duas versoes
   para destinos alternativos, conferindo bytes/hashes e arquivos ausentes.
5. Exercitar senha incorreta, arquivo ilegivel e falha de execucao sem mascarar
   erro. Conferir restauracao com a credencial recuperada fora do repositorio.

Restic possui modo simulacao e selecao/exclusao de origens na
[documentacao oficial](https://restic.readthedocs.io/en/stable/040_backup.html).
Isso valida o mecanismo antes de definir onde a copia externa ficara. Nao
validou conectividade externa, custo, credencial de provedor ou desastre real.

## 7. Matriz De Verificacao E Aceite

| Verificacao | Resultado exigido | Situacao nesta tarefa |
| --- | --- | --- |
| Inventario do repositorio | SQL, mount, seis catalogos e efeitos dos scripts identificados | Conferido estaticamente |
| Estado real da VPS | Build, catalogos, recovery models, espaco, ferramentas e credenciais confirmados | Pendente |
| Backup SQL piloto | Arquivo novo, operacao concluida, checksum e metadata corretos | Pendente |
| VERIFYONLY | Backup inteiramente legivel, sem erros ignorados | Pendente |
| Restore isolado | CHECKDB aprovado e consultas esperadas funcionando | Pendente |
| Ausencia de banco esperado | Falha clara, sem criar catalogo ou omitir silenciosamente | Cenario planejado |
| Credencial ausente/incorreta | Falha sem gerar senha substituta ou exibir valor | Cenario planejado |
| Diretorio sem permissao/espaco insuficiente | Interrupcao antes de prejudicar SQL; testar por simulacao/laboratorio | Cenario planejado |
| Duas execucoes/deploy concorrente | Segunda execucao aguarda ou falha conforme limite, sem executar junto | Cenario planejado |
| Arquivo truncado/corrompido | Verificacao falha; danificar somente copia descartavel no laboratorio | Cenario planejado |
| Restic local com fixtures | Selecao correta, versoes restauradas e credencial de recuperacao testada | Pendente |
| Expansao aos seis bancos | Resultado individual e restore comprovado para cada um | Pendente |

Saida esperada da futura rotina: SetId, escopo SQL_ISOLADO, bancos solicitados,
resultados individuais, arquivos, hashes, tempos e falhas sanitizadas. Nenhum
segredo no relatorio. Sem exclusao/retencao automatica no primeiro ciclo.

Aceite da etapa: gerar e recuperar os backups SQL selecionados e demonstrar
o fluxo local de arquivos. Qualquer prova nao executada permanece pendente.
Envio externo e protecao contra perda de servidor somente entram no proximo
passo; um diretorio cheio de .bak nao representa essa protecao.

## 8. Ordem Futura, Apos O Aceite Das Credenciais

1. Criar conferencia sem efeitos de escrita, com saida sanitizada.
2. Implementar uma pequena rotina SQL em infra/backups, com modo de conferencia
   como padrao e execucao manual explicita. Reutilizar configuracao de nomes e
   arquivos privados; nao carregar o deploy nem colocar backup nos aplicativos.
3. Exercitar falhas/simulacao antes do primeiro backup autorizado.
4. Executar piloto acompanhado e o restore isolado; somente entao ampliar.
5. Preparar ensaio local Restic e registrar provas. Ainda sem agenda ou limpeza.
6. Com esses resultados, decidir destino externo e completar a politica geral.

Nenhum desses scripts, pastas de servidor ou testes de producao foi criado
ou executado por este documento. A verificacao atual nao e autorizacao para
um script futuro fazer deploy, reiniciar SQL, alterar senhas ou restaurar por
cima de bancos existentes.
