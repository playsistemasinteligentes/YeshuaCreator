"""Data-only server recovery using the existing SQL/file restorers and Compose."""

from datetime import datetime
import json
import os
from pathlib import Path
import re
import time
import uuid

REVISION = re.compile(r"[a-f0-9]{40}")
IMAGE = re.compile(r"[a-z0-9][a-z0-9./:_-]*@sha256:[a-f0-9]{64}")
SERVICE = re.compile(r"[a-zA-Z0-9][a-zA-Z0-9_.-]{0,100}")


def capture_contract(op, containers, source):
    images, projects, sql_uid = {}, {}, None
    for container in containers:
        if not op.managed_project(container):
            continue
        labels = container["Config"]["Labels"]
        project, service = labels["com.docker.compose.project"], labels["com.docker.compose.service"]
        paths = op.compose_source_files(container, revision=source["revision"])
        if any(not p.is_relative_to(op.ROOT / "infra") for p in paths):
            raise op.Error("recovery_compose_must_belong_to_repository_infra")
        entry = projects.setdefault(project, {"files": [p.relative_to(op.ROOT).as_posix() for p in paths], "services": {}})
        if entry["files"] != [p.relative_to(op.ROOT).as_posix() for p in paths]:
            raise op.Error("recovery_project_has_diverging_compose_files")
        identity = container["Image"]
        if identity not in images:
            try:
                digests = json.loads(op.sql.run(["docker", "image", "inspect", identity, "--format", "{{json .RepoDigests}}"],
                                               stage="recovery_image_metadata")) or []
            except op.Error:
                # Built images can have been removed while their containers still exist.
                # Preserve data backup; recovery must rebuild or refuse, never use latest.
                digests = []
            images[identity] = next((d for d in digests if IMAGE.fullmatch(d)), None)
        item = entry["services"].setdefault(service, {"replicas": 0, "image_digest": images[identity]})
        if item["image_digest"] != images[identity]:
            raise op.Error("recovery_replica_images_diverge")
        item["replicas"] += 1
        if project == "playsis-shared" and service == "sqlserver":
            sql_uid = int(op.sql.run(["docker", "exec", container["Id"], "id", "-u"], stage="recovery_sql_owner"))
            if not 0 <= sql_uid < 2 ** 31:
                raise op.Error("invalid_recovery_sql_process_owner")
        hook = paths[0].parent / "recovery-assets.sh"
        if hook.is_file():
            op.absolute(hook)
            entry["assets"] = {"path": hook.relative_to(op.ROOT).as_posix(), "sha256": op.digest(hook)}
    sql_image = projects.get("playsis-shared", {}).get("services", {}).get("sqlserver", {}).get("image_digest")
    ready = bool(REVISION.fullmatch(source["revision"].strip()) and sql_uid is not None and sql_image)
    return {"schema": 1, "source_machine": op.machine_id(), "source_revision": source["revision"].strip(),
            "tracked_changes_not_captured": source["tracked_diff"], "created_at": op.now(), "projects": projects,
            "sql_process_uid": sql_uid, "automatic_recovery_ready": ready,
            "data_consistency": "online_not_globally_atomic", "sources_and_images_rebuilt": True}


def recovery_points(s, document):
    snapshots = json.loads(s.op.restic(document, ["snapshots", "--json"]))
    def profile(item):
        tags = item.get("tags", [])
        if "yeshua" not in tags or "scope=" + s.control.policy()["scope"] not in tags:
            return None
        kinds = {t[5:] for t in tags if t.startswith("kind=")}
        return next(iter(kinds)) if len(kinds) == 1 else None
    sql = sorted((i for i in snapshots if profile(i) == "sql" and s.op.HASH.fullmatch(i.get("id", ""))), key=lambda i: i["time"])
    files = sorted((i for i in snapshots if profile(i) == "files" and "recovery=server-v1" in i.get("tags", [])
                    and s.op.HASH.fullmatch(i.get("id", ""))), key=lambda i: i["time"], reverse=True)
    result = []
    for item in files[:20]:
        preceding = [i for i in sql if datetime.fromisoformat(i["time"].replace("Z", "+00:00"))
                     <= datetime.fromisoformat(item["time"].replace("Z", "+00:00")) and i.get("hostname") == item.get("hostname")]
        if preceding:
            selected = preceding[-1]
            result.append({"files_snapshot": item["id"], "sql_snapshot": selected["id"],
                           "files_time": item["time"], "sql_time": selected["time"]})
    return result


def verified_download(s, value, kind, document):
    key = kind + "_download"
    if key in value:
        root = s.op.absolute(value[key])
        receipt = root / "download-receipt.json"
        if receipt.exists():
            data = s.control.private_json(receipt)
            if data.get("snapshot_id") != value[kind + "_snapshot"] or data.get("kind") != kind:
                raise s.op.Error("setup_download_receipt_mismatch")
            if kind == "files" and s.routine.seal_files_download(s.op, document, s.control.policy(), root) != {
                    k: data[k] for k in ("coverage_sha256", "source_machine", "download_machine", "file_selection", "roots")}:
                raise s.op.Error("setup_download_changed_after_verification")
            return root
        # Preserve interrupted downloads. Never mistake an incomplete directory for a receipt.
        value.setdefault("interrupted_downloads", []).append(str(root))
    target = s.BASE / (kind + "-" + uuid.uuid4().hex)
    value[key] = str(target)
    s.save(value)
    s.op.download(document, value[kind + "_snapshot"], target, s.control.policy())
    return target


def load_contract(s, value, document):
    files = verified_download(s, value, "files", document)
    sql = verified_download(s, value, "sql", document)
    metadata = s.routine.downloaded_path(s.op, files, Path(s.control.policy()["staging"]) / "metadata/current")
    path = metadata / "recovery-contract.json"
    if not path.is_file():
        raise s.op.Error("older_backup_requires_assisted_recovery_contract_missing_no_targets_changed")
    contract = s.op.read(path)
    _, coverage, _ = s.routine.file_recovery_inventory(s.op, document, s.control.policy(), files)
    catalog = s.op.read(sql / "root/YeshuaBackup/state/sql-catalog.json")
    seals = {"contract_sha256": s.op.digest(path), "catalog_sha256": s.op.digest(sql / "root/YeshuaBackup/state/sql-catalog.json")}
    if any(key in value and value[key] != observed for key, observed in seals.items()):
        raise s.op.Error("setup_recovery_metadata_changed_after_selection")
    if (contract.get("schema") != 1 or not REVISION.fullmatch(contract.get("source_revision", ""))
            or contract.get("source_machine") != coverage["source_machine"]
            or catalog.get("schema") != 1 or not catalog.get("sql_version")
            or catalog.get("source_machine") != coverage["source_machine"]
            or coverage["source_machine"] == s.op.machine_id()):
        raise s.op.Error("recovery_contract_sql_files_or_target_identity_mismatch")
    projects = contract.get("projects", {})
    sql_service = projects.get("playsis-shared", {}).get("services", {}).get("sqlserver", {})
    if not IMAGE.fullmatch(sql_service.get("image_digest") or ""):
        raise s.op.Error("recovery_requires_captured_sql_registry_digest_no_latest_fallback")
    if type(contract.get("sql_process_uid")) is not int or not 0 <= contract["sql_process_uid"] < 2 ** 31:
        raise s.op.Error("recovery_requires_captured_sql_process_owner")
    for project, entry in projects.items():
        if not s.op.PROJECT_NAME.fullmatch(project) or not entry.get("files") or not entry.get("services"):
            raise s.op.Error("invalid_recovery_project_contract")
        for path in entry["files"]:
            relative = Path(path)
            if relative.is_absolute() or ".." in relative.parts or relative.parts[0] != "infra":
                raise s.op.Error("recovery_source_path_outside_infra")
        for service, item in entry["services"].items():
            if (not SERVICE.fullmatch(service) or "migration" in service.casefold()
                    or type(item.get("replicas")) is not int or not 1 <= item["replicas"] <= 20
                    or item.get("image_digest") is not None and not IMAGE.fullmatch(item["image_digest"])):
                raise s.op.Error("invalid_or_migration_service_in_recovery_contract")
    value.update(seals)
    s.save(value)
    return contract, files, sql, catalog


def checkout_source(s, revision):
    root = s.op.APP_ROOT
    if s.op.sql.run(["git", "-C", str(root), "status", "--porcelain", "--untracked-files=normal"]):
        raise s.op.Error("recovery_requires_clean_source_checkout_no_reset_or_clean_allowed")
    s.op.sql.run(["git", "-C", str(root), "cat-file", "-e", revision + "^{commit}"])
    s.op.sql.run(["git", "-C", str(root), "checkout", "--detach", revision], timeout=120, stage="recovery_source_revision")
    s.op.ROOT = root


def build_models(s, value, contract):
    op = s.op
    document, _ = op.sql.load_credentials(op.APP_ROOT, s.PRIVATE)
    env = op.compose_environment(document, s.PRIVATE)
    env["YESHUA_COMMIT_SHA"] = contract["source_revision"]
    models = {}
    for project, entry in sorted(contract["projects"].items()):
        command = ["docker", "compose", "--project-name", project]
        for path in entry["files"]:
            command += ["-f", str(op.absolute(op.APP_ROOT / path))]
        # Compose config is already escaped for reuse as input, including literal dollars.
        model = json.loads(op.sql.run([*command, "config", "--format", "json"], env=env, stage="recovery_declared_compose"))
        if not set(entry["services"]).issubset(model.get("services", {})):
            raise op.Error("captured_services_missing_in_captured_source_revision")
        model["services"] = {name: model["services"][name] for name in entry["services"]}
        if entry.get("assets"):
            hook = entry["assets"]
            path = op.absolute(op.APP_ROOT / hook["path"])
            if not path.is_relative_to(op.APP_ROOT / "infra") or op.digest(path) != hook["sha256"]:
                raise op.Error("recovery_asset_hook_not_from_captured_revision")
            op.sql.run(["bash", str(path)], env=env, timeout=180, stage="recovery_recreatable_assets")
        for name, service in model["services"].items():
            captured = entry["services"][name]
            if service.get("build"):
                op.sql.run([*command, "build", name], env=env, timeout=7200, stage="recovery_build_from_captured_source")
                # Compose images only lists created containers, which do not exist yet.
                tag = service.get("image") or project + "-" + name
                identity = op.sql.run(["docker", "image", "inspect", tag, "--format", "{{.Id}}"], stage="recovery_built_image")
                if not re.fullmatch(r"sha256:[a-f0-9]{64}", identity):
                    raise op.Error("recovery_build_image_identity_invalid")
                service["image"] = identity
            else:
                image = captured.get("image_digest")
                if not image:
                    raise op.Error("external_image_digest_missing_no_latest_fallback")
                op.sql.run(["docker", "pull", image], timeout=1800, stage="recovery_pinned_image_pull")
                service["image"] = image
            for key in ("build", "depends_on", "profiles"):
                service.pop(key, None)
            service["pull_policy"] = "never"
            service["restart"] = "no"
            service.setdefault("deploy", {})["replicas"] = captured["replicas"]
            service.pop("scale", None)
        for network in model.get("networks", {}).values():
            if network.get("name") != "yeshua-net":
                raise op.Error("recovery_network_requires_review")
            network.clear()
            network.update(name="yeshua-net", external=True)
        models[project] = model
    stage = op.private_directory(s.BASE / "compose", create=True)
    op.write(stage / "compose.json", models)
    provenance = {"schema": 1, "machine_id": op.machine_id(), "source_revision": contract["source_revision"], "projects": {}}
    for project, model in models.items():
        path = stage / (project + ".json")
        op.write(path, model)
        provenance["projects"][project] = {"files": contract["projects"][project]["files"], "model_sha256": op.digest(path)}
    op.write(stage / "provenance.json", provenance)
    return stage


def ensure_only_recovery_host(s, *, sql_allowed=False):
    running = s.op.sql.run(["docker", "ps", "-a", "--format", "{{.Names}}"] ).splitlines()
    allowed = [[], [s.op.sql.SQL_CONTAINER]] if sql_allowed else [[]]
    if running not in allowed:
        raise s.op.Error("automatic_recovery_requires_empty_docker_host_no_existing_containers_will_be_removed")


def start_isolated_sql(s, stage, sql_uid):
    model = s.op.read(stage / "compose.json")["playsis-shared"]
    model["services"] = {"sqlserver": model["services"]["sqlserver"]}
    service = model["services"]["sqlserver"]
    service["ports"] = [{"target": 1433, "published": "1433", "host_ip": "127.0.0.1", "protocol": "tcp"}]
    service["restart"] = "no"
    data = s.op.absolute(s.control.policy()["sql_data"])
    if data.exists() and (not data.is_dir() or any(data.iterdir())):
        raise s.op.Error("recovery_sql_raw_data_directory_not_empty")
    data.mkdir(mode=0o750, parents=True, exist_ok=True)
    os.chown(data, sql_uid, 0)
    os.chmod(data, 0o750)
    s.op.write(stage / "sql-only.json", model)
    provenance = s.op.read(stage / "provenance.json")
    provenance["sql_only_sha256"] = s.op.digest(stage / "sql-only.json")
    s.op.write(stage / "provenance.json", provenance)
    if "yeshua-net" not in s.op.sql.run(["docker", "network", "ls", "--format", "{{.Name}}"] ).splitlines():
        s.op.sql.run(["docker", "network", "create", "--driver", "bridge", "yeshua-net"])
    s.op.sql.run(["docker", "compose", "--project-name", "playsis-shared", "-f", str(stage / "sql-only.json"),
                 "up", "-d", "--no-build", "--pull", "never", "--no-deps", "sqlserver"], timeout=180, stage="setup_recovery_sql_only")


def restore_access(s):
    path = s.op.APP_ROOT / "infra/private/sql_access.py"
    s.op.sql.run([sys_executable(), "-B", str(path), "--file", str(s.PRIVATE)], timeout=180, stage="recovery_sql_access")


def sys_executable():
    import sys
    return sys.executable


def release_services(s, stage):
    projects = s.op.read(stage / "compose.json")
    for project, model in sorted(projects.items()):
        names = [name for name in model["services"] if name != "sqlserver"]
        if names:
            s.op.compose(stage, project, ["create", "--no-build", "--pull", "never", "--no-recreate", *names])
    # Every required service exists stopped before the first worker may execute.
    for project, model in sorted(projects.items(), key=lambda item: item[0] != "playsis-shared"):
        names = [name for name in model["services"] if name not in {"sqlserver", "nginx"}]
        if names:
            s.op.compose(stage, project, ["start", *names])
    if "nginx" in projects.get("playsis-shared", {}).get("services", {}):
        s.op.compose(stage, "playsis-shared", ["start", "nginx"])
    s.op.sql.run(["curl", "--fail", "--silent", "--show-error", "--retry", "10", "--retry-delay", "3",
                 "--retry-connrefused", "--max-time", "20", "--output", "/dev/null", "http://127.0.0.1/spa/"],
                timeout=240, stage="recovery_application_http")
    verified_ids = []
    for project, model in projects.items():
        ids = s.op.compose(stage, project, ["ps", "-q"]).splitlines()
        expected = sum(service.get("deploy", {}).get("replicas", 1) for service in model["services"].values())
        deadline = time.monotonic() + 180
        while True:
            actual = json.loads(s.op.sql.run(["docker", "inspect", *ids])) if ids else []
            if len(actual) == expected and all(i["State"]["Running"] and i["State"].get("Health", {}).get("Status", "healthy") == "healthy" for i in actual):
                break
            if time.monotonic() >= deadline:
                raise s.op.Error("recovered_services_not_ready_no_success_receipt")
            time.sleep(3)
        verified_ids.extend(ids)
    if verified_ids:
        s.op.sql.run(["docker", "update", "--restart", "unless-stopped", *verified_ids], stage="recovery_enable_restart_after_validation")


def stop_recovered_services(s, stage):
    for project, model in s.op.read(stage / "compose.json").items():
        names = [name for name in model["services"] if name != "sqlserver"]
        if names:
            s.op.compose(stage, project, ["stop", "--timeout", "30", *names])


def run(s, value):
    op = s.op
    if value["phase"] == "completed":
        return {"status": "recovery_already_completed", "automatic_rerestore": False}
    document = s.operator_document(s.control.private_json(s.OPERATOR))
    contract, files, sql, catalog = load_contract(s, value, document)
    if value["phase"] == "prepared":
        ensure_only_recovery_host(s)
        if contract.get("tracked_changes_not_captured") and not value.get("committed_only_authorized"):
            raise op.Error("captured_uncommitted_changes_require_explicit_commit_only_acknowledgement")
        checkout_source(s, contract["source_revision"])
        s.routine.restore_files(op, document, s.control.policy(), files, op.machine_id(), apply=True)
        value["phase"] = "files_restored"
        s.save(value)
    if value["phase"] == "files_restored":
        ensure_only_recovery_host(s)
        stage = build_models(s, value, contract)
        value.update(compose_stage=str(stage), phase="models_built")
        s.save(value)
    stage = op.private_directory(Path(value["compose_stage"]))
    if value["phase"] == "models_built":
        ensure_only_recovery_host(s)
        start_isolated_sql(s, stage, contract["sql_process_uid"])
        value["phase"] = "sql_started"
        s.save(value)
    if value["phase"] == "sql_started":
        ensure_only_recovery_host(s, sql_allowed=True)
        restored, password = op.sql.load_credentials(op.APP_ROOT, s.PRIVATE)
        deadline = time.monotonic() + 120
        while True:
            try:
                observed, _ = op.sql.sql_inventory(password)
                break
            except op.Error:
                if time.monotonic() >= deadline:
                    raise op.Error("recovery_sql_not_ready") from None
                time.sleep(2)
        if observed["product_version"] != catalog["sql_version"]:
            raise op.Error("recovery_sql_version_does_not_match_backup")
        value["phase"] = "sql_restoring"
        s.save(value)
        result = s.routine.restore_sql_chain(op, password, s.control.policy(), sql, op.machine_id())
        value.update(sql_result=result, phase="sql_restored")
        s.save(value)
    if value["phase"] == "sql_restoring":
        raise op.Error("partial_sql_recovery_requires_review_no_overwrite_or_automatic_restart")
    if value["phase"] == "sql_restored":
        restore_access(s)
        # Keep the recovery repository access usable until the final restricted pairing.
        restored = s.control.private_json(s.PRIVATE)
        import copy
        backup = copy.deepcopy(document["Shared"]["Backup"])
        for field in ("IdentityFile", "KnownHostsFile"):
            if field in backup.get("Sftp", {}):
                incoming = op.absolute(backup["Sftp"][field])
                directory = op.private_directory(s.PRIVATE.parent / "shared/Backup/ssh", create=True)
                target = directory / ("id_ed25519" if field == "IdentityFile" else "known_hosts")
                s.load("enrollment").private_bytes(s, target, incoming.read_bytes())
                backup["Sftp"][field] = str(target)
        restored.setdefault("Shared", {})["Backup"] = backup
        op.write(s.PRIVATE, restored)
        value["phase"] = "ready_to_release"
        s.save(value)
    if value["phase"] == "ready_to_release":
        if not value.get("release_authorized"):
            raise op.Error("explicit_recovery_release_authorization_required")
        value["phase"] = "releasing"
        s.save(value)
        try:
            release_services(s, stage)
        except BaseException:
            try:
                stop_recovered_services(s, stage)
            finally:
                value["phase"] = "release_failed"
                s.save(value)
            raise
        value.update(phase="completed", completed_at=op.now(), functional_restore_proven=False,
                     integrations_require_reconciliation=True)
        s.save(value)
    if value["phase"] == "releasing":
        stop_recovered_services(s, stage)
        value["phase"] = "release_failed"
        s.save(value)
        raise op.Error("interrupted_service_release_requires_review_no_automatic_replay")
    if value["phase"] == "release_failed":
        raise op.Error("service_release_failed_requires_review_before_external_processing_is_repeated")
    return {"status": "recovered_and_started", "source_revision": contract["source_revision"],
            "functional_restore_proven": False, "integrations_require_reconciliation": True}
