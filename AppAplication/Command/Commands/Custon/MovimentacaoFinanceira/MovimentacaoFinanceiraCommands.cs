using Comandos.Pateners.Command;
using Dominio.TiposPrimitivos;

namespace Comandos.Commands.Clinica
{
    public class ClinicaCommand : ICommand
    {
        public int Id { get; set; }
        public int PacienteId { get; set; }
        public int ServicoId { get; set; }
        public Decimal Valor { get; set; }
        public int TipoMovimentacao { get; set; }
        public DateTime DataMovimentacao { get; set; }
        public Decimal SaldoAtual { get; set; }

        public event EventHandler? CanExecuteChanged;

    }
}
