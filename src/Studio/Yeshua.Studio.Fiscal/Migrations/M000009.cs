using Dominio.Migration;
using Migration.Dominio.Schemas.CQRS;

namespace Yeshua.Studio.Fiscal.Migrations;

[Migration(000009)]
public class M000009 : MigrationBase
{
    public override void Up()
    {
        AddUsecaseGroup("Fiscal")
            .AddUseCaseSubGrup("CTeUtilitarios")
            .AddCommand(
                "CancelarCTeExterno",
                new CancelarCTeExternoInput(string.Empty, string.Empty, 1, string.Empty, 1),
                new EventoFiscalOutput(string.Empty, false, 0, string.Empty, string.Empty, 0))
            .Authorization(Authorization.User)
            .AddScope("fiscal.cte.utilitarios.cancelar")
            .AddEntity("CertificadoDigital");
    }
}

public sealed record CancelarCTeExternoInput(
    string ChaveAcesso,
    string ProtocoloAutorizacao,
    int Ambiente,
    string Justificativa,
    int SequenciaEvento);
