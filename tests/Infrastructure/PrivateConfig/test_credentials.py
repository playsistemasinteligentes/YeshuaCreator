import copy
from contextlib import redirect_stderr, redirect_stdout
import importlib.util
import io
import json
import os
from pathlib import Path
import tempfile
import unittest
from unittest.mock import patch

ROOT = Path(__file__).resolve().parents[3]
spec = importlib.util.spec_from_file_location("credentials", ROOT / "infra/private/credentials.py")
credentials = importlib.util.module_from_spec(spec)
spec.loader.exec_module(credentials)


def configured():
    document = json.loads((ROOT / "infra/private/credentials.example.json").read_text())
    def fill(value):
        if isinstance(value, dict):
            return {key: fill(item) for key, item in value.items()}
        return "fixture-'\"$#;\\!= " + "x" * 40 if value == "" else value
    return fill(document)


class CredentialsTests(unittest.TestCase):
    def test_all_consumers_and_independent_connections(self):
        document = configured()
        document["Apps"]["Memorias"]["MyConfig"].update(ReadConectionString="read-memory", WriteConectionString="write-memory")
        result = credentials.exports(document, Path("/private/production"), "all")
        self.assertEqual("read-memory", result["YESHUA_SQL_MEMORIAS_READ"])
        self.assertEqual("write-memory", result["YESHUA_SQL_MEMORIAS_WRITE"])
        self.assertNotIn("PATH", result)
        self.assertEqual("", result["YESHUA_MEMORIAS_YOUTUBE_CLIENT_SECRET"])

    def test_missing_key_cannot_come_from_inherited_environment(self):
        document = configured()
        document["Shared"]["Jwt"]["SecretKey"] = ""
        with patch.dict(os.environ, YESHUA_JWT_SECRET="inherited-" + "x" * 40):
            with self.assertRaises(credentials.ConfigurationError):
                credentials.exports(document, Path("/private"), "central")

    def test_all_checks_later_apps_before_deploy(self):
        document = configured()
        document["Apps"]["Memorias"]["MyConfig"]["ReadConectionString"] = ""
        with self.assertRaises(credentials.ConfigurationError):
            credentials.exports(document, Path("/private"), "all")
        credentials.exports(document, Path("/private"), "central")

    def test_optional_providers_do_not_block_environment(self):
        result = credentials.environment(configured(), Path("/path-that-does-not-exist"), "shared")
        self.assertEqual("", result["OPENAI_API_KEY"])
        self.assertEqual("", result["ANTHROPIC_API_KEY"])
        self.assertEqual("", result["YESHUA_MCP_TUNNEL_ID"])
        self.assertEqual("", result["YESHUA_MCP_TUNNEL_API_KEY"])

    def test_tunnel_configuration_uses_private_provider_file_only_for_shared(self):
        with tempfile.TemporaryDirectory(dir=Path.home(), prefix=".yeshua-config-test-") as directory:
            root = Path(directory)
            providers = root / "shared/OperationalAgent/integracoes/providers.json"
            credentials.write_new_json(providers, {"McpTunnel": {"Id": "tunnel_fixture", "ApiKey": "fixture-tunnel-key"}})
            result = credentials.environment(configured(), root, "shared")
            self.assertEqual("tunnel_fixture", result["YESHUA_MCP_TUNNEL_ID"])
            self.assertEqual("fixture-tunnel-key", result["YESHUA_MCP_TUNNEL_API_KEY"])
            self.assertEqual("", credentials.environment(configured(), root, "central")["YESHUA_MCP_TUNNEL_API_KEY"])

    def test_partial_tunnel_configuration_is_rejected_without_exposing_key(self):
        with tempfile.TemporaryDirectory(dir=Path.home(), prefix=".yeshua-config-test-") as directory:
            root = Path(directory)
            providers = root / "shared/OperationalAgent/integracoes/providers.json"
            credentials.write_new_json(providers, {"McpTunnel": {"ApiKey": "do-not-display"}})
            with self.assertRaises(credentials.ConfigurationError) as error:
                credentials.environment(configured(), root, "shared")
            self.assertNotIn("do-not-display", str(error.exception))

    def test_import_recognizes_unified_operational_service_and_renamed_observability(self):
        template = json.loads((ROOT / "infra/private/credentials.example.json").read_text())
        services = {
            "yeshua-observability": ({"GF_SECURITY_ADMIN_USER": "fixture-user", "GF_SECURITY_ADMIN_PASSWORD": "fixture-password"}, []),
            "operational-intelligence": ({"ConnectionStrings__OperationalIntelligence": "fixture-connection",
                "Mcp__DatabaseQuery__Connections__Memorias": "fixture-read-only"}, []),
        }
        result = credentials.from_containers(template, services)
        self.assertEqual("fixture-user", result["Shared"]["Grafana"]["UserName"])
        self.assertEqual("fixture-connection", result["Shared"]["OperationalIntelligence"]["ConnectionString"])
        self.assertEqual("fixture-read-only", result["Shared"]["OperationalIntelligence"]["DatabaseQueries"]["Memorias"])

    def test_clinica_executor_uses_app_owned_private_configuration(self):
        document = configured()
        config = {"ProcessingScope": "test", "Codex": {"Model": "configured-codex", "TimeoutSeconds": 600},
                  "Transcription": {"ApiKey": "fixture-audio-key", "Model": "configured-audio"}}
        document["Apps"]["Clinica"].update(config)
        with patch.object(Path, "exists", return_value=False), \
             patch.object(credentials, "read_json", side_effect=AssertionError("No separate Clinica provider file")):
            result = credentials.environment(document, Path("/private"), "shared")
            self.assertEqual("fixture-audio-key", result["CLINICA_TRANSCRIPTION_API_KEY"])
            self.assertEqual("configured-codex", result["CLINICA_CODEX_MODEL"])
            self.assertEqual("test", result["CLINICA_PROCESSING_SCOPE"])
            self.assertEqual("OpenAI", result["CLINICA_TRANSCRIPTION_PROVIDER"])
            unselected = credentials.environment(document, Path("/private"), "central")
            self.assertEqual("", unselected["CLINICA_TRANSCRIPTION_API_KEY"])

    def test_clinica_executor_does_not_inherit_provider_secret(self):
        document = configured()
        document["Apps"]["Clinica"]["Transcription"]["ApiKey"] = ""
        with patch.dict(os.environ, CLINICA_TRANSCRIPTION_API_KEY="inherited-secret"):
            result = credentials.environment(document, Path("/path-that-does-not-exist"), "shared")
        self.assertEqual("", result["CLINICA_TRANSCRIPTION_API_KEY"])

    def test_clinica_can_select_queue_without_changing_the_private_secret_source(self):
        document = configured()
        document["Apps"]["Clinica"]["Transcription"].update(Provider="Queue", ApiKey="fixture-key")
        result = credentials.environment(document, Path("/private"), "clinica")
        self.assertEqual("Queue", result["CLINICA_TRANSCRIPTION_PROVIDER"])
        self.assertEqual("fixture-key", result["CLINICA_TRANSCRIPTION_API_KEY"])

    def test_clinica_rejects_unknown_delivery_provider(self):
        document = configured()
        document["Apps"]["Clinica"]["Transcription"]["Provider"] = "invalid"
        with self.assertRaises(credentials.ConfigurationError):
            credentials.environment(document, Path("/private"), "clinica")

    def test_clinica_general_credentials_are_authoritative_even_when_old_file_exists(self):
        document = configured()
        document["Apps"]["Clinica"]["Transcription"]["ApiKey"] = "main-file-key"
        with patch.object(Path, "exists", lambda path: path.name == "codex-executor.json"), \
             patch.object(credentials, "read_json", side_effect=AssertionError("Obsolete provider must not be read")):
            result = credentials.environment(document, Path("/private"), "clinica")
        self.assertEqual("main-file-key", result["CLINICA_TRANSCRIPTION_API_KEY"])

    def test_clinica_codex_summary_is_disabled_by_default_and_explicitly_enabled(self):
        document = configured()
        result = credentials.environment(document, Path("/private"), "shared")
        self.assertEqual("false", result["CLINICA_CODEX_EXECUTOR_ENABLED"])
        document["Apps"]["Clinica"]["Codex"]["Enabled"] = True
        result = credentials.environment(document, Path("/private"), "shared")
        self.assertEqual("true", result["CLINICA_CODEX_EXECUTOR_ENABLED"])
        document["Apps"]["Clinica"]["Codex"]["Enabled"] = "true"
        with self.assertRaises(credentials.ConfigurationError):
            credentials.environment(document, Path("/private"), "shared")

    def test_schema_types_and_control_characters(self):
        for invalid in [None, False, ["a"], "value\n", "value\0"]:
            document = configured()
            document["Shared"]["Jwt"]["SecretKey"] = invalid
            with self.assertRaises(credentials.ConfigurationError):
                credentials.exports(document, Path("/private"), "central")

    def test_duplicate_keys_are_rejected_without_values(self):
        with self.assertRaises(credentials.ConfigurationError) as error:
            json.loads('{"a":"DO_NOT_DISPLAY", "a":"value"}', object_pairs_hook=credentials.unique_object)
        self.assertNotIn("DO_NOT_DISPLAY", str(error.exception))

    def test_empty_example_is_not_deployable(self):
        example = json.loads((ROOT / "infra/private/credentials.example.json").read_text())
        with self.assertRaises(credentials.ConfigurationError):
            credentials.exports(example, Path("/private"), "all")

    def test_gateway_needs_shared_configuration_not_app_credentials(self):
        document = configured()
        document["Apps"] = {}
        document["Shared"]["Jwt"]["SecretKey"] = "not-used-by-gateway"
        credentials.exports(document, Path("/private"), "gateway")
        document["Shared"]["SqlServer"]["AdminPassword"] = ""
        with self.assertRaises(credentials.ConfigurationError):
            credentials.exports(document, Path("/private"), "gateway")

    def test_existing_vault_is_not_hidden_by_an_empty_new_directory(self):
        with tempfile.TemporaryDirectory(dir=Path.home(), prefix=".yeshua-config-test-") as directory:
            root = Path(directory)
            legacy = root / "old-vault"
            legacy.mkdir()
            (legacy / "fixture.bin").write_bytes(b"fixture")
            (root / "apps" / "Memorias").mkdir(parents=True)
            with patch.object(credentials, "LEGACY_MEMORIAS_ROOT", legacy):
                with self.assertRaises(credentials.ConfigurationError):
                    credentials.environment(configured(), root, "memorias")
                document = configured()
                document["Apps"]["Memorias"]["PrivateRoot"] = str(legacy)
                result = credentials.environment(document, root, "memorias")
                self.assertEqual(str(legacy), result["YESHUA_MEMORIAS_PRIVATE_ROOT"])

    def test_youtube_bootstrap_is_app_owned_and_can_be_partial(self):
        with tempfile.TemporaryDirectory(dir=Path.home(), prefix=".yeshua-config-test-") as directory:
            root = Path(directory)
            bootstrap = root / "apps/Memorias/integracoes/youtube/bootstrap.json"
            credentials.write_new_json(bootstrap, {"ClientSecret": "fixture-secret", "ConfigurationAdminTenantId": 10})
            with patch.object(credentials, "LEGACY_MEMORIAS_ROOT", root / "absent"):
                result = credentials.environment(configured(), root, "memorias")
            self.assertEqual("fixture-secret", result["YESHUA_MEMORIAS_YOUTUBE_CLIENT_SECRET"])
            self.assertEqual("", result["YESHUA_MEMORIAS_YOUTUBE_CLIENT_ID"])
            self.assertEqual("10", result["YESHUA_MEMORIAS_CONFIG_ADMIN_TENANT_ID"])
            self.assertEqual("", credentials.environment(configured(), root, "central")["YESHUA_MEMORIAS_YOUTUBE_CLIENT_SECRET"])

    def test_invalid_youtube_protection_key_is_rejected_without_replacement(self):
        with tempfile.TemporaryDirectory(dir=Path.home(), prefix=".yeshua-config-test-") as directory:
            root = Path(directory)
            bootstrap = root / "apps/Memorias/integracoes/youtube/bootstrap.json"
            credentials.write_new_json(bootstrap, {"EncryptionKey": "fixture-not-a-protection-key"})
            before = bootstrap.read_bytes()
            with self.assertRaises(credentials.ConfigurationError):
                credentials.environment(configured(), root, "memorias")
            self.assertEqual(before, bootstrap.read_bytes())

    def test_read_is_non_mutating_and_existing_file_is_never_overwritten(self):
        with tempfile.TemporaryDirectory(dir=Path.home(), prefix=".yeshua-config-test-") as directory:
            path = Path(directory) / "private" / "credentials.json"
            credentials.write_new_json(path, configured())
            before = path.read_bytes()
            with patch.object(credentials, "validate_access", return_value=path):
                document = credentials.read_json(path)
                credentials.exports(document, path.parent, "all")
            self.assertEqual(before, path.read_bytes())
            with self.assertRaises(FileExistsError):
                credentials.write_new_json(path, {})
            self.assertEqual(before, path.read_bytes())

    @unittest.skipUnless(os.name == "nt", "Windows ACL test")
    def test_real_windows_acl(self):
        with tempfile.TemporaryDirectory(dir=Path.home(), prefix=".yeshua-config-test-") as directory:
            path = Path(directory) / "restricted" / "credentials.json"
            credentials.write_new_json(path, configured())
            self.assertEqual(1, credentials.read_json(path)["SchemaVersion"])

    def test_import_preserves_values_and_vault_mount_without_generating_keys(self):
        template = json.loads((ROOT / "infra/private/credentials.example.json").read_text())
        services = {
            "central-api": ({"JwtSettings__SecretKey": "jwt-" + "x" * 40,
                            "MYCONFIG__READCONECTIONSTRING": "existing-read",
                            "MYCONFIG__WRITECONECTIONSTRING": "existing-write"}, []),
            "memorias-api": ({}, [{"Destination": "/memorias-secrets", "Source": "/existing/vault"}]),
        }
        document = credentials.from_containers(template, services)
        self.assertEqual("existing-read", document["Apps"]["Central"]["MyConfig"]["ReadConectionString"])
        self.assertEqual("/existing/vault", document["Apps"]["Memorias"]["PrivateRoot"])
        self.assertEqual("", document["Shared"]["ModuleAuthentication"]["SharedKey"])
        self.assertEqual("", template["Apps"]["Central"]["MyConfig"]["ReadConectionString"])

    def test_import_rejects_mismatching_existing_signing_keys(self):
        template = json.loads((ROOT / "infra/private/credentials.example.json").read_text())
        services = {"central-api": ({"JwtSettings__SecretKey": "first"}, []),
                    "fiscal-api": ({"JwtSettings__SecretKey": "second"}, [])}
        with self.assertRaises(credentials.ConfigurationError):
            credentials.from_containers(template, services)


class UnifiedInitializationTests(unittest.TestCase):
    def run_init(self, path, *options):
        stdout, stderr = io.StringIO(), io.StringIO()
        with patch.object(credentials.sys, "argv", ["credentials.py", "init", "--file", str(path), *options]):
            with redirect_stdout(stdout), redirect_stderr(stderr):
                result = credentials.main()
        return result, stdout.getvalue(), stderr.getvalue()

    def test_new_environment_stops_until_credentials_are_completed(self):
        with tempfile.TemporaryDirectory(dir=Path.home(), prefix=".yeshua-config-test-") as directory:
            path = Path(directory) / "private/credentials.json"
            with patch.object(credentials, "windows_access"):
                self.assertEqual(0, self.run_init(path)[0])
                before = path.read_bytes()
                example = json.loads((ROOT / "infra/private/credentials.example.json").read_text())
                self.assertEqual(example, credentials.read_json(path))
                self.assertEqual(1, self.run_init(path)[0])
                self.assertEqual(before, path.read_bytes())
                self.assertFalse((path.parent / "apps/Memorias/accounts").exists())

    def test_restored_environment_and_youtube_files_are_reused_unchanged(self):
        with tempfile.TemporaryDirectory(dir=Path.home(), prefix=".yeshua-config-test-") as directory:
            root = Path(directory) / "private"
            path = root / "credentials.json"
            with patch.object(credentials, "windows_access"):
                credentials.write_new_json(path, configured())
                youtube = root / "apps/Memorias/accounts/configuration/fixture-scope"
                youtube.mkdir(parents=True)
                (youtube / "key.bin").write_bytes(b"x" * 32)
                (youtube / "oauth.bin").write_bytes(b"fixture-ciphertext")
                token = root / "apps/Memorias/accounts/fixture-scope/tenants/10/connection-fixture.bin"
                token.parent.mkdir(parents=True)
                token.write_bytes(b"fixture-token")
                protected = [path, youtube / "key.bin", youtube / "oauth.bin", token]
                before = {item: item.read_bytes() for item in protected}
                for _ in range(2):
                    result, stdout, stderr = self.run_init(path)
                    self.assertEqual(0, result, stderr)
                    self.assertIn("reutilizada", stdout)
                self.assertEqual(before, {item: item.read_bytes() for item in protected})
                self.assertTrue((root / "apps/APS.ADM").is_dir())

    def test_import_cannot_replace_a_restored_configuration(self):
        with tempfile.TemporaryDirectory(dir=Path.home(), prefix=".yeshua-config-test-") as directory:
            path = Path(directory) / "private/credentials.json"
            with patch.object(credentials, "windows_access"):
                credentials.write_new_json(path, configured())
                before = path.read_bytes()
                with patch.object(credentials, "import_containers") as importer:
                    self.assertEqual(1, self.run_init(path, "--from-running-containers")[0])
                    importer.assert_not_called()
                self.assertEqual(before, path.read_bytes())

    def test_missing_explicit_youtube_directory_is_not_recreated(self):
        with tempfile.TemporaryDirectory(dir=Path.home(), prefix=".yeshua-config-test-") as directory:
            root = Path(directory)
            missing = root / "missing-youtube"
            document = configured()
            document["Apps"]["Memorias"]["PrivateRoot"] = str(missing)
            with self.assertRaises(credentials.ConfigurationError):
                credentials.exports(document, root, "memorias")
            self.assertFalse(missing.exists())

    def test_existing_file_cannot_be_replaced_by_a_runtime_directory(self):
        with tempfile.TemporaryDirectory(dir=Path.home(), prefix=".yeshua-config-test-") as directory:
            collision = Path(directory) / "Fiscal"
            collision.write_bytes(b"fixture-existing-data")
            with self.assertRaises(credentials.ConfigurationError):
                credentials.create_private_directory(collision)
            self.assertEqual(b"fixture-existing-data", collision.read_bytes())


if __name__ == "__main__":
    unittest.main()
