from contextlib import nullcontext
from datetime import datetime, timezone
import importlib.util
import json
import os
from pathlib import Path
from types import SimpleNamespace
import sys
import tempfile
import unittest
from unittest.mock import MagicMock, patch

ROOT = Path(__file__).resolve().parents[3]
spec = importlib.util.spec_from_file_location("backup_control_tests", ROOT / "infra/backups/control.py")
c = importlib.util.module_from_spec(spec)
sys.modules[spec.name] = c
spec.loader.exec_module(c)
source = c.source
IDENTITY = {"source_machine": "a" * 32, "repository_id": "b" * 64}
OWNER = {"controller_machine": "c" * 32}
ITEM = {"Name": "production", "MachineId": "a" * 32, "RepositoryId": "b" * 64, "Scope": "yeshua-production"}


def request(action="start", **changes):
    return {"protocol": 1, "action": action, **IDENTITY, **OWNER, "request_id": "d" * 32, "kind": "logs", **changes}


def mkdir(path, *, create=False):
    path = Path(path)
    if create:
        path.mkdir(parents=True, exist_ok=True)
    return path


class SourceControlTests(unittest.TestCase):
    def setUp(self):
        self.temp = tempfile.TemporaryDirectory()
        self.addCleanup(self.temp.cleanup)
        self.base = Path(self.temp.name)
        self.c = SimpleNamespace(op=c.op, private_json=c.op.read, run=MagicMock(return_value="ActiveState=activating\n"),
                                 policy=lambda: {"staging": str(self.base)})
        for target, replacement in (("state", lambda _: self.base), ("binding", lambda _: IDENTITY),
                                    ("owner", lambda _: OWNER)):
            patcher = patch.object(source, target, replacement)
            patcher.start()
            self.addCleanup(patcher.stop)
        for name, replacement in (("locked", lambda _: nullcontext()), ("private_directory", mkdir)):
            patcher = patch.object(c.op, name, replacement)
            patcher.start()
            self.addCleanup(patcher.stop)

    def test_repeated_start_reuses_request_and_does_not_start_another_unit(self):
        first = source.dispatch(self.c, request())
        second = source.dispatch(self.c, request())
        self.assertEqual(first, second)
        self.c.run.assert_any_call(["systemctl", "start", "--no-block", source.unit("d" * 32)])
        self.assertEqual(1, sum(call.args[0][1] == "start" for call in self.c.run.call_args_list))

    def test_status_accepts_original_start_payload_and_survives_disconnection(self):
        source.dispatch(self.c, request())
        value = source.dispatch(self.c, request("status"))
        self.assertEqual("queued", value["status"])

    def test_reusing_id_with_different_kind_is_rejected(self):
        source.dispatch(self.c, request())
        with self.assertRaisesRegex(c.op.Error, "different_payload"):
            source.dispatch(self.c, request(kind="files"))

    def test_shell_paths_unknown_operations_and_bad_ids_are_rejected(self):
        for payload in (request(action="shell"), request(request_id="../etc/passwd"), request(kind="check-data"),
                        request(command="id"), request(protocol=2), request(source_machine="e" * 32),
                        request(repository_id="f" * 64), request(controller_machine="e" * 32)):
            with self.subTest(payload=payload), self.assertRaises(c.op.Error):
                source.dispatch(self.c, payload)
        self.c.run.assert_not_called()

    def test_probe_is_allowed_before_handoff_but_capture_is_not(self):
        with patch.object(source, "owner", return_value=None):
            payload = {k: v for k, v in request("probe").items() if k not in {"request_id", "kind"}}
            self.assertFalse(source.dispatch(self.c, payload)["centrally_managed"])
            with self.assertRaisesRegex(c.op.Error, "handoff_required"):
                source.dispatch(self.c, request())

    def test_one_capture_per_source(self):
        source.dispatch(self.c, request())
        self.assertEqual("busy", source.dispatch(self.c, request(request_id="e" * 32))["status"])

    def test_reboot_marks_running_job_failed_and_never_claims_delivery(self):
        source.dispatch(self.c, request())
        path = source.request_path(self.c, "d" * 32)
        value = c.op.read(path)
        c.op.write(path, dict(value, status="running"))
        self.c.run.return_value = "ActiveState=inactive\nResult=success\n"
        result = source.dispatch(self.c, request("status"))
        self.assertEqual("failed", result["status"])
        self.assertEqual("source_execution_interrupted", result["error"])

    def test_queued_request_restarts_same_unit_if_start_was_interrupted(self):
        source.dispatch(self.c, request())
        self.c.run.reset_mock()
        self.c.run.return_value = "ActiveState=inactive\n"
        source.dispatch(self.c, request("status"))
        self.c.run.assert_any_call(["systemctl", "start", "--no-block", source.unit("d" * 32)])

    def test_terminal_receipt_is_not_reexecuted(self):
        source.dispatch(self.c, request())
        path = source.request_path(self.c, "d" * 32)
        c.op.write(path, dict(c.op.read(path), status="completed"))
        self.c.run.reset_mock()
        self.assertEqual("completed", source.dispatch(self.c, request())["status"])
        self.c.run.assert_not_called()

    def test_safety_uses_same_native_executor_without_network(self):
        self.c.credentials = lambda: ({}, "password")
        self.c.routine = SimpleNamespace(sql_cycle=MagicMock(return_value={"delivered": False}))
        result = source.safety(self.c)
        self.assertFalse(result["delivered"])
        self.c.routine.sql_cycle.assert_called_once_with(c.op, {}, "password", self.c.policy(), "logs", native_only=True)

    def test_recent_generation_suppresses_local_fallback(self):
        (self.base / "state").mkdir()
        c.op.write(self.base / "state/sql-generated.json", {"generated_at": datetime.now(timezone.utc).isoformat(), **IDENTITY})
        with patch.object(c.op, "machine_id", return_value=IDENTITY["source_machine"]):
            self.assertEqual("recent_native_sql_backup", source.safety(self.c)["status"])


class ControllerTests(unittest.TestCase):
    def test_health_reports_absent_or_failed_deliveries_not_only_scheduler_success(self):
        self.assertEqual("attention", c.health(self.state())["status"])
        receipt = {"status": "completed", "finished_at": datetime.now(timezone.utc).isoformat()}
        value = self.state(results={k: receipt for k in c.routine.KINDS})
        self.assertEqual("current", c.health(value)["status"])
        value["results"]["logs"] = {"status": "failed"}
        self.assertIn("logs", c.health(value)["overdue"])

    def test_new_sources_get_individual_storage_users_and_chroots(self):
        storage = c.load("storage")
        first = storage.source_layout("node-one")
        second = storage.source_layout("node-two")
        self.assertNotEqual(first, second)
        self.assertIn("/srv/yeshua-backups/node-one", storage.ssh_configuration(first[0], first[1]))
        self.assertEqual((storage.USER, storage.ROOT, storage.CONFIG), storage.source_layout())
        for name in ("../root", "a b", "root;id", "a" * 21):
            with self.assertRaises(RuntimeError):
                storage.source_layout(name)

    def test_calendar_event_waits_instead_of_disappearing_when_tick_holds_lock(self):
        with patch.object(c.op, "locked", side_effect=[c.op.Error("another_backup_or_deploy_holds_lock"), nullcontext()]), \
                patch.object(c.time, "sleep") as sleep:
            with c.controller_lock():
                pass
        sleep.assert_called_once_with(0.25)

    @unittest.skipUnless(os.name == "posix", "POSIX ownership and umask")
    def test_public_ssh_configuration_permissions_do_not_inherit_private_umask(self):
        storage = c.load("storage")
        with tempfile.TemporaryDirectory() as folder:
            previous = os.umask(0o077)
            try:
                directory = Path(folder) / "keys"
                storage.directory(directory, uid=os.geteuid())
                self.assertEqual(0o755, directory.stat().st_mode & 0o777)
                public = directory / "key"
                storage.managed_file(public, "public", 0o644)
                self.assertEqual(0o644, public.stat().st_mode & 0o777)
            finally:
                os.umask(previous)

    def state(self, **changes):
        return {"pending": {}, "active": None, "results": {}, **changes}

    def test_capacity_limit_keeps_request_pending(self):
        value = self.state(pending={"logs": "now"})
        with patch.object(c, "rpc") as rpc:
            c.reconcile(ITEM, value, capture_slots=0, maintenance_active=False)
        rpc.assert_not_called()
        self.assertIsNone(value["active"])
        self.assertIn("logs", value["pending"])

    def test_capture_does_not_run_while_same_source_has_check(self):
        value = self.state(active={"kind": "check-data"}, pending={"logs": "now"})
        with patch.object(c, "rpc") as rpc, patch.object(c, "unit_active", return_value=True):
            c.reconcile(ITEM, value, capture_slots=1, maintenance_active=True)
        rpc.assert_not_called()

    def test_interrupted_maintenance_is_requeued_not_stuck_forever(self):
        value = self.state(active={"kind": "check"})
        with patch.object(c, "unit_active", return_value=False), self.assertRaisesRegex(c.op.Error, "interrupted"):
            c.reconcile(ITEM, value, capture_slots=1, maintenance_active=False)
        self.assertIsNone(value["active"])
        self.assertIn("check", value["pending"])

    def test_start_is_persisted_before_rpc_so_timeout_can_be_reconciled(self):
        value = self.state(pending={"logs": "now"})
        with patch.object(c, "state_path", return_value=Path("state.json")), patch.object(c.op, "write") as write, \
                patch.object(c, "rpc", side_effect=TimeoutError), self.assertRaises(TimeoutError):
            c.reconcile(ITEM, value, capture_slots=1, maintenance_active=False)
        self.assertEqual("logs", value["active"]["kind"])
        write.assert_called_once()

    def test_missing_remote_request_is_retried_with_same_identifier(self):
        active = {"request_id": "d" * 32, "kind": "logs"}
        value = self.state(active=active)
        with patch.object(c, "rpc", side_effect=[{"status": "not_found"}, {"status": "queued"}]) as rpc:
            c.reconcile(ITEM, value, capture_slots=1, maintenance_active=False)
        self.assertEqual(["status", "start"], [call.args[1] for call in rpc.call_args_list])
        self.assertTrue(all(call.args[2] is active for call in rpc.call_args_list))

    def test_sql_full_prevents_starvation_by_continuously_pending_logs(self):
        value = self.state(pending={"logs": "now", "full": "now"})
        with patch.object(c, "state_path", return_value=Path("state.json")), patch.object(c.op, "write"), \
                patch.object(c, "rpc", return_value={"status": "queued"}):
            c.reconcile(ITEM, value, capture_slots=1, maintenance_active=False)
        self.assertEqual("full", value["active"]["kind"])
        self.assertIn("logs", value["pending"])

    def test_delivery_is_not_confirmed_from_source_receipt_alone(self):
        value = self.state(active={"request_id": "d" * 32, "kind": "logs"})
        with patch.object(c, "rpc", return_value={"status": "completed", "result": {}}), \
                self.assertRaisesRegex(c.op.Error, "invalid_source_delivery_receipt"):
            c.reconcile(ITEM, value, capture_slots=1, maintenance_active=False)
        self.assertNotIn("logs", value["results"])

    def test_snapshot_confirmation_checks_full_id_host_run_and_kind(self):
        result = {"status": "completed", "kind": "logs", "repository_id": "b" * 64,
                  "snapshot_id": "f" * 64, "run_id": "20261023T120000Z-123456abcdef"}
        good = {"id": "f" * 64, "hostname": "yeshua-production", "tags": ["yeshua", "scope=yeshua-production",
                "run=" + result["run_id"], "kind=sql"]}
        with patch.object(c, "verify_repository"), patch.object(c, "local_restic", return_value=json.dumps([good])):
            self.assertIn("storage_confirmed_at", c.snapshot_confirmed(ITEM, {"kind": "logs"}, result))
        for changes in ({"id": "e" * 64}, {"hostname": "other"}, {"tags": ["yeshua", "kind=files"]}):
            with self.subTest(changes=changes), patch.object(c, "verify_repository"), \
                    patch.object(c, "local_restic", return_value=json.dumps([dict(good, **changes)])), self.assertRaises(c.op.Error):
                c.snapshot_confirmed(ITEM, {"kind": "logs"}, result)

    def test_rpc_never_accepts_another_source_or_request(self):
        item = dict(ITEM, Host="192.0.2.1", Port=22, IdentityFile="/private/key", KnownHostsFile="/private/known")
        for changes in ({"source_machine": "f" * 32}, {"repository_id": "e" * 64}, {"request_id": "f" * 32}):
            response = dict(IDENTITY, request_id="d" * 32, kind="logs", status="queued", **{})
            response.update(changes)
            with self.subTest(changes=changes), patch.object(c, "run", return_value=json.dumps(response)), \
                    self.assertRaises(c.op.Error):
                c.rpc(item, "start", {"request_id": "d" * 32, "kind": "logs"}, controller_machine="c" * 32)

    def test_rpc_disables_ambient_ssh_config_and_requires_pinned_host(self):
        item = dict(ITEM, Host="192.0.2.1", Port=22, IdentityFile="/private/key", KnownHostsFile="/private/known")
        with patch.object(c, "run", return_value=json.dumps(dict(IDENTITY, status="ready"))) as run:
            c.rpc(item, "probe", controller_machine="c" * 32)
        command = run.call_args.args[0]
        self.assertEqual(["ssh", "-F", "/dev/null"], command[:3])
        self.assertIn("StrictHostKeyChecking=yes", command)
        self.assertIn("BatchMode=yes", command)
        self.assertNotIn("root@192.0.2.1", command)

    def test_controller_reuses_calendars_and_bootstrap_preserves_destination(self):
        installer = c.load("install")
        units = installer.managed_units(ROOT / "infra/backups", "controller")
        for kind in installer.TIMERS:
            original = (ROOT / "infra/backups" / ("yeshua-backup-" + kind + ".timer")).read_text()
            self.assertEqual(original.replace("Unit=yeshua-backup@", "Unit=yeshua-backup-controller@"),
                             units["yeshua-backup-controller-" + kind + ".timer"])
        setup = (ROOT / "infra/bootstraps/setup.sh").read_text()
        self.assertIn("for action in configure-repository recovery-key", setup)
        self.assertNotIn("for action in configure-local recovery-key", setup)


if __name__ == "__main__":
    unittest.main()
