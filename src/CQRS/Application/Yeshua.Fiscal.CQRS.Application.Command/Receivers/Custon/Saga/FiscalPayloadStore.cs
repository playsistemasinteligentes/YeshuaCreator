using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace Command.Receivers
{
    internal static class FiscalPayloadStore
    {
        public static FiscalPayloadStorageResult SaveEmissionPlan(string cargaId, string json)
        {
            if (string.IsNullOrWhiteSpace(json))
                throw new InvalidOperationException("O plano de emissao fiscal nao pode ser vazio.");

            var hash = Hash(json);
            var directory = Path.Combine(StorageRoot(), "fiscal", "planos-emissao");
            Directory.CreateDirectory(directory);

            var fileName = $"{SafeFileName(cargaId)}-{hash}.json";
            var path = Path.Combine(directory, fileName);
            if (!File.Exists(path))
                File.WriteAllText(path, json, new UTF8Encoding(false));

            return new FiscalPayloadStorageResult(path, hash);
        }

        public static string Read(string path, string expectedHash)
        {
            if (string.IsNullOrWhiteSpace(path))
                throw new InvalidOperationException("O storage do plano de emissao fiscal nao foi informado.");

            if (!File.Exists(path))
                throw new FileNotFoundException("O plano de emissao fiscal nao foi encontrado no storage.", path);

            var json = File.ReadAllText(path, Encoding.UTF8);
            if (!string.IsNullOrWhiteSpace(expectedHash) &&
                !string.Equals(Hash(json), expectedHash, StringComparison.OrdinalIgnoreCase))
            {
                throw new InvalidOperationException("O hash do plano de emissao fiscal nao confere com o payload armazenado.");
            }

            return json;
        }

        public static async Task<FiscalCertificateStorageResult> SaveCertificateAsync(
            int tenantId,
            string documentoTitular,
            string thumbprint,
            byte[] pfx,
            string senha,
            CancellationToken cancellationToken)
        {
            var privateRoot = Environment.GetEnvironmentVariable("YESHUA_FISCAL_PRIVATE_ROOT");
            if (string.IsNullOrWhiteSpace(privateRoot) || !Path.IsPathFullyQualified(privateRoot))
                throw new InvalidOperationException("Configure YESHUA_FISCAL_PRIVATE_ROOT fora do storage publico.");
            if (tenantId <= 0)
                throw new ArgumentOutOfRangeException(nameof(tenantId));
            if (string.IsNullOrWhiteSpace(documentoTitular) || !documentoTitular.All(char.IsAsciiDigit)
                || string.IsNullOrWhiteSpace(thumbprint) || !thumbprint.All(char.IsAsciiHexDigit))
                throw new ArgumentException("Documento e thumbprint devem ser identificadores normalizados.");
            var root = Path.GetFullPath(privateRoot).TrimEnd(Path.DirectorySeparatorChar);
            var publicRoot = Path.GetFullPath(StorageRoot()).TrimEnd(Path.DirectorySeparatorChar);
            var comparison = OperatingSystem.IsWindows() ? StringComparison.OrdinalIgnoreCase : StringComparison.Ordinal;
            var volumeRoot = Path.GetPathRoot(Path.GetFullPath(privateRoot))!.TrimEnd(Path.DirectorySeparatorChar);
            if (root.Length == 0 || string.Equals(root, volumeRoot, comparison) || string.Equals(root, publicRoot, comparison)
                || root.StartsWith(publicRoot + Path.DirectorySeparatorChar, comparison))
                throw new InvalidOperationException("Certificados nao podem ser gravados no storage publico.");
            var directory = Path.Combine(
                privateRoot,
                "tenants",
                tenantId.ToString(),
                "titulares",
                SafeFileName(documentoTitular),
                "certificados",
                SafeFileName(thumbprint));
            Directory.CreateDirectory(directory);
            if (!OperatingSystem.IsWindows())
                File.SetUnixFileMode(directory, UnixFileMode.UserRead | UnixFileMode.UserWrite | UnixFileMode.UserExecute);

            var certificatePath = Path.Combine(directory, "certificado.pfx");
            var passwordPath = Path.Combine(directory, "senha.secret");

            await File.WriteAllBytesAsync(certificatePath, pfx, cancellationToken).ConfigureAwait(false);
            await File.WriteAllTextAsync(passwordPath, senha, new UTF8Encoding(false), cancellationToken).ConfigureAwait(false);
            if (!OperatingSystem.IsWindows())
            {
                File.SetUnixFileMode(certificatePath, UnixFileMode.UserRead | UnixFileMode.UserWrite);
                File.SetUnixFileMode(passwordPath, UnixFileMode.UserRead | UnixFileMode.UserWrite);
            }

            return new FiscalCertificateStorageResult(certificatePath, passwordPath);
        }

        private static string StorageRoot()
        {
            return Environment.GetEnvironmentVariable("YESHUA_FISCAL_STORAGE_ROOT")
                ?? Environment.GetEnvironmentVariable("STORAGE_ROOT")
                ?? Path.Combine(AppContext.BaseDirectory, "storage");
        }

        private static string Hash(string value)
        {
            var bytes = SHA256.HashData(Encoding.UTF8.GetBytes(value));
            return Convert.ToHexString(bytes).ToLowerInvariant();
        }

        private static string SafeFileName(string value)
        {
            var source = string.IsNullOrWhiteSpace(value) ? "sem-carga" : value;
            var invalid = Path.GetInvalidFileNameChars();
            var builder = new StringBuilder(source.Length);
            foreach (var character in source)
                builder.Append(Array.IndexOf(invalid, character) >= 0 ? '_' : character);

            return builder.ToString();
        }
    }

    internal sealed record FiscalPayloadStorageResult(string Path, string Sha256);
    internal sealed record FiscalCertificateStorageResult(string CertificatePath, string PasswordPath);
}
