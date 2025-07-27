using RepositoryInterfaces.Patterns.Command;
namespace Command.Read
{
    public struct YuserPermitionsReadCommand : ICommandRead
    {
        public string PermitionsId { get; set; }
        public int? UserId { get; set; }
 public Pagination Paginacao { get; set; }
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationCommandCommandsMigration