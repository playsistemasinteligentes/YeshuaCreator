# Plano De Inteligencia Operacional

Este plano tecnico e complementado por
OPERATIONAL_SUPPORT_ADOPTION_STANDARD.md, que define os conceitos, entregaveis,
evidencias e o gate minimo exigidos de fabricantes de software para o servico
de suporte SRE.

A correlacao entre esses requisitos, a implementacao factual existente no
Yeshua, as lacunas e a ordem interna de evolucao esta em
`YESHUA_SRE_IMPLEMENTATION_PLAN.md`.

## Objetivo

Criar uma camada capaz de compreender, diagnosticar e apoiar a evolucao de
sistemas Yeshua e sistemas legados. A camada deve combinar conhecimento
estatico do software, evidencias de execucao e conhecimento operacional humano.

O codigo-fonte continua sendo a evidencia final. O catalogo intermediario
serve para localizar, relacionar, recortar e explicar essa evidencia.

## Fontes De Conhecimento

- Codigo-fonte legado versionado.
- Codigo gerado e codigo `Custon` dos aplicativos Yeshua.
- DSL, migrations, schemas e entidades do Studio.
- Projetos, dependencias, APIs, filas, workers e configuracoes.
- Tabelas, queries, procedures e outros objetos de banco.
- Logs, eventos, metricas, traces, deploys e respostas de servicos externos.
- Diagnosticos confirmados, decisoes humanas e historico de incidentes.

## Piloto

O primeiro ciclo sera executado em dois recortes:

1. Um fluxo delimitado de um sistema legado.
2. O fluxo de encerramento de MDF-e no aplicativo Yeshua Fiscal.MDFe.

O piloto sera comparado por perguntas reais, e nao pelo volume de arquivos
indexados. Exemplos:

- De onde veio este valor?
- Qual metodo alterou este estado?
- Por que o processamento falhou?
- Quais arquivos e componentes serao afetados por uma mudanca?
- Esse erro ja ocorreu antes?
- Qual evidencia comprova a conclusao?

## Fases

### Fase 0 - Linha De Base

- Selecionar os dois fluxos do piloto.
- Registrar perguntas reais e respostas esperadas.
- Medir tempo atual de investigacao e dependencias manuais.

### Fase 1 - Inventario Tecnico

Catalogar arquivos, projetos, namespaces, classes, interfaces, metodos,
propriedades, parametros, endpoints, filas, tabelas, queries, configuracoes e
testes. Cada item deve possuir sistema, versao, arquivo e intervalo de linhas.

### Fase 2 - Grafo Estrutural

Registrar relacoes objetivas entre os itens:

- metodo chama metodo;
- tipo declara membro;
- endpoint invoca metodo;
- metodo consulta tabela;
- evento dispara processamento;
- teste cobre metodo.

Cada relacao deve guardar localizacao, versao, metodo de descoberta e nivel de
confianca.

### Fase 3 - Fluxo De Dados

Rastrear entradas, validacoes, transformacoes, decisoes, persistencia, eventos
e respostas. A primeira versao deve priorizar campos persistidos e dados do
fluxo de encerramento de MDF-e.

### Fase 4 - Instrumentacao Minima

Padronizar evidencias de execucao com `CorrelationId`, `ExecutionId`,
`TenantId`, aplicativo, ambiente, versao, documento, saga, evento, estado
anterior, estado posterior, resultado, erro e duracao.

No Yeshua, a instrumentacao deve ser gerada nos pontos genericos do motor. No
legado, sera aplicada somente aos pontos do recorte escolhido.

### Fase 5 - Diagnostico Corretivo

Reconstruir uma execucao completa e responder onde o fluxo iniciou, quais
etapas foram executadas, onde falhou, qual chamada externa participou, qual
decisao foi tomada e qual o estado atual.

### Fases Posteriores

Ficam deliberadamente fora do primeiro ciclo:

- previsao baseada em IA;
- automacao de alteracoes em producao;
- busca vetorial sofisticada;
- banco de grafos especializado;
- inferencia completa de regras de negocio;
- correlacao de todos os sistemas simultaneamente.

## Modelo De Confianca

Conclusoes devem ser classificadas como:

- fato observado no codigo;
- fato observado em runtime;
- confirmado por teste;
- inferencia;
- hipotese;
- conflito entre fontes;
- caminho dinamico nao resolvido.

Inferencias nunca devem ser apresentadas como fatos.

## Criterios De Avaliacao

- Precisao dos simbolos encontrados.
- Precisao das chamadas e dependencias.
- Precisao do caminho de dados.
- Percentual de respostas com evidencia de arquivo e linha.
- Tempo para localizar a causa.
- Falsos positivos e falsos negativos.
- Quantidade de perguntas respondidas sem consulta manual extensa.
- Qualidade da estimativa de impacto de uma alteracao.

## Primeira Implementacao

O `Yeshua.Engine.AIContextBuilder` sera utilizado como ponto de partida do
piloto porque ja abre solucoes C# com Roslyn/MSBuild e percorre simbolos. A
primeira entrega deve gerar um inventario versionado, com referencias exatas a
arquivos e linhas, sem transformar o `Yeshua.Engine` em um componente de
runtime ou em um agente autonomo.

`pendencia`: separar futuramente o indexador operacional do
`Yeshua.Engine.AIContextBuilder` quando o modelo do piloto estiver validado.

`observacao`: o primeiro catalogo sera estatico; telemetria, tendencia e
diagnostico serao acoplados depois que a estrutura de simbolos e evidencias
estiver comprovada.

## Resultado Da Primeira Rodada

O recorte Yeshua do Studio MDF-e gerou um inventario semantico com 1 projeto,
8 documentos e 4.559 simbolos, incluindo referencias exatas de arquivo e linha.

O projeto web legado `EmissaoCTe.API` nao pode ser carregado semanticamente no
ambiente atual porque depende de `Microsoft.WebApplication.targets` e de
componentes antigos do .NET Framework. O indexador registrou essa falha e
usou analise sintatica como fallback. O fallback gerou 1 projeto, 264
documentos, 2.048 simbolos e zero erros de parsing.

Esse resultado confirma a estrategia por camadas: primeiro catalogar o que e
possivel com evidencia exata; depois enriquecer o legado com referencias,
chamadas e dependencias conforme os projetos antigos forem disponibilizados em
um ambiente semantico compativel.

## Resultado Da Segunda Rodada

O inventario combinado da Clinica passou a abranger o Studio e os projetos
gerados de Domain, Application, API, RepositoryRead, RepositoryWrite e Worker.
Foram catalogados 8 projetos, 1.533 documentos, 51.768 simbolos e 83.304
relacoes semanticas, sem diagnosticos de carga.

As relacoes agora incluem `PROJECT_REFERENCES`, `DECLARES`, `CALLS`, `CREATES`,
`WRITES`, `USES_TYPE`, `INHERITS` e `IMPLEMENTS`. Cada chamada resolvida guarda
projeto, arquivo, linha, nivel de confianca e metodo de resolucao.

A validacao confirmou que o grafo consegue reconstruir, com evidencia de
codigo, o fluxo de insercao de sessao ate o repositorio, as atualizacoes de
status ate as queries e a saga de transcricao/resumo passando por leitura de
arquivo, Outbox, transicoes da saga e atualizacao do prontuario.

O catalogo piloto ocupa aproximadamente 123 MB em JSON. Antes de ampliar o
recorte, deve-se avaliar identificadores compactos e indices de consulta para
evitar repetir assinaturas e caminhos completos em cada relacao.

`pendencia`: registrar na geracao uma identidade de origem estavel para ligar
diretamente cada declaracao da DSL aos arquivos e simbolos gerados.

`observacao`: sem essa identidade, o grafo comprova relacoes entre o Studio e
o codigo gerado apenas quando existe uma referencia C# observavel; associacoes
baseadas somente no processo de geracao continuam sendo inferencias.

## Indice SQL De Referencias

A proxima iteracao reduz o escopo do inventario para servir como pre-consulta
do codigo-fonte. O Roslyn localiza as evidencias; o SQL seleciona os arquivos e
as cadeias relevantes; o Codex continua responsavel por ler os fontes e fazer a
analise final.

O modo `--reference-sql` preserva os modos anteriores e gera somente scripts
SQL Server, sem escolher nem alterar um banco operacional. A saida contem:

- schema normalizado e versionado por aplicativo/build;
- carga idempotente dos projetos, arquivos, simbolos e declaracoes;
- leituras, escritas e leituras/escritas de campos e propriedades;
- declaracoes e instanciacoes diretas de classes;
- chamadas diretas, construtores, acessores, interfaces e overrides;
- consultas recursivas por campo, classe ou funcao;
- lista final de arquivos candidatos com linhas e motivo da inclusao.

Aplicativo, versao e commit identificam o recorte do fonte. Tenant nao pertence
ao indice estatico. Arquivo e linha podem ser usados para desambiguar a funcao
recebida em um log.

O piloto da Clinica indexou 14 projetos (os 8 projetos de entrada e suas
dependencias compartilhadas), 1.901 arquivos, 21.944 simbolos, 30.544
referencias de campo, 1.537 instanciacoes e 35.116 relacoes de chamada. A carga
SQL gerada ocupa aproximadamente 25 MB, contra 123 MB do inventario JSON mais
amplo.

Limites conhecidos desta primeira versao:

- reflection, `dynamic` e nomes montados em texto nao sao resolvidos;
- SQL escrito como texto nao cria automaticamente uma referencia semantica ao
  campo C# correspondente;
- campos homonimos sao retornados como candidatos quando a identidade exata nao
  conecta todas as representacoes do mesmo dado;
- instanciacao significa `new` resolvido estaticamente; ativacao por container
  de DI sera enriquecida depois.

`pendencia`: validar as consultas em uma base SQL dedicada e medir precisao,
falsos positivos, falsos negativos e tempo de resposta com perguntas reais.

`pendencia`: criar uma identidade logica de campo entre Entity, Command, DTO e
repositorios gerados, reduzindo a dependencia da busca por nomes homonimos.

## API De Consulta E Orquestracao

Foi criado o projeto independente `Yeshua.OperationalIntelligence.Api`. Ele nao
possui referencia para a Engine, Clinica ou MDF-e e utiliza o database separado
`YeshuaOperationalIntelligence`.

A API cria o database quando configurada para isso, aplica migrations
versionadas e oferece consultas de aplicativos, builds, campos, classes,
funcoes e investigacoes combinadas. O `OperationalContextOrchestrator` e os
coletores continuam internos ao mesmo projeto e processo.

O primeiro coletor consulta o indice de codigo-fonte. Novas fontes devem
implementar `IContextCollector`, permitindo coletar logs, metricas, traces,
dados operacionais e APIs legadas antes de construir o pacote enviado ao GPT.

O piloto foi validado com o indice da Clinica: as pesquisas de campo, classe e
funcao retornaram fontes e cadeias reais, e uma investigacao combinada executou
o coletor de codigo com duas evidencias e nenhum aviso.
