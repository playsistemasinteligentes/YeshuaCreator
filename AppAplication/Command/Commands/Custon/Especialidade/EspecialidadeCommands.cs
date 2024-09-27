using Comandos.Pateners.Command;
using Dominio.TiposPrimitivos;

namespace Comandos.Commands.Clinica
{
    public class ClinicaCommand : ICommand
    {
        public int Id { get; set; }
        public string Descricao { get; set; }

        public event EventHandler? CanExecuteChanged;

    }
}
