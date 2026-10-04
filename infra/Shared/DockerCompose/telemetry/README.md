# Yeshua Telemetry

Pacote unico inicial de observabilidade para o Yeshua. Ele usa a imagem oficial
`grafana/otel-lgtm`, que junta OpenTelemetry Collector, Prometheus, Tempo, Loki
e Grafana em um container.

## Retencao inicial

- Prometheus: 5 dias ou 2 GB, o que chegar primeiro.
- Loki: 5 dias.
- Tempo: 5 dias.
- Docker log do proprio container: 3 arquivos de 10 MB.

O limite forte de volume total depende do servidor. Para manter o alvo de 10 GB,
monte `/root/YeshuaDB/persistent/telemetry` sobre uma particao, disco ou volume
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
YESHUA_TELEMETRY_OTLP_ENDPOINT=http://yeshua-telemetry:4317
```

Em execucao local, se essa variavel nao existir, o codigo continua em
`ConsoleJsonl`.

O controle runtime D0/D1 continua separado e volatil. Esta configuracao decide
somente o destino de saida da telemetria habilitada.
