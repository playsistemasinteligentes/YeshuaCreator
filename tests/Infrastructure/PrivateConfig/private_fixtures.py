"""Test-only fixture isolation. Never relaxes the production loader's guards.

Default: a real, secure home/private runner directory. For restricted runners,
YESHUA_PRIVATE_TEST_FILESYSTEM=virtual explicitly selects pyfakefs for unit tests.
This does not establish real Linux permissions/Windows ACL integration coverage.
"""
import os
from pathlib import Path
import unittest
from unittest.mock import patch


class PrivateFixtureTestCase(unittest.TestCase):
    def setUp(self):
        super().setUp()
        mode = os.environ.get("YESHUA_PRIVATE_TEST_FILESYSTEM", "real")
        if mode not in ("real", "virtual"):
            raise ValueError("YESHUA_PRIVATE_TEST_FILESYSTEM must be real or virtual")
        from test_credentials import ROOT, credentials
        if mode == "virtual":
            if os.name == "nt":
                raise ValueError("Use the real Windows runner for ACL/launcher integration")
            # Missing dependency is an error, never a skip or silent fallback.
            from pyfakefs.fake_filesystem_unittest import Patcher
            patcher = Patcher()
            patcher.setUp()
            self.addCleanup(patcher.tearDown)
            # pyfakefs starts its root with 0777; model a secure host root.
            patcher.fs.chmod("/", 0o755)
            patcher.fs.add_real_file(ROOT / "infra/private/credentials.example.json", read_only=True)
            # pyfakefs 6.3.2 applies the mode argument even to O_RDONLY on an
            # existing file (fake_os.open), unlike POSIX. Preserve that file's
            # current mode; retain O_EXCL/O_NOFOLLOW and all error checks.
            fake_open = os.open
            def posix_open(path, flags, mode=0o777, *, dir_fd=None):
                try:
                    mode = os.stat(path, dir_fd=dir_fd).st_mode & 0o7777
                except FileNotFoundError:
                    pass
                return fake_open(path, flags, mode, dir_fd=dir_fd)
            low_level_open = patch.object(os, "open", posix_open)
            low_level_open.start()
            self.addCleanup(low_level_open.stop)
            self.fixture_root = Path("/home/yeshua-private-unit-fixtures")
            self.fixture_root.mkdir(parents=True, mode=0o700)
        else:
            self.fixture_root = Path(os.environ.get("YESHUA_PRIVATE_TEST_ROOT", str(Path.home())))
        # No test should consult the operator's real legacy vault. A test that
        # exercises an existing vault explicitly overrides this absent fixture.
        legacy = patch.object(credentials, "LEGACY_MEMORIAS_ROOT", self.fixture_root / "absent-legacy-fixture")
        legacy.start()
        self.addCleanup(legacy.stop)
