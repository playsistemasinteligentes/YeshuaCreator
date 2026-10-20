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
ensure_directory() { printf 'directory\n' >> "$log"; }
fixture_python() {
  printf '%s\n' "$2" >> "$log"
  [[ "$2" != validate || "$configuration_valid" == yes ]]
}
PYTHON=fixture_python
# Exit the isolated test shell before the optional aliases section.
bash() { printf 'deploy\n' >> "$log"; exit 73; }

: > "$log"
configuration_valid=no
status=0
(main) > /dev/null 2>&1 || status=$?
[[ "$status" -eq 1 ]]
[[ "$(tr '\n' ' ' < "$log")" == 'git init validate ' ]]

configuration_valid=yes
for scenario in fresh restored; do
  : > "$log"
  status=0
  (main) > /dev/null 2>&1 || status=$?
  [[ "$status" -eq 73 ]]
  mapfile -t calls < "$log"
  [[ "${calls[0]} ${calls[1]} ${calls[2]} ${calls[3]}" == 'git init validate apt' ]]
  [[ "${calls[-1]}" == deploy ]]
done

fixture_backup_python() { printf '%s\n' "$*" >> "$log"; }
PYTHON=fixture_backup_python
: > "$log"
prepare_backup
grep -F -- '-B' "$log" >/dev/null
grep -F -- '/infra/backups/install.py --initialize-online' "$log" >/dev/null

echo 'PASS: one setup path, configuration before services, backup installer shared, existing directories unchanged.'
