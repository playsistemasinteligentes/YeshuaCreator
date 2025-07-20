using RepositoryInterfaces.Patterns.Command;
namespace Command.Read
{
    public struct YperfilPermitionsReadCommand : ICommandRead
    {
        public int? PerfilId { get; set; }
        public string PermitionsId { get; set; }
 public Pagination Paginacao { get; set; }
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationCommandCommandsMigration