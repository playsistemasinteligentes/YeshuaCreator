using RepositoryInterfaces.Patterns.Command;
namespace Command.Read
{
    public struct YpserPermitionsReadCommand : ICommandRead
    {
        public string PermitionsId { get; set; }
 public Pagination Paginacao { get; set; }
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationCommandCommandsMigration