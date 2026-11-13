"""Real builds in an isolated volatile checkout; never starts application containers."""
import argparse
import fcntl
import json
from pathlib import Path
import re
import subprocess
import time


def main():
    parser = argparse.ArgumentParser()
    parser.add_argument("--context", type=Path, required=True)
    parser.add_argument("--evict-download-cache", action="store_true", help="Also prune Docker exec.cachemount caches before testing package recovery.")
    args = parser.parse_args()
    context = args.context.resolve()
    if not context.is_relative_to(Path("/root/YeshuaStorage/volatile")) or not (context / ".cache-validation").is_file():
        raise RuntimeError("Validation requires an isolated, explicitly marked volatile checkout.")
    output = context.parent
    results = []
    commit = subprocess.check_output(["git", "-C", "/root/YeshuaCreator", "rev-parse", "HEAD"], text=True).strip()
    definitions = {
        "operational": ("infra/Shared/DockerCompose/operational-intelligence/Dockerfile", None),
        "memorias": ("infra/Memorias/DockerCompose/Dockerfile", "api"),
    }

    def build(case, app):
        dockerfile, target = definitions[app]
        log = output / f"{case}-{app}.log"
        command = ["docker", "build", "--progress=plain", "--build-arg", f"YESHUA_COMMIT_SHA={commit}",
                   "-f", dockerfile, "-t", f"yeshua-cache-validation:{app}"]
        if target:
            command += ["--target", target]
        started = time.monotonic()
        with log.open("w") as stream:
            result = subprocess.run(command + ["."], cwd=context, stdout=stream, stderr=subprocess.STDOUT)
        text = log.read_text()
        steps = dict(re.findall(r"^(#\d+) (\[.+?\] RUN .+)$", text, re.M))
        cached = set(re.findall(r"^(#\d+) CACHED$", text, re.M))
        executed = [description for number, description in steps.items() if number not in cached]
        item = {"case": case, "app": app, "seconds": round(time.monotonic() - started, 2),
                "exitCode": result.returncode, "executedRunSteps": executed,
                "cachedRunSteps": len(steps) - len(executed), "log": str(log)}
        results.append(item)
        (output / "results.json").write_text(json.dumps(results, indent=2))
        print(json.dumps(item), flush=True)
        if result.returncode:
            raise RuntimeError(f"Build failed; inspect {log}")
        return executed

    with open("/var/lock/yeshua-deploy.lock", "w") as lock:
        fcntl.flock(lock, fcntl.LOCK_EX)
        for app in definitions:
            build("baseline", app)
        for app in definitions:
            if build("repeat", app):
                raise RuntimeError("Unchanged build executed a RUN layer.")
        agent = context / "infra/Shared/DockerCompose/operational-intelligence/agent/codex-task.mjs"
        original = agent.read_bytes()
        try:
            agent.write_bytes(original + b"\n// Isolated cache validation.\n")
            if build("agent-change", "operational"):
                raise RuntimeError("Agent-only edit reinstalled dependencies or rebuilt the API.")
            if build("agent-change", "memorias"):
                raise RuntimeError("Agent edit invalidated an unrelated application.")
        finally:
            agent.write_bytes(original)
        source = context / "src/CQRS/Infrastructure/Yeshua.Memorias.CQRS.Infrastructure.Api/Program.cs"
        original = source.read_bytes()
        try:
            source.write_bytes(original + b"\n// Isolated cache validation.\n")
            executed = build("app-change", "memorias")
            if not executed or any("dotnet restore" in step for step in executed):
                raise RuntimeError("Source edit did not rebuild or invalidated package restore.")
            if build("app-change", "operational"):
                raise RuntimeError("Application edit invalidated the operational image.")
        finally:
            source.write_bytes(original)
        if args.evict_download_cache:
            subprocess.run(["docker", "builder", "prune", "--force", "--filter", "type=exec.cachemount"], check=True)
            source = context / "src/OperationalIntelligence/Yeshua.OperationalIntelligence.Api/Program.cs"
            original = source.read_bytes()
            try:
                source.write_bytes(original + b"\n// Validate package recovery after cache eviction.\n")
                build("download-cache-evicted", "operational")
            finally:
                source.write_bytes(original)
        print("Cache validation passed.", flush=True)


if __name__ == "__main__":
    main()
