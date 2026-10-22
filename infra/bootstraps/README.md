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

O deploy sem argumento atualiza Shared, Central, Clinica, APS.ADM, Fiscal, Memorias e
recarrega o Nginx. Os argumentos `central`, `clinica`, `aps-adm`, `fiscal` e
`memorias` e `shared` atualizam somente a unidade escolhida.

Os nomes dos bancos ficam em `infra/docker/deploy.env`. Um deploy completo
executa primeiro a migration da Central e depois as migrations dos aplicativos.
Somente o Front da Central e publicado.

O Nginx e validado e recarregado pelo deploy porque suas rotas conhecem os
aplicativos publicados. A limpeza dos Fronts antigos e uma operacao manual e
unica; ela nao faz parte do setup nem dos deploys seguintes.

## Backup No Setup

Responsabilidade da infraestrutura. A Engine pode gerar o template inicial do
aplicativo, mas nao instala pacotes, acessa a VPS, cria agendas nem executa backup.
Nao existe um setup de backup por aplicativo.

Depois do deploy inicial, o mesmo setup instala/prepara as ferramentas em
/opt/yeshua-backup, preserva a configuracao privada existente e chama
install.py --initialize-online. Completa somente as provas iniciais ausentes
(full, diferencial, logs, arquivos e leitura integral) usando as unidades com
limites de recursos; depois habilita as seis agendas de backup e a limpeza
diaria dos arquivos volateis as 04:30 America/Sao_Paulo, com idade de 7 dias
desde a criacao real no filesystem. A limpeza nao roda durante o setup;
detalhes e simulacao estao no README de infra/backups. Em reexecucao, nao troca
chaves, nao apaga historico e nao repete uma inicializacao ja concluida.
Falha nessa etapa e falha de setup, nao sucesso silencioso.

A instalacao atual utiliza /root/YeshuaCreator e
/root/YeshuaPrivate/production/credentials.json. Layout diferente exige revisao
explicita; o instalador recusa usar caminhos divergentes das unidades.

Nao executar setup.sh como atalho de restore: ele continua fazendo upgrade e
deploy/migrations, como antes. Recuperar primeiro pelo roteiro
[RECOVERY.md](../backups/RECOVERY.md), sem publicar nem ligar workers; somente
apos reconciliacao/aceite retornar ao deploy normal. O instalador de backup e
o mesmo em servidor novo e recuperado. Nao copiar o state vivo de backup da
origem sobre o state de outra maquina; recuperar dados e historico do repositorio
nao significa adotar os locks/recibos operacionais antigos.

## Adesao De Novos Recursos

| Recurso novo | Comportamento |
| --- | --- |
| Banco de usuario no mesmo SQL | Descoberto automaticamente; recebe full inicial na proxima rodada SQL e segue diferencial/logs conforme recovery model |
| Subpastas em /root/YeshuaStorage | Herdam a politica da area e suas exclusoes: volatile e intermediarios de render nao entram; demais grupos aguardam revisao |
| Subpastas privadas na raiz production | Entram na mesma rotina privada, incluindo apps/tenants novos |
| App publicado com Compose playsis-* em infra do repositorio | Descoberto pelos metadados Compose existentes, sem lista fixa de apps no backup |
| Bind fora das areas conhecidas | A copia de arquivos falha com pendencia de classificacao; nao assume descartavel nem copia SQL cru |
| Volume com estado em uso | Registrado para captura coordenada; nao e copiado cru pela rotina online |

Novo aplicativo ainda deve aderir normalmente ao deploy/credenciais/mounts da
infraestrutura. Isso nao e cadastro de estrategia de backup por app. Criar uma
pasta em qualquer outro lugar da VPS nao a torna protegida automaticamente.
O destino externo continua pendente, sem impedir a operacao local.
