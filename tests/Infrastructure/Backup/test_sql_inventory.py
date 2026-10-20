import importlib.util
import json
import os
from pathlib import Path
import subprocess
import tempfile
import unittest
from unittest.mock import patch


ROOT = Path(__file__).resolve().parents[3]
spec = importlib.util.spec_from_file_location("sql_backup_inventory", ROOT / "infra/backups/sql.py")
inventory = importlib.util.module_from_spec(spec)
spec.loader.exec_module(inventory)


class SqlInventoryTests(unittest.TestCase):
    def database(self, **values):
        result = {"name": "YESHUA_CENTRAL", "database_id": 5, "state_desc": "ONLINE",
                  "recovery_model_desc": "SIMPLE", "is_encrypted": False}
        result.update(values)
        return result

    def test_expected_names_match_existing_public_configuration(self):
        actual = inventory.expected_databases(ROOT)
        self.assertEqual(6, len(actual))
        self.assertEqual("YESHUA_APS_ADM", actual["APS_ADM"])

    def test_missing_declaration_fails_without_loading_shell(self):
        with tempfile.TemporaryDirectory() as folder:
            root = Path(folder)
            (root / "infra/docker").mkdir(parents=True)
            (root / "infra/docker/deploy.env").write_text("YESHUA_DB_CENTRAL=YESHUA_CENTRAL\n")
            with self.assertRaises(inventory.InventoryError):
                inventory.expected_databases(root)

    def test_missing_database_is_explicit(self):
        result = inventory.assess({"databases": []}, {"CENTRAL": "YESHUA_CENTRAL"})
        self.assertEqual(["YESHUA_CENTRAL"], result["missing_databases"])
        self.assertFalse(result["backup_executed"])
        self.assertFalse(result["restore_proven"])

    def test_full_without_log_history_and_log_backup_wait_are_flagged(self):
        database = self.database(recovery_model_desc="FULL", last_log=None, log_reuse_wait_desc="LOG_BACKUP")
        result = inventory.assess({"databases": [database]}, {"CENTRAL": "YESHUA_CENTRAL"})
        self.assertEqual({"no_log_backup_recorded_in_msdb", "log_waiting_for_backup"}, {item["code"] for item in result["findings"]})

    def test_bulk_logged_is_not_treated_as_simple(self):
        database = self.database(recovery_model_desc="BULK_LOGGED", last_log=None)
        result = inventory.assess({"databases": [database]}, {"CENTRAL": "YESHUA_CENTRAL"})
        self.assertEqual("no_log_backup_recorded_in_msdb", result["findings"][0]["code"])

    def test_encryption_and_active_backup_are_reported(self):
        sql = {"databases": [self.database(is_encrypted=True)], "active_backup_restore": [{"session_id": 9}]}
        result = inventory.assess(sql, {"CENTRAL": "YESHUA_CENTRAL"})
        self.assertEqual({"sql_encryption_key_recovery_required", "backup_or_restore_already_active"}, {item["code"] for item in result["findings"]})

    def test_additional_databases_are_not_deleted_or_silently_adopted(self):
        sql = {"databases": [self.database(), self.database(name="LEGACY", database_id=6), self.database(name="master", database_id=1)]}
        result = inventory.assess(sql, {"CENTRAL": "YESHUA_CENTRAL"})
        self.assertEqual(["LEGACY"], result["additional_databases_to_classify"])

    def test_password_only_in_child_environment(self):
        captured = []
        def fake_run(args, **kwargs):
            captured.append((args, kwargs))
            return inventory.JSON_MARKER + json.dumps({"databases": []}) if "-Q" in args else ""
        with patch.object(inventory, "run", side_effect=fake_run):
            inventory.sql_inventory("DO_NOT_DISPLAY_PASSWORD")
        args, options = captured[-1]
        self.assertNotIn("DO_NOT_DISPLAY_PASSWORD", " ".join(args))
        self.assertNotIn("-P", args)
        self.assertEqual("DO_NOT_DISPLAY_PASSWORD", options["env"]["SQLCMDPASSWORD"])
        self.assertIn("-b", args)
        self.assertNotIn("-h", args)
        self.assertEqual("0", args[args.index("-y") + 1])
        self.assertEqual(inventory.QUERY, args[args.index("-Q") + 1])

    def test_no_installer_or_container_recreation_when_client_missing(self):
        with patch.object(inventory, "run", side_effect=inventory.InventoryError("absent")) as mocked:
            with self.assertRaises(inventory.InventoryError):
                inventory.sql_inventory("secret")
        self.assertTrue(all(call.args[0][1:4] == ["exec", inventory.SQL_CONTAINER, "test"] for call in mocked.call_args_list))

    def test_command_failure_never_exposes_stdout_or_stderr(self):
        completed = subprocess.CompletedProcess(["docker"], 1, "sensitive-stdout", "sensitive-stderr")
        with patch.object(subprocess, "run", return_value=completed):
            with self.assertRaises(inventory.InventoryError) as error:
                inventory.run(["docker"])
        self.assertNotIn("sensitive", str(error.exception))

    def test_invalid_json_is_sanitized(self):
        with patch.object(inventory, "run", side_effect=["", "sensitive-response"]):
            with self.assertRaises(inventory.InventoryError) as error:
                inventory.sql_inventory("secret")
        self.assertNotIn("sensitive", str(error.exception))

    def test_json_framing_accepts_headers_and_wrapped_lines(self):
        body = inventory.JSON_MARKER + '{"databases":\n[]}\n'
        with patch.object(inventory, "run", side_effect=["", "header\n---\n" + body]):
            document, _ = inventory.sql_inventory("secret")
        self.assertEqual([], document["databases"])

    def test_repeated_marker_is_rejected(self):
        with patch.object(inventory, "run", side_effect=["", inventory.JSON_MARKER * 2 + '{"databases":[]}']):
            with self.assertRaises(inventory.InventoryError):
                inventory.sql_inventory("secret")

    def test_existing_staging_without_write_permission_is_only_reported(self):
        with patch.object(inventory, "run", side_effect=["10001", inventory.InventoryError("not_writable")]) as mocked:
            result = inventory.sql_staging_access()
        self.assertEqual({"container_uid": 10001, "existing_backup_directory_writable": False}, result)
        self.assertEqual(["docker", "exec", inventory.SQL_CONTAINER, "test", "-w", "/var/opt/mssql/backup"], mocked.call_args.args[0])

    def test_metadata_only_inspection_never_outputs_container_environment(self):
        raw = [{"Id": "a" * 64, "Name": "/fixture", "Image": "sha256:fixture", "RestartCount": 0,
                "State": {"StartedAt": "fixture"}, "Mounts": [],
                "Config": {"Labels": {"com.docker.compose.project": "playsis-fixture"}, "User": "10001", "Env": ["SECRET=DO_NOT_DISPLAY"]}}]
        with patch.object(inventory, "run", side_effect=["id", json.dumps(raw)]):
            result = inventory.container_inventory()
        self.assertNotIn("DO_NOT_DISPLAY", json.dumps(result))
        self.assertEqual("10001", result[0]["configured_user"])

    def test_query_contains_no_backup_restore_or_mutation_statement(self):
        for line in inventory.QUERY.splitlines():
            self.assertNotRegex(line.strip().upper(), r"^(BACKUP|RESTORE|INSERT|UPDATE|DELETE|DROP|ALTER|CREATE|EXEC|DBCC)\b")
        self.assertNotIn("Query(", inventory.QUERY)

    def test_path_inventory_of_missing_area_does_not_create_it(self):
        with tempfile.TemporaryDirectory() as folder:
            missing = Path(folder) / "missing"
            self.assertFalse(inventory.path_inventory(missing)["exists"])
            self.assertFalse(missing.exists())

    def test_run_timeout_is_sanitized(self):
        with patch.object(subprocess, "run", side_effect=subprocess.TimeoutExpired(["secret"], 1)):
            with self.assertRaises(inventory.InventoryError) as error:
                inventory.run(["secret"])
        self.assertNotIn("secret", str(error.exception))


if __name__ == "__main__":
    unittest.main()
