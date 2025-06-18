using Comandos.Pateners.Command;
using Command.Patterns.Command;
using Dominio.TiposPrimitivos;
namespace Command.Commands.Read
{
    public struct DisponibilidadeAgendaReadCommand : ICommandRead
    {
        public int? Id { get; set; }
        public int? ProfissionalId { get; set; }
        public DateTime? DataHora { get; set; }
 public Pagination Paginacao { get; set; }
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationCommandCommandsMigration