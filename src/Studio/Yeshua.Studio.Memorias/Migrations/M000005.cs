using Dominio.Migration;
using Migration.Dominio.Schemas.CQRS;

namespace Yeshua.Studio.Memorias.Migrations;

[Migration(000005)]
public sealed class M000005 : MigrationBase
{
    public override void Up()
    {
        AddUsecaseGroup("Memorias").AddUseCaseSubGrup("Fotos")
            .AddCommand("GirarFoto", new GirarFotoInput(), new GirarFotoOutput())
            .Authorization(Authorization.User).AddScope("memorias.foto.editar");
    }
}

public sealed record GirarFotoInput(int AlbumFotoId = 0, int Rotacao = 0);
public sealed record GirarFotoOutput(int AlbumFotoId = 0, int Rotacao = 0);
