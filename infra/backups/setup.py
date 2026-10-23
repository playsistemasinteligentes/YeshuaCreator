"""One setup entry per host role; preparation and recovery remain separate."""

import argparse
from contextlib import contextmanager
import importlib.util
import json
import os
from pathlib import Path
import re
import sys

sys.dont_write_bytecode = True


def load(name):
    spec = importlib.util.spec_from_file_location("yeshua_setup_" + name, Path(__file__).with_name(name + ".py"))
    module = importlib.util.module_from_spec(spec)
    sys.modules[spec.name] = module
    spec.loader.exec_module(module)
    return module


control = load("control")
op, routine = control.op, control.routine
BASE = Path("/root/YeshuaRecovery/setup")
OPERATOR = Path("/root/YeshuaRecovery/operator/credentials.json")
PRIVATE = Path("/root/YeshuaPrivate/production/credentials.json")


@contextmanager
def terminal():
    with routine.recovery_terminal(op) as pair:
        yield pair


def ask(message, choices=None):
    with terminal() as (reader, writer):
        while True:
            writer.write(message + " ")
            writer.flush()
            answer = reader.readline(4096)
            if not answer or answer.strip().upper() == "CANCELAR":
                raise op.Error("setup_cancelled")
            if len(answer) == 4096:
                while answer and not answer.endswith("\n"):
                    answer = reader.readline(4096)
                writer.write("Resposta muito longa; tente novamente.\n")
                continue
            answer = answer.strip()
            if choices is None and answer:
                return answer
            if choices and answer.upper() in choices:
                return choices[answer.upper()]
            writer.write("Opcao nao reconhecida. Tente novamente ou digite CANCELAR.\n")


def confirm(message, word="CONFIRMAR"):
    return ask(message + " Digite " + word + " ou CANCELAR:", {word: True})


def state_path(role):
    if role not in {"applications", "storage"}:
        raise op.Error("invalid_setup_role")
    return op.private_directory(BASE, create=True) / (role + ".json")


def read_state(role):
    path = state_path(role)
    value = control.private_json(path) if path.exists() else None
    if value and (value.get("schema") != 1 or value.get("machine_id") != op.machine_id() or value.get("role") != role):
        raise op.Error("setup_state_belongs_to_another_machine")
    return value


def save(value):
    op.write(state_path(value["role"]), value)


def choose(role, mode=None):
    other = "storage" if role == "applications" else "applications"
    if state_path(other).exists():
        raise op.Error("application_and_storage_setups_belong_on_different_machines")
    if role == "storage" and op.shutil.which("docker"):
        projects = op.sql.run(["docker", "ps", "-a", "--format", '{{.Label "com.docker.compose.project"}}']).splitlines()
        if any(project.startswith("playsis-") for project in projects):
            raise op.Error("storage_setup_refused_on_application_host")
    value = read_state(role)
    if value:
        if mode and value["mode"] != mode:
            raise op.Error("setup_mode_already_selected_review_existing_state_before_switching")
        return value["mode"]
    if not mode:
        mode = ask("\n" + ("Servidor dos aplicativos" if role == "applications" else "Servidor de storage")
                   + ": 1 - instalar/reaplicar; 2 - recuperar backup:",
                   {"1": "new", "NOVO": "new", "NEW": "new", "2": "restore", "RECUPERAR": "restore", "RESTORE": "restore"})
    if mode not in {"new", "restore"}:
        raise op.Error("invalid_setup_mode")
    save({"schema": 1, "role": role, "mode": mode, "machine_id": op.machine_id(),
          "created_at": op.now(), "phase": "selected"})
    return mode


def wait_file(path, validator, template=None):
    op.private_directory(path.parent, create=True)
    if not path.exists() and template is not None:
        op.write(path, template)
    while True:
        try:
            return validator(control.private_json(path))
        except Exception as error:
            print("Configuracao ainda nao esta pronta: " + str(path)
                  + ". Reponha o JSON e suas chaves por SSH/SFTP (pasta 0700, arquivos 0600)."
                  + " Conteudo e senhas nao serao exibidos.", file=sys.stderr)
            if isinstance(error, (op.Error, RuntimeError)) and re.fullmatch(r"[a-z0-9_]+", str(error)):
                print("Verificacao: " + str(error), file=sys.stderr)
        ask("Digite PRONTO para validar novamente ou CANCELAR:", {"PRONTO": True})


def operator_document(document):
    if document.get("SchemaVersion") != 1:
        raise op.Error("operator_credentials_require_schema_1")
    config = document.get("Shared", {}).get("Backup", {})
    if not config.get("Repository"):
        raise op.Error("recovery_requires_existing_repository_not_empty_destination")
    settings = config.get("Sftp", {})
    for key in ("IdentityFile", "KnownHostsFile"):
        if key in settings:
            path = Path(settings[key])
            sibling = OPERATOR.parent / path.name
            if not path.exists() and sibling.is_file():
                settings[key] = str(sibling)
    op.restic_env(document)
    op.sftp_options(document)
    return document


def prepare(role, mode):
    value = read_state(role)
    if not value or value["mode"] != mode:
        raise op.Error("select_setup_mode_first")
    if role == "storage" and value["phase"] == "awaiting_source":
        value.update(load("enrollment").prepare_storage(sys.modules[__name__], mode), phase="prepared")
        save(value)
    if value["phase"] != "selected":
        return {"status": "prepared", "role": role, "mode": mode, "phase": value["phase"]}
    context = sys.modules[__name__]
    if role == "applications" and mode == "restore":
        recovery = load("recovery")
        document = wait_file(OPERATOR, operator_document,
            {"SchemaVersion": 1, "Shared": {"Backup": {"Repository": "", "Password": ""}}})
        try:
            options = recovery.recovery_points(context, document)
        except op.Error:
            if not document["Shared"]["Backup"].get("Repository", "").startswith("sftp:"):
                raise
            confirm("Nao foi possivel acessar o storage. Autorizar o novo IP usando acesso SSH administrativo temporario?", "AUTORIZAR")
            load("enrollment").authorize_recovery(context, document)
            options = recovery.recovery_points(context, document)
        if not options:
            raise op.Error("no_sql_and_files_recovery_points_in_repository")
        for index, item in enumerate(options, 1):
            print(str(index) + " - arquivos " + item["files_time"] + "; SQL " + item["sql_time"], file=sys.stderr)
        selected = ask("Escolha o ponto de recuperacao:", {str(i): item for i, item in enumerate(options, 1)})
        preview = json.loads(op.restic(document, ["dump", selected["files_snapshot"],
                                  "/root/YeshuaBackup/metadata/current/recovery-contract.json"]))
        if preview.get("schema") != 1:
            raise op.Error("unsupported_server_recovery_contract")
        if preview.get("tracked_changes_not_captured"):
            confirm("O backup informa alteracoes locais fora do Git. Apenas a revisao publicada pode ser reconstruida. Continuar?", "CONTINUAR")
            value["committed_only_authorized"] = True
        confirm("Confirme que a maquina antiga esta desligada ou isolada. A recuperacao usara esta copia em uma maquina vazia. Aplicativos so serao liberados apos bancos, arquivos"
                " e acessos verificados. Integracoes externas podem exigir reconciliacao. Autoriza a recuperacao e posterior liberacao?", "RECUPERAR")
        value.update(selected, phase="prepared", release_authorized=True)
    elif role == "storage":
        value.update(load("enrollment").prepare_storage(context, mode), phase="prepared")
    else:
        document = control.private_json(PRIVATE)
        backup = document.get("Shared", {}).get("Backup", {})
        if not control.source.owner(control):
            repository = backup.get("Repository", "")
            match = load("enrollment").SFTP.fullmatch(repository)
            pair = bool(match) or ask("Vincular os backups a uma Storage VPS agora? SIM ou NAO:",
                                     {"SIM": True, "S": True, "NAO": False, "N": False})
            if pair:
                value["storage_address"] = match[2] if match else load("enrollment").endpoint(context, ask("IP da Storage VPS:"))
                value["storage_port"] = int(ask("Porta SSH administrativa do storage (normalmente 22):"))
                value["source_name"] = ask("Nome desta origem no storage (por exemplo production):")
        value["phase"] = "prepared"
    save(value)
    return {"status": "prepared", "role": role, "mode": mode}


def finish_applications():
    value = read_state("applications")
    if not value:
        raise op.Error("application_setup_state_required")
    if value["mode"] == "restore" and value["phase"] != "completed":
        raise op.Error("restore_must_finish_before_backup_pairing")
    document = control.private_json(PRIVATE)
    if not control.source.owner(control) and (value.get("storage_address") or
            document.get("Shared", {}).get("Backup", {}).get("Repository", "").startswith("sftp:")):
        load("enrollment").pair_from_source(sys.modules[__name__], value)
    value.update(phase="completed", completed_at=op.now())
    save(value)
    return {"status": "application_setup_completed", "controller_managed": bool(control.source.owner(control))}


def run(role, mode):
    value = read_state(role)
    if not value or value["mode"] != mode or value["phase"] == "selected":
        raise op.Error("setup_preparation_required")
    context = sys.modules[__name__]
    if role == "storage":
        return load("enrollment").run_storage(context, value)
    if mode == "restore":
        return load("recovery").run(context, value)
    raise op.Error("new_application_installation_uses_existing_deploy")


def main(argv=None):
    parser = argparse.ArgumentParser(description=__doc__)
    parser.add_argument("action", choices=["choose", "prepare", "run", "finish", "status"])
    parser.add_argument("--role", choices=["applications", "storage"], required=True)
    parser.add_argument("--mode", choices=["new", "restore"])
    args = parser.parse_args(argv)
    if os.name != "posix" or os.geteuid() != 0:
        raise op.Error("server_setup_requires_linux_root")
    os.umask(0o077)
    if args.action == "choose":
        print(choose(args.role, args.mode))
        return 0
    with op.locked(BASE / (args.role + ".lock")):
        if args.action == "prepare":
            result = prepare(args.role, args.mode)
        elif args.action == "run":
            result = run(args.role, args.mode)
        elif args.action == "finish":
            if args.role != "applications":
                raise op.Error("finish_is_for_application_host")
            result = finish_applications()
        else:
            result = read_state(args.role) or {"status": "not_started"}
    print(json.dumps(result, ensure_ascii=True))
    return 0


if __name__ == "__main__":
    try:
        raise SystemExit(main())
    except KeyboardInterrupt:
        print("Setup cancelado; dados existentes foram preservados.", file=sys.stderr)
        raise SystemExit(1)
    except Exception as error:
        print(json.dumps({"status": "failed", "error": str(error) if isinstance(error, op.Error) else "setup_failed_details_omitted"}))
        raise SystemExit(1)
