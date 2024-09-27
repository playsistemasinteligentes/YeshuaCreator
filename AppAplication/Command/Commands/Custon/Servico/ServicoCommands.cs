using Comandos.Pateners.Command;
using Dominio.TiposPrimitivos;

namespace Comandos.Commands.Clinica
{
    public class ClinicaCommand : ICommand
    {
        public int Id { get; set; }
        public int GrupoServicoId { get; set; }
        public string Nome { get; set; }
        public Decimal Valor { get; set; }

        public event EventHandler? CanExecuteChanged;

    }
}
