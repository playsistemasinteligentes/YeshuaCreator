# Mapa De Dados, Areas E Politicas De Backup Yeshua

Data: 2026-10-17.

Revisao alinhada ao plano operacional v3, atualizada em 2026-10-19: padrao
privado por diretorio e permissoes, sem exigir criptografia local adicional.

Status: proposta de organizacao, ainda sem implantacao. O mapa descreve o que
foi identificado no repositorio e as decisoes sugeridas. Nao confirma o estado
do servidor, nao cria diretorios, nao configura backup e nao adiciona DSL.

O procedimento de captura, checagem e restauracao esta no
[plano operacional](PLANO_BACKUP_RESTAURACAO_YESHUA.md). Este mapa concentra a
selecao dos dados e a associacao com politicas reutilizaveis. Ele e o mapa de
adesao ao plano: nao gera um job por item e nao substitui o roteiro operacional.

Prioridade anterior a essas rotinas: executar e validar a
[centralizacao de credenciais](PLANO_ETAPA_1_CENTRALIZACAO_CREDENCIAIS_YESHUA.md),
com arquivo privado, acesso restrito e deploy/redeploy funcionando. Este
inventario permanece como planejamento de backup posterior a esse aceite.

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

| Politica proposta | Nivel | O que recebe | Protecao herdada |
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
| DB_CENTRAL | YESHUA_CENTRAL | SQL_ESSENCIAL | Tenants, usuarios, concessoes, sequencias globais, historico de autorizacao e migrations |
| DB_CLINICA | YESHUA_CLINICA | SQL_ESSENCIAL | Dados clinicos/financeiros, uploads, sagas; relacionar documentos e audios |
| DB_APS_ADM | YESHUA_APS_ADM | SQL_ESSENCIAL | Pedidos, cargas, snapshots, sagas e contratos com Fiscal; confirmar anexos externos |
| DB_FISCAL | YESHUA_FISCAL | SQL_ESSENCIAL | Documentos/protocolos, planos, XMLs, certificados e efeitos ja ocorridos na SEFAZ |
| DB_MEMORIAS | YESHUA_MEMORIAS | SQL_ESSENCIAL | Albuns, fotos, publicacoes e canais; depende de arquivos e cofre corretos |
| DB_OPERATIONAL_INTELLIGENCE | YESHUA_OPERATIONAL_INTELLIGENCE | SQL_ESSENCIAL inicialmente | Parte do indice pode ser reconstruida; preservar ate comprovar o que nao e regeneravel |
| DB_SQL_SYSTEM | master, msdb, model quando aplicaveis | SQL_ESSENCIAL, roteiro proprio | Metadados de instancia, SIDs, logins, jobs e chaves; compatibilidade de restore especifica |
| DB_LEGADOS | Context_CLINICA e outros bancos encontrados | SEM_CLASSIFICACAO ate inventario | Nao excluir por nao aparecerem no deploy.env; identificar uso, dono e necessidade |
| DB_LEITURA_FUTURO | Eventual banco separado de leitura | SQL_ESSENCIAL por padrao | So mudar para RECONSTRUIVEL apos provar replay completo, origem disponivel e tempo de recuperacao |

Toda tabela do banco entra: tabelas Y, negocio, Saga/Step, Inbox/Outbox,
idempotencia, sequencias e ledgers. Nao excluir essas tabelas como se fossem
cache. tempdb e recriado pelo SQL e nao entra na rotina de backup.

Replicacao nao substitui backup. Dois bancos contendo a mesma exclusao
acidental nao oferecem um ponto anterior recuperavel.

### 4.2 Arquivos De Negocio

| ID | Origem ou localizador atual | Politica proposta | Decisao de recuperacao |
| --- | --- | --- | --- |
| MEMORIAS_FOTOS | /root/YeshuaStorage/persistent/memorias/photos | ARQUIVOS_ESSENCIAIS | Originais e vinculos com yFileUpload/AlbumFoto; nao trocar por videos do YouTube |
| MEMORIAS_PUBLICACOES | /root/YeshuaStorage/persistent/memorias/publicacoes | ARQUIVOS_ESSENCIAIS | manifest.json, video.mp4 e artefatos finais usados pela saga/upload; preservar bytes/hash |
| MEMORIAS_MUSICAS | /root/YeshuaStorage/persistent/memorias/music | ARQUIVOS_ESSENCIAIS inicialmente | Versoes do Git podem virar RECONSTRUIVEL mediante hash e licenca; adicionais locais continuam protegidos |
| CLINICA_DOCUMENTOS | /root/YeshuaStorage/persistent/docs/input e output | ARQUIVOS_ESSENCIAIS | Configuracao usa docs minusculo; classificar conteudo e referencias reais |
| DOCUMENTOS_LEGADOS | /root/YeshuaStorage/persistent/Docs/input e output | ARQUIVOS_ESSENCIAIS inicialmente | Bootstrap usa Docs maiusculo; no Linux nao e a mesma pasta que docs |
| CLINICA_AUDIO_ORIGINAL | /root/YeshuaStorage/volatile/ia/transcriptions/input | ARQUIVOS_ESSENCIAIS inicialmente | Pode ser a unica gravacao; inclui partes necessarias de uploads aceitos ainda nao consolidados |
| CLINICA_TRANSCRICAO_ARQUIVOS | /root/YeshuaStorage/volatile/ia/transcriptions/output | ARQUIVOS_ESSENCIAIS inicialmente | Confirmar se resultado esta integralmente no SQL; so depois decidir se arquivo e reproduzivel |
| CLINICA_RELATORIOS_ENTRADA | /root/YeshuaStorage/volatile/reports/input | ARQUIVOS_ESSENCIAIS inicialmente | Entrada pode ser documento original; nao excluir por conter volatile |
| CLINICA_RELATORIOS_SAIDA | /root/YeshuaStorage/volatile/reports/output | ARQUIVOS_ESSENCIAIS inicialmente | Documento emitido/assinado/manual e essencial; somente derivado comprovado pode ser reconstruivel |
| FISCAL_PLANOS | /root/YeshuaStorage/fiscal/planos-emissao | ARQUIVOS_ESSENCIAIS | Snapshots/payloads referenciados pelas sagas; preservar junto do banco Fiscal |
| FISCAL_XML | /root/YeshuaStorage/sefaz | ARQUIVOS_ESSENCIAIS | XMLs e artefatos de comunicacao; considerar override YESHUA_SEFAZ_STORAGE_ROOT |
| CLINICA_UPLOAD_LOCAL | Diretorio de trabalho da API + uploads | ARQUIVOS_ESSENCIAIS se contiver originais; LACUNA | Rota /upload grava fora do storage configurado; Compose nao declara mount especifico |
| APS_UPLOAD_LOCAL | Diretorio de trabalho da API + uploads | ARQUIVOS_ESSENCIAIS se contiver originais; LACUNA | Mesma lacuna; APS nao declara volume de arquivos no Compose ativo |
| ANEXOS_NAO_CATALOGADOS | Qualquer StorageKey, caminho local, bucket ou provider encontrado | SEM_CLASSIFICACAO | Relacionar referencias SQL com destinos efetivos; nao supor que a lista de pastas esgota os arquivos |

As duas rotas /upload existem no codigo customizado de API. Precisamos
confirmar seu uso e os arquivos reais no servidor. Se houver dados somente na
camada gravavel do container, extrair e preservar antes de recriar o container.
Nao adiar a preservacao desses dados ate a futura fase de imagens Docker.

Classificacao conservadora nao exige copiar uma pasta inexistente nem torna
um caminho obrigatorio em todo app. O inventario registra a area como presente,
ausente justificada ou lacuna. Ausencia inesperada de area em uso reprova o
conjunto; caminho legado comprovadamente sem uso nao e inventado no servidor.

### 4.3 Segredos, Chaves E Identidades De Recuperacao

| ID | Origem ou localizador | Politica | Dependencia critica |
| --- | --- | --- | --- |
| MEMORIAS_COFRE | /root/YeshuaMemoriasSecrets/accounts | SEGREDOS_ESSENCIAIS | Conexoes, configuracao OAuth cifrada, sessoes de envio e recibos; preservar arvore e chaves |
| MEMORIAS_CONFIG_CIFRADA | accounts/configuration/<hash-do-escopo>/oauth.bin e key.bin | SEGREDOS_ESSENCIAIS | Configuracao salva pela interface pode prevalecer sobre .env; restaurar par correspondente |
| MEMORIAS_UPLOAD_STATE | accounts/<escopo>/tenants/.../upload-*.bin | SEGREDOS_ESSENCIAIS | Sessao/recibo vinculado ao mesmo video, destino, hash e publicacao; evitar upload duplicado |
| MEMORIAS_OAUTH_PENDING | authorization-*.bin no cofre | SEGREDOS_ESSENCIAIS na captura do cofre | Estado transitorio com validade; restore nao ressuscita autorizacao expirada |
| FISCAL_CERTIFICADOS | /root/YeshuaStorage/fiscal/certificados | SEGREDOS_ESSENCIAIS | PFX e senha.secret; preservar com referencias do banco, sem expor pelo gateway |
| CONFIG_PRIVADA | /root/YeshuaDB/persistent/config | SEGREDOS_ESSENCIAIS | module-auth.env, memorias-youtube.env e outros arquivos efetivamente usados pelo loader |
| CHAVES_HOSTS | Origem efetiva de JWT, autenticacao entre modulos, credenciais SQL/broker e provedores | SEGREDOS_ESSENCIAIS | Pode vir de ambiente ou arquivo externo; preservar fonte recuperavel sem imprimir valores |
| SQL_CRIPTOGRAFIA | Certificados/chaves de TDE ou backup cifrado, se existirem | SEGREDOS_ESSENCIAIS | Exportacao suportada e acesso em outra instancia; .bak sozinho pode ser inutilizavel |
| HTTPS_IDENTIDADE | /etc/letsencrypt | SEGREDOS_ESSENCIAIS | Chaves privadas, conta ACME, links, permissoes e renovacao; alternativa de reemissao documentada |
| BACKUP_RECUPERACAO | Credencial do destino externo e senha/chave do repositorio | SEGREDOS_ESSENCIAIS, custodia independente | Kit fora da VPS e fora do unico repositorio que ele desbloqueia |

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
| BROKER_DEFINICOES | Export de definicoes do RabbitMQ e versao/nodename pertinentes | CONFIGURACAO_ESSENCIAL | Topologia, usuarios e politicas; export restrito nao equivale a backup de mensagens |
| GRAFANA_CONFIG | Dashboards, alertas, datasources e alteracoes feitas pela interface | CONFIGURACAO_ESSENCIAL se nao estiverem em Git | Identificar armazenamento/export suportado; nao descartar junto do historico rotativo |
| TELEMETRIA_HISTORICO | /root/YeshuaDB/persistent/telemetry | EVIDENCIA_SELETIVA | Copia consistente de recortes; nao copiar diretorio ativo sem procedimento proprio |
| EVIDENCIAS_ENSAIOS | Manifestos de backup, resultados de checagem, hashes e provas de restore | CONFIGURACAO_ESSENCIAL | Guardar fora do servidor tambem; sem payloads/tokens; material sensivel com acesso restrito |
| CONJUNTOS_BACKUP | Staging local e snapshots externos a implantar | Preservar conforme politica de retencao do plano | .bak/.trn e arquivos selados alimentam a copia externa; nao incluir o repositorio/staging recursivamente no proprio backup |

### 4.5 Filas, Cache E Integracoes

| ID | Recurso | Tratamento proposto | Limite atual |
| --- | --- | --- | --- |
| BROKER_MENSAGENS | Mensagens prontas, nao confirmadas e em execucao | LACUNA: estrategia propria de recuperacao a aprovar | Compose nao declara volume do RabbitMQ; nao presumir reentrega apenas porque existe Outbox |
| REDIS_ESTADO | Conteudo Redis | RECONSTRUIVEL somente se uso exclusivo como cache comprovado | Se guardar unico job, sessao indispensavel ou dado de negocio, deixa de ser cache e precisa de protecao correspondente |
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
| AGENTE_AMBIENTE | operational-agent-workspace/codex/claude | RECONSTRUIVEL para ferramentas e autenticacao | Reautenticar; separar fontes/evidencias exclusivas antes de excluir volumes; nao arquivar sessao de agente indiscriminadamente |
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
| Configuracao privada | /root/YeshuaDB/persistent/config/<app> ou fonte privada existente | SEGREDOS_ESSENCIAIS |
| Cofre/certificado novo | /root/YeshuaPrivate/<ambiente>/<app>/<area> | SEGREDOS_ESSENCIAIS |
| Trabalho descartavel | /root/YeshuaWork/<ambiente>/<app>/<area> | TEMPORARIO |
| Reconstruivel | Area separada da origem essencial | RECONSTRUIVEL |

YeshuaPrivate e YeshuaWork sao convencoes propostas, nao pastas ja usadas.
Memorias pode continuar no cofre atual; Fiscal pode manter os paths atuais
ate uma migracao propria, validada com as referencias SQL. Nenhum movimento
de arquivos foi autorizado ou executado por este mapa.

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
Nova foto no Memorias -> area MEMORIAS_FOTOS -> politica ja existente
Novo video em publicacao -> MEMORIAS_PUBLICACOES -> politica ja existente
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
| FISCAL | DB_FISCAL, planos, XMLs, certificados e configuracao correspondente |
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
| Audios originais da Clinica | Proteger enquanto forem a unica origem | Politica de descarte do produto ainda nao definida; pasta volatile nao decide |
| Videos finais Memorias | Proteger junto da publicacao | Retomada pode depender de bytes/hash exatos; avaliar custo antes de qualquer exclusao |
| Musicas versionadas | Admitir reconstrucao somente das versoes verificadas | Preservar arquivos adicionais e versoes antigas ainda referenciadas |
| Relatorios e transcricoes | Essencial inicialmente; separar originais e derivados comprovados | Reprocessar IA ou gerar PDF de novo pode nao devolver o mesmo documento |
| Documentos Docs/docs | Inventariar ambos sem renomear agora | Diferenca concreta no Linux entre bootstrap e configuracao |
| Upload local em containers | Preservar se existir e depois apontar para area adequada | Hoje nao ha persistencia declarada correspondente |
| Mensagens RabbitMQ | Definir recuperacao e provar antes de prometer cobertura | Definicoes nao guardam mensagens; tarefa aceita pode nao estar mais na fila |
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
