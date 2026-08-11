# Docker Compose Da Clinica

Esta infraestrutura pertence ao aplicativo Clinica. Ela foi restaurada a partir
do backup funcional `infra/legacy/pre-deployment-v1-2026-08-09` e ajustada para
os projetos `Yeshua.Clinica.CQRS.*`.

Os arquivos deste diretorio sao customizados e nao devem ser sobrescritos pela
Engine. O template de origem fica em:

`src/Engine/Yeshua.Engine/Dominio/CodeGeneration/Templates/Infrastructure/CSharpCQRS/DockerCompose`

Deploy:

```bash
curl -fsSL https://raw.githubusercontent.com/playsistemasinteligentes/YeshuaCreator/refs/heads/main/infra/docker/deploy.sh | bash
```

O caminho `infra/docker` e mantido como compatibilidade operacional e encaminha
para este diretorio.

