#!/usr/bin/env bash
set -euo pipefail

APP_DIR="$(cd "$(dirname "${BASH_SOURCE[0]}")/../../.." && pwd)"
DEPLOY_ENV=/dev/null
YESHUA_SKIP_SHARED=1
fixture=$'fixture com espaco, aspas \x27" e $ # ; \\ ! ='

fixture_python() {
  printf 'YESHUA_JWT_SECRET\t%s\n' "$(printf '%s' "$fixture" | base64 | tr -d '\r\n')"
  printf 'YESHUA_MODULE_SHARED_KEY\t\n'
}
YESHUA_PYTHON=fixture_python
export YESHUA_JWT_SECRET=inherited
export YESHUA_MODULE_SHARED_KEY=inherited
source "$APP_DIR/infra/docker/load-deploy-env.sh" central
[[ "$YESHUA_JWT_SECRET" == "$fixture" ]]
[[ -z "$YESHUA_MODULE_SHARED_KEY" ]]

# Daily deploy must not provision SQL. Setup explicitly enables the common hook.
fixture_python() { echo 'FAIL: SQL provisioning started in daily deploy' >&2; return 1; }
YESHUA_SETUP_SQL_ACCESS=0 yeshua_setup_sql_access
fixture_python() { [[ "$1" == -B && "$2" == */infra/private/sql_access.py && "$3" == --allow-missing-databases ]]; }
YESHUA_SETUP_SQL_ACCESS=1 yeshua_setup_sql_access

fixture_python() { return 1; }
export YESHUA_JWT_SECRET=unchanged
if source "$APP_DIR/infra/docker/load-deploy-env.sh" central; then
  echo 'FAIL: invalid configuration was accepted' >&2
  exit 1
fi
[[ "$YESHUA_JWT_SECRET" == unchanged ]]
echo 'PASS: loader preserves special characters, clears stale values, stops on failure and provisions SQL only during setup.'
