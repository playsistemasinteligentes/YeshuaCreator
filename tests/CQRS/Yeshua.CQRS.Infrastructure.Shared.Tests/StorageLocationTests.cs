using Command.Interfaces.Patterns.FileStore;
using Microsoft.Extensions.Options;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shered.Patterns.FileStore;

namespace Yeshua.CQRS.Infrastructure.Shared.Tests;

[TestClass]
public class StorageLocationTests
{
    [DataTestMethod]
    [DataRow("../outside")]
    [DataRow("volatile/app/../secret")]
    [DataRow("persistent/app/./file")]
    [DataRow("persistent//file")]
    [DataRow("/persistent/file")]
    [DataRow("C:\\secret")]
    [DataRow("unclassified/file")]
    public void UnclassifiedOrEscapingPathsAreRejected(string value) =>
        Assert.ThrowsException<ArgumentException>(() => new StoragePath(value));

    [TestMethod]
    public void NewApplicationTenantAndNestedFilesInheritTheirLocation()
    {
        var persistent = StorageLocation.Persistent.For("new-app", "documents");
        var volatileArea = StorageLocation.Volatile.For("new-app", "render");
        Assert.AreEqual("persistent/new-app/documents/42/7/nested/file.xml",
            StoragePathBuilder.Build(persistent, "42", "7/nested", "file.xml").Value.Replace('\\', '/'));
        Assert.AreEqual("volatile/new-app/render/42/video.mp4",
            StoragePathBuilder.Build(volatileArea, "42/video.mp4").Value.Replace('\\', '/'));
    }

    [TestMethod]
    public void ExistingPathsCannotImpersonateAnotherLocationByPrefix()
    {
        var location = StorageLocation.Volatile.For("app", "photos");
        Assert.ThrowsException<InvalidOperationException>(() =>
            StoragePathBuilder.BuildFromFullPath(location, "volatile/app/photos-other/file.png"));
        Assert.ThrowsException<ArgumentException>(() => StoragePathBuilder.Build(location, "../file.png"));
        Assert.ThrowsException<ArgumentException>(() => StorageLocation.Persistent.For("../app", "docs"));
        Assert.ThrowsException<ArgumentException>(() => StorageLocation.Persistent.For("app", "/docs"));
    }

    [TestMethod]
    public async Task DiskWritesStayUnderTheConfiguredRootAndResolverRequiresSegmentBoundary()
    {
        var root = Path.Combine(Path.GetTempPath(), "yeshua-storage-test-" + Guid.NewGuid().ToString("N"));
        var settings = Options.Create(new StorageSettings
        {
            Providers = new() { ["Disk"] = new() { Root = root, BaseUrl = "/storage" } },
            Locations = new() { ["persistent/new-app/docs"] = "Disk" }
        });
        var provider = new DiskStorageProvider(settings);
        var resolver = new StorageResolver(settings, new[] { provider });
        var path = StoragePathBuilder.Build(StorageLocation.Persistent.For("new-app", "docs"), "tenant/new/sub/file.txt");
        try
        {
            Assert.AreSame(provider, resolver.Resolve(path));
            Assert.ThrowsException<Exception>(() => resolver.Resolve(new StoragePath("persistent/new-app/docs-other/file.txt")));
            await provider.SaveAsync(new MemoryStream(new byte[] { 1, 2, 3 }), path, CancellationToken.None);
            Assert.IsTrue(File.Exists(path.ResolveUnder(root)));
            using var stream = provider.OpenRead(path);
            Assert.AreEqual(3L, stream.Length);
        }
        finally
        {
            if (Directory.Exists(root)) Directory.Delete(root, recursive: true);
        }
    }
}
