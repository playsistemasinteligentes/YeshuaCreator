import errno
import os
from pathlib import Path
import sys
import tempfile
import unittest
from unittest.mock import patch

from test_rotation import render


class CreationMetadataTests(unittest.TestCase):
    def test_linux_records_creation_in_the_open_file_without_replacing_existing_value(self):
        with tempfile.TemporaryDirectory() as folder:
            path = Path(folder) / "video.mp4"
            path.write_bytes(b"video")
            with patch.object(sys, "platform", "linux"), patch.object(os, "XATTR_CREATE", 1, create=True), \
                 patch.object(os, "setxattr", create=True) as setter, patch.object(render.time, "time", return_value=123):
                render._record_creation(path)
            descriptor, name, value, flags = setter.call_args.args
            self.assertIsInstance(descriptor, int)
            self.assertEqual(("user.yeshua.created_at_unix", b"123", 1), (name, value, flags))

    def test_existing_creation_is_preserved_but_other_errors_fail_the_write(self):
        with tempfile.TemporaryDirectory() as folder:
            path = Path(folder) / "video.mp4"
            path.write_bytes(b"video")
            with patch.object(sys, "platform", "linux"), patch.object(os, "XATTR_CREATE", 1, create=True), \
                 patch.object(os, "setxattr", side_effect=OSError(errno.EEXIST, "exists"), create=True):
                render._record_creation(path)
            with patch.object(sys, "platform", "linux"), patch.object(os, "XATTR_CREATE", 1, create=True), \
                 patch.object(os, "setxattr", side_effect=OSError(errno.ENOTSUP, "unsupported"), create=True), self.assertRaises(OSError):
                render._record_creation(path)

    def test_non_linux_development_does_not_call_linux_attribute_api(self):
        with patch.object(sys, "platform", "win32"), patch.object(os, "setxattr", create=True) as setter:
            render._record_creation(Path("not-opened"))
        setter.assert_not_called()


if __name__ == "__main__":
    unittest.main()
