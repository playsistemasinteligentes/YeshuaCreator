using Dominio.Migration;
using Migration.Dominio.Schemas.CQRS;

namespace Yeshua.Studio.Fiscal.Migrations;

[Migration(000007)]
public class M000007 : MigrationBase
{
    public override void Up()
    {
        AddUsecaseGroup("Fiscal")
            .AddUseCaseSubGrup("CTeUtilitarios")
            .AddCommand(
                "CancelarCTe",
                new CancelarCTeInput(string.Empty, string.Empty, 1),
                new EventoFiscalOutput(string.Empty, false, 0, string.Empty, string.Empty, 0))
            .Authorization(Authorization.User)
            .AddScope("fiscal.cte.utilitarios.cancelar")
            .AddEntity("CTeTentativaEmissao");

        AddUsecaseGroup("Fiscal")
            .AddUseCaseSubGrup("CTeUtilitarios")
            .AddCommand(
                "CorrigirCTe",
                new CorrigirCTeInput(string.Empty, string.Empty, string.Empty, string.Empty, 0, 1),
                new EventoFiscalOutput(string.Empty, false, 0, string.Empty, string.Empty, 0))
            .Authorization(Authorization.User)
            .AddScope("fiscal.cte.utilitarios.corrigir")
            .AddEntity("CTeTentativaEmissao");

        AddUsecaseGroup("Fiscal")
            .AddUseCaseSubGrup("MDFeUtilitarios")
            .AddCommand(
                "CancelarMDFe",
                new CancelarMDFeInput(string.Empty, string.Empty, 1),
                new EventoFiscalOutput(string.Empty, false, 0, string.Empty, string.Empty, 0))
            .Authorization(Authorization.User)
            .AddScope("fiscal.mdfe.utilitarios.cancelar")
            .AddEntity("MDFeTentativaEmissao");

        AddUsecaseGroup("Fiscal")
            .AddUseCaseSubGrup("MDFeUtilitarios")
            .AddCommand(
                "IncluirCondutorMDFe",
                new IncluirCondutorMDFeInput(string.Empty, string.Empty, string.Empty, 1),
                new EventoFiscalOutput(string.Empty, false, 0, string.Empty, string.Empty, 0))
            .Authorization(Authorization.User)
            .AddScope("fiscal.mdfe.utilitarios.condutor.incluir")
            .AddEntity("MDFeTentativaEmissao");
    }
}

public sealed record CancelarCTeInput(
    string ChaveAcesso,
    string Justificativa,
    int SequenciaEvento);

public sealed record CorrigirCTeInput(
    string ChaveAcesso,
    string GrupoAlterado,
    string CampoAlterado,
    string ValorAlterado,
    int NumeroItemAlterado,
    int SequenciaEvento);

public sealed record CancelarMDFeInput(
    string ChaveAcesso,
    string Justificativa,
    int SequenciaEvento);

public sealed record IncluirCondutorMDFeInput(
    string ChaveAcesso,
    string NomeCondutor,
    string CpfCondutor,
    int SequenciaEvento);

public sealed record EventoFiscalOutput(
    string ChaveAcesso,
    bool Registrado,
    int CodigoRetorno,
    string Motivo,
    string ProtocoloEvento,
    int HttpStatusCode);
