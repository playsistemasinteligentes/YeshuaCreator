# Infra YeshuaCreator

A infraestrutura e declarada por aplicativo e agregada por ambiente. O ambiente
`Production` compartilha os recursos de maquina, mas permite implantar Clinica e
MDF-e separadamente.

## Gerar Os Manifestos

Execute primeiro os aplicativos e depois o ambiente:

```bash
dotnet run --project src/Studio/Yeshua.Studio.AppClinicas -- --deployment-only
dotnet run --project src/Studio/Yeshua.Studio.Fiscal.MDFe -- --deployment-only
dotnet run --project src/Studio/Yeshua.Studio.Environment.Production
```

As saidas ficam em:

- `infra/Clinica/Migration/deployment-model.json`
- `infra/Fiscal.MDFe/Migration/deployment-model.json`
- `infra/Environments/Production/Migration`

## Bootstrap Da Maquina

O bootstrap instala Docker, prepara os diretorios persistentes e baixa o
repositorio. Ele nao implanta aplicativos.

```bash
sudo apt update && sudo apt install -y curl && \
sudo curl -fsSL https://raw.githubusercontent.com/playsistemasinteligentes/YeshuaCreator/refs/heads/main/infra/bootstraps/setup.sh | sudo bash
```

## Referencias De Segredo

Antes do primeiro deploy, crie o arquivo `.env` no servidor:

```bash
cd /root/YeshuaCreator/infra/Environments/Production/Migration
cp .env.example .env
```

O `.env.example` contem apenas os nomes esperados. A definicao e provisao dos
valores sera tratada em uma etapa posterior.

## Deploy Independente

Clinica:

```bash
/root/YeshuaCreator/infra/Environments/Production/Migration/deploy-clinica.sh
```

MDF-e:

```bash
/root/YeshuaCreator/infra/Environments/Production/Migration/deploy-fiscal-mdfe.sh
```

Todos os aplicativos:

```bash
/root/YeshuaCreator/infra/Environments/Production/Migration/deploy-all.sh
```

O script de compatibilidade tambem aceita um destino:

```bash
curl -fsSL https://raw.githubusercontent.com/playsistemasinteligentes/YeshuaCreator/refs/heads/main/infra/docker/deploy.sh | bash -s -- clinica
curl -fsSL https://raw.githubusercontent.com/playsistemasinteligentes/YeshuaCreator/refs/heads/main/infra/docker/deploy.sh | bash -s -- mdfe
```

Nenhum deploy executa `docker compose down`, `git reset` ou `git clean`.

## Certificado

Depois que o gateway HTTP estiver no ar:

```bash
curl -fsSL https://raw.githubusercontent.com/playsistemasinteligentes/YeshuaCreator/refs/heads/main/infra/bootstraps/setup-cert.sh | bash
```

O script le o dominio do manifesto, emite o certificado, habilita a configuracao
HTTPS previamente gerada e reinicia somente o gateway.

## Pendencia Conhecida

Em uma maquina totalmente vazia, os catalogos `CLINICA` e `MDFE` ainda precisam
existir antes das migrations. A criacao automatica dos catalogos sera definida
junto da estrategia de segredos do SQL Server.

O backup da infraestrutura anterior esta em
`infra/legacy/pre-deployment-v1-2026-08-09`.
