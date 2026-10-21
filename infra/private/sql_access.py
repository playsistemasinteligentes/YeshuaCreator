"""Provision explicitly declared SQL access during server setup, never daily deploy."""

import argparse
import importlib.util
import json
import os
from pathlib import Path
import sys
import time

ROOT = Path(os.environ.get("YESHUA_APP_DIR", str(Path(__file__).resolve().parents[2])))


def module(name, path):
    spec = importlib.util.spec_from_file_location(name, path)
    result = importlib.util.module_from_spec(spec)
    spec.loader.exec_module(result)
    return result


private = module("setup_private_configuration", ROOT / "infra/private/credentials.py")
sql = module("setup_sql_primitives", ROOT / "infra/backups/sql.py")


def login_batch(name, entry):
    login, password = sql.literal(name), sql.literal(entry["Password"])
    query = ("SET NOCOUNT ON; SET XACT_ABORT ON; "
             "IF SUSER_ID(" + login + ") IS NULL BEGIN CREATE LOGIN " + sql.identifier(name)
             + " WITH PASSWORD=" + password + "; END; "
             "IF NOT EXISTS (SELECT 1 FROM sys.sql_logins WHERE name=" + login
             + " AND is_disabled=0 AND PWDCOMPARE(" + password + ",password_hash)=1) "
             "THROW 51000, 'Existing login does not match declared SQL access', 1; ")
    if entry.get("CreateDatabase", False):
        query += "GRANT CREATE ANY DATABASE TO " + sql.identifier(name) + "; "
    return query


def database_batch(name, database, roles, allow_missing):
    login, user = sql.literal(name), sql.identifier(name)
    body = ("USE " + sql.identifier(database) + "; "
            # A migration login may already own the new database as dbo.
            "IF SUSER_SID(" + login + ")<>(SELECT owner_sid FROM sys.databases WHERE name=DB_NAME()) BEGIN "
            "IF DATABASE_PRINCIPAL_ID(" + login + ") IS NULL CREATE USER " + user + " FOR LOGIN " + user + "; "
            "IF EXISTS (SELECT 1 FROM sys.database_principals WHERE name=" + login
            + " AND (type<>'S' OR authentication_type<>1)) "
            "THROW 51000, 'Existing database principal requires explicit review', 1; "
            "IF EXISTS (SELECT 1 FROM sys.database_principals WHERE name=" + login
            + " AND sid<>SUSER_SID(" + login + ")) ALTER USER " + user + " WITH LOGIN=" + user + "; ")
    for role in roles:
        body += ("IF IS_ROLEMEMBER(" + sql.literal(role) + "," + login + ")<>1 ALTER ROLE "
                 + sql.identifier(role) + " ADD MEMBER " + user + "; ")
    body += "END; "
    # Database-scoped names are compiled inside the selected database, not master.
    query = "SET NOCOUNT ON; SET XACT_ABORT ON; IF DB_ID(" + sql.literal(database) + ") IS NOT NULL EXEC(" + sql.literal(body) + "); "
    if not allow_missing:
        query += "ELSE THROW 51000, 'Declared access database is missing', 1; "
    return query


def execute_batch(password, client, batch):
    # Neither SQL containing a password nor the admin password belongs in argv/output.
    env = dict(os.environ, SQLCMDPASSWORD=password)
    env.pop("SQLCMDINI", None)
    sql.run(["docker", "exec", "-i", "-e", "SQLCMDPASSWORD", sql.SQL_CONTAINER, client,
             "-S", "localhost", "-U", "sa", "-d", "master", "-C", "-b", "-r", "1", "-x",
             "-l", "10", "-t", "30", "-i", "/dev/stdin"],
            env=env, input=batch, timeout=45, stage="setup_sql_access")


def provision(path, *, allow_missing=False, wait_seconds=120):
    document = private.read_json(path)
    private.environment(document, path.parent, "all", True)
    logins = private.sql_logins(document)
    password = private.required(private.get(document, "Shared", "SqlServer", "AdminPassword"), "Shared.SqlServer.AdminPassword")
    deadline = time.monotonic() + wait_seconds
    while True:
        try:
            _, client = sql.sql_inventory(password)
            break
        except sql.InventoryError:
            if time.monotonic() >= deadline:
                raise sql.InventoryError("setup_sql_admin_not_ready_or_credentials_rejected") from None
            time.sleep(2)
    # Validate all declarations before the first mutation; no inferred grants/rotation.
    batches = []
    for name, entry in logins.items():
        batches.append(login_batch(name, entry))
        for database, roles in entry.get("Databases", {}).items():
            batches.append(database_batch(name, database, roles, allow_missing))
    for batch in batches:
        execute_batch(password, client, batch)
    return {"operation": "setup-sql-access", "admin_connection_verified": True,
            "declared_logins": len(logins), "missing_databases_deferred": allow_missing,
            "passwords_rotated": False, "system_databases_restored": False}


def main():
    parser = argparse.ArgumentParser(description=__doc__)
    parser.add_argument("--file", default=os.environ.get("YESHUA_DEPLOY_SECRETS_FILE", private.DEFAULT_FILE))
    parser.add_argument("--allow-missing-databases", action="store_true")
    args = parser.parse_args()
    try:
        if os.name != "posix" or os.geteuid() != 0:
            raise sql.InventoryError("run_sql_access_setup_on_linux_as_root")
        print(json.dumps(provision(Path(args.file), allow_missing=args.allow_missing_databases)))
        return 0
    except KeyboardInterrupt:
        print("SQL access setup cancelled; review existing state before repeating.", file=sys.stderr)
    except Exception as error:
        message = str(error) if isinstance(error, (private.ConfigurationError, sql.InventoryError)) else "setup_sql_access_failed_details_omitted"
        print(message, file=sys.stderr)
    return 1


if __name__ == "__main__":
    raise SystemExit(main())
