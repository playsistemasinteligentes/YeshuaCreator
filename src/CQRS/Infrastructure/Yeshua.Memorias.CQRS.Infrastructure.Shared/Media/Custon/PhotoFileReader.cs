using Aplication.Interfaces.Services;
using Command.Interfaces.Patterns.FileStore;
using IRepository.Read;

namespace Memorias.Media;

public sealed class PhotoFileReader(IFotoReadRepository photos, IyFileUploadReadRepository uploads, IFileStorage storage, IExecutionContext context)
{
    public PhotoFile? Open(int photoId)
    {
        if (photoId <= 0 || context.TenantID <= 0 || context.UserId <= 0) return null;
        var photo = photos.FirstById(photoId);
        if (photo == null || photo.deleted || photo.tenantid != context.TenantID || photo.userid != context.UserId
            || photo.contenttype is not ("image/jpeg" or "image/png" or "image/webp")
            || string.IsNullOrWhiteSpace(photo.storagekey)) return null;
        var key = photo.storagekey.Replace('\\', '/');
        var prefix = $"persistent/memorias/photos/{context.TenantID}/";
        var parts = key.Split('/');
        if (!key.StartsWith(prefix, StringComparison.Ordinal) || parts.Length != 6
            || parts.Any(part => part is ".." or "." or "")
            || !int.TryParse(parts[4], System.Globalization.NumberStyles.None, System.Globalization.CultureInfo.InvariantCulture, out var uploadId)
            || uploadId <= 0) return null;
        var upload = uploads.FirstById(uploadId);
        if (upload == null || upload.deleted || upload.tenantid != context.TenantID || upload.userid != context.UserId
            || upload.type != "memorias.photo" || upload.entitytype != "Album" || upload.status != 1
            || string.IsNullOrWhiteSpace(upload.filepath)
            || !string.Equals(upload.filepath.Replace('\\', '/'), key, StringComparison.Ordinal)) return null;
        Stream? stream = null;
        try
        {
            stream = storage.OpenRead(new StoragePath(key));
            if (!stream.CanSeek || stream.Length <= 0 || stream.Length > 25 * 1024 * 1024 || stream.Length != upload.filesize)
            {
                stream.Dispose(); return null;
            }
            return new(stream, photo.contenttype);
        }
        catch (IOException) { stream?.Dispose(); return null; }
        catch (UnauthorizedAccessException) { stream?.Dispose(); return null; }
    }
}

public sealed record PhotoFile(Stream Stream, string ContentType);
