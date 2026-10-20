using Command.Receivers;

namespace Yeshua.Fiscal.Tests;

[CollectionDefinition("FiscalStorageEnvironment", DisableParallelization = true)]
public class FiscalStorageEnvironmentCollection { }

[Collection("FiscalStorageEnvironment")]
[Trait("Category", "BusinessSmoke")]
public class FiscalStorageTests : IDisposable
{
    private readonly string _root = Path.Combine(Path.GetTempPath(), "yeshua-fiscal-storage-test-" + Guid.NewGuid().ToString("N"));
    private readonly Dictionary<string, string?> _original = new();

    public FiscalStorageTests()
    {
        foreach (var variable in new[] { "YESHUA_FISCAL_STORAGE_ROOT", "YESHUA_SEFAZ_STORAGE_ROOT", "YESHUA_FISCAL_PRIVATE_ROOT" })
        {
            _original[variable] = Environment.GetEnvironmentVariable(variable);
            Environment.SetEnvironmentVariable(variable, Path.Combine(_root, variable.EndsWith("PRIVATE_ROOT") ? "private" : "storage"));
        }
    }

    [Fact]
    public void EmissionPlanIsVolatileAndHashIsStillChecked()
    {
        var result = FiscalPayloadStore.SaveEmissionPlan("carga-1", "{\"version\":1}");
        Assert.StartsWith(Path.Combine(_root, "storage", "volatile", "fiscal", "planos-emissao"), result.Path);
        Assert.Equal("{\"version\":1}", FiscalPayloadStore.Read(result.Path, result.Sha256));
        Assert.Throws<InvalidOperationException>(() => FiscalPayloadStore.Read(result.Path, "wrong-hash"));
    }

    [Fact]
    public void SefazResponseIsVolatileAndCannotTraverseTheStorageRoot()
    {
        var result = SefazFiscalDocumentStore.SalvarXmlResposta("cte", "consulta", "123", "<response />");
        Assert.StartsWith(Path.Combine(_root, "storage", "volatile", "fiscal", "sefaz", "cte", "consulta"), result.Path);
        Assert.Equal("<response />", File.ReadAllText(result.Path));
        Assert.Throws<ArgumentException>(() => SefazFiscalDocumentStore.SalvarXmlResposta("../../outside", "consulta", "123", "<response />"));
    }

    [Fact]
    public async Task CertificateAndPasswordStayPersistentAndOutsidePublicStorage()
    {
        var result = await FiscalPayloadStore.SaveCertificateAsync(7, "12345678901", "AABB", new byte[] { 1, 2 }, "fixture-only", CancellationToken.None);
        Assert.StartsWith(Path.Combine(_root, "private", "persistent", "fiscal", "certificados", "7"), result.CertificatePath);
        Assert.Equal(new byte[] { 1, 2 }, await File.ReadAllBytesAsync(result.CertificatePath));
        Assert.Equal("fixture-only", await File.ReadAllTextAsync(result.PasswordPath));
        Environment.SetEnvironmentVariable("YESHUA_FISCAL_PRIVATE_ROOT", Path.Combine(_root, "storage", "private"));
        await Assert.ThrowsAsync<InvalidOperationException>(() =>
            FiscalPayloadStore.SaveCertificateAsync(7, "12345678901", "AABB", new byte[] { 1 }, "fixture-only", CancellationToken.None));
    }

    public void Dispose()
    {
        foreach (var variable in _original) Environment.SetEnvironmentVariable(variable.Key, variable.Value);
        if (Directory.Exists(_root)) Directory.Delete(_root, recursive: true);
    }
}
