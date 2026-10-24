"""Yeshua backup operator. Default is plan; mutations require explicit actions."""

import argparse
from contextlib import contextmanager
from datetime import datetime, timezone
import hashlib
import importlib.util
import json
import os
from pathlib import Path, PurePosixPath
import re
import shlex
import shutil
import signal
import stat
import subprocess
import sys
import tarfile
import uuid

sys.dont_write_bytecode = True
ROOT = Path(os.environ.get("YESHUA_APP_DIR", str(Path(__file__).resolve().parents[2])))
APP_ROOT = Path("/root/YeshuaCreator")
spec = importlib.util.spec_from_file_location("yeshua_backup_sql", Path(__file__).with_name("sql.py"))
sql = importlib.util.module_from_spec(spec)
spec.loader.exec_module(sql)
Error = sql.InventoryError
SET_ID = re.compile(r"[0-9]{8}T[0-9]{6}Z-[0-9a-f]{12}")
HASH = re.compile(r"[0-9a-f]{64}")
PROJECT_NAME = re.compile(r"playsis-[a-z0-9][a-z0-9-]*")
RECOVERY_COMPOSE = Path("/root/YeshuaRecovery/setup/compose")
BACKEND_ENV = {"AWS_ACCESS_KEY_ID", "AWS_SECRET_ACCESS_KEY", "AWS_SESSION_TOKEN", "AWS_DEFAULT_REGION",
               "AZURE_ACCOUNT_NAME", "AZURE_ACCOUNT_KEY", "B2_ACCOUNT_ID", "B2_ACCOUNT_KEY"}
VOLATILE_VOLUME_TARGETS = {
    "redis": {"/data"},
    "rabbitmq": {"/var/lib/rabbitmq"},
    "operational-intelligence-agent": {"/workspace", "/home/agent/.codex", "/home/agent/.claude"},
    "operational-intelligence": {"/workspace", "/home/agent/.codex", "/home/agent/.claude"},
}


def now():
    return datetime.now(timezone.utc).isoformat()


def read(path):
    return json.loads(Path(path).read_text(encoding="utf-8-sig"))


def write(path, document):
    path = Path(path)
    temporary = path.with_name(path.name + ".pending")
    descriptor = os.open(temporary, os.O_WRONLY | os.O_CREAT | os.O_EXCL | getattr(os, "O_NOFOLLOW", 0), 0o600)
    with os.fdopen(descriptor, "w", encoding="utf-8", newline="\n") as stream:
        json.dump(document, stream, ensure_ascii=True, indent=2)
        stream.write("\n")
        stream.flush()
        os.fsync(stream.fileno())
    os.replace(temporary, path)


def digest(path):
    with Path(path).open("rb") as stream:
        return hashlib.file_digest(stream, "sha256").hexdigest()


def absolute(path):
    path = Path(path)
    if not path.is_absolute() or ".." in path.parts or any(ord(c) < 32 for c in str(path)):
        raise Error("absolute_normalized_path_required")
    for parent in [path, *path.parents]:
        if parent.is_symlink():
            raise Error("symlink_in_operator_path")
    return path


def private_directory(path, *, create=False):
    path = absolute(path)
    if create:
        path.mkdir(mode=0o700, parents=True, exist_ok=True)
    info = path.stat()
    if not path.is_dir() or info.st_uid != os.geteuid() or info.st_mode & 0o077:
        raise Error("operator_directory_must_be_owned_and_0700")
    return path


def checked_policy(path):
    policy = read(path)
    if policy.get("schema") != 1 or not re.fullmatch(r"yeshua-[a-z0-9-]+", policy.get("scope", "")):
        raise Error("invalid_backup_policy")
    staging = absolute(policy["staging"])
    if not str(staging).startswith("/root/YeshuaBackup") or staging == ROOT or staging.is_relative_to(ROOT):
        raise Error("staging_must_be_dedicated_outside_repository")
    absolute(policy["sql_data"])
    if policy["sql_data"] != "/root/YeshuaDB/persistent/sql" or policy["sql_mode"] not in {"COPY_ONLY", "FULL"}:
        raise Error("unsupported_sql_storage_or_mode")
    for area in policy["areas"]:
        area_path = absolute(area["path"])
        if str(area_path) != "/root/YeshuaStorage/persistent" or area.get("required") is not True:
            raise Error("area_requires_explicit_coverage_review")
    for key in ("minimum_free_bytes", "minimum_available_memory_mb", "stop_timeout_seconds", "command_timeout_seconds",
                "keep_daily", "keep_weekly", "keep_monthly"):
        if type(policy[key]) is not int or policy[key] <= 0:
            raise Error("positive_policy_limit_required")
    if not policy["areas"] or len({a["id"] for a in policy["areas"]}) != len(policy["areas"]):
        raise Error("ambiguous_backup_areas")
    storage_excludes(policy)
    for area in policy["areas"]:
        if not re.fullmatch(r"[a-z][a-z0-9-]*", area["id"]):
            raise Error("invalid_area_id")
    if policy["container_files"] != []:
        raise Error("container_files_requires_coverage_review")
    return policy


def storage_excludes(policy):
    # Persistence is selected by root, never by exceptions to its contents.
    if policy.get("storage_excludes") != []:
        raise Error("persistent_storage_cannot_have_content_exclusions")
    return []


def machine_id():
    return Path("/etc/machine-id").read_text().strip()


def compose_source_files(container, *, revision=None):
    labels = container.get("Config", {}).get("Labels") or {}
    project = labels.get("com.docker.compose.project", "")
    files = [absolute(p) for p in labels.get("com.docker.compose.project.config_files", "").split(",") if p]
    if len(files) == 1 and files[0].parent == RECOVERY_COMPOSE:
        path = files[0]
        private_directory(RECOVERY_COMPOSE)
        provenance = read(RECOVERY_COMPOSE / "provenance.json")
        entry = provenance.get("projects", {}).get(project, {})
        expected = entry.get("model_sha256") if path.name == project + ".json" else None
        if path.name == "sql-only.json" and labels.get("com.docker.compose.service") == "sqlserver" and project == "playsis-shared":
            expected = provenance.get("sql_only_sha256")
        if (provenance.get("schema") != 1 or provenance.get("machine_id") != machine_id()
                or expected != digest(path) or revision is not None and provenance.get("source_revision") != revision.strip()):
            raise Error("recovered_compose_provenance_changed_review_before_backup")
        files = [absolute(ROOT / p) for p in entry.get("files", [])]
    if not files or not all(path.is_relative_to(ROOT / "infra") for path in files):
        raise Error("yeshua_compose_project_requires_repository_infra_ownership")
    return files


def managed_project(container):
    labels = container.get("Config", {}).get("Labels") or {}
    project = labels.get("com.docker.compose.project", "")
    if not PROJECT_NAME.fullmatch(project):
        return False
    compose_source_files(container)
    return True


def inspect_running():
    ids = sql.run(["docker", "ps", "-q"]).split()
    if not ids:
        raise Error("no_running_environment")
    raw = json.loads(sql.run(["docker", "inspect", *ids]))
    selected = [c for c in raw if managed_project(c)]
    if not selected or len([c for c in selected if c["Name"] == "/" + sql.SQL_CONTAINER]) != 1:
        raise Error("expected_sql_container_not_running")
    # A non-Yeshua writer sharing a persistent mount invalidates the pause contract.
    sources = {m["Source"] for c in selected for m in c.get("Mounts", [])}
    for c in raw:
        if c not in selected and any(m["Source"] in sources and m.get("RW") for m in c.get("Mounts", [])):
            raise Error("unknown_container_shares_persistent_writes")
    return selected


def mount_areas(containers, document, private_file, policy):
    areas = list(policy["areas"]) + [
        {"id": "private", "path": str(private_file.parent), "required": True},
        {"id": "memorias-vault", "path": str(sql.memorias_private_root(document, private_file)), "required": True}]
    covered = [absolute(a["path"]) for a in areas]
    if any(p in {Path("/"), Path("/root"), ROOT} or p.is_relative_to(Path(policy["staging"])) for p in covered):
        raise Error("unsafe_or_recursive_capture_root")
    if any(p.is_relative_to(Path(policy["sql_data"])) or Path(policy["sql_data"]).is_relative_to(p) for p in covered):
        raise Error("raw_sql_storage_must_never_be_an_area")
    volatile = [Path("/root/YeshuaStorage/volatile"), Path("/etc/letsencrypt"), Path("/root/YeshuaDB/persistent/telemetry")]
    if any(p.is_relative_to(v) or v.is_relative_to(p) for p in covered for v in volatile):
        raise Error("persistent_capture_root_overlaps_volatile_area")
    for c in containers:
        labels = c.get("Config", {}).get("Labels") or {}
        for mount in c.get("Mounts", []):
            source = absolute(mount["Source"])
            if mount["Type"] == "volume":
                if not re.fullmatch(r"[a-zA-Z0-9_.-]+", mount.get("Name", "")):
                    raise Error("invalid_docker_volume_name")
                if (labels.get("com.docker.compose.project") == "playsis-shared"
                        and mount.get("Destination") in VOLATILE_VOLUME_TARGETS.get(labels.get("com.docker.compose.service"), ())):
                    continue
                raise Error("unclassified_volume_use_storage_location_persistent_or_volatile")
            elif mount["Type"] != "bind":
                raise Error("unsupported_persistent_mount_type")
            elif source == Path(policy["sql_data"]) and c["Name"] == "/" + sql.SQL_CONTAINER:
                continue
            elif source == Path("/root/YeshuaStorage") or source.is_relative_to(Path("/root/YeshuaStorage/volatile")):
                # The shared mount exposes both categories; only persistent is captured.
                continue
            elif source == Path("/etc/letsencrypt"):
                continue
            elif source.is_relative_to(Path("/root/YeshuaDB/persistent/telemetry")):
                raise Error("legacy_telemetry_mount_requires_volatile_root_redeploy")
            elif source.is_relative_to(ROOT):
                if mount.get("RW"):
                    raise Error("writable_repository_mount_requires_review")
            elif not any(source.is_relative_to(root) for root in covered):
                raise Error("unclassified_bind_mount")
    # Nested roots are captured once, preserving their original location/permissions.
    unique = {}
    for area in areas:
        unique.setdefault(area["path"], area)
    return [a for a in unique.values() if not any(Path(a["path"]) != Path(b["path"])
            and Path(a["path"]).is_relative_to(Path(b["path"])) for b in unique.values())]


def public_summary(plan):
    return {"operation": "plan", "source_revision": plan["revision"], "database_count": len(plan["databases"]),
            "databases": [d["name"] for d in plan["databases"]], "container_count": len(plan["containers"]),
            "areas": [{"id": a["id"], "exists": Path(a["path"]).exists()} for a in plan["areas"]],
            "estimated_staging_bytes_without_images": plan["estimated_bytes"],
            "docker_images_excluded": True, "production_paused": False,
            "backup_executed": False, "restore_proven": False}


def make_plan(document, password, private_file, policy):
    revision = sql.run(["git", "-C", str(ROOT), "rev-parse", "HEAD"])
    if not HASH.fullmatch(revision) and not re.fullmatch(r"[0-9a-f]{40}", revision):
        raise Error("invalid_source_revision")
    containers = inspect_running()
    areas = mount_areas(containers, document, private_file, policy)
    metadata, client = sql.sql_inventory(password)
    expected = sql.expected_databases(ROOT)
    assessment = sql.assess(metadata, expected)
    if assessment["missing_databases"] or metadata.get("active_backup_restore"):
        raise Error("sql_inventory_blocks_capture")
    if any("agent" in service["servicename"].lower() and service["status_desc"] == "Running"
           for service in metadata.get("sql_services", [])):
        raise Error("sql_agent_running_requires_writer_isolation_review")
    databases = sql.user_databases(metadata)
    if any(d["state_desc"] != "ONLINE" or d.get("is_encrypted") or d.get("can_backup_database") != 1 for d in databases):
        raise Error("database_unavailable_encrypted_or_permission_missing")
    memory = {line.split(":")[0]: int(line.split()[1]) for line in Path("/proc/meminfo").read_text().splitlines()}
    if memory["MemAvailable"] // 1024 < policy["minimum_available_memory_mb"]:
        raise Error("insufficient_memory_for_capture")
    estimate = sum(int((d["data_allocated_mb"] + d["log_allocated_mb"]) * 1024 ** 2) for d in databases)
    for area in areas:
        measured = sql.path_inventory(area["path"])
        if not measured["exists"]:
            if area["required"]:
                raise Error("required_area_missing")
        elif measured.get("measurement_incomplete") or measured.get("symlink"):
            raise Error("area_size_or_type_cannot_be_verified")
        else:
            estimate += measured.get("allocated_bytes", 0)
    if shutil.disk_usage("/root").free < estimate + policy["minimum_free_bytes"]:
        raise Error("insufficient_staging_space")
    return {"revision": revision, "containers": containers, "areas": areas, "databases": databases,
            "sql": metadata, "client": client, "estimated_bytes": estimate}


@contextmanager
def locked(path):
    import fcntl
    if str(path) == "/var/lock/yeshua-deploy.lock":
        # Ubuntu uses /var/lock -> /run/lock. Resolve only this known system
        # alias so we lock the SAME inode as the existing deployment script.
        parent = Path("/var/lock").resolve(strict=True)
        if parent not in {Path("/var/lock"), Path("/run/lock")}:
            raise Error("unexpected_system_lock_directory")
        path = parent / "yeshua-deploy.lock"
    descriptor = os.open(absolute(path), os.O_CREAT | os.O_RDWR | getattr(os, "O_NOFOLLOW", 0), 0o600)
    try:
        info = os.fstat(descriptor)
        if not stat.S_ISREG(info.st_mode) or info.st_uid != os.geteuid():
            raise Error("lock_file_owner_or_type_mismatch")
        try:
            fcntl.flock(descriptor, fcntl.LOCK_EX | fcntl.LOCK_NB)
        except BlockingIOError:
            raise Error("another_backup_or_deploy_holds_lock") from None
        yield
    finally:
        os.close(descriptor)


def validate_archive(path):
    links = set()
    targets = []
    with tarfile.open(path) as archive:
        members = archive.getmembers()
        for member in members:
            name = PurePosixPath(member.name)
            if name.is_absolute() or ".." in name.parts or member.isdev() or member.isfifo():
                raise Error("unsafe_archive_member")
            if member.issym() or member.islnk():
                target = PurePosixPath(member.linkname)
                joined = (name.parent / target) if member.issym() else target
                depth = 0
                for part in joined.parts:
                    depth += -1 if part == ".." else 0 if part == "." else 1
                    if depth < 0:
                        raise Error("archive_link_escapes_root")
                if target.is_absolute():
                    raise Error("absolute_archive_link_not_supported")
                links.add(name)
                normalized = []
                for part in joined.parts:
                    if part == "..":
                        normalized.pop()
                    elif part != ".":
                        normalized.append(part)
                targets.extend((joined, PurePosixPath(*normalized)))
        # No chained link resolution: a lexical in-root target may traverse a
        # different link and escape after '..'. Ordinary Let's Encrypt links
        # go straight from live/ to regular archive/ files and remain supported.
        if any(any(parent in links for parent in [target, *target.parents]) for target in targets):
            raise Error("archive_chained_link_requires_review")
        for member in members:
            if any(parent in links for parent in PurePosixPath(member.name).parents):
                raise Error("archive_member_traverses_link")


def archive_directory(source, target):
    source = absolute(source)
    if not source.is_dir():
        raise Error("archive_source_must_be_directory")
    sql.run(["nice", "-n", "19", "ionice", "-c", "3", "tar", "--create", "--file", str(target),
             "--numeric-owner", "--acls", "--xattrs",
             "--directory", str(source), "."],
            timeout=3600, stage="archive_area")
    os.chmod(target, 0o600)
    validate_archive(target)


def snapshot_source(stage, revision):
    # Code and history are rebuilt from Git, not duplicated into data backups.
    # Do not record a credential-bearing remote URL or local source contents.
    source = {"revision": revision, "working_tree_captured": False, "root": str(ROOT),
              "rebuild_required": True,
              "tracked_diff": bool(sql.run(["git", "-C", str(ROOT), "status", "--porcelain", "--untracked-files=no"]))}
    write(stage / "source.json", source)
    return source


def compose_environment(document, private_file):
    reader_spec = importlib.util.spec_from_file_location("private_for_compose", ROOT / "infra/private/credentials.py")
    reader = importlib.util.module_from_spec(reader_spec)
    reader_spec.loader.exec_module(reader)
    env = {k: v for k, v in os.environ.items() if not k.startswith(("YESHUA_", "COMPOSE_"))}
    for line in (ROOT / "infra/docker/deploy.env").read_text().splitlines():
        if line and not line.startswith("#"):
            key, value = line.split("=", 1)
            env[key] = value
    env.update(reader.environment(document, private_file.parent, "all", True))
    return env


def frozen_projects(containers, document, private_file):
    """Use existing Compose models, not a second container launcher."""
    env = compose_environment(document, private_file)
    result = {}
    for project in sorted({c["Config"]["Labels"]["com.docker.compose.project"] for c in containers}):
        selected = [c for c in containers if c["Config"]["Labels"]["com.docker.compose.project"] == project]
        files = compose_source_files(selected[0])
        if any(not absolute(f).is_relative_to(ROOT) for f in files):
            raise Error("compose_model_outside_repository")
        args = ["docker", "compose", "--project-name", project]
        for path in files:
            args += ["-f", str(path)]
        model = json.loads(sql.run([*args, "config", "--format", "json"], env=env, stage="freeze_compose"))
        active_services = {c["Config"]["Labels"]["com.docker.compose.service"] for c in selected}
        model["services"] = {k: v for k, v in model["services"].items() if k in active_services}
        model["volumes"] = {}
        for service, config in model["services"].items():
            replicas = [c for c in selected if c["Config"]["Labels"]["com.docker.compose.service"] == service]
            if len({c["Image"] for c in replicas}) != 1:
                raise Error("replica_images_diverge")
            container = replicas[0]
            environment = lambda c: dict(value.split("=", 1) for value in c["Config"]["Env"] if "=" in value)
            mounts_key = lambda c: sorted(json.dumps(mount, sort_keys=True) for mount in c["Mounts"])
            if any(environment(c) != environment(container) or mounts_key(c) != mounts_key(container) for c in replicas):
                raise Error("replica_configuration_diverges_" + project + "_" + service)
            config.pop("build", None)
            config.pop("depends_on", None)
            config.pop("profiles", None)
            config["image"] = recovery_image_tag(container["Image"])
            config["pull_policy"] = "never"
            config["restart"] = "no"
            config.setdefault("deploy", {})["replicas"] = len(replicas)
            config["environment"] = dict(value.split("=", 1) for value in container["Config"]["Env"] if "=" in value)
            # Preserve RabbitMQ's actual hostname: its data is node-identity dependent.
            if service == "rabbitmq":
                config["hostname"] = container["Config"]["Hostname"]
            mounts = []
            for mount in container["Mounts"]:
                item = {"type": mount["Type"], "target": mount["Destination"], "read_only": not mount["RW"]}
                if mount["Type"] == "volume":
                    key = "recovered-" + hashlib.sha256(mount["Name"].encode()).hexdigest()[:12]
                    model["volumes"][key] = {"name": mount["Name"], "external": True}
                    item["source"] = key
                else:
                    item["source"] = mount["Source"]
                    item["bind"] = {"create_host_path": False}
                mounts.append(item)
            config["volumes"] = mounts
        for network in model.get("networks", {}).values():
            name = network.get("name")
            if name != "yeshua-net":
                raise Error("network_requires_explicit_recovery_review")
            network.clear()
            network.update(name=name, external=True)
        result[project] = model
    return result


def recovery_image_tag(image):
    if not re.fullmatch(r"sha256:[0-9a-f]{64}", image):
        raise Error("invalid_captured_image_identity")
    return "yeshua-recovery:sha256-" + image.split(":")[1]


def compose_literals(value):
    # A resolved configuration is parsed by Compose again during recovery.
    # Literal dollar signs in passwords and commands must not interpolate twice.
    if isinstance(value, str):
        return value.replace("$", "$$")
    if isinstance(value, list):
        return [compose_literals(item) for item in value]
    if isinstance(value, dict):
        return {key: compose_literals(item) for key, item in value.items()}
    return value


def stop_and_capture(plan, stage, password, policy):
    stopped = []
    resume_errors = []
    def interrupted(signum, frame):
        raise Error("capture_interrupted_resume_requested")
    previous = {s: signal.signal(s, interrupted) for s in (signal.SIGINT, signal.SIGTERM)}
    try:
        pause = [c for c in plan["containers"] if c["Name"] != "/" + sql.SQL_CONTAINER]
        # Close the external entrance first; stop every known writer before local capture.
        def stop_order(container):
            service = container["Config"]["Labels"]["com.docker.compose.service"]
            return 0 if service == "nginx" else 3 if service in {"rabbitmq", "redis"} else 2 if service in {"yeshua-observability", "yeshua-telemetry"} else 1
        pause.sort(key=stop_order)
        for container in pause:
            stopped.append(container["Id"])
            sql.run(["docker", "stop", "--time", str(policy["stop_timeout_seconds"]), container["Id"]],
                    timeout=policy["stop_timeout_seconds"] + 30, stage="stop_writer")
            state = json.loads(sql.run(["docker", "inspect", container["Id"]]))[0]["State"]
            if state["Running"] or state.get("OOMKilled") or state.get("ExitCode") == 137:
                raise Error("writer_did_not_stop_cleanly")
        sql.assert_no_external_sessions(password, plan["client"])
        sql_root = absolute(Path(policy["sql_data"]) / "backup" / stage.name)
        sql_root.mkdir(mode=0o700, exist_ok=False)
        uid = int(sql.run(["docker", "exec", sql.SQL_CONTAINER, "id", "-u"]))
        os.chown(sql_root, uid, -1)
        sql_entries = []
        for index, database in enumerate(plan["databases"]):
            filename = "db-" + str(index) + ".bak"
            path = sql_root / filename
            files = sql.database_files(password, plan["client"], database["name"])
            if not files or any(f["type_desc"] not in {"ROWS", "LOG"} for f in files):
                raise Error("unsupported_database_files_require_dba_backup")
            sql.backup_database(password, plan["client"], database["name"],
                                "/var/opt/mssql/backup/" + stage.name + "/" + filename,
                                copy_only=policy["sql_mode"] == "COPY_ONLY")
            # Move within the same filesystem when possible; no active SQL data file is copied.
            shutil.move(str(path), stage / filename)
            os.chmod(stage / filename, 0o600)
            sql_entries.append({"name": database["name"], "file": filename, "files": files,
                                "system": database["database_id"] <= 4, "checksum_verified": True})
        sql_root.rmdir()
        archives = []
        for area in plan["areas"]:
            if not Path(area["path"]).exists():
                continue
            filename = area["id"] + ".tar"
            archive_directory(area["path"], stage / filename)
            archives.append({**area, "file": filename, "excluded_paths": []})
        container_files = []
        for container in pause:
            for path in policy["container_files"]:
                # docker cp works on a stopped container; absent paths are explicitly recorded.
                destination = stage / ("container-" + container["Id"][:12])
                process = subprocess.run(["docker", "cp", container["Id"] + ":" + path, str(destination)],
                                         capture_output=True, timeout=120, check=False)
                if process.returncode:
                    # Only a known missing-path diagnostic is absence, not permission/daemon failure.
                    if b"Could not find the file" not in process.stderr and b"No such file or directory" not in process.stderr:
                        raise Error("container_files_capture_failed")
                    continue
                if destination.is_symlink() or not destination.is_dir():
                    raise Error("container_files_path_not_a_regular_directory")
                filename = destination.name + ".tar"
                archive_directory(destination, stage / filename)
                container_files.append({"container": container["Name"], "path": path, "file": filename})
                shutil.rmtree(destination)
        sql.assert_no_external_sessions(password, plan["client"])
        return sql_entries, archives, container_files
    finally:
        # Ignore another interrupt while recovering availability. SIGKILL/power loss still
        # requires the recorded resume command; never claim finally protects against it.
        for signum in previous:
            signal.signal(signum, signal.SIG_IGN)
        for container_id in reversed(stopped):
            try:
                sql.run(["docker", "start", container_id], timeout=90, stage="resume_writer")
            except Error:
                resume_errors.append(container_id[:12])
        for signum, handler in previous.items():
            signal.signal(signum, handler)
        write(stage / "resume.json", {"attempted_at": now(), "failed_container_ids": resume_errors})
        if resume_errors:
            raise Error("resume_incomplete_operator_action_required")


def capture(document, password, private_file, policy, *, allow_pause, isolated, include_images):
    if include_images:
        raise Error("recreatable_docker_image_archives_disabled")
    if not allow_pause or not isolated:
        raise Error("capture_requires_maintenance_window_and_external_writer_isolation")
    base = private_directory(policy["staging"], create=True)
    with locked(base / "backup.lock"):
        with locked("/var/lock/yeshua-deploy.lock"):
            plan = make_plan(document, password, private_file, policy)
            set_id = datetime.now(timezone.utc).strftime("%Y%m%dT%H%M%SZ-") + uuid.uuid4().hex[:12]
            stage = base / set_id
            stage.mkdir(mode=0o700)
            write(stage / "state.json", {"status": "preparing", "set_id": set_id, "created_at": now(),
                                         "source_machine": machine_id(), "running_container_ids": [c["Id"] for c in plan["containers"]]})
            projects = frozen_projects(plan["containers"], document, private_file)
            write(stage / "compose.json", projects)
            source = snapshot_source(stage, plan["revision"])
            images = sorted({c["Image"] for c in plan["containers"]})
            current = inspect_running()
            signature = lambda items: sorted((c["Id"], c["Image"], json.dumps(c["Mounts"], sort_keys=True)) for c in items)
            if signature(current) != signature(plan["containers"]):
                raise Error("environment_changed_during_preparation")
            started = now()
            write(stage / "state.json", {"status": "capturing", "set_id": set_id, "created_at": started,
                                         "source_machine": machine_id(), "running_container_ids": [c["Id"] for c in plan["containers"]]})
            databases, archives, container_files = stop_and_capture(plan, stage, password, policy)
            write(stage / "manifest.json", {"schema": 1, "set_id": set_id, "scope": policy["scope"],
                  "source_machine": machine_id(), "created_at": started, "completed_at": now(), "policy": policy,
                  "consistency": "coordinated_with_operator_asserted_external_writer_isolation",
                  "source": source, "databases": databases, "sql_version": plan["sql"]["product_version"],
                  "sql_mode": policy["sql_mode"], "point_in_time_recovery": False,
                  "archives": archives, "container_files": container_files, "images": images,
                  "images_archived": include_images, "restore_proven": False,
                  "system_database_restore_requires_dba": True})
            seal = {p.name: digest(p) for p in sorted(stage.iterdir()) if p.is_file() and p.name != "state.json"}
            write(stage / "seal.json", seal)
            write(stage / "state.json", {"status": "sealed", "set_id": set_id, "source_machine": machine_id(),
                                         "created_at": started, "completed_at": now()})
        # Network transfer is a separate action, outside the deploy lock and outage.
    return {"operation": "capture", "set_id": set_id, "status": "sealed", "uploaded": False, "restore_proven": False}


def validate_set(stage):
    stage = private_directory(stage)
    manifest = read(stage / "manifest.json")
    if manifest.get("schema") != 1 or not SET_ID.fullmatch(manifest.get("set_id", "")):
        raise Error("invalid_backup_manifest")
    seal = read(stage / "seal.json")
    required_metadata = {"manifest.json", "compose.json", "resume.json"}
    required_metadata |= {"source.json"} if manifest.get("source", {}).get("rebuild_required") else {"source.tar", "source.bundle"}
    if not required_metadata.issubset(seal):
        raise Error("incomplete_backup_seal")
    for name, expected in seal.items():
        if Path(name).name != name or not HASH.fullmatch(expected) or absolute(stage / name).is_dir() or digest(stage / name) != expected:
            raise Error("backup_checksum_mismatch")
    required = {d["file"] for d in manifest["databases"]} | {a["file"] for a in manifest["archives"]}
    required |= {a["file"] for a in manifest["container_files"]}
    if manifest["images_archived"]:
        required.add("images.tar")
    if not required.issubset(seal) or read(stage / "resume.json")["failed_container_ids"]:
        raise Error("backup_parts_or_production_resume_incomplete")
    return manifest


def restic_env(document, *, local_repository=None):
    config = document.get("Shared", {}).get("Backup", {})
    repository, password = config.get("Repository", ""), config.get("Password", "")
    # A path on the VPS is not an external backup. SSH trust/keys are prepared
    # separately; never disable host verification or put passwords in a URL.
    if local_repository is not None:
        repository = str(absolute(local_repository))
        if not Path(repository).is_relative_to(Path("/srv/yeshua-backups")) or not (Path(repository) / "config").is_file():
            raise Error("controller_requires_initialized_storage_repository")
    elif repository == "":
        # Explicit interim destination selected by the operator. Never infer
        # offsite protection merely because a repository exists locally.
        private_directory("/root/YeshuaBackup")
        repository = str(absolute("/root/YeshuaBackup/repository"))
        if Path(repository).exists():
            private_directory(repository)
    elif not isinstance(repository, str) or not repository.startswith(("s3:https://", "sftp:")):
        raise Error("configure_s3_https_sftp_or_leave_external_destination_pending")
    if not isinstance(password, str) or len(password) < 20:
        raise Error("configure_independent_backup_password_at_least_20_characters")
    environment = config.get("Environment", {})
    if not isinstance(environment, dict) or set(environment) - BACKEND_ENV:
        raise Error("unsupported_backend_environment_variable")
    if any(not isinstance(v, str) or any(ord(c) < 32 for c in v) for v in [repository, password, *environment.values()]):
        raise Error("invalid_backup_secret_format")
    env = {k: v for k, v in os.environ.items() if not k.startswith(("RESTIC_", "AWS_", "AZURE_", "B2_"))}
    return dict(env, RESTIC_REPOSITORY=repository, RESTIC_PASSWORD=password, **environment,
                RESTIC_CACHE_DIR="/root/.cache/yeshua-restic", GOMAXPROCS="1")


def sftp_options(document):
    config = document.get("Shared", {}).get("Backup", {})
    settings = config.get("Sftp")
    if settings is None:
        return []
    if (not config.get("Repository", "").startswith("sftp:") or not isinstance(settings, dict)
            or set(settings) != {"IdentityFile", "KnownHostsFile"}):
        raise Error("invalid_sftp_configuration")
    paths = []
    for name in ("IdentityFile", "KnownHostsFile"):
        path = absolute(settings[name])
        if not any(path.is_relative_to(root) for root in (Path("/root/YeshuaPrivate/production"), Path("/root/YeshuaRecovery/operator"))):
            raise Error("sftp_credentials_require_private_root")
        private_directory(path.parent)
        info = path.stat()
        if not stat.S_ISREG(info.st_mode) or info.st_uid != os.geteuid() or info.st_mode & 0o077:
            raise Error("sftp_credentials_must_be_owned_and_0600")
        paths.append(str(path))
    args = ["-F", "/dev/null", "-i", paths[0], "-o", "IdentitiesOnly=yes", "-o", "BatchMode=yes",
            "-o", "StrictHostKeyChecking=yes", "-o", "UserKnownHostsFile=" + paths[1],
            "-o", "ConnectTimeout=15", "-o", "ServerAliveInterval=30", "-o", "ServerAliveCountMax=3"]
    return ["-o", "sftp.args=" + shlex.join(args), "-o", "sftp.connections=2"]


def repository_id(document):
    return hashlib.sha256(restic_env(document)["RESTIC_REPOSITORY"].encode()).hexdigest()


def restic(document, args, *, timeout=14400, input=None, from_document=None, local_repository=None):
    if not shutil.which("restic"):
        raise Error("restic_not_installed_no_automatic_install")
    env = restic_env(document, local_repository=local_repository)
    if from_document is not None:
        origin = restic_env(from_document)
        env.update(RESTIC_FROM_REPOSITORY=origin["RESTIC_REPOSITORY"], RESTIC_FROM_PASSWORD=origin["RESTIC_PASSWORD"])
    options = [] if local_repository is not None else sftp_options(document)
    return sql.run(["nice", "-n", "19", "ionice", "-c", "3", "restic", "--no-cache",
                    "--limit-upload", "2048", "--limit-download", "4096", *options, *args],
                   env=env, timeout=timeout, input=input, stage="restic_operation")


def upload(document, stage, policy):
    with locked(Path(policy["staging"]) / "backup.lock"):
        manifest = validate_set(stage)
        if absolute(stage) != Path(policy["staging"]) / manifest["set_id"] or (stage / "recovery.json").exists():
            raise Error("upload_only_original_sealed_capture")
        if manifest["scope"] != policy["scope"]:
            raise Error("snapshot_scope_mismatch")
        output = restic(document, ["backup", "--json", "--host", policy["scope"], "--tag", "yeshua",
                                  "--tag", "scope=" + policy["scope"], "--tag", "kind=coordinated", "--tag", "set=" + manifest["set_id"], str(stage)])
        summaries = [item for line in output.splitlines() if line.strip()
                     for item in [json.loads(line)] if item.get("message_type") == "summary"]
        if len(summaries) != 1 or not HASH.fullmatch(summaries[0].get("snapshot_id", "")):
            raise Error("restic_success_without_valid_snapshot_receipt")
        receipt = {"set_id": manifest["set_id"], "snapshot_id": summaries[0]["snapshot_id"],
                   "scope": policy["scope"], "uploaded_at": now(), "restore_proven": False,
                   "offsite": bool(document.get("Shared", {}).get("Backup", {}).get("Repository"))}
        write(Path(policy["staging"]) / (manifest["set_id"] + ".upload.json"), receipt)
        return {"operation": "upload", **receipt}


def download(document, snapshot_id, target, policy):
    if not HASH.fullmatch(snapshot_id):
        raise Error("exact_64_character_snapshot_id_required_not_latest")
    target = absolute(target)
    if target.exists() or not str(target).startswith("/root/YeshuaRecovery/"):
        raise Error("recovery_download_requires_new_dedicated_target")
    snapshots = json.loads(restic(document, ["snapshots", "--json", snapshot_id]))
    if len(snapshots) != 1 or snapshots[0].get("id") != snapshot_id:
        raise Error("exact_recovery_snapshot_not_found")
    profiles = {tag.split("=", 1)[1] for tag in snapshots[0].get("tags", []) if tag.startswith("kind=")}
    if len(profiles) != 1 or not profiles.issubset({"sql", "files", "coordinated"}):
        raise Error("unknown_recovery_snapshot_profile")
    private_directory(target, create=True)
    restic(document, ["restore", snapshot_id, "--verify", "--target", str(target)])
    profile = next(iter(profiles))
    if profile != "coordinated":
        details = {}
        if profile == "files":
            import routine
            details = routine.seal_files_download(sys.modules[__name__], document, policy, target)
        write(target / "download-receipt.json", {"snapshot_id": snapshot_id, "kind": profile, "verified_at": now(), **details})
        return {"operation": "download", "snapshot_id": snapshot_id, "kind": profile, "directory": str(target),
                "files_verified": True, "restore_proven": False}
    manifests = list(target.rglob("manifest.json"))
    if len(manifests) != 1:
        raise Error("snapshot_must_contain_exactly_one_sealed_set")
    manifest = validate_set(manifests[0].parent)
    write(manifests[0].parent / "download.json", {"snapshot_id": snapshot_id, "downloaded_at": now()})
    return {"operation": "download", "set_id": manifest["set_id"], "directory": str(manifests[0].parent),
            "files_verified": True, "restore_proven": False}


def ensure_new_server(manifest, expected_machine):
    actual = machine_id()
    if actual == manifest["source_machine"] or actual != expected_machine:
        raise Error("recovery_refused_on_source_or_unconfirmed_machine")
    if sql.run(["docker", "ps", "-aq"]):
        raise Error("new_server_must_have_no_existing_containers")


def restore_area(archive, target):
    target = absolute(target)
    if target.exists() and (not target.is_dir() or any(target.iterdir())):
        raise Error("recovery_destination_not_empty")
    validate_archive(archive)
    target.mkdir(mode=0o700, parents=True, exist_ok=True)
    sql.run(["tar", "--extract", "--file", str(archive), "--numeric-owner", "--same-owner", "--acls", "--xattrs",
             "--directory", str(target)], timeout=3600, stage="restore_area")


def prepare_server(stage, expected_machine):
    manifest = validate_set(stage)
    if manifest.get("source", {}).get("rebuild_required"):
        raise Error("data_only_backup_rebuild_from_git_then_restore_native_sql_and_persistent_files_see_RECOVERY")
    ensure_new_server(manifest, expected_machine)
    policy = checked_policy_from_manifest(manifest)
    if not manifest["images_archived"]:
        # Registry copies by digest may be prepared by the operator instead of an
        # image archive. Never rebuild or pull latest as a recovery side effect.
        for image in manifest["images"]:
            sql.run(["docker", "image", "inspect", image], stage="required_image_missing")
    # Validate all destinations and archives before writing any production path.
    if ROOT == APP_ROOT or ROOT.is_relative_to(APP_ROOT):
        raise Error("run_recovery_toolkit_outside_application_destination")
    targets = [Path(a["path"]) for a in manifest["archives"] if "volume" not in a] + [APP_ROOT, Path(policy["sql_data"])]
    for target in targets:
        target = absolute(target)
        if target.exists() and (not target.is_dir() or any(target.iterdir())):
            raise Error("recovery_destination_not_empty")
    existing_volumes = set(sql.run(["docker", "volume", "ls", "--format", "{{.Name}}"] ).splitlines())
    if any(a.get("volume") in existing_volumes for a in manifest["archives"] if "volume" in a):
        raise Error("recovery_volume_already_exists")
    expanded_bytes = sum((stage / item["file"]).stat().st_size for item in manifest["archives"])
    expanded_bytes += sum(f.get("size_bytes", 0) for d in manifest["databases"] for f in d["files"])
    if manifest["images_archived"]:
        expanded_bytes += (stage / "images.tar").stat().st_size
    if shutil.disk_usage("/root").free < expanded_bytes + policy["minimum_free_bytes"]:
        raise Error("new_server_needs_more_space_for_expanded_data_and_images")
    for item in [*manifest["archives"], *manifest["container_files"]]:
        validate_archive(stage / item["file"])
    validate_archive(stage / "source.tar")
    if manifest["images_archived"]:
        sql.run(["nice", "-n", "19", "docker", "image", "load", "--input", str(stage / "images.tar")],
                timeout=14400, stage="restore_images")
    for image in manifest["images"]:
        sql.run(["docker", "image", "inspect", image], stage="verify_image_identity")
        sql.run(["docker", "image", "tag", image, recovery_image_tag(image)])
    restore_source(stage, manifest)
    for area in manifest["archives"]:
        target = Path(area["path"])
        if "volume" in area:
            existing = sql.run(["docker", "volume", "ls", "--format", "{{.Name}}"] ).splitlines()
            if area["volume"] in existing:
                raise Error("recovery_volume_already_exists")
            sql.run(["docker", "volume", "create", area["volume"]])
            target = Path(sql.run(["docker", "volume", "inspect", "--format", "{{.Mountpoint}}", area["volume"]]))
        restore_area(stage / area["file"], target)
    sql_data = absolute(policy["sql_data"])
    sql_data.mkdir(mode=0o750, parents=True, exist_ok=True)
    os.chown(sql_data, 10001, 0)
    incoming = sql_data / "backup" / manifest["set_id"]
    incoming.mkdir(mode=0o750, parents=True)
    os.chown(incoming.parent, 10001, 0)
    os.chown(incoming, 10001, 0)
    for database in manifest["databases"]:
        target = incoming / database["file"]
        shutil.copyfile(stage / database["file"], target)
        os.chmod(target, 0o640)
        os.chown(target, 10001, 0)
    projects = read(stage / "compose.json")
    for project, model in projects.items():
        write(stage / (project + ".json"), compose_literals(model))
    write(stage / "recovery.json", {"status": "files_prepared", "target_machine": machine_id(),
                                    "prepared_at": now(), "set_id": manifest["set_id"], "activated": False})
    return {"operation": "prepare-server", "set_id": manifest["set_id"], "status": "files_prepared",
            "containers_started": False, "restore_proven": False}


def restore_source(stage, manifest):
    if manifest["source"].get("root") != str(APP_ROOT):
        raise Error("source_root_requires_explicit_recovery_review")
    validate_archive(stage / "source.tar")
    if APP_ROOT.exists() and any(APP_ROOT.iterdir()):
        raise Error("source_recovery_destination_not_empty")
    sql.run(["git", "clone", "--no-checkout", str(stage / "source.bundle"), str(APP_ROOT)], timeout=3600, stage="restore_source_history")
    revision = manifest["source"]["revision"]
    if not re.fullmatch(r"[0-9a-f]{40}", revision):
        raise Error("invalid_recovered_revision")
    sql.run(["git", "-C", str(APP_ROOT), "symbolic-ref", "HEAD", "refs/heads/recovered-" + manifest["set_id"]])
    sql.run(["git", "-C", str(APP_ROOT), "update-ref", "HEAD", revision])
    sql.run(["git", "-C", str(APP_ROOT), "read-tree", revision])
    sql.run(["tar", "--extract", "--file", str(stage / "source.tar"), "--same-owner", "--directory", str(APP_ROOT)], timeout=3600)
    # Keep origin as the local bundle until the operator reviews the captured
    # upstream. Recovery never fetches newer code or runs the deployment script.


def checked_policy_from_manifest(manifest):
    policy = manifest["policy"]
    # Reuse the same path allowlist, even when the restore kit came from elsewhere.
    if policy["sql_data"] != "/root/YeshuaDB/persistent/sql":
        raise Error("unexpected_recovery_sql_root")
    for area in manifest["archives"]:
        path = absolute(area["path"])
        if "volume" in area:
            if not re.fullmatch(r"[a-zA-Z0-9_.-]+", area["volume"]):
                raise Error("invalid_recovery_volume")
        elif str(path) not in {"/root/YeshuaStorage", "/root/YeshuaStorage/persistent", "/root/YeshuaDB/persistent/telemetry", "/etc/letsencrypt",
                               "/root/YeshuaPrivate/production", "/root/YeshuaMemoriasSecrets"}:
            raise Error("recovery_area_requires_explicit_path_review")
    return policy


def restore_sql(stage, password, expected_machine):
    manifest = validate_set(stage)
    receipt = read(stage / "recovery.json")
    if machine_id() == manifest["source_machine"] or machine_id() != expected_machine or receipt["target_machine"] != expected_machine:
        raise Error("sql_restore_only_on_prepared_new_server")
    containers = json.loads(sql.run(["docker", "inspect", sql.SQL_CONTAINER]))
    if len(containers) != 1 or containers[0]["Image"] not in manifest["images"]:
        raise Error("sql_recovery_image_mismatch")
    running = sql.run(["docker", "ps", "--format", "{{.Names}}"] ).splitlines()
    if running != [sql.SQL_CONTAINER]:
        raise Error("only_sql_may_run_during_database_restore")
    metadata, client = sql.sql_inventory(password)
    if metadata["product_version"] != manifest["sql_version"]:
        raise Error("sql_version_must_match_capture")
    if any(d["database_id"] > 4 for d in metadata["databases"]):
        raise Error("destination_user_databases_already_exist")
    sql.assert_no_external_sessions(password, client)
    for database in manifest["databases"]:
        if not database["system"]:
            sql.restore_database(password, client, database["name"],
                "/var/opt/mssql/backup/" + manifest["set_id"] + "/" + database["file"], database["files"])
    receipt.update(status="user_databases_restored_checkdb_passed", sql_restored_at=now(),
                   system_databases_pending_dba=True, integrations_reconciliation_pending=True)
    write(stage / "recovery.json", receipt)
    return {"operation": "restore-sql", "set_id": manifest["set_id"], "status": receipt["status"], "activated": False,
            "system_databases_pending_dba": True, "restore_proven": False}


def recovery_context(stage, expected_machine):
    manifest = validate_set(stage)
    receipt = read(stage / "recovery.json")
    if machine_id() == manifest["source_machine"] or machine_id() != expected_machine or receipt["target_machine"] != expected_machine:
        raise Error("recovery_action_only_on_prepared_new_server")
    return manifest, receipt


def compose(stage, project, args):
    if not PROJECT_NAME.fullmatch(project) or project not in read(stage / "compose.json"):
        raise Error("unexpected_recovery_project")
    return sql.run(["docker", "compose", "--project-name", project, "-f", str(stage / (project + ".json")), *args],
                   timeout=3600, stage="recovery_compose")


def start_sql(stage, expected_machine):
    manifest, receipt = recovery_context(stage, expected_machine)
    if receipt["status"] != "files_prepared" or sql.run(["docker", "ps", "-aq"]):
        raise Error("sql_start_requires_prepared_empty_docker_host")
    model = read(stage / "playsis-shared.json")
    model["services"] = {"sqlserver": model["services"]["sqlserver"]}
    model["services"]["sqlserver"]["ports"] = [{"target": 1433, "published": "1433", "host_ip": "127.0.0.1", "protocol": "tcp"}]
    write(stage / "sql-only.json", model)
    networks = sql.run(["docker", "network", "ls", "--format", "{{.Name}}"] ).splitlines()
    if "yeshua-net" in networks:
        raise Error("recovery_network_already_exists_review_before_start")
    sql.run(["docker", "network", "create", "--driver", "bridge", "yeshua-net"])
    sql.run(["docker", "compose", "--project-name", "playsis-shared", "-f", str(stage / "sql-only.json"),
             "up", "-d", "--no-build", "--pull", "never", "--no-deps", "sqlserver"], timeout=180, stage="recovery_sql_start")
    receipt.update(status="sql_started_wait_for_readiness", sql_started_at=now())
    write(stage / "recovery.json", receipt)
    return {"operation": "start-sql", "status": receipt["status"], "public_sql_port": False, "workers_started": False}


def create_services(stage, expected_machine):
    manifest, receipt = recovery_context(stage, expected_machine)
    if receipt["status"] != "user_databases_restored_checkdb_passed":
        raise Error("services_require_successful_sql_restore")
    projects = read(stage / "compose.json")
    for project in sorted(projects):
        services = sorted(s for s in projects[project]["services"] if s != "sqlserver")
        if services:
            compose(stage, project, ["create", "--no-build", "--pull", "never", "--no-recreate", *services])
    for item in manifest["container_files"]:
        raw = json.loads(sql.run(["docker", "inspect", item["container"]]))[0]
        if raw["State"]["Running"] or raw["Image"] not in manifest["images"]:
            raise Error("container_files_target_must_be_stopped_recovered_image")
        if item["path"] != "/app/uploads":
            raise Error("unsupported_container_files_destination")
        temporary = stage / ("restore-" + raw["Id"][:12]) / "uploads"
        restore_area(stage / item["file"], temporary)
        sql.run(["docker", "cp", "--archive", str(temporary), raw["Id"] + ":/app"], timeout=3600, stage="restore_container_files")
        shutil.rmtree(temporary.parent)
    receipt.update(status="services_created_stopped", created_at=now())
    write(stage / "recovery.json", receipt)
    return {"operation": "create-services", "status": receipt["status"], "workers_started": False, "restore_proven": False}


def retention(document, policy, *, apply, accepted_snapshot, kind="coordinated"):
    if kind not in {"sql", "files", "coordinated"}:
        raise Error("retention_requires_fixed_snapshot_kind")
    if apply:
        if not HASH.fullmatch(accepted_snapshot or ""):
            raise Error("retention_apply_requires_accepted_recovery_snapshot")
        receipt_path = Path(policy["staging"]) / "accepted-recovery.json"
        receipt = read(receipt_path)
        if receipt.get("snapshot_id") != accepted_snapshot or receipt.get("functional_recovery_accepted") is not True:
            raise Error("retention_requires_recorded_functional_recovery_acceptance")
    args = ["forget", "--json", "--host", policy["scope"], "--tag", "yeshua,scope=" + policy["scope"] + ",kind=" + kind,
            "--group-by", "host", "--keep-daily", str(policy["keep_daily"]),
            "--keep-weekly", str(policy["keep_weekly"]), "--keep-monthly", str(policy["keep_monthly"])]
    preview = json.loads(restic(document, [*args, "--dry-run"]))
    removed = {s["id"] for group in preview for s in group.get("remove", [])}
    if any(not HASH.fullmatch(value) for value in removed):
        raise Error("invalid_snapshot_identity_in_retention_preview")
    if apply:
        if accepted_snapshot in removed:
            raise Error("retention_would_remove_accepted_recovery_snapshot")
        kept = {s["id"] for group in preview for s in group.get("keep", [])}
        if accepted_snapshot not in kept:
            raise Error("accepted_snapshot_missing_from_this_repository_scope")
        if removed:
            # Apply the exact reviewed IDs, not a second moving policy selection.
            # A concurrent new backup cannot cause the accepted snapshot to age out.
            restic(document, ["forget", "--json", *sorted(removed)])
    return {"operation": "retention", "applied": apply, "snapshot_count": len(removed), "prune_executed": False}


def cleanup_staging(document, stage, policy, *, apply):
    base = private_directory(policy["staging"])
    stage = absolute(stage)
    if stage.parent != base or not SET_ID.fullmatch(stage.name):
        raise Error("cleanup_only_exact_set_under_dedicated_staging")
    with locked(base / "backup.lock"):
        manifest = validate_set(stage)
        if manifest["set_id"] != stage.name:
            raise Error("cleanup_set_identity_mismatch")
        receipt = read(base / (stage.name + ".upload.json"))
        if receipt["set_id"] != manifest["set_id"] or receipt["scope"] != policy["scope"] or not HASH.fullmatch(receipt["snapshot_id"]):
            raise Error("cleanup_requires_matching_successful_upload_receipt")
        if apply:
            accepted = read(base / "accepted-recovery.json")
            if accepted.get("functional_recovery_accepted") is not True or accepted.get("snapshot_id") != receipt["snapshot_id"]:
                raise Error("cleanup_requires_this_snapshot_recovered_and_accepted")
            if receipt.get("offsite") is not True or not document.get("Shared", {}).get("Backup", {}).get("Repository"):
                raise Error("cleanup_requires_verified_external_copy_not_only_local_repository")
            remote = restic(document, ["dump", receipt["snapshot_id"], str(stage / "manifest.json")])
            if json.loads(remote) != manifest:
                raise Error("remote_manifest_does_not_match_local_set")
            shutil.rmtree(stage)
        return {"operation": "cleanup-staging", "set_id": manifest["set_id"], "applied": apply,
                "business_files_removed": False, "external_snapshot_removed": False}


def resume_source(stage, policy):
    stage = private_directory(stage)
    state = read(stage / "state.json")
    if stage.parent != Path(policy["staging"]) or not SET_ID.fullmatch(stage.name) or state["source_machine"] != machine_id():
        raise Error("resume_only_original_capture_on_source_machine")
    ids = state.get("running_container_ids")
    if not ids or any(not HASH.fullmatch(value) for value in ids):
        raise Error("capture_has_no_pending_resume_list")
    with locked(Path(policy["staging"]) / "backup.lock"), locked("/var/lock/yeshua-deploy.lock"):
        containers = json.loads(sql.run(["docker", "inspect", *ids]))
        if any(not managed_project(c) for c in containers):
            raise Error("resume_container_identity_mismatch")
        # Dependencies first, ingress last. Do not restart an already running process.
        containers.sort(key=lambda c: 0 if c["Name"] in {"/yeshua-sqlserver", "/yeshua-rabbitmq", "/yeshua-redis"}
                        else 2 if c["Name"] == "/yeshua-nginx" else 1)
        for container in containers:
            if not container["State"]["Running"]:
                sql.run(["docker", "start", container["Id"]], timeout=90, stage="manual_resume_source")
    return {"operation": "resume-source", "status": "original_running_set_started", "backup_complete": False}


def main(argv=None):
    parser = argparse.ArgumentParser(description=__doc__)
    parser.add_argument("action", nargs="?", default="plan", choices=("plan", "capture", "init-repository", "upload", "check",
                        "download", "prepare-server", "start-sql", "restore-sql", "create-services", "resume-source", "retention", "cleanup-staging",
                        "configure-local", "configure-repository", "move-to-sftp", "recovery-key", "scheduled", "status", "sql-restore-plan", "restore-sql-chain", "restore-files"))
    parser.add_argument("--file", type=Path, default=Path(os.environ.get("YESHUA_DEPLOY_SECRETS_FILE", "/root/YeshuaPrivate/production/credentials.json")))
    parser.add_argument("--policy", type=Path, default=Path(__file__).with_name("policy.json"))
    parser.add_argument("--set", type=Path)
    parser.add_argument("--allow-pause", action="store_true")
    parser.add_argument("--external-writers-isolated", action="store_true")
    parser.add_argument("--include-images", action="store_true", help="Disabled for new data-only captures; retained only to report an explicit refusal.")
    parser.add_argument("--snapshot")
    parser.add_argument("--target", type=Path)
    parser.add_argument("--new-server-machine-id")
    parser.add_argument("--read-all-data", action="store_true")
    parser.add_argument("--apply", action="store_true")
    parser.add_argument("--kind", choices=("full", "differential", "logs", "files", "check", "check-data", "sql", "coordinated"))
    parser.add_argument("--download-root", type=Path)
    parser.add_argument("--repository", help="Explicit SFTP destination for move-to-sftp only.")
    parser.add_argument("--sftp-identity-file", type=Path)
    parser.add_argument("--sftp-known-hosts-file", type=Path)
    parser.add_argument("--initialize-target", action="store_true", help="Explicitly initialize a new empty SFTP repository before copying.")
    parser.add_argument("--show-recovery-key", action="store_true", help="Show the existing recovery password again, only in a private controlling terminal.")
    args = parser.parse_args(argv)
    try:
        if os.name != "posix" or os.geteuid() != 0:
            raise Error("run_on_linux_as_root_operator")
        if args.show_recovery_key and args.action != "recovery-key":
            raise Error("recovery_key_display_requires_explicit_action")
        os.umask(0o077)
        policy = checked_policy(args.policy)
        require_sql = args.action in {"plan", "capture", "restore-sql", "restore-sql-chain"} or args.action == "scheduled" and args.kind in {"full", "differential", "logs"}
        document, password = sql.load_credentials(ROOT, absolute(args.file), require_sql=require_sql)
        stage = absolute(args.set) if args.set else None
        if args.action in {"upload", "prepare-server", "start-sql", "restore-sql", "create-services", "resume-source", "cleanup-staging"} and stage is None:
            raise Error("set_directory_required")
        if args.action in {"configure-local", "configure-repository", "move-to-sftp", "recovery-key", "scheduled", "status", "sql-restore-plan", "restore-sql-chain", "restore-files"}:
            import routine
            op = sys.modules[__name__]
            if args.action == "configure-local":
                result = routine.configure_local(op, args.file, policy)
            elif args.action == "configure-repository":
                result = routine.configure_repository(op, args.file, policy)
            elif args.action == "move-to-sftp":
                import destination
                result = destination.move_to_sftp(op, routine, args.file, policy, args.repository,
                    args.sftp_identity_file, args.sftp_known_hosts_file, apply=args.apply, initialize=args.initialize_target)
            elif args.action == "recovery-key":
                result = routine.recovery_key(op, args.file, policy, show=args.show_recovery_key)
            elif args.action == "scheduled":
                result = routine.scheduled(op, document, password, args.file, policy, args.kind)
            elif args.action == "status":
                result = routine.status(op, policy)
            elif args.action == "sql-restore-plan":
                result = routine.restore_plan(op, policy)
            else:
                if not args.download_root:
                    raise Error("verified_download_root_required")
                if args.action == "restore-files":
                    result = routine.restore_files(op, document, policy, args.download_root, args.new_server_machine_id, apply=args.apply)
                else:
                    result = routine.restore_sql_chain(op, password, policy, args.download_root, args.new_server_machine_id)
        elif args.action == "plan":
            result = public_summary(make_plan(document, password, args.file, policy))
        elif args.action == "capture":
            result = capture(document, password, args.file, policy, allow_pause=args.allow_pause,
                             isolated=args.external_writers_isolated, include_images=args.include_images)
        elif args.action == "init-repository":
            restic(document, ["init"])
            result = {"operation": args.action, "status": "initialized"}
        elif args.action == "upload":
            result = upload(document, stage, policy)
        elif args.action == "check":
            restic(document, ["check", *(["--read-data"] if args.read_all_data else [])])
            result = {"operation": "check", "data_read": args.read_all_data, "restore_proven": False}
        elif args.action == "download":
            if not args.target or not args.snapshot:
                raise Error("snapshot_and_new_target_required")
            result = download(document, args.snapshot, args.target, policy)
        elif args.action == "prepare-server":
            result = prepare_server(stage, args.new_server_machine_id)
        elif args.action == "start-sql":
            result = start_sql(stage, args.new_server_machine_id)
        elif args.action == "restore-sql":
            result = restore_sql(stage, password, args.new_server_machine_id)
        elif args.action == "create-services":
            result = create_services(stage, args.new_server_machine_id)
        elif args.action == "resume-source":
            result = resume_source(stage, policy)
        elif args.action == "cleanup-staging":
            result = cleanup_staging(document, stage, policy, apply=args.apply)
        else:
            result = retention(document, policy, apply=args.apply, accepted_snapshot=args.snapshot, kind=args.kind or "coordinated")
    except Exception as error:
        print(json.dumps({"operation": args.action, "status": "failed",
                          "error": str(error) if isinstance(error, Error) else "operator_failed_details_omitted"}))
        return 1
    print(json.dumps(result, indent=2))
    return 0


if __name__ == "__main__":
    raise SystemExit(main())
