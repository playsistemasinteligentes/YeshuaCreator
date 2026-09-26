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

O deploy sem argumento atualiza Shared, Central, Clinica, APS.ADM, Fiscal e
recarrega o Nginx. Os argumentos `central`, `clinica`, `aps-adm`, `fiscal` e
`shared` atualizam somente a unidade escolhida.

Os nomes dos bancos ficam em `infra/docker/deploy.env`. Um deploy completo
executa primeiro a migration da Central e depois as migrations dos aplicativos.
Somente o Front da Central e publicado.

O Nginx e validado e recarregado pelo deploy porque suas rotas conhecem os
aplicativos publicados. A limpeza dos Fronts antigos e uma operacao manual e
unica; ela nao faz parte do setup nem dos deploys seguintes.
