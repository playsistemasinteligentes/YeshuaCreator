#!/usr/bin/env bash
set -euo pipefail

# Both processes belong to the existing operational container. Any unexpected
# exit restarts that container; the broker retains unacknowledged work.
: "${CELERY_BROKER_URL:?Configure the standard broker credential}"
: "${YESHUA_PROCESSING_SCOPE:?Configure the Clinica processing scope}"

api_pid=""
executor_pid=""
cleanup() {
  trap - EXIT TERM INT
  [[ -z "$executor_pid" ]] || kill -TERM "$executor_pid" 2>/dev/null || true
  [[ -z "$api_pid" ]] || kill -TERM "$api_pid" 2>/dev/null || true
  [[ -z "$executor_pid" ]] || wait "$executor_pid" 2>/dev/null || true
  [[ -z "$api_pid" ]] || wait "$api_pid" 2>/dev/null || true
}
trap cleanup EXIT
trap 'exit 0' TERM INT

if [[ "$(id -u)" == "0" ]]; then
  gosu agent "$@" &
  api_pid=$!
  gosu agent /opt/task-runtime/bin/python /opt/clinica-executor/main.py &
else
  "$@" &
  api_pid=$!
  /opt/task-runtime/bin/python /opt/clinica-executor/main.py &
fi
executor_pid=$!

exit_code=0
wait -n "$api_pid" "$executor_pid" || exit_code=$?
echo '{"event":"ClinicaExecutor.ProcessExited"}' >&2
[[ "$exit_code" != "0" ]] || exit_code=1
exit "$exit_code"
