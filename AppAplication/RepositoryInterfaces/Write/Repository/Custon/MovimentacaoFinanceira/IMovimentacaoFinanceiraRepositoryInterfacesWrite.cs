// 
public partial interface  MovimentacaoFinanceira
{
    public int Id { get; set; }
    public int PacienteId { get; set; }
    public int ServicoId { get; set; }
    public Decimal Valor { get; set; }
    public int TipoMovimentacao { get; set; }
    public DateTime DataMovimentacao { get; set; }
    public Decimal SaldoAtual { get; set; }
}
