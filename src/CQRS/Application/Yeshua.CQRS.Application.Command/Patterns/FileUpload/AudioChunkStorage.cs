using Command.Interfaces.Patterns.FileStore;
using Microsoft.AspNetCore.Http;

namespace Command.Patterns.FileUpload;

// The recorder's existing ordered chunks and final merge, shared by applications.
// Locking, upload ownership and starting a saga remain in each application's use case.
public static class AudioChunkStorage
{
    public static string AudioKey(int tenantId, int uploadId, string inputNamespace = "")
    {
        if (tenantId <= 0 || uploadId <= 0 || inputNamespace.Length > 40
            || inputNamespace.Any(c => !(c is >= 'a' and <= 'z' or >= '0' and <= '9' or '-')))
            throw new InvalidOperationException("Referencia de audio invalida.");
        return $"volatile/ia/transcriptions/input/{(inputNamespace.Length == 0 ? "" : inputNamespace + "/")}{tenantId}/{uploadId}/audio.webm";
    }

    public static async Task<string?> SaveAsync(IFileStorage storage, int tenantId, int uploadId,
        IFormFile file, int index, bool final, CancellationToken cancellationToken, string inputNamespace = "")
    {
        if (file is null || file.Length <= 0 || index is < 0 or > 10000)
            throw new InvalidOperationException("Parte de audio invalida.");
        var audio = AudioKey(tenantId, uploadId, inputNamespace);
        var directory = audio[..audio.LastIndexOf('/')];
        var pending = StoragePathBuilder.BuildFromFullPath(StorageLocation.Volatile.TranscriptionsInput,
            $"{directory}/pending_merge/chunk_{index}.part");
        await storage.SaveAsync(file, pending, cancellationToken);
        if (!final) return null;
        var parts = storage.ListFiles(StoragePathBuilder.BuildFromFullPath(
            StorageLocation.Volatile.TranscriptionsInput, pending.Directory + Path.DirectorySeparatorChar))
            .Where(p => Path.GetFileName(p.Value).StartsWith("chunk_", StringComparison.Ordinal)).ToList();
        if (parts.Count != index + 1)
            throw new InvalidOperationException("Ainda faltam partes do audio. Reenvie as partes ausentes.");
        var destination = StoragePathBuilder.BuildFromFullPath(StorageLocation.Volatile.TranscriptionsInput, audio);
        using var output = storage.OpenWrite(destination);
        for (var partIndex = 0; partIndex <= index; partIndex++)
        {
            var part = parts.SingleOrDefault(p => Path.GetFileName(p.Value) == $"chunk_{partIndex}.part")
                ?? throw new InvalidOperationException("Sequencia de partes incompleta.");
            using var input = storage.OpenRead(part);
            await input.CopyToAsync(output, cancellationToken);
        }
        return destination.Value;
    }
}
