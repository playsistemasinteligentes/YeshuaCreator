# Instalacao E Recuperacao Dos Servidores

Uma entrada por maquina. As duas entradas usam o mesmo bootstrap e perguntam
no inicio: **1 - instalar/reaplicar; 2 - recuperar backup**. Nao ha comando de
restore a executar manualmente depois: o setup coordena as fases separadas.
Repetir o mesmo comando retoma a escolha registrada nesta maquina. Nunca rode
o setup storage na VPS dos aplicativos. Requer Linux com Python 3.12 ou superior
(Ubuntu 24.04 ou superior), root e acesso aos repositorios de pacotes/imagens.

## Servidor Dos Aplicativos

```bash
curl -fsSL https://raw.githubusercontent.com/playsistemasinteligentes/YeshuaCreator/refs/heads/main/infra/bootstraps/setup.sh -o /root/yeshua-setup.sh && bash /root/yeshua-setup.sh
```

Na instalacao limpa, recebe/valida o JSON privado no inicio, prepara as mesmas
pastas, publica os aplicativos e configura backup. Pode vincular uma Storage VPS
por SSH administrativo temporario, sem guardar a senha root. Na recuperacao,
recebe o kit em /root/YeshuaRecovery/operator, lista pontos compativeis, obtem
a revisao Git capturada e restaura os dados antes de liberar os aplicativos.
Nao roda deploy normal nem migrations nesse caminho.

O certificado ja e tratado pelo setup. Se DNS/ACME nao estiver disponivel,
conclui em HTTP com HTTPS pendente; nao precisa esperar a troca de IP/DNS para
preparar o ambiente. HTTP nao protege senhas; mantenha o acesso restrito ate
habilitar HTTPS. Depois de corrigir DNS, repita o mesmo comando padrao.

## Servidor De Storage

```bash
curl -fsSL https://raw.githubusercontent.com/playsistemasinteligentes/YeshuaCreator/refs/heads/main/infra/bootstraps/setup-storage.sh -o /root/yeshua-storage-setup.sh && bash /root/yeshua-storage-setup.sh
```

Prepara apenas receptor SFTP, ferramentas e controlador/agendas; nao instala
Docker nem aplicativos. Pode ficar pronto com as origens desligadas. Na
recuperacao, repor JSON/chaves e o repositorio cifrado preservado, sem init.
Repositorio ou origem ausente aparece como pendencia, nao como restore concluido.
Em perda das duas maquinas, recuperar primeiro o storage e seu historico;
depois recuperar o servidor dos aplicativos pelo outro comando.

Execute os comandos em terminal interativo, sem nohup/redirecionar os prompts.
Credenciais e confirmacoes sao solicitadas no inicio, antes das etapas longas.
As fases, guardas e limitacoes estao em [RECOVERY.md](../backups/RECOVERY.md).

## Deploys Posteriores

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

O repositorio atual no filesystem da VPS tem papel de destino de backup, como
um volume externo, e esta local apenas para desenvolvimento/testes da arquitetura.
Nao e uma copia interna completa obrigatoria antes dos futuros destinos remotos.
Essa decisao nao significa protecao fisica externa: o destino atual continua
offsite=false enquanto fisicamente local. O instalador preserva/verifica o
destino externo ja configurado, sem fallback silencioso. A mudanca inicial de
local para SFTP e explicita pelo operador, nao pelo deploy. Multidestino segue
em planejamento; veja infra/backups/README.md, secao Storage SFTP.

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

Com uma Storage VPS controladora ja vinculada, o mesmo instalador reconhece
state/controller-owner.json: preserva as seis agendas no controlador, mantem
somente a seguranca SQL local e a limpeza volatil na origem. Nao reativa timers
legados nem executa novamente a bateria inicial na origem. A configuracao de
uma nova maquina controladora usa setup-storage.sh acima; o instalador interno
continua sendo o mesmo install.py --role controller. Nao executar o setup
completo dos aplicativos nessa maquina. Instrucoes em infra/backups/README.md.

A instalacao atual utiliza /root/YeshuaCreator e
/root/YeshuaPrivate/production/credentials.json. Layout diferente exige revisao
explicita; o instalador recusa usar caminhos divergentes das unidades.

Escolher recuperar no inicio do setup em uma maquina vazia. O caminho de
recuperacao nao chama o deploy/migrations; os servicos so sao liberados apos
arquivos, SQL e acessos verificados. Backups antigos sem contrato exigem o
roteiro assistido de [RECOVERY.md](../backups/RECOVERY.md). O instalador de backup
e o mesmo em servidor novo e recuperado. Nao copiar o state vivo de backup da
origem sobre o state de outra maquina; recuperar dados e historico do repositorio
nao significa adotar os locks/recibos operacionais antigos.

## Adesao De Novos Recursos

| Recurso novo | Comportamento |
| --- | --- |
| Banco de usuario no mesmo SQL | Descoberto automaticamente; recebe full inicial na proxima rodada SQL e segue diferencial/logs conforme recovery model |
| Subpastas em /root/YeshuaStorage/persistent | Entram integralmente; volatile fica fora. A aplicacao escolhe a area pelo StorageLocation |
| Subpastas privadas na raiz production | Entram na mesma rotina privada, incluindo apps/tenants novos |
| App publicado com Compose playsis-* em infra do repositorio | Descoberto pelos metadados Compose existentes, sem lista fixa de apps no backup |
| Bind fora das areas conhecidas | A copia de arquivos falha com pendencia de classificacao; nao assume descartavel nem copia SQL cru |
| Volume com estado em uso | Registrado para captura coordenada; nao e copiado cru pela rotina online |

Novo aplicativo ainda deve aderir normalmente ao deploy/credenciais/mounts da
infraestrutura. Isso nao e cadastro de estrategia de backup por app. Criar uma
pasta em qualquer outro lugar da VPS nao a torna protegida automaticamente.
Sem destino externo configurado, a pendencia nao impede a operacao local.
Se houver SFTP, a chave e o known_hosts ficam na raiz privada e devem ser
repostos no inicio junto com credentials.json, antes de validar o backup.
