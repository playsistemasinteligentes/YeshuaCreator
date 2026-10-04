using Dominio.Migration;
using Migration.Dominio.Schemas.CQRS;

namespace Yeshua.Studio.Fiscal.Migrations;

[Migration(000008)]
public class M000008 : MigrationBase
{
    public override void Up()
    {
        AddUsecaseGroup("Fiscal")
            .AddUseCaseSubGrup("MDFeUtilitarios")
            .AddCommand(
                "EncerrarMDFePorChave",
                new EncerrarMDFePorChaveInput(string.Empty, string.Empty, 2, 0, 0, string.Empty, 1),
                new EventoFiscalOutput(string.Empty, false, 0, string.Empty, string.Empty, 0))
            .Authorization(Authorization.User)
            .AddScope("fiscal.mdfe.utilitarios.encerrar")
            .AddEntity("MDFeTentativaEmissao");
    }
}

public sealed record EncerrarMDFePorChaveInput(
    string ChaveAcesso,
    string ProtocoloAutorizacao,
    int Ambiente,
    int CodigoUfEncerramento,
    int CodigoMunicipioEncerramento,
    string DataEncerramento,
    int SequenciaEvento);
