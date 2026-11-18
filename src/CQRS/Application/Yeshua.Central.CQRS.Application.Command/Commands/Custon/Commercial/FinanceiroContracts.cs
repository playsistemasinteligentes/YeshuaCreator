namespace Command.UseCase;

public interface IFinanceiroResult
{
    decimal Saldo { get; set; }
    bool Simulacao { get; set; }
    string CobrancaId { get; set; }
    string Token { get; set; }
    string Direitos { get; set; }
    List<OfertaFinanceiraInfo> Ofertas { get; set; }
    List<DireitoFinanceiroInfo> Contratacoes { get; set; }
    List<MovimentoFinanceiroInfo> Movimentos { get; set; }
    List<CobrancaFinanceiraInfo> Cobrancas { get; set; }
}

public partial record ConsultarFinanceiroOutputCommand : IFinanceiroResult;
public partial record CriarRecargaOutputCommand : IFinanceiroResult;
public partial record ConfirmarPagamentoTesteOutputCommand : IFinanceiroResult;
public partial record ContratarUsoOutputCommand : IFinanceiroResult;
public partial record AtualizarAcessoOutputCommand : IFinanceiroResult;
public partial record ExecutarFinanceiroOutputCommand : IFinanceiroResult;
public partial record AdicionarCreditosCarteiraOutputCommand : IFinanceiroResult;
public partial record AlocarCreditosCarteiraOutputCommand : IFinanceiroResult;

public static class FinanceiroResults
{
    public static T Copy<T>(IFinanceiroResult source) where T : IFinanceiroResult, new() => new()
    {
        Saldo = source.Saldo, Simulacao = source.Simulacao, CobrancaId = source.CobrancaId,
        Token = source.Token, Direitos = source.Direitos, Ofertas = source.Ofertas,
        Contratacoes = source.Contratacoes, Movimentos = source.Movimentos, Cobrancas = source.Cobrancas
    };
}
