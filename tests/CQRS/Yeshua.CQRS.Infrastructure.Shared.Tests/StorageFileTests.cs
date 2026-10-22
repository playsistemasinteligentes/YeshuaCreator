using Command.Interfaces.Patterns.FileStore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Runtime.InteropServices;
using System.Text;

namespace Yeshua.CQRS.Infrastructure.Shared.Tests;

[TestClass]
public class StorageFileTests
{
    [TestMethod]
    public void WritesPreserveOriginalCreationAndDoNotCreateSidecars()
    {
        var root = Path.Combine(Path.GetTempPath(), "yeshua-creation-" + Guid.NewGuid().ToString("N"));
        Directory.CreateDirectory(root);
        var path = Path.Combine(root, "data.txt");
        try
        {
            StorageFile.WriteAllText(path, "original", new UTF8Encoding(false));
            var created = File.GetCreationTimeUtc(path);
            using (var stream = StorageFile.OpenWrite(path)) stream.Write(new byte[] { 1, 2 });
            Assert.AreEqual(2L, new FileInfo(path).Length);
            if (OperatingSystem.IsWindows()) Assert.AreEqual(created, File.GetCreationTimeUtc(path));
            Assert.AreEqual(1, Directory.GetFiles(root).Length);
        }
        finally
        {
            Directory.Delete(root, recursive: true);
        }
    }

    [TestMethod]
    public void LinuxCreationMetadataIsRecordedOnceAndSurvivesUpdates()
    {
        if (!OperatingSystem.IsLinux()) Assert.Inconclusive("Requires Linux extended file attributes.");
        var path = Path.Combine(Path.GetTempPath(), "yeshua-creation-" + Guid.NewGuid().ToString("N"));
        try
        {
            StorageFile.WriteAllText(path, "original", new UTF8Encoding(false));
            var value = new byte[64];
            using (var stream = File.OpenRead(path))
            {
                var count = GetAttribute(stream.SafeFileHandle.DangerousGetHandle().ToInt32(), StorageFile.CreationAttribute, value, (nuint)value.Length);
                Assert.IsTrue(count > 0);
                var created = long.Parse(Encoding.ASCII.GetString(value, 0, (int)count));
                Assert.IsTrue(Math.Abs(DateTimeOffset.UtcNow.ToUnixTimeSeconds() - created) < 60);
                var old = Encoding.ASCII.GetBytes("1234567890");
                Assert.AreEqual(0, SetAttribute(stream.SafeFileHandle.DangerousGetHandle().ToInt32(), StorageFile.CreationAttribute, old, (nuint)old.Length, 0));
            }
            StorageFile.WriteAllText(path, "updated", new UTF8Encoding(false));
            using var updated = File.OpenRead(path);
            var size = GetAttribute(updated.SafeFileHandle.DangerousGetHandle().ToInt32(), StorageFile.CreationAttribute, value, (nuint)value.Length);
            Assert.AreEqual("1234567890", Encoding.ASCII.GetString(value, 0, (int)size));
        }
        finally
        {
            File.Delete(path);
        }
    }

    [DllImport("libc", EntryPoint = "fgetxattr", SetLastError = true)]
    private static extern nint GetAttribute(int descriptor, [MarshalAs(UnmanagedType.LPUTF8Str)] string name, byte[] value, nuint size);

    [DllImport("libc", EntryPoint = "fsetxattr", SetLastError = true)]
    private static extern int SetAttribute(int descriptor, [MarshalAs(UnmanagedType.LPUTF8Str)] string name, byte[] value, nuint size, int flags);
}
