import importlib.util
import json
import os
from pathlib import Path
import subprocess
import tempfile
from types import SimpleNamespace
import unittest
from unittest.mock import patch

source = Path(__file__).resolve().parents[2] / 'infra/Shared/DockerCompose/operational-intelligence/host-disk-usage.py'
spec = importlib.util.spec_from_file_location('host_disk_usage', source)
disk = importlib.util.module_from_spec(spec)
spec.loader.exec_module(disk)


class HostDiskUsageTests(unittest.TestCase):
    def test_reserved_blocks_are_not_reported_as_available(self):
        fs = SimpleNamespace(f_blocks=100, f_bfree=30, f_bavail=20, f_frsize=1024)
        with patch.object(disk.os, 'statvfs', return_value=fs, create=True):
            usage = disk.filesystem_usage()
        self.assertEqual(usage['reservedBytes'], 10 * 1024)
        self.assertEqual(usage['usedBytes'] + usage['availableBytes'] + usage['reservedBytes'], usage['capacityBytes'])
        self.assertEqual(usage['usedPercent'], 77.78)

    def test_partial_scan_preserves_complete_paths_and_discards_interrupted_record(self):
        raw = b'4096\t/storage/with\nnewline\0' + b'8192\t/storage\0' + b'1024\t/interrupted'
        with patch.object(disk, 'run_read', return_value=(raw, None, True, 1)):
            result = disk.directory_usage('storage', '/storage', 3, 1)
        self.assertEqual(result['status'], 'partial')
        self.assertTrue(result['timedOut'])
        self.assertEqual([row['path'] for row in result['directories']], ['/storage', '/storage/with\nnewline'])

    def test_failed_scan_does_not_misrepresent_permission_error_as_zero_usage(self):
        with patch.object(disk, 'run_read', return_value=(b'', 1, False, 1)):
            result = disk.directory_usage('storage', '/storage', 3, 1)
        self.assertEqual(result['status'], 'unavailable')
        self.assertEqual(result['directories'], [])

    def test_timeout_returns_partial_output_without_reading_file_contents(self):
        failure = subprocess.TimeoutExpired(['du'], 1, output=b'4096\t/safe\0')
        with patch.object(disk.subprocess, 'run', side_effect=failure):
            raw, code, timed_out, errors = disk.run_read(['du'], 1)
        self.assertEqual(raw, b'4096\t/safe\0')
        self.assertIsNone(code)
        self.assertTrue(timed_out)

    def test_docker_projection_retains_only_size_metadata(self):
        raw = json.dumps({'Type': 'Images', 'Size': '10GB', 'Reclaimable': '2GB', 'unexpected': 'not-exported'}).encode()
        with patch.object(disk, 'run_read', return_value=(raw, 0, False, 0)):
            result = disk.docker_usage(1)
        self.assertEqual(result['status'], 'complete')
        self.assertNotIn('unexpected', result['categories'][0])

    @unittest.skipUnless(os.name == 'posix', 'Linux report permissions')
    def test_report_replacement_is_complete_and_readable_without_changing_source_permissions(self):
        with tempfile.TemporaryDirectory() as directory:
            disk.save_report({'status': 'complete', 'marker': 1}, directory)
            disk.save_report({'status': 'partial', 'marker': 2}, directory)
            path = Path(directory) / 'disk-usage.json'
            self.assertEqual(json.loads(path.read_text())['marker'], 2)
            self.assertEqual(path.stat().st_mode & 0o777, 0o644)
            self.assertEqual(len(list(Path(directory).iterdir())), 1)


if __name__ == '__main__':
    unittest.main()
