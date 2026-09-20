# Resumo Vivo Da Evolucao Operacional

Este arquivo mostra, em linguagem direta, o que cada conceito significa, o que
ja foi implementado e qual e o passo atual. Atualiza-lo ao concluir ou alterar
qualquer rodada do plano.

Documentos de referencia:

- `OPERATIONAL_SUPPORT_ADOPTION_STANDARD.md`: requisitos externos para suporte.
- `YESHUA_SRE_IMPLEMENTATION_PLAN.md`: plano detalhado de implementacao.
- Este arquivo: situacao resumida e ponto atual.

## 1. Objetivo Geral

Construir capacidade operacional completa, ligando:

`fonte versionado -> build -> runtime -> evidencias -> diagnostico -> mudanca`

O objetivo e responder problemas e duvidas com fatos, localizar os fontes
envolvidos, comprovar a versao executada e alterar o sistema com menor risco.

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

## 3. Tres Eixos Independentes

- Severidade: gravidade do fato (`Information`, `Warning`, `Error`, `Critical`).
- Profundidade: quantidade de contexto (`D0` a `D4`).
- Modo: forma de execucao (`Live`, `Replay`, `Simulation`, `Regression`).

Um eixo nao altera automaticamente o outro. No momento, o Yeshua possui uma
base parcial de severidade e profundidade D0/D1, incluindo controle central e
sincronizacao de politica. Ainda falta o envelope uniforme que carregue os tres
eixos em toda evidencia; esse contrato pertence a R08.

## 4. Niveis De Capacidade

| Nivel | Capacidade | Estado resumido |
| --- | --- | --- |
| Y0 | Fonte versionado e pesquisavel | Implementado |
| Y1 | Build verificavel | Parcial avancado; falta homologar o gate publicado e vincular o snapshot |
| Y2 | Operacao observavel ponta a ponta | Nao implementado |
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
| G2 | Parcial avancado | runtime e fonte possuem versao; falta comprovacao automatica do mesmo artefato |
| G3 | Parcial | TraceId/CorrelationId existem; identidade universal ainda nao |
| G4 | Parcial | ha telemetria real; falta envelope seguro D0/D1 completo |
| G5 | Parcial | fonte e consultavel; evidencia runtime ainda nao e central e duravel |
| G6 | Parcial inicial | controle dirigido existe; governanca e captura D2 ainda nao |
| G7 | Parcial | pos-build existe; demonstracao integral dos gates ainda nao |

## 6. Situacao Das Rodadas

| Rodada | Entrega | Estado |
| --- | --- | --- |
| R01 | Escopo piloto Clinica | Implementado |
| R02 | Identidade imutavel do build | Implementado |
| R03 | Saude de API e Worker | Implementado |
| R04 | Telemetria e progresso | Implementado; build e testes locais aprovados, com evidencia operacional basica no ambiente publicado |
| R05 | Gate pos-build e smoke CRUD | Implementado e compilado; execucao do gate publicado pendente |
| R06 | Business smoke e vinculo ao snapshot | Pausado; nao iniciado |
| R07+ | Protecao, eixos, propagacao e diagnostico | Nao iniciado |

## 7. Ponto Atual

1. Congelar a criacao de mecanismos paralelos; evoluir somente os pontos
   arquiteturais existentes.
2. Executar F-EXP-00 no Fiscal para provar custo minimo quando desligado.
3. Executar R07 e R08 no Fiscal como uma fundacao segura: classificacao,
   `NeverCapture`, tres eixos, dois resultados e envelope operacional.
4. Executar R09 e R10 para identidade e causalidade sincronas e assincronas.
5. Consolidar D0/D1 nos pontos existentes em R11 e R12.
6. Implementar o provider e `RuntimeContextCollector` em R13 sem chamada remota
   sincrona no caminho quente.
7. Correlacionar runtime com o snapshot confirmado em R14.
8. Fechar D2 e homologar G1-G7 em R15 e R16.
9. Manter D3, D4, replay e agentes fora do caminho critico ate G1-G7 estarem
   demonstrados.

A ordem detalhada e os criterios de saida estao em
`YESHUA_SRE_IMPLEMENTATION_PLAN.md`. A proxima implementacao concreta e
F-EXP-00, seguida pela fundacao R07/R08. R06 continua util ao gate de negocio,
mas nao deve bloquear a seguranca da observabilidade.

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
