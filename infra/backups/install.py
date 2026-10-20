"""Install backup tooling separately from application deployment. No app restart."""

import argparse
import hashlib
import json
import os
from pathlib import Path
import shutil
import subprocess
import sys

TIMERS = ("full", "differential", "logs", "files", "check", "check-data")
FILES = ("backup.py", "sql.py", "routine.py", "policy.json", "install.py", "README.md", "RECOVERY.md",
         "yeshua-backup@.service", *("yeshua-backup-" + kind + ".timer" for kind in TIMERS))


def run(args, env=None, timeout=120):
    process = subprocess.run(args, capture_output=True, text=True, timeout=timeout, env=env, check=False)
    if process.returncode:
        raise RuntimeError("installer_command_failed_" + args[0].split("/")[-1] + "_exit_" + str(process.returncode))
    return process.stdout


def secure(path):
    for candidate in [path, *path.parents]:
        if candidate.is_symlink():
            raise RuntimeError("installer_path_contains_symlink")
    path.mkdir(mode=0o700, parents=True, exist_ok=True)
    if path.stat().st_uid != 0 or path.stat().st_mode & 0o077:
        raise RuntimeError("installer_directory_must_be_root_0700")


def initialize_online(env, base, machine):
    catalog = base / "state/sql-catalog.json"
    if catalog.exists() and json.loads(catalog.read_text()).get("source_machine") != machine:
        raise RuntimeError("backup_state_belongs_to_another_machine_do_not_overwrite")
    for kind in ("full", "differential", "logs", "files", "check-data"):
        proof = base / "status" / (kind + ".json")
        receipt = json.loads(proof.read_text()) if proof.exists() else {}
        selection_current = kind != "files" or receipt.get("file_selection") == "persistent-roots-v1"
        if receipt.get("status") == "completed" and catalog.exists() and selection_current:
            failure = base / "status" / (kind + "-failure.json")
            if not failure.exists() or json.loads(failure.read_text()).get("failed_at", "") <= json.loads(proof.read_text()).get("finished_at", ""):
                continue
        print("Initial online backup: " + kind, file=sys.stderr, flush=True)
        run(["systemctl", "start", "yeshua-backup@" + kind + ".service"], env=env, timeout=14400)


def install(enable=False, initialize=False):
    if os.name != "posix" or os.geteuid() != 0:
        raise RuntimeError("run_installer_on_linux_as_root")
    if os.environ.get("YESHUA_APP_DIR", "/root/YeshuaCreator") != "/root/YeshuaCreator" or os.environ.get(
            "YESHUA_DEPLOY_SECRETS_FILE", "/root/YeshuaPrivate/production/credentials.json") != "/root/YeshuaPrivate/production/credentials.json":
        raise RuntimeError("installed_units_require_standard_app_and_private_paths_review_custom_layout")
    os.umask(0o077)
    persistent = Path("/root/YeshuaStorage/persistent")
    if any(path.is_symlink() for path in (persistent, *persistent.parents)):
        raise RuntimeError("persistent_storage_root_contains_symlink")
    persistent.mkdir(mode=0o750, parents=True, exist_ok=True)
    if not shutil.which("restic"):
        raise RuntimeError("install_reliable_distribution_restic_package_first")
    source = Path(__file__).resolve().parent
    checksum = hashlib.sha256()
    for name in FILES:
        path = source / name
        if path.is_symlink() or not path.is_file():
            raise RuntimeError("installer_source_file_missing_or_linked")
        checksum.update(name.encode() + b"\0" + path.read_bytes())
    release_id = checksum.hexdigest()[:20]
    root = Path("/opt/yeshua-backup")
    secure(root)
    secure(root / "releases")
    release = root / "releases" / release_id
    if not release.exists():
        destination = release / "infra/backups"
        destination.mkdir(mode=0o700, parents=True)
        for name in FILES:
            shutil.copyfile(source / name, destination / name)
            os.chmod(destination / name, 0o600)
    else:
        for name in FILES:
            if (release / "infra/backups" / name).read_bytes() != (source / name).read_bytes():
                raise RuntimeError("existing_release_checksum_mismatch")
    link = root / "current"
    if link.exists() and not link.is_symlink():
        raise RuntimeError("installer_current_path_is_not_managed_symlink")
    previous = os.readlink(link) if link.is_symlink() else None
    pending = root / "current.pending"
    if pending.exists() or pending.is_symlink():
        raise RuntimeError("installer_pending_link_requires_review")
    pending.symlink_to(release, target_is_directory=True)
    os.replace(pending, link)
    env = dict(os.environ, YESHUA_APP_DIR="/root/YeshuaCreator", PYTHONDONTWRITEBYTECODE="1")
    units = ["yeshua-backup@.service", *("yeshua-backup-" + kind + ".timer" for kind in TIMERS)]
    try:
        run(["systemd-analyze", "verify", *[str(release / "infra/backups" / name) for name in units]])
        for name in units:
            target = Path("/etc/systemd/system") / name
            if target.is_symlink():
                raise RuntimeError("existing_backup_unit_is_symlink")
            if target.exists() and target.read_bytes() != (source / name).read_bytes():
                raise RuntimeError("existing_backup_unit_differs_review_update_before_replacing")
            if not target.exists():
                shutil.copyfile(source / name, target)
                os.chmod(target, 0o644)
        run(["systemctl", "daemon-reload"])
        configured = run([sys.executable, "-B", str(link / "infra/backups/backup.py"), "configure-local"], env=env)
        result = json.loads(configured)
        if initialize:
            initialize_online(env, Path("/root/YeshuaBackup"), Path("/etc/machine-id").read_text().strip())
            enable = True
        if enable:
            base = Path("/root/YeshuaBackup/status")
            for kind in ("full", "differential", "logs", "files", "check-data"):
                proof = json.loads((base / (kind + ".json")).read_text())
                if proof.get("status") != "completed":
                    raise RuntimeError("initial_backup_proofs_required_before_scheduling")
                if kind == "files" and proof.get("file_selection") != "persistent-roots-v1":
                    raise RuntimeError("current_persistent_root_snapshot_required_before_scheduling")
            run([sys.executable, "-B", str(link / "infra/backups/backup.py"), "sql-restore-plan"], env=env)
            run(["systemctl", "enable", "--now", *("yeshua-backup-" + k + ".timer" for k in TIMERS)])
        return {"operation": "install-backup-tooling", "release": release_id, "local_repository": result["repository"],
                "schedules_enabled": enable, "external_destination_pending": True, "applications_restarted": False}
    except Exception:
        link.unlink()
        if previous:
            link.symlink_to(previous, target_is_directory=True)
        raise


if __name__ == "__main__":
    parser = argparse.ArgumentParser(description=__doc__)
    parser.add_argument("--enable-schedules", action="store_true")
    parser.add_argument("--initialize-online", action="store_true", help="Complete missing initial proofs and enable schedules; preserve existing backups/keys.")
    args = parser.parse_args()
    try:
        print(json.dumps(install(args.enable_schedules, args.initialize_online), indent=2))
    except Exception as error:
        print(json.dumps({"operation": "install-backup-tooling", "status": "failed",
                          "error": str(error) if isinstance(error, RuntimeError) else "installer_failed_details_omitted"}))
        raise SystemExit(1)
