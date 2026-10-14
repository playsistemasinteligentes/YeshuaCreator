using Dominio.Migration;

namespace Yeshua.Studio.Memorias.Migrations;

[Migration(000003)]
public sealed class M000003 : MigrationBase
{
    public override void Up() => AddCustomPage(
        "MEM", "Estudio Memorias", "memorias-estudio", "memorias.estudio.visualizar", "Publicar memorias");
}
