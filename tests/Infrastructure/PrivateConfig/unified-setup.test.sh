#!/usr/bin/env bash
set -euo pipefail

repo="$(cd "$(dirname "${BASH_SOURCE[0]}")/../../.." && pwd)"
APP_DIR="$repo"
source "$repo/infra/bootstraps/setup.sh"
temporary="$(mktemp -d)"
log="$temporary/calls.log"
cleanup() {
  rm -f -- "$log" "$temporary/result" "$temporary/existing/data" "$temporary/collision"
  rmdir -- "$temporary/existing" "$temporary/new" "$temporary"
}
trap cleanup EXIT

# Test only: record ownership calls instead of requiring root or changing ACLs.
chown() { printf 'chown:%s\n' "$*" >> "$log"; }
chmod() { printf 'chmod:%s\n' "$*" >> "$log"; }
mkdir -p "$temporary/existing"
printf 'fixture-data' > "$temporary/existing/data"
: > "$log"
ensure_directory "$temporary/existing" 10001:0 750
[[ ! -s "$log" ]]
[[ "$(< "$temporary/existing/data")" == fixture-data ]]
ensure_directory "$temporary/new" 10001:0 750
[[ "$(wc -l < "$log")" -eq 2 ]]
ensure_directory "$temporary/new" 10001:0 750
[[ "$(wc -l < "$log")" -eq 2 ]]
printf 'fixture-collision' > "$temporary/collision"
if ensure_directory "$temporary/collision" 10001:0 750 2>/dev/null; then
  echo 'FAIL: persistence file was accepted as a directory' >&2
  exit 1
fi
[[ "$(< "$temporary/collision")" == fixture-collision ]]

# The public entry streams the script to bash; BASH_SOURCE may be empty there.
streamed="$(printf 'set -eu\nmain() { echo called; }\n%s\n' "$(tail -n 3 "$repo/infra/bootstraps/setup.sh")" | command bash)"
[[ "$streamed" == called ]]

# Exercise orchestration with no apt, Docker, Git, service or /root side effects.
require_root() { :; }
git() { printf 'git\n' >> "$log"; }
curl() {
  case "$*" in
    *https://playsis.com.br/spa/*)
      [[ "$*" == *'--resolve playsis.com.br:443:127.0.0.1'* && "$*" != *'--insecure'* ]]
      printf 'curl-https\n' >> "$log"
      [[ "$https_health_valid" == yes ]]
      ;;
    *http://127.0.0.1/spa/*)
      printf 'curl-http\n' >> "$log"
      [[ "$http_health_valid" == yes ]]
      ;;
    *) printf 'curl\n' >> "$log" ;;
  esac
}
apt() { printf 'apt\n' >> "$log"; }
docker() {
  if [[ "$1" == ps ]]; then printf 'docker-list\n' >> "$log"; else printf 'docker\n' >> "$log"; fi
}
systemctl() { printf 'systemctl\n' >> "$log"; }
restic() { :; }
ionice() { :; }
ensure_directory() { printf 'directory\n' >> "$log"; }
configure_aliases() { printf 'aliases\n' >> "$log"; }
fixture_python() {
  if [[ "$2" == */infra/backups/backup.py ]]; then
    printf 'backup:%s\n' "$3" >> "$log"
    [[ "$3" != recovery-key || "$custody_confirmed" == yes ]]
    return
  fi
  if [[ "$2" == */infra/private/sql_access.py ]]; then
    [[ "$1" == -B && "$3" == --file && "$4" == "$PRIVATE_FILE" ]]
    printf 'sql-access\n' >> "$log"
    [[ "$sql_access_valid" == yes ]]
    return
  fi
  if [[ "$2" == */infra/backups/install.py ]]; then
    [[ "$1" == -B && "$3" == --initialize-online ]]
    printf 'install-backup\n' >> "$log"
    [[ "$backup_install_valid" == yes ]]
    return
  fi
  [[ "$1" == -B && "$2" == */infra/private/credentials.py ]]
  printf '%s\n' "$3" >> "$log"
  if [[ "$3" == init ]]; then
    [[ "$4" == --wait && "$configuration_prepared" == yes ]]
  else
    [[ "$3" == validate && "$configuration_valid" == yes ]]
  fi
}
PYTHON=fixture_python
bash() {
  [[ "$YESHUA_DEPLOY_SECRETS_FILE" == "$PRIVATE_FILE" ]]
  if [[ "$1" == "$DEPLOY_SCRIPT" ]]; then
    [[ "${YESHUA_SETUP_SQL_ACCESS:-0}" == 1 && "$2" == all ]]
    printf 'deploy\n' >> "$log"
    [[ "$deploy_valid" == yes ]]
  else
    [[ "$1" == "$APP_DIR/infra/bootstraps/setup-cert.sh" ]]
    printf 'https\n' >> "$log"
    [[ "$https_valid" == yes ]]
  fi
}
deploy_valid=yes
sql_access_valid=yes
backup_install_valid=yes
https_valid=yes
http_health_valid=yes
https_health_valid=yes

: > "$log"
configuration_valid=no
configuration_prepared=no
status=0
(main) > /dev/null 2>&1 || status=$?
[[ "$status" -eq 1 ]]
[[ "$(tr '\n' ' ' < "$log")" == 'git init ' ]]

configuration_prepared=yes
: > "$log"
status=0
(main) > /dev/null 2>&1 || status=$?
[[ "$status" -eq 1 ]]
[[ "$(tr '\n' ' ' < "$log")" == 'git init validate ' ]]

configuration_valid=yes
custody_confirmed=no
: > "$log"
status=0
(main) > /dev/null 2>&1 || status=$?
[[ "$status" -eq 1 ]]
[[ "$(tr '\n' ' ' < "$log")" == 'git init validate backup:configure-local backup:recovery-key ' ]]

custody_confirmed=yes
for scenario in fresh restored; do
  : > "$log"
  status=0
  (main) > "$temporary/result" 2>&1 || status=$?
  [[ "$status" -eq 0 ]]
  mapfile -t calls < "$log"
  [[ "${calls[0]} ${calls[1]} ${calls[2]} ${calls[3]} ${calls[4]} ${calls[5]}" == 'git init validate backup:configure-local backup:recovery-key apt' ]]
  [[ "${calls[-9]} ${calls[-8]} ${calls[-7]} ${calls[-6]} ${calls[-5]} ${calls[-4]} ${calls[-3]} ${calls[-2]} ${calls[-1]}" == 'deploy sql-access install-backup https aliases docker-list curl-http curl-https backup:status' ]]
  grep -F 'Setup concluido: aplicativos, backup e HTTPS conferidos.' "$temporary/result" >/dev/null
done

# Every required stage must stop the single setup before claiming completion.
for failure in deploy_valid sql_access_valid backup_install_valid https_valid http_health_valid https_health_valid; do
  : > "$log"
  status=0
  (declare "$failure=no"; main) > "$temporary/result" 2>&1 || status=$?
  [[ "$status" -eq 1 ]]
  if grep -F 'Setup concluido:' "$temporary/result" >/dev/null; then
    echo "FAIL: setup claimed success after $failure failed" >&2
    exit 1
  fi
  case "$failure" in
    deploy_valid) [[ "$(tail -n 1 "$log")" == deploy ]] ;;
    sql_access_valid) [[ "$(tail -n 1 "$log")" == sql-access ]] ;;
    backup_install_valid) [[ "$(tail -n 1 "$log")" == install-backup ]] ;;
    https_valid) [[ "$(tail -n 1 "$log")" == https ]] ;;
    http_health_valid) [[ "$(tail -n 1 "$log")" == curl-http ]] ;;
    https_health_valid) [[ "$(tail -n 1 "$log")" == curl-https ]] ;;
  esac
done
rm -f -- "$temporary/result"

# A bare server installs only backup prerequisites before asking for custody.
: > "$log"
(
  command() {
    if [[ "$1" == -v && ( "$2" == restic || "$2" == ionice ) ]]; then return 1; fi
    builtin command "$@"
  }
  prepare_backup_key
)
[[ "$(tr '\n' ' ' < "$log")" == 'apt apt backup:configure-local backup:recovery-key ' ]]

: > "$log"
status=0
(
  command() { return 1; }
  apt() { printf 'apt-failure\n' >> "$log"; return 1; }
  prepare_backup_key
) > /dev/null 2>&1 || status=$?
[[ "$status" -eq 1 ]]
[[ "$(tr '\n' ' ' < "$log")" == 'apt-failure ' ]]

fixture_backup_python() { printf '%s\n' "$*" >> "$log"; }
PYTHON=fixture_backup_python
: > "$log"
prepare_backup
grep -F -- '-B' "$log" >/dev/null
grep -F -- '/infra/backups/install.py --initialize-online' "$log" >/dev/null

echo 'PASS: one setup includes credentials, early key custody, deploy, SQL, backup, HTTPS and final health checks; failures stop completion; existing directories unchanged.'
