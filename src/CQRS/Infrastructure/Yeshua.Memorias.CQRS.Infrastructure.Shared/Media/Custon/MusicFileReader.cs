using Command.Interfaces.Patterns.FileStore;
using Dominio.Media;

namespace Memorias.Media;

public sealed class MusicFileReader(IFileStorage storage)
{
    public Stream? Open(int id)
    {
        var track = VideoPresentation.FindMusic(id);
        if (track == null) return null;
        Stream? stream = null;
        try
        {
            stream = storage.OpenRead(new StoragePath(track.StorageKey));
            if (stream.CanSeek && stream.Length is > 0 and <= 25 * 1024 * 1024) return stream;
            stream.Dispose(); return null;
        }
        catch (IOException) { stream?.Dispose(); return null; }
        catch (UnauthorizedAccessException) { stream?.Dispose(); return null; }
    }
}
