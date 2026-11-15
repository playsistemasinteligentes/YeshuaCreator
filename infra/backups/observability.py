"""Sanitized backup state projection and best-effort OTLP metrics export."""

from datetime import datetime, timezone
import json
import math
import os
import re
from urllib import request as http


KINDS = ("full", "differential", "logs", "files", "check", "check-data")
LIMIT_SECONDS = {
    "logs": 1800,
    "files": 129600,
    "full": 691200,
    "differential": 216000,
    "check": 172800,
    "check-data": 691200,
}
HEALTH = {"current": 0, "attention": 1, "critical": 2}
SOURCE = re.compile(r"[a-z][a-z0-9-]{0,39}")
SCOPE = re.compile(r"yeshua-[a-z0-9-]+")
DEFAULT_ENDPOINT = "http://127.0.0.1:4318/v1/metrics"


def _instant(value):
    try:
        result = datetime.fromisoformat(value)
    except (TypeError, ValueError):
        return None
    return result if result.tzinfo is not None else None


def _nonnegative(value):
    return float(value) if type(value) in {int, float} and math.isfinite(value) and value >= 0 else 0.0


def elapsed_seconds(started_at, finished_at):
    started, finished = _instant(started_at), _instant(finished_at)
    if not started or not finished or finished < started:
        return 0.0
    return (finished - started).total_seconds()


def snapshot(item, state, repository_free_bytes, minimum_free_bytes, *, observed_at=None):
    """Build the bounded, secret-free projection transported to the source host."""
    now = observed_at or datetime.now(timezone.utc)
    if now.tzinfo is None:
        raise ValueError("backup_observation_requires_aware_time")
    profiles = {}
    overdue = []
    for kind in KINDS:
        receipt = state.get("results", {}).get(kind, {})
        finished = _instant(receipt.get("finished_at"))
        completed = receipt.get("status") == "completed" and finished is not None and finished <= now
        is_overdue = not completed or (now - finished).total_seconds() > LIMIT_SECONDS[kind]
        if is_overdue:
            overdue.append(kind)
        profiles[kind] = {
            "status": "completed" if completed else ("failed" if receipt.get("status") == "failed" else "missing"),
            "last_success_unix_seconds": int(finished.timestamp()) if completed else 0,
            "overdue": is_overdue,
            "duration_seconds": _nonnegative(receipt.get("duration_seconds")),
            "bytes_processed": _nonnegative(receipt.get("bytes_processed")),
            "data_added_bytes": _nonnegative(receipt.get("data_added_bytes")),
        }
    health = "critical" if state.get("last_error") else ("attention" if overdue else "current")
    active = state.get("active") or {}
    active_kind = active.get("kind") if active.get("kind") in KINDS else None
    pending = sorted(kind for kind in state.get("pending", {}) if kind in KINDS)
    scope = item["Scope"]
    result = {
        "schema": 1,
        "source": item["Name"],
        "scope": scope,
        "environment": scope.removeprefix("yeshua-").replace("-", " ").title(),
        "observed_at_unix_seconds": int(now.timestamp()),
        "health": health,
        "repository_free_bytes": int(max(0, repository_free_bytes)),
        "minimum_free_bytes": int(max(0, minimum_free_bytes)),
        "active_kind": active_kind,
        "pending": pending,
        "functional_restore_proven": False,
        "profiles": profiles,
    }
    validate(result)
    return result


def validate(value):
    """Reject arbitrary controller input before it reaches the local OTLP endpoint."""
    expected = {"schema", "source", "scope", "environment", "observed_at_unix_seconds", "health",
                "repository_free_bytes", "minimum_free_bytes", "active_kind", "pending",
                "functional_restore_proven", "profiles"}
    if not isinstance(value, dict) or set(value) != expected or value.get("schema") != 1:
        raise ValueError("invalid_backup_observation")
    if (not SOURCE.fullmatch(value.get("source", "")) or not SCOPE.fullmatch(value.get("scope", ""))
            or not isinstance(value.get("environment"), str) or not 1 <= len(value["environment"]) <= 40
            or value.get("health") not in HEALTH or type(value.get("observed_at_unix_seconds")) is not int
            or value["observed_at_unix_seconds"] <= 0):
        raise ValueError("invalid_backup_observation_identity")
    for field in ("repository_free_bytes", "minimum_free_bytes"):
        if type(value.get(field)) is not int or not 0 <= value[field] <= 2 ** 63 - 1:
            raise ValueError("invalid_backup_observation_capacity")
    if value.get("active_kind") is not None and value["active_kind"] not in KINDS:
        raise ValueError("invalid_backup_observation_active_kind")
    if (not isinstance(value.get("pending"), list) or value["pending"] != sorted(set(value["pending"]))
            or any(kind not in KINDS for kind in value["pending"])
            or type(value.get("functional_restore_proven")) is not bool):
        raise ValueError("invalid_backup_observation_state")
    profiles = value.get("profiles")
    if not isinstance(profiles, dict) or set(profiles) != set(KINDS):
        raise ValueError("invalid_backup_observation_profiles")
    profile_fields = {"status", "last_success_unix_seconds", "overdue", "duration_seconds",
                      "bytes_processed", "data_added_bytes"}
    for profile in profiles.values():
        if (not isinstance(profile, dict) or set(profile) != profile_fields
                or profile.get("status") not in {"completed", "failed", "missing"}
                or type(profile.get("last_success_unix_seconds")) is not int
                or not 0 <= profile["last_success_unix_seconds"] <= value["observed_at_unix_seconds"]
                or type(profile.get("overdue")) is not bool
                or any(type(profile.get(field)) not in {int, float} or not math.isfinite(profile[field])
                       or not 0 <= profile[field] <= 2 ** 63 - 1
                       for field in ("duration_seconds", "bytes_processed", "data_added_bytes"))):
            raise ValueError("invalid_backup_observation_profile")
    return value


def _attribute(key, value):
    return {"key": key, "value": {"stringValue": value}}


def _point(snapshot_value, metric, value, kind=None):
    attributes = [_attribute("backup.source", snapshot_value["source"]), _attribute("metric", metric)]
    if kind is not None:
        attributes.append(_attribute("backup.kind", kind))
    return {"attributes": attributes,
            "timeUnixNano": str(snapshot_value["observed_at_unix_seconds"] * 1_000_000_000),
            "asDouble": float(value)}


def otlp(snapshot_value):
    """Return OTLP/HTTP JSON using one low-cardinality observable gauge."""
    validate(snapshot_value)
    points = [
        _point(snapshot_value, "observed_at_unix_seconds", snapshot_value["observed_at_unix_seconds"]),
        _point(snapshot_value, "health_state", HEALTH[snapshot_value["health"]]),
        _point(snapshot_value, "repository_free_bytes", snapshot_value["repository_free_bytes"]),
        _point(snapshot_value, "repository_minimum_free_bytes", snapshot_value["minimum_free_bytes"]),
        _point(snapshot_value, "functional_restore_proven", int(snapshot_value["functional_restore_proven"])),
        _point(snapshot_value, "pending_total", len(snapshot_value["pending"])),
    ]
    for kind in KINDS:
        profile = snapshot_value["profiles"][kind]
        points.extend((
            _point(snapshot_value, "profile_last_success_unix_seconds", profile["last_success_unix_seconds"], kind),
            _point(snapshot_value, "profile_overdue", int(profile["overdue"]), kind),
            _point(snapshot_value, "profile_duration_seconds", profile["duration_seconds"], kind),
            _point(snapshot_value, "profile_bytes_processed", profile["bytes_processed"], kind),
            _point(snapshot_value, "profile_data_added_bytes", profile["data_added_bytes"], kind),
            _point(snapshot_value, "profile_active", int(snapshot_value["active_kind"] == kind), kind),
            _point(snapshot_value, "profile_pending", int(kind in snapshot_value["pending"]), kind),
        ))
    resource = [
        _attribute("service.name", "Yeshua.Backup"),
        _attribute("service.namespace", "Yeshua"),
        _attribute("deployment.environment.name", snapshot_value["environment"]),
    ]
    return {"resourceMetrics": [{"resource": {"attributes": resource}, "scopeMetrics": [{
        "scope": {"name": "Yeshua.Backup"},
        "metrics": [{"name": "yeshua.backup.current", "description": "Sanitized current backup state",
                     "unit": "1", "gauge": {"dataPoints": points}}],
    }]}]}


def publish(snapshot_value, *, endpoint=None, sender=None):
    """Best effort only: observability failure must never fail the backup protocol."""
    try:
        payload = json.dumps(otlp(snapshot_value), separators=(",", ":")).encode()
        target = endpoint or os.environ.get("YESHUA_BACKUP_OTLP_ENDPOINT", DEFAULT_ENDPOINT)
        outgoing = http.Request(target, data=payload, headers={"Content-Type": "application/json"}, method="POST")
        response = (sender or http.urlopen)(outgoing, timeout=2)
        try:
            code = response.getcode()
            response.read(4096)
        finally:
            response.close()
        return 200 <= code < 300
    except Exception:
        return False
