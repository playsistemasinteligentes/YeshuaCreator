# Docker Compose Do MDF-e

Infraestrutura customizada do aplicativo Fiscal.MDFe para o servidor atual.
API, Front e Migration formam um projeto Compose independente da Clinica.

O aplicativo usa o SQL Server do Shared pela rede externa `yeshua-net`, no
catalogo `MDFE`. Seu deploy nao executa `down` nem altera containers da Clinica.

