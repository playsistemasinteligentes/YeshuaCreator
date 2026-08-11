# Docker Compose Da Clinica

Esta infraestrutura pertence ao aplicativo Clinica. Ela foi restaurada a partir
do backup funcional `infra/legacy/pre-deployment-v1-2026-08-09` e ajustada para
os projetos `Yeshua.Clinica.CQRS.*`.

Os arquivos deste diretorio sao customizados e nao devem ser sobrescritos pela
Engine. O template de origem fica em:

`src/Engine/Yeshua.Engine/Dominio/CodeGeneration/Templates/Infrastructure/CSharpCQRS/DockerCompose`

O SQL Server, Redis, RabbitMQ e nginx pertencem ao Shared do servidor. Este
Compose contem somente os containers da Clinica e usa a rede externa
`yeshua-net`.

Deploy isolado:

```bash
curl -fsSL https://raw.githubusercontent.com/playsistemasinteligentes/YeshuaCreator/refs/heads/main/infra/docker/deploy.sh | bash -s -- clinica
```

O deploy nao executa `down` e nao altera containers do MDF-e.
