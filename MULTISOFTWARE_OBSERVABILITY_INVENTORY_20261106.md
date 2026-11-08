# Inventario Inicial De Observabilidade Da Multisoftware

Data do levantamento: 06/11/2026.

Estado: inventario somente leitura. Nenhuma alteracao foi realizada no
repositorio da Multisoftware ou na infraestrutura.

## 1. Escopo E Confianca

O levantamento foi executado sobre o repositorio local `MultiCTe`, branch
`release/8.2.0/8.2.0.15`, e complementado por leitura de tags posteriores.

Classificacao das conclusoes:

- **Confirmado no codigo**: existe evidencia direta no repositorio analisado.
- **Confirmado no historico**: existe evidencia direta em tag posterior.
- **Indicado por ferramenta operacional**: scripts do proprio repositorio
  demonstram uso pratico, mas a instalacao atual ainda precisa ser consultada.
- **A validar no ambiente**: depende de servidor, agente, licenca ou
  configuracao externa nao presente no repositorio.

## 2. Resumo Executivo

A Multisoftware ja possui tres caminhos de observabilidade, mas eles nao formam
uma arquitetura unica:

1. logs por Serilog para arquivo, console, Graylog ou destino TCP/UDP;
2. metricas de jobs por DogStatsD para o agente Datadog;
3. health checks HTTP proprios em algumas aplicacoes.

Na linha 8.2 analisada nao existe uma fundacao uniforme de OpenTelemetry nem
exportacao OTLP. Em versoes posteriores foi introduzido `ActivitySource` para
traces de jobs, consumido pelo tracer da Datadog, mas sem configuracao oficial
do SDK OpenTelemetry ou de um exportador OTLP encontrada no codigo inspecionado.

Grafana nao aparece como destino no codigo. Se ele exibe telemetria, consulta
um backend externo que deve ser identificado no servidor. O Portal CI tambem
nao foi localizado como componente deste repositorio e precisa ser inventariado
separadamente.

## 3. Logs

### 3.1 Caminho Compartilhado

**Confirmado no codigo** em `Servicos/Global/Log.cs`:

- fachada estatica `Servicos.Log`;
- Serilog como implementacao;
- metodos para erro, informacao, advertencia e debug;
- captura automatica de membro, arquivo e linha do chamador;
- cache de loggers por destino;
- falha do logger protegida para nao interromper o fluxo principal.

### 3.2 Destinos Implementados

**Confirmado no codigo**:

| Destino | Transporte | Observacao |
| --- | --- | --- |
| Arquivo local | arquivo texto | gravado na pasta `Log` da aplicacao |
| Console | stdout | usado junto do arquivo |
| Debug | debug output | somente em desenvolvimento |
| Graylog | GELF TCP ou UDP | sink dedicado do Serilog |
| Log Web generico | TCP ou UDP | JSON enviado para URL e porta configuradas |

Nao existe envio direto para Grafana. Grafana e uma camada de visualizacao e,
se estiver exibindo logs, existe outro armazenamento ou servico entre ele e a
aplicacao.

### 3.3 Configuracao

**Confirmado no codigo**:

- a entidade usa a tabela `T_CONFIGURACAO_LOG`;
- a primeira configuracao retornada pelo repository e usada como padrao;
- sao configuraveis arquivo, Log Web e Graylog;
- URL, porta e TCP/UDP sao configuraveis;
- Error, Info, Warning e Debug podem ser ligados ou desligados;
- em Debug, arquivo fica ligado e Graylog/Log Web ficam desligados;
- Graylog tambem aceita `GRAYLOG_HOST` e `GRAYLOG_PORT` como fallback;
- a porta padrao do Graylog e 12201.

A tela de configuracao da aplicacao permite ler e gravar os campos do Graylog.

### 3.4 Estrutura Dos Eventos

Na linha 8.2, os eventos incluem ou podem incluir:

- aplicacao executavel;
- cliente;
- prefixo/categoria;
- timestamp;
- mensagem;
- membro chamador;
- caminho do arquivo;
- numero da linha;
- nivel Serilog.

Nao foi encontrado um contrato universal com `TraceId`, `SpanId`, versao,
commit e identidades causais em todos os logs.

### 3.5 Uso Operacional Do Graylog

**Indicado por ferramenta operacional**:

O repositorio possui um kit SRE com consulta direcionada a API do Graylog 5 ou
superior. A ferramenta:

- consulta por categoria, metodo, texto, tenant, servidor e aplicacao;
- agrupa mensagens por assinatura;
- compara volume com o dia anterior;
- mascara credenciais e dados pessoais;
- limita a janela e a quantidade de amostras;
- registra a consulta realizada;
- trata o Graylog como fonte oficial para investigacao de chamados.

O proprio kit informa que campos como tenant, categoria e metodo variam por
versao e se tornam mais consistentes a partir da linha 8.3.2.

### 3.6 Riscos E Lacunas Dos Logs

- excecoes podem ser gravadas com `Exception.ToString()` completo;
- objetos podem ser serializados integralmente;
- nao foi identificado rate limiting no caminho compartilhado;
- polling e catches repetitivos podem produzir grande volume;
- identidade e campos mudam entre versoes;
- retencao, streams, indices e volume atual do Graylog dependem do ambiente;
- o destino Log Web generico precisa ser identificado no servidor;
- nao ha correlacao universal entre log e trace na linha 8.2.

## 4. Metricas E Datadog

### 4.1 Instrumentacao DogStatsD

**Confirmado no codigo**:

`SGT.BackgroundWorkers/Utils/JobMetricsHelper.cs` utiliza o cliente DogStatsD e
publica:

| Metrica | Tipo | Finalidade |
| --- | --- | --- |
| `job.execution.count` | Counter | execucoes por job e resultado |
| `job.duration.ms` | Histogram | duracao da execucao |
| `job.cpu_time.ms` | Gauge | CPU consumida no ciclo |
| `job.memory.mb` | Gauge | memoria do processo ao final |

Tags atuais:

- nome do job;
- tenant sanitizado;
- sucesso ou falha.

O projeto referencia `DogStatsD-CSharp-Client` e `JustEat.StatsD`.

### 4.2 Ponto De Medicao

**Confirmado no codigo**:

`LongRunningProcessBase` mede cada execucao nao ignorada com `Stopwatch`, tempo
de CPU e memoria do processo. A metrica e publicada no `finally`, tanto para
sucesso quanto para falha.

### 4.3 Inicializacao

**Confirmado no codigo**:

- a inicializacao conhecida fica no startup do `SGT.WebAdmin`;
- exige `StatsD:Enabled=true`;
- host, porta e prefixo sao configuraveis;
- os padroes sao localhost, porta 8125 e prefixo `sgt.webadmin`;
- essas chaves nao aparecem no `appsettings.json` versionado da aplicacao.

Isso indica configuracao por transformacao, arquivo de deploy ou variavel
externa. A configuracao efetiva precisa ser lida no servidor.

Permanece uma lacuna importante: confirmar se o host Windows Service que roda
os jobs inicializa o helper. Se nao inicializar, o codigo de medicao existe,
mas retorna sem publicar metricas nesse processo.

### 4.4 Riscos E Lacunas Das Metricas

- tenant como tag pode elevar cardinalidade e custo;
- gauge de memoria representa o processo inteiro, nao apenas o job;
- CPU e calculada como delta do processo e pode misturar execucoes concorrentes;
- nao ha medicao explicita de backlog, espera, vazao ou entrada na fila;
- nao ha prova local de que `StatsD:Enabled` esteja ativo em producao;
- nao foi inventariado o conjunto de dashboards e monitores do Datadog;
- nao foi inventariado custo, retencao ou volume de series.

## 5. Traces

### 5.1 Linha 8.2

**Confirmado no codigo**:

Nao foram encontradas referencias a:

- `ActivitySource`;
- SDK oficial do OpenTelemetry;
- exportador OTLP;
- variaveis `OTEL_EXPORTER_OTLP_*`;
- Collector OpenTelemetry.

### 5.2 Evolucao Em Versoes Posteriores

**Confirmado no historico**:

A tag 8.3.1.5 possui `ActivitySource` no servico periodico de jobs e inicializa
DogStatsD no host de jobs. O comentario do codigo indica que o tracer .NET da
Datadog e o consumidor esperado dessas Activities.

Nao foi encontrada configuracao oficial de SDK OpenTelemetry e OTLP na tag
8.4.0.0 inspecionada.

Conclusao: existe um inicio de instrumentacao compativel com OpenTelemetry, mas
a arquitetura permanece dependente da ativacao do tracer Datadog e ainda nao
usa OTLP como fronteira neutra.

## 6. Health Checks

**Confirmado no codigo**:

Existem endpoints de health check em:

- `SGT.WebAdmin`;
- `SGT.WebService`;
- `SGT.WebService.REST`;
- `ReportApi`.

Os checks analisados validam conectividade com:

- banco administrativo da Multisoftware;
- banco do tenant ou aplicacao.

Lacunas:

- nao existe um contrato unico de liveness e readiness para todos os hosts;
- Worker nao apareceu com um health endpoint equivalente;
- nao foi confirmada a coleta desses endpoints por Datadog, Grafana ou Portal CI;
- os checks nao comprovam progresso das filas ou funcionamento das dependencias
  externas.

## 7. Grafana

**Confirmado no codigo**:

Nao foram encontradas integracoes de aplicacao com Grafana.

**A validar no ambiente**:

- endereco e versao;
- data sources cadastrados;
- dashboards existentes;
- regras de alerta;
- se consulta Graylog, Datadog, SQL Server ou outro backend;
- autenticacao e permissoes;
- retencao e origem real de cada painel.

## 8. Portal CI

**A validar no ambiente**:

O Portal CI citado nas conversas nao foi identificado como projeto deste
repositorio. Precisamos registrar:

- repositorio e responsavel;
- banco utilizado;
- indicadores armazenados;
- fontes de dados;
- APIs, jobs ou integrações de entrada;
- retencao;
- consumidores e permissoes;
- possibilidade de assumir a projecao da Inteligencia Operacional.

Nao se deve decidir que o Portal CI armazenara telemetria bruta antes desse
levantamento. A recomendacao inicial permanece guardar nele estado consolidado,
incidentes e recomendacoes.

## 9. Topologia Atual Mais Provavel

Com base apenas nas evidencias disponiveis:

```text
Aplicacoes e Workers
  |-- Servicos.Log / Serilog
  |     |-- arquivo e console
  |     |-- Graylog
  |     `-- destino TCP/UDP generico
  |
  |-- JobMetricsHelper / DogStatsD
  |     `-- Datadog Agent -> Datadog
  |
  `-- Health checks HTTP

Graylog, Datadog, Grafana e Portal CI
  `-- relacoes exatas ainda dependem do inventario do ambiente
```

## 10. Comparacao Com A Referencia Yeshua

| Capacidade | Multisoftware atual | Referencia Yeshua | Lacuna principal |
| --- | --- | --- | --- |
| Logs | Serilog + Graylog/rede | OpenTelemetry logs + Loki | contrato e correlacao uniformes |
| Metricas | DogStatsD parcial | OpenTelemetry Metrics + Prometheus | OTLP, backlog, vazao e cardinalidade |
| Traces | ausente na 8.2; Activity em versoes novas | ActivitySource + OTLP + Tempo | SDK/exportador e cobertura ponta a ponta |
| Coleta | agentes externos separados | Collector como fronteira | inventario e decisao de transicao |
| Visualizacao | Grafana e Datadog mencionados | Grafana sobre backends definidos | fontes reais do Grafana |
| Inteligencia | Portal CI a mapear | Inteligencia Operacional | modelo, APIs e estado consolidado |
| Filas | duracao de job | espera, execucao, backlog e vazao | fatos por fila e item |
| Identidade | campos variam por versao | identidade gerada e consistente | recurso, versao e causalidade |

## 11. Proximas Verificacoes No Ambiente

Sem alterar configuracao, coletar:

1. versao e configuracao do Datadog Agent;
2. arquivos efetivos com `StatsD:Enabled`, host, porta e prefixo;
3. processos que carregam `JobMetricsHelper`;
4. dashboards, monitores e volume do Datadog;
5. URL, versao, inputs, streams, indices e retencao do Graylog;
6. volume por aplicacao, nivel e assinatura no Graylog;
7. endereco, data sources, dashboards e alertas do Grafana;
8. arquitetura, banco e interfaces do Portal CI;
9. destino e finalidade do Log Web TCP/UDP;
10. quais health checks sao consultados atualmente;
11. custos mensais de Datadog e armazenamento de logs;
12. requisitos de seguranca e isolamento por tenant.

## 12. Conclusao

A Multisoftware nao parte do zero. Ela ja possui Graylog, metricas DogStatsD,
Datadog e health checks, mas cada capacidade nasceu separadamente. O primeiro
passo de evolucao deve ser introduzir uma fronteira OpenTelemetry/OTLP sem
remover o que funciona.

O piloto deve padronizar um Worker e uma fila, exportar traces e metricas por
OTLP para a infraestrutura existente e comparar cobertura, custo e volume.
Somente depois desse resultado deve ser avaliada a introducao de Collector,
Prometheus, Loki e Tempo ou a retirada gradual de recursos do Datadog.

