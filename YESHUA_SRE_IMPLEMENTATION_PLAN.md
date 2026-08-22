# Plano De Implementacao SRE No Yeshua

## 1. Finalidade

Este documento traduz a especificacao externa
`OPERATIONAL_SUPPORT_ADOPTION_STANDARD.md` para a implementacao interna do
Yeshua.

A especificacao externa define o que um fabricante precisa entregar. Este
plano registra, para cada entrega:

- o que o requisito exige;
- o que ja existe no Yeshua;
- qual evidencia no repositorio comprova a afirmacao;
- qual lacuna permanece;
- quem deve implementar a lacuna;
- como a entrega sera aceita.

Este arquivo nao deve apresentar uma capacidade planejada como se estivesse
disponivel. Toda afirmacao usa um dos estados abaixo.

A linha de base foi avaliada no repositorio em 2026-08-21. Ela comprova a
existencia de codigo, nao a homologacao de um ambiente de producao.

| Estado | Significado |
| --- | --- |
| IMPLEMENTADO | Existe codigo utilizavel e evidencia verificavel |
| PARCIAL | Existe uma base real, mas o requisito ainda nao esta completo |
| NAO IMPLEMENTADO | Nao existe implementacao suficiente no repositorio |
| CONCEITO | Existe somente decisao, desenho ou requisito textual |

## 2. Linha De Base Factual

### 2.1 Capacidades Implementadas

- Engenharia reversa por manifesto para sistemas Yeshua e legados.
- Selecao fechada de solucao, projetos e diretorios.
- Snapshot versionado com conteudo integral dos fontes.
- Conteudo comprimido e deduplicado por SHA-256.
- Indice semantico C# por Roslyn.
- Indice textual complementar para DSL, JavaScript, TypeScript, HTML, Razor,
  Vue e SQL.
- Referencias de campos, classes, funcoes e cadeias de chamadas.
- Classificacao de fonte gerado, customizado, DSL, contrato, teste, regra de
  negocio e borda arquitetural.
- Historico de commits importado separadamente do snapshot.
- API de consulta por campo, classe e funcao.
- Orquestrador extensivel por `IContextCollector`.
- Contexto compacto e bundle com os fontes selecionados.
- Smoke tests CRUD gerados por aplicativo e ordenados por dependencias.
- Healthcheck de banco da API de Inteligencia Operacional.
- Modelo de infraestrutura capaz de renderizar healthchecks de containers.

### 2.2 Capacidades Parciais

- `TraceId` existe em HTTP, Worker e Receiver, mas nao representa o conjunto
  completo de identidades operacionais.
- `CorrelationId` existe em filas, Inbox, Outbox e Saga, mas nao ha um contrato
  unico de propagacao ponta a ponta.
- Receivers registram inicio, fim, duracao e excecao, mas nao produzem ainda o
  contrato D0/D1 completo.
- Workers registram inicio e falhas, mas nao registram uma narrativa causal
  padronizada.
- Healthchecks existem em partes da infraestrutura, mas nao formam um gate
  pos-build unico.
- A API operacional centraliza fontes estaticas, mas ainda nao coleta logs,
  metricas, traces, bancos operacionais ou servicos externos.

### 2.3 Capacidades Nao Implementadas

- Modelo runtime dos tres eixos independentes.
- `RootOperationId`, `OperationId`, `ExecutionId` e `CausationId` como contrato
  universal.
- Resultados tecnico e de negocio registrados separadamente.
- Politica D2 direcionada, temporaria e auditada.
- Classificacao e sanitizacao automatica de dados observaveis.
- Provider central de eventos operacionais consultavel por `OperationId`.
- Coletores de runtime na Inteligencia Operacional.
- Replay, Simulation e Regression baseados em capturas.
- Agentes operacionais autonomos.
- Deteccao preditiva baseada em comportamento runtime.

## 3. Divisao De Responsabilidades No Yeshua

### Engine

- Gerar o contrato e as bordas de instrumentacao.
- Gerar propagacao nos pontos padronizaveis de HTTP, fila, Worker, retry,
  Outbox e Saga.
- Gerar health endpoints, smoke tests e testes de propagacao.
- Gerar pontos de extensao para resultados e dados especificos.
- Nunca decidir regra de negocio especifica do aplicativo.

### Shared

- Conter contratos runtime genericos.
- Conter contexto operacional, relogio, gerador de IDs, sanitizacao basica e
  interfaces de publicacao.
- Conter implementacoes neutras quanto ao aplicativo.

### Studio E DSL

- Declarar operacoes relevantes e seus nomes de negocio.
- Declarar resultados de negocio conhecidos.
- Declarar classificacao de dados e campos proibidos quando isso fizer parte
  da especificacao do aplicativo.
- Declarar quais fluxos exigem D1, quais podem ativar D2 e quais cenarios sao
  candidatos a regressao.
- Permanecer pequena: detalhes de provider, armazenamento e deploy nao devem
  poluir a DSL de dominio.

### Aplicativo E IA/DEV

- Informar decisoes e resultados que somente a regra de negocio conhece.
- Sanitizar dados particulares que nao possam ser classificados pela Engine.
- Implementar coletores e integracoes especificas.
- Implementar corpos customizados de Replay ou Simulation quando houver
  efeitos particulares.

### Infraestrutura

- Hospedar providers de logs, metricas, traces e eventos.
- Configurar acesso, retencao, disponibilidade e auditoria.
- Executar o gate pos-build e preservar seus relatorios.

### Inteligencia Operacional

- Correlacionar evidencias runtime com o snapshot correto do fonte.
- Coordenar coletores.
- Produzir bundles de investigacao.
- Expor capacidades a pessoas, Codex e futuros agentes.
- Separar fatos, inferencias, hipoteses e recomendacoes.

## 4. Matriz Dos Passos De Implementacao

### Passo 1 - Definir Escopo E Responsaveis

**Entrega externa:** ficha de escopo, operacoes cobertas, ambientes,
responsaveis, restricoes e runbook.

**Yeshua hoje: PARCIAL**

- A especificacao externa e o plano de inteligencia registram o processo.
- Os aplicativos possuem DSL, mas nao existe um catalogo operacional
  homologavel com responsaveis e escopo fechado.

**Implementacao Yeshua:** criar um manifesto de homologacao por aplicativo,
separado da DSL de dominio, referenciando operacoes declaradas ou geradas.

**Aceite:** o manifesto identifica uma lista fechada de operacoes, ambiente,
responsaveis, restricoes e caminho do runbook.

### Passo 2 - Confirmar Fonte E Versao

**Entrega externa:** uma execucao deve apontar para uma versao confirmada e
indexada.

**Yeshua hoje: PARCIAL**

- `ReverseEngineeringManifest` recebe sistema, tipo, versao, solucao e projetos.
- `ReferenceSqlExporter` coleta o snapshot.
- `ReferenceSqlPublisher` publica fontes comprimidos e deduplicados.
- `GitHistoryImporter` importa historico de commits.
- A API consulta builds e devolve bundles da versao selecionada.
- O runtime dos aplicativos ainda nao expoe de forma padrao o commit/build que
  esta executando.

**Implementacao Yeshua:** gerar metadata imutavel no build e expor
`Application`, `Environment` e `Version` nos hosts, health endpoints e eventos
operacionais.

**Aceite:** um evento e o endpoint de saude informam uma versao existente no
indice e o hash do artefato corresponde ao build implantado.

### Passo 3 - Catalogar Operacoes

**Entrega externa:** catalogo de operacoes, entradas, etapas, dependencias e
resultados.

**Yeshua hoje: PARCIAL**

- A DSL e os artefatos gerados permitem inferir endpoints, Commands, Receivers,
  Workers, filas, Sagas e integracoes.
- O indice encontra simbolos e cadeias.
- Nao existe uma identidade operacional explicita para cada operacao nem um
  catalogo de resultados tecnicos e de negocio.

**Implementacao Yeshua:** a Engine deve gerar um catalogo inicial a partir da
DSL e dos hosts. IA/dev complementa etapas, dependencias e resultados que nao
sejam inferiveis.

**Aceite:** cada operacao homologada possui identificador estavel, entrada,
etapas, dependencias, resultados e eventos esperados.

### Passo 4 - Modelar Os Tres Eixos

**Entrega externa:** severidade, profundidade e modo variam de forma
independente.

**Yeshua hoje: CONCEITO**

- Os tres eixos estao definidos na especificacao.
- Nao existem tipos runtime nem persistencia desses eixos.

**Implementacao Yeshua:** criar tipos genericos `OperationalSeverity`,
`DiagnosticDepth` e `ExecutionMode`; a Engine deve inclui-los nos eventos sem
acoplar um eixo ao outro.

**Aceite:** testes combinam severidades diferentes com D0/D1/D2 e com Live,
Replay, Simulation e Regression sem alterar automaticamente os outros eixos.

### Passo 5 - Implementar Identidade E Propagacao

**Entrega externa:** operacao reconstruivel por IDs sincronamente e
assincronamente.

**Yeshua hoje: PARCIAL**

- `IExecutionContext.TraceId` existe em HTTP e Worker.
- Receiver base usa `TraceId` ao registrar inicio, fim e erro.
- Inbox, Outbox, fila e Saga possuem `CorrelationId`.
- Nao existem contratos universais para raiz, operacao, execucao e causa.
- Nao existem testes ponta a ponta de propagacao.

**Implementacao Yeshua:** evoluir o contexto gerado para
`RootOperationId`, `OperationId`, `ExecutionId` e `CausationId`; criar novo
`ExecutionId` por etapa/tentativa; propagar headers e envelopes de mensagem.

**Aceite:** um teste inicia por HTTP, atravessa Outbox, fila e Worker e recupera
todas as etapas pela mesma raiz e cadeia causal.

### Passo 6 - Implementar D0 E D1

**Entrega externa:** baseline consultavel de inicio, fim, resultado, etapas,
dependencias, duracao, retry e erro.

**Yeshua hoje: PARCIAL**

- `ReciverBase` mede duracao e registra inicio, conclusao/falha e excecao.
- Workers registram inicio e falhas.
- Os eventos nao carregam ainda versao, ambiente, tres eixos, resultados
  separados, dependencia ou classificacao de dados.

**Implementacao Yeshua:** a Engine deve envolver Commands, endpoints, Workers,
filas, repositorios e integracoes com emissores padronizados. IA/dev informa o
`BusinessOutcome` quando ele depender da regra.

**Aceite:** sucesso, rejeicao e falha produzem eventos D0/D1 completos e
consultaveis, sem exigir logs livres para reconstruir o fluxo.

### Passo 7 - Disponibilizar Evidencias

**Entrega externa:** consulta central, filtravel, auditada e sem acesso
administrativo ao servidor.

**Yeshua hoje: PARCIAL**

- A API de Inteligencia Operacional consulta o indice estatico.
- `OperationalContextOrchestrator` coordena coletores.
- Somente `SourceCodeContextCollector` esta implementado.
- Nao ha provider nem coletor de evidencias runtime.

**Implementacao Yeshua:** definir um provider inicial de eventos e adicionar
coletores de logs/eventos, metricas, traces, banco operacional e integracoes.
Implementar consulta por identidades, tres eixos, versao e janela de tempo.

**Aceite:** o suporte recupera uma operacao completa pela API sem entrar no
servidor, e a consulta fica auditada.

### Passo 8 - Integrar Runtime E Codigo

**Entrega externa:** uma falha deve levar aos fontes corretos da versao
executada.

**Yeshua hoje: PARCIAL**

- Snapshot, indice semantico, indice textual, classificacao, historico e bundle
  estao implementados.
- O perfil `BusinessRule` remove bordas, contratos, bases e testes.
- O perfil `ChangeImplementation` preserva propriedade e fonte da verdade.
- Falta receber a identidade runtime completa e selecionar automaticamente o
  build correspondente.

**Implementacao Yeshua:** criar um coletor runtime que transforme componente,
funcao, arquivo, linha, classes e campos em uma consulta ao build indicado pelo
evento.

**Aceite:** dado um `OperationId` com erro, a API seleciona a versao, produz o
bundle e aponta os fontes relevantes sem usar o disco atual como substituto.

### Passo 9 - Implementar D2 Direcionado

**Entrega externa:** diagnostico profundo com alvo, prazo, limite e auditoria.

**Yeshua hoje: NAO IMPLEMENTADO**

**Implementacao Yeshua:** criar `DiagnosticPolicy`, repositorio de politicas e
avaliador leve nos pontos gerados. A politica pode mirar aplicativo, operacao,
ID, componente ou janela e deve expirar automaticamente.

**Aceite:** uma politica captura D2 somente para o alvo, respeita campos e
volume autorizados, expira e deixa trilha de auditoria.

### Passo 10 - Classificar E Proteger Dados

**Entrega externa:** classificacao, mascaramento, NeverCapture, retencao e
teste de vazamento.

**Yeshua hoje: NAO IMPLEMENTADO**

**Implementacao Yeshua:** criar classificacao padrao nos tipos primitivos e
permitir declaracao complementar na DSL. O serializador operacional deve
aplicar mascaramento antes de entregar o evento ao provider.

**Aceite:** testes automatizados comprovam que senhas, tokens, certificados e
campos `NeverCapture` nunca aparecem em evento, erro, snapshot ou bundle.

### Passo 11 - Executar G1 A G7

**Entrega externa:** demonstracoes e decisao formal de homologacao.

**Yeshua hoje: NAO IMPLEMENTADO**

- Existem smoke tests CRUD gerados, mas eles nao executam o gate SRE completo.

**Implementacao Yeshua:** gerar um projeto de homologacao operacional por
aplicativo, reutilizando o TestKit e pontos customizados para sucesso, rejeicao,
falha e D2.

**Aceite:** a execucao gera uma ficha G1-G7 preenchida com links para eventos,
bundles, testes e relatorios.

### Passo 12 - Evoluir D3, D4 E Prevencao

**Entrega externa:** maturidade avancada com reproducao e prevencao.

**Yeshua hoje: CONCEITO**

**Implementacao Yeshua:** iniciar apenas depois do baseline D0/D1, da
propagacao e da protecao de dados. Cada fluxo tera adaptadores de efeitos,
snapshots sanitizados e relogio/IDs controlaveis.

**Aceite:** um incidente selecionado pode ser reproduzido sem efeito externo e
convertido em regressao deterministica.

## 5. Gate De Saude Pos-Build

Saude pos-build nao e apenas verificar se um processo respondeu HTTP. O Yeshua
deve produzir um relatorio unico, versionado e associado ao artefato.

### 5.1 Estagios Propostos

| Estagio | Verificacao | Situacao atual |
| --- | --- | --- |
| BuildIntegrity | restore, build, testes unitarios e artefatos esperados | PARCIAL |
| VersionIntegrity | runtime, artefato e snapshot usam a mesma versao | NAO IMPLEMENTADO |
| DeploymentReadiness | configuracao obrigatoria e manifests validos | PARCIAL |
| DependencyHealth | SQL, Redis, RabbitMQ, storage e integracoes essenciais | PARCIAL |
| HostHealth | API, Worker e Front vivos e prontos | PARCIAL |
| ApiSmoke | autenticacao e CRUD gerado em ordem de dependencia | PARCIAL |
| BusinessSmoke | fluxos criticos especificos do aplicativo | NAO IMPLEMENTADO |
| ObservabilityHealth | IDs, versao, provider e coleta funcionando | NAO IMPLEMENTADO |
| DataProtection | ausencia de NeverCapture | NAO IMPLEMENTADO |

### 5.2 Implementacao Alvo

- A Engine gera o esqueleto dos checks padronizaveis.
- O projeto de cada aplicativo contem checks customizados de negocio.
- A infraestrutura executa os checks depois do deploy, sem derrubar outros
  aplicativos do servidor.
- O resultado e um `PostBuildHealthReport` com aplicativo, ambiente, versao,
  horario, checks, duracoes, evidencias e estado final.
- Falhas obrigatorias impedem a promocao do build.
- Checks evolutivos podem gerar alerta sem impedir a promocao.

### 5.3 Primeiro Incremento Realista

1. Expor health de API e Worker com aplicativo, ambiente e versao.
2. Verificar SQL, Redis e RabbitMQ sem executar regra de negocio.
3. Executar os smoke tests ja gerados.
4. Adicionar um `BusinessSmoke` customizado por aplicativo.
5. Publicar o relatorio como evidencia do build.
6. Comparar a versao do relatorio com o snapshot indexado.

## 6. O Que As Evidencias Permitem Fazer

### Disponivel Hoje

- Responder perguntas sobre campos, classes, funcoes e cadeias.
- Selecionar fontes relevantes para regra de negocio, arquitetura, mudanca ou
  diagnostico.
- Distinguir codigo gerado, DSL, custom e fonte estatico.
- Produzir bundle versionado com codigo e historico confirmado.
- Apoiar analise de impacto e orientar onde uma mudanca deve ser feita.

### Possivel Apos D0/D1 E Coletores Runtime

- Reconstruir uma operacao real de ponta a ponta.
- Distinguir falha tecnica de rejeicao de negocio.
- Correlacionar erro, dependencia, versao e fonte.
- Responder duvidas operacionais com fatos de runtime e codigo.
- Medir recorrencia, latencia, retries e pontos de falha.
- Gerar automaticamente um dossie inicial de incidente.

### Possivel Apos D2 E Protecao De Dados

- Aumentar temporariamente a profundidade para um registro ou operacao.
- Capturar decisoes e parametros autorizados sem ativar debug global.
- Comparar execucoes equivalentes.
- Reduzir investigacoes manuais no servidor e no banco.

### Possivel Apos D3/D4

- Reproduzir incidentes com efeitos bloqueados.
- Simular uma correcao sobre dados sanitizados.
- Converter incidentes em testes de regressao.
- Validar mudancas antes de promover um build.

## 7. Agentes Operacionais

Agente nao e uma fonte de verdade. Ele consome evidencias, executa uma politica
e registra sua conclusao ou acao. A autonomia deve crescer somente depois da
qualidade das evidencias.

### Nivel A - Agente Investigador

- Somente leitura.
- Reune runtime, fonte, versao e historico.
- Separa fatos, inferencias e lacunas.
- Produz hipotese e proximos testes.

Estado atual: PARCIAL. A selecao de fontes existe; faltam coletores runtime.

### Nivel B - Agente De Validacao

- Executa healthchecks, smoke tests e consultas permitidas.
- Compara o resultado com o build anterior.
- Nao altera producao.

Estado atual: NAO IMPLEMENTADO como agente; existem testes reutilizaveis.

### Nivel C - Agente De Melhoria

- Localiza fonte da verdade e impacto.
- Propoe alteracao na DSL, Engine ou custom correto.
- Gera plano, codigo e regressao em ambiente controlado.
- Depende de revisao humana para integrar e implantar.

Estado atual: CONCEITO. O bundle ja informa propriedade e editabilidade.

### Nivel D - Agente Operacional Assistido

- Executa somente acoes previstas em runbook.
- Exige autorizacao conforme risco.
- Usa comandos idempotentes, limites e rollback conhecido.
- Audita entrada, decisao, aprovacao, acao e resultado.

Estado atual: NAO IMPLEMENTADO.

### Nivel E - Agente Autonomo Limitado

- Atua apenas sobre acoes reversiveis e previamente homologadas.
- Possui limite de frequencia, custo, escopo e impacto.
- Interrompe a automacao quando a evidencia e insuficiente.

Estado atual: fora do primeiro ciclo.

## 8. Inteligencia Preditiva E Preventiva

Previsao nao nasce somente de codigo-fonte nem de um modelo de IA. Ela exige
historico runtime confiavel, versao, baseline e qualidade de dados.

### Degrau 1 - Checks Preventivos

- versao divergente do snapshot;
- fila crescendo continuamente;
- Outbox ou Inbox estagnada;
- Worker sem progresso;
- dependencia indisponivel;
- certificado proximo do vencimento;
- migration pendente;
- smoke test que deixou de passar.

Esses checks usam regras deterministicas e devem vir antes de IA preditiva.

### Degrau 2 - Deteccao De Tendencia

- aumento de latencia por operacao;
- crescimento de retries;
- mudanca de distribuicao de resultados;
- aumento de rejeicoes de negocio;
- concentracao de erros por versao ou dependencia.

### Degrau 3 - Deteccao De Anomalia

- comportamento diferente do baseline da mesma operacao;
- sequencia de etapas incomum;
- dependencia ou query fora do perfil esperado;
- combinacao rara de estado e erro.

### Degrau 4 - Recomendacao E Prevencao

- correlacionar anomalia com mudanca de codigo ou configuracao;
- prever risco de saturacao ou falha;
- recomendar teste, rollback, aumento de capacidade ou correcao;
- abrir investigacao com fontes e evidencias preselecionados.

Nenhum degrau autoriza sozinho uma alteracao de producao.

## 9. Niveis De Capacidade Do Yeshua

| Nivel | Capacidade | Criterio de conclusao | Estado |
| --- | --- | --- | --- |
| Y0 | Fonte versionada e pesquisavel | snapshot, indice, API e bundle | IMPLEMENTADO |
| Y1 | Build verificavel | health pos-build e versao runtime ligada ao snapshot | PARCIAL |
| Y2 | Operacao observavel | D0/D1, identidades e propagacao ponta a ponta | NAO IMPLEMENTADO |
| Y3 | Diagnostico dirigido | D2, protecao de dados e coletores runtime | NAO IMPLEMENTADO |
| Y4 | Reproducao segura | D3/D4, Replay, Simulation e Regression | NAO IMPLEMENTADO |
| Y5 | Operacao assistida | agentes investigadores, validadores e de melhoria | CONCEITO |
| Y6 | Prevencao inteligente | tendencias, anomalias e agentes limitados | CONCEITO |

O objetivo imediato nao e saltar para Y5 ou Y6. A sequencia segura e concluir
Y1, depois Y2 e Y3. Os niveis seguintes somente terao valor se o baseline for
confiavel.

## 10. Ordem De Implementacao Recomendada

As rodadas abaixo sao unidades pequenas de planejamento, implementacao e
aceite. Uma rodada somente termina quando sua entrega e seu criterio de saida
forem comprovados. A correlacao com um gate indica que a rodada contribui para
ele; o gate somente fica conforme quando todos os seus requisitos forem
demonstrados.

### 10.1 Mapa Das Rodadas

| Rodada | Entrega principal | Passo externo | Gate | Profundidade | Nivel |
| --- | --- | --- | --- | --- | --- |
| R01 | Escopo piloto e responsaveis | Passo 1 | G1 | Nao aplicavel | Base |
| R02 | Identidade imutavel do build | Passo 2 | G2 | Base de D0 | Y1 |
| R03 | Saude de API e Worker | Passos 2 e 6 | G2 e G4 | D0 | Y1 |
| R04 | Saude de dependencias e progresso | Passos 6 e 7 | G4 e G5 | D0/D1 | Y1 |
| R05 | Orquestracao pos-build e smoke CRUD | Passo 11 | G7 | Evidencia de teste | Y1 |
| R06 | Business smoke e vinculo com snapshot | Passos 2 e 11 | G2 e G7 | Evidencia de teste | Y1 |
| R07 | Classificacao e protecao de dados | Passo 10 | G4 | D0-D4 | Base de Y2 |
| R08 | Contrato dos tres eixos e resultados | Passo 4 | G4 | D0/D1 | Y2 |
| R09 | Identidade e propagacao sincrona | Passo 5 | G3 | D0 | Y2 |
| R10 | Propagacao assincrona e causalidade | Passo 5 | G3 | D1 | Y2 |
| R11 | Eventos operacionais essenciais | Passo 6 | G4 | D0 | Y2 |
| R12 | Narrativa operacional | Passo 6 | G4 | D1 | Y2 |
| R13 | Provider, consulta e coletor runtime | Passo 7 | G5 | D0/D1 | Y2 |
| R14 | Correlacao automatica runtime-codigo | Passo 8 | G2 e G7 | D0-D2 | Y2/Y3 |
| R15 | Diagnostico direcionado | Passo 9 | G6 | D2 | Y3 |
| R16 | Homologacao operacional | Passo 11 | G1-G7 | D0-D2 | Y3 |
| R17 | Captura forense | Passo 12 | Avancado | D3 | Y4 |
| R18 | Reproducao e regressao | Passo 12 | Avancado | D4 | Y4 |
| R19 | Agentes operacionais assistidos | Passo 12 | Avancado | D0-D4 | Y5 |
| R20 | Prevencao e predicao | Passo 12 | Avancado | D0-D4 | Y6 |

### 10.2 R01 - Escopo Piloto E Responsaveis

**Correlacao:** Passo 1, Gate G1, profundidade nao aplicavel.

1. Escolher um fluxo inicial da Clinica.
2. Escolher um fluxo inicial do MDF-e.
3. Identificar donos tecnico e funcional.
4. Registrar ambientes, dependencias, restricoes e dados proibidos.
5. Criar o runbook inicial de cada fluxo.

**Entrega:** duas fichas de escopo com operacoes incluidas e excluidas.

**Criterio de saida:** cada fluxo possui responsaveis, ambiente, ponto de
entrada, resultado esperado e procedimento manual atual de verificacao.

### 10.3 R02 - Identidade Imutavel Do Build

**Correlacao:** Passo 2, Gate G2, fundamento do D0 e do nivel Y1.

1. Criar o contrato generico de identidade runtime.
2. Definir como `Application`, `Environment`, `Version`, `CommitSha` e horario
   de build entram no artefato.
3. Expor a identidade nos hosts sem depender da DSL de dominio.
4. Gerar testes da Engine para Clinica e MDF-e.
5. Documentar o comando de build que produz a metadata.

**Entrega:** API e Worker conseguem informar a identidade do artefato em
execucao.

**Criterio de saida:** a identidade permanece igual durante toda a vida do
processo e corresponde ao artefato compilado.

### 10.4 R03 - Saude De API E Worker

**Correlacao:** Passos 2 e 6, Gates G2 e G4, profundidade D0, nivel Y1.

1. Gerar liveness da API sem consultar dependencias.
2. Gerar readiness inicial da API.
3. Definir health do Worker por heartbeat e progresso, sem presumir que HTTP
   sozinho comprova processamento.
4. Incluir identidade runtime nas respostas e evidencias.
5. Criar testes para host saudavel e host indisponivel.

**Entrega:** contrato uniforme de saude para API e Worker.

**Criterio de saida:** e possivel distinguir processo vivo, host pronto e
Worker sem progresso.

### 10.5 R04 - Saude De Dependencias E Progresso

**Correlacao:** Passos 6 e 7, Gates G4 e G5, profundidades D0/D1, nivel Y1.

1. Criar contribuidores de health desacoplados por dependencia.
2. Implementar checks de SQL, Redis e RabbitMQ quando usados pelo aplicativo.
3. Registrar tempo, resultado e erro sanitizado de cada check.
4. Verificar Inbox, Outbox, filas e ultimo progresso dos Workers.
5. Permitir que integracoes especificas fornecam checks customizados.

**Entrega:** readiness explica qual dependencia impede a operacao.

**Criterio de saida:** uma falha controlada em cada dependencia produz um
resultado identificavel sem executar regra de negocio destrutiva.

### 10.6 R05 - Orquestracao Pos-Build E Smoke CRUD

**Correlacao:** Passo 11, Gate G7, evidencia de teste, nivel Y1.

1. Criar o executor do gate pos-build.
2. Executar BuildIntegrity, VersionIntegrity, HostHealth e DependencyHealth.
3. Reutilizar as suites CRUD geradas por aplicativo.
4. Consolidar resultados, tempos e evidencias.
5. Publicar `PostBuildHealthReport` associado ao build.

**Entrega:** um comando executa o gate tecnico e produz um relatorio unico.

**Criterio de saida:** sucesso e falha do gate sao reproduziveis, e uma falha
obrigatoria impede a promocao do build.

### 10.7 R06 - Business Smoke E Vinculo Com Snapshot

**Correlacao:** Passos 2 e 11, Gates G2 e G7, evidencia de teste, conclusao de
Y1.

1. Criar o ponto customizado de `BusinessSmoke` por aplicativo.
2. Implementar um cenario critico para cada fluxo escolhido em R01.
3. Consultar a Inteligencia Operacional para confirmar que a versao do runtime
   possui snapshot indexado.
4. Anexar a referencia do snapshot ao relatorio pos-build.
5. Testar versao ausente ou divergente.

**Entrega:** gate pos-build tecnico e de negocio ligado ao fonte confirmado.

**Criterio de saida:** Y1 somente e concluido quando health, smoke e snapshot
apontam para o mesmo aplicativo e versao.

### 10.8 R07 - Classificacao E Protecao De Dados

**Correlacao:** Passo 10, Gate G4, aplicavel a D0-D4, fundamento de Y2.

1. Criar os tipos de classificacao de dados.
2. Definir `SafeMetadata`, `OperationalData`, `Sensitive` e `NeverCapture`.
3. Criar mascaramento e sanitizacao antes do provider.
4. Permitir classificacao complementar na DSL e no codigo customizado.
5. Criar testes automaticos contra senhas, tokens, certificados e chaves.
6. Definir retencao inicial por profundidade.

**Entrega:** politica executavel de protecao, nao apenas um catalogo textual.

**Criterio de saida:** os testes comprovam que `NeverCapture` nao atravessa a
borda de observabilidade.

### 10.9 R08 - Contrato Dos Tres Eixos E Resultados

**Correlacao:** Passo 4, Gate G4, profundidades D0/D1, nivel Y2.

1. Criar os tipos de severidade, profundidade e modo de execucao.
2. Criar resultados tecnico e de negocio independentes.
3. Criar o envelope minimo do evento operacional.
4. Definir defaults seguros para operacoes Live.
5. Testar combinacoes independentes dos tres eixos.

**Entrega:** contratos estaticos e testes sem provider definitivo.

**Criterio de saida:** alterar severidade nao altera profundidade ou modo, e
rejeicao de negocio nao vira falha tecnica automaticamente.

### 10.10 R09 - Identidade E Propagacao Sincrona

**Correlacao:** Passo 5, Gate G3, profundidade D0, nivel Y2.

1. Evoluir `IExecutionContext` com `RootOperationId`, `OperationId`,
   `ExecutionId` e `CausationId`.
2. Receber ou criar identidades na entrada HTTP.
3. Propagar contexto entre endpoint, Command e Receiver.
4. Criar um novo `ExecutionId` por etapa.
5. Preservar compatibilidade temporaria com `TraceId`.
6. Criar testes de propagacao sincrona.

**Entrega:** uma requisicao HTTP reconstruivel ate o fim do Receiver.

**Criterio de saida:** nenhuma operacao do piloto termina sem identidade, e as
etapas preservam raiz e operacao.

### 10.11 R10 - Propagacao Assincrona E Causalidade

**Correlacao:** Passo 5, Gate G3, profundidade D1, nivel Y2.

1. Incluir o contexto no envelope de mensagens.
2. Propagar por Outbox, fila, Inbox, Saga e Worker.
3. Preservar `OperationId` e criar `ExecutionId` por tentativa.
4. Usar `CausationId` para ligar produtor e consumidor.
5. Modelar retry sem perder a operacao original.
6. Criar teste ponta a ponta HTTP para Worker.

**Entrega:** cadeia causal sincrona e assincrona.

**Criterio de saida:** uma mensagem do piloto pode ser rastreada da entrada ao
consumidor, inclusive em retry.

### 10.12 R11 - Eventos Operacionais Essenciais

**Correlacao:** Passo 6, Gate G4, profundidade D0, nivel Y2.

1. Emitir inicio e fim das operacoes homologadas.
2. Incluir identidade runtime e operacional.
3. Registrar duracao e resultados tecnico e de negocio.
4. Registrar erro resumido e sanitizado.
5. Garantir que falha do provider nao interrompa a operacao principal.
6. Criar testes de sucesso, rejeicao e falha.

**Entrega:** baseline D0 uniforme nos fluxos do piloto.

**Criterio de saida:** cada operacao produz evidencia essencial completa em
qualquer resultado.

### 10.13 R12 - Narrativa Operacional

**Correlacao:** Passo 6, Gate G4, profundidade D1, nivel Y2.

1. Registrar etapas relevantes e suas duracoes.
2. Registrar dependencias, retries e mudancas de componente.
3. Registrar transicoes de fila, Inbox, Outbox e Saga.
4. Definir quais fluxos permanecem apenas em D0.
5. Testar uma narrativa completa por fluxo piloto.

**Entrega:** narrativa D1 pesquisavel sem depender de mensagens livres.

**Criterio de saida:** uma pessoa que nao escreveu o fluxo consegue ordenar as
etapas e identificar onde houve degradacao.

### 10.14 R13 - Provider, Consulta E Coletor Runtime

**Correlacao:** Passo 7, Gate G5, profundidades D0/D1, conclusao de Y2.

1. Escolher e encapsular o provider inicial de eventos.
2. Definir persistencia, retencao e indisponibilidade.
3. Criar consultas por identidades, versao, eixos e tempo.
4. Criar `RuntimeContextCollector` na Inteligencia Operacional.
5. Auditar as consultas.
6. Testar operacao com provider indisponivel.

**Entrega:** evidencias runtime acessiveis pela API operacional.

**Criterio de saida:** o suporte recupera D0/D1 de uma operacao sem acesso
administrativo ao servidor.

### 10.15 R14 - Correlacao Automatica Runtime-Codigo

**Correlacao:** Passo 8, Gates G2 e G7, profundidades D0-D2, transicao Y2/Y3.

1. Usar aplicativo e versao runtime para selecionar o snapshot.
2. Transformar componente, funcao, arquivo, linha, classe e campo em consultas
   ao indice.
3. Unir evidencia runtime e fontes no orquestrador.
4. Produzir bundle com fatos, inferencias e lacunas separados.
5. Tratar versao ausente e simbolo nao resolvido.

**Entrega:** investigacao de uma operacao real com os fontes da mesma versao.

**Criterio de saida:** dado um `OperationId`, a API entrega runtime, snapshot e
fontes relacionados sem ampliar silenciosamente a pesquisa.

### 10.16 R15 - Diagnostico Direcionado

**Correlacao:** Passo 9, Gate G6, profundidade D2, nivel Y3.

1. Criar `DiagnosticPolicy` e seu repositorio.
2. Implementar alvos por aplicativo, operacao, ID, componente e tempo.
3. Definir campos autorizados, volume e expiracao.
4. Avaliar a politica nos pontos gerados.
5. Auditar ativacao, uso, expiracao e encerramento.
6. Demonstrar que operacoes fora do alvo permanecem em D0/D1.

**Entrega:** D2 temporario e controlado.

**Criterio de saida:** a politica expira sem intervencao manual e nao captura
fora do alvo ou da classificacao autorizada.

### 10.17 R16 - Homologacao Operacional

**Correlacao:** Passo 11, Gates G1-G7, profundidades D0-D2, conclusao de Y3.

1. Executar sucesso, rejeicao de negocio e falha tecnica.
2. Executar diagnostico D2 dirigido.
3. Produzir relatorios pos-build e bundles.
4. Medir tempo de investigacao e lacunas.
5. Executar teste `NeverCapture`.
6. Preencher a ficha G1-G7 por fluxo.

**Entrega:** pacote de homologacao dos dois fluxos piloto.

**Criterio de saida:** cada gate possui evidencia e decisao explicita; somente
o escopo aprovado e declarado elegivel para suporte.

### 10.18 R17 - Captura Forense

**Correlacao:** Passo 12, maturidade avancada, profundidade D3, nivel Y4.

1. Selecionar um incidente prioritario.
2. Definir Commands, snapshots e diferencas necessarios.
3. Sanitizar e versionar os artefatos.
4. Aplicar autorizacao, limite e retencao especificos.
5. Comparar estado anterior e posterior.

**Entrega:** pacote forense D3 de um fluxo delimitado.

**Criterio de saida:** o pacote explica dados e decisoes sem conter efeito,
segredo ou informacao fora da politica.

### 10.19 R18 - Reproducao E Regressao

**Correlacao:** Passo 12, maturidade avancada, profundidade D4, nivel Y4.

1. Isolar banco, filas, relogio, IDs e integracoes externas.
2. Implementar Replay com a mesma versao capturada.
3. Implementar Simulation com alteracao controlada.
4. Bloquear efeitos reais por padrao.
5. Converter o incidente em Regression.
6. Executar a regressao no gate de build.

**Entrega:** um incidente reproduzivel e transformado em teste.

**Criterio de saida:** Replay e Simulation nao produzem efeito externo, e a
Regression detecta a reintroducao do problema.

### 10.20 R19 - Agentes Operacionais Assistidos

**Correlacao:** Passo 12, maturidade avancada, profundidades D0-D4, nivel Y5.

1. Implementar primeiro o agente investigador somente leitura.
2. Implementar o agente de validacao sobre health e smoke.
3. Implementar o agente de melhoria com alteracoes submetidas a revisao.
4. Restringir acoes operacionais a runbooks homologados.
5. Exigir autorizacao, idempotencia, limite e auditoria.

**Entrega:** agentes separados por responsabilidade e nivel de autonomia.

**Criterio de saida:** nenhuma acao com efeito ocorre por inferencia nao
confirmada ou fora de politica.

### 10.21 R20 - Prevencao E Predicao

**Correlacao:** Passo 12, maturidade avancada, profundidades D0-D4, nivel Y6.

1. Implementar checks deterministas de versao, fila, Outbox, Inbox, Worker,
   dependencia, certificado, migration e smoke.
2. Construir baseline por operacao e versao.
3. Detectar tendencias de latencia, retry, erro e rejeicao.
4. Detectar anomalias de sequencia, dependencia e estado.
5. Correlacionar anomalias com deploys e mudancas de fonte.
6. Gerar recomendacoes e abrir investigacoes ja enriquecidas.

**Entrega:** prevencao baseada primeiro em regras e depois em comportamento.

**Criterio de saida:** alertas possuem evidencia, taxa de falso positivo
medida e nunca autorizam sozinhos uma mudanca em producao.

## 11. Evidencias No Repositorio

| Capacidade | Evidencia principal |
| --- | --- |
| Engenharia reversa | `src/Engine/Yeshua.Engine.AIContextBuilder/Program.cs` |
| Manifesto | `src/Engine/Yeshua.Engine.AIContextBuilder/ReverseEngineeringManifest.cs` |
| Snapshot SQL | `src/Engine/Yeshua.Engine.AIContextBuilder/ReferenceSqlPublisher.cs` |
| Historico Git | `src/Engine/Yeshua.Engine.AIContextBuilder/GitHistoryImporter.cs` |
| Classificacao | `src/Engine/Yeshua.Engine.AIContextBuilder/SourceArtifactClassifier.cs` |
| API operacional | `src/OperationalIntelligence/Yeshua.OperationalIntelligence.Api/Endpoints/OperationalIntelligenceEndpoints.cs` |
| Orquestracao | `src/OperationalIntelligence/Yeshua.OperationalIntelligence.Api/Application/OperationalContextOrchestrator.cs` |
| Bundle | `src/OperationalIntelligence/Yeshua.OperationalIntelligence.Api/Application/SourceBundleBuilder.cs` |
| Trace atual | `src/CQRS/Application/Yeshua.CQRS.Application.Command/Patterns/Command/ReciverBase.cs` |
| Contexto HTTP | `src/CQRS/Infrastructure/Yeshua.CQRS.Infrastructure.Api/Services/CurrentUserHttp.cs` |
| Contexto Worker | `src/CQRS/Infrastructure/Yeshua.Clinica.CQRS.Infrastructure.Worker/Migration/WorkerExecutionContext.cs` |
| Smoke tests gerados | `src/Engine/Yeshua.Engine/Dominio/Schemas/CQRS/SourceCodeIntegrationApiSmokeCrudTestMigration.cs` |
| Suite de smoke | `src/Engine/Yeshua.Engine/Dominio/Schemas/CQRS/CSharpCQRS.cs` |
| Healthchecks de deploy | `src/Engine/Yeshua.Engine/Dominio/Deployment/DockerComposeRenderer.cs` |

## 12. Regra De Manutencao

Ao concluir uma entrega:

1. atualizar o estado neste documento;
2. adicionar a evidencia concreta;
3. registrar o teste de aceite executado;
4. retirar afirmacoes que nao correspondam mais ao codigo;
5. atualizar o gate externo afetado;
6. nao promover uma intencao futura para IMPLEMENTADO sem teste.
