using Comandos.Pateners.Command;
using Dominio.TiposPrimitivos;
namespace Command.Commands.Read
{
    public class DisponibilidadeAgendaReadCommand : ICommand
    {
        public int Id { get; set; }
        public int ProfissionalId { get; set; }
        public DateTime DataHora { get; set; }
    }
}
