import importlib.util
import json
from pathlib import Path
import subprocess
import tempfile
import unittest
from unittest.mock import patch


ROOT = Path(__file__).resolve().parents[3]
spec = importlib.util.spec_from_file_location("cache_policy", ROOT / "infra/docker/configure-build-cache.py")
cache_policy = importlib.util.module_from_spec(spec)
spec.loader.exec_module(cache_policy)


class BuildCacheTests(unittest.TestCase):
    def test_merge_preserves_unrelated_settings(self):
        original = {"log-driver": "local", "builder": {"entitlements": {"network-host": False}}}
        merged = cache_policy.merge_policy(original, {"enabled": True})
        self.assertEqual("local", merged["log-driver"])
        self.assertEqual({"network-host": False}, merged["builder"]["entitlements"])
        self.assertNotIn("gc", original["builder"])

    def test_invalid_daemon_config_leaves_existing_file_intact(self):
        with tempfile.TemporaryDirectory() as directory:
            config = Path(directory) / "daemon.json"
            config.write_text('{"log-driver":"local"}')
            def reject(*args):
                raise subprocess.CalledProcessError(1, args)
            with self.assertRaises(subprocess.CalledProcessError):
                cache_policy.write_config(config, {"invalid": True}, reject)
            self.assertEqual('{"log-driver":"local"}', config.read_text())
            self.assertEqual([config], list(config.parent.iterdir()))

    def test_checks_effective_limits_not_only_config_file(self):
        policy = json.loads(cache_policy.POLICY.read_text())
        rules = [{}] + [
            {"all": all_records, **{key: int(policy["default" + key[0].upper() + key[1:]])
                                   for key in ("reservedSpace", "maxUsedSpace", "minFreeSpace")}}
            for all_records in (False, False, True)
        ]
        builder = {"Name": "default", "Driver": "docker", "Nodes": [{"GCPolicy": rules}]}
        with patch.object(cache_policy, "run", side_effect=lambda *args: subprocess.CompletedProcess([], 0, json.dumps(builder))):
            self.assertTrue(cache_policy.active_policy(policy))
            rules[-1]["maxUsedSpace"] = 125000000000
            self.assertFalse(cache_policy.active_policy(policy))

    def test_already_active_policy_never_restarts_docker(self):
        with tempfile.TemporaryDirectory() as directory:
            config = Path(directory) / "daemon.json"
            config.write_text(json.dumps({"builder": {"gc": json.loads(cache_policy.POLICY.read_text())}}))
            with patch.object(cache_policy, "CONFIG", config), patch.object(cache_policy.os, "geteuid", return_value=0, create=True), \
                 patch.object(cache_policy, "active_policy", return_value=True), \
                 patch.object(cache_policy, "write_config") as write, patch.object(cache_policy.subprocess, "run") as command:
                cache_policy.main()
                write.assert_not_called()
                command.assert_not_called()

    def test_failed_activation_restores_config_and_running_containers(self):
        with tempfile.TemporaryDirectory() as directory:
            config = Path(directory) / "daemon.json"
            previous = {"log-driver": "local"}
            config.write_text(json.dumps(previous))
            def command(*args):
                if args == ("systemctl", "restart", "docker"):
                    raise subprocess.CalledProcessError(1, args)
                return subprocess.CompletedProcess(args, 0, "c1\nc2\n" if args == ("docker", "ps", "-q") else "")
            with patch.object(cache_policy, "CONFIG", config), patch.object(cache_policy.os, "geteuid", return_value=0, create=True), \
                 patch.object(cache_policy, "active_policy", return_value=False), \
                 patch.object(cache_policy, "write_config") as write, patch.object(cache_policy, "run", side_effect=command) as run, \
                 patch.object(cache_policy.subprocess, "run"):
                with self.assertRaises(subprocess.CalledProcessError):
                    cache_policy.main()
                self.assertEqual(previous, write.call_args_list[-1].args[1])
                self.assertIn(unittest.mock.call("systemctl", "start", "docker"), run.call_args_list)
                self.assertIn(unittest.mock.call("docker", "start", "c1", "c2"), run.call_args_list)


if __name__ == "__main__":
    unittest.main()
