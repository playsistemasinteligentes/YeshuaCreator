# Yeshua Observability

Pacote unico inicial de observabilidade para o Yeshua. Ele usa a imagem oficial
`grafana/otel-lgtm`, que junta OpenTelemetry Collector, Prometheus, Tempo, Loki
e Grafana em um container.

Servico/container: `yeshua-observability`. O nome anterior `yeshua-telemetry`
continua como alias de rede. Configuracoes ficam na pasta `observability`;
o bind `/root/YeshuaStorage/volatile/infra/telemetry` foi preservado, sem mover
ou apagar dados. Grafana usa `/observability/`, com redirecionamento da rota
anterior `/telemetry/`.

## Personalizacoes E Recuperacao

Decisao do projeto: historico de telemetria e estado interno do Grafana sao
VOLATEIS, fora do backup. Personalizacoes de paineis, alertas e fontes de dados
devem ser mantidas nos arquivos de infraestrutura versionados, usando o
provisionamento nativo do Grafana. Nao depender de alteracoes feitas somente
pela interface. Segredos continuam no arquivo privado do ambiente, fora do Git.

Na recriacao, repor a imagem/configuracao versionada e aplicar o provisionamento;
nao restaurar o banco interno para substituir essas definicoes. O Compose agora
usa /root/YeshuaStorage/volatile/infra/telemetry. O caminho antigo nao e movido
ou apagado automaticamente e nao houve alteracao da VPS nesta implementacao.
Uma captura sobre o bind legado exige a virada intencional para a raiz volatil.
Essa regra nao muda permissoes da interface nem remove personalizacoes existentes.

## Retencao inicial

- Prometheus: 5 dias ou 2 GB, o que chegar primeiro.
- Loki: 5 dias.
- Tempo: 5 dias.
- Docker log do proprio container: 3 arquivos de 10 MB.

O limite forte de volume total depende do servidor. Para manter o alvo de 10 GB,
monte `/root/YeshuaStorage/volatile/infra/telemetry` sobre uma particao, disco ou volume
com quota de 10 GB. O Compose aplica limite de CPU/memoria do container e a
retencao por componente, mas Docker Compose puro nao limita tamanho de bind
mount de forma portavel.

No Tempo 3, a retencao nao fica mais no bloco legado `compactor`. Ela fica em
`backend_scheduler.provider.compaction.compaction` e no override padrao em
`overrides.defaults.compaction`.

## Ativacao nas aplicacoes

No servidor, o `infra/docker/deploy.env` ja deixa APIs e Workers em `Otlp` por
padrao:

```env
YESHUA_TELEMETRY_EXPORT_MODE=Otlp
YESHUA_TELEMETRY_OTLP_ENDPOINT=http://yeshua-observability:4317
```

Em execucao local, se essa variavel nao existir, o codigo continua em
`ConsoleJsonl`.

O controle runtime D0/D1 continua separado e volatil. Esta configuracao decide
somente o destino de saida da telemetria habilitada.

## Contrato De Manutencao Dos Dashboards

Os dashboards versionados em `grafana/dashboards/yeshua-overview.json` e
`grafana/dashboards/yeshua-queue-health.json` sao codigo operacional. Uma alteracao
nele pode mudar a interpretacao de saude do ambiente mesmo sem alterar a coleta.
Por isso, nao basta a consulta produzir uma linha: o painel precisa explicar
corretamente o que essa linha significa.

Todo painel deve conter uma descricao acessivel pelo icone de informacao do
Grafana, respondendo no minimo:

1. **O que mede:** sinal, origem e unidade real recebida.
2. **Como interpretar:** significado pratico de um valor e suas correlacoes.
3. **Cuidado:** o que o painel nao permite concluir isoladamente.
4. **Fonte:** receiver, metrica ou borda operacional responsavel, quando isso
   ajudar no diagnostico.

### Unidades E Conversoes

Antes de aplicar qualquer conversao, confirmar a unidade produzida na origem e
a unidade esperada pelo Grafana:

- proporcao de `0` a `1`: multiplicar uma vez por `100` e usar `percent`;
- percentual de `0` a `100`: nao multiplicar e usar `percent`;
- bytes: manter o valor em bytes e selecionar uma unidade de dados no Grafana;
- timestamp Unix em segundos: usar `time() - valor` para exibir idade em `s`;
- contador acumulado: usar `rate()` para taxa ou `increase()` para janela;
- gauge: consultar o valor atual sem transformar em taxa.

Nunca corrigir uma unidade apenas pela aparencia do grafico. Exemplo concreto:
`container.cpu.utilization` chega como proporcao e precisa de `100 *`, enquanto
`container.memory.percent` ja chega em percentual e nao pode ser multiplicada
novamente.

### Significado Visual

- Nao misturar no mesmo eixo percentuais, segundos, bytes e contagens.
- Quando duas grandezas precisarem coexistir, usar eixos e unidades explicitos;
  preferir paineis separados quando a leitura continuar ambigua.
- Titulos devem dizer o objeto e a unidade ou janela quando isso nao for obvio.
- Legendas devem identificar servico, operacao, fila ou container e mostrar
  valor atual; media e maximo sao adicionados quando ajudarem na decisao.
- `No data`, zero e ausencia de demanda sao estados diferentes e precisam ser
  explicados na ajuda do painel.
- Limites coloridos representam orientacao inicial. Eles nao substituem a linha
  de base operacional nem devem transformar um pico isolado em incidente.

### Cardinalidade E Agregacao

- Prometheus recebe agregados; identificadores de entidade ou item nao podem
  virar labels de alta cardinalidade.
- Instancias de Worker podem mudar em deploy. Alertas de indisponibilidade devem
  avaliar o conjunto ativo por servico e operacao, nao uma serie antiga isolada.
- Fila, item doente e instancia de Worker sao conceitos diferentes. Backlog zero
  pode coexistir com itens em falha terminal.
- Consultas com varios servicos selecionados devem preservar o label necessario
  para nao consolidar silenciosamente realidades diferentes.

### Checklist Antes De Publicar

1. Confirmar a unidade na metrica de origem e depois da exportacao Prometheus.
2. Executar a PromQL com dado real e validar um valor conhecido.
3. Testar zero, `No data`, pico, multiplos servicos e multiplas replicas.
4. Conferir titulo, descricao, legenda, unidade, eixo, limites e tooltip.
5. Verificar se a mudanca afeta regras de alerta, MCP, runbooks ou consultas da
   Inteligencia Operacional.
6. Validar o JSON e carregar o dashboard pelo provisionamento versionado.
7. Nao manter melhoria apenas na interface do Grafana: toda alteracao oficial
   precisa voltar para os arquivos deste diretorio.

Se a metrica mudar na aplicacao, na Engine ou no Collector, revisar em conjunto
o caminho completo: geracao do sinal -> exportacao OTLP -> transformacao no
Collector -> nome/labels no Prometheus -> PromQL -> unidade e significado no
Grafana -> regra de alerta e recomendacao operacional.

### Validacao Local

Antes de publicar o pacote, executar:

```powershell
./infra/Shared/DockerCompose/observability/validate-dashboard.ps1
```

O helper valida o JSON, IDs e referencias duplicadas, descricoes obrigatorias,
consultas vazias, limites do grid, sobreposicao de paineis e conversoes de
percentual conhecidas. Ele protege a estrutura; a semantica das consultas ainda
deve ser confirmada com dados reais do Prometheus conforme o checklist acima.

## Catalogo Semantico De Observabilidade

Os dashboards desta pasta sao convertidos automaticamente para um contrato
estavel pelo MCP privado da Inteligencia Operacional:

```text
yeshua_observability_dashboards_list
yeshua_observability_dashboard_get
```

O conversor percorre todos os paineis; nao existe codigo MCP especifico para
cada grafico. As secoes em negrito da descricao (`O que mede`, `Como
interpretar`, `Fonte`, `Cuidado`, `Categorias`, `Importante` e `Custo`) viram
metadata semantica. Configuracoes do Grafana viram metadata tecnica: consultas,
datasource, unidade, modo instant/range, reducer, thresholds, overrides e
variaveis. Recursos ainda nao reconhecidos sao devolvidos como parciais e podem
ser inspecionados com `includeRaw=true`.

Para pedir a manutencao completa, use a expressao:

> **Atualize o Catalogo Semantico de Observabilidade.**

Ela significa revisar todos os dashboards, corrigir descricoes e configuracoes,
executar a validacao local, confirmar a descoberta MCP e publicar o pacote.

O dashboard `Yeshua - Diagnostico de Filas` e a entrada operacional para
decisao. Ele separa saude da fila e saude dos itens, abre a composicao das
doencas e so entao apresenta evidencias individuais. O dashboard de visao
operacional permanece como aprofundamento tecnico; nao deve ser a primeira
etapa de raciocinio para decidir se uma fila esta doente.
