using Dominio.Migration;
using Migration.Dominio.Schemas.CQRS;

namespace Yeshua.Studio.Fiscal.Migrations;

[Migration(000004)]
public class M000004 : MigrationBase
{
    public override void Up()
    {
        AlterEntity("CertificadoDigital")
            .AddColumn("SenhaStorageKey", "Senha no Storage").Varchar(500).Group("Arquivo");

        AlterEntity("EntradaFiscalContingencia")
            .AddColumn("CertificadoDigitalId", "Certificado Digital")
                .FK("CertificadoDigital", "Id")
                .Int()
                .Group("SEFAZ");

        AddUsecaseGroup("Fiscal")
            .AddUseCaseSubGrup("SEFAZ")
            .AddCommand(
                "RegistrarCertificadoDigitalContingencia",
                new RegistrarCertificadoDigitalContingenciaInput(
                    0,
                    string.Empty,
                    string.Empty,
                    string.Empty,
                    string.Empty),
                new RegistrarCertificadoDigitalContingenciaOutput(
                    0,
                    string.Empty,
                    string.Empty,
                    null,
                    null,
                    false,
                    string.Empty))
            .Authorization(Authorization.User)
            .AddScope("fiscal.contingencia.certificado.registrar")
            .AddEntity("CertificadoDigital")
            .AddEntity("EntradaFiscalContingencia");
    }
}

public sealed record RegistrarCertificadoDigitalContingenciaInput(
    int EntradaFiscalContingenciaId,
    string DocumentoTitular,
    string Apelido,
    string ArquivoPfxBase64,
    string Senha);

public sealed record RegistrarCertificadoDigitalContingenciaOutput(
    int CertificadoDigitalId,
    string DocumentoTitular,
    string Thumbprint,
    DateTime? ValidoDe,
    DateTime? ValidoAte,
    bool Reutilizado,
    string Mensagem);
