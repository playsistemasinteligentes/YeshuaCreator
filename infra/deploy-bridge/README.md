# Ponte privada de deploy

`yeshua_deploy` usa exatamente a exposição/autorização administrativa existente:
`IMcpTool.IsPublic=false` e `McpToolRegistry`/`McpAccessPolicy` restringem catálogo
e execução à conexão privada pelo túnel. As quatro funções públicas permanecem
inalteradas. Não há `confirm`, aprovação externa, `approvals` ou outra autenticação
do operador. `requestId` é somente chave de deduplicação e consulta.

```json
{"action":"execute","requestId":"deploy-001","target":"all"}
```
```json
{"action":"status","requestId":"deploy-001"}
```

Destinos: `all`, `central`, `clinica`, `aps-adm`, `fiscal`, `memorias`, `presenca`, `shared`.
O helper chama somente `/bin/bash /root/YeshuaCreator/infra/docker/deploy.sh TARGET`,
sem argumento de tag nem `YESHUA_RELEASE_TAG` ou `YESHUA_SKIP_UPDATE` no ambiente.
O script executa `git reset --hard`, `git clean -fd` e `git pull origin main`
antes do build; a ponte não presume que o checkout local esteja atualizado.
Atualização Git, lock, build, migrations e serviços continuam no script existente.
`releaseTag` foi removido do schema de entrada e é recusado explicitamente,
inclusive nulo: clientes antigos devem omitir o campo. Seleção por tag permanece
desativada; todo novo deploy segue a versão mais recente de `main`. Não aceita comandos, caminhos, flags ou env livres.

A API está no container sem socket Docker e com checkout do host somente leitura.
Por isso SSH permanece apenas como transporte técnico com comando forçado, sem
shell livre. A ativação usa o provider privado existente
`shared/OperationalAgent/integracoes/providers.json`, com `"Deploy": {"Enabled": true}`.
O loader fornece as opções `Mcp:Deploy:Destination`, `IdentityFile` e
`KnownHostsFile` com destino e caminhos fixos. A chave do host fica fixada e a
chave privada permanece fora do Git, montada somente no container operacional.
Ausência dessa configuração retorna indisponibilidade, sem mecanismo alternativo.

## Instalação na estrutura atual

O deploy Shared executa `infra/deploy-bridge/install.sh` depois de subir os
serviços, quando a rede e a identidade do agente já existem. Não cria container,
servidor, transporte nem mecanismo paralelo de deploy. Sem ativação explícita,
as opções permanecem vazias; a instalação também revoga a chave autorizada da
conta técnica quando desabilitada, preservando chave privada e recibos.

O instalador cria a conta de sistema `yeshua-deploy`, com senha bloqueada e home
controlado por root em `/var/lib/yeshua-deploy`. O único authorized_keys é
controlado por root, com `restrict`, origem limitada à rede Docker `yeshua-net`
e comando forçado. Não altera o acesso SSH dos outros usuários. A conta não
pertence ao grupo Docker nem recebe sudo genérico. A única regra sudoers,
validada por visudo, é:
`yeshua-deploy ALL=(root) NOPASSWD: NOSETENV: /usr/bin/python3 -I /opt/yeshua-deploy/bridge.py`.

O helper é instalado em `/opt/yeshua-deploy/bridge.py`, root:root 0644, e os
recibos em `/root/YeshuaStorage/persistent/infra/deploy-bridge/receipts`, root:root
0700. A chave exclusiva fica em
`YeshuaPrivate/<ambiente>/shared/OperationalAgent/integracoes/deploy-bridge`,
montada somente leitura em `/run/yeshua-deploy`. Instalações repetidas reutilizam
a mesma chave. O known_hosts usa a chave pública local do host, sem ssh-keyscan
pela rede. O alias host.docker.internal usa host-gateway; não se fixa IP de container.

Reconstrução: restaurar o diretório privado e o storage persistente pelo backup
existente e executar o fluxo normal da infraestrutura. O instalador recompõe
conta, autorização, helper e permissões; fixa a identidade do host reconstruído
pela chave pública local. Não colocar a chave privada em imagem, Git ou resposta MCP.

Decisão explícita de 19/11/2026: MCP e Codex continuam no mesmo container/usuário,
tratados como uma instância administrativa confiável. Esta ativação não cria
isolamento de privilégios entre eles. A lista de tools configurada no Codex é
conveniência, não uma barreira de autorização. Separação de executores fica para
a futura frente de agrupamento de agentes. Isso não torna deploy público nem
libera acesso geral ao host: o limite do SSH continua sendo o script fixo.

Recibos privados são gravados atomicamente com fsync antes da execução. Mesmo
requestId/destino devolve o estado; destino diferente é recusado.
Recibos antigos com `releaseTag` continuam legíveis por `status` (campo opcional
no schema de saída apenas para histórico). Seus IDs são recusados em `execute`,
sem replay nem conversão de uma execução antiga em deploy da `main`. Após perda
da conexão, consultar o mesmo ID. Execuções da ponte são serializadas; após perda
do processo/reboot, `Running` sem lock vira `Interrupted`, sem replay automático.
O processo destacado sobrevive à conexão/API; encerramento do cgroup SSH também
pode interrompê-lo. `Succeeded` significa saída zero do script, não homologação.
Saída bruta fica somente em `receipts/ID.log`, até 1 MiB, nunca na resposta MCP.
Não apagar recibos para reutilizar IDs. Não há limpeza automática.

Testes locais usam fixture inofensiva, nunca o deploy real:
`python3 -B tests/ReleaseAutomation/deploy-bridge.test.py` e
`dotnet test tests/OperationalIntelligence/Yeshua.OperationalIntelligence.Api.Tests`.
