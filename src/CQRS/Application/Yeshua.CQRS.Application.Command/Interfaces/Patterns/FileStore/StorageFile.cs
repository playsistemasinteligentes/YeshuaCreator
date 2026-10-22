using System.Globalization;
using System.Runtime.InteropServices;
using System.Text;

namespace Command.Interfaces.Patterns.FileStore;

public static class StorageFile
{
    public const string CreationAttribute = "user.yeshua.created_at_unix";

    public static FileStream OpenWrite(string path)
    {
        var stream = new FileStream(path, FileMode.Create, FileAccess.Write);
        try
        {
            RecordCreation(stream);
            return stream;
        }
        catch
        {
            stream.Dispose();
            throw;
        }
    }

    public static void WriteAllText(string path, string content, Encoding encoding)
    {
        using var stream = OpenWrite(path);
        using var writer = new StreamWriter(stream, encoding);
        writer.Write(content);
    }

    private static void RecordCreation(FileStream stream)
    {
        // The Linux fallback is attached to the inode; no sidecar, table or refreshed TTL.
        // Local Windows development keeps its native file creation timestamp.
        if (!OperatingSystem.IsLinux()) return;
        var value = Encoding.ASCII.GetBytes(DateTimeOffset.UtcNow.ToUnixTimeSeconds().ToString(CultureInfo.InvariantCulture));
        var handle = stream.SafeFileHandle;
        var retained = false;
        try
        {
            handle.DangerousAddRef(ref retained);
            if (SetAttribute(handle.DangerousGetHandle().ToInt32(), CreationAttribute, value, (nuint)value.Length, 1) == 0)
                return;
            var error = Marshal.GetLastPInvokeError();
            if (error != 17) // XATTR_CREATE preserves the original value (EEXIST).
                throw new IOException($"Cannot record storage file creation metadata (errno {error}).");
        }
        finally
        {
            if (retained) handle.DangerousRelease();
        }
    }

    [DllImport("libc", EntryPoint = "fsetxattr", SetLastError = true)]
    private static extern int SetAttribute(int descriptor, [MarshalAs(UnmanagedType.LPUTF8Str)] string name,
        byte[] value, nuint size, int flags);
}
