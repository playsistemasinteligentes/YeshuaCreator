# Infraestrutura Compartilhada

Servicos pertencentes ao servidor fisico: SQL Server, Redis, RabbitMQ, nginx,
Operational Intelligence API, Operational Intelligence Agent, pacote de
telemetria, rede Docker e volumes persistentes.

Os aplicativos usam projetos Compose independentes e se conectam a rede
externa `yeshua-net`. O Shared nunca e derrubado por um deploy de aplicativo.

A Operational Intelligence API e compartilhada por todos os aplicativos. Seu
controle HTTP fica acessivel no proprio servidor em `127.0.0.1:5728`.

O Operational Intelligence Agent e um container interno de apoio tecnico. Ele
possui SDK .NET, Git, Node, Python, Codex CLI e Claude Code para diagnostico,
compilacao e testes em workspace proprio. Na primeira fase ele nao monta
`/var/run/docker.sock`, nao publica, nao reinicia containers e nao executa
migrations; dados operacionais devem vir da Operational Intelligence API e do
pacote de telemetria.

O controle operacional de cada aplicativo e aplicado pela propria API do
aplicativo. O Worker consulta a API do mesmo aplicativo, nao a API operacional
central.

O servico `yeshua-telemetry` e o pacote unico inicial para centralizacao OTLP:
OpenTelemetry Collector, Loki, Tempo, Prometheus e Grafana no mesmo container.
Ele guarda dados em `/root/YeshuaDB/persistent/telemetry`, com retencao padrao
de 5 dias. APIs e Workers so usam esse pacote quando
`YESHUA_TELEMETRY_EXPORT_MODE=Otlp`. O deploy de servidor ja usa `Otlp` por
padrao em `infra/docker/deploy.env`; execucoes locais sem essa variavel
continuam em `ConsoleJsonl`.
