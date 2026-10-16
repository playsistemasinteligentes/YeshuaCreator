using Dominio.Migration;

namespace Yeshua.Studio.Memorias.Migrations;

[Migration(000008)]
public sealed class M000008 : MigrationBase
{
    public override void Up()
    {
        AddUsecaseGroup("Memorias").AddUseCaseSubGrup("Canais")
            .AddCommand("ReservarCanalStandard", new ReservarCanalStandardInput(), new ReservarCanalStandardOutput())
            .Internal();
    }
}

public sealed record ReservarCanalStandardInput(bool SomenteConsultar = false);
public sealed record ReservarCanalStandardOutput(bool Disponivel = false, int CanalStandardId = 0,
    string CanalId = "", string ConexaoYouTubeId = "", int CredencialTenantId = 0);
