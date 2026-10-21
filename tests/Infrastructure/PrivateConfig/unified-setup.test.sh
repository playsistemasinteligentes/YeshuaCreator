#!/usr/bin/env bash
set -euo pipefail

repo="$(cd "$(dirname "${BASH_SOURCE[0]}")/../../.." && pwd)"
APP_DIR="$repo"
source "$repo/infra/bootstraps/setup.sh"
temporary="$(mktemp -d)"
log="$temporary/calls.log"
cleanup() {
  rm -f -- "$log" "$temporary/existing/data" "$temporary/collision"
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
curl() { printf 'curl\n' >> "$log"; }
apt() { printf 'apt\n' >> "$log"; }
docker() { printf 'docker\n' >> "$log"; }
systemctl() { printf 'systemctl\n' >> "$log"; }
restic() { :; }
ionice() { :; }
ensure_directory() { printf 'directory\n' >> "$log"; }
fixture_python() {
  if [[ "$2" == */infra/backups/backup.py ]]; then
    printf 'backup:%s\n' "$3" >> "$log"
    [[ "$3" != recovery-key || "$custody_confirmed" == yes ]]
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
# Exit the isolated test shell before the optional aliases section.
bash() {
  [[ "${YESHUA_SETUP_SQL_ACCESS:-0}" == 1 && "$YESHUA_DEPLOY_SECRETS_FILE" == "$PRIVATE_FILE" ]]
  printf 'deploy\n' >> "$log"
  exit 73
}

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
  (main) > /dev/null 2>&1 || status=$?
  [[ "$status" -eq 73 ]]
  mapfile -t calls < "$log"
  [[ "${calls[0]} ${calls[1]} ${calls[2]} ${calls[3]} ${calls[4]} ${calls[5]}" == 'git init validate backup:configure-local backup:recovery-key apt' ]]
  [[ "${calls[-1]}" == deploy ]]
done

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

echo 'PASS: one setup path, credentials wait then key custody before upgrade/deploy, refusal stops setup, backup installer shared, existing directories unchanged.'
