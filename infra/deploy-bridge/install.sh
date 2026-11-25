#!/usr/bin/env bash
set -euo pipefail

[[ "$(id -u)" == "0" ]] || { echo "A ponte de deploy deve ser instalada pelo administrador do host." >&2; exit 1; }
SOURCE_DIR="$(cd -- "$(dirname -- "${BASH_SOURCE[0]}")" && pwd)"
CLIENT="${YESHUA_PRIVATE_ROOT:?Configure o diretorio privado}/shared/OperationalAgent/integracoes/deploy-bridge"
BASE=/root/YeshuaStorage/persistent/infra/deploy-bridge
ACCOUNT=yeshua-deploy
ACCOUNT_HOME=/var/lib/yeshua-deploy

# The container bind-mounts only this directory, never the main credentials file.
[[ ! -L "$CLIENT" ]] || { echo "Diretorio da chave nao pode ser link simbolico." >&2; exit 1; }
install -d -o root -g root -m 0700 "$CLIENT"
if [[ "${YESHUA_MCP_DEPLOY_ENABLED:-false}" != "true" ]]; then
  if [[ -e "$ACCOUNT_HOME/.ssh/authorized_keys" || -L "$ACCOUNT_HOME/.ssh/authorized_keys" ]]; then
    [[ ! -L "$ACCOUNT_HOME" && ! -L "$ACCOUNT_HOME/.ssh" && ! -L "$ACCOUNT_HOME/.ssh/authorized_keys" && -f "$ACCOUNT_HOME/.ssh/authorized_keys" ]] || { echo "Autorizacao SSH invalida." >&2; exit 1; }
    install -o root -g root -m 0644 /dev/null "$ACCOUNT_HOME/.ssh/authorized_keys"
  fi
  echo "Deploy MCP desabilitado na configuracao privada."
  exit 0
fi

for executable in /usr/bin/curl /usr/bin/ssh-keygen /usr/bin/python3 /usr/bin/sudo /usr/sbin/visudo /usr/sbin/sshd; do
  [[ -x "$executable" ]] || { echo "Dependencia ausente: $executable" >&2; exit 1; }
done
for directory in /opt/yeshua-deploy "$BASE" "$BASE/receipts" "$ACCOUNT_HOME" "$ACCOUNT_HOME/.ssh"; do
  [[ ! -L "$directory" ]] || { echo "Diretorio administrativo nao pode ser link simbolico." >&2; exit 1; }
done
for file in "$CLIENT/id_ed25519" "$CLIENT/id_ed25519.pub" "$CLIENT/known_hosts" /opt/yeshua-deploy/bridge.py /etc/sudoers.d/yeshua-deploy "$ACCOUNT_HOME/.ssh/authorized_keys"; do
  [[ ! -L "$file" && ( ! -e "$file" || -f "$file" ) ]] || { echo "Arquivo administrativo invalido." >&2; exit 1; }
done
[[ ! -e "$ACCOUNT_HOME/.ssh/authorized_keys2" && ! -L "$ACCOUNT_HOME/.ssh/authorized_keys2" ]] || { echo "Conta tecnica possui outra autorizacao SSH; revise antes de ativar." >&2; exit 1; }

# Run after compose up: network and the existing agent identity now exist, also on first setup.
client_uid="$(docker exec yeshua-operational-intelligence id -u agent)"
client_gid="$(docker exec yeshua-operational-intelligence id -g agent)"
[[ "$client_uid" =~ ^[1-9][0-9]*$ && "$client_gid" =~ ^[1-9][0-9]*$ ]] || { echo "Identidade do agente invalida." >&2; exit 1; }
sources="$(docker network inspect yeshua-net --format '{{range .IPAM.Config}}{{println .Subnet}}{{end}}' | /usr/bin/python3 -c '
import ipaddress, sys
networks = [ipaddress.ip_network(line.strip(), strict=True) for line in sys.stdin if line.strip()]
if not networks or any(not network.is_private or network.is_loopback for network in networks):
    raise SystemExit("Rede privada Yeshua invalida.")
print(",".join(str(network) for network in networks))
')"

if ! id "$ACCOUNT" >/dev/null 2>&1; then
  useradd --system --user-group --no-create-home --home-dir "$ACCOUNT_HOME" --shell /bin/sh "$ACCOUNT"
fi
[[ "$(id -u "$ACCOUNT")" != "0" && "$(id -nG "$ACCOUNT")" == "$ACCOUNT" ]] || { echo "Conta tecnica possui grupos inesperados." >&2; exit 1; }
[[ "$(getent passwd "$ACCOUNT" | cut -d: -f6)" == "$ACCOUNT_HOME" ]] || { echo "Home da conta tecnica inesperado." >&2; exit 1; }
usermod --lock "$ACCOUNT"
install -d -o root -g root -m 0755 /opt/yeshua-deploy "$ACCOUNT_HOME" "$ACCOUNT_HOME/.ssh"
install -d -o root -g root -m 0700 "$BASE" "$BASE/receipts"
install -o root -g root -m 0644 "$SOURCE_DIR/bridge.py" /opt/yeshua-deploy/bridge.py

sudoers="$(mktemp)"
trap 'rm -f "$sudoers"' EXIT
printf '%s\n' 'yeshua-deploy ALL=(root) NOPASSWD: NOSETENV: /usr/bin/python3 -I /opt/yeshua-deploy/bridge.py' > "$sudoers"
/usr/sbin/visudo -cf "$sudoers" >/dev/null
install -o root -g root -m 0440 "$sudoers" /etc/sudoers.d/yeshua-deploy

if [[ ! -f "$CLIENT/id_ed25519" ]]; then
  [[ ! -e "$CLIENT/id_ed25519.pub" ]] || { echo "Restaure a chave privada existente antes de continuar." >&2; exit 1; }
  /usr/bin/ssh-keygen -q -t ed25519 -N '' -C yeshua-mcp-deploy -f "$CLIENT/id_ed25519"
fi
public_key="$(/usr/bin/ssh-keygen -y -f "$CLIENT/id_ed25519")"
printf '%s yeshua-mcp-deploy\n' "$public_key" > "$CLIENT/id_ed25519.pub"
printf 'from="%s",restrict,command="/usr/bin/sudo -n /usr/bin/python3 -I /opt/yeshua-deploy/bridge.py" %s yeshua-mcp-deploy\n' "$sources" "$public_key" > "$ACCOUNT_HOME/.ssh/authorized_keys"
chown root:root "$ACCOUNT_HOME/.ssh/authorized_keys"
chmod 0644 "$ACCOUNT_HOME/.ssh/authorized_keys"

# Pin the local host's public identity; never obtain trust with ssh-keyscan over the network.
[[ -f /etc/ssh/ssh_host_ed25519_key.pub && ! -L /etc/ssh/ssh_host_ed25519_key.pub ]] || { echo "Chave publica SSH do host ausente." >&2; exit 1; }
printf 'host.docker.internal %s\n' "$(cat /etc/ssh/ssh_host_ed25519_key.pub)" > "$CLIENT/known_hosts"
chown "$client_uid:$client_gid" "$CLIENT/id_ed25519"
chmod 0400 "$CLIENT/id_ed25519"
chown root:root "$CLIENT/id_ed25519.pub" "$CLIENT/known_hosts"
chmod 0444 "$CLIENT/id_ed25519.pub" "$CLIENT/known_hosts"
chown "root:$client_gid" "$CLIENT"
chmod 0750 "$CLIENT"
/usr/sbin/sshd -t
echo "Ponte MCP instalada: conta exclusiva, comando forcado, chave privada e identidade do host fixada."
