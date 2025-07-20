using RepositoryInterfaces.Patterns.Command;
namespace Command.Read
{
    public struct EspecialidadeReadCommand : ICommandRead
    {
        public int? Id { get; set; }
        public string Descricao { get; set; }
 public Pagination Paginacao { get; set; }
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationCommandCommandsMigration