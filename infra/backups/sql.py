"""SQL inventory and native backup primitives; CLI remains read-only."""

import argparse
from datetime import datetime, timezone
import importlib.util
import json
import os
from pathlib import Path
import re
import shutil
import subprocess
import sys


ROOT = Path(__file__).resolve().parents[2]
SQL_CONTAINER = "yeshua-sqlserver"
SQLCMD_PATHS = ("/opt/mssql-tools18/bin/sqlcmd", "/opt/mssql-tools/bin/sqlcmd")
JSON_MARKER = "YESHUA_SQL_INVENTORY="
SYSTEM_DATABASES = frozenset({"master", "model", "msdb", "tempdb"})
QUERY = """
SET NOCOUNT ON;
SET LOCK_TIMEOUT 5000;
DECLARE @inventory nvarchar(max) = (
SELECT
    CONVERT(varchar(40), SERVERPROPERTY('ProductVersion')) AS product_version,
    CONVERT(varchar(128), SERVERPROPERTY('Edition')) AS edition,
    CONVERT(varchar(40), SYSUTCDATETIME(), 126) AS captured_at_utc,
    IS_SRVROLEMEMBER('sysadmin') AS current_login_is_sysadmin,
    HAS_PERMS_BY_NAME(NULL, NULL, 'CREATE ANY DATABASE') AS can_create_database,
    JSON_QUERY((
        SELECT d.name, d.database_id, d.state_desc, d.recovery_model_desc,
            d.log_reuse_wait_desc, d.is_encrypted, d.is_read_only,
            CAST(ISNULL(f.data_pages, 0) * 8.0 / 1024 AS decimal(18,2)) AS data_allocated_mb,
            CAST(ISNULL(f.log_pages, 0) * 8.0 / 1024 AS decimal(18,2)) AS log_allocated_mb,
            CONVERT(varchar(40), b.last_full, 126) AS last_full,
            CONVERT(varchar(40), b.last_copy_only_full, 126) AS last_copy_only_full,
            CONVERT(varchar(40), b.last_log, 126) AS last_log,
            HAS_PERMS_BY_NAME(d.name, 'DATABASE', 'BACKUP DATABASE') AS can_backup_database
        FROM sys.databases AS d
        LEFT JOIN (
            SELECT database_id,
                SUM(CASE WHEN type = 0 THEN CONVERT(bigint, size) ELSE 0 END) AS data_pages,
                SUM(CASE WHEN type = 1 THEN CONVERT(bigint, size) ELSE 0 END) AS log_pages
            FROM sys.master_files GROUP BY database_id
        ) AS f ON f.database_id = d.database_id
        LEFT JOIN (
            SELECT database_name,
                MAX(CASE WHEN type = 'D' AND is_copy_only = 0 THEN backup_finish_date END) AS last_full,
                MAX(CASE WHEN type = 'D' AND is_copy_only = 1 THEN backup_finish_date END) AS last_copy_only_full,
                MAX(CASE WHEN type = 'L' THEN backup_finish_date END) AS last_log
            FROM msdb.dbo.backupset GROUP BY database_name
        ) AS b ON b.database_name = d.name
        ORDER BY d.database_id FOR JSON PATH, INCLUDE_NULL_VALUES
    )) AS databases,
    JSON_QUERY((
        SELECT session_id, command, DB_NAME(database_id) AS database_name,
            percent_complete, estimated_completion_time
        FROM sys.dm_exec_requests
        WHERE command LIKE 'BACKUP%' OR command LIKE 'RESTORE%'
        FOR JSON PATH
    )) AS active_backup_restore,
    (SELECT COUNT(*) FROM msdb.dbo.sysjobs WHERE enabled = 1) AS enabled_sql_agent_jobs,
    JSON_QUERY((
        SELECT j.name, j.enabled,
            (SELECT COUNT(*) FROM msdb.dbo.sysjobsteps AS s WHERE s.job_id = j.job_id) AS step_count,
            (SELECT COUNT(*) FROM msdb.dbo.sysjobschedules AS s WHERE s.job_id = j.job_id) AS schedule_count,
            CAST(CASE WHEN EXISTS (
                SELECT 1 FROM msdb.dbo.sysjobsteps AS s
                WHERE s.job_id = j.job_id AND (s.command LIKE '%BACKUP%DATABASE%' OR s.command LIKE '%BACKUP%LOG%')
            ) THEN 1 ELSE 0 END AS bit) AS contains_direct_backup_command
        FROM msdb.dbo.sysjobs AS j ORDER BY j.name FOR JSON PATH
    )) AS sql_agent_jobs,
    JSON_QUERY((
        SELECT servicename, status_desc, startup_type_desc
        FROM sys.dm_server_services FOR JSON PATH
    )) AS sql_services
FOR JSON PATH, WITHOUT_ARRAY_WRAPPER);
SELECT N'YESHUA_SQL_INVENTORY=' + @inventory;
"""


class InventoryError(Exception):
    pass


def run(args, *, timeout=35, env=None, input=None, stage="command"):
    try:
        process = subprocess.run(args, capture_output=True, text=True, timeout=timeout,
                                 env=env, input=input, check=False)
    except (OSError, subprocess.TimeoutExpired):
        raise InventoryError("command_unavailable_or_timed_out") from None
    if process.returncode:
        output = process.stdout + process.stderr
        sql_codes = sorted(set(re.findall(r"(?:Msg\s+|\()([0-9]{3,6})(?:,|\))", output)))
        categories = [name for name, pattern in {
            "login_rejected": r"Login failed|authentication failed",
            "client_option_rejected": r"Unknown Option|invalid option|Invalid argument|Unexpected argument|Invalid value",
            "connection_unavailable": r"connection.*failed|server was not found|Login timeout|TCP Provider",
        }.items() if re.search(pattern, output, re.I)]
        raise InventoryError(stage + "_failed_exit_" + str(process.returncode)
                             + "_sql_codes_" + ",".join(sql_codes)
                             + "_categories_" + ",".join(categories))
    return process.stdout.strip()


def load_credentials(repository, path, *, require_sql=True):
    sys.dont_write_bytecode = True
    spec = importlib.util.spec_from_file_location("yeshua_private_credentials", repository / "infra/private/credentials.py")
    reader = importlib.util.module_from_spec(spec)
    spec.loader.exec_module(reader)
    document = reader.read_json(path)
    if type(document.get("SchemaVersion")) is not int or document["SchemaVersion"] != 1:
        raise InventoryError("unsupported_private_configuration_schema")
    password = reader.get(document, "Shared", "SqlServer", "AdminPassword")
    if require_sql:
        password = reader.required(password, "Shared.SqlServer.AdminPassword")
    return document, password


def expected_databases(repository):
    names = {}
    wanted = {"CENTRAL", "CLINICA", "APS_ADM", "FISCAL", "MEMORIAS", "OPERATIONAL_INTELLIGENCE"}
    for line in (repository / "infra/docker/deploy.env").read_text(encoding="utf-8-sig").splitlines():
        match = re.fullmatch(r"YESHUA_DB_([A-Z_]+)=([A-Za-z0-9_]+)", line.strip())
        if match and match[1] in wanted:
            if match[1] in names:
                raise InventoryError("duplicate_database_declaration")
            names[match[1]] = match[2]
    if names.keys() != wanted or len(set(names.values())) != len(names):
        raise InventoryError("missing_or_ambiguous_database_declarations")
    return names


def sql_inventory(password):
    client = None
    for candidate in SQLCMD_PATHS:
        try:
            run(["docker", "exec", SQL_CONTAINER, "test", "-x", candidate], timeout=10)
            client = candidate
            break
        except InventoryError:
            pass
    if client is None:
        raise InventoryError("sqlcmd_not_found_in_sql_container")
    # docker inherits this one variable; its value never becomes an argument.
    env = dict(os.environ, SQLCMDPASSWORD=password)
    env.pop("SQLCMDINI", None)
    output = run(["docker", "exec", "-e", "SQLCMDPASSWORD", SQL_CONTAINER,
                  client, "-S", "localhost", "-U", "sa", "-d", "master", "-C",
                  "-b", "-r", "1", "-l", "10", "-t", "30", "-x",
                  "-y", "0", "-w", "65535", "-Q", QUERY], env=env,
                 timeout=45, stage="sql_metadata")
    try:
        framed = "".join(output.splitlines()).split(JSON_MARKER)
        if len(framed) != 2:
            raise ValueError("Missing or repeated inventory marker")
        document = json.loads(framed[1])
    except (ValueError, TypeError):
        raise InventoryError("invalid_sql_inventory_response") from None
    if not isinstance(document, dict) or not isinstance(document.get("databases"), list):
        raise InventoryError("invalid_sql_inventory_shape")
    return document, client


def identifier(value):
    if not isinstance(value, str) or not value or len(value) > 128 or any(ord(c) < 32 for c in value):
        raise InventoryError("invalid_sql_identifier")
    return "[" + value.replace("]", "]]") + "]"


def literal(value):
    if not isinstance(value, str) or any(ord(c) < 32 for c in value):
        raise InventoryError("invalid_sql_literal")
    return "N'" + value.replace("'", "''") + "'"


def execute(password, client, query, *, timeout=3600):
    env = dict(os.environ, SQLCMDPASSWORD=password)
    env.pop("SQLCMDINI", None)
    return run(["docker", "exec", "-e", "SQLCMDPASSWORD", SQL_CONTAINER, client,
                "-S", "localhost", "-U", "sa", "-d", "master", "-C", "-b", "-r", "1",
                "-l", "10", "-t", str(timeout), "-x", "-y", "0", "-w", "65535", "-Q", query],
               env=env, timeout=timeout + 15, stage="sql_operation")


def query_json(password, client, query):
    output = execute(password, client, "SET NOCOUNT ON; DECLARE @j nvarchar(max)=(" + query
                     + "); SELECT N'YESHUA_RESULT=' + @j;", timeout=30)
    try:
        parts = "".join(output.splitlines()).split("YESHUA_RESULT=")
        if len(parts) != 2:
            raise ValueError()
        return json.loads(parts[1])
    except ValueError:
        raise InventoryError("invalid_sql_operation_response") from None


def assert_no_external_sessions(password, client):
    sessions = query_json(password, client, """
        SELECT s.session_id FROM sys.dm_exec_sessions s
        WHERE s.is_user_process=1 AND s.session_id<>@@SPID FOR JSON PATH
    """)
    if sessions:
        raise InventoryError("other_sql_sessions_present_isolate_external_writers")


def database_files(password, client, name):
    return query_json(password, client, "SELECT name AS logical_name, type_desc, CONVERT(bigint,size)*8192 AS size_bytes FROM sys.master_files WHERE database_id=DB_ID("
                      + literal(name) + ") ORDER BY file_id FOR JSON PATH")


def backup_database(password, client, name, container_path, *, copy_only=True):
    require_user_database(name)
    # Never initialize/overwrite an existing media file. Caller owns a fresh SetId directory.
    query = ("BACKUP DATABASE " + identifier(name) + " TO DISK=" + literal(container_path)
             + " WITH " + ("COPY_ONLY, " if copy_only else "")
             + "CHECKSUM, STOP_ON_ERROR, COMPRESSION, BUFFERCOUNT=4, MAXTRANSFERSIZE=1048576;"
             + " RESTORE VERIFYONLY FROM DISK=" + literal(container_path) + " WITH CHECKSUM, STOP_ON_ERROR;")
    execute(password, client, query)


def backup_metadata(password, client, container_path):
    rows = query_json(password, client, """
        SELECT TOP (1) b.database_name, b.type, b.is_copy_only,
          CONVERT(varchar(36),b.backup_set_uuid) AS backup_guid,
          CONVERT(varchar(30),b.first_lsn) AS first_lsn,
          CONVERT(varchar(30),b.last_lsn) AS last_lsn,
          CONVERT(varchar(30),b.checkpoint_lsn) AS checkpoint_lsn,
          CONVERT(varchar(30),b.database_backup_lsn) AS database_backup_lsn,
          CONVERT(varchar(36),b.differential_base_guid) AS differential_base_guid,
          CONVERT(varchar(36),b.first_recovery_fork_guid) AS first_fork,
          CONVERT(varchar(36),b.last_recovery_fork_guid) AS last_fork,
          CONVERT(varchar(36),b.family_guid) AS family_guid,
          CONVERT(varchar(40),b.backup_finish_date,126) AS finished_at,
          b.has_backup_checksums, CONVERT(bigint,b.compressed_backup_size) AS bytes
        FROM msdb.dbo.backupset b
        JOIN msdb.dbo.backupmediafamily f ON f.media_set_id=b.media_set_id
        WHERE f.physical_device_name=""" + literal(container_path)
        + " AND b.backup_finish_date IS NOT NULL ORDER BY b.backup_set_id DESC FOR JSON PATH, INCLUDE_NULL_VALUES")
    return rows[0] if len(rows) == 1 else None


def verify_native(password, client, container_path):
    execute(password, client, "RESTORE VERIFYONLY FROM DISK=" + literal(container_path)
            + " WITH CHECKSUM, STOP_ON_ERROR;")


def backup_native(password, client, name, container_path, kind):
    require_user_database(name)
    if kind not in {"full", "differential", "logs"}:
        raise InventoryError("unsupported_native_backup_kind")
    command = "BACKUP LOG " if kind == "logs" else "BACKUP DATABASE "
    options = "DIFFERENTIAL, " if kind == "differential" else ""
    execute(password, client, command + identifier(name) + " TO DISK=" + literal(container_path)
            + " WITH " + options + "CHECKSUM, STOP_ON_ERROR, COMPRESSION, BUFFERCOUNT=4, MAXTRANSFERSIZE=1048576;")
    verify_native(password, client, container_path)


def differential_base(password, client, name):
    return query_json(password, client, "SELECT DISTINCT CONVERT(varchar(36),differential_base_guid) AS guid"
        + " FROM sys.master_files WHERE type=0 AND database_id=DB_ID(" + literal(name) + ") FOR JSON PATH, INCLUDE_NULL_VALUES")


def restore_database(password, client, name, container_path, files, *, recover=True):
    if name.casefold() in SYSTEM_DATABASES:
        raise InventoryError("system_database_requires_dba_recovery_procedure")
    if not files or any(item.get("type_desc") not in {"ROWS", "LOG"} for item in files):
        raise InventoryError("unsupported_database_file_type")
    import hashlib
    stem = hashlib.sha256(name.encode()).hexdigest()[:20]
    moves = ["MOVE " + literal(item["logical_name"]) + " TO "
             + literal("/var/opt/mssql/data/recovered_" + stem + "_" + str(index)
                       + (".ldf" if item["type_desc"] == "LOG" else ".mdf"))
             for index, item in enumerate(files)]
    # No REPLACE, SINGLE_USER or forced disconnect: never overwrite a database.
    execute(password, client, "IF DB_ID(" + literal(name) + ") IS NOT NULL THROW 51000, 'Database already exists', 1; "
            + "RESTORE DATABASE " + identifier(name) + " FROM DISK=" + literal(container_path)
            + " WITH CHECKSUM, STOP_ON_ERROR, " + ("RECOVERY, " if recover else "NORECOVERY, ")
            + ", ".join(moves) + "; "
            + ("DBCC CHECKDB (" + identifier(name) + ") WITH NO_INFOMSGS, ALL_ERRORMSGS;" if recover else ""))


def apply_restore_part(password, client, name, container_path, kind):
    if kind not in {"I", "L"}:
        raise InventoryError("unsupported_restore_sequence_part")
    execute(password, client, ("RESTORE LOG " if kind == "L" else "RESTORE DATABASE ") + identifier(name)
            + " FROM DISK=" + literal(container_path) + " WITH CHECKSUM, STOP_ON_ERROR, NORECOVERY;")


def finish_restore(password, client, name):
    execute(password, client, "RESTORE DATABASE " + identifier(name) + " WITH RECOVERY; DBCC CHECKDB ("
            + identifier(name) + ") WITH NO_INFOMSGS, ALL_ERRORMSGS;")


def require_user_database(name):
    identifier(name)
    if name.casefold() in SYSTEM_DATABASES:
        raise InventoryError("system_databases_are_excluded_from_backup")


def user_databases(metadata):
    return [d for d in metadata["databases"]
            if d["database_id"] > 4 and d["name"].casefold() not in SYSTEM_DATABASES]


def memorias_private_root(document, private_file):
    value = document.get("Apps", {}).get("Memorias", {}).get("PrivateRoot")
    return Path(value) if value else private_file.parent / "apps/Memorias"


def assess(sql, expected):
    databases = {item["name"]: item for item in sql["databases"]}
    missing = sorted(set(expected.values()) - databases.keys())
    findings = [{"code": "expected_database_missing", "database": name} for name in missing]
    for name in expected.values():
        database = databases.get(name)
        if database is None:
            continue
        if database["state_desc"] != "ONLINE":
            findings.append({"code": "database_not_online", "database": name})
        if database.get("is_encrypted"):
            findings.append({"code": "sql_encryption_key_recovery_required", "database": name})
        if database["recovery_model_desc"] in ("FULL", "BULK_LOGGED"):
            if not database.get("last_log"):
                findings.append({"code": "no_log_backup_recorded_in_msdb", "database": name})
            if database.get("log_reuse_wait_desc") == "LOG_BACKUP":
                findings.append({"code": "log_waiting_for_backup", "database": name})
    if sql.get("active_backup_restore"):
        findings.append({"code": "backup_or_restore_already_active"})
    extra = sorted(name for name in databases if name not in expected.values()
                   and databases[name].get("database_id", 0) > 4)
    return {"missing_databases": missing, "additional_databases_included": extra,
            "findings": findings, "backup_executed": False, "restore_proven": False}


def path_inventory(path, measure=True):
    path = Path(path)
    result = {"path": str(path), "exists": path.exists()}
    if path.is_symlink():
        result.update(symlink=True, recursive_measurement_skipped=True)
        return result
    if not path.exists():
        return result
    info = path.stat()
    result.update(uid=info.st_uid, gid=info.st_gid, mode=oct(info.st_mode & 0o777))
    if measure and path.is_dir() and path not in (Path("/"), Path("/root"), Path("/etc"), Path("/var")):
        args = ["du", "-s", "-B1", "--one-file-system", "--", str(path)]
        if shutil.which("nice"):
            args = ["nice", "-n", "19", *args]
        if shutil.which("ionice"):
            args = ["ionice", "-c", "3", *args]
        try:
            result["allocated_bytes"] = int(run(args, timeout=15).split()[0])
        except (InventoryError, ValueError, IndexError):
            result["measurement_incomplete"] = True
    return result


def host_inventory(document, private_file):
    memory = {}
    for line in Path("/proc/meminfo").read_text().splitlines():
        key, value = line.split(":", 1)
        memory[key] = int(value.split()[0])
    disk = os.statvfs("/root")
    private_root = private_file.parent
    memory_root = memorias_private_root(document, private_file)
    if not memory_root.is_absolute():
        raise InventoryError("memorias_private_bind_must_be_absolute")
    paths = {
        "sql_data": "/root/YeshuaDB/persistent/sql",
        "sql_backup_staging": "/root/YeshuaDB/persistent/sql/backup",
        "persistent_storage": "/root/YeshuaStorage/persistent",
        "volatile_storage": "/root/YeshuaStorage/volatile",
        "fiscal_plans_and_legacy": "/root/YeshuaStorage/fiscal",
        "fiscal_xml": "/root/YeshuaStorage/sefaz",
        "private_configuration": str(private_root),
        "memorias_vault": str(memory_root),
        "https_configuration": "/etc/letsencrypt",
        "telemetry_volatile": "/root/YeshuaStorage/volatile/infra/telemetry",
        "telemetry_legacy_requires_redeploy": "/root/YeshuaDB/persistent/telemetry",
    }
    return {"cpus": os.cpu_count(), "available_memory_mb": memory["MemAvailable"] // 1024,
            "swap_free_mb": memory["SwapFree"] // 1024,
            "disk_free_gb": round(disk.f_bavail * disk.f_frsize / 1024 ** 3, 2),
            "load_1m": float(Path("/proc/loadavg").read_text().split()[0]),
            "tools": {name: bool(shutil.which(name)) for name in ("restic", "sqlcmd", "du", "nice", "ionice")},
            "areas": {name: path_inventory(path) for name, path in paths.items()}}


def sql_staging_access():
    result = {"container_uid": int(run(["docker", "exec", SQL_CONTAINER, "id", "-u"], timeout=10))}
    try:
        run(["docker", "exec", SQL_CONTAINER, "test", "-w", "/var/opt/mssql/backup"], timeout=10)
        result["existing_backup_directory_writable"] = True
    except InventoryError:
        result["existing_backup_directory_writable"] = False
    return result


def container_inventory():
    ids = run(["docker", "ps", "-q"]).split()
    if not ids:
        raise InventoryError("no_running_containers")
    inspected = json.loads(run(["docker", "inspect", *ids], stage="container_inspection"))
    results = []
    for item in inspected:
        labels = item["Config"].get("Labels") or {}
        if not labels.get("com.docker.compose.project", "").startswith("playsis-"):
            continue
        results.append({"id": item["Id"][:12], "name": item["Name"], "image": item["Image"],
                        "service": labels.get("com.docker.compose.service"),
                        "configured_user": item["Config"].get("User", ""),
                        "started_at": item["State"]["StartedAt"], "restarts": item["RestartCount"],
                        "mounts": [{key: mount.get(key) for key in ("Type", "Source", "Destination", "RW")}
                                   for mount in item.get("Mounts", [])]})
    return results


def schedule_inventory():
    result = {"scope": "system_timers_and_root_system_cron_only"}
    try:
        timers = run(["systemctl", "list-timers", "--all", "--no-pager", "--no-legend", "--plain"])
        result["backup_related_timer_lines"] = sum(bool(re.search(r"backup|restic|borg|duplicity", line, re.I)) for line in timers.splitlines())
        result["backup_related_units"] = sorted(set(unit for line in timers.splitlines()
            if re.search(r"backup|restic|borg|duplicity", line, re.I)
            for unit in re.findall(r"\b[\w@.-]+\.(?:timer|service)\b", line)))
    except InventoryError:
        result["timer_review_incomplete"] = True
    cron_text = ""
    try:
        process = subprocess.run(["crontab", "-l"], capture_output=True, text=True, check=False, timeout=10)
        if process.returncode == 0:
            cron_text += process.stdout
        elif process.returncode != 1:
            result["root_cron_review_incomplete"] = True
    except (OSError, subprocess.TimeoutExpired):
        result["root_cron_review_incomplete"] = True
    candidates = [Path("/etc/crontab"), *Path("/etc/cron.d").glob("*")]
    for path in candidates:
        if path.is_file() and not path.is_symlink() and path.stat().st_size < 128 * 1024:
            cron_text += "\n" + path.read_text(errors="replace")
    result["backup_related_cron_lines"] = sum(bool(re.search(r"backup|restic|borg|duplicity", line, re.I)) for line in cron_text.splitlines() if not line.lstrip().startswith("#"))
    result["absence_does_not_prove_no_external_scheduler"] = True
    return result


def inventory(repository, private_file):
    document, password = load_credentials(repository, private_file)
    expected = expected_databases(repository)
    containers = container_inventory()
    sql, client = sql_inventory(password)
    return {"captured_at_utc": datetime.now(timezone.utc).isoformat(), "operation": "inventory_only",
            "expected_databases": expected, "sqlcmd_in_sql_container": client,
            "sql": sql, "assessment": assess(sql, expected), "host": host_inventory(document, private_file),
            "sql_backup_directory_access": sql_staging_access(),
            "containers": containers, "existing_schedules": schedule_inventory()}


def main(argv=None):
    parser = argparse.ArgumentParser(description=__doc__)
    parser.add_argument("action", nargs="?", choices=("inventory",), default="inventory")
    parser.add_argument("--file", type=Path,
                        default=Path(os.environ.get("YESHUA_DEPLOY_SECRETS_FILE", "/root/YeshuaPrivate/production/credentials.json")))
    args = parser.parse_args(argv)
    try:
        if os.name != "posix" or os.geteuid() != 0:
            raise InventoryError("run_on_linux_as_administrative_operator")
        result = inventory(ROOT, args.file)
    except Exception as error:
        result = {"operation": "inventory_only", "status": "failed",
                  "error": str(error) if isinstance(error, InventoryError) else "inventory_failed_details_omitted"}
        print(json.dumps(result))
        return 1
    print(json.dumps(result, indent=2))
    return 0


if __name__ == "__main__":
    raise SystemExit(main())
