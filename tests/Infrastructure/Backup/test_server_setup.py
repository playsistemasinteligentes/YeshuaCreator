from contextlib import nullcontext
import base64
import copy
import importlib.util
import io
import json
import os
from pathlib import Path
import subprocess
import sys
import tempfile
import unittest
from unittest.mock import MagicMock, patch

ROOT = Path(__file__).resolve().parents[3]
spec = importlib.util.spec_from_file_location("server_setup_tests", ROOT / "infra/backups/setup.py")
s = importlib.util.module_from_spec(spec)
sys.modules[spec.name] = s
spec.loader.exec_module(s)
recovery = s.load("recovery")
enrollment = s.load("enrollment")
MACHINE = "a" * 32
OLD = "b" * 32
PIN = "mcr.microsoft.com/mssql/server@sha256:" + "c" * 64
PUBLIC = "ssh-ed25519 " + base64.b64encode(b"\x00\x00\x00\x0bssh-ed25519\x00\x00\x00\x20" + bytes(range(32))).decode()


def directory(path, *, create=False):
    path = Path(path)
    if create:
        path.mkdir(parents=True, exist_ok=True)
    return path


class SetupSelectionTests(unittest.TestCase):
    def setUp(self):
        self.temp = tempfile.TemporaryDirectory()
        self.addCleanup(self.temp.cleanup)
        self.base = Path(self.temp.name)
        for target, value in (("BASE", self.base),):
            p = patch.object(s, target, value)
            p.start()
            self.addCleanup(p.stop)
        for name, value in (("private_directory", directory), ("machine_id", lambda: MACHINE)):
            p = patch.object(s.op, name, value)
            p.start()
            self.addCleanup(p.stop)
        p = patch.object(s.control, "private_json", s.op.read)
        p.start()
        self.addCleanup(p.stop)

    def test_choice_is_asked_once_and_survives_retry(self):
        with patch.object(s, "ask", return_value="restore") as ask:
            self.assertEqual("restore", s.choose("applications"))
            self.assertEqual("restore", s.choose("applications"))
        ask.assert_called_once()
        self.assertEqual(MACHINE, s.read_state("applications")["machine_id"])

    def test_changing_mode_or_reusing_another_hosts_state_is_rejected(self):
        s.choose("applications", "restore")
        with self.assertRaises(s.op.Error):
            s.choose("applications", "new")
        with patch.object(s.op, "machine_id", return_value=OLD), self.assertRaises(s.op.Error):
            s.read_state("applications")

    def test_storage_setup_is_not_a_second_step_on_the_application_host(self):
        s.choose("applications", "new")
        with self.assertRaisesRegex(s.op.Error, "different_machines"):
            s.choose("storage", "restore")
        self.assertEqual("new", s.read_state("applications")["mode"])

    def test_bad_role_is_not_a_path(self):
        for role in ("../root", "root", "applications;id"):
            with self.assertRaises(s.op.Error):
                s.state_path(role)

    def test_invalid_confirmation_reprompts_without_ending_setup(self):
        writer = io.StringIO()
        with patch.object(s, "terminal", return_value=nullcontext((io.StringIO("wrong\n2\n"), writer))):
            self.assertEqual("restore", s.ask("mode", {"2": "restore"}))
        self.assertIn("Tente novamente", writer.getvalue())

    def test_name_accepts_uppercase_and_reprompts_for_invalid_identifiers(self):
        writer = io.StringIO()
        with patch.object(s, "terminal", return_value=nullcontext((io.StringIO("invalid_name\n../prod\nYESHUA01\n"), writer))):
            self.assertEqual("yeshua01", s.ask(enrollment.SOURCE_NAME_PROMPT, validator=enrollment.source_name))
        self.assertEqual(2, writer.getvalue().count("Valor invalido"))

    def test_ip_and_port_retry_until_valid_and_preserve_cancel(self):
        for validator, answers, expected in (
                (enrollment.ipv4_address, "server\n999.1.2.3\n::1\n162.35.13.23\n", "162.35.13.23"),
                (enrollment.ssh_port, "ssh\n0\n65536\n22\n", 22)):
            with self.subTest(expected=expected), patch.object(s, "terminal", return_value=nullcontext((io.StringIO(answers), io.StringIO()))):
                self.assertEqual(expected, s.ask("value", validator=validator))
            with patch.object(s, "terminal", return_value=nullcontext((io.StringIO("invalid\nCANCELAR\n"), io.StringIO()))), \
                    self.assertRaisesRegex(s.op.Error, "setup_cancelled"):
                s.ask("value", validator=validator)

    def test_storage_preparation_retries_the_field_without_losing_valid_answers(self):
        reader = io.StringIO("bad\n162.35.13.23\nSIM\nbad-host\n69.164.247.138\nssh\n70000\n22\ninvalid_name\nYESHUA01\n")
        writer = io.StringIO()
        with patch.object(s, "PRIVATE", self.base / "credentials.json"), \
                patch.object(s, "terminal", side_effect=lambda: nullcontext((reader, writer))):
            result = enrollment.prepare_storage(s, "new")
            document = s.op.read(s.PRIVATE)
        self.assertEqual({"pair_now": True, "peer_host": "69.164.247.138", "peer_port": 22, "source_name": "yeshua01"}, result)
        self.assertEqual("162.35.13.23", document["Shared"]["Backup"]["Storage"]["Address"])
        self.assertEqual(1, writer.getvalue().count("Vincular agora"))
        self.assertEqual(2, writer.getvalue().count("Nome desta origem"))

    def test_source_name_limits_are_not_relaxed_by_normalization(self):
        self.assertEqual("prod01", enrollment.source_name("PROD01"))
        self.assertEqual("p" * 20, enrollment.source_name("P" * 20))
        for value in ("", "p" * 21, "01prod", "prod_01", "prod;id", "prod name", "memorias/01", "pr\u00f3d"):
            with self.subTest(value=value), self.assertRaises(ValueError):
                enrollment.source_name(value)

    def test_storage_retry_reuses_existing_private_configuration_and_saves_normalized_name(self):
        document = {"SchemaVersion": 1, "Shared": {"Backup": {
            "Storage": {"Schema": 1, "Address": "162.35.13.23", "Receivers": []},
            "Controller": {"Schema": 1, "MachineId": MACHINE, "MaxActiveCaptures": 2, "Sources": []}}}}
        reader, writer = io.StringIO("SIM\n69.164.247.138\n22\nPROD01\n"), io.StringIO()
        with patch.object(s, "PRIVATE", self.base / "credentials.json"), \
                patch.object(s, "terminal", side_effect=lambda: nullcontext((reader, writer))):
            s.op.write(s.PRIVATE, document)
            s.save({"schema": 1, "role": "storage", "mode": "new", "machine_id": MACHINE, "phase": "selected"})
            s.prepare("storage", "new")
            state = s.read_state("storage")
            with patch.object(s, "ask", side_effect=AssertionError("do not ask completed preparation again")):
                s.prepare("storage", "new")
            self.assertEqual(document, s.op.read(s.PRIVATE))
        self.assertEqual("prepared", state["phase"])
        self.assertEqual("prod01", state["source_name"])
        self.assertNotIn("publico desta Storage", writer.getvalue())

    def test_oversized_answer_is_discarded_in_full(self):
        writer = io.StringIO()
        with patch.object(s, "terminal", return_value=nullcontext((io.StringIO("x" * 4096 + "2\n2\n"), writer))):
            self.assertEqual("restore", s.ask("mode", {"2": "restore"}))
        self.assertIn("muito longa", writer.getvalue())

    def test_eof_and_cancel_do_not_confirm(self):
        for text in ("", "CANCELAR\n"):
            with patch.object(s, "terminal", return_value=nullcontext((io.StringIO(text), io.StringIO()))), self.assertRaises(s.op.Error):
                s.confirm("confirm")

    def test_restore_never_accepts_an_empty_repository_setting(self):
        with self.assertRaisesRegex(s.op.Error, "existing_repository"):
            s.operator_document({"SchemaVersion": 1, "Shared": {"Backup": {"Repository": ""}}})

    def test_finished_recovery_does_not_need_operator_kit_or_reapply_data(self):
        with patch.object(s.control, "private_json", side_effect=AssertionError("do not read kit")):
            result = recovery.run(s, {"phase": "completed"})
        self.assertEqual("recovery_already_completed", result["status"])

    def test_prepare_only_cannot_accidentally_enable_jobs(self):
        installer = s.load("install")
        for flags in ({"enable": True}, {"initialize": True}):
            with self.assertRaisesRegex(RuntimeError, "does_not_initialize"):
                installer.install(prepare_only=True, **flags)

    def test_prepare_only_branch_precedes_repository_and_online_initialization(self):
        source = (ROOT / "infra/backups/install.py").read_text()
        self.assertLess(source.index('if prepare_only:\n'), source.index('if role == "controller":'))
        self.assertIn('"repository_initialized": False', source)


class RecoveryContractTests(unittest.TestCase):
    def test_capture_records_sql_digest_uid_project_files_and_replicas(self):
        with tempfile.TemporaryDirectory() as folder:
            root = Path(folder)
            path = root / "infra/Shared/DockerCompose/docker-compose.yml"
            path.parent.mkdir(parents=True)
            path.write_text("services: {}")
            container = {"Id": "container-id", "Image": "image-id", "Config": {"Labels": {
                "com.docker.compose.project": "playsis-shared", "com.docker.compose.service": "sqlserver",
                "com.docker.compose.project.config_files": str(path)}}}
            def run(args, **kwargs):
                return "10001" if "exec" in args else json.dumps([PIN])
            with patch.object(s.op, "ROOT", root), patch.object(s.op, "machine_id", return_value=OLD), \
                    patch.object(s.op.sql, "run", side_effect=run):
                result = recovery.capture_contract(s.op, [container], {"revision": "a" * 40, "tracked_diff": False})
            self.assertTrue(result["automatic_recovery_ready"])
            self.assertEqual(10001, result["sql_process_uid"])
            self.assertEqual(PIN, result["projects"]["playsis-shared"]["services"]["sqlserver"]["image_digest"])

    def test_missing_registry_digest_does_not_advertise_automatic_restore(self):
        with patch.object(s.op, "machine_id", return_value=OLD):
            result = recovery.capture_contract(s.op, [], {"revision": "a" * 40, "tracked_diff": False})
        self.assertFalse(result["automatic_recovery_ready"])

    def test_missing_image_metadata_does_not_prevent_data_backup_or_guess_a_digest(self):
        with tempfile.TemporaryDirectory() as folder:
            root = Path(folder)
            container = {"Id": "id", "Image": "removed-image", "Config": {"Labels": {
                "com.docker.compose.project": "playsis-central", "com.docker.compose.service": "api",
                "com.docker.compose.project.config_files": str(root / "infra/central.yml")}}}
            with patch.object(s.op, "ROOT", root), patch.object(s.op.sql, "run", side_effect=s.op.Error("image_removed")), \
                    patch.object(s.op, "machine_id", return_value=OLD):
                result = recovery.capture_contract(s.op, [container], {"revision": "a" * 40, "tracked_diff": False})
        self.assertIsNone(result["projects"]["playsis-central"]["services"]["api"]["image_digest"])
        self.assertFalse(result["automatic_recovery_ready"])

    def test_restored_container_resolves_original_source_only_with_sealed_provenance(self):
        with tempfile.TemporaryDirectory() as folder:
            root = Path(folder)
            stage = root / "compose"
            stage.mkdir()
            path = stage / "playsis-shared.json"
            path.write_text('{"services": {}}')
            original = root / "infra/shared.yml"
            labels = {"com.docker.compose.project": "playsis-shared", "com.docker.compose.service": "sqlserver",
                      "com.docker.compose.project.config_files": str(path)}
            provenance = {"schema": 1, "machine_id": MACHINE, "source_revision": "a" * 40,
                          "projects": {"playsis-shared": {"files": ["infra/shared.yml"], "model_sha256": s.op.digest(path)}}}
            s.op.write(stage / "provenance.json", provenance)
            with patch.object(s.op, "RECOVERY_COMPOSE", stage), patch.object(s.op, "ROOT", root), \
                    patch.object(s.op, "private_directory", side_effect=directory), patch.object(s.op, "machine_id", return_value=MACHINE):
                self.assertEqual([original], s.op.compose_source_files({"Config": {"Labels": labels}}, revision="a" * 40))
                with self.assertRaisesRegex(s.op.Error, "provenance_changed"):
                    s.op.compose_source_files({"Config": {"Labels": labels}}, revision="b" * 40)
                sql = stage / "sql-only.json"
                sql.write_text('{"services": {"sqlserver": {}}}')
                provenance["sql_only_sha256"] = s.op.digest(sql)
                s.op.write(stage / "provenance.json", provenance)
                labels["com.docker.compose.project.config_files"] = str(sql)
                self.assertEqual([original], s.op.compose_source_files({"Config": {"Labels": labels}}))
                sql.write_text("tampered")
                with self.assertRaisesRegex(s.op.Error, "provenance_changed"):
                    s.op.compose_source_files({"Config": {"Labels": labels}})

    def test_contract_rejects_cross_machine_sql_and_mutated_metadata_before_writes(self):
        with tempfile.TemporaryDirectory() as folder:
            root = Path(folder)
            metadata = root / "metadata"
            metadata.mkdir()
            sql = root / "sql"
            catalog = sql / "root/YeshuaBackup/state/sql-catalog.json"
            catalog.parent.mkdir(parents=True)
            contract = {"schema": 1, "source_revision": "a" * 40, "source_machine": OLD, "sql_process_uid": 10001,
                        "projects": {"playsis-shared": {"files": ["infra/sql.yml"], "services": {"sqlserver": {"image_digest": PIN, "replicas": 1}}}}}
            s.op.write(metadata / "recovery-contract.json", contract)
            s.op.write(catalog, {"schema": 1, "sql_version": "16.0.1.0", "source_machine": OLD})
            with patch.object(recovery, "verified_download", side_effect=lambda _, v, kind, doc: root if kind == "files" else sql), \
                    patch.object(s.routine, "downloaded_path", return_value=metadata), \
                    patch.object(s.routine, "file_recovery_inventory", return_value=(None, {"source_machine": OLD}, [])), \
                    patch.object(s.control, "policy", return_value={"staging": "/root/YeshuaBackup"}), \
                    patch.object(s.op, "machine_id", return_value=MACHINE), patch.object(s, "save"):
                state = {}
                recovery.load_contract(s, state, {})
                self.assertIn("contract_sha256", state)
                changed = dict(contract, source_revision="e" * 40)
                s.op.write(metadata / "recovery-contract.json", changed)
                with self.assertRaisesRegex(s.op.Error, "metadata_changed"):
                    recovery.load_contract(s, state, {})
                s.op.write(metadata / "recovery-contract.json", contract)
                s.op.write(catalog, {"schema": 1, "sql_version": "16.0.1.0", "source_machine": "c" * 32})
                with self.assertRaisesRegex(s.op.Error, "identity_mismatch"):
                    recovery.load_contract(s, {}, {})

    def test_missing_contract_is_assisted_recovery_not_a_guess_at_latest(self):
        with tempfile.TemporaryDirectory() as folder, patch.object(recovery, "verified_download", return_value=Path(folder)), \
                patch.object(s.routine, "downloaded_path", return_value=Path(folder)), \
                patch.object(s.control, "policy", return_value={"staging": "/root/YeshuaBackup"}), \
                self.assertRaisesRegex(s.op.Error, "older_backup_requires_assisted"):
            recovery.load_contract(s, {}, {})

    def test_raw_sql_directory_is_never_reused_or_deleted(self):
        with tempfile.TemporaryDirectory() as folder:
            data = Path(folder)
            (data / "existing.mdf").write_text("keep")
            model = {"services": {"sqlserver": {}}, "networks": {}}
            with patch.object(s.op, "read", return_value={"playsis-shared": model}), patch.object(s.control, "policy", return_value={"sql_data": folder}), \
                    patch.object(s.op, "absolute", side_effect=Path), patch.object(s.op.sql, "run") as run, self.assertRaises(s.op.Error):
                recovery.start_isolated_sql(s, data, 10001)
            self.assertEqual("keep", (data / "existing.mdf").read_text())
            run.assert_not_called()

    def snapshot(self, kind, identifier, stamp, *, tags=None, host="yeshua-production"):
        return {"id": identifier * 64, "time": stamp, "hostname": host,
                "tags": tags or ["yeshua", "scope=yeshua-production", "kind=" + kind, "recovery=server-v1"]}

    def test_selection_requires_exact_profile_scope_and_sql_not_after_files(self):
        data = [self.snapshot("sql", "a", "2026-10-23T10:00:00Z"),
                self.snapshot("sql", "b", "2026-10-23T12:00:00Z"),
                self.snapshot("files", "c", "2026-10-23T11:00:00Z"),
                self.snapshot("files", "d", "2026-10-23T11:00:00Z", host="other"),
                self.snapshot("files", "e", "2026-10-23T11:00:00Z", tags=["yeshua", "scope=yeshua-production", "kind=files"])]
        with patch.object(s.op, "restic", return_value=json.dumps(data)), patch.object(s.control, "policy", return_value={"scope": "yeshua-production"}):
            points = recovery.recovery_points(s, {})
        self.assertEqual(1, len(points))
        self.assertEqual("a" * 64, points[0]["sql_snapshot"])
        self.assertEqual("c" * 64, points[0]["files_snapshot"])

    def test_clean_checkout_is_required_and_never_reset(self):
        with patch.object(s.op.sql, "run", return_value=" M user-file") as run, self.assertRaises(s.op.Error):
            recovery.checkout_source(s, "a" * 40)
        self.assertEqual(1, run.call_count)

    def test_exact_commit_is_checked_out_not_main(self):
        with patch.object(s.op.sql, "run", return_value="") as run:
            recovery.checkout_source(s, "a" * 40)
        self.assertIn(["git", "-C", str(s.op.APP_ROOT), "checkout", "--detach", "a" * 40], [x.args[0] for x in run.call_args_list])
        self.assertFalse(any("reset" in x.args[0] or "clean" in x.args[0] for x in run.call_args_list))

    def test_any_existing_container_blocks_automatic_restore(self):
        for value in ("existing-app", "stopped-container", "yeshua-sqlserver"):
            with patch.object(s.op.sql, "run", return_value=value), self.assertRaises(s.op.Error):
                recovery.ensure_only_recovery_host(s)
        with patch.object(s.op.sql, "run", return_value="yeshua-sqlserver"):
            recovery.ensure_only_recovery_host(s, sql_allowed=True)

    def test_sql_is_only_service_started_and_port_is_loopback(self):
        model = {"services": {"sqlserver": {"ports": [], "environment": {"PASSWORD": "$$raw"}}, "rabbitmq": {}, "api": {}}, "networks": {}}
        with tempfile.TemporaryDirectory() as folder, patch.object(s.control, "policy", return_value={"sql_data": str(Path(folder) / "data")}), \
                patch.object(s.op, "absolute", side_effect=Path), patch.object(recovery.os, "chown", create=True), \
                patch.object(s.op.sql, "run", return_value="yeshua-net") as run:
            stage = Path(folder)
            s.op.write(stage / "compose.json", {"playsis-shared": model})
            s.op.write(stage / "provenance.json", {})
            recovery.start_isolated_sql(s, stage, 10001)
            prepared = s.op.read(stage / "sql-only.json")
            self.assertEqual({"sqlserver"}, set(prepared["services"]))
            self.assertEqual("127.0.0.1", prepared["services"]["sqlserver"]["ports"][0]["host_ip"])
            self.assertEqual("$$raw", prepared["services"]["sqlserver"]["environment"]["PASSWORD"])
            self.assertEqual(s.op.digest(stage / "sql-only.json"), s.op.read(stage / "provenance.json")["sql_only_sha256"])
            self.assertEqual("sqlserver", run.call_args.args[0][-1])
            self.assertIn("--no-deps", run.call_args.args[0])

    def test_builds_only_captured_active_services_and_pins_external_images(self):
        with tempfile.TemporaryDirectory() as folder:
            root = Path(folder)
            contract = {"source_revision": "a" * 40, "projects": {"playsis-shared": {"files": ["infra/shared.yml"], "services": {
                "sqlserver": {"image_digest": PIN, "replicas": 1}, "api": {"image_digest": None, "replicas": 2}}}}}
            template = {"services": {"sqlserver": {"image": "sql:latest"}, "api": {"build": "./app", "environment": {"PASSWORD": "abc$$secret"}},
                                     "api-migration": {"build": "./migration"}}, "networks": {}}
            def run(args, **kwargs):
                if "config" in args:
                    return json.dumps(template)
                if "images" in args:
                    return "short-id"
                if "inspect" in args:
                    return "sha256:" + "d" * 64
                return ""
            with patch.object(s.op, "APP_ROOT", root), patch.object(s, "BASE", root), \
                    patch.object(s.op, "private_directory", side_effect=directory), patch.object(s.op, "absolute", side_effect=Path), \
                    patch.object(s.op.sql, "load_credentials", return_value=({}, "")), patch.object(s.op, "compose_environment", return_value={}), \
                    patch.object(s.op, "machine_id", return_value=MACHINE), \
                    patch.object(s.op.sql, "run", side_effect=run) as commands:
                stage = recovery.build_models(s, {}, contract)
            model = s.op.read(stage / "playsis-shared.json")
            self.assertEqual({"sqlserver", "api"}, set(model["services"]))
            self.assertEqual(PIN, model["services"]["sqlserver"]["image"])
            self.assertEqual(2, model["services"]["api"]["deploy"]["replicas"])
            self.assertEqual("no", model["services"]["api"]["restart"])
            self.assertEqual("abc$$secret", model["services"]["api"]["environment"]["PASSWORD"])
            self.assertEqual("abc$$secret", s.op.read(stage / "compose.json")["playsis-shared"]["services"]["api"]["environment"]["PASSWORD"])
            self.assertIn(["docker", "image", "inspect", "playsis-shared-api", "--format", "{{.Id}}"], [x.args[0] for x in commands.call_args_list])
            self.assertFalse(any("images" in call.args[0] for call in commands.call_args_list))
            self.assertFalse(any("api-migration" in call.args[0] or "run" in call.args[0] for call in commands.call_args_list))


class RecoveryPhaseTests(unittest.TestCase):
    def setUp(self):
        patcher = patch.object(s.op, "machine_id", return_value=MACHINE)
        patcher.start()
        self.addCleanup(patcher.stop)

    def environment(self, folder):
        base = Path(folder)
        context = MagicMock()
        context.op = s.op
        context.BASE = base
        context.PRIVATE = base / "credentials.json"
        context.OPERATOR = base / "operator.json"
        context.control.policy.return_value = {}
        context.control.private_json.return_value = {"Shared": {"Backup": {}}}
        context.operator_document.return_value = {"Shared": {"Backup": {}}}
        context.routine.restore_sql_chain.return_value = {"checkdb_passed": True}
        contract = {"source_revision": "a" * 40, "tracked_changes_not_captured": False}
        return context, contract, base

    def test_sql_failure_stops_before_service_release_and_preserves_partial_state(self):
        with tempfile.TemporaryDirectory() as folder:
            context, contract, base = self.environment(folder)
            value = {"phase": "sql_started", "compose_stage": str(base), "release_authorized": True}
            context.routine.restore_sql_chain.side_effect = s.op.Error("restore_failed")
            with patch.object(recovery, "load_contract", return_value=(contract, base, base, {"sql_version": "16.1"})), \
                    patch.object(recovery, "ensure_only_recovery_host"), patch.object(s.op, "private_directory", return_value=base), \
                    patch.object(s.op.sql, "load_credentials", return_value=({}, "secret")), \
                    patch.object(s.op.sql, "sql_inventory", return_value=({"product_version": "16.1"}, "client")), \
                    patch.object(recovery, "release_services") as release, self.assertRaises(s.op.Error):
                recovery.run(context, value)
            self.assertEqual("sql_restoring", value["phase"])
            release.assert_not_called()

    def test_interrupted_sql_is_not_overwritten_on_retry(self):
        with tempfile.TemporaryDirectory() as folder:
            context, contract, base = self.environment(folder)
            value = {"phase": "sql_restoring", "compose_stage": str(base)}
            with patch.object(recovery, "load_contract", return_value=(contract, base, base, {})), \
                    patch.object(s.op, "private_directory", return_value=base), self.assertRaisesRegex(s.op.Error, "partial_sql"):
                recovery.run(context, value)
            context.routine.restore_sql_chain.assert_not_called()

    def test_wrong_sql_version_is_rejected_before_any_restore(self):
        with tempfile.TemporaryDirectory() as folder:
            context, contract, base = self.environment(folder)
            value = {"phase": "sql_started", "compose_stage": str(base)}
            with patch.object(recovery, "load_contract", return_value=(contract, base, base, {"sql_version": "old"})), \
                    patch.object(recovery, "ensure_only_recovery_host"), patch.object(s.op, "private_directory", return_value=base), \
                    patch.object(s.op.sql, "load_credentials", return_value=({}, "secret")), \
                    patch.object(s.op.sql, "sql_inventory", return_value=({"product_version": "new"}, "client")), self.assertRaises(s.op.Error):
                recovery.run(context, value)
            context.routine.restore_sql_chain.assert_not_called()

    def test_explicit_release_authorization_is_required(self):
        with tempfile.TemporaryDirectory() as folder:
            context, contract, base = self.environment(folder)
            value = {"phase": "ready_to_release", "compose_stage": str(base), "release_authorized": False}
            with patch.object(recovery, "load_contract", return_value=(contract, base, base, {})), \
                    patch.object(s.op, "private_directory", return_value=base), patch.object(recovery, "release_services") as release, \
                    self.assertRaises(s.op.Error):
                recovery.run(context, value)
            release.assert_not_called()

    def test_positive_flow_restores_files_then_sql_then_access_before_release(self):
        with tempfile.TemporaryDirectory() as folder:
            context, contract, base = self.environment(folder)
            contract["sql_process_uid"] = 10001
            state = {"phase": "prepared", "release_authorized": True}
            order = []
            context.routine.restore_files.side_effect = lambda *args, **kwargs: order.append("files")
            context.routine.restore_sql_chain.side_effect = lambda *args, **kwargs: order.append("sql") or {"checkdb_passed": True}
            with patch.object(recovery, "load_contract", return_value=(contract, base, base, {"sql_version": "16.1"})), \
                    patch.object(recovery, "ensure_only_recovery_host"), patch.object(recovery, "checkout_source"), \
                    patch.object(recovery, "build_models", return_value=base), patch.object(recovery, "start_isolated_sql", side_effect=lambda *a: order.append("sql_start")), \
                    patch.object(recovery, "restore_access", side_effect=lambda *a: order.append("access")), \
                    patch.object(recovery, "release_services", side_effect=lambda *a: order.append("release")), \
                    patch.object(s.op, "private_directory", return_value=base), patch.object(s.op, "write"), \
                    patch.object(s.op.sql, "load_credentials", return_value=({}, "secret")), \
                    patch.object(s.op.sql, "sql_inventory", return_value=({"product_version": "16.1"}, "client")):
                result = recovery.run(context, state)
            self.assertEqual(["files", "sql_start", "sql", "access", "release"], order)
            self.assertEqual("completed", state["phase"])
            self.assertEqual("recovered_and_started", result["status"])
            self.assertFalse(result["functional_restore_proven"])

    def test_release_failure_is_not_reported_as_success_or_replayed(self):
        with tempfile.TemporaryDirectory() as folder:
            context, contract, base = self.environment(folder)
            value = {"phase": "ready_to_release", "compose_stage": str(base), "release_authorized": True}
            with patch.object(recovery, "load_contract", return_value=(contract, base, base, {})), \
                    patch.object(s.op, "private_directory", return_value=base), patch.object(recovery, "release_services", side_effect=s.op.Error("not_ready")), \
                    patch.object(recovery, "stop_recovered_services") as stop, \
                    self.assertRaises(s.op.Error):
                recovery.run(context, value)
            self.assertEqual("release_failed", value["phase"])
            stop.assert_called_once()


class PairingTransactionTests(unittest.TestCase):
    def context(self, folder):
        context = MagicMock()
        context.op = s.op
        context.PRIVATE = Path(folder) / "credentials.json"
        context.control.BASE = Path(folder) / "state"
        context.control.controller_lock.side_effect = lambda: nullcontext()
        context.load.return_value = MagicMock()
        document = {"Shared": {"Backup": {"Storage": {"Address": "192.0.2.25", "Receivers": []},
                                         "Controller": {"MachineId": MACHINE, "Sources": []}}}}
        context.control.private_json.side_effect = lambda path: document if path == context.PRIVATE else s.op.read(path)
        return context, document

    def test_offer_is_pending_and_never_breaks_existing_controller_sources(self):
        with tempfile.TemporaryDirectory() as folder:
            context, document = self.context(folder)
            path = Path(folder) / "ssh/id_ed25519"
            path.parent.mkdir()
            storage = MagicMock()
            storage.source_layout.return_value = ("yeshua-bk-prod", Path(folder) / "receiver", None)
            installer = MagicMock()
            context.load.side_effect = lambda name: installer if name == "install" else storage
            payload = {"name": "prod", "source_port": 22, "source_host_key": PUBLIC,
                       "source": {"machine_id": OLD, "scope": "yeshua-production", "public_key": PUBLIC, "backup_password": "x" * 32}}
            with patch.dict(os.environ, {"SSH_CONNECTION": "192.0.2.1 1234 192.0.2.25 22"}), \
                    patch.object(enrollment, "key", return_value=(path, PUBLIC)), patch.object(s.op, "machine_id", return_value=MACHINE):
                offer = enrollment.storage_offer(context, payload)
            self.assertEqual([], document["Shared"]["Backup"]["Controller"]["Sources"])
            self.assertEqual(1, len(document["Shared"]["Backup"]["Storage"]["PendingOffers"]))
            self.assertTrue(offer["initialize_target"])
            context.control.controller.assert_not_called()
            self.assertNotIn("backup_password", offer)

    def test_confirm_does_not_enable_until_repository_and_source_probe_pass(self):
        with tempfile.TemporaryDirectory() as folder:
            context, document = self.context(folder)
            item = {"Name": "prod", "MachineId": OLD, "Enabled": False}
            document["Shared"]["Backup"]["Storage"]["PendingOffers"] = [item]
            context.control.rpc.return_value = {"centrally_managed": False}
            with self.assertRaisesRegex(s.op.Error, "not_handed_off"):
                enrollment.storage_confirm(context, {"name": "prod", "source_machine": OLD,
                    "repository_id": "d" * 64, "restic_repository_id": "e" * 64})
            context.control.run.assert_not_called()
            self.assertFalse(item["Enabled"])

    def test_confirm_activates_after_bound_identity_probe_and_preserves_other_sources(self):
        with tempfile.TemporaryDirectory() as folder:
            context, document = self.context(folder)
            item = {"Name": "prod", "MachineId": OLD, "Enabled": False}
            unrelated = {"Name": "other", "MachineId": "f" * 32}
            document["Shared"]["Backup"]["Controller"]["Sources"] = [unrelated]
            document["Shared"]["Backup"]["Storage"]["PendingOffers"] = [item]
            context.control.rpc.return_value = {"centrally_managed": True}
            installer = MagicMock(CONTROLLER_TIMERS=("timer",))
            context.load.return_value = installer
            with patch.object(s.op, "private_directory", side_effect=directory):
                result = enrollment.storage_confirm(context, {"name": "prod", "source_machine": OLD,
                    "repository_id": "d" * 64, "restic_repository_id": "e" * 64})
            self.assertEqual("source_paired", result["status"])
            self.assertIn(unrelated, document["Shared"]["Backup"]["Controller"]["Sources"])
            self.assertTrue(item["Enabled"])
            self.assertEqual([], document["Shared"]["Backup"]["Storage"]["PendingOffers"])
            self.assertEqual(6, context.control.controller.call_count)


class EnrollmentTests(unittest.TestCase):
    @unittest.skipUnless(os.name == "posix", "POSIX descriptors and ownership")
    def test_restore_adopts_repository_owners_without_following_links(self):
        storage = s.load("storage")
        with tempfile.TemporaryDirectory() as folder:
            root = Path(folder)
            repository = root / "repository"
            repository.mkdir()
            (repository / "index").mkdir()
            (repository / "index/block").write_text("encrypted")
            storage.adopt_encrypted_repository(repository, os.geteuid(), os.getegid())
            self.assertEqual(0o700, repository.stat().st_mode & 0o777)
            self.assertEqual(0o600, (repository / "index/block").stat().st_mode & 0o777)
            outside = root / "outside"
            outside.write_text("untouched")
            before = outside.stat().st_mode
            (repository / "escape").symlink_to(outside)
            with self.assertRaises(OSError):
                storage.adopt_encrypted_repository(repository, os.geteuid(), os.getegid())
            self.assertEqual(before, outside.stat().st_mode)

    def test_source_and_storage_cannot_be_paired_as_same_machine(self):
        with patch.object(s.op, "machine_id", return_value=MACHINE), self.assertRaisesRegex(s.op.Error, "different_machines"):
            enrollment.source_pair(s, {"storage_address": "192.0.2.25", "controller_machine": MACHINE})

    def test_repository_url_parser_does_not_accept_shell_or_custom_paths(self):
        for url in ("sftp:root@1.2.3.4:/root", "sftp:u@1.2.3.4:/repository;id", "sftp:u@host:/repository", "sftp:u@1.2.3.4:/repository\n"):
            self.assertIsNone(enrollment.SFTP.fullmatch(url))
        self.assertIsNotNone(enrollment.SFTP.fullmatch("sftp:yeshua-backup@162.35.11.225:/repository"))

    def test_admin_authentication_is_native_temporary_and_password_not_an_argument(self):
        with tempfile.TemporaryDirectory() as folder, patch.object(s, "BASE", Path(folder)), \
                patch.object(s.op, "private_directory", side_effect=directory), \
                patch.object(enrollment.subprocess, "run", return_value=MagicMock(returncode=0)) as run:
            with enrollment.admin_session(s, "192.0.2.1") as command:
                self.assertIn("BatchMode=yes", command)
        first, last = run.call_args_list[0].args[0], run.call_args_list[-1].args[0]
        self.assertIn("-M", first)
        self.assertIn("StrictHostKeyChecking=ask", first)
        self.assertEqual(["-O", "exit"], last[-3:-1])
        self.assertNotIn("sshpass", str(run.call_args_list))
        self.assertNotIn("StrictHostKeyChecking=no", str(run.call_args_list))

    def test_failed_admin_authentication_never_proceeds(self):
        with tempfile.TemporaryDirectory() as folder, patch.object(s, "BASE", Path(folder)), \
                patch.object(s.op, "private_directory", side_effect=directory), \
                patch.object(s, "ask", side_effect=s.op.Error("setup_cancelled")) as ask, \
                patch.object(enrollment.subprocess, "run", return_value=MagicMock(returncode=1)) as run, \
                self.assertRaisesRegex(s.op.Error, "setup_cancelled"):
            with enrollment.admin_session(s, "192.0.2.1"):
                self.fail("must not execute remote setup")
        ask.assert_called_once()
        run.assert_called_once()

    def test_closed_admin_connection_retries_only_after_operator_confirmation(self):
        with tempfile.TemporaryDirectory() as folder, patch.object(s, "BASE", Path(folder)), \
                patch.object(s.op, "private_directory", side_effect=directory), \
                patch.object(s, "ask", return_value=True) as ask, \
                patch.object(enrollment.subprocess, "run", side_effect=[MagicMock(returncode=255), MagicMock(returncode=0), MagicMock(returncode=0)]) as run:
            entered = 0
            with enrollment.admin_session(s, "192.0.2.1") as command:
                entered += 1
                self.assertIn("BatchMode=yes", command)
        self.assertEqual(1, entered)
        ask.assert_called_once()
        self.assertEqual(3, run.call_count)
        self.assertEqual(run.call_args_list[0].args[0], run.call_args_list[1].args[0])
        self.assertIn("StrictHostKeyChecking=ask", run.call_args_list[1].args[0])
        self.assertEqual(["-O", "exit"], run.call_args.args[0][-3:-1])

    def test_admin_timeout_offers_retry_without_aborting_prepared_setup(self):
        with tempfile.TemporaryDirectory() as folder, patch.object(s, "BASE", Path(folder)), \
                patch.object(s.op, "private_directory", side_effect=directory), \
                patch.object(s, "ask", return_value=True) as ask, \
                patch.object(enrollment.subprocess, "run", side_effect=[subprocess.TimeoutExpired(["ssh"], 300), MagicMock(returncode=0), MagicMock(returncode=0)]):
            with enrollment.admin_session(s, "192.0.2.1"):
                pass
        ask.assert_called_once()

    def test_invalid_ssh_retry_answer_reprompts_instead_of_restarting_setup(self):
        reader, writer = io.StringIO("wrong\nTENTAR\n"), io.StringIO()
        with tempfile.TemporaryDirectory() as folder, patch.object(s, "BASE", Path(folder)), \
                patch.object(s.op, "private_directory", side_effect=directory), \
                patch.object(s, "terminal", side_effect=lambda: nullcontext((reader, writer))), \
                patch.object(enrollment.subprocess, "run", side_effect=[MagicMock(returncode=255), MagicMock(returncode=0), MagicMock(returncode=0)]) as run:
            with enrollment.admin_session(s, "192.0.2.1"):
                pass
        self.assertIn("Tente novamente", writer.getvalue())
        self.assertEqual(3, run.call_count)

    def test_peer_failure_after_login_is_not_replayed_as_an_authentication_retry(self):
        with tempfile.TemporaryDirectory() as folder, patch.object(s, "BASE", Path(folder)), \
                patch.object(s.op, "private_directory", side_effect=directory), patch.object(s, "ask") as ask, \
                patch.object(enrollment.subprocess, "run", return_value=MagicMock(returncode=0)) as run, \
                self.assertRaisesRegex(s.op.Error, "remote_step_failed"):
            with enrollment.admin_session(s, "192.0.2.1"):
                raise s.op.Error("remote_step_failed")
        ask.assert_not_called()
        self.assertEqual(2, run.call_count)

    def test_storage_can_wait_for_origin_without_enabling_any_jobs(self):
        value = {"mode": "restore", "phase": "prepared", "pair_now": False}
        document = {"Shared": {"Backup": {"Storage": {"Address": "192.0.2.1", "Receivers": []}, "Controller": {"Sources": []}}}}
        with patch.object(s.control, "private_json", return_value=document), patch.object(enrollment, "receivers"), \
                patch.object(s, "save"), patch.object(s.control, "run") as run:
            result = enrollment._run_storage(s, value)
        self.assertEqual("storage_ready_source_pairing_pending", result["status"])
        self.assertFalse(result["schedules_enabled"])
        run.assert_not_called()

    def test_missing_old_repository_is_not_initialized(self):
        value = {"mode": "restore", "phase": "prepared", "pair_now": False}
        document = {"Shared": {"Backup": {"Storage": {"Receivers": []}, "Controller": {"Sources": [{"RepositoryPath": "/srv/yeshua-backups/missing"}]}}}}
        with patch.object(s.control, "private_json", return_value=document), patch.object(enrollment, "receivers"), \
                patch.object(s.op, "absolute", side_effect=Path), patch.object(s, "save"), \
                patch.object(Path, "is_file", return_value=False), patch.object(s.control, "run") as run:
            result = enrollment._run_storage(s, value)
        self.assertEqual("storage_prepared_restore_pending", result["status"])
        self.assertFalse(result["repository_initialized"])
        run.assert_not_called()


@unittest.skipUnless(os.name == "posix", "Bash/Linux bootstrap harness")
class ShellFlowTests(unittest.TestCase):
    def test_all_four_paths_use_one_bootstrap_and_do_not_cross_roles(self):
        for role in ("applications", "storage"):
            for mode in ("new", "restore"):
                with self.subTest(role=role, mode=mode), tempfile.TemporaryDirectory() as folder:
                    root = Path(folder)
                    (root / ".git").mkdir()
                    log = root / "calls"
                    fake = root / "python"
                    fake.write_text('#!/bin/bash\necho "python $*" >> "$CALLS"\nif [[ "$*" == *" choose "* ]]; then echo "$MODE"; fi\n')
                    fake.chmod(0o700)
                    script = 'source "$SCRIPT"\nAPP_DIR="$ROOT"\nDEPLOY_SCRIPT="$ROOT/deploy"\nINSTALLED_TOOLS="$ROOT/tools"\nPYTHON="$FAKE"\n'
                    script += 'function apt(){ echo "apt $*" >> "$CALLS"; }; function git(){ echo "git $*" >> "$CALLS"; }; '
                    script += 'function docker(){ echo "docker $*" >> "$CALLS"; }; function systemctl(){ echo "systemctl $*" >> "$CALLS"; }; '
                    script += 'function prepare_backup_key(){ echo key >> "$CALLS"; }; function ensure_directory(){ echo directory >> "$CALLS"; }; '
                    script += 'function configure_aliases(){ :; }; function verify_installation(){ :; }; function verify_https(){ :; }; '
                    script += 'function bash(){ echo "bash $*" >> "$CALLS"; }; main --role "$ROLE" --mode "$MODE"\n'
                    result = subprocess.run(["bash", "-c", script], env=dict(os.environ, SCRIPT=str(ROOT / "infra/bootstraps/setup.sh"),
                            ROOT=str(root), CALLS=str(log), FAKE=str(fake), ROLE=role, MODE=mode), capture_output=True, text=True)
                    self.assertEqual(0, result.returncode, result.stdout + result.stderr)
                    calls = log.read_text()
                    if role == "storage":
                        self.assertNotIn("docker ", calls)
                        self.assertNotIn("deploy", calls)
                        self.assertIn("--role controller --prepare-only", calls)
                        self.assertNotIn("credentials.py init", calls)
                    elif mode == "restore":
                        self.assertNotIn(str(root / "deploy") + " all", calls)
                        self.assertNotIn("credentials.py init", calls)
                        self.assertNotIn("\nkey\n", calls)
                        self.assertIn("run --role applications --mode restore", calls)
                    else:
                        self.assertIn(str(root / "deploy") + " all", calls)
                        self.assertIn("credentials.py init --wait", calls)
                        self.assertNotIn("run --role applications --mode restore", calls)
                    if role == "applications":
                        self.assertLess(calls.index("prepare --role applications"), calls.index("apt upgrade"))

    def test_shell_syntax(self):
        for relative in ("infra/bootstraps/setup.sh", "infra/bootstraps/setup-storage.sh", "infra/Memorias/DockerCompose/recovery-assets.sh"):
            result = subprocess.run(["bash", "-n", str(ROOT / relative)], capture_output=True, text=True)
            self.assertEqual(0, result.returncode, result.stderr)


if __name__ == "__main__":
    unittest.main()
