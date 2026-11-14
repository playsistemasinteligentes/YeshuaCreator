#!/usr/bin/env python3
"""Apply native Docker builder GC; caller holds the standard deploy lock."""
import json
import os
from pathlib import Path
import subprocess
import tempfile
import time


POLICY = Path(__file__).with_name("build-cache-policy.json")
CONFIG = Path("/etc/docker/daemon.json")


def merge_policy(config, policy):
    # Preserve logging, storage, network and other daemon/builder settings.
    merged = dict(config)
    merged["builder"] = {**config.get("builder", {}), "gc": policy}
    return merged


def run(*args):
    return subprocess.run(args, check=True, text=True, capture_output=True, timeout=120)


def active_policy(policy):
    builders = run("docker", "buildx", "ls", "--format", "{{json .}}").stdout
    for line in builders.splitlines():
        builder = json.loads(line)
        if builder.get("Name") != "default" or builder.get("Driver") != "docker":
            continue
        for node in builder.get("Nodes", []):
            rules = node.get("GCPolicy") or []
            if len(rules) != 4:
                continue
            matches = True
            for actual in rules[1:]:
                for key in ("reservedSpace", "maxUsedSpace", "minFreeSpace"):
                    matches &= actual.get(key, 0) == int(policy["default" + key[0].upper() + key[1:]])
            matches &= rules[-1].get("all") is True
            if matches:
                return True
    return False


def write_config(config_path, config, runner=run):
    config_path.parent.mkdir(parents=True, exist_ok=True)
    temporary = None
    try:
        with tempfile.NamedTemporaryFile(mode="w", dir=config_path.parent, suffix=".json", delete=False) as stream:
            temporary = Path(stream.name)
            json.dump(config, stream, indent=2)
            stream.write("\n")
            stream.flush()
            os.fsync(stream.fileno())
        runner("dockerd", "--validate", "--config-file", str(temporary))
        if config_path.exists():
            stat = config_path.stat()
            os.chmod(temporary, stat.st_mode & 0o777)
            os.chown(temporary, stat.st_uid, stat.st_gid)
        os.replace(temporary, config_path)
    finally:
        if temporary is not None:
            temporary.unlink(missing_ok=True)


def main():
    if os.geteuid() != 0:
        raise RuntimeError("Execute como root pelo setup/deploy padrao.")
    policy = json.loads(POLICY.read_text())
    previous = json.loads(CONFIG.read_text()) if CONFIG.exists() else {}
    merged = merge_policy(previous, policy)
    if merged != previous:
        write_config(CONFIG, merged)
    if active_policy(policy):
        print("Cache Docker: politica de 30 GB ja ativa.")
        return
    # Try the non-disruptive path first; some Docker versions need a restart
    # to reconstruct the embedded BuildKit worker with its new GC policy.
    subprocess.run(["systemctl", "reload", "docker"], capture_output=True, timeout=120)
    if not active_policy(policy):
        print("Cache Docker: ativando politica com reinicio do Docker.", flush=True)
        running = run("docker", "ps", "-q").stdout.split()
        try:
            run("systemctl", "restart", "docker")
            for _ in range(30):
                try:
                    if active_policy(policy):
                        break
                except subprocess.SubprocessError:
                    pass
                time.sleep(1)
            else:
                raise RuntimeError("Politica de cache nao confirmada no builder ativo.")
        except Exception:
            write_config(CONFIG, previous)
            run("systemctl", "reset-failed", "docker.service", "docker.socket")
            run("systemctl", "start", "docker")
            if running:
                run("docker", "start", *running)
            raise
    print("Cache Docker: retencao nativa confirmada, alvo 30 GB e reserva de disco 30 GB.")


if __name__ == "__main__":
    main()
