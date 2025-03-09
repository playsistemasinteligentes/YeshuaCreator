using Comandos.Pateners.Command;
using Dominio.TiposPrimitivos;
namespace Command.Commands
{
    public class DisponibilidadeAgendaCrudCommand : ICommand
    {
        public int? Id { get; set; }
        public int? ProfissionalId { get; set; }
        public DateTime DataHora { get; set; }
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationCommandCommandsMigration