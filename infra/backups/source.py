"""Restricted control of the existing source executor; no resident agent."""

from datetime import datetime, timezone
import ipaddress
import os
from pathlib import Path
import re
import stat

USER = "yeshua-backup-control"
COMMAND = "/usr/bin/python3 -I /opt/yeshua-backup/current/infra/backups/control.py source-dispatch"
KINDS = ("full", "differential", "logs", "files")


def owner(c):
    path = Path(c.policy()["staging"]) / "state/controller-owner.json"
    if not path.exists():
        return None
    value = c.private_json(path)
    if (value.get("schema") != 1 or value.get("source_machine") != c.op.machine_id()
            or not re.fullmatch(r"[a-f0-9]{32}", value.get("controller_machine", ""))):
        raise c.op.Error("invalid_controller_ownership_do_not_reenable_local_schedules")
    return value


def state(c):
    return c.op.private_directory(Path(c.policy()["staging"]) / "control", create=True)


def binding(c):
    document, _ = c.credentials()
    return {"source_machine": c.op.machine_id(), "repository_id": c.op.repository_id(document)}


def request_id(c, value):
    if not isinstance(value, str) or not re.fullmatch(r"[a-f0-9]{32}", value):
        raise c.op.Error("invalid_request_id")
    return value


def request_path(c, identifier):
    directory = c.op.private_directory(state(c) / "requests", create=True)
    return directory / (request_id(c, identifier) + ".json")


def unit(identifier):
    return "yeshua-backup-request@" + identifier + ".service"


def status(c, path):
    value = c.private_json(path)
    if value["status"] in {"queued", "running"}:
        properties = dict(line.split("=", 1) for line in c.run([
            "systemctl", "show", unit(value["request_id"]), "--property=ActiveState,Result"]).splitlines())
        if properties.get("ActiveState") not in {"activating", "active", "reloading", "deactivating"}:
            if value["status"] == "queued":
                c.run(["systemctl", "start", "--no-block", unit(value["request_id"])])
            else:
                value = c.private_json(path)
                if value["status"] == "running":
                    value.update(status="failed", finished_at=c.op.now(), error="source_execution_interrupted")
                    c.op.write(path, value)
    return value


def dispatch(c, request):
    if not isinstance(request, dict) or request.get("protocol") != 1:
        raise c.op.Error("unsupported_control_protocol")
    action = request.get("action")
    fields = {"protocol", "action", "source_machine", "repository_id", "controller_machine"}
    if action in {"start", "status"}:
        fields |= {"request_id", "kind"}
        request_id(c, request.get("request_id"))
        if request.get("kind") not in KINDS:
            raise c.op.Error("unsupported_source_backup_kind")
    elif action != "probe":
        raise c.op.Error("unsupported_control_action")
    if set(request) != fields or not re.fullmatch(r"[a-f0-9]{32}", request.get("controller_machine", "")):
        raise c.op.Error("invalid_control_request_fields")
    identity = binding(c)
    if any(request.get(key) != value for key, value in identity.items()):
        raise c.op.Error("source_or_repository_binding_mismatch")
    ownership = owner(c)
    if ownership and ownership["controller_machine"] != request["controller_machine"]:
        raise c.op.Error("controller_owner_mismatch")
    if action == "probe":
        generated = Path(c.policy()["staging"]) / "state/sql-generated.json"
        return dict(identity, status="ready", centrally_managed=bool(ownership),
                    sql_generated=c.private_json(generated) if generated.exists() else None)
    if not ownership:
        raise c.op.Error("source_handoff_required")
    with c.op.locked(state(c) / "dispatch.lock"):
        path = request_path(c, request["request_id"])
        if path.exists():
            existing = c.private_json(path)
            if any(existing.get(key) != value for key, value in request.items() if key != "action"):
                raise c.op.Error("request_id_reused_with_different_payload")
            return status(c, path)
        if action == "status":
            return dict(identity, status="not_found", request_id=request["request_id"], kind=request["kind"])
        active = state(c) / "active.json"
        if active.exists():
            previous = status(c, request_path(c, c.private_json(active)["request_id"]))
            if previous["status"] in {"queued", "running"}:
                return dict(identity, status="busy", request_id=request["request_id"], kind=request["kind"])
        value = dict(request, action="start", status="queued", created_at=c.op.now())
        c.op.write(path, value)
        c.op.write(active, {"request_id": request["request_id"]})
        c.run(["systemctl", "start", "--no-block", unit(request["request_id"])])
        return value


def execute(c, identifier):
    path = request_path(c, identifier)
    with c.op.locked(state(c) / "execution.lock"):
        request = c.private_json(path)
        if request.get("status") != "queued":
            return {"status": "already_executed", "request_id": identifier}
        ownership = owner(c)
        if (not ownership or ownership["controller_machine"] != request["controller_machine"]
                or any(request.get(k) != v for k, v in binding(c).items())):
            raise c.op.Error("source_request_binding_changed")
        request.update(status="running", started_at=c.op.now())
        c.op.write(path, request)
        try:
            document, password = c.credentials()
            result = c.routine.scheduled(c.op, document, password, c.PRIVATE, c.policy(), request["kind"])
            request.update(status="completed", finished_at=c.op.now(), result=result)
        except Exception as error:
            request.update(status="failed", finished_at=c.op.now(),
                           error=str(error) if isinstance(error, c.op.Error) else "source_backup_failed")
            c.op.write(path, request)
            raise
        c.op.write(path, request)
        return {"status": "completed", "request_id": identifier, "kind": request["kind"]}


def safety(c):
    if not owner(c):
        return {"status": "standalone_no_safety_job_needed"}
    policy = c.policy()
    base = c.op.private_directory(policy["staging"])
    with c.op.locked(base / "execution.lock"):
        generated = base / "state/sql-generated.json"
        value = c.private_json(generated) if generated.exists() else {}
        stamp = datetime.fromisoformat(value["generated_at"]) if value.get("generated_at") else None
        if stamp and (stamp.tzinfo is None or stamp > datetime.now(timezone.utc)):
            raise c.op.Error("invalid_sql_generation_timestamp")
        if stamp and value.get("source_machine") == c.op.machine_id() and (
                datetime.now(timezone.utc) - stamp).total_seconds() < 1200:
            return {"status": "recent_native_sql_backup"}
        document, password = c.credentials()
        return c.routine.sql_cycle(c.op, document, password, policy, "logs", native_only=True)


def activate(c, controller_machine):
    if not re.fullmatch(r"[a-f0-9]{32}", controller_machine):
        raise c.op.Error("invalid_controller_machine")
    previous = owner(c)
    if previous and previous["controller_machine"] != controller_machine:
        raise c.op.Error("explicit_controller_transfer_required")
    base = c.op.private_directory(c.policy()["staging"])
    timers = ["yeshua-backup-" + kind + ".timer" for kind in c.routine.KINDS]
    # Exclude a legacy job already queued by systemd before handing off its timers.
    with c.op.locked(base / "execution.lock"), c.op.locked(state(c) / "dispatch.lock"):
        for kind in c.routine.KINDS:
            active = c.run(["systemctl", "show", "yeshua-backup@" + kind + ".service",
                            "--property=ActiveState", "--value"]).strip()
            if active in {"active", "activating", "deactivating"}:
                raise c.op.Error("wait_for_current_backup_before_handoff")
        c.op.write(base / "state/controller-owner.json", {"schema": 1, "source_machine": c.op.machine_id(),
                   "controller_machine": controller_machine, "activated_at": c.op.now()})
        c.run(["systemctl", "disable", "--now", *sorted(timers)])
        c.run(["systemctl", "enable", "--now", "yeshua-backup-sql-safety.timer"])
    return {"status": "controller_owns_schedules", "local_sql_safety": True, "applications_restarted": False}


def configure_access(c, public_key, controller_ip):
    import pwd
    storage = c.load("storage")
    key = storage.key_line(public_key, controller_ip)
    ipaddress.ip_address(controller_ip)
    try:
        account = pwd.getpwnam(USER)
    except KeyError:
        c.run(["useradd", "--system", "--user-group", "--home-dir", "/nonexistent", "--no-create-home",
               "--shell", "/bin/sh", USER])
        account = pwd.getpwnam(USER)
    if account.pw_uid == 0 or account.pw_dir != "/nonexistent" or account.pw_shell != "/bin/sh":
        raise c.op.Error("existing_controller_account_requires_review")
    storage.directory(Path("/etc/ssh/authorized_keys"))
    storage.managed_file(Path("/etc/ssh/authorized_keys") / USER, key, 0o644)
    sudo = Path("/etc/sudoers.d/yeshua-backup-control")
    storage.managed_file(sudo, USER + " ALL=(root) NOPASSWD: " + COMMAND + "\n", 0o440)
    c.run(["/usr/sbin/visudo", "-cf", str(sudo)])
    configuration = ("# Managed restricted backup controller; no interactive shell.\n"
        "Match User " + USER + "\n"
        "    ForceCommand /usr/bin/sudo -n -- " + COMMAND + "\n"
        "    AuthorizedKeysFile /etc/ssh/authorized_keys/" + USER + "\n"
        "    AuthenticationMethods publickey\n"
        "    PasswordAuthentication no\n"
        "    KbdInteractiveAuthentication no\n"
        "    PermitTTY no\n"
        "    DisableForwarding yes\n"
        "    PermitTunnel no\n"
        "Match all\n")
    target = Path("/etc/ssh/sshd_config.d/61-yeshua-backup-control.conf")
    created = storage.managed_file(target, configuration, 0o644)
    try:
        c.run(["/usr/sbin/sshd", "-t"])
        effective = dict(line.split(" ", 1) for line in c.run([
            "/usr/sbin/sshd", "-T", "-C", "user=" + USER + ",addr=" + controller_ip + ",host=controller"]).splitlines())
        expected = {"forcecommand": "/usr/bin/sudo -n -- " + COMMAND, "disableforwarding": "yes",
                    "passwordauthentication": "no", "authenticationmethods": "publickey", "permittty": "no",
                    "authorizedkeysfile": "/etc/ssh/authorized_keys/" + USER}
        if any(effective.get(k) != v for k, v in expected.items()):
            raise c.op.Error("effective_source_ssh_configuration_mismatch")
        c.run(["systemctl", "reload", "ssh"])
    except BaseException:
        if created:
            target.unlink()
        raise
    return {"status": "restricted_control_access_configured", "user": USER, "interactive_shell": False}
