import os
from pathlib import Path
import tempfile
import unittest

from private_fixtures import PrivateFixtureTestCase
from test_credentials import ROOT, configured, credentials


@unittest.skipUnless(os.name == "posix", "POSIX unit permission/link semantics; Windows ACL covered separately")
class FixtureSecurityTests(PrivateFixtureTestCase):
    def test_read_preserves_private_permissions_and_bytes(self):
        with tempfile.TemporaryDirectory(dir=self.fixture_root) as directory:
            path = Path(directory) / 'private/credentials.json'
            credentials.write_new_json(path, configured())
            before = path.read_bytes()
            credentials.read_json(path)
            self.assertEqual(before, path.read_bytes())
            self.assertEqual(0o600, path.stat().st_mode & 0o777)

    def test_world_readable_file_is_still_rejected(self):
        with tempfile.TemporaryDirectory(dir=self.fixture_root) as directory:
            path = Path(directory) / 'private/credentials.json'
            credentials.write_new_json(path, configured())
            path.chmod(0o644)
            with self.assertRaises(credentials.ConfigurationError):
                credentials.read_json(path)
            self.assertEqual(0o644, path.stat().st_mode & 0o777)

    def test_link_cannot_bypass_loader_guards(self):
        with tempfile.TemporaryDirectory(dir=self.fixture_root) as directory:
            path = Path(directory) / 'private/credentials.json'
            credentials.write_new_json(path, configured())
            link = path.with_name('link.json')
            link.symlink_to(path)
            with self.assertRaises(credentials.ConfigurationError):
                credentials.read_json(link)


class PhysicalSandboxGuardsTests(unittest.TestCase):
    # Always runs on the real filesystem, even when unit fixtures use pyfakefs.
    def test_repository_destination_is_denied_before_file_creation(self):
        path = ROOT / 'must-not-create-private-fixture.json'
        self.assertFalse(path.exists())
        with self.assertRaises(credentials.ConfigurationError):
            credentials.write_new_json(path, configured())
        self.assertFalse(path.exists())

    @unittest.skipUnless(os.name == 'posix', 'POSIX permission guard')
    def test_insecure_temporary_ancestor_is_denied_on_real_filesystem(self):
        with tempfile.TemporaryDirectory() as directory:
            path = Path(directory) / 'private/credentials.json'
            # Do not change /tmp, HOME or parent permissions to force a pass.
            ancestor = Path(directory).parent
            if not ancestor.stat().st_mode & 0o022:
                # Create an insecure ancestor owned by this fixture when the
                # runner's default temp root is already secure.
                ancestor = Path(directory) / 'insecure'
                ancestor.mkdir(mode=0o777)
                ancestor.chmod(0o777)
                path = ancestor / 'private/credentials.json'
            with self.assertRaises(credentials.ConfigurationError):
                credentials.write_new_json(path, configured())
            self.assertFalse(path.exists())
