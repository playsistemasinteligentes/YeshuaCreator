using Comandos.Pateners.Command;
using Dominio.TiposPrimitivos;
namespace Comandos.Commands
{
    public class MovimentacaoFinanceiraCommand : ICommand
    {
        public int Id { get; set; }
        public int PacienteId { get; set; }
        public int ServicoId { get; set; }
        public Decimal Valor { get; set; }
        public int TipoMovimentacao { get; set; }
        public DateTime DataMovimentacao { get; set; }
        public Decimal SaldoAtual { get; set; }
    }
}
