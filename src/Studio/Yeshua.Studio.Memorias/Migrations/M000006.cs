using Dominio.Migration;

namespace Yeshua.Studio.Memorias.Migrations;

[Migration(000006)]
public sealed class M000006 : MigrationBase
{
    public override void Up()
    {
        // Campos consolidados em M000001 para recriacao da base de testes.
        // Preserva a identidade ja registrada pela projecao de autorizacao da Central.
    }
}
