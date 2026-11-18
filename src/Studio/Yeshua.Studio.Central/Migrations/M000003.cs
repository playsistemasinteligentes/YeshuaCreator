using Dominio;
using Dominio.Migration;
using Migration.Dominio.Schemas.CQRS;

namespace Yeshua.Studio.Central.Migrations;

[Migration(000003)]
public sealed class M000003 : MigrationBase
{
    public override void Up()
    {
        AddModule("COBRANCA", "Cobranca e contratacoes");
        AddCustomPage("COBRANCA", "Creditos e contratacoes", "central-financeiro", "central.financeiro", "Minha conta");
        AddEntity("CarteiraCredito").InternalToUseCase("Central", "Financeiro", "ExecutarFinanceiro")
            .AddColumn("Id", "ID").Varchar(32).Key()
            .AddColumn("Saldo", "Saldo").Decimal(18, 4).NotNull();
        AddEntity("CobrancaCredito").InternalToUseCase("Central", "Financeiro", "ExecutarFinanceiro")
            .AddColumn("Id", "ID").Varchar(64).Key()
            .AddColumn("Creditos", "Creditos").Decimal(18, 4).NotNull()
            .AddColumn("Valor", "Valor em reais").Decimal(18, 2).NotNull()
            .AddColumn("Status", "Estado").Int().NotNull()
            .AddColumn("CriadaEmUtc", "Criada em UTC").DateTime().NotNull()
            .AddColumn("VenceEmUtc", "Vencimento UTC").DateTime().NotNull()
            .AddColumn("Moeda", "Moeda").Varchar(3).NotNull()
            .AddColumn("Provedor", "Provedor").Varchar(30).NotNull()
            .AddColumn("PagaEmUtc", "Paga em UTC").DateTime();
        AddEntity("MovimentoCredito").InternalToUseCase("Central", "Financeiro", "ExecutarFinanceiro")
            .AddColumn("Id", "ID").Varchar(64).Key()
            .AddColumn("Tipo", "Tipo").Varchar(30).NotNull()
            .AddColumn("Referencia", "Referencia").Varchar(100).NotNull()
            .AddColumn("Quantidade", "Creditos").Decimal(18, 4).NotNull()
            .AddColumn("SaldoApos", "Saldo apos").Decimal(18, 4).NotNull()
            .AddColumn("CriadoEmUtc", "Criado em UTC").DateTime().NotNull();
        AddEntity("DireitoUsoContratado").InternalToUseCase("Central", "Financeiro", "ExecutarFinanceiro")
            .AddColumn("Id", "ID").Varchar(64).Key()
            .AddColumn("ResourceKey", "Recurso").Varchar(100).NotNull()
            .AddColumn("PeriodUntilUtc", "Validade").DateTime()
            .AddColumn("GrantedUnits", "Quantidade contratada").Decimal(18, 4).NotNull();
        AddEntity("ContratacaoUso").InternalToUseCase("Central", "Financeiro", "ExecutarFinanceiro")
            .AddColumn("Id", "ID").Varchar(64).Key()
            .AddColumn("Oferta", "Oferta").Varchar(100).NotNull()
            .AddColumn("Quantidade", "Quantidade").Int().NotNull()
            .AddColumn("Creditos", "Creditos contratados").Decimal(18, 4).NotNull()
            .AddColumn("CriadaEmUtc", "Criada em UTC").DateTime().NotNull();
        var commands = AddUsecaseGroup("Central").AddUseCaseSubGrup("Financeiro");
        foreach (var command in new[] { "ConsultarFinanceiro", "CriarRecarga", "ConfirmarPagamentoTeste", "ContratarUso" })
            commands.AddCommand(command, new FinanceiroInput(), new FinanceiroOutput()).Authorization(Authorization.User);
        commands.AddCommand("AtualizarAcesso", new FinanceiroInput(), new FinanceiroOutput()).Authorization(Authorization.ApplicationEntry);
        commands.AddCommand("ExecutarFinanceiro", new ExecucaoFinanceiroInput(), new FinanceiroOutput()).Internal();
    }
}

public class FinanceiroInput
{
    public string RequestId { get; set; } = "";
    public string CobrancaId { get; set; } = "";
    public string Oferta { get; set; } = "";
    public int Quantidade { get; set; } = 1;
    public decimal Creditos { get; set; }
}

public sealed class ExecucaoFinanceiroInput : FinanceiroInput
{
    public string Operacao { get; set; } = "";
}

public sealed class FinanceiroOutput
{
    public decimal Saldo { get; set; }
    public bool Simulacao { get; set; }
    public string CobrancaId { get; set; } = "";
    public string Token { get; set; } = "";
    public string Direitos { get; set; } = "";
    public List<OfertaFinanceiraInfo> Ofertas { get; set; } = [];
    public List<DireitoFinanceiroInfo> Contratacoes { get; set; } = [];
    public List<MovimentoFinanceiroInfo> Movimentos { get; set; } = [];
    public List<CobrancaFinanceiraInfo> Cobrancas { get; set; } = [];
}

public sealed record OfertaFinanceiraInfo(string Codigo = "", string Titulo = "", string Aplicativo = "", string Recurso = "",
    string Modelo = "", decimal PrecoCreditos = 0, int Meses = 0, decimal Unidades = 0);
public sealed record DireitoFinanceiroInfo(string Recurso = "", string ValidoAteUtc = "", decimal UnidadesContratadas = 0);
public sealed record MovimentoFinanceiroInfo(string Tipo = "", string Referencia = "", decimal Quantidade = 0,
    decimal SaldoApos = 0, string CriadoEmUtc = "");
public sealed record CobrancaFinanceiraInfo(string Id = "", decimal Creditos = 0, decimal Valor = 0, int Status = 0);
