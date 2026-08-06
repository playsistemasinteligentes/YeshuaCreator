# Infra YeshuaCreator

Comandos operacionais para preparar servidor Ubuntu, emitir certificado e fazer deploy do ambiente Docker.

> Atencao: os scripts de setup/deploy usam `/root/YeshuaCreator` como diretorio padrao no servidor.

## 1. Preparar Servidor Ubuntu

Execute depois que o Ubuntu Server estiver instalado:

```bash
sudo apt update && sudo apt install -y curl && \
sudo curl -fsSL https://raw.githubusercontent.com/playsistemasinteligentes/YeshuaCreator/refs/heads/main/infra/bootstraps/setup.sh | sudo bash
```

## 2. Configurar Certificado

```bash
curl -fsSL https://raw.githubusercontent.com/playsistemasinteligentes/YeshuaCreator/refs/heads/main/infra/bootstraps/setup-cert.sh | bash
```

## 3. Deploy

```bash
curl -fsSL https://raw.githubusercontent.com/playsistemasinteligentes/YeshuaCreator/refs/heads/main/infra/docker/deploy.sh | bash
```

O deploy executa `git reset --hard`, `git clean -fd` e `git pull origin main` dentro de `/root/YeshuaCreator`. Portanto, qualquer alteracao local nao commitada no servidor sera descartada.

## 4. Deploy Em Segundo Plano

```bash
nohup bash -c "curl -fsSL https://raw.githubusercontent.com/playsistemasinteligentes/YeshuaCreator/refs/heads/main/infra/docker/deploy.sh | bash" > /root/deploy.log 2>&1 &
```

Acompanhar:

```bash
tail -f /root/deploy.log
```

## 5. Logs Dos Containers

```bash
docker compose -f /root/YeshuaCreator/infra/docker/docker-compose.yml logs --tail=100 -f --timestamps
```

## 6. Comandos Uteis

Entrar na pasta do compose:

```bash
cd /root/YeshuaCreator/infra/docker
```

Ver status:

```bash
docker compose ps
```

Subir ambiente:

```bash
docker compose up -d
```

Parar ambiente:

```bash
docker compose down
```
