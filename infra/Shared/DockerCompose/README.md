# Infraestrutura Compartilhada

Servicos pertencentes ao servidor fisico: SQL Server, Redis, RabbitMQ, nginx,
Operational Intelligence API, rede Docker e volumes persistentes.

Os aplicativos usam projetos Compose independentes e se conectam a rede
externa `yeshua-net`. O Shared nunca e derrubado por um deploy de aplicativo.

A Operational Intelligence API e compartilhada por todos os aplicativos. Seu
controle HTTP fica acessivel no proprio servidor em `127.0.0.1:5728`; os
aplicativos acessam `http://operational-intelligence-api:5728` pela rede Docker.
