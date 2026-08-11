# Primeiro Ciclo Do Servidor

O processo operacional permanece em tres passos.

## 1. Setup

```bash
nohup bash -c "curl -fsSL https://raw.githubusercontent.com/playsistemasinteligentes/YeshuaCreator/main/infra/bootstraps/setup.sh | bash" > /root/setup.log 2>&1 &
tail -f /root/setup.log
```

## 2. Certificado

```bash
nohup bash -c "curl -fsSL https://raw.githubusercontent.com/playsistemasinteligentes/YeshuaCreator/main/infra/bootstraps/setup-cert.sh | bash" > /root/setup-cert.log 2>&1 &
tail -f /root/setup-cert.log
```

## 3. Deploys Posteriores

```bash
curl -fsSL https://raw.githubusercontent.com/playsistemasinteligentes/YeshuaCreator/main/infra/docker/deploy.sh | bash
```

O deploy sem argumento atualiza Shared, Clinica e MDF-e. Os argumentos
`clinica`, `mdfe` e `shared` atualizam somente a unidade escolhida.
