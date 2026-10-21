from contextlib import nullcontext
from pathlib import Path
import tempfile
from types import SimpleNamespace
import unittest
from unittest.mock import patch

from test_routine import op, record, routine


class ClassificationCycleTests(unittest.TestCase):
    def test_old_system_intents_are_preserved_without_new_sql_operations(self):
        with tempfile.TemporaryDirectory() as folder:
            base = Path(folder)
            (base / "intents").mkdir()
            path = base / "intents/old-master.json"
            op.write(path, {"system": True, "database_name": "master"})
            before = path.read_bytes()
            with patch.object(routine, "complete_intent") as complete:
                routine.reconcile_intents(op, base, "fixture", "client")
            complete.assert_not_called()
            self.assertEqual(before, path.read_bytes())

    def test_online_cycle_never_recopies_system_media_but_keeps_estudo_and_new_app(self):
        with tempfile.TemporaryDirectory() as folder:
            base = Path(folder) / "backup"
            for name in ("records", "intents", "state"):
                (base / name).mkdir(parents=True)
            data = Path(folder) / "sql"
            native = data / "backup/yeshua-scheduled"
            native.mkdir(parents=True)
            old = native / "old-master.bak"
            old.write_bytes(b"keep old media on disk, not in new snapshots")
            old_record = base / "records/old-master.json"
            op.write(old_record, record(database_name="master", system=True, path=str(old), schema=1,
                                        source_machine="fixture-machine"))
            policy = {"sql_data": str(data), "minimum_free_bytes": 1024, "scope": "yeshua-production"}
            database = {"state_desc": "ONLINE", "recovery_model_desc": "SIMPLE", "is_encrypted": False,
                        "data_allocated_mb": 1, "log_allocated_mb": 1}
            metadata = {"product_version": "fixture-version", "databases": [
                {**database, "name": "master", "database_id": 1, "state_desc": "OFFLINE"},
                {**database, "name": "Estudo", "database_id": 5},
                {**database, "name": "NewApp", "database_id": 6}]}
            original_stat = Path.stat

            def path_stat(path, *args, **kwargs):
                result = original_stat(path, *args, **kwargs)
                return SimpleNamespace(st_uid=0, st_mode=0o40711) if path == native else result

            def complete(operator, root, password, client, intent, intent_path):
                path = Path(intent["path"])
                path.write_bytes(b"fixture native SQL media")
                row = record(database_name=intent["database_name"], backup_guid=intent["database_name"],
                             path=str(path), system=False, schema=1, source_machine="fixture-machine",
                             files=intent["files"], created_at="2026-10-21T00:00:00+00:00")
                op.write(root / "records" / intent_path.name, row)
                intent_path.unlink()
                return row

            with patch.object(op, "locked", return_value=nullcontext()), \
                    patch.object(op, "absolute", side_effect=Path), patch.object(op, "machine_id", return_value="fixture-machine"), \
                    patch.object(op.sql, "sql_inventory", return_value=(metadata, "client")), \
                    patch.object(op.sql, "expected_databases", return_value={"ESTUDO": "Estudo", "NEW": "NewApp"}), \
                    patch.object(op.sql, "run", return_value="10001"), \
                    patch.object(op.sql, "database_files", return_value=[{"type_desc": "ROWS", "logical_name": "data"}]), \
                    patch.object(op.sql, "backup_native") as backup, \
                    patch.object(routine, "complete_intent", side_effect=complete), \
                    patch.object(routine, "preflight", return_value=base), \
                    patch.object(routine, "snapshot", return_value={"snapshot_id": "a" * 64}) as snapshot, \
                    patch.object(routine.shutil, "disk_usage", return_value=SimpleNamespace(free=10 ** 12)), \
                    patch.object(routine.os, "chown", create=True), patch.object(Path, "stat", path_stat):
                result = routine._sql_cycle(op, {}, "fixture", policy, "full", base)

            self.assertEqual(["Estudo", "NewApp"], [call.args[2] for call in backup.call_args_list])
            self.assertEqual(2, result["database_backups"])
            sources = snapshot.call_args.args[3]
            self.assertNotIn(native, sources)
            self.assertNotIn(base / "records", sources)
            self.assertNotIn(old, sources)
            self.assertNotIn(old_record, sources)
            self.assertEqual(2, sum(path.suffix == ".bak" for path in sources))
            self.assertTrue(old.is_file())
            self.assertTrue(old_record.is_file())
            self.assertEqual({"Estudo", "NewApp"}, set(op.read(base / "state/sql-catalog.json")["chains"]))


if __name__ == "__main__":
    unittest.main()
