using Dominio.Migration;
using Migration.Dominio.Schemas.CQRS;

namespace Yeshua.Studio.Memorias.Migrations;

[Migration(000006)]
public sealed class M000006 : MigrationBase
{
    public override void Up()
    {
        AlterEntity("Album")
            .AddColumn("QualidadeVideo", "Qualidade do Video").Int().Group("Renderizacao")
                .Enumerable(1, "Economica (HD 720p)")
                .Enumerable(2, "Padrao (Full HD 1080p)")
                .Enumerable(3, "Alta (4K 2160p)");

        AlterEntity("PublicacaoAlbum")
            .AddColumn("QualidadeVideo", "Qualidade do Video").Int().Immutable().Group("Renderizacao")
                .Enumerable(1, "Economica (HD 720p)")
                .Enumerable(2, "Padrao (Full HD 1080p)")
                .Enumerable(3, "Alta (4K 2160p)");
    }
}
