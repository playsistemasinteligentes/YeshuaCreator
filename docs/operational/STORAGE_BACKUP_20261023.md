# Storage De Backup - 2026-10-23

## Escopo

Origem: 69.164.247.138, vps3523734, Ubuntu 24.04.5 LTS.
Storage: 162.35.11.225, vps3750254, Ubuntu 26.04.1 LTS.
SSH na porta 22. Recursos conferidos no sistema: disco de aproximadamente
1 TB e 1,6 GiB de memoria utilizavel no storage. Isso confirma capacidade
compativel com armazenamento; nao comprova o SKU/faturamento do provedor.

Fase inicial: nenhum aplicativo, Docker, SQL, Restic ou agente no storage.
Evolucao posterior nesta data: controlador e Restic tambem no storage, sem
Docker/SQL/aplicativos. Geracao SQL, leitura, deduplicacao e envio continuam na
origem; agendas e verificacoes passam ao storage. Replicacao ainda pendente.
Destino ativo: sftp:yeshua-backup@162.35.11.225:/repository.
Caminho real no storage: /srv/yeshua-backups/repository.

## Protecao De Acesso

- Conta tecnica yeshua-backup, sem senha/shell, chroot e SFTP obrigatorio.
- Chave de transporte aceita somente do IP 69.164.247.138.
- Sem terminal, encaminhamento de portas ou acesso ao filesystem do host.
- Chave privada e known_hosts na origem em
  /root/YeshuaPrivate/production/shared/Backup/ssh, fora do Git.
- Shared.Backup no credentials.json referencia os arquivos SSH. A senha
  independente do Restic nao mudou. Senhas de root nao foram alteradas.
- Chaves administrativas separadas da chave dos backups. Na maquina local:
  %USERPROFILE%/.ssh/yeshua-production-admin e yeshua-storage-admin.
  Para revogar acesso administrativo, remover somente as respectivas linhas
  marcadas em /root/.ssh/authorized_keys de cada VPS e trocar as senhas
  compartilhadas. Isso nao exige remover a chave tecnica do backup.

Kit de recuperacao local, com ACL somente do usuario, SYSTEM e administradores:
%USERPROFILE%/.yeshua/private/production/20261023-storage/.
Contem credentials.json atualizado, id_ed25519 de transporte, known_hosts,
ferramentas e roteiro. Integridade dos tres arquivos privados comparada por
SHA-256 com a origem, sem revelar conteudo. Nenhuma senha entrou no Git.
IP novo na recuperacao exige atualizar a autorizacao from= no STORAGE.

## Evidencias Da Fase SFTP

- Envio, listagem e remocao de arquivo publico pelo usuario tecnico: passou.
- Tentativa de abrir shell e ler /etc/passwd do host: bloqueadas.
- Reexecucao do setup do storage: passou, sem reinstalar componentes.
- 174 snapshots antigos copiados; arvores/metadados conferidos e todos os
  blocos remotos lidos. Historico local antigo mantido, sem prune.
- Novos full, diferencial e logs dos seis bancos: concluidos no storage.
- Novo snapshot de arquivos persistentes/privados: concluido no storage.
- Reexecucao de install.py --initialize-online com destino SFTP: passou,
  recibo da mesma senha preservado e agendas habilitadas.
- 235 testes Python no Linux: passaram. Windows: 230 passaram, cinco
  exclusivos de Linux ignorados. Dados sinteticos em diretorios isolados.
- Central HTTPS /spa/: HTTP 200. IDs/inicio dos containers dos aplicativos
  iguais aos anteriores. Nenhum deploy/restart dos aplicativos.

Release instalado: 59ff60af7577d7f64c09 em /opt/yeshua-backup.
Migracao: 7min08s, 16,6s de CPU e pico de memoria de 179,9 MiB.
Limites do cliente: CPU 25% de um nucleo, memoria 768 MiB, baixa prioridade,
envio 2 MiB/s, leitura 4 MiB/s. Isso nao limita o SQL dentro do container.
Seis agendas preservadas; limpeza de volatil continua separada as 04:30.
SQL nativo continua gerando midias locais. Nao foi criada outra copia local
completa dos novos snapshots antes do envio ao storage.
Conferencia dessa fase: 180 snapshots no storage, aproximadamente 38 MiB ocupados;
historico local antigo com 33 MiB e midias nativas SQL com 48 MiB. Todas as
seis agendas habilitadas e ativas, sem marcador de destino externo pendente.

## Verificacao De Recuperacao

Concluida as 08:54:43 America/Sao_Paulo (11:54:43 UTC):

- Download de snapshots SQL/arquivos exatos com verificacao do Restic.
- Tres arquivos privados comparados por hash: JSON, chave SSH e known_hosts.
- 18 midias baixadas conferidas por SHA-256 e RESTORE VERIFYONLY WITH CHECKSUM.
- Cadeias D/I/L verificadas para YESHUA_APS_ADM, YESHUA_CENTRAL,
  YESHUA_CLINICA, YESHUA_FISCAL, YESHUA_MEMORIAS e
  YESHUA_OPERATIONAL_INTELLIGENCE.
- Nenhum banco de producao restaurado/sobrescrito. Pastas temporarias de
  download e teste SQL removidas; todas as agendas retomadas.

IDs completos dos snapshots no recibo privado remote-recovery-verification.json.
Ainda nao e prova de restauracao funcional integral em servidor novo.

## Evolucao Para Controle Central

O usuario aprovou centralizar as agendas na Storage VPS, mantendo o trabalho
que depende dos dados na origem. Implementado com control.py/source.py e
routine.py existente, sem servico de aplicacao novo nem agente residente.

```text
162.35.11.225: calendarios e reconciliacao de pedidos
    | SSH: chave exclusiva, usuario/comando restritos
    v
69.164.247.138: oneshot -> SQL nativo/arquivos -> Restic
    | SFTP: cifrado, incremental, limite 2 MiB/s
    v
162.35.11.225: repositorio -> recibo confirmado -> check/check-data local
    |
    +--> segundo provedor: ainda pendente
```

As seis agendas legadas foram desativadas na origem apos conferir o acesso.
No storage, mesmos horarios, reconciliacao a cada 30s e intencoes consolidadas.
Um trabalho por origem; ate dois envios no conjunto; uma verificacao pesada.
Pedidos persistidos e executados por systemd continuam apos a sessao SSH;
repeticao do mesmo ID nao gera outra captura. Cadastro aceita novas maquinas
com repositorios/chaves individuais e storage.py --source-name isola receptores.

Na origem, timer de seguranca a cada 5min gera logs nativos se a ultima geracao
concluida tem mais de 20min. Usa os mesmos locks/catalogo, sem envio nem nova
implementacao SQL. A indisponibilidade do controlador nao interrompe sozinha a
manutencao nativa, mas nao garante copia externa. Midias continuam no disco
ate uma futura politica de liberacao. Limpeza volatil permanece local.

O setup/instalador comum reconhece a propriedade do controlador e nao reativa
agendas antigas. Controle exige Linux/root somente no provisionamento; rotina
usa yeshua-backup-control com chave do storage, nao acesso SSH root. Protocolos
aceitam apenas probe/start/status com identidades e pedidos validados, nao
comandos/caminhos arbitrarios. Senhas SQL nao foram copiadas para o storage.

Provas desta etapa e hashes ficam nas duas VPSs em
/root/YeshuaBackup/operations/20261023-controller/.
O recibo de disconnection comprova o pedido a8f30c844eef4756b42548e7cce0fc44
rodando depois do SSH e repetido com o mesmo ID. Full dos seis bancos entregue
e confirmado no storage: 76b12feb3287bf40da20a95abc68b2211e1c5d4d76a08698bb86f2f138d90179.
Protecao local testada com seis backups nativos de log e chamadas Restic
proibidas no processo de teste; geracao local nao foi registrada como entrega.
261 testes passaram no Linux antes da virada (incluindo permissoes/umask).
Todos os seis perfis concluidos na nova arquitetura; check e check-data
executados no storage. O painel de estado terminou current, sem perfis
atrasados. Recibos completos em acceptance.json no storage.
Nova rodada automatica de logs observada pela agenda apos os testes manuais.
Reexecucao de --initialize-online respeitou a propriedade do controlador e
manteve os seis timers antigos disabled. Catalogo dos seis bancos validado,
sem executar restore. Windows: 255 testes passaram e seis POSIX ignorados.
Containers dos aplicativos sem mudanca de ID/inicio; HTTPS /spa/ retornou 200.

Kit local ampliado em %USERPROFILE%/.yeshua/private/production/20261023-storage/:
controller/credentials.json, controller/id_ed25519 e controller/known_hosts
sao do controlador, separados dos arquivos da origem. Permissoes restritas,
fora do Git; guardar tambem copia independente sob controle do operador.

## Pendencias Atuais

- Segunda copia em outro provedor e protecao contra exclusao maliciosa.
- Notificacao externa dos atrasos/falhas. Estado/journal/status existem;
  nao representam alertas entregues fora das VPSs.
- Restauracao funcional completa em servidor novo. Leitura integral e
  VERIFYONLY nao comprovam restauracao do ambiente inteiro.
- Liberacao/retencao das midias SQL e descarte do historico local antigo
  somente com estrategia/aceite apropriados; nada removido nesta etapa.
- Medir tempos/capacidade conforme o historico crescer. O teto de quatro
  horas e as taxas atuais precisam ser revistos antes de volumes grandes.
- Deploy normal nao atualiza as ferramentas de backup. Usar o instalador
  dedicado em cada papel; o pacote aplicado e versionado por hash.
- Agente operacional ja estava reiniciando, com codigo 126 na observacao
  inicial. Mesmo container e mesmo problema anterior; nao corrigido aqui.

Recibos tecnicos privados na origem:
/root/YeshuaBackup/operations/20261023-sftp/ e /root/YeshuaBackup/state/.
