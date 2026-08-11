# Infra YeshuaCreator

A infraestrutura e mantida em paralelo aos Studios e ao codigo gerado. Executar
um Studio nao gera nem altera Docker Compose, Dockerfiles ou scripts de deploy.

## Clinica

A infraestrutura funcional da Clinica fica em:

`infra/Clinica/DockerCompose`

Ela preserva a topologia anterior: Front, API, Worker, Migration, Nginx,
SQL Server, Redis, RabbitMQ, AI Worker e AI Summarizer.

O caminho historico `infra/docker` continua valido como entrada de
compatibilidade.

## Preparar Servidor

```bash
sudo apt update && sudo apt install -y curl && \
sudo curl -fsSL https://raw.githubusercontent.com/playsistemasinteligentes/YeshuaCreator/refs/heads/main/infra/bootstraps/setup.sh | sudo bash
```

O setup prepara os diretorios persistentes, instala Docker, atualiza o
repositorio e sobe a infraestrutura da Clinica.

## Deploy Da Clinica

```bash
curl -fsSL https://raw.githubusercontent.com/playsistemasinteligentes/YeshuaCreator/refs/heads/main/infra/docker/deploy.sh | bash
```

O deploy preserva o comportamento historico: atualiza o repositorio, derruba o
Compose da Clinica, recompila as imagens, sobe SQL Server, Redis e RabbitMQ,
executa a migration e sobe os servicos com duas instancias do Front.

Atencao: o script executa `git reset --hard` e `git clean -fd` no repositorio do
servidor antes de atualizar a branch `main`.

## Certificado

```bash
curl -fsSL https://raw.githubusercontent.com/playsistemasinteligentes/YeshuaCreator/refs/heads/main/infra/bootstraps/setup-cert.sh | bash
```

Durante a emissao, o script para os containers que ocupam a porta 80 e os
restaura ao final.

## Template CSharpCQRS

O Compose inicial padrao do schema fica em:

`src/Engine/Yeshua.Engine/Dominio/CodeGeneration/Templates/Infrastructure/CSharpCQRS/DockerCompose`

Ele e uma matriz de copia unica. Depois de copiado para um aplicativo, os
arquivos tornam-se customizados e nao sao sobrescritos pela Engine.

## Seguranca

As credenciais diretas foram mantidas nesta restauracao para preservar o fluxo
operacional anterior. A externalizacao e rotacao dos segredos sera tratada em
uma etapa posterior.

O backup original permanece em:

`infra/legacy/pre-deployment-v1-2026-08-09`
