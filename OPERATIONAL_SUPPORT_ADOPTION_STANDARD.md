# Padrao De Adocao De Observabilidade E Inteligencia Operacional

## 1. Finalidade

Este documento define o passo a passo para implantar observabilidade,
diagnostico e inteligencia operacional em aplicativos Yeshua e sistemas
legados aceitos para sustentacao.

Ele tambem define os requisitos minimos para um sistema ser aceito pelo
suporte. O atendimento nao depende de tecnologia especifica. Um legado pode
usar mecanismos diferentes do Yeshua, desde que produza evidencias equivalentes
e atenda aos mesmos criterios.

O escopo de suporte deve ser expresso por operacoes de negocio. Um sistema pode
ser homologado para um conjunto fechado de operacoes sem alegar cobertura para
fluxos ainda nao instrumentados.

## 2. Linguagem Normativa

| Classificacao | Significado |
| --- | --- |
| OBRIGATORIO | Condicao necessaria para aceitar o sistema no suporte |
| RECOMENDADO | Deve ser implementado, salvo justificativa registrada |
| EVOLUTIVO | Capacidade posterior ao gate minimo |

O nao atendimento de um requisito OBRIGATORIO impede a homologacao do fluxo
afetado.

## 3. Principios

- Observabilidade produz fatos; inteligencia operacional correlaciona os fatos.
- O codigo-fonte confirmado continua sendo evidencia primaria.
- Working tree nunca representa versao operacional confirmada.
- Toda evidencia runtime aponta para aplicativo, ambiente e versao.
- Severidade, profundidade e modo de execucao sao eixos diferentes.
- IDs sao sempre produzidos; o detalhamento pode ser seletivo.
- Fatos sao imutaveis; hipoteses e diagnosticos sao derivados.
- Observabilidade nao pode interromper a operacao principal.
- Segredos nunca podem ser capturados.
- Diagnostico direcionado possui prazo, alvo e limites.
- Replay e simulacao nao produzem efeitos reais por padrao.
- A Engine gera bordas; DSL declara significado; IA/dev completa os miolos.

## 4. Modelo Conceitual

### 4.1 Identidades universais

| Identidade | Uso |
| --- | --- |
| RootOperationId | Relaciona uma operacao principal e suas filhas |
| OperationId | Identifica uma intencao de negocio do inicio ao fim |
| ExecutionId | Identifica uma etapa ou tentativa tecnica |
| CausationId | Identifica a execucao que provocou a atual |
| Application | Identifica o aplicativo ou sistema |
| Environment | Identifica o ambiente |
| Version | Identifica o commit ou build confirmado |

SagaId, JobId, MessageId, TenantId, UserId, DocumentId e identificadores fiscais
sao contextuais. Eles complementam as identidades universais.

### 4.2 Resultados

| Resultado | Exemplos |
| --- | --- |
| TechnicalOutcome | Success, Failure, Timeout, Unavailable |
| BusinessOutcome | Approved, Rejected, Completed, Cancelled |

Uma resposta tecnica bem-sucedida pode conter uma rejeicao de negocio.

### 4.3 Severidade

- Information.
- Warning.
- Error.
- Critical.

Severidade informa gravidade, nao volume de captura.

### 4.4 Profundidade

| Nivel | Nome | Evidencia esperada |
| --- | --- | --- |
| D0 | Essential | identidade, versao, inicio, fim, resultado e erro resumido |
| D1 | Narrative | etapas, duracoes, causalidade, retries e dependencias |
| D2 | Diagnostic | decisoes, funcoes, queries, parametros e stack trace |
| D3 | Forensic | Commands, snapshots, diferencas e artefatos sanitizados |
| D4 | Replayable | estado, leituras, relogio, IDs e respostas externas |

Os niveis sao cumulativos.

### 4.5 Modos de execucao

| Modo | Objetivo |
| --- | --- |
| Live | Executar a operacao real e produzir evidencias |
| Replay | Repetir a mesma versao e dependencias capturadas |
| Simulation | Alterar versao, dados, configuracao ou dependencia |
| Regression | Preservar uma reproducao sanitizada como teste |

### 4.6 Classificacao de dados

| Classe | Tratamento |
| --- | --- |
| SafeMetadata | Permitido no baseline |
| OperationalData | Permitido conforme politica |
| Sensitive | Captura explicita, mascarada e temporaria |
| NeverCapture | Proibido em qualquer profundidade |

Senhas, tokens, chaves privadas e certificados privados sao NeverCapture.

## 5. Arquitetura Logica

O modelo possui sete blocos:

1. Especificacoes, DSL e codigo-fonte confirmado.
2. Engenharia reversa e indice estatico versionado.
3. Instrumentacao de operacoes e execucoes.
4. Coletores de eventos, metricas, traces e snapshots.
5. Orquestracao e normalizacao.
6. Investigacao assistida e validacao humana.
7. Replay, simulacao e regressao.

Providers e armazenamentos podem mudar. Os contratos conceituais permanecem.

## 6. Fases De Implantacao

## Fase 0 - Definir Escopo E Responsaveis

### Objetivo

Determinar quais operacoes serao suportadas e quem responde por codigo,
operacao, dados e seguranca.

### Passos obrigatorios

1. Identificar sistema, ambientes e repositorios.
2. Listar as operacoes incluidas no suporte.
3. Identificar APIs, workers, filas, jobs, bancos e integracoes.
4. Definir responsavel tecnico, operacional e dono dos dados.
5. Registrar restricoes de acesso, retencao e dados sensiveis.
6. Escolher um fluxo de sucesso e um de falha para homologacao.

### Trilha Yeshua

- Identificar Studio e projetos gerados.
- Relacionar operacoes a Commands, Receivers e integracoes.

### Trilha legado

- Delimitar projetos, servicos e modulos cobertos.
- Registrar pontos sem fonte, acesso ou instrumentacao.

### Entregaveis

- ficha do sistema;
- operacoes suportadas;
- mapa de componentes;
- matriz de responsaveis;
- riscos e exclusoes.

### Criterio de saida

Nenhum componente relevante pode permanecer com propriedade desconhecida.

## Fase 1 - Confirmar Fonte E Versao

### Objetivo

Relacionar toda evidencia runtime ao codigo exato que a produziu.

### Passos obrigatorios

1. Disponibilizar repositorios e projetos.
2. Trabalhar apenas com commits confirmados.
3. Criar manifesto com sistema, tipo, versao, solucao e projetos.
4. Executar engenharia reversa.
5. Validar arquivos, classes, campos e funcoes prioritarios.
6. Registrar a versao no artefato de deploy.
7. Emitir Application, Environment e Version em API e Worker.
8. Comprovar que a versao emitida existe no indice.

### Trilha Yeshua

- Usar AIContextBuilder e manifestos versionados.
- Classificar DSL, regeneraveis e customizados.
- Usar commit confirmado como identidade de build.

### Trilha legado

- Fornecer lista fechada de projetos e diretorios.
- Usar analise semantica ou fallback sintatico documentado.
- Adaptar build e deploy para expor a versao.

### Entregaveis

- manifesto;
- build indexado;
- relatorio de cobertura;
- procedimento de versionamento;
- evidencia runtime da versao.

### Criterio de saida

Uma funcao encontrada em erro deve levar ao snapshot correto do fonte.

## Fase 2 - Catalogar Operacoes

### Objetivo

Colocar a operacao de negocio no centro da sustentacao.

### Passos obrigatorios

1. Nomear cada operacao do escopo.
2. Identificar entrada, resultado, entidade e componentes.
3. Definir quando inicia e termina.
4. Identificar filhas, lotes, etapas assincronas e retries.
5. Definir TechnicalOutcome e BusinessOutcome.
6. Relacionar IDs contextuais.
7. Definir quais erros encerram, suspendem ou permitem retry.

### Trilha Yeshua

- Declarar significado na DSL quando padronizavel.
- Usar Commands e Receivers como bordas geradas.
- Gerar catalogo a partir da DSL.

### Trilha legado

- Criar catalogo externo inicialmente.
- Mapear controllers, services, jobs e procedures.
- Introduzir nomes estaveis sem reescrever a arquitetura.

### Entregaveis

- catalogo de operacoes;
- diagrama causal;
- matriz operacao versus componente;
- definicao de resultados e retries.

### Criterio de saida

Suporte e desenvolvimento usam os mesmos nomes para descrever o fluxo.

## Fase 3 - Definir Eventos E Dados

### Objetivo

Padronizar evidencias e impedir captura acidental de dados proibidos.

### Passos obrigatorios

1. Definir eventos de Lifecycle, Decision, StateChange, Dependency,
   Integration, Message, Retry, Failure e Infrastructure.
2. Definir payload minimo por evento.
3. Classificar cada atributo.
4. Definir mascaramento e NeverCapture.
5. Definir profundidade minima e maxima.
6. Definir retencao por classe e profundidade.
7. Definir limites de eventos, bytes e snapshots.
8. Definir quem ativa diagnostico direcionado.

### Trilha Yeshua

- Engine define eventos tecnicos globais.
- DSL define eventos e resultados de negocio.
- IA/dev registra somente decisoes internas relevantes.

### Trilha legado

- Reaproveitar logs estruturados existentes.
- Criar adaptadores de normalizacao.
- Substituir strings livres nos pontos prioritarios.

### Entregaveis

- catalogo de eventos;
- dicionario de atributos;
- classificacao de dados;
- politicas de retencao e profundidade.

### Criterio de saida

Cada evento possui dono, finalidade, schema e classificacao.

## Fase 4 - Implementar D0 E D1

### Objetivo

Garantir narrativa basica e correlacionada em producao.

### Passos obrigatorios

1. Gerar ou receber os IDs universais.
2. Propagar contexto em HTTP, fila, Worker, job, Saga e Outbox.
3. Emitir inicio, fim, duracao e resultado.
4. Capturar excecoes com componente, funcao e stack disponivel.
5. Emitir etapas relevantes em D1.
6. Separar resultado tecnico e de negocio.
7. Preservar OperationId em retries automaticos.
8. Garantir que falha na telemetria nao falhe a operacao.
9. Comprovar ausencia de NeverCapture.

### Trilha Yeshua

- Implementar contratos e propagacao no Shared.
- Engine gera instrumentacao nas bordas.
- Evitar logs manuais repetitivos nos gerados.

### Trilha legado

- Instrumentar primeiro entrada, processamento e saida.
- Usar interceptadores ou wrappers quando apropriado.
- Mapear IDs existentes para o modelo universal.

### Entregaveis

- contexto de execucao;
- propagadores;
- eventos D0/D1;
- teste ponta a ponta;
- relatorio de dados proibidos.

### Criterio de saida

Uma operacao real revela inicio, etapas, resultado, erro, versao e componentes.

## Fase 5 - Disponibilizar Evidencias

### Objetivo

Permitir consulta sem acesso manual a cada servidor.

### Passos obrigatorios

1. Definir fontes oficiais de eventos, traces, metricas e snapshots.
2. Normalizar timestamps, aplicacao, ambiente, versao e IDs.
3. Permitir consulta por OperationId e IDs contextuais.
4. Aplicar controle de acesso e auditoria.
5. Aplicar retencao, descarte e limites.
6. Definir comportamento durante indisponibilidade do coletor.
7. Documentar atraso maximo de disponibilizacao.
8. Eliminar dependencia de acesso administrativo ao host.

### Trilha Yeshua

- Criar coletores por IContextCollector.
- Manter a API operacional desacoplada dos aplicativos.
- Permitir consulta por API e Console.

### Trilha legado

- Criar adaptadores para fontes existentes.
- Expor somente o recorte necessario.
- Registrar fontes inacessiveis ou insuficientes.

### Entregaveis

- mapa de fontes;
- coletores;
- politicas de acesso e retencao;
- consultas documentadas.

### Criterio de saida

Um analista recupera a narrativa pelo OperationId sem entrar no servidor.

## Fase 6 - Integrar Codigo E Runtime

### Objetivo

Combinar o que aconteceu com o codigo confirmado.

### Passos obrigatorios

1. Criar coletor de runtime no orquestrador.
2. Receber pergunta, aplicacao, ambiente e IDs.
3. Obter Version a partir da evidencia runtime.
4. Reconstruir a narrativa.
5. Extrair funcoes, arquivos e linhas.
6. Consultar o indice estatico daquela versao.
7. Incluir DSL, gerados e customizados conforme propriedade.
8. Gerar bundle com fatos, fontes e confianca.
9. Separar fato, inferencia, hipotese e conflito.
10. Permitir chamada direta pelo agente.

### Trilha Yeshua

- Usar marcadores de propriedade e fonte da verdade.
- Orientar mudancas para DSL, template ou custom correto.

### Trilha legado

- Identificar cadeias sintaticas, parciais ou inferidas.
- Nunca apresentar fallback como fato semantico.

### Entregaveis

- coletor runtime;
- investigacao combinada;
- bundle operacional;
- relatorio de confianca.

### Criterio de saida

Uma falha real gera narrativa, versao e fontes suficientes para triagem.

## Fase 7 - Implementar D2 Direcionado

### Objetivo

Detalhar um alvo sem ativar debug para toda a base.

### Passos obrigatorios

1. Criar DiagnosticPolicy.
2. Permitir alvo por operacao, entidade, tenant, usuario ou mensagem.
3. Definir janela e expiracao automatica.
4. Definir limites de eventos e bytes.
5. Distribuir politicas para cache local.
6. Evitar consulta remota por evento.
7. Propagar DiagnosticSessionId e profundidade.
8. Capturar decisoes, funcoes, queries e atributos permitidos.
9. Auditar ativacao e encerramento.
10. Comprovar que operacoes nao selecionadas permanecem em D0/D1.

### Trilha Yeshua

- Gerar avaliacao e propagacao nas bordas.
- Fornecer API pequena para decisoes nos miolos.

### Trilha legado

- Implementar chave de diagnostico equivalente.
- Limitar primeiro recorte a entidades prioritarias.

### Entregaveis

- DiagnosticPolicy;
- avaliador em memoria;
- controle e auditoria;
- teste de lote com um item em D2.

### Criterio de saida

Um lote detalha somente o alvo escolhido.

## Fase 8 - Implementar D3 Forensic

### Objetivo

Capturar estado suficiente para explicar problemas dependentes de dados.

### Passos obrigatorios

1. Criar Snapshot e ArtifactReference.
2. Capturar estado anterior e posterior somente quando autorizado.
3. Armazenar objetos fora do evento.
4. Gerar hash, schema, classificacao e tamanho.
5. Mascarar antes da persistencia.
6. Permitir projecoes customizadas.
7. Definir retencao curta e descarte verificavel.
8. Comparar snapshots e produzir diferencas.

### Trilha Yeshua

- Gerar snapshots pela metadata da DSL.
- Respeitar Sensitive e NeverCapture.

### Trilha legado

- Criar DTOs de captura especificos.
- Nao serializar objetos desconhecidos automaticamente.

### Criterio de saida

Dados de entrada e mudancas sao explicados sem expor dados proibidos.

## Fase 9 - Implementar D4 E Reproducao

### Objetivo

Transformar execucao real em caso reproduzivel e simulavel.

### Passos obrigatorios

1. Definir ReplayCapsule.
2. Capturar Command, estado, leituras e respostas externas.
3. Controlar relogio, IDs, sequencias e aleatoriedade.
4. Isolar banco, fila, arquivos e integracoes.
5. Bloquear efeitos reais.
6. Repetir mesma versao e comparar.
7. Executar nova versao com a mesma capsula.
8. Permitir variacoes declaradas.
9. Promover casos sanitizados para regressao.
10. Registrar diferencas entre original, replay e simulacao.

### Trilha Yeshua

- Gerar harness e portas controlaveis.
- Detectar acessos diretos nao reproduziveis.

### Trilha legado

- Encapsular progressivamente dependencias.
- Aceitar reproducao parcial com limites registrados.

### Criterio de saida

O caso reproduz o resultado ou explica as fontes de nao determinismo.

## Fase 10 - Saude Preventiva

1. Definir comportamento esperado por operacao.
2. Historizar disponibilidade, volume, duracao e rejeicao.
3. Separar metricas tecnicas e de negocio.
4. Definir limites e janelas.
5. Relacionar alertas a aplicacao, versao e operacao.
6. Criar runbook para cada alerta acionavel.
7. Medir falsos positivos.

Criterio: todo alerta indica impacto, evidencia, responsavel e proxima acao.

## Fase 11 - Capacidade Preditiva

1. Selecionar previsoes com valor comprovado.
2. Definir historico minimo.
3. Comparar entrada e capacidade.
4. Detectar regressao apos versao.
5. Medir precisao e antecedencia.
6. Separar previsao de fato observado.

Criterio: previsoes possuem confianca, horizonte e taxa de acerto.

## Fase 12 - Inteligencia Operacional Assistida

1. Consolidar codigo, runtime, metricas, snapshots e historico.
2. Classificar evidencias por confianca.
3. Localizar incidentes semelhantes.
4. Separar hipotese e evidencia.
5. Recomendar acoes com impacto e risco.
6. Exigir validacao humana para efeitos operacionais.
7. Registrar diagnosticos confirmados.
8. Transformar incidentes em especificacoes e regressao.

Criterio: a IA cita evidencias e declara contexto insuficiente.

## 7. Gate Minimo Para Aceitacao No Suporte

Um fluxo somente e ELEGIVEL PARA SUPORTE quando comprova G1 a G7.

### G1 - Governanca

- escopo definido;
- responsaveis identificados;
- acessos e restricoes documentados;
- runbook inicial.

### G2 - Fonte E Versao

- codigo confirmado disponivel;
- manifesto aprovado;
- snapshot indexado;
- runtime informa Application, Environment e Version;
- versao corresponde a build indexado.

### G3 - Identidade Operacional

- OperationId nas operacoes;
- ExecutionId nas etapas principais;
- propagacao sincrona e assincrona;
- IDs contextuais relevantes.

### G4 - Evidencia Minima

- D0 em todas as operacoes cobertas;
- D1 nos fluxos prioritarios;
- erros possuem componente, versao e stack quando possivel;
- resultados tecnico e de negocio separados;
- dados classificados;
- NeverCapture validado.

### G5 - Consulta Operacional

- evidencias centralizadas ou acessiveis por coletor;
- busca por OperationId;
- sem dependencia de acesso administrativo ao servidor;
- retencao acordada;
- consultas auditadas.

### G6 - Diagnostico Direcionado

- D2 ativavel para alvo limitado;
- politica com expiracao e limites;
- demais operacoes permanecem em D0/D1;
- ativacao auditada.

### G7 - Demonstracao

- fluxo de sucesso reconstruido;
- rejeicao de negocio distinguida de sucesso tecnico;
- falha tecnica real ou controlada investigada;
- erro levou ao snapshot correto do fonte;
- bundle produzido com fatos, versao e arquivos;
- tempo e conclusao registrados.

D3, D4, replay, simulacao, previsao e IA cognitiva nao sao obrigatorios para o
gate inicial. Eles determinam maturidade avancada.

## 8. Classificacao De Suportabilidade

| Estado | Significado |
| --- | --- |
| NAO ELEGIVEL | Falha em requisito obrigatorio |
| EM ADEQUACAO | Possui plano, mas nao recebe suporte normal |
| ELEGIVEL | Atende G1 a G7 para o escopo |
| AVANCADO | Possui D3/D4, replay ou prevencao adicional |

EM ADEQUACAO permite onboarding, nao SLA normal de diagnostico.

### 8.1 Ficha De Avaliacao

Uma ficha deve ser preenchida para cada sistema e escopo de operacoes. Nao e
permitido aprovar apenas pela existencia de ferramentas; cada gate precisa de
evidencia executada e verificavel.

| Gate | Estado | Evidencia | Responsavel | Pendencia E Prazo |
| --- | --- | --- | --- | --- |
| G1 - Governanca | Pendente | | | |
| G2 - Fonte e versao | Pendente | | | |
| G3 - Identidade operacional | Pendente | | | |
| G4 - Evidencia minima | Pendente | | | |
| G5 - Consulta operacional | Pendente | | | |
| G6 - Diagnostico direcionado | Pendente | | | |
| G7 - Demonstracao | Pendente | | | |

Estados permitidos por gate:

- Pendente: ainda nao avaliado.
- Nao conforme: requisito nao atendido.
- Conforme com ressalva: requisito atendido, com melhoria recomendada
  registrada e sem risco para o diagnostico minimo.
- Conforme: requisito atendido e comprovado.

Resultado da avaliacao:

| Campo | Preenchimento |
| --- | --- |
| Sistema | |
| Tipo | Yeshua ou legado |
| Ambiente | |
| Versao avaliada | commit ou build confirmado |
| Operacoes cobertas | lista fechada |
| Operacoes excluidas | lista e justificativa |
| Classificacao | NAO ELEGIVEL, EM ADEQUACAO, ELEGIVEL ou AVANCADO |
| Validade da homologacao | data ou criterio de recertificacao |
| Responsavel tecnico | |
| Responsavel do suporte | |
| Aprovador | |

Uma operacao excluida deve aparecer explicitamente no resultado. A homologacao
de parte do sistema nao implica suporte para os demais fluxos.

## 9. Processo De Onboarding

1. Receber solicitacao.
2. Definir escopo por operacoes.
3. Aplicar checklist G1 a G7.
4. Classificar lacunas.
5. Criar plano de adequacao.
6. Executar engenharia reversa.
7. Instrumentar D0/D1 e D2 direcionado.
8. Integrar coletores.
9. Executar demonstracoes.
10. Revisar seguranca.
11. Registrar evidencias.
12. Aprovar ou rejeitar.
13. Definir recertificacao.

Mudanca de repositorio, pipeline, versao, arquitetura ou fonte de evidencia
exige reavaliacao do gate afetado.

## 10. Pacote De Homologacao

- ficha e escopo;
- manifestos;
- repositorios e projetos;
- catalogos de operacoes e eventos;
- classificacao de dados;
- procedimento de build e deploy;
- identificacao da versao runtime;
- mapa de propagacao;
- fontes de evidencias;
- politica de profundidade;
- politica de acesso e retencao;
- runbook;
- bundles de sucesso e falha;
- relatorio NeverCapture;
- checklist G1 a G7;
- aprovadores.

## 11. Responsabilidades

### Plataforma Yeshua

- manter contratos universais;
- gerar instrumentacao;
- manter engenharia reversa e API;
- fornecer propagacao, politicas, snapshots e replay;
- permanecer generica.

### Time Do Aplicativo

- declarar operacoes e resultados;
- classificar dados;
- instrumentar decisoes dos miolos;
- adaptar integracoes;
- manter manifestos e versoes.

### Time Do Legado

- fornecer codigo e ambiente;
- mapear operacoes;
- adaptar IDs e eventos;
- declarar limites;
- corrigir lacunas do gate.

### Operacao

- manter evidencias disponiveis;
- administrar retencao e acesso;
- operar diagnostico;
- manter runbooks.

### Suporte

- investigar por API e Console;
- separar fatos, hipoteses e diagnosticos;
- preservar evidencias;
- registrar lacunas recorrentes.

### Seguranca E Dono Dos Dados

- aprovar classificacao;
- validar mascaramento;
- definir retencao;
- auditar D2 a D4.

## 12. Metricas

- cobertura das operacoes;
- runtime associado a versao;
- operacoes com narrativa completa;
- falhas sem OperationId;
- evidencias com dados proibidos;
- tempo para localizar causa;
- acessos manuais ao servidor;
- precisao dos fontes selecionados;
- falsos positivos e negativos;
- sessoes D2 fora do limite;
- incidentes transformados em regressao.

## 13. Ordem Recomendada Para O Yeshua

1. Formalizar ExecutionContext e OperationalEvent.
2. Formalizar profundidade, severidade e resultados.
3. Emitir Application, Environment e Version.
4. Gerar IDs e propagacao em API e Worker.
5. Instrumentar Command e Receiver em D0/D1.
6. Instrumentar fila, Saga, Outbox e Retry.
7. Gerar catalogos pela DSL e Engine.
8. Implementar coletor runtime na API operacional.
9. Executar G1 a G7 na Clinica.
10. Executar G1 a G7 no primeiro legado.
11. Implementar DiagnosticPolicy.
12. Somente depois iniciar D3 e D4.

## 14. Conclusao Do Programa

O programa e efetivo quando:

- suporte reconstrui operacao sem acesso manual extenso;
- runtime leva ao codigo correto;
- falha real produz diagnostico com evidencias;
- mudanca encontra DSL, gerados e custom corretos;
- incidente pode virar especificacao e regressao;
- sistemas incompletos sao recusados ou enviados para adequacao.

## 15. Decisoes Abertas

- formato definitivo dos eventos;
- local dos catalogos;
- provider inicial;
- retencao por profundidade;
- distribuicao de DiagnosticPolicy;
- tratamento de IDs sensiveis;
- autorizacao de D3/D4 em producao;
- fronteira entre DSL e API custom;
- processo de recertificacao.
