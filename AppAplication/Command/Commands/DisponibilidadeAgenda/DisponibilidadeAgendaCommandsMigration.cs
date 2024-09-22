using Comandos.Pateners.Command;
using Dominio.TiposPrimitivos;
namespace Comandos.Commands
{
    public class DisponibilidadeAgendaCommand : ICommand
    {
        public int Id { get; set; }
        public int ProfissionalId { get; set; }
        public DateTime DataHora { get; set; }
    }
}
