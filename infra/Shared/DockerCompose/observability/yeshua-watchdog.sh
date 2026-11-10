#!/usr/bin/env sh
set -eu

READY_FILE="${LGTM_READY_FILE:-/tmp/ready}"
INTERVAL_SECONDS="${YESHUA_TELEMETRY_WATCHDOG_INTERVAL_SECONDS:-30}"
FAILURE_LIMIT="${YESHUA_TELEMETRY_WATCHDOG_FAILURE_LIMIT:-3}"

while [ ! -f "$READY_FILE" ]; do
  sleep 1
done

failures=0

stack_is_healthy() {
  curl -fsS http://127.0.0.1:3000/api/health >/dev/null 2>&1 &&
    curl -fsS http://127.0.0.1:3100/ready >/dev/null 2>&1 &&
    curl -fsS http://127.0.0.1:3200/ready >/dev/null 2>&1 &&
    curl -fsS http://127.0.0.1:4040/ready >/dev/null 2>&1 &&
    curl -fsS http://127.0.0.1:9090/-/ready >/dev/null 2>&1 &&
    curl -fsS http://127.0.0.1:13133/ready >/dev/null 2>&1
}

while :; do
  sleep "$INTERVAL_SECONDS"

  if stack_is_healthy; then
    failures=0
    continue
  fi

  failures=$((failures + 1))
  echo "Observability watchdog detected an unhealthy component ($failures/$FAILURE_LIMIT)." >&2

  if [ "$failures" -ge "$FAILURE_LIMIT" ]; then
    echo "Observability stack is incomplete; restarting the consolidated container." >&2
    kill -TERM 1
    exit 1
  fi
done
