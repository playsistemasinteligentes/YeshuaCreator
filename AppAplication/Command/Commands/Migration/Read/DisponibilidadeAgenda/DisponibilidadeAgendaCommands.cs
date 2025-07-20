using RepositoryInterfaces.Patterns.Command;
namespace Command.Read
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