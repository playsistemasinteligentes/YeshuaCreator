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
