# Plano De Experimentos Operacionais Do Fiscal

## 1. Objetivo

Usar o aplicativo Fiscal como primeiro laboratorio completo das definicoes de
`OPERATIONAL_SUPPORT_ADOPTION_STANDARD.md`, sem espalhar instrumentacao ainda
nao comprovada pelos demais aplicativos Yeshua.

O experimento cobre o fluxo real:

`ContingenciaFiscalStandard -> EmissaoFiscalCargaStandard -> CT-e -> MDF-e -> retorno da contingencia`

O Fiscal foi escolhido porque exercita, no mesmo processo:

- tela, HTTP, Command e Receiver;
- duas sagas e transicao entre elas;
- execucao imediata, espera externa e Worker;
- repositories e SQL;
- certificado e dados `NeverCapture`;
- integracao SEFAZ;
- sucesso tecnico, rejeicao fiscal e falha tecnica.

A correlacao formal entre este plano e o documento externo fica separada em
`docs/operational/fiscal/FISCAL_OPERATIONAL_STANDARD_CORRELATION.md`. O padrao
externo nao e alterado pelos experimentos.

## 2. Regra Principal De Custo

Toda captura deve possuir seletor liga/desliga. Nao basta desligar a publicacao
depois que o dado ja foi calculado.

A decisao acontece antes de:

- iniciar cronometro;
- consultar relogio;
- criar ID adicional;
- acessar ou criar entrada em dicionario;
- executar `lock` ou `Interlocked` de contador;
- montar mensagem;
- capturar excecao detalhada ou stack trace;
- serializar JSON;
- copiar payload;
- gravar em stdout, disco, banco ou rede.

Quando uma capacidade estiver desligada, o custo permitido no caminho quente e:

1. ler uma referencia imutavel de politica com `Volatile.Read`;
2. testar um bit gerado para a capacidade;
3. retornar.

Nenhuma capacidade fica permanentemente ligada por acidente. O perfil de
suporte pode manter D0 habilitado por configuracao, mas existe um `MasterEnabled`
capaz de desligar toda captura operacional em emergencia. Identidade de build e
endpoints de health nao possuem custo por operacao; so executam quando o host
inicia ou quando o endpoint e consultado.

Cada ponto instrumentado deve possuir um registro de custo correlacionado a
Secao 17 do documento externo:

| Campo de controle | Obrigatorio |
| --- | --- |
| `Capability` | flag que liga a captura |
| `HotPathLocation` | ponto exato onde a decisao ocorre |
| `DisabledCost` | alocacoes, sincronizacao, CPU e latencia com a flag desligada |
| `EnabledCost` | custo por profundidade habilitada |
| `Volume` | eventos e bytes por unidade de tempo |
| `Retention` | tempo de preservacao |
| `DataClassification` | maior classe de dado que pode sair do ponto |
| `StandardReference` | secao, gate e profundidade atendidos |
| `Evidence` | benchmark, teste ou relatorio que comprova a medicao |

## 3. O Que Pode Ser Ligado Separadamente

O controle nao deve usar uma unica chave generica chamada `Telemetry`. A
politica compilada deve possuir flags independentes:

| Capacidade | O que mede | Padrao inicial do experimento |
| --- | --- | --- |
| `CommandCounters` | execucoes, falhas, ativos e duracao agregada | desligado |
| `CommandEvents` | inicio, fim e resultado do Command | desligado |
| `RepositoryCounters` | quantidade, falhas e duracao agregada | desligado |
| `RepositoryEvents` | dependencia e duracao por execucao | desligado |
| `SagaEvents` | criacao, transicao, wait, retomada e conclusao | desligado |
| `WorkerEvents` | ciclo, itens capturados, processados e falhas | desligado |
| `ExternalCallEvents` | chamada e retorno SEFAZ sem payload sensivel | desligado |
| `DomainTracking` | alteracao de campos explicitamente permitidos | desligado |
| `PayloadCapture` | campos autorizados para D2 ou superior | desligado |
| `OperationalMetrics` | backlog, taxa, latencia e progresso | desligado |

Falhas tambem obedecem a politica. O perfil normal de suporte deve habilitar o
resumo de erro D0, mas o codigo nao pode possuir uma escrita incondicional que
ignore `MasterEnabled` ou a flag da capacidade.

## 4. Selecao Do Alvo

As flags dizem **o que** pode ser capturado. Os seletores dizem **onde** a
captura vale:

1. aplicativo e ambiente;
2. componente;
3. operacao;
4. entidade;
5. registro;
6. campo.

A politica tambem carrega:

- severidade minima;
- profundidade D0-D4;
- modo Live, Replay, Simulation ou Regression;
- expiracao;
- limite de eventos e bytes;
- amostragem, quando permitida;
- lista positiva de campos capturaveis.

Precedencia: o alvo mais especifico vence. `NeverCapture` nunca pode ser
sobrescrito por um alvo mais especifico, aprovador ou profundidade.

Para evitar comparacao de strings e varredura de listas em toda execucao, a
Engine gera IDs numericos para componente, operacao, entidade e campo. Ao
receber uma politica nova, o host a compila uma vez em uma estrutura imutavel.
Somente diagnostico direcionado por registro acessa um indice adicional.

## 5. Dados Proibidos No Fiscal

Devem nascer como `NeverCapture`:

- bytes do PFX;
- senha do certificado;
- chave privada;
- token e cabecalho de autenticacao;
- connection string;
- XML fiscal integral;
- payload bruto contendo dados pessoais ou fiscais;
- segredos de SEFAZ ou infraestrutura.

Podem existir como metadados seguros, quando necessarios:

- tipo do documento;
- ambiente de homologacao/producao;
- UF autorizadora;
- `cStat` e codigo interno de resultado;
- duracao;
- tamanho em bytes;
- hash nao reversivel para correlacao;
- chave de acesso apenas quando a classificacao e a politica permitirem.

## 6. Ciclo Obrigatorio De Cada Experimento

1. Declarar hipotese, ponto instrumentado e gate relacionado.
2. Definir flags e alvo; iniciar com tudo desligado.
3. Medir o fluxo sem instrumentacao.
4. Ligar somente uma capacidade em ambiente local ou homologacao.
5. Medir CPU, memoria, alocacoes, latencia, locks, volume e tamanho.
6. Confirmar que nenhum `NeverCapture` foi produzido.
7. Desligar em runtime e comprovar cessacao da captura sem reinicio.
8. Registrar resultado: aprovado, revisar ou rejeitado.
9. Remover o experimento rejeitado; nao deixar codigo morto.
10. Somente o experimento aprovado vira geracao padrao da Engine.

## 7. Experimentos Em Ordem

### F-EXP-00 - Custo Desligado

**Correlacao externa:** Secoes 4, 5.5 e 17. Prepara G4 sem produzir evidencia
quando desligado.

**Fluxo:** confirmar uma contingencia ate concluir CT-e e MDF-e.

**Implementacao:** adicionar somente a decisao barata nos pontos selecionados,
com `MasterEnabled=false` e todas as flags desligadas.

**Aceite:** zero alocacao atribuivel a telemetria, nenhum dicionario, lock,
cronometro, serializacao ou I/O. No teste ponta a ponta, a diferenca de latencia
deve ficar dentro do ruido medido; se houver regressao consistente, a
implementacao nao avanca.

**Resultado da primeira rodada (2026-09-19): implementacao funcional concluida,
medicao de desempenho pendente.**

- `DefaultLevel=None` foi configurado para Fiscal em Development e Homologation.
- Receivers consultam a politica antes de iniciar cronometro, acessar contadores
  ou montar dados de telemetria.
- Repositories consultam a politica antes de calcular o hash da query, iniciar
  cronometro ou entrar no bloco de instrumentacao.
- `DomainValueChanged` e `Metric` rejeitam a captura antes de atualizar
  dicionarios e contadores.
- A falha da propria politica desliga a telemetria e nao altera o resultado nem
  substitui uma excecao do negocio.
- Oito testes focados passaram, cobrindo sucesso, falha retornada, excecao,
  politica indisponivel e os cortes `Off` de Receiver e Repository.

Esta rodada comprova comportamento e ausencia das operacoes caras depois do
corte. Ela ainda nao comprova o criterio quantitativo de zero alocacao nem a
diferenca de latencia dentro do ruido. Essa evidencia exige benchmark isolado e
comparacao do fluxo Fiscal ponta a ponta antes de aprovar definitivamente o
experimento.

### F-EXP-01 - Command D0

**Correlacao externa:** Secoes 5, 7, 9.3, 9.4 e 10; contribui para G4.

**Borda instrumentada:** `ReciverBase`, uma unica vez para todos os Commands.
Nenhum miolo de negocio recebe codigo de observabilidade.

**Alvo inicial:** uma instancia de `EntradaFiscalContingencia`, selecionada em
runtime por entidade e correlacao. A Engine gera no Command apenas referencias
diretas para esses dois valores; sem reflection, descriptor alocado ou conversao
no caminho quente.

**Flags:** `CommandCounters`; depois, em medicao separada, `CommandEvents`.

**Captura:** operacao, inicio/fim, duracao e resultados tecnico e de negocio.

**Aceite:** ligar e desligar sem reinicio; rejeicao de negocio nao aparece como
falha tecnica; nenhuma captura fora do objeto selecionado. O piloto ainda usa os
seletores textuais da politica atual. IDs numericos so serao promovidos depois
de medicao demonstrar necessidade.

**Resultado da segunda rodada (2026-09-20): metadata central implementada.**

- A Engine gera `IOperationalTelemetryCommand` somente no Command de entrada
  que possui entidade declarada na DSL.
- A metadata aponta diretamente para o nome da entidade e, quando disponivel,
  para a `CorrelationId` ja existente no Command.
- `ReciverBase` entrega entidade e correlacao para a politica antes de iniciar
  cronometro ou acessar contadores.
- Nenhum handler, regra fiscal ou metodo especifico recebeu instrumentacao.
- Nao ha reflection, criacao de descriptor, serializacao ou conversao de ID no
  caminho quente introduzida por esta rodada.
- O Fiscal foi regenerado com `--codegen-only`; a Engine, os Commands gerados e
  os nove testes focados compilaram com zero erros.

**Resultado da terceira rodada (2026-09-20): selecao e troca em runtime
comprovadas no caminho do Receiver.**

- A mesma instancia de politica, logger e Receiver foi mantida durante toda a
  prova; nao houve reinicializacao entre ligar e desligar.
- Um alvo `Command + EntradaFiscalContingencia + correlation-selected` capturou
  somente a execucao da correlacao escolhida.
- Outra correlacao da mesma entidade executou normalmente e nao entrou na
  telemetria.
- A substituicao da politica por `None/D0` interrompeu novas capturas da
  correlacao escolhida sem recriar qualquer componente.
- O caminho real de distribuicao ja existente permanece: `PUT` na API central,
  consulta por revisao da API/Worker Fiscal e troca atomica do snapshot local.

Continua pendente somente a evidencia em homologacao com os tres processos
rodando, comprovando o intervalo de propagacao HTTP da central ate API e Worker.
O comportamento local da politica e da borda Command esta fechado.

### F-EXP-02 - Saga De Contingencia D1

**Correlacao externa:** Secoes 5.2, 6, 9.4 e 9.5; contribui para G3 e G4.

**Alvo:** `ContingenciaFiscalStandard`.

**Flags:** `SagaEvents`.

**Captura:** criacao, step atual, transicao, entrada em wait, retomada, falha e
conclusao. Nao capturar payload do step.

**Aceite:** reconstruir os cinco steps da saga pela identidade operacional e
desligar a narrativa mantendo o fluxo funcional.

**Resultado da primeira rodada (2026-09-20): borda central implementada e
comportamento isolado comprovado.**

- `SagaExecutor`, usado tanto pelo Worker quanto pela continuacao imediata,
  tornou-se o unico ponto de instrumentacao; nenhum handler fiscal foi alterado.
- A politica e consultada por `Component=Saga`, `Operation=<tipo da saga>` e
  `Entity=<step>` antes de criar evento, converter correlacao ou escrever log.
- Quando habilitada em D1, a narrativa registra `SagaStarted`, `StepStarted`,
  `Waiting`, `Resumed`, `StepCompleted`, `RetryScheduled`, `Failed` e
  `SagaCompleted`, conforme as transicoes que realmente ocorrerem.
- Nenhum payload, mensagem de excecao ou dado fiscal integra o evento. Cada
  registro contem somente saga, step, correlacao, fase e instante.
- O snapshot operacional mantem uma janela limitada aos 512 eventos mais
  recentes; nao existe crescimento ilimitado em memoria.
- O teste reproduziu wait, estimulo externo, retomada, proximo step e conclusao
  usando o executor real. Com a politica desligada, a saga continuou funcional
  e a narrativa permaneceu vazia.

Continua pendente habilitar `ContingenciaFiscalStandardSaga` em homologacao e
confirmar visualmente os cinco steps no endpoint operacional da API/Worker.

### F-EXP-03 - Transicao Entre As Duas Sagas

**Correlacao externa:** Secoes 6.2 e 9.5; comprova G3.

**Alvo:** `PublicarPlanoParaSagaFiscal`, inicio de
`EmissaoFiscalCargaStandard` e `AguardarResultadoEmissaoFiscal`.

**Flags:** `SagaEvents` e somente os eventos necessarios de Worker/Inbox/Outbox.

**Captura:** raiz preservada, nova execucao por tentativa e causa ligando
publicador e consumidor.

**Aceite:** uma unica raiz reconstrui contingencia, emissao e retorno, inclusive
quando houver retry.

**Resultado da primeira rodada (2026-09-20): identidade de execucao implantada
na borda central; causalidade entre modulos devolvida ao backlog arquitetural.**

- A `CorrelationId` existente continua sendo a raiz unica da contingencia e da
  emissao fiscal; nenhum identificador concorrente foi criado para representar
  a mesma operacao.
- Cada passagem de um step pelo `SagaExecutor` recebe uma execucao identificada
  por `StepCorrelationId:Attempt`. O numero da tentativa vem do
  `ExecutionCount` ja mantido pelo step.
- A instrumentacao permanece exclusivamente no `SagaExecutor`, borda comum
  usada pelas sagas. Handlers e Workers customizados nao recebem logs nem
  telemetria de observabilidade.
- Os experimentos de `ModuleEventPublished` e `ModuleEventConsumed` que haviam
  sido colocados em handlers fiscais customizados foram removidos. Essa
  causalidade deve nascer futuramente na borda generica de Inbox/Outbox, usando
  o `messageId` persistido, sem codigo de observabilidade no negocio.
- Nenhum payload, XML, PFX, senha, mensagem fiscal ou dado de documento foi
  acrescentado aos eventos; a narrativa contem somente saga, step, raiz, fase,
  tentativa, execucao, causa e instante.
- Com `SagaEvents` desligado, a decisao retorna antes de montar os identificadores
  textuais adicionais. O fluxo de negocio continua usando seus IDs persistidos
  normalmente.
- Os testes focados comprovaram tentativas e execucoes distintas do mesmo step.

Continua pendente instrumentar a borda generica de Inbox/Outbox e depois
executar o fluxo completo em homologacao com API e Worker separados.

### F-EXP-04 - Repositories

**Correlacao externa:** Secoes 5.2, 9.3, 9.4 e 10; contribui para G4.

**Alvo:** queries efetivamente usadas pelas duas sagas.

**Flags:** primeiro `RepositoryCounters`; depois `RepositoryEvents` apenas para
uma operacao selecionada.

**Captura:** operacao, query ID, duracao e resultado. Nunca SQL nem parametros.

**Aceite:** comprovar o custo de contador e evento separadamente e desligar
ambos de forma independente.

**Resultado da primeira rodada (2026-09-20): capacidades separadas na borda
unica de repositorio.**

- `InstrumentedUnitOfWork` continua sendo o unico ponto que envolve as chamadas
  de banco; repositories e handlers customizados nao foram instrumentados.
- `RepositoryCounters` e `RepositoryEvents` sao avaliados antes de calcular
  query ID, iniciar cronometro ou entrar em `try/catch`.
- Com ambos desligados, a chamada segue diretamente para o `UnitOfWork` real.
- `RepositoryCounters` atualiza somente quantidade, falhas e duracoes
  agregadas. `RepositoryEvents` em D1, Debug ou Trace escreve o evento individual
  sem obrigar a coleta do contador.
- O evento recebe somente operacao, query ID opaco, trace, resultado e duracao.
  SQL e parametros nao atravessam a borda de telemetria.
- A politica pode manter apenas contadores, apenas eventos, ambos ou nenhum,
  sem reiniciar a aplicacao.
- O projeto `Yeshua.CQRS.Infrastructure.Shared` compilou sem erros e tres testes
  focados comprovaram desligamento antecipado, agregacao e selecao independente.

Continua pendente medir custo em homologacao nas queries usadas pelas duas sagas
e habilitar `RepositoryEvents` somente para uma operacao selecionada.

### F-EXP-05 - Integracao SEFAZ

**Correlacao externa:** Secoes 6.2, 7, 8, 9.4, 9.5 e 10; contribui para G3 e
G4.

**Alvo:** `AutorizarCTeNaSefaz` e `AutorizarMDFeNaSefaz`.

**Flags:** `ExternalCallEvents`.

**Captura:** documento, ambiente, UF/autorizador, duracao, resultado HTTP,
`cStat`, resultado tecnico e resultado de negocio.

**Aceite:** distinguir autorizado, rejeitado e indisponibilidade tecnica sem
capturar XML, PFX, senha ou chave privada.

### F-EXP-06 - D2 Direcionado

**Correlacao externa:** Secoes 5.2, 8 e 9.7; comprova G6.

**Alvo:** uma unica carga ou `EntradaFiscalContingenciaId`, com expiracao curta.

**Flags:** somente capacidades necessarias e `PayloadCapture` com lista
positiva.

**Aceite:** nenhum outro registro recebe D2; expiracao desliga automaticamente;
limite de volume interrompe a captura; solicitante, justificativa e aprovador
ficam auditados.

### F-EXP-07 - Demonstracao G1-G7

**Correlacao externa:** Secoes 11, 13, 14, 15 e 17; decide a elegibilidade do
Fiscal para suporte.

Executar tres contingencias controladas:

1. autorizacao completa;
2. rejeicao fiscal esperada;
3. falha tecnica controlada.

O PostBuild deve associar runtime, commit, snapshot, evidencias D0/D1, teste de
`NeverCapture` e uma ativacao D2. Esse e o primeiro pacote completo de
homologacao operacional do Fiscal.

## 8. Ordem De Alteracao Do Codigo

### Etapa 1 - Medir A Linha Atual

1. Criar benchmark pequeno para `Logger`, politica, Receiver e Repository.
2. Medir o fluxo Fiscal real sem novas capturas.
3. Registrar o custo atual de dicionarios e locks, que hoje ocorre mesmo sem
   detalhe.

### Etapa 2 - Contrato E Politica

1. Evoluir `OperationalTelemetryDecision` para carregar flags de capacidade.
2. Acrescentar `MasterEnabled` a politica central e local.
3. Compilar a politica recebida em snapshot imutavel.
4. Gerar IDs e masks estaticos; nao usar reflection.
5. Manter compatibilidade temporaria com `DefaultLevel` e `DefaultDepth`.

### Etapa 3 - Corte Antecipado

1. Fazer `ReciverBase` consultar a decisao antes do cronometro e do logger.
2. Fazer `RepositoryTelemetry` consultar antes de medir e agregar.
3. Fazer `Logger` respeitar flags tambem em falhas.
4. Fazer `DomainTracking` consultar mask antes de ler ou converter valor.
5. Impedir qualquer construcao de payload antes da decisao.

### Etapa 4 - Aplicar Somente Ao Fiscal

1. Adicionar politica `Fiscal/Development` e `Fiscal/Homologation` na central,
   inicialmente desligada.
2. Gerar descritores das duas sagas e dos Commands envolvidos.
3. Executar F-EXP-00 a F-EXP-05 um por vez.
4. Nao regenerar nem alterar Clinica ou APS durante os experimentos.

### Etapa 5 - Promover Para A Engine

1. Revisar custo e utilidade de cada ponto.
2. Remover instrumentacao experimental rejeitada.
3. Transformar somente os pontos aprovados em geracao padrao.
4. Regenerar um segundo aplicativo para provar generalidade.

## 9. Criterios De Desempenho

- `OFF`: zero alocacao e nenhuma primitiva de sincronizacao da telemetria.
- `D0 counters`: sem JSON e sem I/O no caminho quente; custo macro medido e
  explicitamente aceito antes da promocao.
- `D0/D1 events`: publicacao desacoplada da transacao; fila cheia descarta ou
  degrada conforme politica, nunca bloqueia negocio.
- `D2`: sempre limitado por alvo, expiracao e volume.
- Toda regressao precisa mostrar comparacao desligado/ligado; nao basta afirmar
  que o custo e pequeno.

## 10. Resultado Esperado

Ao concluir os experimentos, o Fiscal tera observabilidade controlavel e o
Yeshua tera aprendido, por medicao real, quais pontos merecem virar padrao da
Engine. Nenhum custo fica escondido: toda captura possui flag, alvo,
profundidade, validade e evidencia de custo.
