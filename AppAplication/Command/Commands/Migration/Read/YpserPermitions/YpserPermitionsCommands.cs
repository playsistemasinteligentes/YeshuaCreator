using RepositoryInterfaces.Patterns.Command;
namespace Command.Read
{
    public struct YpserPermitionsReadCommand : ICommandRead
    {
        public int? UserId { get; set; }
        public string PermitionsId { get; set; }
 public Pagination Paginacao { get; set; }
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationCommandCommandsMigration