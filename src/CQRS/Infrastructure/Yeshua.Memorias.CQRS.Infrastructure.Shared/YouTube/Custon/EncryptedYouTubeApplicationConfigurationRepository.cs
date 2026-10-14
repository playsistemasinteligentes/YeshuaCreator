using System.Diagnostics;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Memorias.YouTube;

public sealed class EncryptedYouTubeApplicationConfigurationRepository(YouTubeOptions baseline) : IYouTubeApplicationConfigurationRepository
{
    private string Scope => Convert.ToHexString(SHA256.HashData(Encoding.UTF8.GetBytes(baseline.ProcessingScope)));
    private string DirectoryPath => Path.Combine(baseline.CredentialsDirectory, "configuration", Scope);
    private byte[] AssociatedData => Encoding.UTF8.GetBytes("Memorias.YouTube.configuration.v1:" + baseline.ProcessingScope);

    public YouTubeApplicationConfiguration? Read()
    {
        if (!Path.IsPathFullyQualified(baseline.CredentialsDirectory) || string.IsNullOrWhiteSpace(baseline.ProcessingScope)) return null;
        var path = Path.Combine(DirectoryPath, "oauth.bin");
        if (!File.Exists(path)) return null;
        try
        {
            if (new FileInfo(path).Length is < 29 or > 8192) throw new CryptographicException();
            var key = ReadKey();
            var bytes = File.ReadAllBytes(path);
            var plain = new byte[bytes.Length - 29];
            try
            {
                if (bytes[0] != 1) throw new CryptographicException();
                using var aes = new AesGcm(key, 16);
                aes.Decrypt(bytes.AsSpan(1, 12), bytes.AsSpan(29), bytes.AsSpan(13, 16), plain, AssociatedData);
                var value = JsonSerializer.Deserialize(plain, YouTubeConfigurationJson.Default.StoredYouTubeConfiguration)
                    ?? throw new CryptographicException();
                return new(value.ClientId, value.ClientSecret, Convert.ToBase64String(key), value.UpdatedAtUtc);
            }
            finally { CryptographicOperations.ZeroMemory(plain); CryptographicOperations.ZeroMemory(key); }
        }
        catch (Exception error) when (error is IOException or UnauthorizedAccessException or CryptographicException or JsonException)
        { throw new YouTubeConnectionException("Configuracao privada YouTube indisponivel. Necessaria revisao do administrador."); }
    }

    public async Task<YouTubeApplicationConfiguration> SaveAsync(string clientId, string clientSecret, CancellationToken cancellationToken)
    {
        if (!Path.IsPathFullyQualified(baseline.CredentialsDirectory) || string.IsNullOrWhiteSpace(baseline.ProcessingScope))
            throw new YouTubeConnectionException("Armazenamento privado YouTube nao configurado.");
        try
        {
            CreatePrivateDirectory(baseline.CredentialsDirectory);
            CreatePrivateDirectory(Path.Combine(baseline.CredentialsDirectory, "configuration"));
            CreatePrivateDirectory(DirectoryPath);
            using var lease = await AcquireAsync(cancellationToken);
            var existing = Read();
            if (existing != null && existing.ClientId != clientId)
                throw new YouTubeConnectionException("O Client ID ja esta vinculado ao aplicativo.");
            var key = LoadOrCreateKey();
            var value = new StoredYouTubeConfiguration(clientId,
                string.IsNullOrEmpty(clientSecret) ? existing?.ClientSecret ?? baseline.ClientSecret : clientSecret, DateTime.UtcNow);
            var plain = JsonSerializer.SerializeToUtf8Bytes(value, YouTubeConfigurationJson.Default.StoredYouTubeConfiguration);
            var bytes = new byte[29 + plain.Length];
            try
            {
                bytes[0] = 1; RandomNumberGenerator.Fill(bytes.AsSpan(1, 12));
                using var aes = new AesGcm(key, 16);
                aes.Encrypt(bytes.AsSpan(1, 12), plain, bytes.AsSpan(29), bytes.AsSpan(13, 16), AssociatedData);
                WriteAtomic(Path.Combine(DirectoryPath, "oauth.bin"), bytes);
                return new(clientId, clientSecret, Convert.ToBase64String(key), value.UpdatedAtUtc);
            }
            finally { CryptographicOperations.ZeroMemory(plain); CryptographicOperations.ZeroMemory(key); }
        }
        catch (Exception error) when (error is IOException or UnauthorizedAccessException or CryptographicException)
        { throw new YouTubeConnectionException("Nao foi possivel salvar a configuracao privada YouTube."); }
    }

    private byte[] ReadKey()
    {
        var path = Path.Combine(DirectoryPath, "key.bin");
        if (new FileInfo(path).Length != 32) throw new CryptographicException();
        return File.ReadAllBytes(path);
    }

    private byte[] LoadOrCreateKey()
    {
        var path = Path.Combine(DirectoryPath, "key.bin");
        if (File.Exists(path)) return ReadKey();
        byte[] key;
        try { key = Convert.FromBase64String(baseline.EncryptionKey); }
        catch (FormatException) { key = []; }
        if (key.Length != 32)
        {
            var accounts = Path.Combine(baseline.CredentialsDirectory, Scope);
            if (File.Exists(Path.Combine(DirectoryPath, "oauth.bin"))
                || (Directory.Exists(accounts) && Directory.EnumerateFiles(accounts, "*.bin", SearchOption.AllDirectories).Any()))
                throw new YouTubeConnectionException("Chave de protecao existente indisponivel. Nao sera gerada uma substituta.");
            key = RandomNumberGenerator.GetBytes(32);
        }
        try { WriteAtomic(path, key); return key; }
        catch { CryptographicOperations.ZeroMemory(key); throw; }
    }

    private async Task<FileStream> AcquireAsync(CancellationToken cancellationToken)
    {
        var started = Stopwatch.GetTimestamp();
        while (true)
        {
            cancellationToken.ThrowIfCancellationRequested();
            try { return new FileStream(Path.Combine(DirectoryPath, "write.lock"), FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.None); }
            catch (IOException) when (Stopwatch.GetElapsedTime(started) < TimeSpan.FromSeconds(30))
            { await Task.Delay(50, cancellationToken); }
        }
    }

    private static void CreatePrivateDirectory(string path)
    {
        Directory.CreateDirectory(path);
        if (!OperatingSystem.IsWindows()) File.SetUnixFileMode(path, UnixFileMode.UserRead | UnixFileMode.UserWrite | UnixFileMode.UserExecute);
    }

    private static void WriteAtomic(string path, byte[] bytes)
    {
        var temporary = path + "." + Guid.NewGuid().ToString("N") + ".tmp";
        try
        {
            using (var stream = new FileStream(temporary, FileMode.CreateNew, FileAccess.Write, FileShare.None))
            {
                if (!OperatingSystem.IsWindows()) File.SetUnixFileMode(temporary, UnixFileMode.UserRead | UnixFileMode.UserWrite);
                stream.Write(bytes); stream.Flush(true);
            }
            File.Move(temporary, path, true);
        }
        finally { File.Delete(temporary); }
    }
}

internal sealed record StoredYouTubeConfiguration(string ClientId, string ClientSecret, DateTime UpdatedAtUtc);
[JsonSerializable(typeof(StoredYouTubeConfiguration))]
internal partial class YouTubeConfigurationJson : JsonSerializerContext;
