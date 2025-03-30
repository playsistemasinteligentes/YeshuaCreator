using Comandos.Pateners.Command;
using Dominio.TiposPrimitivos;
namespace Command.Commands.Read
{
    public struct DisponibilidadeAgendaReadCommand : ICommand
    {
        public int? Id { get; set; }
        public int? ProfissionalId { get; set; }
        public DateTime? DataHora { get; set; }
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationCommandCommandsMigration