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

Destinos: `all`, `central`, `clinica`, `aps-adm`, `fiscal`, `memorias`, `shared`.
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
shell livre. Configuração no provider privado existente: `Mcp:Deploy:Destination`
(`yeshua-deploy@HOST`), `IdentityFile` e `KnownHostsFile` absolutos. A chave do host
deve estar fixada; a chave privada fica fora do Git e do sandbox do agente.
Ausência dessa configuração retorna indisponibilidade, sem mecanismo alternativo.

A instalação técnica no host **não foi executada** nesta tarefa. Para uma ativação
futura, instalar `bridge.py` em `/opt/yeshua-deploy/bridge.py`, root:root 0644,
com ancestrais e checkout sem escrita do agente/usuário SSH. Criar
`/root/YeshuaStorage/persistent/infra/deploy-bridge` e `receipts`, root:root 0700.
Conta técnica `yeshua-deploy`: sem senha/grupo Docker/sudo genérico; única regra
sudoers validada com visudo:
`yeshua-deploy ALL=(root) NOPASSWD: NOSETENV: /usr/bin/python3 -I /opt/yeshua-deploy/bridge.py`.
Chave SSH exclusiva, arquivo de autorização controlado por root, com `restrict`,
origem limitada e comando forçado `sudo -n /usr/bin/python3 -I /opt/yeshua-deploy/bridge.py`;
sem forwarding, TTY ou user RC. Validar configuração efetiva do sshd e permissões.
Isso limita a capacidade da máquina; não é aprovação por execução ou login adicional
do operador. Não alterar Compose, sandbox, Docker ou host para contornar falhas.

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
