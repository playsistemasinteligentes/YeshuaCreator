using System.Diagnostics;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Text.Json.Serialization.Metadata;

namespace Memorias.YouTube;

public sealed class EncryptedYouTubeAccountRepository(YouTubeOptions options) : IYouTubeAccountRepository
{
    public Task<IYouTubeAccountLease> AcquireAsync(YouTubeOwner owner, CancellationToken cancellationToken) =>
        AcquireAsync(owner, "account.lock", cancellationToken);

    public Task<IYouTubeAccountLease> AcquireUploadAsync(YouTubeOwner owner, int publicationId, CancellationToken cancellationToken) =>
        AcquireAsync(owner, UploadPurpose(publicationId) + ".lock", cancellationToken);

    private async Task<IYouTubeAccountLease> AcquireAsync(YouTubeOwner owner, string lockName, CancellationToken cancellationToken)
    {
        owner.Validate();
        if (!options.Configured)
            throw new YouTubeConnectionException("Conexao YouTube nao configurada no servidor.");

        var scope = Convert.ToHexString(SHA256.HashData(Encoding.UTF8.GetBytes(options.ProcessingScope)));
        var directory = Path.Combine(options.CredentialsDirectory, scope, "tenants", owner.TenantId.ToString());
        Directory.CreateDirectory(directory);
        if (!OperatingSystem.IsWindows())
            File.SetUnixFileMode(directory, UnixFileMode.UserRead | UnixFileMode.UserWrite | UnixFileMode.UserExecute);
        var started = Stopwatch.GetTimestamp();
        while (true)
        {
            cancellationToken.ThrowIfCancellationRequested();
            try
            {
                var fileLock = new FileStream(Path.Combine(directory, lockName), FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.None);
                return new Lease(fileLock, directory, owner, options);
            }
            catch (IOException) when (Stopwatch.GetElapsedTime(started) < TimeSpan.FromSeconds(30))
            {
                await Task.Delay(50, cancellationToken);
            }
        }
    }

    private static string UploadPurpose(int publicationId) => publicationId > 0
        ? "upload-" + publicationId.ToString(System.Globalization.CultureInfo.InvariantCulture)
        : throw new YouTubeConnectionException("Publicacao invalida.");

    private sealed class Lease(FileStream fileLock, string directory, YouTubeOwner owner, YouTubeOptions options) : IYouTubeAccountLease
    {
        private readonly byte[] _key = Convert.FromBase64String(options.EncryptionKey);

        public YouTubeAccount? ReadAccount(string connectionId) => Read(ConnectionPurpose(connectionId), YouTubeStorageJson.Default.YouTubeAccount);
        public YouTubeAuthorization? ReadAuthorization(string state) => Read(AuthorizationPurpose(state), YouTubeStorageJson.Default.YouTubeAuthorization);
        public void SaveAccount(YouTubeAccount account) => Write(ConnectionPurpose(account.ConnectionId), account, YouTubeStorageJson.Default.YouTubeAccount);
        public void SaveAuthorization(YouTubeAuthorization authorization) => Write(AuthorizationPurpose(authorization.State), authorization, YouTubeStorageJson.Default.YouTubeAuthorization);
        public void DeleteAuthorization(string state) => File.Delete(Path.Combine(directory, AuthorizationPurpose(state) + ".bin"));
        public YouTubeUploadState? ReadUpload(int publicationId) => Read(UploadPurpose(publicationId), YouTubeStorageJson.Default.YouTubeUploadState);
        public void SaveUpload(YouTubeUploadState state) => Write(UploadPurpose(state.PublicationId), state, YouTubeStorageJson.Default.YouTubeUploadState);

        public IReadOnlyList<YouTubeAccount> ReadAccounts()
        {
            var accounts = new List<YouTubeAccount>();
            foreach (var path in Directory.EnumerateFiles(directory, "connection-*.bin"))
            {
                var id = Path.GetFileNameWithoutExtension(path)["connection-".Length..];
                var account = ReadAccount(id);
                if (account != null) accounts.Add(account);
            }
            return accounts;
        }

        public void RemoveExpiredAuthorizations(DateTime now)
        {
            foreach (var path in Directory.EnumerateFiles(directory, "authorization-*.bin"))
            {
                var state = Path.GetFileNameWithoutExtension(path)["authorization-".Length..];
                if (ReadAuthorization(state)?.ExpiresAtUtc <= now) DeleteAuthorization(state);
            }
        }

        public void CancelAuthorizations(string connectionId)
        {
            foreach (var path in Directory.EnumerateFiles(directory, "authorization-*.bin"))
            {
                var state = Path.GetFileNameWithoutExtension(path)["authorization-".Length..];
                if (ReadAuthorization(state)?.ConnectionId == connectionId) DeleteAuthorization(state);
            }
        }

        private static string ConnectionPurpose(string id)
        {
            if (!Guid.TryParseExact(id, "N", out var parsed) || parsed == Guid.Empty)
                throw new YouTubeConnectionException("Identificacao de conexao invalida.");
            return "connection-" + parsed.ToString("N");
        }

        private static string AuthorizationPurpose(string state)
        {
            if (state.Length != 64 || !state.All(char.IsAsciiHexDigit))
                throw new YouTubeConnectionException("Identificacao de autorizacao invalida.");
            return "authorization-" + state;
        }

        private byte[] AssociatedData(string purpose) => Encoding.UTF8.GetBytes(
            $"Memorias.YouTube.v2:{options.ProcessingScope}:{owner.TenantId}:{purpose}");

        private T? Read<T>(string purpose, JsonTypeInfo<T> typeInfo) where T : class
        {
            var path = Path.Combine(directory, purpose + ".bin");
            if (!File.Exists(path)) return null;
            var info = new FileInfo(path);
            if (info.Length is < 29 or > 65536)
                throw new YouTubeConnectionException("Credencial YouTube invalida. Reconecte sua conta.");
            var bytes = File.ReadAllBytes(path);
            var plain = new byte[bytes.Length - 29];
            try
            {
                if (bytes[0] != 1) throw new CryptographicException();
                using var aes = new AesGcm(_key, 16);
                aes.Decrypt(bytes.AsSpan(1, 12), bytes.AsSpan(29), bytes.AsSpan(13, 16), plain, AssociatedData(purpose));
                return JsonSerializer.Deserialize(plain, typeInfo);
            }
            catch (Exception exception) when (exception is CryptographicException or JsonException)
            {
                throw new YouTubeConnectionException("Credencial YouTube invalida. Reconecte sua conta.");
            }
            finally { CryptographicOperations.ZeroMemory(plain); }
        }

        private void Write<T>(string purpose, T value, JsonTypeInfo<T> typeInfo)
        {
            var plain = JsonSerializer.SerializeToUtf8Bytes(value, typeInfo);
            var bytes = new byte[29 + plain.Length];
            bytes[0] = 1;
            RandomNumberGenerator.Fill(bytes.AsSpan(1, 12));
            try
            {
                using var aes = new AesGcm(_key, 16);
                aes.Encrypt(bytes.AsSpan(1, 12), plain, bytes.AsSpan(29), bytes.AsSpan(13, 16), AssociatedData(purpose));
                var path = Path.Combine(directory, purpose + ".bin");
                var temporary = path + "." + Guid.NewGuid().ToString("N") + ".tmp";
                try
                {
                    using (var stream = new FileStream(temporary, FileMode.CreateNew, FileAccess.Write, FileShare.None))
                    {
                        if (!OperatingSystem.IsWindows())
                            File.SetUnixFileMode(temporary, UnixFileMode.UserRead | UnixFileMode.UserWrite);
                        stream.Write(bytes);
                        stream.Flush(true);
                    }
                    File.Move(temporary, path, true);
                }
                finally { File.Delete(temporary); }
            }
            finally { CryptographicOperations.ZeroMemory(plain); }
        }

        public void Dispose()
        {
            CryptographicOperations.ZeroMemory(_key);
            fileLock.Dispose();
        }
    }
}

[JsonSerializable(typeof(YouTubeAccount))]
[JsonSerializable(typeof(YouTubeAuthorization))]
[JsonSerializable(typeof(YouTubeUploadState))]
internal partial class YouTubeStorageJson : JsonSerializerContext;
