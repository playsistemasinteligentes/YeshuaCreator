# Resumo Vivo Da Evolucao Operacional

Este arquivo mostra, em linguagem direta, o que cada conceito significa, o que
ja foi implementado e qual e o passo atual. Atualiza-lo ao concluir ou alterar
qualquer rodada do plano.

Documentos de referencia:

- `OPERATIONAL_SUPPORT_ADOPTION_STANDARD.md`: requisitos do padrao para
  agentizacao da fabricacao, evolucao e manutencao de software.
- `YESHUA_SRE_IMPLEMENTATION_PLAN.md`: plano detalhado de implementacao.
- Este arquivo: situacao resumida e ponto atual.

## 1. Objetivo Geral

Construir capacidade operacional completa, ligando:

`necessidade -> concepcao -> planejamento -> fabricacao -> validacao -> entrega
-> implantacao -> uso -> operacao -> manutencao e evolucao`

Cada etapa deve produzir evidencias utilizaveis pelas etapas seguintes. O
objetivo imediato continua sendo tornar runtime, fonte e resultado
reconstruiveis; o objetivo final e permitir que agentes autorizados usem essas
evidencias para apoiar a construcao, validacao, entrega, manutencao e evolucao
do software.

## 2. Conceitos Sem Mistura

### Engenharia Reversa E Contexto De Codigo

Le o fonte confirmado, cria indice semantico e textual e seleciona os arquivos
relevantes para uma pergunta. Nao observa o sistema em execucao.

### Telemetria

Sao os dados produzidos durante a execucao: inicio, fim, falha, duracao,
contadores, progresso e chamadas de repositorio.

### Observabilidade

E a capacidade de compreender o estado do sistema usando telemetria, health,
logs, metricas e traces. Telemetria e materia-prima; observabilidade e a
capacidade obtida com ela.

### Testes E Gates

Executam o sistema de forma controlada para comprovar que um build funciona.
Nao substituem observabilidade. Produzem evidencias de demonstracao e impedem
que um artefato invalido seja considerado aprovado.

### Inteligencia Operacional

Correlaciona codigo, versao, runtime, telemetria, configuracao e resultados de
testes para apoiar diagnostico, manutencao e, futuramente, agentes operacionais.

## 3. Evidencia E Escopo De Captura

- Severidade: gravidade do fato (`Information`, `Warning`, `Error`, `Critical`).
- Profundidade: quantidade de contexto (`D0` a `D4`).
- Escopo: componente, operacao, entidade, registro e campo selecionados.

Severidade e profundidade nao se alteram automaticamente. O contrato tipado e
o envelope uniforme foram implementados no Shared. As evidencias de Command,
Repository, Saga e DomainTracker publicam severidade e profundidade, enquanto
a politica operacional seleciona o escopo. Reproducao, simulacao e regressao
sao capacidades futuras que consumirao as evidencias, nao modos globais da
politica.

## 4. Niveis De Capacidade

| Nivel | Capacidade | Estado resumido |
| --- | --- | --- |
| Y0 | Fonte versionado e pesquisavel | Implementado |
| Y1 | Build verificavel | Parcial avancado; falta homologar o gate publicado e vincular o snapshot |
| Y2 | Operacao observavel ponta a ponta | Parcial; envelope seguro D0/D1 implantado nas bordas comuns |
| Y3 | Diagnostico dirigido | Nao implementado |
| Y4 | Reproducao segura | Nao implementado |
| Y5 | Operacao assistida | Conceito |
| Y6 | Prevencao inteligente | Conceito |

## 5. O Que Ja Foi Implementado

### Codigo E Versao

- Engenharia reversa de snapshots confirmados por commit.
- Indice Roslyn e indice textual complementar.
- API de consulta e bundle de fontes relevantes.
- Identidade runtime com aplicativo, ambiente, versao, commit e horario do build.

### Runtime E Telemetria

- Liveness e readiness basicos de API e Worker.
- Telemetria centralizada em `ReciverBase.Execute`.
- Estatisticas de Commands e repositorios em memoria.
- Contrato de progresso para ciclos de Worker.
- Endpoint de snapshot de telemetria.
- Logs estruturados em JSON enviados ao stdout dos containers.
- Envelope operacional tipado com severidade, profundidade, resultado
  tecnico e resultado de negocio independentes.
- Publicador unico de evidencias para Command, Repository, Saga e
  DomainTracker, preservando `Level`, `Category` e `Data` para o Loki.
- Classificacao `Public`, `Internal`, `Confidential`, `Restricted` e
  `NeverCapture`, aplicada antes do sink.
- Bloqueio de nomes proibidos tanto nos logs quanto nos spans antes dos
  exportadores JSONL ou OTLP.

### Controle Operacional Antecipado

- API central de politica por aplicativo e ambiente.
- Politica local singleton em API e Worker.
- Sincronizacao por polling sem reiniciar os aplicativos.
- Baseline D0 e ativacao D1.
- Endpoint gerado para consultar a politica efetivamente carregada no aplicativo.

Essa parte foi antecipada de rodadas futuras e foi a principal causa da mistura
de assuntos durante R04.

### Testes

- TestKit HTTP generico.
- Suites CRUD geradas por aplicativo.
- Smoke CRUD da Clinica gerado e orquestrado pelo runner pos-build; execucao
  contra o ambiente publicado permanece pendente.

## 5.1 Avaliacao Dos Gates Externos

| Gate | Estado | Resumo |
| --- | --- | --- |
| G1 | Parcial | piloto documentado; governanca ainda nao generalizada |
| G2 | Parcial avancado | runtime resolve versao/commit e seleciona o snapshot correspondente; falta comprovacao no artefato publicado |
| G3 | Parcial avancado | identidade sincrona universal implementada; falta propagacao assincrona por Outbox, Inbox, Saga e Worker |
| G4 | Parcial avancado | envelope seguro implantado nas bordas comuns; faltam descritores gerados e demonstracao integral |
| G5 | Parcial avancado | fonte e runtime sao consultaveis pela API central; falta homologar retencao e auditoria no ambiente publicado |
| G6 | Parcial avancado | D2 dirigido, temporario, limitado e auditado foi implementado; falta demonstracao integrada |
| G7 | Parcial avancado | pos-build e bundle separam fatos, inferencias e lacunas; demonstracao integral ainda nao |

## 6. Situacao Das Rodadas

| Rodada | Entrega | Estado |
| --- | --- | --- |
| R01 | Escopo piloto Clinica | Implementado |
| R02 | Identidade imutavel do build | Implementado |
| R03 | Saude de API e Worker | Implementado |
| R04 | Telemetria e progresso | Implementado; build e testes locais aprovados, com evidencia operacional basica no ambiente publicado |
| R05 | Gate pos-build e smoke CRUD | Implementado e compilado; execucao do gate publicado pendente |
| R06 | Business smoke e vinculo ao snapshot | Pausado; nao iniciado |
| R07 | Classificacao e protecao de dados | Parcial avancado; classificacao estatica gerada por campo, convencoes, complemento pela DSL, regras de profundidade e barreira `NeverCapture` implementados; faltam retencao por profundidade e homologacao integrada de vazamento |
| R08 | Evidencia, escopo e dois resultados | Implementado em codigo e validado localmente; severidade e profundidade sao independentes, e o escopo e controlado pelo snapshot da politica |
| R09 | Identidade e propagacao sincrona | Implementado em codigo e validado localmente; Engine gera raiz, operacao, execucao e causa nas bordas HTTP, Command, Receiver, dominio e repository |
| R10 | Propagacao assincrona e causalidade | Implementado e validado localmente no piloto HTTP do Fiscal; envelope de fila preparado e testado, com consumidor RabbitMQ real pendente de homologacao integrada |
| R11 | Eventos operacionais essenciais | Implementado e validado localmente para Commands do Fiscal; baseline D0 inclui inicio, termino, identidade runtime e operacional, duracao, outcomes e erro sanitizado |
| R12 | Narrativa operacional | Parcial avancado; Saga, Inbox/Outbox, SQL e chamada HTTP real emitem D1, e a Engine gera a entrada por contrato declarado; faltam estados de entrega/consumo, autenticacao/homologacao da entrada, SEFAZ e demonstracao integrada |
| R13 | Provider, consulta e coletor runtime | Implementado em codigo e validado localmente sobre o Loki existente; homologacao publicada pendente |
| R14 | Correlacao automatica runtime-codigo | Implementado em codigo e validado localmente; homologacao com evidencias publicadas pendente |
| R15 | Diagnostico direcionado | Implementado em codigo e validado localmente; demonstracao integrada pendente |
| R16 | Homologacao operacional | Estrutura G1-G7 implementada e validada localmente; execucao dos cenarios publicados pendente |

## 7. Ponto Atual

1. Congelar a criacao de mecanismos paralelos; evoluir somente os pontos
   arquiteturais existentes.
2. Manter a medicao quantitativa de F-EXP-00 pendente ate o fluxo estabilizar.
3. Concluir R07 com retencao por profundidade e homologacao integrada dos
   testes de vazamento.
4. Homologar a cadeia R10 no ambiente publicado e validar um consumidor real
   de fila quando um fluxo piloto adotar RabbitMQ.
5. Concluir R12 nas transicoes de estado da entrega/consumo, autenticacao e
   homologacao da borda gerada entre modulos, dependencias SEFAZ e demonstracao
   integrada da narrativa Fiscal.
6. Homologar o provider e `RuntimeContextCollector` de R13 no ambiente
   publicado, incluindo indisponibilidade do Loki.
7. Homologar a correlacao automatica de R14 com runtime e snapshots publicados.
8. Executar os cenarios publicados e alimentar o relatorio G1-G7 de R16.
9. Manter D3, D4, replay e agentes fora do caminho critico ate G1-G7 estarem
   demonstrados.

A ordem detalhada e os criterios de saida estao em
`YESHUA_SRE_IMPLEMENTATION_PLAN.md`. R11 esta concluida para Commands do
piloto Fiscal e R12 esta parcial avancada. R13 agora consulta evidencias do
Loki pelo orquestrador central usando aplicacao, versao, periodo e identidades
operacionais, sem chamada sincrona aos aplicativos. R14 usa a versao e o commit
dos rotulos do Loki para selecionar o snapshot confirmado, resolve sinais dos
logs e produz bundle com fatos, inferencias e lacunas separados. O proximo
avanco estrutural foi entregue em R16: o PostBuild agora consolida G1-G7,
mantem gates sem prova como `Missing` e pode exigir todos os gates no modo
final. Permanece pendente executar os cenarios no ambiente publicado.
A medicao quantitativa de
F-EXP-00 permanece registrada, mas nao bloqueia esse avanco enquanto as bordas
ainda estao evoluindo.

O roteiro detalhado de custo e seletores do piloto Fiscal esta em
`docs/operational/fiscal/FISCAL_OPERATIONAL_EXPERIMENT_PLAN.md`.

## 8. Regra De Atualizacao

Ao final de cada passo:

1. registrar o que foi realmente implementado;
2. registrar a evidencia executada;
3. manter como pendente o que nao foi validado;
4. vincular a entrega a taxonomia do documento externo;
5. tratar conceito interno sem correspondencia externa como lacuna da especificacao antes de implementa-lo definitivamente;
6. atualizar a rodada e o nivel de capacidade;
7. somente depois iniciar a proxima rodada.
