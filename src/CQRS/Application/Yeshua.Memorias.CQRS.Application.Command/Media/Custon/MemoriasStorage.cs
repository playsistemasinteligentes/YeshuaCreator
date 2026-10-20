using Command.Interfaces.Patterns.FileStore;
using Dominio.Media;

namespace Command.Media;

public static class MemoriasStorage
{
    public static readonly StorageLocation Photos = StorageLocation.Volatile.For("memorias", "photos");
    public static readonly StorageLocation Publications = StorageLocation.Volatile.For("memorias", "publicacoes");
    public static readonly StorageLocation Music = StorageLocation.Volatile.For("memorias", "music");

    public static StoragePath MusicPath(MusicTrack track) => StoragePathBuilder.Build(Music, track.FileName);
    public static StoragePath PublicationPath(int publicationId, string fileName) =>
        StoragePathBuilder.Build(Publications, $"{publicationId}/{fileName}");
}
