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

Revisao de 2026-10-20 por solicitacao do usuario: salvo as decisoes confirmadas
na secao 0, as classificacoes abaixo sao PROPOSTAS a discutir item por item.
A correcao imediata retira das novas capturas somente volatile/** e
persistent/memorias/publicacoes/*/.render-*/** de /root/YeshuaStorage.
Os demais grupos ficam como estao ate revisao. Nao apagar origens, snapshots
antigos ou executar prune nesta etapa.

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
- A decisao dos bancos de aplicativos nao classifica por consequencia bancos
  de sistema ou legados sem aplicativo identificado. Esses itens seguem na revisao.
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
  persistente. O worker consultado devolve o texto pela fila, sem gravacao
  identificada em TranscriptionsOutput; audio baixado e WAV sao temporarios.
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

### 0.2 Atividades Da Reforma

DECISAO POSTERIOR DO USUARIO: recriar o ambiente Yeshua do zero, inclusive
bancos/dados e conexoes YouTube atuais, sem obrigacao de migrar/preservar o
acervo de testes. Essa autorizacao pontual substitui a exigencia de preservar
o cofre nesta transicao. Nao muda a politica futura: bancos/persistente continuam
protegidos e deploy normal nunca limpa dados. Nao inclui fontes, sistema
operacional, acesso administrativo, recursos de terceiros ou canais/videos
publicados no Google. A limpeza depende do inventario e do caminho de recriacao
conferidos, para nao remover um recurso fora do escopo.

PONTO DE RETOMADA: concluir a reinstalacao limpa e testar um novo backup; a
revisao das categorias ainda nao classificadas e as investigacoes permanecem
separadas. Nao implementar cobranca nem agendar limpeza generica por esta decisao.

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

Os temporarios de transcricao continuam no /tmp descartavel do container, sem
volume persistente e sem backup. A aplicacao limpa sua propria tentativa tanto
no sucesso quanto em falhas de download, FFmpeg e transcricao; isso nao e uma
rotina generica de limpeza por idade/tamanho nem apaga o audio original.

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
- [ ] Concluir com o usuario a classificacao dos demais itens, um por vez.
- [ ] Investigar DocsInput da Clinica antes de classificar: identificar uso real,
  escritores/leitores, conteudo e referencias; conferir docs/Docs no ambiente.
  Usuario nao recorda a finalidade. Nao mover, excluir nem mudar a selecao por suposicao.
- [ ] Investigar tambem DocsOutput da Clinica, por decisao posterior do usuario:
  identificar finalidade, uso e conteudo antes de classificar; sem alteracao agora.
- [ ] Incluir a pasta legada persistent/Docs (D maiusculo) na mesma investigacao,
  confirmado pelo usuario; nao presumir que e equivalente a persistent/docs no Linux.
- [x] Direcionar novos uploads de fotos do Memorias a StorageLocation volatil.
- [ ] Executar a reinstalacao limpa dos recursos Yeshua da VPS, conforme a
  autorizacao posterior, sem migrar dados/cofre antigos e sem atingir terceiros.
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
- [ ] Conferir a instalacao inicial e a rotina publicada depois das alteracoes;
  nao declarar estas atividades concluidas apenas pelo planejamento.
- [ ] Planejar preservacao paga de fotos por tenant inteiro ou por usuario
  dentro de um tenant, conforme a pendencia 0.4; nao implementar cobranca agora.
- [x] Direcionar novos videos MP4 locais do Memorias a StorageLocation volatil.
- [x] Direcionar novos manifestos de renderizacao do Memorias a StorageLocation volatil
  e tratar sua ausencia no fluxo da aplicacao.
- [x] Direcionar trilhas padrao do Memorias a StorageLocation volatil e garantir
  reposicao a partir dos arquivos versionados quando necessario, com verificacao de hash.
- [ ] Planejar a task de limpeza de volatil por tempo e/ou tamanho atingido,
  com tratamento especifico de cada aplicacao, conforme a pendencia 0.5.
- [ ] Conferir o tratamento de audio original ausente na Clinica e a liberacao
  para limpeza, protegendo uploads/transcricoes ainda em andamento.
- [ ] Investigar o uso da rota /upload da Clinica, que recebe audio e grava em
  uploads fora de StorageLocation. Adequar ao caminho volatil padrao se usada,
  ou remover a rota se comprovadamente obsoleta; nenhuma remocao nesta revisao.
- [ ] Fazer a mesma investigacao/adequacao da rota /upload do APS, que tambem
  recebe audio e grava em uploads fora de StorageLocation; remover so se obsoleta.
- [ ] Alinhar os temporarios do worker de transcricao ao contrato de storage
  volatil e limpeza da aplicacao; conferir se TranscriptionsOutput ainda e necessario.
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

### 0.5 Pendencia: Limpeza E Tratamento Dos Dados Volateis

Abrir trabalho posterior para limpeza por tempo de permanencia e/ou limite
de tamanho ocupado. Prazos, limites, escopo e ordem de remocao ainda serao
definidos; nao habilitar agendamento nem exclusao nesta revisao.

Cada aplicacao deve definir o tratamento de seus dados volateis: quando um
arquivo esta em uso ou pode ser descartado; e o que acontece se ele faltar
antes, durante ou depois do processamento. Reenvio, regeneracao quando houver
insumos e aviso de indisponibilidade sao decisoes do fluxo da aplicacao,
nao suposicoes de uma rotina generica de infraestrutura.

A rotina de limpeza respeitara esse contrato, nao tocara em persistente e
preservara as restricoes de acesso de volateis sensiveis. Nao apagara arquivo
apenas por mtime ou por pressao de disco sem considerar uso/estado da aplicacao.
Simular candidatos e testar os limites
antes de ativar. Limpeza de volatil e independente da rotina de backup.

Videos MP4 locais do Memorias permanecem volateis mesmo com contratacao paga.
Manifestos manifest.json tambem foram confirmados como volateis. Nao inferir
a classificacao de outros arquivos desconhecidos somente por compartilharem a pasta.

Status: PENDENTE DE PLANEJAMENTO E IMPLEMENTACAO. Nenhum dado foi apagado.

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
| DB_SQL_SYSTEM | master, msdb, model quando aplicaveis | SQL_ESSENCIAL, roteiro proprio | Metadados de instancia, SIDs, logins, jobs e chaves; compatibilidade de restore especifica |
| DB_LEGADOS | Context_CLINICA e outros bancos encontrados | SEM_CLASSIFICACAO ate inventario | Nao excluir por nao aparecerem no deploy.env; identificar uso, dono e necessidade |
| DB_LEITURA_FUTURO | Eventual banco separado de leitura de aplicativo | PERSISTENTE | A regra de todos os bancos dos aplicativos tambem cobre novas bases de leitura; nao presumir exclusao por replay |

Toda tabela do banco entra: tabelas Y, negocio, Saga/Step, Inbox/Outbox,
idempotencia, sequencias e ledgers. Nao excluir essas tabelas como se fossem
cache. tempdb e recriado pelo SQL e nao entra na rotina de backup.

Replicacao nao substitui backup. Dois bancos contendo a mesma exclusao
acidental nao oferecem um ponto anterior recuperavel.

### 4.2 Arquivos De Negocio

| ID | Origem ou localizador atual | Politica proposta | Decisao de recuperacao |
| --- | --- | --- | --- |
| MEMORIAS_FOTOS | /root/YeshuaStorage/persistent/memorias/photos (destino atual a corrigir) | VOLATIL por padrao, confirmado | Direcionar a StorageLocation volatil; preservacao paga por tenant/usuario fica na pendencia 0.4, nao implementada |
| MEMORIAS_VIDEOS_LOCAIS | /root/YeshuaStorage/persistent/memorias/publicacoes/{id}/video.mp4 (destino atual a corrigir) | SEMPRE VOLATIL, confirmado | Sem preservacao paga; direcionar via StorageLocation a volatil e tratar ausencia/limpeza na aplicacao |
| MEMORIAS_PUBLICACOES | /root/YeshuaStorage/persistent/memorias/publicacoes/{id}/manifest.json (destino atual a corrigir) | VOLATIL, confirmado | Instrucoes de renderizacao para o Python; direcionar via StorageLocation e tratar ausencia na aplicacao; .render-* tambem volatil |
| MEMORIAS_MUSICAS | /root/YeshuaStorage/persistent/memorias/music (destino atual a corrigir) | Trilhas padrao versionadas VOLATEIS, confirmado | Repor do Git/deploy com hash; eventuais arquivos nao versionados exigem identificacao/classificacao propria |
| CLINICA_DOCUMENTOS_ENTRADA | /root/YeshuaStorage/persistent/docs/input | PENDENTE DE INVESTIGACAO, por decisao do usuario | Localizacao declarada/configurada, sem fluxo identificado na conferencia do codigo; confirmar finalidade e conteudo antes de decidir persistente/volatil |
| CLINICA_DOCUMENTOS_SAIDA | /root/YeshuaStorage/persistent/docs/output | PENDENTE DE INVESTIGACAO, por decisao do usuario | Confirmar finalidade, uso e conteudo antes de decidir persistente/volatil; nenhuma alteracao agora |
| DOCUMENTOS_LEGADOS | /root/YeshuaStorage/persistent/Docs/input e output | PENDENTE DE INVESTIGACAO, confirmado pelo usuario | Conferir junto com DocsInput/DocsOutput; bootstrap cria Docs maiusculo, distinto de docs no Linux; vazio no inventario anterior |
| CLINICA_AUDIO_ORIGINAL | /root/YeshuaStorage/volatile/ia/transcriptions/input | VOLATIL, confirmado individualmente | Ja usa StorageLocation.Volatile.TranscriptionsInput; tratar ausencia/reenvio e limpeza na aplicacao; nenhuma exclusao da origem nesta revisao |
| CLINICA_TRANSCRICAO_ARQUIVOS | /root/YeshuaStorage/volatile/ia/transcriptions/output; temporarios do worker | VOLATIL, confirmado individualmente | Texto retornado pela fila e salvo no banco permanece persistente; sem gravacao identificada nessa pasta no worker consultado; conferir necessidade da localizacao e tratar temporarios |
| CLINICA_RELATORIOS_ENTRADA | /root/YeshuaStorage/volatile/reports/input | VOLATIL, confirmado individualmente | Manter classificacao existente, por decisao do usuario; origem/uso nao comprovados no codigo conferido; nenhuma limpeza ativada |
| CLINICA_RELATORIOS_SAIDA | /root/YeshuaStorage/volatile/reports/output | VOLATIL pela regra confirmada | Area ja volatil permanece volatil; tratamento de ausencia/limpeza pertence a aplicacao; nenhuma limpeza ativada |
| FISCAL_PLANOS | /root/YeshuaStorage/fiscal/planos-emissao (destino atual a corrigir) | VOLATIL, confirmado | Direcionar via StorageLocation e tratar ausencia no processamento, sem backup por padrao |
| FISCAL_XML | /root/YeshuaStorage/sefaz (destino atual a corrigir) | VOLATIL por padrao, confirmado | XMLs assinados/retornos incluidos; consulta banco -> SEFAZ e guarda persistente paga a planejar na secao 0.7 |
| CLINICA_UPLOAD_LOCAL | Diretorio de trabalho da API + uploads | Audios VOLATEIS, confirmado | Rota /upload recebe audio e grava fora de StorageLocation; investigar uso e adequar ao caminho padrao ou remover se obsoleta; nenhuma exclusao agora |
| APS_UPLOAD_LOCAL | Diretorio de trabalho da API + uploads | Audios VOLATEIS, confirmado | Rota /upload recebe campo audio e grava fora de StorageLocation; investigar uso e adequar ao padrao ou remover se obsoleta; nenhuma exclusao agora |
| ANEXOS_NAO_CATALOGADOS | Qualquer StorageKey, caminho local, bucket ou provider encontrado | SEM_CLASSIFICACAO | Relacionar referencias SQL com destinos efetivos; nao supor que a lista de pastas esgota os arquivos |

As duas rotas /upload existem no codigo customizado de API e recebem audio.
Esses uploads foram classificados pelo usuario como volateis. Precisamos
confirmar o uso das rotas antes de adequar a StorageLocation ou remover se
obsoletas. Essa decisao nao autoriza excluir outros arquivos desconhecidos
encontrados no container nem modifica agora a captura coordenada existente.

Classificacao conservadora nao exige copiar uma pasta inexistente nem torna
um caminho obrigatorio em todo app. O inventario registra a area como presente,
ausente justificada ou lacuna. Ausencia inesperada de area em uso reprova o
conjunto; caminho legado comprovadamente sem uso nao e inventado no servidor.

### 4.3 Segredos, Chaves E Identidades De Recuperacao

| ID | Origem ou localizador | Politica | Dependencia critica |
| --- | --- | --- | --- |
| MEMORIAS_COFRE | Apps.Memorias.PrivateRoot/accounts, atualmente /root/YeshuaMemoriasSecrets/accounts | SEGREDOS_ESSENCIAIS | Resolver bind privado; preservar conexoes, configuracao OAuth cifrada, sessoes, recibos e chaves |
| MEMORIAS_CONFIG_CIFRADA | accounts/configuration/<hash-do-escopo>/oauth.bin e key.bin | SEGREDOS_ESSENCIAIS | Configuracao salva pela interface pode prevalecer sobre bootstrap.json; restaurar par correspondente |
| MEMORIAS_UPLOAD_STATE | accounts/<escopo>/tenants/.../upload-*.bin | SEGREDOS_ESSENCIAIS | Sessao/recibo vinculado ao mesmo video, destino, hash e publicacao; evitar upload duplicado |
| MEMORIAS_OAUTH_PENDING | authorization-*.bin no cofre | SEGREDOS_ESSENCIAIS na captura do cofre | Estado transitorio com validade; restore nao ressuscita autorizacao expirada |
| FISCAL_CERTIFICADOS | /root/YeshuaPrivate/production/apps/Fiscal/tenants/<Id>/titulares/<Documento>/certificados/<Thumbprint> | PERSISTENTE, confirmado | Certificado PFX e senha.secret com acesso restrito; alinhar StorageLocation na reforma, sem exposicao publica |
| CONFIG_PRIVADA | /root/YeshuaPrivate/production/credentials.json | SEGREDOS_ESSENCIAIS | Fonte tecnica unica por ambiente; Shared/Apps, root 0600, fora do Git e das imagens |
| INTEGRACOES_PRIVADAS | /root/YeshuaPrivate/production/apps/Memorias/integracoes/youtube/bootstrap.json e shared/OperationalAgent/integracoes/providers.json | SEGREDOS_ESSENCIAIS quando usados | Integracoes dos respectivos consumidores, opcionais; nao substituir o cofre Memorias por bootstrap vazio |
| CONFIG_PRIVADA_LEGADA | /root/YeshuaDB/persistent/config e /root/YeshuaStorage/fiscal/certificados | Inventariar legado sem adocao implicita | Nao sao o destino atual de novas credenciais; confirmar uso, sem migracao ou exclusao automatica |
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
