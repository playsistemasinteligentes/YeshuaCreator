"""Explicit repository transitions; never infer data loss from a failed connection."""

import copy
import hashlib
import json
import re


def custody_fingerprint(repository, password):
    return hashlib.sha256(json.dumps(
        ["yeshua-backup-recovery-v1", repository, password], ensure_ascii=True).encode()).hexdigest()


def snapshot_signatures(snapshots):
    # Copy can assign a new ID; the immutable content tree and metadata must match.
    return {json.dumps([s["tree"], s["time"], s.get("hostname"), sorted(s.get("paths", [])),
                        sorted(s.get("tags", [])), s.get("username"), s.get("excludes", [])], sort_keys=True)
            for s in snapshots}


def finish_transition(op, base, target, custody):
    repository = op.restic_env(target)["RESTIC_REPOSITORY"]
    password = op.restic_env(target)["RESTIC_PASSWORD"]
    transferred = dict(custody, key_fingerprint=custody_fingerprint(repository, password),
                       repository_transferred_at=op.now(), previous_key_fingerprint=custody["key_fingerprint"])
    op.write(base / "state/recovery-key-custody.json", transferred)
    marker = base / "external-destination.pending.json"
    if marker.exists():
        marker.unlink()
    transition = base / "state/repository-transition.pending.json"
    transition.replace(base / "state" / ("repository-transition-" + op.repository_id(target)[:16] + ".json"))


def resume_transition(op, base, target):
    pending = base / "state/repository-transition.pending.json"
    if not pending.exists():
        return
    transfer = op.read(pending)
    environment = op.restic_env(target)
    custody = transfer["previous_custody"]
    if (transfer.get("source_machine") != op.machine_id()
            or transfer.get("repository") != environment["RESTIC_REPOSITORY"]
            or not transfer.get("data_read_verified") or not custody.get("operator_confirmed_external_copy")
            or custody.get("key_fingerprint") != custody_fingerprint(transfer["previous_repository"], environment["RESTIC_PASSWORD"])):
        raise op.Error("pending_repository_transition_requires_review")
    op.restic(target, ["check", "--read-data"])
    finish_transition(op, base, target, custody)


def start_new_sftp_history(op, private_file, policy, repository, identity, known_hosts, *, previous_repository,
                           initialize=False):
    """Operator-approved empty history, without accessing or deleting the previous repository."""
    if (type(initialize) is not bool or repository == previous_repository
            or not re.fullmatch(r"sftp:[a-z][a-z0-9-]*@[0-9.]+:/repository", repository)
            or not re.fullmatch(r"sftp:[a-z][a-z0-9-]*@[0-9.]+:/repository", previous_repository)):
        raise op.Error("invalid_new_history_transition")
    base = op.private_directory(policy["staging"])
    with op.locked(base / "backup.lock"), op.locked(base / "files.lock"):
        original, _ = op.sql.load_credentials(op.ROOT, private_file, require_sql=False)
        before = op.digest(private_file)
        if original["Shared"]["Backup"].get("Repository") != previous_repository:
            raise op.Error("source_repository_changed_repeat_pairing")
        source = op.restic_env(original)
        custody = op.read(base / "state/recovery-key-custody.json")
        if (custody.get("schema") != 1 or custody.get("source_machine") != op.machine_id()
                or custody.get("operator_confirmed_external_copy") is not True
                or custody.get("key_fingerprint") != custody_fingerprint(previous_repository, source["RESTIC_PASSWORD"])):
            raise op.Error("original_backup_key_custody_required_before_transition")
        target = copy.deepcopy(original)
        target["Shared"]["Backup"].update(Repository=repository, Sftp={
            "IdentityFile": str(identity), "KnownHostsFile": str(known_hosts)})
        op.restic_env(target)
        op.sftp_options(target)
        if initialize:
            op.restic(target, ["init"])
        # A retry may find the repository initialized by the previous attempt, never erase it.
        if json.loads(op.restic(target, ["snapshots", "--json"])) != []:
            raise op.Error("new_history_requires_empty_target_no_data_deleted")
        op.restic(target, ["check", "--read-data"])
        actual = json.loads(op.restic(target, ["cat", "config"]))
        if not isinstance(actual, dict) or not re.fullmatch(r"[a-f0-9]{64}", actual.get("id", "")):
            raise op.Error("invalid_pairing_repository_identity")
        if op.digest(private_file) != before:
            raise op.Error("credentials_changed_during_repository_transition")
        state = op.private_directory(base / "state", create=True)
        pending = state / "repository-transition.pending.json"
        if pending.exists():
            previous = op.read(pending)
            if (previous.get("source_machine") != op.machine_id() or previous.get("repository") != repository
                    or previous.get("previous_repository") != previous_repository or previous.get("new_history") is not True
                    or previous.get("restic_repository_id") != actual["id"]):
                raise op.Error("pending_repository_transition_requires_review")
        op.write(pending, {"source_machine": op.machine_id(), "previous_repository": previous_repository,
            "repository": repository, "restic_repository_id": actual["id"], "recorded_at": op.now(),
            "new_history": True, "snapshot_count": 0, "password_unchanged": True,
            "previous_custody": custody, "data_read_verified": True})
        op.write(private_file, target)
        finish_transition(op, base, target, custody)
        return {"operation": "start-new-sftp-history", "status": "completed", "repository": repository,
                "previous_history_deleted": False, "password_unchanged": True, "restore_proven": False}


def move_to_sftp(op, routine, private_file, policy, repository, identity, known_hosts, *, apply=False, initialize=False,
                 allow_empty_initial=False):
    if (not isinstance(repository, str) or not re.fullmatch(r"sftp:[a-z][a-z0-9-]*@[0-9.]+:/repository", repository)
            or identity is None or known_hosts is None):
        raise op.Error("explicit_sftp_user_ipv4_repository_and_private_ssh_paths_required")
    base = op.private_directory(policy["staging"])
    if apply and op.sql.run(["systemctl", "list-units", "--type=timer", "--state=active", "--plain", "--no-legend",
                             "yeshua-backup-*.timer"]).strip():
        raise op.Error("stop_backup_timers_before_repository_transition")
    with op.locked(base / "backup.lock"), op.locked(base / "files.lock"):
        original, _ = op.sql.load_credentials(op.ROOT, private_file, require_sql=False)
        before = op.digest(private_file)
        target = copy.deepcopy(original)
        settings = target["Shared"]["Backup"]
        settings.update(Repository=repository, Sftp={"IdentityFile": str(identity), "KnownHostsFile": str(known_hosts)})
        op.restic_env(target)
        op.sftp_options(target)
        if original["Shared"]["Backup"].get("Repository"):
            if original["Shared"]["Backup"] != settings:
                raise op.Error("only_local_to_sftp_transition_supported")
            op.restic(target, ["snapshots", "--json"])
            if apply:
                resume_transition(op, base, target)
            return {"operation": "move-to-sftp", "status": "already_configured", "repository": repository,
                    "local_history_deleted": False, "restore_proven": False}
        source = op.restic_env(original)
        receipt_path = base / "state/recovery-key-custody.json"
        custody = op.read(receipt_path)
        if (custody.get("schema") != 1 or custody.get("source_machine") != op.machine_id()
                or custody.get("operator_confirmed_external_copy") is not True
                or custody.get("key_fingerprint") != custody_fingerprint(source["RESTIC_REPOSITORY"], source["RESTIC_PASSWORD"])):
            raise op.Error("original_backup_key_custody_required_before_transition")
        snapshots = json.loads(op.restic(original, ["snapshots", "--json"]))
        if not snapshots and not (allow_empty_initial and apply):
            raise op.Error("local_backup_history_required_before_transition")
        if not apply:
            return {"operation": "move-to-sftp", "status": "planned", "source_snapshots": len(snapshots),
                    "repository": repository, "local_history_deleted": False, "credentials_changed": False}
        if initialize:
            op.restic(target, ["init", "--copy-chunker-params"], from_document=original)
        op.restic(target, ["copy"], from_document=original)
        copied = json.loads(op.restic(target, ["snapshots", "--json"]))
        if not snapshot_signatures(snapshots).issubset(snapshot_signatures(copied)):
            raise op.Error("remote_history_verification_failed_original_configuration_unchanged")
        op.restic(target, ["check", "--read-data"])
        if op.digest(private_file) != before:
            raise op.Error("credentials_changed_during_repository_transition")
        state = op.private_directory(base / "state", create=True)
        op.write(state / "repository-transition.pending.json", {
            "source_machine": op.machine_id(), "previous_repository": source["RESTIC_REPOSITORY"],
            "repository": repository, "snapshot_count": len(snapshots), "recorded_at": op.now(),
            "password_unchanged": True, "previous_custody": custody, "data_read_verified": True})
        # The key did not change. Preserve the real operator acknowledgement, not a new fabricated one.
        op.write(private_file, target)
        finish_transition(op, base, target, custody)
        return {"operation": "move-to-sftp", "status": "completed", "repository": repository,
                "copied_snapshots": len(snapshots), "data_read_verified": True, "password_unchanged": True,
                "local_history_deleted": False, "restore_proven": False}
