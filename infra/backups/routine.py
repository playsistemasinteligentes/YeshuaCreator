"""Online SQL chains and deduplicated file snapshots using the existing operator."""

from datetime import datetime, timezone
import json
import os
from pathlib import Path
import shutil
import uuid


KINDS = {"full", "differential", "logs", "files", "check", "check-data"}


def configure_local(op, private_file, policy):
    import secrets
    base = op.private_directory(policy["staging"], create=True)
    with op.locked(base / "backup.lock"):
        document, _ = op.sql.load_credentials(op.ROOT, private_file, require_sql=False)
        before = op.digest(private_file)
        config = document.setdefault("Shared", {}).setdefault("Backup", {})
        if not isinstance(config, dict):
            raise op.Error("invalid_backup_configuration")
        if config.get("Repository"):
            raise op.Error("existing_external_repository_requires_explicit_transition")
        changed = False
        if not config.get("Password"):
            config["Password"] = secrets.token_urlsafe(48)
            changed = True
        if "Repository" not in config:
            config["Repository"] = ""
            changed = True
        if "Environment" not in config:
            config["Environment"] = {}
            changed = True
        if changed:
            if op.digest(private_file) != before:
                raise op.Error("credentials_changed_during_configuration")
            op.write(private_file, document)
        op.restic_env(document)
        repository = base / "repository"
        if not repository.exists():
            op.restic(document, ["init"])
        elif not (repository / "config").is_file():
            raise op.Error("existing_local_repository_directory_is_not_initialized")
        else:
            op.restic(document, ["snapshots", "--json"])
        for name in ("state", "records", "intents", "metadata", "status"):
            op.private_directory(base / name, create=True)
        op.write(base / "external-destination.pending.json", {
            "status": "pending_user_selection", "recorded_at": op.now(),
            "local_repository": str(repository), "offsite": False,
            "host_loss_protection": False})
    return {"operation": "configure-local", "repository": str(repository), "offsite": False,
            "external_destination_pending": True, "secrets_printed": False}


def preflight(op, policy):
    base = op.private_directory(policy["staging"])
    if shutil.disk_usage(base).free < policy["minimum_free_bytes"]:
        raise op.Error("low_disk_backup_stopped_without_deleting_data")
    memory = {line.split(":")[0]: int(line.split()[1]) for line in Path("/proc/meminfo").read_text().splitlines()}
    if memory["MemAvailable"] // 1024 < policy["minimum_available_memory_mb"]:
        raise op.Error("low_memory_backup_deferred")
    return base


def read_records(op, base, *, source_machine=None):
    records = []
    for path in sorted((base / "records").glob("*.json")):
        op.absolute(path)
        entry = op.read(path)
        if entry.get("schema") != 1 or entry.get("source_machine") != (source_machine or op.machine_id()):
            raise op.Error("sql_catalog_schema_or_machine_mismatch")
        records.append(entry)
    return records


def lsn(op, value):
    if not isinstance(value, str) or not value.isdigit():
        raise op.Error("invalid_sql_backup_lsn")
    return int(value)


def chain(op, records, name):
    own = [r for r in records if r["database_name"] == name]
    fulls = [r for r in own if r["type"] == "D" and not r["is_copy_only"]]
    if not fulls:
        raise op.Error("managed_full_backup_missing")
    full = max(fulls, key=lambda r: r["created_at"])
    differentials = [r for r in own if r["type"] == "I" and r.get("differential_base_guid") == full["backup_guid"]]
    diff = max(differentials, key=lambda r: lsn(op, r["last_lsn"])) if differentials else None
    selected = [full] + ([diff] if diff else [])
    for part in selected:
        if part["family_guid"] != full["family_guid"] or part["first_fork"] != full["last_fork"] or part["last_fork"] != full["last_fork"]:
            raise op.Error("sql_recovery_fork_requires_dba_review")
    cursor = lsn(op, selected[-1]["last_lsn"])
    fork = selected[-1]["last_fork"]
    logs = sorted((r for r in own if r["type"] == "L" and lsn(op, r["last_lsn"]) > cursor), key=lambda r: lsn(op, r["last_lsn"]))
    for record in logs:
        if record["family_guid"] != full["family_guid"] or record["first_fork"] != fork or record["last_fork"] != fork:
            raise op.Error("sql_recovery_fork_requires_dba_review")
        if lsn(op, record["first_lsn"]) > cursor:
            raise op.Error("sql_log_chain_gap_detected")
        selected.append(record)
        cursor = lsn(op, record["last_lsn"])
    return selected


def validate_metadata(op, row, intent):
    expected = {"full": "D", "differential": "I", "logs": "L"}[intent["kind"]]
    if not row or row["database_name"] != intent["database_name"] or row["type"] != expected or not row["has_backup_checksums"] or row["is_copy_only"]:
        raise op.Error("native_backup_metadata_mismatch")
    for key in ("backup_guid", "first_fork", "last_fork", "family_guid"):
        try:
            uuid.UUID(row[key])
        except (ValueError, TypeError, KeyError):
            raise op.Error("invalid_native_backup_identity") from None
    for key in ("first_lsn", "last_lsn"):
        lsn(op, row[key])
    if row["type"] == "I" and row.get("differential_base_guid") != intent.get("base_guid"):
        raise op.Error("differential_base_changed_during_backup")


def complete_intent(op, base, password, client, intent, intent_path):
    row = op.sql.backup_metadata(password, client, intent["container_path"])
    validate_metadata(op, row, intent)
    op.sql.verify_native(password, client, intent["container_path"])
    path = op.absolute(intent["path"])
    native = Path("/root/YeshuaDB/persistent/sql/backup/yeshua-scheduled")
    if not path.is_relative_to(native) or not path.is_file():
        raise op.Error("native_backup_outside_dedicated_directory")
    os.chmod(path, 0o640)
    record = {**row, "schema": 1, "created_at": op.now(), "source_machine": op.machine_id(),
              "path": str(path), "sha256": op.digest(path), "files": intent["files"],
              "system": intent["system"], "run_id": intent["run_id"]}
    op.write(base / "records" / intent_path.name, record)
    intent_path.unlink()
    return record


def reconcile_intents(op, base, password, client):
    for path in sorted((base / "intents").glob("*.json")):
        op.absolute(path)
        intent = op.read(path)
        existing = base / "records" / path.name
        if existing.exists():
            record = op.read(existing)
            if op.digest(op.absolute(record["path"])) != record["sha256"]:
                raise op.Error("native_backup_record_checksum_mismatch")
            path.unlink()
        else:
            # A successful BACKUP LOG may have truncated the active log before
            # the operator crashed. Recover its receipt before taking another.
            complete_intent(op, base, password, client, intent, path)


def snapshot(op, document, policy, sources, kind, run_id):
    if kind == "files":
        op.storage_excludes(policy)
    output = op.restic(document, ["backup", "--json", "--host", policy["scope"], "--tag", "yeshua",
             "--tag", "scope=" + policy["scope"], "--tag", "kind=" + kind, "--tag", "run=" + run_id,
             *[str(p) for p in sources]])
    summaries = [item for line in output.splitlines() if line.strip()
                 for item in [json.loads(line)] if item.get("message_type") == "summary"]
    if len(summaries) != 1 or not op.HASH.fullmatch(summaries[0].get("snapshot_id", "")):
        raise op.Error("local_snapshot_receipt_missing")
    return {"snapshot_id": summaries[0]["snapshot_id"], "data_added_bytes": summaries[0].get("data_added"),
            "bytes_processed": summaries[0].get("total_bytes_processed"), "offsite": bool(document["Shared"]["Backup"].get("Repository"))}


def sql_cycle(op, document, password, policy, kind):
    base = preflight(op, policy)
    with op.locked(base / "backup.lock"):
        return _sql_cycle(op, document, password, policy, kind, base)


def native_kind(op, password, client, database, kind, records):
    system = database["database_id"] <= 4
    owned = [r for r in records if r["database_name"] == database["name"] and r["type"] == "D" and not r["is_copy_only"]]
    if kind == "logs":
        if system:
            return None, None
        # Onboard a newly created user database without waiting until Sunday.
        if not owned:
            return "full", None
        if database["recovery_model_desc"] not in {"FULL", "BULK_LOGGED"}:
            return None, None
    elif kind == "differential":
        if system or not owned:
            return "full", None
        latest = max(owned, key=lambda r: r["created_at"])
        current = op.sql.differential_base(password, client, database["name"])
        if not current or any(row.get("guid") != latest["backup_guid"] for row in current):
            return "full", None
        return "differential", latest["backup_guid"]
    return kind, None


def _sql_cycle(op, document, password, policy, kind, base):
    with op.locked("/var/lock/yeshua-deploy.lock"):
        metadata, client = op.sql.sql_inventory(password)
        if metadata.get("active_backup_restore"):
            raise op.Error("another_native_backup_or_restore_active")
        expected = op.sql.assess(metadata, op.sql.expected_databases(op.ROOT))
        if expected["missing_databases"]:
            raise op.Error("expected_database_missing")
        databases = [d for d in metadata["databases"] if d["name"] != "tempdb"]
        if any(d["state_desc"] != "ONLINE" or d.get("is_encrypted") for d in databases):
            raise op.Error("database_requires_readiness_review")
        reconcile_intents(op, base, password, client)
        records = read_records(op, base)
        run_id = datetime.now(timezone.utc).strftime("%Y%m%dT%H%M%SZ-") + uuid.uuid4().hex[:12]
        native = op.absolute(Path(policy["sql_data"]) / "backup" / "yeshua-scheduled")
        if not native.exists():
            native.mkdir(mode=0o700)
            os.chmod(native, 0o711)
        if native.stat().st_uid != 0 or native.stat().st_mode & 0o022:
            raise op.Error("native_backup_parent_owner_or_mode_mismatch")
        if not native.stat().st_mode & 0o001:
            raise op.Error("native_backup_parent_not_traversable_by_sql_process")
        uid = int(op.sql.run(["docker", "exec", op.sql.SQL_CONTAINER, "id", "-u"]))
        run = native / run_id
        run.mkdir(mode=0o700)
        os.chown(run, uid, -1)
        completed = []
        for database in databases:
            preflight(op, policy)
            estimate = int((database["data_allocated_mb"] + database["log_allocated_mb"]) * 1024 ** 2)
            if shutil.disk_usage(base).free < estimate + policy["minimum_free_bytes"]:
                raise op.Error("database_backup_would_exceed_disk_reserve")
            system = database["database_id"] <= 4
            selected_kind, base_guid = native_kind(op, password, client, database, kind, records)
            if selected_kind is None:
                continue
            key = op.hashlib.sha256(database["name"].encode()).hexdigest()[:20]
            filename = key + (".trn" if selected_kind == "logs" else ".bak")
            files = op.sql.database_files(password, client, database["name"])
            if not files or any(f["type_desc"] not in {"ROWS", "LOG"} for f in files):
                raise op.Error("unsupported_native_database_files")
            intent = {"schema": 1, "run_id": run_id, "database_name": database["name"],
                      "kind": selected_kind, "base_guid": base_guid, "system": system, "files": files,
                      "path": str(run / filename), "container_path": "/var/opt/mssql/backup/yeshua-scheduled/" + run_id + "/" + filename}
            intent_path = base / "intents" / (run_id + "-" + key + ".json")
            op.write(intent_path, intent)
            op.sql.backup_native(password, client, database["name"], intent["container_path"], selected_kind)
            record = complete_intent(op, base, password, client, intent, intent_path)
            records.append(record)
            completed.append(record)
        # Catalog and media are snapshotted together. The native directory is
        # append-only; a file is never overwritten or aged out behind a chain.
        chains = {}
        for name in sorted({r["database_name"] for r in records if not r["system"]}):
            chains[name] = [r["backup_guid"] for r in chain(op, records, name)]
        op.write(base / "state" / "sql-catalog.json", {"schema": 1, "source_machine": op.machine_id(),
                 "updated_at": op.now(), "sql_version": metadata["product_version"], "chains": chains, "restore_proven": False})
    # Do not block deployment for the repository write.
    receipt = snapshot(op, document, policy, [native, base / "records", base / "state" / "sql-catalog.json"], "sql", run_id)
    return {"operation": "scheduled", "kind": kind, "run_id": run_id,
            "database_backups": len(completed), "services_paused": False, "restore_proven": False, **receipt}


def files_cycle(op, document, private_file, policy):
    base = preflight(op, policy)
    with op.locked(base / "files.lock"):
        current = base / "metadata" / "current"
        if current.exists():
            # Generated scratch only; repository snapshots retain prior versions.
            op.absolute(current)
            shutil.rmtree(current)
        current.mkdir(mode=0o700)
        with op.locked("/var/lock/yeshua-deploy.lock"):
            revision = op.sql.run(["git", "-C", str(op.ROOT), "rev-parse", "HEAD"])
            op.snapshot_source(current, revision)
            containers = op.inspect_running()
            areas = op.mount_areas(containers, document, private_file, policy)
            op.write(current / "compose.json", op.frozen_projects(containers, document, private_file))
        sources = [Path("/root/YeshuaStorage/persistent"), private_file.parent,
                   op.absolute(document["Apps"]["Memorias"]["PrivateRoot"]), current]
        https = Path("/etc/letsencrypt")
        if https.exists():
            sources.append(https)
        for source in sources:
            op.absolute(source)
            if not source.is_dir() or source == base or base.is_relative_to(source):
                raise op.Error("unsafe_online_file_snapshot_source")
        run_id = datetime.now(timezone.utc).strftime("%Y%m%dT%H%M%SZ-") + uuid.uuid4().hex[:12]
        op.write(current / "coverage.json", {"created_at": op.now(), "consistency": "online_not_globally_atomic",
            "included": [str(p) for p in sources], "excluded_live_state": ["RabbitMQ", "Redis", "telemetry", "agent_volumes", "unmounted_container_uploads"],
            "excluded_volatile_paths": ["/root/YeshuaStorage/volatile", "/app/uploads"],
            "coordinated_areas_pending": [a for a in areas if not any(Path(a["path"]).is_relative_to(p) for p in sources)],
            "source_and_toolkit_rebuild_from_git": True, "coordinated_capture_pending": True,
            "docker_images_deferred": True, "restore_proven": False})
        # Budget a full new copy, even though Restic normally stores only changes.
        # Do not rely on deduplication to keep the production disk alive.
        estimate = op.sql.run(["du", "--apparent-size", "--summarize", "--block-size=1", "--", *[str(p) for p in sources]],
                              timeout=120, stage="online_files_capacity")
        source_bytes = sum(int(line.split()[0]) for line in estimate.splitlines())
        if source_bytes <= 0 or shutil.disk_usage(base).free < source_bytes + policy["minimum_free_bytes"]:
            raise op.Error("online_file_snapshot_would_exceed_disk_reserve")
        receipt = snapshot(op, document, policy, sources, "files", run_id)
    return {"operation": "scheduled", "kind": "files", "run_id": run_id, "services_paused": False,
            "file_selection": "persistent-roots-v1",
            "source_bytes_budget": source_bytes, "budget_includes_excluded_paths": False, "incremental_repository": True,
            "global_consistency": False, "coordinated_capture_pending": True, **receipt}


def scheduled(op, document, password, private_file, policy, kind):
    if kind not in KINDS:
        raise op.Error("invalid_scheduled_backup_kind")
    base = op.private_directory(policy["staging"])
    try:
        if kind in {"full", "differential", "logs"}:
            result = sql_cycle(op, document, password, policy, kind)
        elif kind == "files":
            result = files_cycle(op, document, private_file, policy)
        else:
            with op.locked(base / "backup.lock"), op.locked(base / "files.lock"):
                op.restic(document, ["check", *(["--read-data"] if kind == "check-data" else [])])
            result = {"operation": "scheduled", "kind": kind, "data_read": kind == "check-data"}
        result.update(status="completed", finished_at=op.now(), external_destination_pending=not bool(document["Shared"]["Backup"].get("Repository")), restore_proven=False)
        op.write(base / "status" / (kind + ".json"), result)
        return result
    except Exception as error:
        op.write(base / "status" / (kind + "-failure.json"), {"status": "failed", "kind": kind,
                 "failed_at": op.now(), "error": str(error) if isinstance(error, op.Error) else "backup_failed_details_omitted"})
        raise


def status(op, policy):
    base = op.private_directory(policy["staging"])
    return {"operation": "status", "external_destination_pending": (base / "external-destination.pending.json").exists(),
            "free_bytes": shutil.disk_usage(base).free, "minimum_free_bytes": policy["minimum_free_bytes"],
            "results": [op.read(p) for p in sorted((base / "status").glob("*.json"))], "restore_proven": False}


def restore_plan(op, policy):
    base = op.private_directory(policy["staging"])
    records = read_records(op, base)
    result = {}
    for name in sorted({r["database_name"] for r in records if not r["system"]}):
        selected = chain(op, records, name)
        for row in selected:
            if op.digest(op.absolute(row["path"])) != row["sha256"]:
                raise op.Error("restore_chain_checksum_mismatch")
        result[name] = [{"type": r["type"], "path": r["path"], "backup_guid": r["backup_guid"], "last_lsn": r["last_lsn"]} for r in selected]
    return {"operation": "sql-restore-plan", "databases": result, "sql_changed": False, "restore_proven": False}


def restore_sql_chain(op, password, policy, download_root, new_machine):
    root = op.private_directory(download_root)
    if not root.is_relative_to(Path("/root/YeshuaRecovery")):
        raise op.Error("restore_chain_requires_verified_download_directory")
    receipt = op.read(root / "download-receipt.json")
    if receipt.get("kind") != "sql" or not op.HASH.fullmatch(receipt.get("snapshot_id", "")) or not receipt.get("verified_at"):
        raise op.Error("restore_chain_requires_verified_sql_snapshot_receipt")
    catalog_root = root / Path(policy["staging"]).relative_to("/")
    catalog = op.read(catalog_root / "state/sql-catalog.json")
    if catalog.get("schema") != 1 or not catalog.get("source_machine"):
        raise op.Error("invalid_recovery_sql_catalog")
    if op.machine_id() != new_machine or op.machine_id() == catalog["source_machine"]:
        raise op.Error("incremental_restore_refused_on_source_or_unconfirmed_server")
    containers = op.sql.run(["docker", "ps", "--format", "{{.Names}}"] ).splitlines()
    if containers != [op.sql.SQL_CONTAINER]:
        raise op.Error("only_recovery_sql_may_run_during_chain_restore")
    metadata, client = op.sql.sql_inventory(password)
    if not catalog.get("sql_version") or metadata["product_version"] != catalog["sql_version"]:
        raise op.Error("incremental_restore_requires_captured_sql_version")
    if any(d["database_id"] > 4 for d in metadata["databases"]) or metadata.get("active_backup_restore"):
        raise op.Error("incremental_restore_requires_empty_user_database_destination")
    op.sql.assert_no_external_sessions(password, client)
    records = read_records(op, catalog_root, source_machine=catalog["source_machine"])
    selected = {name: chain(op, records, name) for name in sorted({r["database_name"] for r in records if not r["system"]})}
    if not selected:
        raise op.Error("empty_incremental_recovery_catalog")
    native = Path("/root/YeshuaDB/persistent/sql/backup/yeshua-scheduled")
    for rows in selected.values():
        for row in rows:
            try:
                if str(uuid.UUID(row["backup_guid"])) != row["backup_guid"].lower():
                    raise ValueError()
            except (ValueError, TypeError, KeyError, AttributeError):
                raise op.Error("invalid_recovery_backup_identity") from None
            original = Path(row["path"])
            if not original.is_relative_to(native):
                raise op.Error("recovery_media_path_outside_backup_area")
            source = op.absolute(root / original.relative_to("/"))
            if op.digest(source) != row["sha256"]:
                raise op.Error("incremental_restore_media_checksum_mismatch")
    required = sum(f.get("size_bytes", 0) for rows in selected.values() for f in rows[0]["files"])
    required += sum((root / Path(r["path"]).relative_to("/")).stat().st_size for rows in selected.values() for r in rows)
    if shutil.disk_usage("/root").free < required + policy["minimum_free_bytes"]:
        raise op.Error("insufficient_disk_for_incremental_recovery")
    incoming = op.absolute(Path(policy["sql_data"]) / "backup" / ("chain-" + uuid.uuid4().hex))
    if not incoming.parent.is_dir():
        raise op.Error("recovery_sql_backup_bind_not_prepared")
    incoming.mkdir(mode=0o700)
    uid = int(op.sql.run(["docker", "exec", op.sql.SQL_CONTAINER, "id", "-u"]))
    os.chown(incoming, uid, -1)
    parts = {}
    for name, rows in selected.items():
        parts[name] = []
        for row in rows:
            target = incoming / (row["backup_guid"] + ".bak")
            shutil.copyfile(root / Path(row["path"]).relative_to("/"), target)
            os.chown(target, uid, -1)
            os.chmod(target, 0o640)
            container_path = "/var/opt/mssql/backup/" + incoming.name + "/" + target.name
            op.sql.verify_native(password, client, container_path)
            parts[name].append((row, container_path))
    for name, media in parts.items():
        full, path = media[0]
        op.sql.restore_database(password, client, name, path, full["files"], recover=False)
        for row, path in media[1:]:
            op.sql.apply_restore_part(password, client, name, path, row["type"])
        op.sql.finish_restore(password, client, name)
    return {"operation": "restore-sql-chain", "databases": sorted(parts), "checkdb_passed": True,
            "system_state_pending_dba": True, "integrations_pending_reconciliation": True, "restore_proven": False}
