using System.Text;
using Migration.Dominio;

namespace TestMigration;

[TestClass]
public sealed class ContextGenerationTests
{
    [TestMethod]
    public void GenerationWritesSourcesAndPreservesCustomWithoutTouchingLegacyContext()
    {
        var testRoot = Path.GetFullPath(Path.Combine(Path.GetTempPath(), "Yeshua.Engine.Tests"));
        var directory = Path.GetFullPath(Path.Combine(testRoot, Guid.NewGuid().ToString("N")));
        var context = Path.Combine(Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory)!.Parent!.Parent!.Parent!.FullName, "Contexto.txt");
        var before = Stamp(context);
        try
        {
            Directory.CreateDirectory(directory);
            var generator = new SampleGenerator();
            var generated = Path.Combine(directory, "Generated.cs");
            var custom = Path.Combine(directory, "Custom.cs");
            File.WriteAllText(custom, "custom-owned");
            generator.WriteCode(new StringBuilder("class Generated_" + Guid.NewGuid().ToString("N") + " {}"), generated, false, true);
            generator.WriteCode(new StringBuilder("replacement"), custom, true, true);
#pragma warning disable CS0618 // Verify legacy external callers are inert too.
            generator.WriteContexto("legacy-" + Guid.NewGuid().ToString("N"));
#pragma warning restore CS0618
            StringAssert.Contains(File.ReadAllText(generated), "class Generated_");
            Assert.AreEqual("custom-owned", File.ReadAllText(custom));
            Assert.AreEqual(before, Stamp(context), "Generation must not create, append, rewrite or delete Contexto.txt.");
        }
        finally
        {
            if (directory.StartsWith(testRoot + Path.DirectorySeparatorChar, StringComparison.OrdinalIgnoreCase) && Directory.Exists(directory))
                Directory.Delete(directory, true);
        }
    }

    private static (bool Exists, long Length, DateTime Modified) Stamp(string path) => File.Exists(path)
        ? (true, new FileInfo(path).Length, File.GetLastWriteTimeUtc(path)) : (false, 0, DateTime.MinValue);

    private sealed class SampleGenerator : SourceCodeBase
    {
        protected override StringBuilder GenerateCode() => new("class Generated {}");
        protected override StringBuilder GenerateCustonCode() => new("class Custom {}");
    }
}
