"""Central schedules over restricted SSH, reusing native SQL and Restic."""

import argparse
from contextlib import contextmanager, ExitStack
from datetime import datetime, timedelta, timezone
import importlib.util
import ipaddress
import json
import os
from pathlib import Path
import re
import stat
import subprocess
import sys
import time
import uuid

sys.dont_write_bytecode = True
PRIVATE = Path("/root/YeshuaPrivate/production/credentials.json")
BASE = Path("/root/YeshuaBackup/controller")
NAME = re.compile(r"[a-z][a-z0-9-]{0,39}")
ID = re.compile(r"[a-f0-9]{32}")
HASH = re.compile(r"[a-f0-9]{64}")
CAPTURE = ("full", "differential", "logs", "files")
CHECKS = ("check", "check-data")


def load(name):
    spec = importlib.util.spec_from_file_location("yeshua_control_" + name, Path(__file__).with_name(name + ".py"))
    module = importlib.util.module_from_spec(spec)
    sys.modules[spec.name] = module
    spec.loader.exec_module(module)
    return module


op = load("backup")
op.ROOT = Path(os.environ.get("YESHUA_APP_DIR", str(op.APP_ROOT)))
routine = load("routine")
source = load("source")


def run(args, *, timeout=60, input=None):
    result = subprocess.run(args, capture_output=True, text=True, input=input, timeout=timeout, check=False)
    if result.returncode:
        raise op.Error("control_command_failed_" + Path(args[0]).name)
    return result.stdout


def private_json(path):
    path = op.absolute(path)
    op.private_directory(path.parent)
    info = path.stat()
    if not stat.S_ISREG(info.st_mode) or info.st_uid != os.geteuid() or info.st_mode & 0o077:
        raise op.Error("controller_file_must_be_owned_and_0600")
    return op.read(path)


def policy():
    return op.checked_policy(Path(__file__).with_name("policy.json"))


def credentials():
    return op.sql.load_credentials(op.APP_ROOT, PRIVATE, require_sql=True)


def configuration():
    document = private_json(PRIVATE)
    config = document.get("Shared", {}).get("Backup", {}).get("Controller", {})
    if (config.get("Schema") != 1 or config.get("MachineId") != op.machine_id()
            or not isinstance(config.get("Sources"), list) or not config["Sources"]
            or type(config.get("MaxActiveCaptures")) is not int or not 1 <= config["MaxActiveCaptures"] <= 4):
        raise op.Error("invalid_controller_configuration")
    names, machines, repositories = set(), set(), set()
    for item in config["Sources"]:
        if (set(item) != {"Name", "Host", "Port", "MachineId", "RepositoryId", "ResticRepositoryId",
                          "RepositoryPath", "IdentityFile", "KnownHostsFile", "Password", "Scope", "Enabled"}
                or not NAME.fullmatch(item.get("Name", "")) or not ID.fullmatch(item.get("MachineId", ""))
                or not HASH.fullmatch(item.get("RepositoryId", "")) or not HASH.fullmatch(item.get("ResticRepositoryId", ""))
                or not re.fullmatch(r"yeshua-[a-z0-9-]+", item.get("Scope", ""))
                or type(item.get("Enabled")) is not bool or type(item.get("Port")) is not int or not 1 <= item["Port"] <= 65535):
            raise op.Error("invalid_controller_source")
        ipaddress.ip_address(item["Host"])
        repository = op.absolute(item["RepositoryPath"])
        if not repository.is_relative_to(Path("/srv/yeshua-backups")) or repository == Path("/srv/yeshua-backups"):
            raise op.Error("source_repository_outside_storage")
        for field in ("IdentityFile", "KnownHostsFile"):
            path = op.absolute(item[field])
            if not path.is_relative_to(PRIVATE.parent):
                raise op.Error("controller_ssh_files_require_private_root")
            op.private_directory(path.parent)
            info = path.stat()
            if not stat.S_ISREG(info.st_mode) or info.st_uid != 0 or info.st_mode & 0o077:
                raise op.Error("controller_ssh_files_must_be_root_0600")
        if (item["Name"] in names or item["MachineId"] in machines or str(repository) in repositories
                or item["MachineId"] == config["MachineId"]):
            raise op.Error("controller_sources_require_distinct_names_machines_and_repositories")
        names.add(item["Name"])
        machines.add(item["MachineId"])
        repositories.add(str(repository))
        op.restic_env(repository_document(item), local_repository=repository)
    return config


def repository_document(item):
    return {"Shared": {"Backup": {"Password": item["Password"]}}}


def local_restic(item, args, *, timeout=14400):
    return op.restic(repository_document(item), args, local_repository=item["RepositoryPath"], timeout=timeout)


def verify_repository(item):
    value = json.loads(local_restic(item, ["cat", "config"], timeout=30))
    if value.get("id") != item["ResticRepositoryId"]:
        raise op.Error("storage_repository_identity_mismatch")


def rpc(item, action, request=None, *, controller_machine=None):
    payload = {"protocol": 1, "action": action, "source_machine": item["MachineId"],
               "repository_id": item["RepositoryId"], "controller_machine": controller_machine or op.machine_id()}
    if request:
        payload.update(request_id=request["request_id"], kind=request["kind"])
    output = run(["ssh", "-F", "/dev/null", "-T", "-i", item["IdentityFile"], "-p", str(item["Port"]),
        "-o", "BatchMode=yes", "-o", "IdentitiesOnly=yes", "-o", "StrictHostKeyChecking=yes",
        "-o", "UserKnownHostsFile=" + item["KnownHostsFile"], "-o", "ConnectTimeout=5",
        "-o", "ServerAliveInterval=5", "-o", "ServerAliveCountMax=2",
        "yeshua-backup-control@" + item["Host"], "yeshua-backup-control-v1"],
        timeout=20, input=json.dumps(payload))
    if len(output) > 65536:
        raise op.Error("oversized_source_response")
    value = json.loads(output)
    if (not isinstance(value, dict) or value.get("source_machine") != item["MachineId"]
            or value.get("repository_id") != item["RepositoryId"]
            or request and any(value.get(k) != request[k] for k in ("request_id", "kind"))):
        raise op.Error("source_response_identity_mismatch")
    return value


def state_path(name):
    if not NAME.fullmatch(name):
        raise op.Error("invalid_source_name")
    op.private_directory(BASE, create=True)
    return BASE / (name + ".json")


@contextmanager
def controller_lock():
    # Calendar events must wait for a short reconciliation, not disappear on contention.
    deadline = time.monotonic() + 170
    with ExitStack() as stack:
        while True:
            try:
                stack.enter_context(op.locked(BASE / "controller.lock"))
                break
            except op.Error as error:
                if str(error) != "another_backup_or_deploy_holds_lock" or time.monotonic() >= deadline:
                    raise
                time.sleep(0.25)
        yield


def read_state(item):
    path = state_path(item["Name"])
    value = private_json(path) if path.exists() else {"schema": 1, "source_machine": item["MachineId"],
            "repository_id": item["RepositoryId"], "pending": {}, "active": None, "results": {}}
    if (value.get("schema") != 1 or value.get("source_machine") != item["MachineId"]
            or value.get("repository_id") != item["RepositoryId"]):
        raise op.Error("controller_state_binding_mismatch")
    return value


def health(value):
    now = datetime.now(timezone.utc)
    overdue = []
    for kind, seconds in {"logs": 1800, "files": 129600, "full": 691200, "differential": 216000,
                          "check": 172800, "check-data": 691200}.items():
        receipt = value["results"].get(kind, {})
        stamp = receipt.get("finished_at")
        if receipt.get("status") != "completed" or not stamp:
            overdue.append(kind)
            continue
        finished = datetime.fromisoformat(stamp)
        if finished.tzinfo is None or finished > now or (now - finished).total_seconds() > seconds:
            overdue.append(kind)
    return {"status": "attention" if overdue or value.get("last_error") else "current", "overdue": overdue,
            "functional_restore_proven": False}


def snapshot_confirmed(item, request, result):
    identifier = result.get("snapshot_id", "")
    if (result.get("status") != "completed" or result.get("repository_id") != item["RepositoryId"]
            or result.get("kind") != request["kind"] or not HASH.fullmatch(identifier)
            or not op.SET_ID.fullmatch(result.get("run_id", ""))):
        raise op.Error("invalid_source_delivery_receipt")
    verify_repository(item)
    snapshots = json.loads(local_restic(item, ["snapshots", "--json", identifier], timeout=30))
    expected = {"yeshua", "scope=" + item["Scope"], "run=" + result["run_id"],
                "kind=" + ("files" if request["kind"] == "files" else "sql")}
    if (len(snapshots) != 1 or snapshots[0].get("id") != identifier
            or snapshots[0].get("hostname") != item["Scope"]
            or not expected.issubset(snapshots[0].get("tags", []))):
        raise op.Error("snapshot_not_confirmed_at_storage")
    return dict(result, storage_confirmed_at=op.now(), source_machine=item["MachineId"])


def unit_active(name):
    return run(["systemctl", "show", name, "--property=ActiveState", "--value"]).strip() in {
        "active", "activating", "reloading", "deactivating"}


def reconcile(item, value, *, capture_slots, maintenance_active):
    if value.get("retry_after") and datetime.fromisoformat(value["retry_after"]) > datetime.now(timezone.utc):
        return
    active = value.get("active")
    if active:
        if active["kind"] in CHECKS:
            if not unit_active("yeshua-backup-maintenance@" + item["Name"] + "--" + active["kind"] + ".service"):
                # A worker writes its receipt and clears active under the same lock.
                value["pending"].setdefault(active["kind"], op.now())
                value["active"] = None
                raise op.Error("storage_check_interrupted")
            return
        response = rpc(item, "status", active)
        if response["status"] == "not_found":
            response = rpc(item, "start", active)
        if response["status"] == "completed":
            value["results"][active["kind"]] = snapshot_confirmed(item, active, response["result"])
            value["active"] = None
            value.pop("last_error", None)
        elif response["status"] == "failed":
            value["pending"].setdefault(active["kind"], op.now())
            value["active"] = None
            raise op.Error("source_backup_failed_see_source_journal")
        elif response["status"] == "busy":
            value["pending"].setdefault(active["kind"], op.now())
            value["active"] = None
        elif response["status"] not in {"queued", "running"}:
            raise op.Error("unexpected_source_job_status")
        return
    kind = next((k for k in (*CAPTURE, *CHECKS) if k in value["pending"]), None)
    if not kind:
        return
    if kind in CHECKS:
        if maintenance_active:
            return
        value["active"] = {"kind": kind, "started_at": op.now()}
        value["pending"].pop(kind)
        # Persist before starting, so the worker cannot race the accepted request.
        op.write(state_path(item["Name"]), value)
        run(["systemctl", "start", "--no-block", "yeshua-backup-maintenance@" + item["Name"] + "--" + kind + ".service"])
        return
    if capture_slots <= 0:
        return
    request = {"kind": kind, "request_id": uuid.uuid4().hex, "started_at": op.now()}
    value["active"] = request
    value["pending"].pop(kind)
    op.write(state_path(item["Name"]), value)
    response = rpc(item, "start", request)
    if response["status"] == "busy":
        value["active"] = None
        value["pending"].setdefault(kind, op.now())
    elif response["status"] not in {"queued", "running", "completed"}:
        raise op.Error("unexpected_source_job_status")


def controller(kind):
    op.private_directory(BASE, create=True)
    with controller_lock():
        config = configuration()
        items = [item for item in config["Sources"] if item["Enabled"]]
        if kind in routine.KINDS:
            for item in items:
                value = read_state(item)
                value["pending"].setdefault(kind, op.now())
                op.write(state_path(item["Name"]), value)
            return {"status": "scheduled", "kind": kind, "sources": len(items)}
        if kind != "tick":
            raise op.Error("invalid_controller_kind")
        cursor = BASE / "cursor.json"
        position = private_json(cursor).get("position", 0) if cursor.exists() else 0
        # Bounded round-robin: a disconnected source cannot stall all machines.
        selected = (items[position:] + items[:position])[:4]
        outcomes = []
        started = time.monotonic()
        for item in selected:
            if time.monotonic() - started >= 60:
                break
            states = [read_state(i) for i in items]
            captures = sum(bool(v["active"] and v["active"]["kind"] in CAPTURE) for v in states)
            maintenance_active = any(v["active"] and v["active"]["kind"] in CHECKS for v in states)
            value = read_state(item)
            try:
                reconcile(item, value, capture_slots=config["MaxActiveCaptures"] - captures,
                          maintenance_active=maintenance_active)
                outcomes.append({"source": item["Name"], "status": "reconciled"})
            except Exception as error:
                message = str(error) if isinstance(error, op.Error) else "controller_operation_failed"
                value["last_error"] = {"failed_at": op.now(), "error": message}
                value["retry_after"] = (datetime.now(timezone.utc) + timedelta(minutes=5)).isoformat()
                outcomes.append({"source": item["Name"], "status": "failed", "error": message})
            op.write(state_path(item["Name"]), value)
        op.write(cursor, {"position": (position + len(outcomes)) % len(items) if items else 0})
        return {"status": "failed" if any(o["status"] == "failed" for o in outcomes) else "reconciled", "sources": outcomes}


def maintenance(identifier):
    if "--" not in identifier:
        raise op.Error("invalid_maintenance_request")
    name, kind = identifier.rsplit("--", 1)
    if kind not in CHECKS or not NAME.fullmatch(name):
        raise op.Error("invalid_maintenance_request")
    item = next((i for i in configuration()["Sources"] if i["Name"] == name and i["Enabled"]), None)
    if not item:
        raise op.Error("unknown_controller_source")
    with op.locked(BASE / "maintenance.lock"):
        with controller_lock():
            value = read_state(item)
            if not value["active"] or value["active"]["kind"] != kind:
                raise op.Error("maintenance_not_scheduled")
        try:
            verify_repository(item)
            local_restic(item, ["check", *(["--read-data"] if kind == "check-data" else [])], timeout=42000)
            result = {"status": "completed", "finished_at": op.now(), "data_read": kind == "check-data",
                      "repository_id": item["RepositoryId"], "executed_on_storage": True}
        except Exception:
            result = {"status": "failed", "failed_at": op.now(), "error": "storage_repository_check_failed"}
        with controller_lock():
            value = read_state(item)
            value["results"][kind] = result
            value["active"] = None
            if result["status"] == "failed":
                value["pending"].setdefault(kind, op.now())
                value["retry_after"] = (datetime.now(timezone.utc) + timedelta(minutes=5)).isoformat()
                value["last_error"] = result
            else:
                value.pop("last_error", None)
            op.write(state_path(name), value)
        return result


def main():
    parser = argparse.ArgumentParser(description=__doc__)
    parser.add_argument("action", choices=["source-dispatch", "source-run", "source-activate", "source-access",
                                           "sql-safety", "controller", "maintenance", "probe", "status"])
    parser.add_argument("--request")
    parser.add_argument("--kind")
    parser.add_argument("--controller-machine")
    parser.add_argument("--controller-ip")
    parser.add_argument("--authorized-key", type=Path)
    args = parser.parse_args()
    if os.name != "posix" or os.geteuid() != 0:
        raise op.Error("control_requires_linux_root")
    os.umask(0o077)
    c = sys.modules[__name__]
    if args.action == "source-dispatch":
        # No arguments, shell fragments, paths or secrets are accepted over SSH.
        raw = sys.stdin.buffer.read(4097)
        if len(raw) > 4096:
            raise op.Error("oversized_control_request")
        return source.dispatch(c, json.loads(raw))
    if args.action == "source-run":
        return source.execute(c, args.request)
    if args.action == "source-activate":
        return source.activate(c, args.controller_machine)
    if args.action == "source-access":
        return source.configure_access(c, args.authorized_key.read_text(), args.controller_ip)
    if args.action == "sql-safety":
        try:
            return source.safety(c)
        except op.Error as error:
            if str(error) == "another_backup_or_deploy_holds_lock":
                return {"status": "deferred_existing_backup_or_deploy"}
            raise
    if args.action == "controller":
        return controller(args.kind)
    if args.action == "maintenance":
        return maintenance(args.request)
    config = configuration()
    if args.action == "probe":
        results = []
        for item in config["Sources"]:
            verify_repository(item)
            results.append(dict(rpc(item, "probe"), source=item["Name"]))
        return {"status": "ready", "sources": results}
    return {"status": "controller_status", "sources": [dict(read_state(i), name=i["Name"],
            enabled=i["Enabled"], health=health(read_state(i))) for i in config["Sources"]],
            "destructive_retention_enabled": False, "functional_restore_proven": False}


if __name__ == "__main__":
    try:
        result = main()
        print(json.dumps(result, ensure_ascii=True))
        raise SystemExit(1 if result.get("status") == "failed" else 0)
    except Exception as error:
        print(json.dumps({"status": "failed", "error": str(error) if isinstance(error, op.Error) else "control_failed_details_omitted"}))
        raise SystemExit(1)
