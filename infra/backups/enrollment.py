"""Storage setup and explicit SSH pairing; administrative sessions are temporary."""

from contextlib import contextmanager
import hashlib
import io
import ipaddress
import json
import os
from pathlib import Path
import re
import shlex
import subprocess
import tarfile
import time
import uuid

SFTP = re.compile(r"sftp:([a-z][a-z0-9-]{0,31})@(\d+\.\d+\.\d+\.\d+):/repository")
SOURCE_NAME_PROMPT = "Nome desta origem (exemplo production; ate 20 letras/numeros/hifen, comecando por letra):"
PEER_ERRORS = frozenset({
    "pairing_failed_details_omitted", "command_unavailable_or_timed_out", "another_backup_or_deploy_holds_lock",
    "operator_directory_must_be_owned_and_0700", "private_pairing_file_permissions_require_review",
    "pairing_private_key_requires_root_0600", "invalid_pairing_repository_identity",
    "original_backup_key_custody_required_before_transition", "pending_repository_transition_requires_review",
    "credentials_changed_during_repository_transition", "source_repository_changed_repeat_pairing",
    "new_history_requires_empty_target_no_data_deleted", "invalid_new_history_transition",
    "new_history_requires_explicit_confirmation", "initialize_only_allowed_for_confirmed_new_history",
    "explicit_controller_transfer_required", "explicit_previous_controller_required_to_replace_control_key",
    "existing_controller_account_requires_review", "effective_source_ssh_configuration_mismatch",
    "wait_for_current_backup_before_handoff", "wait_for_current_backups_before_storage_transition",
    "only_local_to_sftp_transition_supported", "stop_backup_timers_before_repository_transition",
    "remote_history_verification_failed_original_configuration_unchanged",
    "remote_history_missing_restore_or_confirm_new_history", "invalid_pairing_flags",
    "pairing_required_file_or_directory_missing", "pairing_file_permission_denied", "pairing_filesystem_operation_failed",
})


def source_name(value):
    value = value.lower()
    if not re.fullmatch(r"[a-z][a-z0-9-]{0,19}", value):
        raise ValueError("invalid_source_name")
    return value


def ssh_port(value):
    port = int(value)
    if not 1 <= port <= 65535:
        raise ValueError("invalid_ssh_port")
    return port


def ipv4_address(value):
    return str(ipaddress.IPv4Address(value))


def endpoint(s, address):
    value = str(ipaddress.ip_address(address))
    if any(ord(c) < 32 for c in value):
        raise s.op.Error("invalid_setup_peer_address")
    return value


def private_bytes(s, path, content):
    path = s.op.absolute(path)
    s.op.private_directory(path.parent)
    if path.exists() and (path.stat().st_uid != 0 or path.stat().st_mode & 0o077):
        raise s.op.Error("private_pairing_file_permissions_require_review")
    pending = path.with_name(path.name + ".pending")
    fd = os.open(pending, os.O_WRONLY | os.O_CREAT | os.O_EXCL | os.O_NOFOLLOW, 0o600)
    with os.fdopen(fd, "wb") as stream:
        stream.write(content)
        stream.flush()
        os.fsync(stream.fileno())
    os.replace(pending, path)


def command(s, args, *, input=None, timeout=180):
    result = subprocess.run(args, input=input, capture_output=True, timeout=timeout, check=False)
    if result.returncode:
        raise s.op.Error("pairing_command_failed_" + Path(args[0]).name)
    return result.stdout


@contextmanager
def admin_session(s, host, port=22, user="root"):
    host = endpoint(s, host)
    if type(port) is not int or not 1 <= port <= 65535 or not re.fullmatch(r"[a-z][a-z0-9_-]{0,30}", user):
        raise s.op.Error("invalid_administrative_ssh_endpoint")
    if user != "root":
        raise s.op.Error("bootstrap_requires_temporary_root_ssh_not_stored_password")
    directory = s.op.private_directory(s.BASE / "ssh", create=True)
    socket = directory / ("connection-" + uuid.uuid4().hex[:12])
    known = directory / "known_hosts"
    base = ["ssh", "-F", "/dev/null", "-S", str(socket), "-p", str(port), "-o", "ControlPersist=600",
            "-o", "UserKnownHostsFile=" + str(known), "-o", "StrictHostKeyChecking=ask",
            "-o", "ConnectTimeout=10", user + "@" + host]
    print("Acesso administrativo temporario a " + host + ". Confira a identidade SSH; digite a senha somente no prompt SSH.",
          file=__import__("sys").stderr)
    # OpenSSH uses /dev/tty for host confirmation/password; neither is placed in argv/config.
    while True:
        try:
            process = subprocess.run([*base[:-1], "-M", "-fN", base[-1]], check=False, timeout=300)
        except subprocess.TimeoutExpired:
            print("O tempo do acesso SSH expirou. Nenhuma etapa remota foi iniciada por esta tentativa.",
                  file=__import__("sys").stderr)
        else:
            if process.returncode == 0:
                break
            print("O acesso SSH nao foi concluido. A conexao pode ter expirado, sido recusada ou encerrada."
                  " Confira a mensagem do SSH acima e a senha do servidor de destino.", file=__import__("sys").stderr)
        # Only an explicit operator action retries authentication; remote operations are never replayed here.
        s.ask("Digite TENTAR para refazer somente o acesso SSH ou CANCELAR para sair:", {"TENTAR": True})
    try:
        yield [*base[:-1], "-o", "BatchMode=yes", base[-1]]
    finally:
        subprocess.run([*base[:-1], "-O", "exit", base[-1]], capture_output=True, timeout=20, check=False)


def send_toolkit(s, ssh):
    installer = s.load("install")
    buffer = io.BytesIO()
    with tarfile.open(fileobj=buffer, mode="w:gz") as archive:
        for name in installer.FILES:
            path = Path(__file__).with_name(name)
            if path.is_symlink() or not path.is_file():
                raise s.op.Error("pairing_toolkit_file_missing")
            archive.add(path, arcname="infra/backups/" + name, recursive=False)
    data = buffer.getvalue()
    digest = hashlib.sha256(data).hexdigest()
    target = "/root/YeshuaBackup/enrollment/" + digest[:20]
    receiver = ("import sys,io,tarfile,pathlib,os,hashlib;os.umask(0o077);"
                "data=sys.stdin.buffer.read(8388609);"
                "assert len(data)<=8388608 and hashlib.sha256(data).hexdigest()==" + repr(digest) + ";"
                "p=pathlib.Path(" + repr(target) + ");"
                "assert not any(x.is_symlink() for x in [p,*p.parents]);p.mkdir(parents=True,exist_ok=True,mode=0o700);"
                "a=tarfile.open(fileobj=io.BytesIO(data));"
                "assert all(i.isfile() and i.name.startswith('infra/backups/') and '..' not in pathlib.PurePosixPath(i.name).parts for i in a.getmembers());"
                "a.extractall(p,filter='data')")
    command(s, [*ssh, "python3 -I -c " + shlex.quote(receiver)], input=data)
    return target


def peer(s, ssh, directory, action, payload):
    remote = "python3 -I " + shlex.quote(directory + "/infra/backups/enrollment.py") + " peer --action " + action
    try:
        process = subprocess.run([*ssh, remote], input=json.dumps(payload).encode(), capture_output=True,
                                 timeout=14400, check=False)
    except (OSError, subprocess.TimeoutExpired):
        raise s.op.Error("pairing_peer_unavailable_or_timed_out") from None
    output = process.stdout
    if len(output) > 1048576:
        raise s.op.Error("oversized_pairing_response")
    try:
        result = json.loads(output)
    except (ValueError, UnicodeError):
        raise s.op.Error("invalid_pairing_response" if not process.returncode else "pairing_command_failed_ssh") from None
    if not isinstance(result, dict):
        raise s.op.Error("invalid_pairing_response")
    if result.get("status") == "failed":
        code = result.get("error")
        # Only known codes or the SQL runner's numeric diagnostic may cross this boundary, never raw output/secrets.
        numeric = isinstance(code, str) and re.fullmatch(
            r"command_failed_exit_-?[0-9]{1,3}_sql_codes_(?:[0-9]{3,6}(?:,[0-9]{3,6})*)?_categories_"
            r"(?:(?:login_rejected|client_option_rejected|connection_unavailable)(?:,(?:login_rejected|client_option_rejected|connection_unavailable))*)?", code)
        raise s.op.Error(code if isinstance(code, str) and (code in PEER_ERRORS or numeric) else "peer_setup_failed_details_omitted")
    if process.returncode:
        raise s.op.Error("pairing_command_failed_ssh")
    return result


def peer_failure(s, error):
    if isinstance(error, FileNotFoundError):
        code = "pairing_required_file_or_directory_missing"
    elif isinstance(error, PermissionError):
        code = "pairing_file_permission_denied"
    elif isinstance(error, OSError):
        code = "pairing_filesystem_operation_failed"
    else:
        code = str(error) if isinstance(error, s.op.Error) else "pairing_failed_details_omitted"
    return {"status": "failed", "error": code}


def confirm_new_history(s, value, source, repository, *, allowed):
    previous = source.get("repository", "")
    if not previous or previous == repository or not allowed:
        return False
    binding = {"source_machine": source["machine_id"], "previous_repository": previous,
               "repository": repository, "controller_machine": s.op.machine_id()}
    if value.get("new_history_authorized") != binding:
        s.confirm("A origem ainda aponta para " + previous + ". Iniciar NOVO historico neste storage, sem copiar nem apagar o destino anterior?", "NOVOHISTORICO")
        value["new_history_authorized"] = binding
        s.save(value)
    return True


def key(s, directory, comment):
    directory = s.op.private_directory(directory, create=True)
    path = directory / "id_ed25519"
    if not path.exists():
        command(s, ["ssh-keygen", "-q", "-t", "ed25519", "-N", "", "-C", comment, "-f", str(path)])
    if path.is_symlink() or path.stat().st_uid != 0 or path.stat().st_mode & 0o077:
        raise s.op.Error("pairing_private_key_requires_root_0600")
    public = command(s, ["ssh-keygen", "-y", "-f", str(path)]).decode().strip()
    return path, public


def prepare_storage(s, mode):
    def validate(document):
        backup = document.get("Shared", {}).get("Backup", {})
        settings = backup.get("Storage", {})
        endpoint(s, settings.get("Address", ""))
        if settings.get("Schema") != 1 or not isinstance(settings.get("Receivers", []), list):
            raise s.op.Error("storage_configuration_requires_schema_and_receivers")
        controller = backup.get("Controller", {})
        if (controller.get("Schema") != 1 or not isinstance(controller.get("Sources"), list)
                or type(controller.get("MaxActiveCaptures")) is not int or not 1 <= controller["MaxActiveCaptures"] <= 4):
            raise s.op.Error("invalid_initial_controller_configuration")
        names = set()
        storage = s.load("storage")
        for receiver in settings["Receivers"]:
            storage.source_layout(receiver.get("Layout"))
            storage.key_line(receiver["PublicKey"], receiver["SourceAddress"])
            if receiver["Name"] in names:
                raise s.op.Error("duplicate_receiver_name")
            names.add(receiver["Name"])
        if mode == "restore" and not controller["Sources"]:
            raise s.op.Error("restore_requires_preserved_controller_configuration_not_a_blank_template")
        for item in controller["Sources"]:
            receiver = next((r for r in settings["Receivers"] if r["Name"] == item["Name"]), None)
            if not receiver:
                raise s.op.Error("each_preserved_repository_requires_its_receiver_public_key")
            _, root, _ = storage.source_layout(receiver.get("Layout"))
            if (item.get("RepositoryPath") != str(root / "repository")
                    or not re.fullmatch(r"[a-f0-9]{64}", item.get("ResticRepositoryId", ""))
                    or not isinstance(item.get("Password"), str) or len(item["Password"]) < 20):
                raise s.op.Error("invalid_preserved_repository_configuration")
        return document
    # Existing deployments can recover their public receiver declaration without any password export.
    if s.PRIVATE.exists():
        existing = s.control.private_json(s.PRIVATE)
        backup = existing.get("Shared", {}).get("Backup", {})
        if "Storage" not in backup and backup.get("Controller", {}).get("Sources"):
            host = s.ask("Endereco IPv4 publico desta Storage VPS:", validator=ipv4_address)
            receivers = []
            for item in backup["Controller"]["Sources"]:
                if item["RepositoryPath"] == "/srv/yeshua-backups/repository":
                    path = Path("/etc/ssh/authorized_keys/yeshua-backup")
                    fields = path.read_text().split()
                    receivers.append({"Name": item["Name"], "Layout": None, "SourceAddress": item["Host"],
                                      "PublicKey": " ".join(fields[1:3])})
            backup["Storage"] = {"Schema": 1, "Address": endpoint(s, host), "Receivers": receivers}
            s.op.write(s.PRIVATE, existing)
    address = s.ask("Endereco IPv4 publico desta Storage VPS:", validator=ipv4_address) if not s.PRIVATE.exists() and mode == "new" else ""
    document = s.wait_file(s.PRIVATE, validate, {"SchemaVersion": 1, "Shared": {"Backup": {
        "Storage": {"Schema": 1, "Address": address, "Receivers": []},
        "Controller": {"Schema": 1, "MachineId": "", "MaxActiveCaptures": 2, "Sources": []}}}})
    controller = document["Shared"]["Backup"]["Controller"]
    if controller.get("MachineId") and controller["MachineId"] != s.op.machine_id():
        if mode != "restore":
            raise s.op.Error("storage_machine_changed_choose_restore_do_not_impersonate_previous_machine")
        s.confirm("Este JSON pertence ao storage anterior. Vincular a nova maquina e preservar a identidade anterior para a transferencia?", "VINCULAR")
        document["Shared"]["Backup"]["Storage"]["PreviousMachineId"] = controller["MachineId"]
        document["Shared"]["Backup"]["Storage"]["Address"] = s.ask("Endereco IPv4 publico da NOVA Storage VPS:", validator=ipv4_address)
    controller["MachineId"] = s.op.machine_id()
    s.op.write(s.PRIVATE, document)
    add = s.ask("Vincular agora um servidor de aplicativos? SIM ou NAO (pode estar fora do ar):", {"SIM": True, "S": True, "NAO": False, "N": False})
    result = {"pair_now": add}
    if add:
        result["peer_host"] = s.ask("IP IPv4 do servidor dos aplicativos:", validator=ipv4_address)
        result["peer_port"] = s.ask("Porta SSH do servidor dos aplicativos (1 a 65535; normalmente 22):", validator=ssh_port)
        result["source_name"] = s.ask(SOURCE_NAME_PROMPT, validator=source_name)
    return result


def receivers(s, document, *, restoring=False):
    settings = document["Shared"]["Backup"]["Storage"]
    storage = s.load("storage")
    for item in settings["Receivers"]:
        storage.configure(item["PublicKey"], item["SourceAddress"], item.get("Layout"), update_source_address=True,
                          adopt_repository=restoring)


def run_storage(s, value):
    s.op.private_directory(s.control.BASE, create=True)
    with s.op.locked(s.control.BASE / "enrollment.lock"):
        return _run_storage(s, value)


def _run_storage(s, value):
    document = s.control.private_json(s.PRIVATE)
    receivers(s, document, restoring=value["mode"] == "restore")
    storage_settings = document["Shared"]["Backup"]["Storage"]
    controller = document["Shared"]["Backup"]["Controller"]
    # Restore only makes existing repositories available. It NEVER initializes a missing old repository.
    for item in controller.get("Sources", []):
        path = s.op.absolute(item["RepositoryPath"])
        if not (path / "config").is_file():
            value["phase"] = "awaiting_repository"
            s.save(value)
            print("Repositorio ainda ausente: " + str(path) + ". Reponha a copia externa e repita o MESMO comando.", file=__import__("sys").stderr)
            return {"status": "storage_prepared_restore_pending", "schedules_enabled": False, "repository_initialized": False}
        s.control.verify_repository(item)
    if value.get("pair_now") and value["phase"] != "completed":
        with admin_session(s, value["peer_host"], value["peer_port"]) as ssh:
            directory = send_toolkit(s, ssh)
            item = peer(s, ssh, directory, "source-info", {})
            source_name = value["source_name"]
            previous = next((i for i in controller["Sources"] if i["Name"] == source_name), None)
            layout = None if previous and previous["RepositoryPath"] == "/srv/yeshua-backups/repository" else source_name
            user, root, _ = s.load("storage").source_layout(layout)
            public = item["public_key"]
            s.load("storage").configure(public, value["peer_host"], layout, update_source_address=True)
            record = {"Name": source_name, "Layout": layout, "SourceAddress": value["peer_host"], "PublicKey": public}
            storage_settings["Receivers"] = [r for r in storage_settings["Receivers"] if r["Name"] != source_name] + [record]
            identity, control_public = key(s, s.PRIVATE.parent / "shared/Backup/controller" / source_name, "yeshua-controller-" + source_name)
            pinned = command(s, [*ssh, "cat /etc/ssh/ssh_host_ed25519_key.pub"]).decode().strip()
            known = identity.with_name("known_hosts")
            known.write_text(("[" + value["peer_host"] + "]:" + str(value["peer_port"]) if value["peer_port"] != 22 else value["peer_host"])
                             + " " + " ".join(pinned.split()[:2]) + "\n")
            known.chmod(0o600)
            storage_host_key = Path("/etc/ssh/ssh_host_ed25519_key.pub").read_text().strip()
            destination = "sftp:" + user + "@" + storage_settings["Address"] + ":/repository"
            payload = {"repository": destination, "storage_address": storage_settings["Address"],
                       "storage_host_key": storage_host_key, "controller_public_key": control_public,
                       "controller_machine": s.op.machine_id(), "previous_controller": item.get("controller_machine"),
                       "initialize_target": not (root / "repository/config").is_file() and value["mode"] == "new"}
            if payload["previous_controller"] and payload["previous_controller"] != s.op.machine_id():
                s.confirm("A origem esta vinculada a outro controlador. Revogar a chave tecnica anterior e transferir para este storage?", "TRANSFERIR")
            payload["new_history"] = confirm_new_history(s, value, item, destination,
                allowed=value["mode"] == "new" and previous is None)
            payload["expected_repository"] = item.get("repository", "")
            result = peer(s, ssh, directory, "source-pair", payload)
            configured = {"Name": source_name, "Host": value["peer_host"], "Port": value["peer_port"],
                "MachineId": item["machine_id"], "RepositoryId": result["repository_id"],
                "ResticRepositoryId": result["restic_repository_id"], "RepositoryPath": str(root / "repository"),
                "Scope": item["scope"], "IdentityFile": str(identity), "KnownHostsFile": str(known),
                "Password": item["backup_password"], "Enabled": True}
            # A restored source gets a new machine-id; preserve old operational receipts instead of impersonating it.
            with s.control.controller_lock():
                old_state = s.control.BASE / (source_name + ".json")
                if old_state.exists():
                    observed = s.control.private_json(old_state)
                    if observed.get("source_machine") != configured["MachineId"] or observed.get("repository_id") != configured["RepositoryId"]:
                        archive = s.op.private_directory(s.control.BASE / "previous", create=True)
                        os.replace(old_state, archive / (source_name + "-" + uuid.uuid4().hex + ".json"))
                controller["Sources"] = [i for i in controller["Sources"] if i["Name"] != source_name] + [configured]
                s.op.write(s.PRIVATE, document)
            s.control.verify_repository(configured)
            peer(s, ssh, directory, "source-activate", payload)
            s.control.rpc(configured, "probe")
    enabled = [i for i in controller.get("Sources", []) if i.get("Enabled")]
    if not enabled:
        value["phase"] = "awaiting_source"
        s.save(value)
        return {"status": "storage_ready_source_pairing_pending", "schedules_enabled": False}
    # A missing source must not prevent access to the restored repository.
    ready = []
    for item in enabled:
        try:
            probe = s.control.rpc(item, "probe")
            if probe.get("centrally_managed"):
                ready.append(item)
        except s.op.Error:
            pass
    if not ready:
        value["phase"] = "awaiting_source"
        s.save(value)
        return {"status": "storage_ready_source_pairing_pending", "schedules_enabled": False}
    installer = s.load("install")
    s.control.run(["systemctl", "enable", "--now", *installer.CONTROLLER_TIMERS, "yeshua-backup-controller-tick.timer"])
    queued = value["phase"] != "completed"
    if queued:
        for kind in ("full", "differential", "logs", "files", "check", "check-data"):
            s.control.controller(kind)
    value.update(phase="completed", completed_at=s.op.now())
    s.save(value)
    return {"status": "storage_ready", "schedules_enabled": True, "initial_proofs_queued": queued,
            "restore_proven": False, "external_copy_pending": True}


def source_info(s):
    document, _ = s.op.sql.load_credentials(s.op.APP_ROOT, s.PRIVATE, require_sql=False)
    s.op.restic_env(document)
    path, public = key(s, s.PRIVATE.parent / "shared/Backup/ssh", "yeshua-source-backup")
    ownership = s.control.source.owner(s.control)
    return {"machine_id": s.op.machine_id(), "scope": s.control.policy()["scope"], "public_key": public,
            "backup_password": document["Shared"]["Backup"]["Password"],
            "repository": document["Shared"]["Backup"].get("Repository", ""),
            "controller_machine": ownership["controller_machine"] if ownership else None}


def source_pair(s, payload):
    address = endpoint(s, payload["storage_address"])
    if not re.fullmatch(r"[a-f0-9]{32}", payload.get("controller_machine", "")):
        raise s.op.Error("invalid_pairing_controller_identity")
    if payload["controller_machine"] == s.op.machine_id():
        raise s.op.Error("application_and_storage_roles_require_different_machines")
    if not SFTP.fullmatch(payload.get("repository", "")) or SFTP.fullmatch(payload["repository"])[2] != address:
        raise s.op.Error("pairing_repository_address_mismatch")
    if any(type(payload.get(field, False)) is not bool for field in ("initialize_target", "new_history")):
        raise s.op.Error("invalid_pairing_flags")
    base = s.op.private_directory(s.control.policy()["staging"])
    control = s.control.source.state(s.control)
    # Exclude controller captures, SQL safety and newly queued requests while switching the connection.
    with s.op.locked(control / "execution.lock"), s.op.locked(base / "execution.lock"), s.op.locked(control / "dispatch.lock"):
        return _source_pair(s, payload, address, base)


def _source_pair(s, payload, address, base):
    document, _ = s.op.sql.load_credentials(s.op.APP_ROOT, s.PRIVATE, require_sql=False)
    before = s.op.digest(s.PRIVATE)
    config = document["Shared"]["Backup"]
    old = config.get("Repository", "")
    if "expected_repository" in payload and old != payload["expected_repository"]:
        raise s.op.Error("source_repository_changed_repeat_pairing")
    path, _ = key(s, s.PRIVATE.parent / "shared/Backup/ssh", "yeshua-source-backup")
    host_key = payload["storage_host_key"].strip().split()
    s.load("storage").key_line(" ".join(host_key[:2]), address)
    content = address + " " + " ".join(host_key[:2]) + "\n"
    target_id = hashlib.sha256((payload["repository"] + "\n" + content).encode()).hexdigest()
    targets = s.op.private_directory(path.parent / "targets", create=True)
    target = s.op.private_directory(targets / target_id, create=True)
    known = target / "known_hosts"
    # Candidate trust is isolated: a failed enrollment must not break the active repository's SSH pin.
    private_bytes(s, known, content.encode())
    settings = {"IdentityFile": str(path), "KnownHostsFile": str(known)}
    if not old:
        installer = s.load("install")
        active_timers = []
        for timer in installer.BACKUP_TIMERS:
            result = subprocess.run(["systemctl", "is-enabled", timer], capture_output=True, text=True, check=False)
            if result.stdout.strip() == "enabled":
                active_timers.append(timer)
        if active_timers:
            s.control.run(["systemctl", "disable", "--now", *active_timers])
        try:
            deadline = time.monotonic() + 14400
            while any(s.control.unit_active("yeshua-backup@" + kind + ".service") for kind in s.routine.KINDS):
                if time.monotonic() >= deadline:
                    raise s.op.Error("wait_for_current_backups_before_storage_transition")
                time.sleep(3)
            s.load("destination").move_to_sftp(s.op, s.routine, s.PRIVATE, s.control.policy(), payload["repository"],
                path, known, apply=True, initialize=payload.get("initialize_target", False), allow_empty_initial=True)
        except BaseException:
            if active_timers and not s.control.source.owner(s.control):
                s.control.run(["systemctl", "enable", "--now", *active_timers])
            raise
        document, _ = s.op.sql.load_credentials(s.op.APP_ROOT, s.PRIVATE, require_sql=False)
    else:
        destination = s.load("destination")
        if old != payload["repository"] and payload.get("new_history") is True:
            if payload.get("expected_repository") != old:
                raise s.op.Error("new_history_requires_explicit_confirmation")
            destination.start_new_sftp_history(s.op, s.PRIVATE, s.control.policy(), payload["repository"], path, known,
                previous_repository=old, initialize=payload.get("initialize_target", False))
            document, _ = s.op.sql.load_credentials(s.op.APP_ROOT, s.PRIVATE, require_sql=False)
        else:
            if payload.get("initialize_target"):
                raise s.op.Error("initialize_only_allowed_for_confirmed_new_history")
            candidate = json.loads(json.dumps(document))
            candidate["Shared"]["Backup"].update(Repository=payload["repository"], Sftp=settings)
            with s.op.locked(base / "backup.lock"), s.op.locked(base / "files.lock"):
                snapshots = json.loads(s.op.restic(candidate, ["snapshots", "--json"]))
                if old != payload["repository"] and not snapshots:
                    raise s.op.Error("remote_history_missing_restore_or_confirm_new_history")
                s.op.restic(candidate, ["cat", "config"])
                if s.op.digest(s.PRIVATE) != before:
                    raise s.op.Error("credentials_changed_during_repository_transition")
                if old != payload["repository"]:
                    s.op.write(base / "previous-repository.json", {"repository": old, "changed_at": s.op.now()})
                s.op.write(s.PRIVATE, candidate)
                destination.resume_transition(s.op, base, candidate)
                document = candidate
    installer = s.load("install")
    installer.install(prepare_only=True)
    s.control.source.configure_access(s.control, payload["controller_public_key"], address,
                                     previous_controller=payload.get("previous_controller"))
    actual = json.loads(s.op.restic(document, ["cat", "config"]))
    return {"status": "source_prepared", "repository_id": s.op.repository_id(document), "restic_repository_id": actual["id"]}


def authorize_recovery(s, document):
    match = SFTP.fullmatch(document["Shared"]["Backup"]["Repository"])
    if not match:
        raise s.op.Error("automatic_recovery_pairing_requires_sftp_ipv4_repository")
    identity = document["Shared"]["Backup"]["Sftp"]["IdentityFile"]
    public = command(s, ["ssh-keygen", "-y", "-f", identity]).decode().strip()
    port = s.ask("Porta SSH administrativa do storage (1 a 65535; normalmente 22):", validator=ssh_port)
    with admin_session(s, match[2], port) as ssh:
        directory = send_toolkit(s, ssh)
        peer(s, ssh, directory, "authorize-recovery", {"user": match[1], "public_key": public})
        pinned = command(s, [*ssh, "cat /etc/ssh/ssh_host_ed25519_key.pub"]).decode().strip()
    known = s.OPERATOR.parent / "known_hosts"
    known.write_text(match[2] + " " + " ".join(pinned.split()[:2]) + "\n")
    known.chmod(0o600)
    document["Shared"]["Backup"]["Sftp"]["KnownHostsFile"] = str(known)
    s.op.write(s.OPERATOR, document)


def pair_from_source(s, value):
    document = s.control.private_json(s.PRIVATE)
    match = SFTP.fullmatch(document["Shared"]["Backup"].get("Repository", ""))
    address = value.get("storage_address") or (match[2] if match else None)
    if not address:
        raise s.op.Error("storage_address_required_for_pairing")
    port = value.get("storage_port") or s.ask("Porta SSH administrativa do storage (1 a 65535; normalmente 22):", validator=ssh_port)
    info = source_info(s)
    name = value.get("source_name") or s.ask(SOURCE_NAME_PROMPT, validator=source_name)
    public_host = Path("/etc/ssh/ssh_host_ed25519_key.pub").read_text().strip()
    with admin_session(s, address, port) as ssh:
        directory = send_toolkit(s, ssh)
        offer = peer(s, ssh, directory, "storage-offer", {"name": name, "source": info,
                     "source_port": 22, "source_host_key": public_host,
                     "existing_user": match[1] if match else None})
        # The storage public identity is read over the authenticated administrative session.
        offer["storage_host_key"] = command(s, [*ssh, "cat /etc/ssh/ssh_host_ed25519_key.pub"]).decode().strip()
        offer["previous_controller"] = info.get("controller_machine")
        offer["expected_repository"] = info.get("repository", "")
        offer["new_history"] = confirm_new_history(s, value, info, offer["repository"],
            allowed=value["mode"] == "new" and offer.get("new_source") is True)
        paired = source_pair(s, offer)
        s.control.source.activate(s.control, offer["controller_machine"], previous_controller=info.get("controller_machine"))
        peer(s, ssh, directory, "storage-confirm", {"name": name, "source_machine": info["machine_id"], **paired})


def storage_offer(s, payload):
    name = payload.get("name", "")
    if not re.fullmatch(r"[a-z][a-z0-9-]{0,19}", name):
        raise s.op.Error("invalid_pairing_source_name")
    installer = s.load("install")
    installer.install(role="controller", prepare_only=True)
    document = s.control.private_json(s.PRIVATE)
    backup = document["Shared"]["Backup"]
    settings, controller = backup["Storage"], backup["Controller"]
    if controller["MachineId"] != s.op.machine_id():
        raise s.op.Error("prepare_storage_identity_before_source_pairing")
    source = payload["source"]
    if (not re.fullmatch(r"[a-f0-9]{32}", source.get("machine_id", ""))
            or not re.fullmatch(r"yeshua-[a-z0-9-]+", source.get("scope", ""))
            or type(payload.get("source_port")) is not int or not 1 <= payload["source_port"] <= 65535):
        raise s.op.Error("invalid_source_offer")
    source_ip = endpoint(s, os.environ.get("SSH_CONNECTION", "").split()[0])
    old = next((i for i in controller.get("Sources", []) if i["Name"] == name), None)
    pending = next((i for i in settings.get("PendingOffers", []) if i["Name"] == name), None)
    if not old and pending:
        old = pending
    layout = None if payload.get("existing_user") == "yeshua-backup" else name
    storage = s.load("storage")
    user, root, _ = storage.source_layout(layout)
    if payload.get("existing_user") and user != payload["existing_user"]:
        raise s.op.Error("restore_repository_user_layout_mismatch")
    storage.configure(source["public_key"], source_ip, layout, update_source_address=True)
    identity, public = key(s, s.PRIVATE.parent / "shared/Backup/controller" / name, "yeshua-controller-" + name)
    known = identity.with_name("known_hosts")
    host_key = payload["source_host_key"].strip().split()
    storage.key_line(" ".join(host_key[:2]), source_ip)
    known.write_text((source_ip if payload["source_port"] == 22 else "[" + source_ip + "]:" + str(payload["source_port"]))
                     + " " + " ".join(host_key[:2]) + "\n")
    known.chmod(0o600)
    initialized = (root / "repository/config").is_file()
    pending_offer = old and old.get("ResticRepositoryId") == "0" * 64 and not old.get("Enabled")
    if old and not initialized and not pending_offer:
        raise s.op.Error("old_repository_missing_restore_data_before_pairing")
    entry = {"Name": name, "Host": source_ip, "Port": payload["source_port"], "MachineId": source["machine_id"],
             "RepositoryId": "0" * 64, "ResticRepositoryId": old["ResticRepositoryId"] if old else "0" * 64,
             "RepositoryPath": str(root / "repository"), "Scope": source["scope"], "IdentityFile": str(identity),
             "KnownHostsFile": str(known), "Password": source["backup_password"], "Enabled": False}
    if old and not pending_offer:
        s.control.verify_repository(dict(entry, ResticRepositoryId=old["ResticRepositoryId"]))
    settings["PendingOffers"] = [i for i in settings.get("PendingOffers", []) if i["Name"] != name] + [entry]
    record = {"Name": name, "Layout": layout, "SourceAddress": source_ip, "PublicKey": source["public_key"]}
    settings["Receivers"] = [i for i in settings["Receivers"] if i["Name"] != name] + [record]
    s.op.write(s.PRIVATE, document)
    return {"status": "storage_offered", "repository": "sftp:" + user + "@" + settings["Address"] + ":/repository",
            "storage_address": settings["Address"], "controller_machine": s.op.machine_id(),
            "controller_public_key": public, "initialize_target": not initialized,
            "new_source": not old or bool(pending_offer)}


def storage_confirm(s, payload):
    document = s.control.private_json(s.PRIVATE)
    backup = document["Shared"]["Backup"]
    controller, settings = backup["Controller"], backup["Storage"]
    item = next((i for i in settings.get("PendingOffers", []) if i["Name"] == payload["name"]), None)
    if not item or item["MachineId"] != payload["source_machine"]:
        raise s.op.Error("source_offer_confirmation_identity_mismatch")
    for field, source_field in (("RepositoryId", "repository_id"), ("ResticRepositoryId", "restic_repository_id")):
        if not re.fullmatch(r"[a-f0-9]{64}", payload.get(source_field, "")):
            raise s.op.Error("invalid_pairing_repository_identity")
        item[field] = payload[source_field]
    s.control.verify_repository(item)
    probe = s.control.rpc(item, "probe")
    if not probe.get("centrally_managed"):
        raise s.op.Error("source_has_not_handed_off_schedules")
    s.op.private_directory(s.control.BASE, create=True)
    with s.control.controller_lock():
        state = s.control.BASE / (item["Name"] + ".json")
        if state.exists():
            previous = s.control.private_json(state)
            if previous.get("source_machine") != item["MachineId"] or previous.get("repository_id") != item["RepositoryId"]:
                archive = s.op.private_directory(s.control.BASE / "previous", create=True)
                os.replace(state, archive / (item["Name"] + "-" + uuid.uuid4().hex + ".json"))
        item["Enabled"] = True
        controller["Sources"] = [i for i in controller["Sources"] if i["Name"] != payload["name"]] + [item]
        settings["PendingOffers"] = [i for i in settings.get("PendingOffers", []) if i["Name"] != payload["name"]]
        s.op.write(s.PRIVATE, document)
    installer = s.load("install")
    s.control.run(["systemctl", "enable", "--now", *installer.CONTROLLER_TIMERS, "yeshua-backup-controller-tick.timer"])
    for kind in ("full", "differential", "logs", "files", "check", "check-data"):
        s.control.controller(kind)
    return {"status": "source_paired", "initial_proofs_queued": True}


def peer_action(s, action, payload):
    if action in {"storage-offer", "storage-confirm", "authorize-recovery"}:
        s.op.private_directory(s.control.BASE, create=True)
        with s.op.locked(s.control.BASE / "enrollment.lock"):
            return _peer_action(s, action, payload)
    return _peer_action(s, action, payload)


def _peer_action(s, action, payload):
    if action == "source-info":
        return source_info(s)
    if action == "source-pair":
        return source_pair(s, payload)
    if action == "source-activate":
        return s.control.source.activate(s.control, payload["controller_machine"], previous_controller=payload.get("previous_controller"))
    if action == "storage-offer":
        return storage_offer(s, payload)
    if action == "storage-confirm":
        return storage_confirm(s, payload)
    if action == "authorize-recovery":
        storage = s.load("storage")
        document = s.control.private_json(s.PRIVATE)
        source_ip = endpoint(s, os.environ.get("SSH_CONNECTION", "").split()[0])
        found = None
        for item in document["Shared"]["Backup"]["Storage"]["Receivers"]:
            user, _, _ = storage.source_layout(item.get("Layout"))
            if user == payload["user"]:
                if item["PublicKey"].strip().split()[:2] != payload["public_key"].strip().split()[:2]:
                    raise s.op.Error("recovery_transport_key_does_not_match_registered_source")
                storage.configure(payload["public_key"], source_ip, item.get("Layout"), update_source_address=True)
                item["SourceAddress"] = source_ip
                found = item
        if not found:
            raise s.op.Error("recovery_source_not_registered_in_storage")
        s.op.write(s.PRIVATE, document)
        return {"status": "recovery_source_authorized", "source_ip": source_ip}
    raise s.op.Error("unsupported_pairing_action")


if __name__ == "__main__":
    import argparse
    import importlib.util
    import sys
    spec = importlib.util.spec_from_file_location("yeshua_peer_setup", Path(__file__).with_name("setup.py"))
    setup = importlib.util.module_from_spec(spec)
    sys.modules[spec.name] = setup
    spec.loader.exec_module(setup)
    parser = argparse.ArgumentParser(description=__doc__)
    parser.add_argument("peer", choices=["peer"])
    parser.add_argument("--action", required=True, choices=["source-info", "source-pair", "source-activate", "authorize-recovery", "storage-offer", "storage-confirm"])
    args = parser.parse_args()
    try:
        if os.name != "posix" or os.geteuid() != 0:
            raise setup.op.Error("pairing_requires_linux_root")
        os.umask(0o077)
        raw = sys.stdin.buffer.read(65537)
        if len(raw) > 65536:
            raise setup.op.Error("oversized_pairing_request")
        print(json.dumps(peer_action(setup, args.action, json.loads(raw))))
    except Exception as error:
        print(json.dumps(peer_failure(setup, error)))
        raise SystemExit(1)
