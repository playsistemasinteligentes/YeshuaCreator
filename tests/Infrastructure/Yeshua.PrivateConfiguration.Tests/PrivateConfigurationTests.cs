using Command.Receivers;
using Command.Receivers.Custon.UseCases.FileUpload.Infra;
using Microsoft.VisualStudio.TestTools.UnitTesting;

[assembly: DoNotParallelize]

namespace Yeshua.PrivateConfiguration.Tests;

[TestClass]
public class PrivateConfigurationTests
{
    [TestMethod]
    public void InfrastructureDefaultsDoNotProvideCredentials()
    {
        var broker = new Shared.InterfacesConcrete.Queue.RabbitMQ.RabbitMqOptions();
        Assert.AreEqual(string.Empty, broker.UserName);
        Assert.AreEqual(string.Empty, broker.Password);
        Assert.AreEqual(string.Empty, new JwtSettings().SecretKey);
    }

    [TestMethod]
    public void UploadRequiresConfiguredKeyAndPreservesTokenContract()
    {
        Assert.ThrowsException<InvalidOperationException>(() => new UploadTokenHelper(""));
        var first = new UploadTokenHelper(new string('a', 64));
        var replica = new UploadTokenHelper(new string('a', 64));
        var different = new UploadTokenHelper(new string('b', 64));
        var token = first.Generate(12, 34, 56);
        Assert.AreEqual((12, 34, 56), replica.ValidateAndExtract(token));
        Assert.ThrowsException<Exception>(() => different.ValidateAndExtract(token));
    }

    [TestMethod]
    public async Task CertificateUsesPrivateTenantAndOwnerHierarchy()
    {
        var temporary = Path.GetFullPath(Path.Combine(Path.GetTempPath(), "Yeshua.PrivateConfiguration.Tests"));
        var directory = Path.Combine(temporary, Guid.NewGuid().ToString("N"));
        var previous = Environment.GetEnvironmentVariable("YESHUA_FISCAL_PRIVATE_ROOT");
        try
        {
            Environment.SetEnvironmentVariable("YESHUA_FISCAL_PRIVATE_ROOT", directory);
            var result = await FiscalPayloadStore.SaveCertificateAsync(10, "12345678000199", "AB12", [1, 2, 3], "fixture-secret", default);
            var expected = Path.Combine(directory, "tenants", "10", "titulares", "12345678000199", "certificados", "AB12");
            Assert.AreEqual(Path.Combine(expected, "certificado.pfx"), result.CertificatePath);
            CollectionAssert.AreEqual(new byte[] { 1, 2, 3 }, await File.ReadAllBytesAsync(result.CertificatePath));
            Assert.AreEqual("fixture-secret", await File.ReadAllTextAsync(result.PasswordPath));
            await Assert.ThrowsExceptionAsync<ArgumentException>(() =>
                FiscalPayloadStore.SaveCertificateAsync(10, "..", "AB12", [1], "fixture", default));
        }
        finally
        {
            Environment.SetEnvironmentVariable("YESHUA_FISCAL_PRIVATE_ROOT", previous);
            if (Path.GetFullPath(directory).StartsWith(temporary + Path.DirectorySeparatorChar, StringComparison.OrdinalIgnoreCase)
                && Directory.Exists(directory))
                Directory.Delete(directory, true);
        }
    }

    [TestMethod]
    public async Task CertificateCannotFallBackToPublicStorage()
    {
        var previous = Environment.GetEnvironmentVariable("YESHUA_FISCAL_PRIVATE_ROOT");
        var storage = Environment.GetEnvironmentVariable("YESHUA_FISCAL_STORAGE_ROOT");
        try
        {
            Environment.SetEnvironmentVariable("YESHUA_FISCAL_PRIVATE_ROOT", null);
            await Assert.ThrowsExceptionAsync<InvalidOperationException>(() =>
                FiscalPayloadStore.SaveCertificateAsync(10, "12345678000199", "AB12", [1], "fixture", default));
            Environment.SetEnvironmentVariable("YESHUA_FISCAL_PRIVATE_ROOT", Path.GetTempPath());
            Environment.SetEnvironmentVariable("YESHUA_FISCAL_STORAGE_ROOT", Path.GetTempPath());
            await Assert.ThrowsExceptionAsync<InvalidOperationException>(() =>
                FiscalPayloadStore.SaveCertificateAsync(10, "12345678000199", "AB12", [1], "fixture", default));
        }
        finally
        {
            Environment.SetEnvironmentVariable("YESHUA_FISCAL_PRIVATE_ROOT", previous);
            Environment.SetEnvironmentVariable("YESHUA_FISCAL_STORAGE_ROOT", storage);
        }
    }
}
