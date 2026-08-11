# Infraestrutura Compartilhada

Servicos pertencentes ao servidor fisico: SQL Server, Redis, RabbitMQ, nginx,
rede Docker e volumes persistentes.

Os aplicativos usam projetos Compose independentes e se conectam a rede
externa `yeshua-net`. O Shared nunca e derrubado por um deploy de aplicativo.

