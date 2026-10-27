"""Private deployment configuration. No key generation or data migration."""

import argparse
import base64
import copy
from contextlib import contextmanager, ExitStack
import json
import os
from pathlib import Path
import re
import shutil
import stat
import subprocess
import sys

APPS = {"central": "Central", "clinica": "Clinica", "aps-adm": "APS.ADM",
        "fiscal": "Fiscal", "memorias": "Memorias"}
DB_KEYS = {"Central": "CENTRAL", "Clinica": "CLINICA", "APS.ADM": "APS_ADM",
           "Fiscal": "FISCAL", "Memorias": "MEMORIAS"}
DEFAULT_FILE = "/root/YeshuaPrivate/production/credentials.json"
LEGACY_MEMORIAS_ROOT = Path("/root/YeshuaMemoriasSecrets")


class ConfigurationError(Exception):
    pass


def windows_access(path, protect=False):
    # SID-based checks do not depend on the workstation language.
    script = r"""
$Target = $env:YESHUA_ACL_TARGET
$Protect = $env:YESHUA_ACL_PROTECT
$ErrorActionPreference = 'Stop'
Import-Module Microsoft.PowerShell.Security -ErrorAction Stop
$me = [Security.Principal.WindowsIdentity]::GetCurrent().User
$allowed = @($me.Value, 'S-1-5-18', 'S-1-5-32-544')
if ($Protect -eq 'yes') {
    $acl = Get-Acl -LiteralPath $Target
    $acl.SetAccessRuleProtection($true, $false)
    foreach ($rule in @($acl.Access)) { [void]$acl.RemoveAccessRuleSpecific($rule) }
    $acl.SetOwner($me)
    foreach ($sid in $allowed) {
        $identity = [Security.Principal.SecurityIdentifier]::new($sid)
        if (Test-Path -LiteralPath $Target -PathType Container) {
            $rule = [Security.AccessControl.FileSystemAccessRule]::new($identity, 'FullControl', 'ContainerInherit,ObjectInherit', 'None', 'Allow')
        } else {
            $rule = [Security.AccessControl.FileSystemAccessRule]::new($identity, 'FullControl', 'Allow')
        }
        $acl.AddAccessRule($rule)
    }
    Set-Acl -LiteralPath $Target -AclObject $acl
}
$acl = Get-Acl -LiteralPath $Target
if ($acl.GetOwner([Security.Principal.SecurityIdentifier]).Value -notin $allowed) { exit 1 }
foreach ($rule in $acl.Access) {
    if ($rule.AccessControlType -eq 'Allow' -and $rule.IdentityReference.Translate([Security.Principal.SecurityIdentifier]).Value -notin $allowed) { exit 1 }
}
"""
    child_env = dict(os.environ, YESHUA_ACL_TARGET=str(path), YESHUA_ACL_PROTECT="yes" if protect else "no")
    child_env.pop("PSModulePath", None)
    shell = shutil.which("pwsh") or str(Path(os.environ["SystemRoot"]) / "System32/WindowsPowerShell/v1.0/powershell.exe")
    result = subprocess.run([shell, "-NoProfile", "-NonInteractive", "-Command",
                             script], env=child_env,
                            stdout=subprocess.DEVNULL, stderr=subprocess.DEVNULL)
    if result.returncode:
        raise ConfigurationError("ACL privada invalida ou impossivel de aplicar.")


def validate_access(path):
    if not Path(path).is_absolute():
        raise ConfigurationError("O caminho privado deve ser absoluto.")
    path = Path(os.path.abspath(path))
    for candidate in [path, *path.parents]:
        info = candidate.lstat()
        if stat.S_ISLNK(info.st_mode) or getattr(info, "st_file_attributes", 0) & getattr(stat, "FILE_ATTRIBUTE_REPARSE_POINT", 0):
            raise ConfigurationError("Links nao sao permitidos no caminho privado.")
        if candidate == path and not stat.S_ISREG(info.st_mode):
            raise ConfigurationError("A configuracao privada deve ser arquivo regular.")
        if os.name != "nt":
            owners = (os.geteuid(),) if candidate in (path, path.parent) else (0, os.geteuid())
            if info.st_uid not in owners or info.st_mode & 0o022:
                raise ConfigurationError("Proprietario ou escrita de terceiros no caminho privado.")
            if candidate in (path, path.parent) and info.st_mode & 0o077:
                raise ConfigurationError("Arquivo/pasta privada permitem acesso de terceiros.")
    if os.name == "nt":
        windows_access(path)
        windows_access(path.parent)
    return path


def unique_object(pairs):
    result = {}
    for key, value in pairs:
        if key in result:
            raise ConfigurationError("JSON privado contem chave duplicada.")
        result[key] = value
    return result


def read_json(path):
    path = validate_access(path)
    try:
        flags = os.O_RDONLY | getattr(os, "O_NOFOLLOW", 0)
        with os.fdopen(os.open(path, flags), "r", encoding="utf-8-sig") as source:
            if os.fstat(source.fileno()).st_size > 1024 * 1024:
                raise ConfigurationError("Configuracao privada excede o tamanho permitido.")
            result = json.load(source, object_pairs_hook=unique_object)
        if not isinstance(result, dict):
            raise ConfigurationError("A raiz da configuracao deve ser um objeto JSON.")
        return result
    except (ValueError, UnicodeError):
        raise ConfigurationError("JSON privado invalido; conteudo omitido.") from None


def get(document, *keys):
    value = document
    for key in keys:
        if not isinstance(value, dict):
            raise ConfigurationError("Secao privada deve ser um objeto JSON.")
        value = value.get(key, {})
    if value == {} or value is None:
        return ""
    if not isinstance(value, str) or any(char in value for char in "\0\r\n"):
        raise ConfigurationError("Credenciais devem ser strings de uma unica linha.")
    return value


def required(value, name):
    if not value.strip() or value.startswith("<"):
        raise ConfigurationError("Configuracao obrigatoria ausente: " + name)
    return value


def sql_logins(document):
    shared = document.get("Shared", {})
    server = shared.get("SqlServer", {}) if isinstance(shared, dict) else None
    if not isinstance(server, dict):
        raise ConfigurationError("Shared.SqlServer deve ser um objeto.")
    config = server.get("Logins", {})
    if not isinstance(config, dict):
        raise ConfigurationError("Shared.SqlServer.Logins deve ser um objeto.")
    roles = {"db_owner", "db_datareader", "db_datawriter", "db_ddladmin", "db_backupoperator"}
    seen = set()
    for name, entry in config.items():
        if (not isinstance(name, str) or not name or len(name) > 128 or any(ord(c) < 32 for c in name)
                or name.casefold() in {"sa", "dbo", "guest", "sys", "information_schema", "public"}
                or name.casefold() in seen):
            raise ConfigurationError("Nome de login SQL invalido, reservado ou duplicado.")
        seen.add(name.casefold())
        if not isinstance(entry, dict) or set(entry) - {"Password", "CreateDatabase", "Databases"}:
            raise ConfigurationError("Login SQL aceita somente Password, CreateDatabase e Databases.")
        required(get(entry, "Password"), "Shared.SqlServer.Logins.Password")
        if type(entry.get("CreateDatabase", False)) is not bool:
            raise ConfigurationError("CreateDatabase deve ser booleano.")
        databases = entry.get("Databases", {})
        if not isinstance(databases, dict):
            raise ConfigurationError("Databases deve mapear nomes de bancos para listas de roles.")
        seen_databases = set()
        for database, selected in databases.items():
            if (not isinstance(database, str) or not database or len(database) > 128
                    or any(ord(c) < 32 for c in database) or database.casefold() in {"master", "model", "msdb", "tempdb"}
                    or database.casefold() in seen_databases):
                raise ConfigurationError("Banco de usuario invalido ou duplicado no provisionamento SQL.")
            seen_databases.add(database.casefold())
            if (not isinstance(selected, list) or any(not isinstance(role, str) or role not in roles for role in selected)
                    or len(set(selected)) != len(selected)):
                raise ConfigurationError("Roles SQL invalidas ou duplicadas; declarar somente roles de banco permitidas.")
    return config


def exports(document, root, target, include_shared=False):
    if type(document.get("SchemaVersion")) is not int or document["SchemaVersion"] != 1:
        raise ConfigurationError("SchemaVersion deve ser 1.")
    if target not in {*APPS, "shared", "all", "gateway"}:
        raise ConfigurationError("Destino de configuracao desconhecido.")
    selected = set(APPS.values()) if target == "all" else {APPS[target]} if target in APPS else set()
    shared = target in ("all", "shared", "gateway") or include_shared
    if shared:
        sql_logins(document)
    result = {
        "YESHUA_SQL_SA_PASSWORD": get(document, "Shared", "SqlServer", "AdminPassword"),
        "YESHUA_RABBITMQ_USERNAME": get(document, "Shared", "RabbitMq", "UserName"),
        "YESHUA_RABBITMQ_PASSWORD": get(document, "Shared", "RabbitMq", "Password"),
        "YESHUA_CELERY_BROKER_URL": get(document, "Shared", "RabbitMq", "BrokerUrl"),
        "YESHUA_JWT_SECRET": get(document, "Shared", "Jwt", "SecretKey"),
        "YESHUA_MODULE_SHARED_KEY": get(document, "Shared", "ModuleAuthentication", "SharedKey"),
        "YESHUA_TELEMETRY_GRAFANA_USER": get(document, "Shared", "Grafana", "UserName"),
        "YESHUA_TELEMETRY_GRAFANA_PASSWORD": get(document, "Shared", "Grafana", "Password"),
        "YESHUA_SQL_OPERATIONAL_INTELLIGENCE": get(document, "Shared", "OperationalIntelligence", "ConnectionString"),
        "YESHUA_SQL_CENTRAL_AUTHORIZATION": get(document, "Shared", "CentralAuthorization", "ConnectionString"),
        "YESHUA_CLINICA_UPLOAD_SIGNING_KEY": get(document, "Apps", "Clinica", "Upload", "SigningKey"),
    }
    for app, suffix in DB_KEYS.items():
        for mode in ("Read", "Write"):
            key = "YESHUA_SQL_" + suffix + "_" + mode.upper()
            result[key] = get(document, "Apps", app, "MyConfig", mode + "ConectionString")
            if app in selected:
                required(result[key], "Apps." + app + ".MyConfig." + mode + "ConectionString")
    for name in [*DB_KEYS, "OperationalIntelligence"]:
        key = "YESHUA_SQL_MCP_" + DB_KEYS.get(name, "OPERATIONAL_INTELLIGENCE")
        result[key] = get(document, "Shared", "OperationalIntelligence", "DatabaseQueries", name)
        if shared:
            required(result[key], "Shared.OperationalIntelligence.DatabaseQueries." + name)
    needed = []
    if selected:
        needed += ["YESHUA_RABBITMQ_USERNAME", "YESHUA_RABBITMQ_PASSWORD",
                   "YESHUA_SQL_CENTRAL_AUTHORIZATION", "YESHUA_JWT_SECRET"]
    if shared:
        needed += ["YESHUA_SQL_SA_PASSWORD", "YESHUA_RABBITMQ_USERNAME", "YESHUA_RABBITMQ_PASSWORD",
                   "YESHUA_TELEMETRY_GRAFANA_USER", "YESHUA_TELEMETRY_GRAFANA_PASSWORD",
                   "YESHUA_SQL_OPERATIONAL_INTELLIGENCE"]
    if selected.intersection({"APS.ADM", "Fiscal"}):
        needed.append("YESHUA_MODULE_SHARED_KEY")
    if "Clinica" in selected:
        needed.append("YESHUA_CLINICA_UPLOAD_SIGNING_KEY")
    if "Memorias" in selected:
        needed.append("YESHUA_CELERY_BROKER_URL")
    for key in needed:
        required(result[key], key)
    for key in ("YESHUA_JWT_SECRET", "YESHUA_MODULE_SHARED_KEY", "YESHUA_CLINICA_UPLOAD_SIGNING_KEY"):
        if key in needed and len(result[key].encode("utf-8")) < 32:
            raise ConfigurationError("Chave de assinatura deve ter pelo menos 32 bytes: " + key)
    result["YESHUA_PRIVATE_ROOT"] = str(root)
    result["YESHUA_FISCAL_PRIVATE_ROOT"] = str(root / "apps" / "Fiscal")
    memory_root = get(document, "Apps", "Memorias", "PrivateRoot")
    if memory_root and not Path(memory_root).is_absolute():
        raise ConfigurationError("Apps.Memorias.PrivateRoot deve ser absoluto.")
    if "Memorias" in selected and memory_root and not Path(memory_root).is_dir():
        raise ConfigurationError("Apps.Memorias.PrivateRoot nao existe. Reponha o diretorio YouTube antes de publicar; ele nao sera recriado vazio.")
    result["YESHUA_MEMORIAS_PRIVATE_ROOT"] = memory_root or str(root / "apps" / "Memorias")
    suffix = DB_KEYS[APPS[target]] if target in APPS else None
    result["MYCONFIG__READCONECTIONSTRING"] = result["YESHUA_SQL_" + suffix + "_READ"] if suffix else ""
    result["MYCONFIG__WRITECONECTIONSTRING"] = result["YESHUA_SQL_" + suffix + "_WRITE"] if suffix else ""
    result["MYCONFIG__CENTRALAUTHORIZATIONCONECTIONSTRING"] = result["YESHUA_SQL_CENTRAL_AUTHORIZATION"]
    result.update({key: "" for key in ("OPENAI_API_KEY", "ANTHROPIC_API_KEY",
        "YESHUA_MCP_TUNNEL_ID", "YESHUA_MCP_TUNNEL_API_KEY",
        "YESHUA_MEMORIAS_YOUTUBE_CLIENT_ID", "YESHUA_MEMORIAS_YOUTUBE_CLIENT_SECRET",
        "YESHUA_MEMORIAS_YOUTUBE_ENCRYPTION_KEY", "YESHUA_MEMORIAS_YOUTUBE_REDIRECT_URI",
        "YESHUA_MEMORIAS_CONFIG_ADMIN_TENANT_ID", "YESHUA_MEMORIAS_CONFIG_ADMIN_USER_ID")})
    return result


def environment(document, root, target, include_shared=False):
    result = exports(document, root, target, include_shared)
    if target in ("memorias", "all"):
        bootstrap = root / "apps" / "Memorias" / "integracoes" / "youtube" / "bootstrap.json"
        if bootstrap.exists():
            config = read_json(bootstrap)
            properties = (("ClientId", "CLIENT_ID"), ("ClientSecret", "CLIENT_SECRET"), ("EncryptionKey", "ENCRYPTION_KEY"))
            for prop, name in properties:
                result["YESHUA_MEMORIAS_YOUTUBE_" + name] = get(config, prop)
            protection_key = result["YESHUA_MEMORIAS_YOUTUBE_ENCRYPTION_KEY"]
            if protection_key:
                try:
                    valid_key = len(base64.b64decode(protection_key, validate=True)) == 32
                except ValueError:
                    valid_key = False
                if not valid_key:
                    raise ConfigurationError("Chave bootstrap YouTube deve ser base64 de 32 bytes; nao gere outra para substituir um cofre existente.")
            for prop, variable in (("RedirectUri", "YESHUA_MEMORIAS_YOUTUBE_REDIRECT_URI"),
                                   ("ConfigurationAdminTenantId", "YESHUA_MEMORIAS_CONFIG_ADMIN_TENANT_ID"),
                                   ("ConfigurationAdminUserId", "YESHUA_MEMORIAS_CONFIG_ADMIN_USER_ID")):
                if prop in config:
                    value = config[prop]
                    if prop == "RedirectUri":
                        value = get(config, prop)
                    elif type(value) not in (int, str) or not str(value).isdigit():
                        raise ConfigurationError("Configuracao YouTube invalida.")
                    result[variable] = str(value)
        legacy = LEGACY_MEMORIAS_ROOT
        if legacy.is_dir() and any(legacy.iterdir()) and not get(document, "Apps", "Memorias", "PrivateRoot"):
            raise ConfigurationError("Cofre Memorias existente: configure Apps.Memorias.PrivateRoot explicitamente antes do deploy.")
    if target in ("shared", "all", "gateway") or include_shared:
        providers = root / "shared" / "OperationalAgent" / "integracoes" / "providers.json"
        if providers.exists():
            config = read_json(providers)
            result["OPENAI_API_KEY"] = get(config, "OpenAI", "ApiKey")
            result["ANTHROPIC_API_KEY"] = get(config, "Anthropic", "ApiKey")
            result["YESHUA_MCP_TUNNEL_ID"] = get(config, "McpTunnel", "Id")
            result["YESHUA_MCP_TUNNEL_API_KEY"] = get(config, "McpTunnel", "ApiKey")
            tunnel_id, tunnel_key = result["YESHUA_MCP_TUNNEL_ID"], result["YESHUA_MCP_TUNNEL_API_KEY"]
            if bool(tunnel_id) != bool(tunnel_key) or (tunnel_id and not tunnel_id.startswith("tunnel_")):
                raise ConfigurationError("McpTunnel exige Id valido e ApiKey juntos em providers.json.")
    # App-owned configuration lives in the main credentials document; never inherit secrets.
    clinical_keys = ("CLINICA_PROCESSING_SCOPE", "CLINICA_CODEX_MODEL", "CLINICA_CODEX_TIMEOUT_SECONDS",
                     "CLINICA_TRANSCRIPTION_API_KEY", "CLINICA_TRANSCRIPTION_MODEL", "CLINICA_TRANSCRIPTION_BASE_URL",
                     "CLINICA_TRANSCRIPTION_PROVIDER", "CLINICA_CODEX_EXECUTOR_ENABLED")
    result.update({key: "" for key in clinical_keys})
    if target in ("clinica", "shared", "all") or include_shared:
        config = document.get("Apps", {}).get("Clinica", {})
        if config:
            enabled = config.get("Codex", {}).get("Enabled", False)
            if type(enabled) is not bool:
                raise ConfigurationError("Apps.Clinica.Codex.Enabled deve ser booleano.")
            result.update({
                "CLINICA_CODEX_EXECUTOR_ENABLED": str(enabled).lower(),
                "CLINICA_PROCESSING_SCOPE": get(config, "ProcessingScope"),
                "CLINICA_CODEX_MODEL": get(config, "Codex", "Model"),
                "CLINICA_CODEX_TIMEOUT_SECONDS": str(config.get("Codex", {}).get("TimeoutSeconds", 900)),
                "CLINICA_TRANSCRIPTION_API_KEY": get(config, "Transcription", "ApiKey"),
                "CLINICA_TRANSCRIPTION_MODEL": get(config, "Transcription", "Model") or "gpt-transcribe",
                "CLINICA_TRANSCRIPTION_BASE_URL": get(config, "Transcription", "BaseUrl") or "https://api.openai.com/v1",
                "CLINICA_TRANSCRIPTION_PROVIDER": get(config, "Transcription", "Provider") or "OpenAI",
            })
            if not result["CLINICA_CODEX_TIMEOUT_SECONDS"].isdigit() or not 30 <= int(result["CLINICA_CODEX_TIMEOUT_SECONDS"]) <= 3600:
                raise ConfigurationError("Codex.TimeoutSeconds deve estar entre 30 e 3600.")
            if result["CLINICA_TRANSCRIPTION_PROVIDER"] not in ("OpenAI", "Queue"):
                raise ConfigurationError("Transcription.Provider deve ser OpenAI ou Queue.")

    return result


def create_private_directory(path):
    path = Path(os.path.abspath(path))
    for candidate in [path, *path.parents]:
        if candidate.is_symlink() or (candidate.exists() and getattr(candidate.lstat(), "st_file_attributes", 0) & getattr(stat, "FILE_ATTRIBUTE_REPARSE_POINT", 0)):
            raise ConfigurationError("Links nao sao permitidos no diretorio privado.")
    if path.exists() and not path.is_dir():
        raise ConfigurationError("Um arquivo ocupa o lugar de um diretorio privado.")
    missing = []
    current = path
    while not current.exists():
        missing.append(current)
        current = current.parent
    for directory in reversed(missing):
        # Windows ACL is applied before any file is written; avoid Python's
        # special mkdir(0700) DACL conflicting with the explicit owner update.
        directory.mkdir(mode=0o777 if os.name == "nt" else 0o700)
        if os.name == "nt":
            windows_access(directory, protect=True)
    if os.name == "nt":
        windows_access(path)
    return path


def prepare_application_directories(root):
    for app in DB_KEYS:
        create_private_directory(root / "apps" / app)


def write_new_json(path, document):
    path = Path(os.path.abspath(path))
    repository = Path(__file__).resolve().parents[2]
    if path.resolve().is_relative_to(repository):
        raise ConfigurationError("Arquivo real de credenciais deve ficar fora do repositorio.")
    for parent in path.parents:
        if parent.exists():
            info = parent.lstat()
            if stat.S_ISLNK(info.st_mode) or getattr(info, "st_file_attributes", 0) & getattr(stat, "FILE_ATTRIBUTE_REPARSE_POINT", 0):
                raise ConfigurationError("Links nao sao permitidos no destino privado.")
    create_private_directory(path.parent)
    if os.name != "nt":
        for parent in [path.parent, *path.parent.parents]:
            info = parent.lstat()
            owners = (os.geteuid(),) if parent == path.parent else (0, os.geteuid())
            if stat.S_ISLNK(info.st_mode) or info.st_uid not in owners or info.st_mode & 0o022:
                raise ConfigurationError("Destino privado inseguro; criacao recusada.")
        if path.parent.stat().st_mode & 0o077:
            raise ConfigurationError("Pasta de destino deve ser privada (0700).")
    descriptor = os.open(path, os.O_WRONLY | os.O_CREAT | os.O_EXCL | getattr(os, "O_NOFOLLOW", 0), 0o600)
    with os.fdopen(descriptor, "w", encoding="utf-8", newline="\n") as output:
        json.dump(document, output, indent=2, ensure_ascii=True)
        output.write("\n")
    if os.name == "nt":
        windows_access(path, protect=True)


def import_containers():
    projects = {"playsis-shared", *("playsis-" + name for name in APPS)}
    ids = []
    for project in sorted(projects):
        command = subprocess.run(["docker", "ps", "-q", "--filter", "label=com.docker.compose.project=" + project],
                                 check=True, capture_output=True, text=True)
        ids.extend(command.stdout.split())
    if not ids:
        raise ConfigurationError("Nenhum container em execucao para importar.")
    command = subprocess.run(["docker", "inspect", *ids], check=True, capture_output=True, text=True)
    services = {}
    for container in json.loads(command.stdout):
        labels = container.get("Config", {}).get("Labels") or {}
        if labels.get("com.docker.compose.project") not in projects:
            continue
        name = labels.get("com.docker.compose.service")
        values = dict(item.split("=", 1) for item in container["Config"].get("Env", []) if "=" in item)
        entry = (values, container.get("Mounts", []))
        if name in services and services[name] != entry:
            raise ConfigurationError("Replicas possuem configuracoes divergentes; reconcilie antes da importacao.")
        services[name] = entry
    return services


def from_containers(template, services):
    document = copy.deepcopy(template)
    shared = document["Shared"]
    def env(service):
        return services.get(service, ({}, []))[0]
    shared["SqlServer"]["AdminPassword"] = env("sqlserver").get("MSSQL_SA_PASSWORD") or env("sqlserver").get("SA_PASSWORD", "")
    shared["RabbitMq"]["UserName"] = env("rabbitmq").get("RABBITMQ_DEFAULT_USER", "")
    shared["RabbitMq"]["Password"] = env("rabbitmq").get("RABBITMQ_DEFAULT_PASS", "")
    shared["RabbitMq"]["BrokerUrl"] = env("memorias-media-renderer").get("CELERY_BROKER_URL", "")
    grafana = env("yeshua-observability") or env("yeshua-telemetry")
    shared["Grafana"].update(UserName=grafana.get("GF_SECURITY_ADMIN_USER", ""), Password=grafana.get("GF_SECURITY_ADMIN_PASSWORD", ""))
    ops = env("operational-intelligence") or env("operational-intelligence-api")
    shared["OperationalIntelligence"]["ConnectionString"] = ops.get("ConnectionStrings__OperationalIntelligence", "")
    for name in [*DB_KEYS, "OperationalIntelligence"]:
        shared["OperationalIntelligence"]["DatabaseQueries"][name] = ops.get("Mcp__DatabaseQuery__Connections__" + ("ApsAdm" if name == "APS.ADM" else name), "")
    jwt, module = set(), set()
    for target, app in APPS.items():
        api = env(target + "-api")
        document["Apps"][app]["MyConfig"] = {mode + "ConectionString": api.get("MYCONFIG__" + mode.upper() + "CONECTIONSTRING", "") for mode in ("Read", "Write")}
        if api.get("JwtSettings__SecretKey"):
            jwt.add(api["JwtSettings__SecretKey"])
        if api.get("YeshuaModules__Authentication__SharedKey"):
            module.add(api["YeshuaModules__Authentication__SharedKey"])
    if len(jwt) > 1 or len(module) > 1:
        raise ConfigurationError("Chaves de assinatura divergem entre containers; importacao exige reconciliacao explicita.")
    shared["Jwt"]["SecretKey"] = next(iter(jwt), "")
    shared["ModuleAuthentication"]["SharedKey"] = next(iter(module), "")
    shared["CentralAuthorization"]["ConnectionString"] = env("central-api").get("MYCONFIG__WRITECONECTIONSTRING", "")
    document["Apps"]["Clinica"]["Upload"]["SigningKey"] = env("clinica-api").get("UploadTokens__SigningKey", "")
    for mount in services.get("memorias-api", ({}, []))[1]:
        if mount.get("Destination") == "/memorias-secrets":
            document["Apps"]["Memorias"]["PrivateRoot"] = mount["Source"]
    return document


def from_development_source(template):
    """One-time extraction from the pre-cleanup commit, never a runtime fallback."""
    repository = Path(__file__).resolve().parents[2]
    document = copy.deepcopy(template)
    def original(path, json_value=True):
        result = subprocess.run(["git", "-C", str(repository), "show", "HEAD:" + path],
                                capture_output=True, text=True, encoding="utf-8")
        if result.returncode:
            return {} if json_value else ""
        return json.loads(result.stdout.lstrip("\ufeff")) if json_value else result.stdout
    jwt = set()
    for app in DB_KEYS:
        studio = "AppClinicas" if app == "Clinica" else app
        settings = original("src/Studio/Yeshua.Studio." + studio + "/appsettings.json")
        config = settings.get("MyConfig", {})
        document["Apps"][app]["MyConfig"] = {key: config.get(key, "") for key in ("ReadConectionString", "WriteConectionString")}
        if app == "Central":
            document["Shared"]["CentralAuthorization"]["ConnectionString"] = config.get("CentralAuthorizationConectionString") or config.get("WriteConectionString", "")
        api = original("src/CQRS/Infrastructure/Yeshua." + app + ".CQRS.Infrastructure.Api/appsettings.json")
        secret = api.get("JwtSettings", {}).get("SecretKey")
        if secret:
            jwt.add(secret)
        if app == "APS.ADM":
            rabbit = api.get("RabbitMq", {})
            document["Shared"]["RabbitMq"].update(UserName=rabbit.get("UserName", ""), Password=rabbit.get("Password", ""))
        for profile in ("Smoke", "Seed"):
            test = original("tests/CQRS/Yeshua." + app + ".CQRS.Tests.Integration.Api." + profile + "/appsettings.json")
            settings = test.get("TestSettings", {})
            if settings.get("Login") or settings.get("Password"):
                document["Apps"][app].setdefault("Tests", {})[profile] = settings
    if len(jwt) > 1:
        raise ConfigurationError("JWT diverge entre fontes locais; configure explicitamente.")
    document["Shared"]["Jwt"]["SecretKey"] = next(iter(jwt), "")
    document["Shared"]["ModuleAuthentication"]["SharedKey"] = os.environ.get("YESHUA_MODULE_SHARED_KEY", "")
    helper = original("src/CQRS/Application/Yeshua.Clinica.CQRS.Application.Command/Receivers/Custon/UseCases/FileUpload/Infra/UploadTokenHelper.cs", False)
    signing = re.search(r'private const string Secret = "([^"\\]*)";', helper)
    if signing:
        document["Apps"]["Clinica"]["Upload"]["SigningKey"] = signing.group(1)
    return document


def validate_initial_configuration(path):
    if path.resolve().is_relative_to(Path(__file__).resolve().parents[2]):
        raise ConfigurationError("Arquivo real de credenciais deve ficar fora do repositorio.")
    document = read_json(path)
    environment(document, path.parent, "all")
    prepare_application_directories(path.parent)


@contextmanager
def configuration_terminal():
    try:
        # stdin can contain the setup script itself (curl | bash).
        with open("/dev/tty", "r", encoding="utf-8") as reader, \
                open("/dev/tty", "w", encoding="utf-8", buffering=1) as writer:
            if not reader.isatty() or not writer.isatty():
                raise ConfigurationError("Preparacao das credenciais exige terminal interativo privado.")
            yield reader, writer
    except OSError:
        raise ConfigurationError("Sem terminal interativo privado. Prepare o arquivo e execute o mesmo setup novamente.") from None
    except KeyboardInterrupt:
        raise ConfigurationError("Preparacao das credenciais cancelada; nenhum servico foi iniciado nesta etapa.") from None


def wait_for_configuration(path):
    if path.resolve().is_relative_to(Path(__file__).resolve().parents[2]):
        raise ConfigurationError("Arquivo real de credenciais deve ficar fora do repositorio.")
    with ExitStack() as stack:
        terminal = None
        while True:
            try:
                if not path.exists() and not path.is_symlink():
                    template = json.loads(Path(__file__).with_name("credentials.example.json").read_text(encoding="utf-8"))
                    write_new_json(path, template)
                validate_initial_configuration(path)
                print("Configuracao privada pronta. Nenhuma credencial ou cofre existente foi substituido.")
                return
            except (ConfigurationError, OSError, ValueError, subprocess.SubprocessError) as error:
                message = str(error) if isinstance(error, ConfigurationError) else "Nao foi possivel preparar a configuracao privada; conteudo omitido."
            if terminal is None:
                terminal = stack.enter_context(configuration_terminal())
            reader, writer = terminal
            writer.write("\n==== Arquivo de credenciais antes da instalacao ====\n")
            writer.write(message + "\n")
            writer.write("Destino no servidor: " + str(path) + "\n")
            writer.write("Em outra sessao SSH/SFTP, reponha o arquivo preservado ou complete o exemplo nesse destino.\n")
            writer.write("Pasta administrativa 0700, arquivo 0600, ambos do usuario que executa o setup.\n")
            writer.write("Reponha tambem os diretorios privados explicitamente configurados, se houver.\n")
            writer.write("Nao cole JSON, senhas ou chaves neste terminal. Nenhum servico foi iniciado nesta etapa.\n")
            while True:
                writer.write("Digite PRONTO para validar novamente ou CANCELAR para sair: ")
                writer.flush()
                answer = reader.readline(128)
                if not answer or answer.strip() == "CANCELAR" or len(answer) == 128:
                    raise ConfigurationError("Preparacao das credenciais cancelada; nenhum servico foi iniciado nesta etapa.")
                if answer.strip() == "PRONTO":
                    break
                writer.write("Confirmacao nao reconhecida; nao informe segredos aqui.\n")


def main():
    parser = argparse.ArgumentParser(description="Configuracao privada Yeshua; validate/init nao imprimem valores.")
    parser.add_argument("action", choices=["validate", "export", "init"])
    parser.add_argument("--file", default=os.environ.get("YESHUA_DEPLOY_SECRETS_FILE", DEFAULT_FILE))
    parser.add_argument("--target", default="all", choices=[*APPS, "shared", "all", "gateway"])
    parser.add_argument("--include-shared", action="store_true")
    parser.add_argument("--from-running-containers", action="store_true")
    parser.add_argument("--from-development-source", action="store_true")
    parser.add_argument("--test-profile", choices=["Smoke", "Seed"])
    parser.add_argument("--wait", action="store_true", help="init: aguarda preparo do arquivo em terminal privado, sem ler segredos do stdin.")
    args = parser.parse_args()
    try:
        if args.wait and (args.action != "init" or args.from_running_containers or args.from_development_source
                          or args.test_profile or args.target != "all" or args.include_shared):
            raise ConfigurationError("--wait e exclusivo de init para todos os aplicativos, sem importacao.")
        path = Path(os.path.abspath(args.file))
        if args.action == "init":
            if args.wait:
                wait_for_configuration(path)
                return 0
            if path.exists() or path.is_symlink():
                if args.from_running_containers or args.from_development_source:
                    raise ConfigurationError("Arquivo ja existe; importacao nao pode sobrescreve-lo.")
                validate_initial_configuration(path)
                print("Configuracao existente validada e reutilizada. Nenhuma credencial ou cofre foi substituido.")
                return 0
            template = json.loads(Path(__file__).with_name("credentials.example.json").read_text(encoding="utf-8"))
            if args.from_development_source:
                if args.from_running_containers:
                    raise ConfigurationError("Escolha apenas uma origem para importar.")
                template = from_development_source(template)
            if args.from_running_containers:
                services = import_containers()
                template = from_containers(template, services)
                memory = services.get("memorias-api", ({}, []))[0]
                youtube = {key: memory.get("MemoriasYouTube__" + key, "") for key in ("ClientId", "ClientSecret", "EncryptionKey")}
                for key in ("RedirectUri", "ConfigurationAdminTenantId", "ConfigurationAdminUserId"):
                    if memory.get("MemoriasYouTube__" + key):
                        youtube[key] = memory["MemoriasYouTube__" + key]
                if any(youtube.values()):
                    write_new_json(path.parent / "apps" / "Memorias" / "integracoes" / "youtube" / "bootstrap.json", youtube)
                agent = services.get("operational-intelligence", services.get("operational-intelligence-agent", ({}, [])))[0]
                if any(agent.get(key) for key in ("OPENAI_API_KEY", "ANTHROPIC_API_KEY", "McpTunnel__Id", "McpTunnel__ApiKey")):
                    write_new_json(path.parent / "shared" / "OperationalAgent" / "integracoes" / "providers.json",
                                   {"OpenAI": {"ApiKey": agent.get("OPENAI_API_KEY", "")},
                                    "Anthropic": {"ApiKey": agent.get("ANTHROPIC_API_KEY", "")},
                                    "McpTunnel": {"Id": agent.get("McpTunnel__Id", ""), "ApiKey": agent.get("McpTunnel__ApiKey", "")}})
            write_new_json(path, template)
            prepare_application_directories(path.parent)
            print("Arquivo privado criado. Complete campos ausentes e execute validate antes de publicar.")
            return 0
        document = read_json(path)
        if args.test_profile:
            if args.target not in APPS:
                raise ConfigurationError("Selecione um aplicativo para o perfil de testes.")
            keys = ("Apps", APPS[args.target], "Tests", args.test_profile)
            values = {"TESTSETTINGS__" + key.upper(): get(document, *keys, key) for key in ("Login", "Password", "BaseUrl", "LoginPath")}
            timeout = document.get("Apps", {}).get(APPS[args.target], {}).get("Tests", {}).get(args.test_profile, {}).get("TimeoutSeconds", 30)
            if type(timeout) not in (int, str) or not str(timeout).isdigit() or int(timeout) < 1:
                raise ConfigurationError("Tests.TimeoutSeconds deve ser inteiro positivo.")
            values["TESTSETTINGS__TIMEOUTSECONDS"] = str(timeout)
            required(values["TESTSETTINGS__LOGIN"], "Tests.Login")
            required(values["TESTSETTINGS__PASSWORD"], "Tests.Password")
        else:
            values = environment(document, path.parent, args.target, args.include_shared)
        if args.action == "export":
            for key, value in values.items():
                print(key + "\t" + base64.b64encode(value.encode("utf-8")).decode("ascii"))
        else:
            print("Configuracao privada valida para " + args.target + ". Nenhum segredo exibido.")
        return 0
    except (ConfigurationError, OSError, ValueError, subprocess.SubprocessError) as error:
        message = str(error) if isinstance(error, ConfigurationError) else "Nao foi possivel ler/criar a configuracao privada; conteudo omitido."
        print(message, file=sys.stderr)
        return 1


if __name__ == "__main__":
    sys.exit(main())
