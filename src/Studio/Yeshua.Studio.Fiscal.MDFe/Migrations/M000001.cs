using Dominio.Migration;

namespace Yeshua.Studio.Fiscal.MDFe.Migrations;

[Migration(000001)]
public class M000001 : MigrationBase
{
    public override void Up()
    {
        AddModule("FIS", "Fiscal");

        AddEntity("MDFe").AddModule("FIS")
            .AddColumn("Id", "ID").Int().Incremento().Key()
            .AddColumn("ChaveAcesso", "Chave de Acesso").Varchar(44).NotNull()
            .AddColumn("Serie", "Serie").Int().NotNull()
            .AddColumn("Numero", "Numero").Int().NotNull()
            .AddColumn("UfCarregamento", "UF de Carregamento").Varchar(2).NotNull()
            .AddColumn("UfDescarregamento", "UF de Descarregamento").Varchar(2).NotNull()
            .AddColumn("PlacaVeiculo", "Placa do Veiculo").Varchar(7).NotNull()
            .AddColumn("EmitidoEm", "Emitido em").DateTime().NotNull()
            .AddColumn("AutorizadoEm", "Autorizado em").DateTime()
            .AddColumn("IniciadoEm", "Inicio do Transporte").DateTime()
            .AddColumn("EncerradoEm", "Encerrado em").DateTime()
            .AddColumn("CanceladoEm", "Cancelado em").DateTime()
            .AddColumn("Situacao", "Situacao do MDF-e").Int().NotNull()
                .Enumerable(1, "Autorizado")
                .Enumerable(2, "EmTransporte")
                .Enumerable(3, "Encerrado")
                .Enumerable(4, "Cancelado");

        AddEntity("MDFeEncerramento").AddModule("FIS")
            .AddColumn("Id", "ID").Int().Incremento().Key()
            .AddColumn("MDFeId", "MDF-e").FK("MDFe", "Id").Int().NotNull()
            .AddColumn("ChaveAcesso", "Chave de Acesso").Varchar(44).NotNull()
            .AddColumn("UfCarregamento", "UF de Carregamento").Varchar(2).NotNull()
            .AddColumn("UfDescarregamento", "UF de Descarregamento").Varchar(2).NotNull()
            .AddColumn("PlacaVeiculo", "Placa do Veiculo").Varchar(7).NotNull()
            .AddColumn("SolicitadoEm", "Solicitado em").DateTime().NotNull()
            .AddColumn("AutorizadoEm", "Autorizado em").DateTime()
            .AddColumn("Protocolo", "Protocolo SEFAZ").Varchar(20)
            .AddColumn("CodigoRetorno", "Codigo de Retorno").Varchar(10)
            .AddColumn("MensagemRetorno", "Mensagem de Retorno").Varchar(500);

        // AddQuery<MDFe>("AutorizadosParaEncerramento", q => q
        //     .WhereContext("EmTransporte", x => x.Situacao == 2)
        //     .Where("Geral", x => x.Situacao == 2)
        //     .Select(x => new
        //     {
        //         x.Id,
        //         x.ChaveAcesso,
        //         x.Serie,
        //         x.Numero,
        //         x.UfCarregamento,
        //         x.UfDescarregamento,
        //         x.PlacaVeiculo,
        //         x.EmitidoEm,
        //         x.IniciadoEm,
        //         x.Situacao
        //     }));

        AddUsecaseGroup("FiscalMDFe")
            .AddUseCaseSubGrup("Encerramento")
            .AddCommand(
                "EncerrarMDFe",
                new EncerrarMDFeInput(string.Empty, string.Empty, string.Empty, string.Empty),
                new EncerrarMDFeOutput(string.Empty, false, string.Empty, string.Empty, null))
            .Authorization(Migration.Dominio.Schemas.CQRS.Authorization.User)
            .AddScope("mdfe.encerrar")
            .AddEntity("MDFe");
    }
}

public sealed record EncerrarMDFeInput(
    string ChaveAcesso,
    string UfCarregamento,
    string UfDescarregamento,
    string PlacaVeiculo);

public sealed record EncerrarMDFeOutput(
    string ChaveAcesso,
    bool Encerrado,
    string Protocolo,
    string Mensagem,
    DateTime? EncerradoEm);

public sealed class MDFe
{
    public int Id { get; set; }
    public string ChaveAcesso { get; set; } = string.Empty;
    public int Serie { get; set; }
    public int Numero { get; set; }
    public string UfCarregamento { get; set; } = string.Empty;
    public string UfDescarregamento { get; set; } = string.Empty;
    public string PlacaVeiculo { get; set; } = string.Empty;
    public DateTime EmitidoEm { get; set; }
    public DateTime? AutorizadoEm { get; set; }
    public DateTime? IniciadoEm { get; set; }
    public DateTime? EncerradoEm { get; set; }
    public DateTime? CanceladoEm { get; set; }
    public int Situacao { get; set; }
}
