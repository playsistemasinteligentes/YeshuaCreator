# Ponte privada de deploy (instalação administrativa pendente)

`yeshua_deploy` apenas submete `execute` ou consulta `status` por SSH com comando
forçado. O helper chama exclusivamente `/bin/bash /root/YeshuaCreator/infra/docker/deploy.sh TARGET`,
com `YESHUA_RELEASE_TAG`. O script existente continua responsável por lock,
seleção da tag, atualização Git, build, migrations, subida e gateway.
Deploy completo usa `all`. Não há comando livre, instalação, limpeza, merge ou restart separado.

Esta entrega autoriza **implementação e testes no workspace**, não instalação,
deploy, restart ou mudança do host. Nada é instalado automaticamente pelo Compose,
setup ou deploy. A ferramenta fica desabilitada por padrão. Restrições administrativas
bloqueiam a operação; não usar Docker socket, `privileged`, SSH root livre,
`sudo bash`, cópia de fontes ou execução manual alternativa para contorná-las.

## Fronteira e autorização

A ferramenta só aparece no MCP privado existente: porta privada e ambos os IPs
em loopback. Headers de proxy não autorizam. Isso autentica a conexão administrativa
confiável; não implementa ACL por tenant/usuário. Não expor para clientes externos.

`confirm=true` registra intenção, mas sozinho **não autoriza execução**. Antes de
cada execução, um administrador fora do agente deve conferir a ordem explícita do
operador e criar uma aprovação no host para **um requestId, um destino e uma tag**,
com expiração e identificador operacional de quem aprovou. Não incluir nome, e-mail,
segredos ou texto livre nesse identificador. Autorizar desenvolvimento não é autorizar deploy.
A aprovação não pode ser criada/alterada por MCP, SSH restrito ou workspace do agente.
Quem controla a conexão pode consumir uma aprovação existente; por isso aprovar apenas
o pedido exato, após a confirmação humana. Permissão expirada ou ausente fecha a execução.

## Passos administrativos (somente após autorização separada)

1. Revisar este helper e a política local. Criar conta SSH dedicada `yeshua-deploy`,
   sem grupos Docker/sudo, senha bloqueada, sem chave administrativa ou shell livre.
   Instalar `bridge.py` como `/opt/yeshua-deploy/bridge.py`, root:root, 0644, diretório
   root:root 0755. Instalar fora do checkout: o deploy atualiza/limpa esse checkout.
   Todos os ancestrais, helper, checkout `/root/YeshuaCreator`, `.git`, scripts,
   configuração Git/hooks e configurações carregadas pelo deploy devem ser controlados
   pelo administrador, sem escrita do usuário SSH, agente, grupo ou outros.
   Revisar a origem Git e as tags aprovadas; o deploy executa código dessa origem.
2. Criar `/root/YeshuaStorage/persistent/infra/deploy-bridge/{approvals,receipts}`,
   incluindo a raiz `deploy-bridge`, root:root 0700. Não montar essas pastas no agente.
   O helper exige proprietário root, modo privado e diretórios/arquivos reais, sem symlink.
   Este é estado administrativo do host em área persistente já coberta pelo backup,
   não um banco/fila alternativo da API nem arquivos dos volumes voláteis dos agentes.
3. Validar com `visudo` uma regra **exata**, sem wildcard, sem SETENV e sem outros
   comandos: `yeshua-deploy ALL=(root) NOPASSWD: NOSETENV: /usr/bin/python3 -I /opt/yeshua-deploy/bridge.py`.
   A única elevação é esse protocolo fixo: helper não aceita argumentos CLI, ambiente
   do solicitante ou programas/caminhos enviados no JSON. Não conceder sudo genérico.
4. Autorizar uma chave exclusiva com linha root-owned em `/etc/ssh/authorized_keys/yeshua-deploy`:
   `from="IP_DA_ORIGEM",restrict,command="sudo -n /usr/bin/python3 -I /opt/yeshua-deploy/bridge.py" ssh-ed25519 CHAVE_PUBLICA`.
   Configurar bloco `Match User yeshua-deploy` com `AuthorizedKeysFile` nesse caminho,
   `AuthenticationMethods publickey`, `PasswordAuthentication no`,
   `KbdInteractiveAuthentication no`, `PermitTTY no`, `DisableForwarding yes`,
   `PermitUserRC no` e o mesmo `ForceCommand`. Validar `sshd -t` e configuração efetiva
   com `sshd -T -C ...` antes de qualquer ativação, em janela administrativa autorizada.
   Não alterar o acesso root existente. Este documento não autoriza reload/restart.
5. Fixar chave do host em `known_hosts`, verificada por canal administrativo independente;
   não usar aceitação automática. Chave privada exclusiva e known_hosts ficam na área
   privada de runtime existente, fora do Git e das raízes legíveis pelo sandbox do agente.
   Dar acesso somente ao processo API, com permissões/mounts mínimos. Não encaminhar SSH agent.
   Configurar no provider privado existente `Mcp:Deploy:Enabled=true`,
   `Destination=yeshua-deploy@HOST`, `IdentityFile=/caminho/privado/id_ed25519` e
   `KnownHostsFile=/caminho/privado/known_hosts`. Sem esses pré-requisitos manter desabilitado.
   A ausência de chave, permissão ou rede é bloqueio administrativo, não motivo para
   ampliar sandbox/AppArmor/seccomp. A API já executa processos; não criar outro executor.
6. Para cada ordem humana, escolher requestId novo (1–80 letras ASCII, números, `_`, `-`),
   revisar destino e tag global existente. Criar atomicamente arquivo 0600 root:root
   `approvals/REQUEST_ID.json`, por canal administrativo externo, por exemplo:
   `{"requestId":"deploy-001","target":"all","releaseTag":"1.2.3","approvedBy":"operator-42","expiresAtUtc":"2026-11-17T18:00:00+00:00"}`.
   O horário é exemplo, não uma autorização válida. A revisão deve incluir o impacto
   nos serviços e a janela aprovada. O MCP não recebe credencial nem emite aprovações.
7. Homologar em host isolado a conta forçada, negação de shell/forwarding/comandos extras,
   permissões, indisponibilidade, desconexão e política de encerramento de sessões SSH.
   O processo usa `setsid` para sobreviver à conexão/API; hosts que encerram todo o cgroup
   da sessão devem ser tratados como Interrupted, sem replay. Não afirmar homologação
   de produção com base nos testes de workspace. Ativação exige autorização própria.

## Contrato MCP

Execução, somente após aprovação administrativa válida:

```json
{"action":"execute","requestId":"deploy-001","target":"all","releaseTag":"1.2.3","confirm":true}
```

Consulta, inclusive após timeout ou reinício da API:

```json
{"action":"status","requestId":"deploy-001"}
```

Destinos permitidos: `all`, `central`, `clinica`, `aps-adm`, `fiscal`, `memorias`, `shared`.
Não aceita flags, env, caminho, comando, branch, parâmetros de Docker ou variantes de restart.
A configuração de destino/chave é administrativa, nunca argumento da ferramenta.

## Persistência e falhas

O recibo root-only é gravado com replace atômico e fsync antes de iniciar o script.
Um requestId com mesmo destino/tag consulta seu recibo; com outro conteúdo é recusado.
O recibo consome a autorização permanentemente: não excluir recibos para repetir trabalho.
A ponte serializa suas execuções; `deploy.sh` preserva seu lock global já existente.

Estados: `NotFound`, `Running`, `Succeeded`, `Failed`, `Interrupted`, `Blocked`.
`Running` sem lock vivo vira `Interrupted` na consulta após perda do processo/reboot.
Nunca se repete automaticamente trabalho interrompido. Um deploy pode ter produzido
mudanças parciais antes da falha; o administrador deve reconciliar antes de aprovar
nova execução. `Succeeded` significa saída zero do script, não homologação funcional.
Queda entre consumo e início também fica Interrupted, sem tentar adivinhar o resultado.
Perda de conexão não cancela o deploy no host: consultar sempre o mesmo requestId.

Recibos incluem pedido/destino/tag/aprovador, horários UTC e exitCode quando conhecido.
Saída stdout/stderr fica em `receipts/REQUEST_ID.log`, privada, limitada ao primeiro
1 MiB; o restante é drenado sem persistir. Pode conter informação restrita emitida
pelo deploy: não retornar ao MCP, não exportar para logs públicos. Recibos são pequenos;
retenção/arquivamento são administrativos, preservando tombstones de requestIds consumidos.
O helper não apaga dados. Ausência/corrupção do armazenamento ou permissões inseguras
retorna Blocked; não contornar com outro ID nem reconstruir recibos automaticamente.

Verificações locais sem host: `python3 -B tests/ReleaseAutomation/deploy-bridge.test.py`
e `dotnet test tests/OperationalIntelligence/Yeshua.OperationalIntelligence.Api.Tests`.
Os testes substituem o script por fixture inofensiva; nunca executam o deploy real.
